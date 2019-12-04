using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Automation.BDaq;
using System.IO;
using Psychophysics;
using Psychophysics.Old;

namespace Basics
{
    public partial class PsycoPhysicTask : XCoolForm.XCoolForm
    {
		public static int NFrame = 0;
		public static int NumberCol = 1;
		public static int ActiveCol = 1;
		public static FrameProperties[] FrameProps = new FrameProperties[NFrame];
		public static List<List<FrameProperties>> AllLevelProp = new List<List<FrameProperties>>();
		public static List<int> BaseIndex = new List<int>();
		public static List<String> AllLevelName = new List<String>();
		public static List<int> EnabledTask = new List<int>();
		public static List<int> NumerRepeat = new List<int>();
		public static int[] TaskIndex = new int[NFrame];
		public static bool ChangeHappened = false;
		Size namTxt, numTrilTxt, cmbSiz;

		// Display Option
		public static int TypeDisplay = 1;
		//
		int TaskName = 1;
		//// DAQ
		public static int FrameRate = 125;
		public static ValueRange InputValRange = ValueRange.V_Neg5To5;
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

		List<int> a = new List<int>();
		private XmlThemeLoader xtl = new XmlThemeLoader();
		// Save Parameters
		public bool Savetask = false;
		public string DataPath = "";
		// Keyboard
		public static char keyboardChar = ' ';

		// Degree Conversion
		public static double userDistance = 0.5;
		public static double WidthM = 0.42, HeightM = 0.26;
		public static double WidthP = BasConfigs._monitor_resolution_x, HeightP = BasConfigs._monitor_resolution_y;

				
		// Stop
		public static bool brake = false;

        bool eventLock = false;

