using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basics;
using MetroFramework;
using MetroFramework.Forms;

namespace TaskRunning
{

	/// <summary>
	/// This form get task and saving output address.
	/// Operator can set task running configurtion in setting tab.
	/// Taskrunner called when start run button pressed.
	/// </summary>
	public partial class TaskOperator : MetroForm
	{
		SaveFileDialog sfd = null;
		OpenFileDialog ofd = null;
		TaskRunner runner = null;
		TaskServer et_socket;
		ETStatus _etStat = ETStatus.disconnected;
		public static float gzX, gzY;
		public TaskData tsk;
		int Marker_Radius = 10;
		private Size secondMonit;
		int _slideNum = 0;
		public static string savedData = BasConfigs._monitor_resolution_x.ToString() + "," + BasConfigs._monitor_resolution_y.ToString() + "\n";

		public string getSavPath { get { return txtSavPath.Text; } }
		
		public RunConfig getRunConfigs
		{
			get
			{
				RunConfig r = new RunConfig();
				if (chBx_prompt.Checked)
					r.showGoalPrompt = true;

				if (chkb_nmsPrompt.Checked)
					r.nmsShowGoalPrompt = true;
									
				if (chbx_sound.Checked)
					r.useSound = true;

				if (chkb_nmsSound.Checked)
					r.nmsUseSound = true;

				if (chbx_useMouseGaze.Checked)
					r.useCursor = true;

				if (chbx_showarrow.Checked)
					r.showArrow = true;

				if (chbx_NMshowarrow.Checked)
					r.nmsShowArrow = true;

				if (chbuseMouseNextFrm.Checked)
					r.useCursorNextFrm = true;
				return r;
			}
		}

		public TaskOperator(TaskServer sd)
		{
			InitializeComponent();
			et_socket = sd;
			
			Screen[] screens = Screen.AllScreens;
			secondMonit = new Size(screens[screens.Length-1].Bounds.Width, screens[screens.Length-1].Bounds.Height);
			tsk = new TaskData();
		}
		
		public void RefreshPctBx()
		{
			Bitmap b = tsk.GetSlideImage(_slideNum, pbOper.Size);
			Graphics flagGraphics = Graphics.FromImage(b);
			flagGraphics.FillEllipse(Brushes.Black, (float)gzX * pbOper.Width / secondMonit.Width - Marker_Radius / 2,(float) gzY * pbOper.Height / secondMonit.Height - Marker_Radius / 2, Marker_Radius, Marker_Radius);
			flagGraphics.Flush();
			pbOper.Image = b;
		}

		private void txtPath_Click(object sender, EventArgs e)
		{
			CrtSaveFile();
		}

