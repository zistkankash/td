using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Psychophysics;
using Psychophysics.Old;
using TaskRunning;

namespace Basics
{
    public partial class PsycoPhysicTask : XCoolForm.XCoolForm
    {
		public PsycophysicTasks _tsk = new PsycophysicTasks(20);
				
		Size namTxt, numTrilTxt, cmbSiz;
		public int ActiveCol;
		// Display Option
		
		//
		int TaskName = 1;
		//// DAQ
		public static int FrameRate = 125;
		//public static ValueRange InputValRange = ValueRange.V_Neg5To5;
		public static String DaqName = "USB-4704,BID#0";
		// Analog input
		//public static InstantAiCtrl instantAiCtrl = new InstantAiCtrl();
		public static int[] AInIndex = new int[2];
		// output
		//public static InstantDoCtrl instantDoCtrl = new InstantDoCtrl();
		public static int[] DOutIndex = new int[2];
		// Sound
		public static bool SoundMute = false;
		public static string WinPath = "./Resources/coin.wav", FailPath = "./Resources/fail.wav";
		RowStyle SaveRowStyle;

		List<List<int>> test = new List<List<int>>();
			
		private XmlThemeLoader xtl = new XmlThemeLoader();
		// Save Parameters
		
		// Keyboard
		
		// Stop
		
        bool eventLock = false;

        public PsycoPhysicTask()
		{
			InitializeComponent();
			_tsk.EnabledTask.Add(0);
			_tsk.NumerRepeat.Add(1);
			_tsk.AllLevelName.Add("Untitled" + (_tsk.AllLevelName.Count + 1));
			_tsk.BaseIndex.Add(0);
			NameTask_TB0.Text = _tsk.AllLevelName[0];
			//TaskIndex = new int[_tsk.NFrame];
			DOutIndex[0] = 0;
			DOutIndex[1] = 1;
			// initializaion for Analog Input index (X)
			AInIndex[0] = 0;
			// initializaion for Analog Input index (Y)
			AInIndex[1] = 1;

			SaveRowStyle = Task_Table.RowStyles[Task_Table.RowCount - 1];
			
			namTxt = NameTask_TB0.Size;
			numTrilTxt = NumTrial_TB0.Size;
			cmbSiz = SelectTask_CB0.Size;
		}