        public PsycoPhysicTask()
		{
			InitializeComponent();
			EnabledTask.Add(0);
			NumerRepeat.Add(1);
			AllLevelName.Add("Untitled" + (AllLevelName.Count + 1));
			BaseIndex.Add(0);
			NameTask_TB0.Text = AllLevelName[0];
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

		private void SetTheme()
		{
			this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.Flat;
			this.TitleBar.TitleBarBackImage = TaskDesigner.Properties.Resources.engineer;
			this.TitleBar.TitleBarCaption = "CogLAB";

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
		
		private void TaskPreview_Load(object sender, EventArgs e)
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
		
		private void frmCoolForm_XCoolFormHolderButtonClick(XCoolForm.XCoolForm.XCoolFormHolderButtonClickArgs e)
		{
			switch (e.ButtonIndex)
			{
				case 0:

					break;
				case 1:
					if (EnabledTask.Count == AllLevelProp.Count)
					{
						TaskName++;
						Add_PB_Click(null, null);
						EnabledTask.Add(0);
					}
					break;
				case 4:
					Setting SettingFrm = new Setting();
					SettingFrm.FormClosing += delegate { this.Show(); };
					this.Hide();
					SettingFrm.Show();
					break;
				case 3:
					{
						SavePsycoPhysicTask(true);
						MessageBox.Show("Selected task saved successfully!", "Save Task");
					}
					break;
				case 2:
					{
						LoadTaskFromFile(true, null);
						MessageBox.Show("Selected task loaded successfully!","Load Task");
					}
					break;
				case 5:
					break;
				case 6:
					break;
			}

		}

		public bool SavePsycoPhysicTask(bool ShowMessage)
		{
			if (DataPath == "")
			{
				if (ShowMessage)
				{
					SaveFileDialog sfd = new SaveFileDialog();
					sfd.Filter = "Text Files (*.txt)|*.txt";
					if (sfd.ShowDialog() == DialogResult.Cancel)
						return false;
					DataPath = sfd.FileName;
				}
				else
					return false;
			}	
			String SaveText = "";
			SaveText += "Number Of Levels\n";
			int levelcnt = AllLevelProp.Count;
			SaveText += levelcnt + "\n";
			for (int i = 0; i < levelcnt; i++)
			{
				SaveText += "___Name\n";
				SaveText += "___" + AllLevelName[i] + "\n";
				SaveText += "___Number Of Repeatation\n";
				int repeatnum = NumerRepeat[i];
				SaveText += "___" + repeatnum + "\n";
				SaveText += "___Number Of Frames\n";
				int framecnt = AllLevelProp[i].Count;
				SaveText += "___" + framecnt + "\n";
				for (int j = 0; j < framecnt; j++)
				{
					SaveText += "______Frame" + j + "\n______" + AllLevelProp[i][j].FrameTime + " " + AllLevelProp[i][j].BGColor.R + " " + AllLevelProp[i][j].BGColor.G + " " + AllLevelProp[i][j].BGColor.B + "\n";
					SaveText += "_________Fixation\n";
					SaveText += "_________" + AllLevelProp[i][j].Fixation.Xloc + " " + AllLevelProp[i][j].Fixation.Yloc + " " + AllLevelProp[i][j].Fixation.Width + " " + AllLevelProp[i][j].Fixation.Type + " " + AllLevelProp[i][j].FixationTime + " " + AllLevelProp[i][j].Fixation.ColorPt.R + " " + AllLevelProp[i][j].Fixation.ColorPt.G + " " + AllLevelProp[i][j].Fixation.ColorPt.B + "\n";
					int stimuluscnt = AllLevelProp[i][j].NumberSaccade;
					SaveText += "_________Number Of Stimulus\n";
					SaveText += "_________" + stimuluscnt + "\n";
					for (int k = 0; k < stimuluscnt; k++)
					{
						SaveText += "_________Stimulus\n";
						if (AllLevelProp[i][j].Stimulus[k].Type == 1 || AllLevelProp[i][j].Stimulus[k].Type == 5 || AllLevelProp[i][j].Stimulus[k].Type == 9)
						{
							SaveText += "_________" + AllLevelProp[i][j].Stimulus[k].Type + " " + AllLevelProp[i][j].Stimulus[k].Xloc + " " + AllLevelProp[i][j].Stimulus[k].Yloc + " " + AllLevelProp[i][j].Stimulus[k].Width + " " + AllLevelProp[i][j].Stimulus[k].Height + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.R + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.G + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.B + " " + AllLevelProp[i][j].Stimulus[k].Contrast + "\n";
						}
						if (AllLevelProp[i][j].Stimulus[k].Type == 2 || AllLevelProp[i][j].Stimulus[k].Type == 6 || AllLevelProp[i][j].Stimulus[k].Type == 10)
						{
							SaveText += "_________" + AllLevelProp[i][j].Stimulus[k].Type + " " + AllLevelProp[i][j].Stimulus[k].Xloc + " " + AllLevelProp[i][j].Stimulus[k].Yloc + " " + AllLevelProp[i][j].Stimulus[k].Width + " " + AllLevelProp[i][j].Stimulus[k].Height + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.R + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.G + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.B + " " + AllLevelProp[i][j].Stimulus[k].Contrast + "\n";
						}
						if (AllLevelProp[i][j].Stimulus[k].Type == 3 || AllLevelProp[i][j].Stimulus[k].Type == 7 || AllLevelProp[i][j].Stimulus[k].Type == 11)
						{
							SaveText += "_________" + AllLevelProp[i][j].Stimulus[k].Type + " " + AllLevelProp[i][j].Stimulus[k].Xloc + " " + AllLevelProp[i][j].Stimulus[k].Yloc + " " + AllLevelProp[i][j].Stimulus[k].Width + " " + AllLevelProp[i][j].Stimulus[k].Height + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.R + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.G + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.B + " " + AllLevelProp[i][j].Stimulus[k].Contrast + "\n";
						}
						if (AllLevelProp[i][j].Stimulus[k].Type == 4 || AllLevelProp[i][j].Stimulus[k].Type == 8 || AllLevelProp[i][j].Stimulus[k].Type == 12)
						{
							if (File.Exists(AllLevelProp[i][j].Stimulus[k].PathPic))
							{
								Uri uriFilePath = new Uri(@AllLevelProp[i][j].Stimulus[k].PathPic);
								SaveText += "_________" + AllLevelProp[i][j].Stimulus[k].Type + " " + AllLevelProp[i][j].Stimulus[k].Xloc + " " + AllLevelProp[i][j].Stimulus[k].Yloc + " " + AllLevelProp[i][j].Stimulus[k].Width + " " + AllLevelProp[i][j].Stimulus[k].Height + "\n_________" + AllLevelProp[i][j].Stimulus[k].PathPic + "\n";
							}
						}
					}
					
					SaveText += "_________Reward\n";
					SaveText += "_________" + AllLevelProp[i][j].RewardType + "\n";
					
					SaveText += "_________Events Count\n";
					SaveText += "_________" + 12.ToString() + "\n";

					SaveText += "_________Event Codes\n_________";
				
					SaveText += AllLevelProp[i][j].events.condition.ToString() + " " + AllLevelProp[i][j].events.trialStart.ToString() + " " + AllLevelProp[i][j].events.trialEnd.ToString() + " " + AllLevelProp[i][j].events.fixOn.ToString() + " " + AllLevelProp[i][j].events.fixOff.ToString() + " " + AllLevelProp[i][j].events.stimOn.ToString() + " " + AllLevelProp[i][j].events.stimOff.ToString() + " " + AllLevelProp[i][j].events.enterFixWindow.ToString() + " " + AllLevelProp[i][j].events.abortFixWindow.ToString() + " " + AllLevelProp[i][j].events.enterTargetWindow.ToString() + " " + AllLevelProp[i][j].events.saccadInit.ToString() + " " + AllLevelProp[i][j].events.saccadLand.ToString() + " ";
					
					SaveText += "\n";
				}
			}
			SaveText += "Distance " + userDistance + "\n";
			SaveText += "MoniTorWidth(m) " + WidthM + "\n";
			SaveText += "MoniTorHeight(m) " + HeightM + "\n";
			SaveText += "MoniTorWidth(pixel) " + WidthP + "\n";
			SaveText += "MoniTorHeight(pixel) " + HeightP + "\n";
			File.WriteAllText(DataPath, SaveText);
			return true;
		}

		public bool LoadTaskFromFile(bool _getAddress, string address)
		{
			DialogResult dt = DialogResult.Cancel;
			OpenFileDialog theDialog = new OpenFileDialog();
			if (_getAddress)
			{
				theDialog.Title = "Open Text File";
				theDialog.Filter = "Text Files (*.txt)|*.txt";
				theDialog.InitialDirectory = @"..";
				dt = theDialog.ShowDialog();
				if (dt == DialogResult.Cancel)
					return false;
			}
			else
			{
				theDialog.FileName = address;
			}
			eventLock = false;

			AllLevelProp.Clear();
			AllLevelName.Clear();
			BaseIndex.Clear();
			NumerRepeat.Clear();
			EnabledTask.Clear();
			
			using (var fs = File.OpenRead(theDialog.FileName))
			using (var reader = new StreamReader(fs))
			{
				var line = reader.ReadLine();
				line = reader.ReadLine();
				int NumberLevel = int.Parse(line);
				for (int i = 0; i < NumberLevel; i++)
				{
					BaseIndex.Add(0);
					List<FrameProperties> ListAddedFrame = new List<FrameProperties>();

					line = reader.ReadLine();
					line = reader.ReadLine();
					AllLevelName.Add(line.Substring(3));

					line = reader.ReadLine();
					line = reader.ReadLine();
					int repeatnumber = int.Parse(line.Substring(3));
					NumerRepeat.Add(repeatnumber);
					EnabledTask.Add(2);

					line = reader.ReadLine();
					line = reader.ReadLine();
					int NumberFrame = int.Parse(line.Substring(3));

					for (int j = 0; j < NumberFrame; j++)
					{
						FrameProperties varFrame = new FrameProperties();

						line = reader.ReadLine();
						line = reader.ReadLine();
						var values = line.Substring(6).Split(' ');
						int FrameTime = int.Parse(values[0]);
						//Debug.Write("Load Debug " + line.Substring(6) + " " + values[0] + "\n");
						Color BGColor = Color.FromArgb(255, int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));

						line = reader.ReadLine();
						line = reader.ReadLine();
						values = line.Substring(9).Split(' ');
						FixationPts varFixation = new FixationPts();
						//varFixation.SetFixationPts(int.Parse(), int.Parse(), int.Parse(), int.Parse(),Color.FromArgb(255, int.Parse(), int.Parse(), int.Parse()));
						Color fixationColor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
						varFixation.SetFixationPts(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), fixationColor);
						int fixationtime = int.Parse(values[4]);
						line = reader.ReadLine();
						line = reader.ReadLine();
						//Debug.Write("Load Debug " + line.Substring(9)+ "\n");
						int NumberStimulus = int.Parse(line.Substring(9));
						FixationPts[] varStimulus = new FixationPts[NumberStimulus];

						for (int k = 0; k < NumberStimulus; k++)
						{
							line = reader.ReadLine();
							line = reader.ReadLine();
							values = line.Substring(9).Split(' ');
							

							varStimulus[k] = new FixationPts();
							if (int.Parse(values[0]) == 4 || int.Parse(values[0]) == 8 || int.Parse(values[0]) == 12)
							{
								line = reader.ReadLine();
								varStimulus[k].SetPicture(int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[0]), line.Substring(9));
							}
							else
							{
								Color stimulusColor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
								varStimulus[k].SetFixationPts(int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[0]), stimulusColor);
								varStimulus[k].SetContrastPts(int.Parse(values[8]));
							}
						}
												
						line = reader.ReadLine();
						line = reader.ReadLine();
						int reward = int.Parse(line.Substring(9));
						
						line = reader.ReadLine();
						line = reader.ReadLine();
						int eventNum = int.Parse(line.Substring(9));
						
						line = reader.ReadLine();
						line = reader.ReadLine();
						string[] events = line.Split(' ');
						TriggerEvents tg = new TriggerEvents();
						int ev, subFirst = 9;
						for (int evCount = 0; evCount < eventNum; evCount++)
						{
							int.TryParse(events[evCount].Substring(subFirst), out ev);
							subFirst = 0;
							tg.SetEvent(evCount + 1, ev);
						}
						varFrame.SetProperties(BGColor, FrameTime, varFixation, fixationtime, NumberStimulus, varStimulus, reward, null, 0, null,tg);
					
						ListAddedFrame.Add(varFrame);
					}
					AllLevelProp.Add(ListAddedFrame);
				}
				line = reader.ReadLine();
				var value = line.Split(' ');
				userDistance = double.Parse(value[1]);

