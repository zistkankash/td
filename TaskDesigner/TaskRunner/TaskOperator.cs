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
		public static float gzX, gzY;
		public TaskData tsk;
		int Marker_Radius = 10;
		private Size secondMonit;
		public static string savedData = "";

		public string getSavPath { get { return txtSavPath.Text; } }
		
		public RunConfig getRunConfigs
		{
			get
			{
				RunConfig r = new RunConfig();
				if (chBx_prompt.Checked)
					r.showGoalPrompt = true;

				if (chbx_NMshowarrow.Checked)
					r.showArrow = true;
				
				if (chbx_sound.Checked)
					r.useSound = true;

				if (chbx_usemouse.Checked)
					r.useCursor = true;
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
			Bitmap b = (Bitmap)pbOper.Image;
			Graphics flagGraphics = Graphics.FromImage(pbOper.Image);
			

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
			btnStart.Enabled = false;
			tsk.runConf = getRunConfigs;
			runner.RunTask(GetETStat());
			runner.Show();
			btStop.Enabled = true;
			txtSavPath.Enabled = false;
			txtbxTask.Enabled = false;
			refTimer.Start();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private bool GetETStat()
		{
			int ans = 2;
			if (et_socket != null)
				ans = et_socket.IsCalibrated;
			if (ans == 2)
			{
				DialogResult dt = MetroMessageBox.Show((IWin32Window)this, "ET was not connected. Run in offline mode?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (dt == DialogResult.OK)
					return false;
				else
				{
					MetroMessageBox.Show((IWin32Window)this, "Press Connect in ET connection window...", "Connecting...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					et_socket.GazeTracker = null;
					et_socket.StartListening();
					while (et_socket.GazeTracker == null) ;
					return true;
				}
			}

			if (ans == 1)
				return true;

			if (ans == 0)
			{
				MetroMessageBox.Show((IWin32Window)this, "Due to lack of calibrated data in ET, task is running in offline mode.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			runner = new TaskRunner(et_socket, tsk, this, false);
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
				btStop.Enabled = false;
				btnStart.Enabled = true;
				txtbxTask.Enabled = true;
				txtSavPath.Enabled = true;
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
				savedData = "";
			}
			txtSavPath.Text = FileName.UpdateFileName(false, txtSavPath.Text);
			if (num < tsk.picList.Count)
				pbOper.Image = tsk.picList[num].image;
			else
			{
				txtbxTask.Enabled = true;
				txtSavPath.Enabled = true;
				btnStart.Enabled = true;
				btStop.Enabled = false;
			}
		}
	}

	public enum TaskRunMod { recursive , reward}
	
	public struct RunConfig { public GroupingMod shapeGroupingMode; public TaskRunMod taskRunMode; public bool showArrow; public bool showGoalPrompt; public bool useCursor; public bool useSound; }
}