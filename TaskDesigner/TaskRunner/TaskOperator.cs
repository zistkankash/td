using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Basics;
using MetroFramework;
using TaskDesigner;

namespace TaskRunning
{

	/// <summary>
	/// This form get task and saving output address.
	/// Operator can set task running configurtion in setting tab.
	/// Taskrunner called when start run button pressed.
	/// </summary>
	public partial class TaskOperator : Form
	{
		SaveFileDialog sfd = null;
		TaskRunner runner = null;
		Bitmap _operationBitmap, tempBitmap;
		
		ETStatus _etStat = ETStatus.disconnected;
		public static float gzX, gzY;
		public TaskClient tsk;
		int Marker_Radius = 5;
		private Size triableScreen;
		int _slideNum = 0;
		public static bool _stopped = false;
		PsycophysicsRunner shFrame;
		//int i = 0;
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

				if (chbx_useMouseGaze.Checked)
					r.useCursor = true;

				if (chbx_showarrow.Checked)
					r.showArrow = true;

				if (chbuseMouseNextFrm.Checked)
					r.useCursorNextFrm = true;
				
				if(ckbxParOut.Checked)
					r.ParAddress = int.Parse(txtbxParAddress.Text, System.Globalization.NumberStyles.HexNumber);
								
				try
					{ r.gazNumSmoth = short.Parse(txtNumGazeSmth.Text); }
				catch (Exception) { r.gazNumSmoth = 5; txtNumGazeSmth.Text = 5.ToString(); }
				return r;
			}
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;
		Screen[] screens;

		public TaskOperator()
		{
			InitializeComponent();
			screens = Screen.AllScreens;
			triableScreen = new Size(screens[BasConfigs._triableMonitor].Bounds.Width, screens[BasConfigs._triableMonitor].Bounds.Height);
			tsk = new TaskClient();
			_operationBitmap = new Bitmap(pbOper.Width, pbOper.Height);
		}

		void RefreshPctBx()
		{
			//i++;
			//gzX = (float)i %1440;
			//gzY = (float)i %900;
			if (!_stopped)
			{
				if (tsk.Type == TaskType.media)
				{
					BitmapManager.Screenshot(out tempBitmap, screens[BasConfigs._triableMonitor].Bounds.Location, new Size(screens[BasConfigs._triableMonitor].Bounds.Width, screens[BasConfigs._triableMonitor].Bounds.Height));
					_operationBitmap = BitmapManager.DrawOn(tempBitmap, pbOper.Size, Color.White);
				}
				if (tsk.Type == TaskType.cognitive && shFrame.opFlag != null)
				{
					_operationBitmap = shFrame.opFlag;
					//_operationBitmap = BitmapManager.DrawOn(shFrame.opFlag, pbOper.Size, Color.White);
				}

				Graphics flagGraphics = Graphics.FromImage(_operationBitmap);
				flagGraphics.FillEllipse(Brushes.Red, (float)gzX * pbOper.Width / triableScreen.Width - Marker_Radius / 2, (float)gzY * pbOper.Height / triableScreen.Height - Marker_Radius / 2, Marker_Radius, Marker_Radius);

				flagGraphics.Flush();
			}
			//pbOper.Image.Dispose();
			pbOper.Image = _operationBitmap;

		}

		void txtPath_Click(object sender, EventArgs e)
		{
			txtSavPath.Text = CrtSaveFile();
		}

		void btnStart_Click_1(object sender, EventArgs e)
		{
			try
			{
				if (!tsk.IsReady)
				{
					MetroMessageBox.Show((IWin32Window)this, "Please select correct task!", "Task Runner", MessageBoxButtons.OK, MessageBoxIcon.Hand, 100);
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
					refTimer.Start();
					refTimer.Enabled = true;
					tsk.SetRunConfig = getRunConfigs;
					if (tsk.Type == TaskType.cognitive)
					{
						tsk.PsycoPhysicsTask.Brake = false;
						bool st;
						if (_etStat == ETStatus.ready)
							st = true;
						else
							st = false;
						_stopped = false;
						shFrame = new PsycophysicsRunner(st ,pbOper.Width, pbOper.Height, tsk.PsycoPhysicsTask);
						shFrame.pupilDataPath = txtSavPath.Text;
						shFrame.eventDataPath = FileName.UpdateFileName(txtSavPath.Text, "events");
						shFrame.Show();
					}
					else
					{
						_stopped = false;
						if (tsk.Type == TaskType.media)
							runner = new TaskRunner(tsk.MediaTask, TaskType.media, this, _etStat == ETStatus.ready);
						else
							runner = new TaskRunner(tsk.PsycoTask, TaskType.lab, this, (_etStat == ETStatus.ready));
						
						runner.Show();
											
					}
					
					SetControlsLocked();
										
				}
			}
			catch(Exception)
			{
				EndTask();
				refTimer.Stop();
				return;
			}
            Application.OpenForms[this.Name].Select();
			
		}