		void SetTheme()
		{
			this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.Flat;
			this.TitleBar.TitleBarBackImage = TaskDesigner.Properties.Resources.engineer;
			this.TitleBar.TitleBarCaption = "CogLAB Psycophysics";

			this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
			this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
			this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;

			this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Angular;
			this.MenuIcon = TaskDesigner.Properties.Resources.brain.GetThumbnailImage(25, 25, null, IntPtr.Zero);
			this.StatusBar.EllipticalGlow = false;

			this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.UpperGlow;

			this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Left;

			this.StatusBar.BarItems[1].BarItemText = "";
			this.StatusBar.BarItems[1].ItemTextAlign = StringAlignment.Center;

			xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"Themes\BlueWinterTheme.xml"));
		}
		
		void TaskPreview_Load(object sender, EventArgs e)
		{
			this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.file.GetThumbnailImage(20, 20, null, IntPtr.Zero), "File"));
			this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.add.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Add"));
			this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.import.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Load"));
			this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.save.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Save"));
			this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.setting.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Setting"));
			this.IconHolder.HolderButtons.Add(new XCoolForm.XTitleBarIconHolder.XHolderButton(TaskDesigner.Properties.Resources.help.GetThumbnailImage(20, 20, null, IntPtr.Zero), "Help"));

			this.IconHolder.HolderButtons[0].FrameBackImage = TaskDesigner.Properties.Resources.file.GetThumbnailImage(48, 48, null, IntPtr.Zero);
			this.IconHolder.HolderButtons[1].FrameBackImage = TaskDesigner.Properties.Resources.add.GetThumbnailImage(48, 48, null, IntPtr.Zero);
			this.IconHolder.HolderButtons[2].FrameBackImage = TaskDesigner.Properties.Resources.import.GetThumbnailImage(48, 48, null, IntPtr.Zero);
			this.IconHolder.HolderButtons[3].FrameBackImage = TaskDesigner.Properties.Resources.save.GetThumbnailImage(48, 48, null, IntPtr.Zero);
			this.IconHolder.HolderButtons[4].FrameBackImage = TaskDesigner.Properties.Resources.setting.GetThumbnailImage(48, 48, null, IntPtr.Zero);
			this.IconHolder.HolderButtons[5].FrameBackImage = TaskDesigner.Properties.Resources.help.GetThumbnailImage(48, 48, null, IntPtr.Zero);

			this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(60));
			this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(200, "INS"));
			this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(80, "Done"));
			this.StatusBar.EllipticalGlow = false;

			this.XCoolFormHolderButtonClick += new XCoolFormHolderButtonClickHandler(frmCoolForm_XCoolFormHolderButtonClick);
			xtl.ThemeForm = this;
			SetTheme();
            eventLock = true;
		}
		
		void frmCoolForm_XCoolFormHolderButtonClick(XCoolForm.XCoolForm.XCoolFormHolderButtonClickArgs e)
		{
			switch (e.ButtonIndex)
			{
				case 0:

					break;
				case 1:
					if (_tsk.EnabledTask.Count == _tsk.AllLevelProp.Count)
					{
						TaskName++;
						Add_PB_Click(null, null);
						_tsk.EnabledTask.Add(0);
					}
					break;
				case 4:
					//Setting SettingFrm = new Setting();
					//SettingFrm.FormClosing += delegate { this.Show(); };
					//this.Hide();
					//SettingFrm.Show();
					break;
				case 3:
					{
						if (_tsk.SavePsycoPhysicTask(true))
							MessageBox.Show("Selected task saved successfully!", "Save Task");
					}
					break;
				case 2:
					{
						if (_tsk.LoadTaskFromFile(true, null))
						{
							MessageBox.Show("Selected task loaded successfully!", "Load Task");
							FillTaskTable();
						}
						
					}
					break;
				case 5:
					break;
				case 6:
					break;
			}

		}
		
        void FillTaskTable()
        {
            Task_Table.RowStyles.Clear();
            Task_Table.Controls.Clear();
            Task_Table.RowCount = 0;
            for (int i = 0; i < _tsk.AllLevelProp.Count; i++)
            {
                //add a new RowStyle as a copy of the previous one
                this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));

                var namebox = new TextBox();
                namebox.Name = "NameTask_TB" + (Task_Table.RowCount);
                namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);
                namebox.Size = namTxt;
                namebox.Text = _tsk.AllLevelName[i];
                Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount);
               

                var Combox = new ComboBox();
                Combox.Items.Add(" ");
                
				//Combox.Items.Add("MGS");
				//Combox.Items.Add("VGS");
				//Combox.Items.Add("Posner");
				Combox.Items.Add("Edit");
				Combox.Items.Add("Delete");
				Combox.Items.Add("Copy");
				Combox.Name = "SelectTask_CB" + (Task_Table.RowCount);
                //Debug.Write(" Combo" + Combox.Name + "\n");
                Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
                Combox.Size = cmbSiz;
                this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount);
                var txbox = new TextBox();
                txbox.Text = Convert.ToString(_tsk.NumerRepeat[i]);
                txbox.Name = "NumTrial_TB" + (Task_Table.RowCount);
                txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
                txbox.Size = numTrilTxt;
                Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount);
                Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount).ToString() }, 3, this.Task_Table.RowCount);
                Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount).ToString() }, 4, this.Task_Table.RowCount);
                this.Task_Table.RowCount++;
                UpdateData(i + 1);
                UpdateComboBox(i);
            }
        }

        void SelectTask_CB_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (!eventLock)
                return;
			ComboBox cmb = (ComboBox)sender;

			String cmbName = cmb.Name;
			int index = int.Parse(cmbName.Substring(13));
            ActiveCol = index + 1;
			int selectedIndex = cmb.SelectedIndex;
			String selectedText = cmb.Text;
			
			switch (selectedText)
			{
				case "VGS":
					break;
				case "MGS":
					break;
				case "Design":
					//this.Visible = false;
					Designer NormalFrm = new Designer(1, 0, this);
					NormalFrm.FormClosing += delegate { this.Show(); this.UpdateComboBox(index); };
					this.Hide();
					NormalFrm.Show();
					break;
				case "Copy":
					AddCondition(false, index);
					NameTask_TB0.Select();
					break; 
				case "Posner":
					break;
				case "Discrimination":
					break;
				case "Delete":
					if (MessageBox.Show("Do you want to delete this condition?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
					{
						if (_tsk.AllLevelProp.Count > 0)//&& AllLevelProp[index - 1].Count > 1
						{

							_tsk.AllLevelProp.RemoveAt(index);
							_tsk.AllLevelName.RemoveAt(index);
							_tsk.NumerRepeat.RemoveAt(index);
							_tsk.EnabledTask.RemoveAt(index);
							_tsk.BaseIndex.RemoveAt(index);

							FillTaskTable();
						}
					}
					NameTask_TB0.Select();
					break;

				case "Edit":
					Designer EditForm = new Designer(2, index, this);
					EditForm.FormClosing += delegate { this.Show(); this.UpdateComboBox(index); };
					this.Hide();
					EditForm.Show();
					break;
				
				default:


					break;
			}


		}

		public void TaskPreview_VisibleChanged(object sender, EventArgs e)
		{
			if ( !eventLock || !this.Visible)
				return;
			NameTask_TB0.Select();
			
			Label FrCountLB = Controls.Find("FramePerTask_LB" + (ActiveCol-1), true).FirstOrDefault() as Label;
			FrCountLB.Text = Convert.ToString(_tsk.AllLevelProp[ActiveCol - 1].Count);
			UpdateData(ActiveCol);
		}

		void Add_PB_Click(object sender, EventArgs e)
		{
            eventLock = false;
			//add a new RowStyle as a copy of the previous one
			AddCondition(true, -1);
            eventLock = true;
		}

		void AddCondition(bool newCond, int id)
		{
			this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));
			this.Task_Table.RowCount++;

			string name = "", repeat = "1";
			if (newCond)
				name = "Untitled" + TaskName;
				
			else
			{
				name = _tsk.AllLevelName[id];
				_tsk.AllLevelProp.Add(FrameProperties.Copy(_tsk.AllLevelProp[id]));
				_tsk.EnabledTask.Add(2);
				repeat = _tsk.NumerRepeat[id].ToString();
			}

			var namebox = new TextBox();
			namebox.Name = "NameTask_TB" + (Task_Table.RowCount - 1);
			namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);

			_tsk.AllLevelName.Add(name);
			_tsk.BaseIndex.Add(0);
			namebox.Text = name;
			namebox.Size = namTxt;
			Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount - 1);

			_tsk.NumerRepeat.Add(1);
			var Combox = new ComboBox();
			Combox.Size = cmbSiz;
			Combox.Items.Add(" ");
			if (newCond)
				Combox.Items.Add("Design");
			else
			{
				Combox.Items.Add("Delete");
				Combox.Items.Add("Edit");
				Combox.Items.Add("Copy");
			}
			

			Combox.Name = "SelectTask_CB" + (Task_Table.RowCount - 1);
			Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
			this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount - 1);
			var txbox = new TextBox();
			txbox.Text = repeat;
			txbox.Name = "NumTrial_TB" + (Task_Table.RowCount - 1);
			txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
			txbox.Size = numTrilTxt;
			Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount - 1);
			
			Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount - 1) }, 3, this.Task_Table.RowCount - 1);
			Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount - 1) }, 4, this.Task_Table.RowCount - 1);
			if(!newCond)
				UpdateData(Task_Table.RowCount);
		}

		void UpdateData(int Index)
		{
			int time = 0;
			if (_tsk.AllLevelProp.Count > 0)
			{
				for (int i = 0; i < _tsk.AllLevelProp[Index - 1].Count; i++)
				{
					if (_tsk.AllLevelProp[Index - 1][i].RepeatInfo.Active)
					{
						int varTime = 0;
						for (int j = 0; j < _tsk.AllLevelProp[Index - 1][i].RepeatInfo.Length; j++)
							varTime += _tsk.AllLevelProp[Index - 1][i + j].FrameTime;
						time += _tsk.AllLevelProp[Index - 1][i].RepeatInfo.RepeatationNumber * varTime;
						i = i + _tsk.AllLevelProp[Index - 1][i].RepeatInfo.Length - 1;
					}
					else
					{
						time += _tsk.AllLevelProp[Index - 1][i].FrameTime;
					}
				}
                Label timeLB = Task_Table.Controls.Find("TotalTime_LB" + (Index - 1), true).FirstOrDefault() as Label;
                Label numFrLB = Task_Table.Controls.Find("FramePerTask_LB" + (Index - 1), true).FirstOrDefault() as Label;
				numFrLB.Text = Convert.ToString(_tsk.AllLevelProp[Index - 1].Count);

				TextBox numtrialTB = Task_Table.Controls.Find("NumTrial_TB" + (Index - 1), true).FirstOrDefault() as TextBox;
				numtrialTB.Text = Convert.ToString(_tsk.NumerRepeat[Index - 1]);
				TextBox nametaskTB = Task_Table.Controls.Find("NameTask_TB" + (Index - 1), true).FirstOrDefault() as TextBox;
				nametaskTB.Text = _tsk.AllLevelName[Index - 1];
				timeLB.Text = Convert.ToString(time * int.Parse(numtrialTB.Text));
			}
			else
			{
				Label timeLB = Task_Table.Controls.Find("TotalTime_LB" + (Index-1), true).FirstOrDefault() as Label;
				Label numFrLB = Task_Table.Controls.Find("FramePerTask_LB" + (Index-1), true).FirstOrDefault() as Label;
				numFrLB.Text = Convert.ToString(0);
				timeLB.Text = Convert.ToString(0);

				TextBox numtrialTB = Task_Table.Controls.Find("NumTrial_TB" + (Index - 1), true).FirstOrDefault() as TextBox;
				numtrialTB.Text = Convert.ToString(_tsk.NumerRepeat[Index - 1]);
				TextBox nametaskTB = Task_Table.Controls.Find("NameTask_TB" + (Index - 1), true).FirstOrDefault() as TextBox;
				nametaskTB.Text = _tsk.AllLevelName[Index - 1];
				timeLB.Text = Convert.ToString(time * int.Parse(numtrialTB.Text));
			}


		}
		
		void Stop_PB_Click(object sender, EventArgs e)
		{
			_tsk.Brake = true;
		}

		void Task_Table_Scroll(object sender, ScrollEventArgs e)
		{
			return;
		}

		void NumTrial_TB_TextChanged(object sender, EventArgs e)
		{
            if (!eventLock)
                return;
			TextBox cmb = (TextBox)sender;

			String cmbName = cmb.Name;
			int index = int.Parse(cmbName.Substring(11));
			try
            {
				_tsk.NumerRepeat[index] = int.Parse(cmb.Text);
                
            }
            catch(Exception)
            {
				_tsk.NumerRepeat[index] = 1;
				cmb.Text = "";
                
            }
            UpdateData(index + 1);
        }

		void Start_PB_Click(object sender, EventArgs e)
		{
			if (_tsk.AllLevelProp.Count == 0)
			{
				MessageBox.Show("Can not show empty task!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			_tsk.Brake = false;
			if (chkRandom.Checked)
				_tsk.SeqRandTaskRunner = 2;
			else
				_tsk.SeqRandTaskRunner = 1;

			PsycophysicsRunner ShFrame = new PsycophysicsRunner(false, 0 ,0, _tsk, null);

			ShFrame.Show();
		}

		void UpdateComboBox(int index)
		{
			if (_tsk.EnabledTask[index] == 2)
			{
				ComboBox comb = Task_Table.Controls.Find("SelectTask_CB" + index, true).FirstOrDefault() as ComboBox;
				comb.Items.Clear();
				comb.Items.Add("Delete");
				comb.Items.Add("Edit");
				comb.Items.Add("Copy");
			}
		}

		void TaskPreview_FormClosing(object sender, FormClosingEventArgs e)
		{
			//Application.Exit();
			//Application.ExitThread();

			//foreach (Process Proc in Process.GetProcesses())
			//    if (Proc.ProcessName.Equals("TaskDesigner"))  //Process Excel?
			//        Proc.Kill();
		}

		void NameTask_TB_TextChanged(object sender, EventArgs e)
		{
            if (!eventLock)
                return;
			TextBox cmb = (TextBox)sender;
			String cmbName = cmb.Name;
			int index = int.Parse(cmbName.Substring(11));
			_tsk.AllLevelName[index] = cmb.Text;
		}

		
	}
}