		private void btnStart_Click_1(object sender, EventArgs e)
		{
			try
			{
				if (!tsk.taskIsReady)
				{
					MetroMessageBox.Show((IWin32Window)this, "Please select correct task!", "Task Runner", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				if (txtSavPath.Text == "")
				{
					Directory.CreateDirectory(@"C:\GazeData");
					txtSavPath.Text = @"C:\GazeData\slide.csv";
				}

				if (GetETStat())
				{
					btnStart.Enabled = false;
					runner = new TaskRunner(et_socket, tsk, this);
					tsk.runConf = getRunConfigs;
					runner.Show();
					if (_etStat == ETStatus.ready)
						runner.RunTask(true);
					else
						runner.RunTask(false);
					SetControlsLocked();
					btStop.Enabled = true;
					txtSavPath.Enabled = false;
					txtbxTask.Enabled = false;
					refTimer.Start();
				}
			}
			catch(Exception)
			{
				return;
			}
		}

		/// <summary>
		/// Get ET socket status to run the task.
		/// </summary>
		/// <returns></returns>
		private bool GetETStat()
		{
			if (et_socket != null)
				_etStat = et_socket.IsCalibrated;

			if (_etStat == ETStatus.disconnected || _etStat == ETStatus.listening)
			{
				DialogResult dt = MetroMessageBox.Show((IWin32Window)this, "ET was not connected. Run in offline mode?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

				if (dt == DialogResult.OK)
					return true;

				else
				{
					MetroMessageBox.Show((IWin32Window)this, "Please go to connection settings in ET and coglab and make connection.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					
					return false;
				}
			}

			if (_etStat == ETStatus.ready)
				return true;

			if (_etStat == ETStatus.not_calibrated)
			{
				DialogResult dt = MetroMessageBox.Show((IWin32Window)this, "Due to lack of calibrated data in ET, do you want to run the task in offline mode?", "Question", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				if (dt == DialogResult.OK)
					return true;
				else
					return false;
			}

			return false;
		}
		
		private void SetControlsLocked()
		{
			metroPanel1.Enabled = false;
			metroPanel2.Enabled = false;
			metroPanel3.Enabled = false;
			metroPanel4.Enabled = false;
		}

		private void SetControlsOpened()
		{
			metroPanel1.Enabled = true;
			metroPanel2.Enabled = true;
			metroPanel3.Enabled = true;
			metroPanel4.Enabled = true;
		}
		
		private void TaskOperator_Load(object sender, EventArgs e)
		{
			BringToFront();
			txtbxTask.Select();
			this.KeyDown += new KeyEventHandler(TaskOperator_KeyDown);
		}

		private string CrtSaveFile()
		{
			sfd = new SaveFileDialog();
			string TaskFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			sfd.InitialDirectory = TaskFolder;
			sfd.Title = "Create CSV File to Write Gaze Points Data";
			sfd.CustomPlaces.Add(@"C:\");
			sfd.CustomPlaces.Add(@"C:\Program Files\");
			sfd.CustomPlaces.Add(@"K:\Documents\");
			sfd.Filter = "Excel Files (.csv) |*.csv";
			if (sfd.ShowDialog() == DialogResult.OK)
				return sfd.FileName;
			else
				return "";
		}
		
		private void setTextTask()
		{
			if (tsk.LoadTask(false))
			{
				txtbxTask.Text = tsk.tskAddress;
				pbOper.SizeMode = PictureBoxSizeMode.StretchImage;
				pbOper.Image = tsk.GetSlideImage(0,pbOper.Size);
				btnStart.Enabled = true;
			}
			else
			{
				MetroMessageBox.Show((IWin32Window)this, "Wrong or Corrupted Task File", "Error", 100);
				
			}
		}
		
		private void txtbxTask_Click(object sender, EventArgs e)
		{
			setTextTask();
		}

		private void txtSavPath_Click(object sender, EventArgs e)
		{
			txtSavPath.Text = CrtSaveFile();
		}

		private void TaskOperator_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void btStop_Click(object sender, EventArgs e)
		{
			if (runner.StopTask())
			{
				Stop();
			}
		}

		private void refTimer_Tick(object sender, EventArgs e)
		{
			RefreshPctBx();
		}

		public void SetNextSlide(int num)
		{
			if (num == 0)
			{
				txtSavPath.Text = FileName.UpdateFileName(true, txtSavPath.Text);
				return;
			}

			if (savedData != "")
			{
				File.WriteAllText(txtSavPath.Text, savedData);
				savedData = BasConfigs._monitor_resolution_x.ToString() + "," + BasConfigs._monitor_resolution_y.ToString() + "\n";
			}

			if (num < tsk.picList.Count)
			{
				txtSavPath.Text = FileName.UpdateFileName(false, txtSavPath.Text);
				_slideNum = num;
			}
			else
			{
				Stop();
			}
		}

		public void Stop()
		{
			_slideNum = 0;
			gzX = 0; gzY = 0;
			refTimer.Stop();
			pbOper.Image = Basics.BitmapData.PutText("اتمام تسک", Color.Black, Brushes.White, pbOper.Size,46);
			SetControlsOpened();
			txtbxTask.Enabled = true;
			txtSavPath.Enabled = true;
			btnStart.Enabled = true;
			btStop.Enabled = false;
		}
	}

	
}