				line = reader.ReadLine();
				value = line.Split(' ');
				WidthM = double.Parse(value[1]);

				line = reader.ReadLine();
				value = line.Split(' ');
				HeightM = double.Parse(value[1]);

				line = reader.ReadLine();
				value = line.Split(' ');
				WidthP = double.Parse(value[1]);

				line = reader.ReadLine();
				value = line.Split(' ');
				HeightP = double.Parse(value[1]);

				FillTaskTable();

				eventLock = true;
				return true;
			}
		}

        private void FillTaskTable()
        {
            Task_Table.RowStyles.Clear();
            Task_Table.Controls.Clear();
            Task_Table.RowCount = 0;
            for (int i = 0; i < AllLevelProp.Count; i++)
            {
                //add a new RowStyle as a copy of the previous one
                this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));

                var namebox = new TextBox();
                namebox.Name = "NameTask_TB" + (Task_Table.RowCount);
                namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);
                //namebox.Size = namTxt;
                namebox.Text = AllLevelName[i];
                Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount);
                Debug.Write(" Hellp" + "\n");

                var Combox = new ComboBox();
                Combox.Items.Add(" ");
                Combox.Items.Add("Design");
                //Combox.Items.Add("MGS");
                //Combox.Items.Add("VGS");
                //Combox.Items.Add("Posner");
                Combox.Items.Add("Delete");
                Combox.Name = "SelectTask_CB" + (Task_Table.RowCount);
                //Debug.Write(" Combo" + Combox.Name + "\n");
                Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
                //Combox.Size = cmbSiz;
                this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount);
                var txbox = new TextBox();
                txbox.Text = Convert.ToString(NumerRepeat[i]);
                txbox.Name = "NumTrial_TB" + (Task_Table.RowCount);
                txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
                //txbox.Size = numTrilTxt;
                Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount);
                Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount).ToString() }, 3, this.Task_Table.RowCount);
                Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount).ToString() }, 4, this.Task_Table.RowCount);
                this.Task_Table.RowCount++;
                UpdateData(i + 1);
                UpdateComboBox(i);
            }
        }

        private void SelectTask_CB_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (!eventLock)
                return;
			ComboBox cmb = (ComboBox)sender;

			String cmbName = cmb.Name;
			int index = (int)Char.GetNumericValue(cmbName[(cmbName.Length - 1)]);
            ActiveCol = index + 1;
			int selectedIndex = cmb.SelectedIndex;
			String selectedText = cmb.Text;
			Debug.Write(this.Name + selectedIndex + "\n");

			switch (selectedText)
			{
				case "VGS":
					break;
				case "MGS":
					break;
				case "Design":
					//this.Visible = false;
					Designer NormalFrm = new Designer(1, 0);
					NormalFrm.FormClosing += delegate { this.Show(); this.UpdateComboBox(index); };
					this.Hide();
					NormalFrm.Show();
					break;
				case "Posner":
					break;
				case "Discrimination":
					break;
				case "Delete":
					
					if (AllLevelProp.Count > 0)//&& AllLevelProp[index - 1].Count > 1
					{
												
						AllLevelProp.RemoveAt(index);
						AllLevelName.RemoveAt(index);
						NumerRepeat.RemoveAt(index);
						EnabledTask.RemoveAt(index);
						BaseIndex.RemoveAt(index);
						
                        FillTaskTable();
					}
					

					break;

				case "Edit":
					Designer EditForm = new Designer(2, index);
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
			if (!ChangeHappened || !eventLock)
				return;
			ChangeHappened = false;

			Label FrCountLB = Controls.Find("FramePerTask_LB" + (ActiveCol-1), true).FirstOrDefault() as Label;
			FrCountLB.Text = Convert.ToString(AllLevelProp[ActiveCol - 1].Count);
			UpdateData(ActiveCol);
		}

		private void Add_PB_Click(object sender, EventArgs e)
		{
            eventLock = false;
			//add a new RowStyle as a copy of the previous one
			this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));
			this.Task_Table.RowCount++;
			var namebox = new TextBox();
			namebox.Name = "NameTask_TB" + (Task_Table.RowCount - 1);
			namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);

			AllLevelName.Add("Untitled" + TaskName);
			BaseIndex.Add(0);
			namebox.Text = "Untitled" + TaskName;
			namebox.Size = namTxt;
			Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount - 1);

			NumerRepeat.Add(1);
			var Combox = new ComboBox();
			Combox.Size = cmbSiz;
			Combox.Items.Add(" ");
			Combox.Items.Add("Design");
			//Combox.Items.Add("Load");

			Combox.Name = "SelectTask_CB" + (Task_Table.RowCount - 1);
			Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
			this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount - 1);
			var txbox = new TextBox();
			txbox.Text = "1";
			txbox.Name = "NumTrial_TB" + (Task_Table.RowCount - 1);
			txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
			txbox.Size = numTrilTxt;
			Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount - 1);
			Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount - 1) }, 3, this.Task_Table.RowCount - 1);
			Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount - 1) }, 4, this.Task_Table.RowCount - 1);
            eventLock = true;
		}

		private void UpdateData(int Index)
		{
			int time = 0;
			if (AllLevelProp.Count > 0)
			{
				for (int i = 0; i < AllLevelProp[Index - 1].Count; i++)
				{
					if (AllLevelProp[Index - 1][i].RepeatInfo.Active)
					{
						int varTime = 0;
						for (int j = 0; j < AllLevelProp[Index - 1][i].RepeatInfo.Length; j++)
							varTime += AllLevelProp[Index - 1][i + j].FrameTime;
						time += AllLevelProp[Index - 1][i].RepeatInfo.RepeatationNumber * varTime;
						i = i + AllLevelProp[Index - 1][i].RepeatInfo.Length - 1;
					}
					else
					{
						time += AllLevelProp[Index - 1][i].FrameTime;
					}
				}
                Label timeLB = Task_Table.Controls.Find("TotalTime_LB" + (Index - 1), true).FirstOrDefault() as Label;
                Label numFrLB = Task_Table.Controls.Find("FramePerTask_LB" + (Index - 1), true).FirstOrDefault() as Label;
				numFrLB.Text = Convert.ToString(AllLevelProp[Index - 1].Count);

				TextBox numtrialTB = Task_Table.Controls.Find("NumTrial_TB" + (Index - 1), true).FirstOrDefault() as TextBox;
				numtrialTB.Text = Convert.ToString(NumerRepeat[Index - 1]);
				TextBox nametaskTB = Task_Table.Controls.Find("NameTask_TB" + (Index - 1), true).FirstOrDefault() as TextBox;
				nametaskTB.Text = AllLevelName[Index - 1];
				timeLB.Text = Convert.ToString(time * int.Parse(numtrialTB.Text));
			}
			else
			{
				Label timeLB = Task_Table.Controls.Find("TotalTime_LB" + (Index-1), true).FirstOrDefault() as Label;
				Label numFrLB = Task_Table.Controls.Find("FramePerTask_LB" + (Index-1), true).FirstOrDefault() as Label;
				numFrLB.Text = Convert.ToString(0);
				timeLB.Text = Convert.ToString(0);

				TextBox numtrialTB = Task_Table.Controls.Find("NumTrial_TB" + (Index - 1), true).FirstOrDefault() as TextBox;
				numtrialTB.Text = Convert.ToString(NumerRepeat[Index - 1]);
				TextBox nametaskTB = Task_Table.Controls.Find("NameTask_TB" + (Index - 1), true).FirstOrDefault() as TextBox;
				nametaskTB.Text = AllLevelName[Index - 1];
				timeLB.Text = Convert.ToString(time * int.Parse(numtrialTB.Text));
			}


		}
		
		private void Stop_PB_Click(object sender, EventArgs e)
		{
			brake = true;
		}

		private void Task_Table_Scroll(object sender, ScrollEventArgs e)
		{
			return;
		}

		private void NumTrial_TB_TextChanged(object sender, EventArgs e)
		{
            if (!eventLock)
                return;
			TextBox cmb = (TextBox)sender;

			String cmbName = cmb.Name;
			int index = (int)Char.GetNumericValue(cmbName[(cmbName.Length - 1)]);
            try
            {
                NumerRepeat[index] = int.Parse(cmb.Text);
                
            }
            catch(Exception)
            {
				NumerRepeat[index] = 1;
				cmb.Text = "";
                
            }
            UpdateData(index + 1);
        }

		private void Start_PB_Click(object sender, EventArgs e)
		{
			if (AllLevelProp.Count == 0)
			{
				MessageBox.Show("Can not show empty task!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			brake = false;
			if (chkRandom.Checked)
				TypeDisplay = 2;
			else
				TypeDisplay = 1;

			ShowFrame ShFrame = new ShowFrame(false);

			ShFrame.Show();
		}

		private void UpdateComboBox(int index)
		{
			if (EnabledTask[index] == 2)
			{
				ComboBox comb = Task_Table.Controls.Find("SelectTask_CB" + index, true).FirstOrDefault() as ComboBox;
				comb.Items.Clear();
				comb.Items.Add("Delete");
				comb.Items.Add("Edit");
			}
		}

		private void TaskPreview_FormClosing(object sender, FormClosingEventArgs e)
		{
			//Application.Exit();
			//Application.ExitThread();

			//foreach (Process Proc in Process.GetProcesses())
			//    if (Proc.ProcessName.Equals("TaskDesigner"))  //Process Excel?
			//        Proc.Kill();
		}

		private void NameTask_TB_TextChanged(object sender, EventArgs e)
		{
            if (!eventLock)
                return;
			TextBox cmb = (TextBox)sender;
			String cmbName = cmb.Name;
			int index = (int)Char.GetNumericValue(cmbName[(cmbName.Length - 1)]);
			Debug.Write("Helpppppp " + AllLevelName.Count + " \n");
			AllLevelName[index] = cmb.Text;
		}

		
	}
}