		/// <summary>
		/// Get ET socket status to run the task.
		/// </summary>
		/// <returns></returns>
		bool GetETStat()
		{
			if (BasConfigs.server != null)
			{
				if (BasConfigs.server.serverDisposed)
					_etStat = ETStatus.disconnected;
				else
					_etStat = BasConfigs.server.IsCalibrated;
			}
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
		
		void SetControlsLocked()
		{
			groupBox1.Enabled = false;
			groupBox2.Enabled = false;
			groupBox3.Enabled = false;
			groupBox4.Enabled = false;
			
			pnlErr1.Enabled = false;
			pnlRunMode.Enabled = false;
			btnClose.Enabled = false;
			txtSavPath.Enabled = false;
			txtbxTask.Enabled = false;
			btnStop.Enabled = true;
		}

		void SetControlsOpened()
		{
			groupBox1.Enabled = true;
			groupBox2.Enabled = true;
			groupBox3.Enabled = true;
			groupBox4.Enabled = true;
			
			pnlErr1.Enabled = true;
			pnlRunMode.Enabled = true;
			btnClose.Enabled = true;
			txtSavPath.Enabled = true;
			txtbxTask.Enabled = true;
			btnStop.Enabled = false;
		}
		
		void TaskOperator_Load(object sender, EventArgs e)
		{
			
		}

		string CrtSaveFile()
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
			{
			
				return sfd.FileName;
			}
			else
				return "";
		}
		
		void setTextTask()
		{
			if (tsk.LoadTask(true))
			{
				txtbxTask.Text = tsk.Address;
				pbOper.SizeMode = PictureBoxSizeMode.StretchImage;
				tsk.GetFrameImage(0, ref _operationBitmap);
				pbOper.Image = _operationBitmap;
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

		void TaskOperator_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				if (!btnStart.Enabled && btnStop.Enabled)
				{
					MetroMessageBox.Show((IWin32Window)this, "Please press \"Stop Task\" first!");
					return;
				}
				this.Close();
				e.Handled = true;
			}
		}

		void btStop_Click(object sender, EventArgs e)
		{
			if (tsk.Type == TaskType.cognitive)
			{
				tsk.PsycoPhysicsTask.Brake = true;
				_stopped = true;

			}
			else
			{
				if (runner != null && runner.StopTask())
				{
					SavePupilData();
					_stopped = true;
				}
			}
			
		}

		void refTimer_Tick(object sender, EventArgs e)
		{
			if (_stopped == true)
			{
				EndTask();
				
				refTimer.Enabled = false;
				refTimer.Stop();
			}
			RefreshPctBx();
		}
		
		/// <summary>
		/// Saving pupil data in media(linguistic) tasks and psycology tasks is acomplished in this methode.
		/// Saving data in cognitive tasks has a methode in related class.
		/// </summary>
		void SavePupilData()
		{
			if (savedData != "")
			{
				File.WriteAllText(txtSavPath.Text, savedData);
				savedData = BasConfigs._monitor_resolution_x.ToString() + "," + BasConfigs._monitor_resolution_y.ToString() + "\n";
			}
		}

		public void SetNextSlide()
		{
			int num = tsk.MediaTask.showedIndex;
			if (num == 0)
			{
				txtSavPath.Text = FileName.AddNumToCSVFileName(true, txtSavPath.Text);
				return;
			}

			SavePupilData();

			if (num < tsk.MediaTask.PicList.Count)
			{
				txtSavPath.Text = FileName.AddNumToCSVFileName(false, txtSavPath.Text);
				_slideNum = num;
			}
			else
			{
				_stopped = true;
			}
		}
		
		void cmbTriableScreen_SelectedIndexChanged(object sender, EventArgs e)
		{
			BasConfigs.SetScreenConfigs(cmbTriableScreen.SelectedIndex);
		}
		
		/// <summary>
		/// Just set _stoped variable to false to Stop Running Task in Task Runner. calling EndTask from other methodes and classes not allowed.
		/// </summary>
		void EndTask()
		{
			_slideNum = 0;
			gzX = 0; gzY = 0;
			_operationBitmap = BitmapManager.TextBitmap("اتمام تسک", Color.Black, Brushes.White, pbOper.Size, 46);
			SetControlsOpened();
			txtbxTask.Enabled = true;
			txtSavPath.Enabled = true;
			btnStart.Enabled = true;
			btnStop.Enabled = false;
			
			//Select();
		}

		void Exit()
		{
			if (!btnStart.Enabled && btnStop.Enabled)
			{
				MetroMessageBox.Show((IWin32Window)this, "Please press Stop Task first!");
				return;
			}
			this.Close();
			
		}
		
		void tabPageEx1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		void tabPageEx4_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}
		
		private void txtbxTask_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Exit();
			else
				setTextTask();
		}

		private void txtSavPath_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Exit();
			else
				CrtSaveFile();
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			HelpForm hlp = new HelpForm();
			hlp.Show(Directory.GetCurrentDirectory() + "\\CogLABOperator.pdf");
		}
				
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

	
	}

	
}