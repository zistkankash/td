using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Automation.BDaq;
using System.IO;
using System.Media;
using System.Net.Sockets;
using System.Net;
using Basics;
using TaskDesigner;
using Psychophysics.Old;

namespace Psychophysics
{
    public partial class TaskPreview : XCoolForm.XCoolForm
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
		public static InstantAiCtrl instantAiCtrl = new InstantAiCtrl();
		public static int[] AInIndex = new int[2];
		// output
		public static InstantDoCtrl instantDoCtrl = new InstantDoCtrl();
		public static int[] DOutIndex = new int[2];
		// Sound
		public static bool SoundMute = false;
		public static string WinPath = "./Resources/coin.wav", FailPath = "./Resources/fail.wav";
		RowStyle SaveRowStyle;

		List<List<int>> test = new List<List<int>>();

		List<int> a = new List<int>();
		private XmlThemeLoader xtl = new XmlThemeLoader();
		// Save Parameters
		public static bool Savetask = false;
		public static string DataPath = "";
		// Keyboard
		public static char keyboardChar = ' ';

		// Degree Conversion
		public static double userDistance = 0.5;
		public static double WidthM = 0.42, HeightM = 0.26;
		public static double WidthP = 1440, HeightP = 900;

		// LAN
		public static Socket mySocket;
		public static EndPoint epLocal, epRemote;
		public static int RemotePort = 1, LocalPort = 2;
		public static string RemoteIP = " ", LocalIP = " ";
		public static byte[] buffer;
		public static byte[] SendingData;
		double[] DSendingData = new double[3];
		public static bool UseLan = true, LANConnected = false;
		// Stop
		public static bool StopBT_Pushed = false;
		public TaskPreview()
		{
			InitializeComponent();
			EnabledTask.Add(0);
			NumerRepeat.Add(1);
			AllLevelName.Add("Untitled" + (AllLevelName.Count + 1));
			BaseIndex.Add(0);
			NameTask_TB1.Text = AllLevelName[0];
			DOutIndex[0] = 0;
			DOutIndex[1] = 1;
			// initializaion for Analog Input index (X)
			AInIndex[0] = 0;
			// initializaion for Analog Input index (Y)
			AInIndex[1] = 1;

			SaveRowStyle = Task_Table.RowStyles[Task_Table.RowCount - 1];
			SaveOut_CB.Checked = Savetask;
			Path_TB.Enabled = SaveOut_CB.Checked;
			Save_BT.Enabled = SaveOut_CB.Checked;

			namTxt = NameTask_TB1.Size;
			numTrilTxt = NumTrial_TB1.Size;
			cmbSiz = SelectTask_CB1.Size;
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
					SaveFileDialog sfd = new SaveFileDialog();
					sfd.Filter = "Text Files (*.txt)|*.txt";

					if (sfd.ShowDialog() == DialogResult.OK)
					{
						// Text File
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

								SaveText += "_________Showframe\n";
								int showframecnt = AllLevelProp[i][j].ShowFrame.Length;
								SaveText += "_________" + showframecnt + "\n";
								for (int k = 0; k < showframecnt; k++)
								{
									SaveText += "_________Showframe" + k + "\n";
									SaveText += "_________" + AllLevelProp[i][j].ShowFrame[k].CenterX + " " + AllLevelProp[i][j].ShowFrame[k].CenterY + " " + AllLevelProp[i][j].ShowFrame[k].Width + " " + AllLevelProp[i][j].ShowFrame[k].Height + " " + AllLevelProp[i][j].ShowFrame[k].Thickness + " " + AllLevelProp[i][j].ShowFrame[k].ColorBox.R + " " + AllLevelProp[i][j].ShowFrame[k].ColorBox.R + " " + AllLevelProp[i][j].ShowFrame[k].ColorBox.R + "\n";
								}

								SaveText += "_________Cue\n";
								if (AllLevelProp[i][j].Cue.type == 1)
								{
									SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.ArrowLocX0 + " " + AllLevelProp[i][j].Cue.ArrowLocX1 + " " + AllLevelProp[i][j].Cue.ArrowLocY + " " + AllLevelProp[i][j].Cue.Valid + " " + AllLevelProp[i][j].Cue.ArrowColor.R + " " + AllLevelProp[i][j].Cue.ArrowColor.G + " " + AllLevelProp[i][j].Cue.ArrowColor.B + " " + AllLevelProp[i][j].Cue.ArrowWidth + "\n";
								}
								else if (AllLevelProp[i][j].Cue.type == 2)
								{
									SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.BoxRatio + "\n";
								}
								else
								{
									SaveText += "_________" + AllLevelProp[i][j].Cue.type + "\n";
								}

								SaveText += "_________Reward\n";
								SaveText += "_________" + AllLevelProp[i][j].RewardType + "\n";

								SaveText += "_________RepeatInfo\n";
								SaveText += "_________" + AllLevelProp[i][j].RepeatInfo.Active + " " + AllLevelProp[i][j].RepeatInfo.RepeatationNumber + " " + AllLevelProp[i][j].RepeatInfo.Length + " " + AllLevelProp[i][j].RepeatInfo.RandomLocation + "\n";
							}
						}
						SaveText += "Distance " + userDistance + "\n";
						SaveText += "MoniTorWidth(m) " + WidthM + "\n";
						SaveText += "MoniTorHeight(m) " + HeightM + "\n";
						SaveText += "MoniTorWidth(pixel) " + WidthP + "\n";
						SaveText += "MoniTorHeight(pixel) " + HeightP + "\n";
						File.WriteAllText(sfd.FileName, SaveText);
					}
					break;
				case 2:
					OpenFileDialog theDialog = new OpenFileDialog();
					theDialog.Title = "Open Text File";
					theDialog.Filter = "Text Files (*.txt)|*.txt";
					theDialog.InitialDirectory = @"..";
					if (theDialog.ShowDialog() == DialogResult.OK)
					{

						for (int i = AllLevelName.Count; i > 0; i--)
						{
							Label FrCountLB = Controls.Find("FramePerTask_LB" + (i), true).FirstOrDefault() as Label;
							Task_Table.Controls.Remove(FrCountLB);
							Label TotalTimeLB = Controls.Find("TotalTime_LB" + (i), true).FirstOrDefault() as Label;
							Task_Table.Controls.Remove(TotalTimeLB);
							TextBox RptTB = Controls.Find("NumTrial_TB" + (i), true).FirstOrDefault() as TextBox;
							Task_Table.Controls.Remove(RptTB);
							TextBox NmTB = Controls.Find("NameTask_TB" + (i), true).FirstOrDefault() as TextBox;
							Task_Table.Controls.Remove(NmTB);
							ComboBox TaskCB = Controls.Find("SelectTask_CB" + (i), true).FirstOrDefault() as ComboBox;
							Task_Table.Controls.Remove(TaskCB);
							Task_Table.RowStyles.RemoveAt(i);
							Task_Table.RowCount--;
						}

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
										Debug.Write("Load Debug " + line.Substring(9) + "\n");

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
									int NumberShowFrame = int.Parse(line.Substring(9));
									ShowFr[] varShowFrame = new ShowFr[NumberShowFrame];
									for (int k = 0; k < NumberShowFrame; k++)
									{
										varShowFrame[k] = new ShowFr();
										line = reader.ReadLine();
										line = reader.ReadLine();
										values = line.Substring(9).Split(' ');
										Color showframecolor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
										varShowFrame[k].SetShowFrameProp(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), showframecolor);
									}
									//MainForm.MeanX_PupilCenter[i] = Double.Parse(values[0]);

									HintForm varCue = new HintForm();
									line = reader.ReadLine();
									line = reader.ReadLine();
									values = line.Substring(9).Split(' ');

									varCue.type = int.Parse(values[0]);
									if (int.Parse(values[0]) == 1)
									{
										//SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.ArrowLocX0 + " " + AllLevelProp[i][j].Cue.ArrowLocX1 + " " + AllLevelProp[i][j].Cue.ArrowLocY + " " + AllLevelProp[i][j].Cue.ArrowColor.R + " " + AllLevelProp[i][j].Cue.ArrowColor.G + " " + AllLevelProp[i][j].Cue.ArrowColor.B + " " + AllLevelProp[i][j].Cue.ArrowWidth;
										Color showframecolor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));

										varCue.ArrowWidth = int.Parse(values[8]);
										varCue.SetArrowProp(int.Parse(values[3]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[4]), showframecolor);
									}
									else if (int.Parse(values[0]) == 2)
									{
										//SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.BoxRatio + "\n";
										varCue.SetBoxProp(20, int.Parse(values[1]), Color.Black);
									}
									else
									{

									}


									line = reader.ReadLine();
									line = reader.ReadLine();
									int reward = int.Parse(line.Substring(9));
									////Debug.Write("Load Debug " + line.Substring(9) + "\n");

									varFrame.SetProperties(BGColor, FrameTime, varFixation, fixationtime, NumberStimulus, varStimulus, reward, varCue, NumberShowFrame, varShowFrame);
									Debug.Write("FixTime1 : " + varFrame.FixationTime + "\n");

									line = reader.ReadLine();
									line = reader.ReadLine();
									values = line.Substring(9).Split(' ');
									RepeatLinkFrame repeatInfo = new RepeatLinkFrame();
									repeatInfo.SetProperties(bool.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));

									varFrame.RepeatInfo = repeatInfo;

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

							for (int i = 0; i < AllLevelProp.Count; i++)
							{
								//add a new RowStyle as a copy of the previous one
								this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));
								this.Task_Table.RowCount++;

								var namebox = new TextBox();
								namebox.Name = "NameTask_TB" + (Task_Table.RowCount - 1);
								namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);
								namebox.Size = namTxt;
								namebox.Text = AllLevelName[i];
								Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount - 1);


								var Combox = new ComboBox();
								Combox.Size = cmbSiz;
								Combox.Items.Add(" ");
								Combox.Items.Add("Design");
								Combox.Items.Add("MGS");
								Combox.Items.Add("VGS");
								Combox.Items.Add("Posner");
								//Combox.Items.Add("Delete");
								Combox.Name = "SelectTask_CB" + (Task_Table.RowCount - 1);
								Debug.Write(" Combo" + Combox.Name + "\n");
								Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
								this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount - 1);
								var txbox = new TextBox();
								txbox.Text = Convert.ToString(NumerRepeat[i]);
								txbox.Name = "NumTrial_TB" + (Task_Table.RowCount - 1);
								txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
								txbox.Size = numTrilTxt;
								Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount - 1);
								Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount - 1) }, 3, this.Task_Table.RowCount - 1);
								Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount - 1) }, 4, this.Task_Table.RowCount - 1);
								UpdateData(i + 1);
								UpdateComboBox(i + 1);
							}



						}
					}
					break;
				case 5:
					break;
				case 6:
					break;
			}

		}


		private void LoadTaskFromFile()
		{
			OpenFileDialog theDialog = new OpenFileDialog();
			theDialog.Title = "Open Text File";
			theDialog.Filter = "Text Files (*.txt)|*.txt";
			theDialog.InitialDirectory = @"..";
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				Debug.Write(AllLevelProp.Count + " " + AllLevelName.Count + " " + EnabledTask.Count + "\n");

				//if(EnabledTask.Count > 0 && EnabledTask[EnabledTask.Count - 1] == 0)
				{
					for (int i = AllLevelName.Count; i > 0; i--)
					{
						Label FrCountLB = Controls.Find("FramePerTask_LB" + (i), true).FirstOrDefault() as Label;
						Task_Table.Controls.Remove(FrCountLB);
						Label TotalTimeLB = Controls.Find("TotalTime_LB" + (i), true).FirstOrDefault() as Label;
						Task_Table.Controls.Remove(TotalTimeLB);
						TextBox RptTB = Controls.Find("NumTrial_TB" + (i), true).FirstOrDefault() as TextBox;
						Task_Table.Controls.Remove(RptTB);
						TextBox NmTB = Controls.Find("NameTask_TB" + (i), true).FirstOrDefault() as TextBox;
						Task_Table.Controls.Remove(NmTB);
						ComboBox TaskCB = Controls.Find("SelectTask_CB" + (i), true).FirstOrDefault() as ComboBox;
						Task_Table.Controls.Remove(TaskCB);
						Task_Table.RowStyles.RemoveAt(i);
						Task_Table.RowCount--;
					}

					//AllLevelProp.Clear();
					AllLevelName.RemoveAt(EnabledTask.Count - 1);
					BaseIndex.RemoveAt(EnabledTask.Count - 1);
					NumerRepeat.RemoveAt(EnabledTask.Count - 1);
					EnabledTask.RemoveAt(EnabledTask.Count - 1);
				}

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
								Debug.Write("Load Debug " + line.Substring(9) + "\n");

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
							int NumberShowFrame = int.Parse(line.Substring(9));
							ShowFr[] varShowFrame = new ShowFr[NumberShowFrame];
							for (int k = 0; k < NumberShowFrame; k++)
							{
								varShowFrame[k] = new ShowFr();
								line = reader.ReadLine();
								line = reader.ReadLine();
								values = line.Substring(9).Split(' ');
								Color showframecolor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
								varShowFrame[k].SetShowFrameProp(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), showframecolor);
							}
							//MainForm.MeanX_PupilCenter[i] = Double.Parse(values[0]);

							HintForm varCue = new HintForm();
							line = reader.ReadLine();
							line = reader.ReadLine();
							values = line.Substring(9).Split(' ');

							varCue.type = int.Parse(values[0]);
							if (int.Parse(values[0]) == 1)
							{
								//SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.ArrowLocX0 + " " + AllLevelProp[i][j].Cue.ArrowLocX1 + " " + AllLevelProp[i][j].Cue.ArrowLocY + " " + AllLevelProp[i][j].Cue.ArrowColor.R + " " + AllLevelProp[i][j].Cue.ArrowColor.G + " " + AllLevelProp[i][j].Cue.ArrowColor.B + " " + AllLevelProp[i][j].Cue.ArrowWidth;
								Color showframecolor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));

								varCue.ArrowWidth = int.Parse(values[8]);
								varCue.SetArrowProp(int.Parse(values[3]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[4]), showframecolor);
							}
							else if (int.Parse(values[0]) == 2)
							{
								//SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.BoxRatio + "\n";
								varCue.SetBoxProp(20, int.Parse(values[1]), Color.Black);
							}
							else
							{

							}

							line = reader.ReadLine();
							line = reader.ReadLine();
							int reward = int.Parse(line.Substring(9));
							////Debug.Write("Load Debug " + line.Substring(9) + "\n");

							varFrame.SetProperties(BGColor, FrameTime, varFixation, fixationtime, NumberStimulus, varStimulus, reward, varCue, NumberShowFrame, varShowFrame);
							Debug.Write("FixTime1 : " + varFrame.FixationTime + "\n");

							line = reader.ReadLine();
							line = reader.ReadLine();
							values = line.Substring(9).Split(' ');
							RepeatLinkFrame repeatInfo = new RepeatLinkFrame();
							repeatInfo.SetProperties(bool.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));

							varFrame.RepeatInfo = repeatInfo;

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

					for (int i = 0; i < AllLevelProp.Count; i++)
					{
						//add a new RowStyle as a copy of the previous one
						this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));
						this.Task_Table.RowCount++;

						var namebox = new TextBox();
						namebox.Name = "NameTask_TB" + (Task_Table.RowCount - 1);
						namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);

						namebox.Text = AllLevelName[i];
						Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount - 1);
						Debug.Write(" Hellp" + "\n");

						var Combox = new ComboBox();
						Combox.Items.Add(" ");
						Combox.Items.Add("Design");
						Combox.Items.Add("MGS");
						Combox.Items.Add("VGS");
						Combox.Items.Add("Posner");
						//Combox.Items.Add("Delete");
						Combox.Name = "SelectTask_CB" + (Task_Table.RowCount - 1);
						Debug.Write(" Combo" + Combox.Name + "\n");
						Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
						this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount - 1);
						var txbox = new TextBox();
						txbox.Text = Convert.ToString(NumerRepeat[i]);
						txbox.Name = "NumTrial_TB" + (Task_Table.RowCount - 1);
						txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);

						Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount - 1);
						Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount - 1) }, 3, this.Task_Table.RowCount - 1);
						Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount - 1) }, 4, this.Task_Table.RowCount - 1);
						UpdateData(i + 1);
						UpdateComboBox(i + 1);
					}
				}
			}
		}

		private void SelectTask_CB_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;

			String cmbName = cmb.Name;
			int index = (int)Char.GetNumericValue(cmbName[(cmbName.Length - 1)]);
			ActiveCol = index;
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
					break;
					if (AllLevelProp.Count > 0)//&& AllLevelProp[index - 1].Count > 1
					{
						Debug.Write("Num List : " + AllLevelName.Count + " " + AllLevelProp.Count + " \n");
						for (int i = AllLevelName.Count -1; i > 0; i--)
						{
							Label FrCountLB = Controls.Find("FramePerTask_LB" + (i), true).FirstOrDefault() as Label;
							Task_Table.Controls.Remove(FrCountLB);
							Label TotalTimeLB = Controls.Find("TotalTime_LB" + (i), true).FirstOrDefault() as Label;
							Task_Table.Controls.Remove(TotalTimeLB);
							TextBox RptTB = Controls.Find("NumTrial_TB" + (i), true).FirstOrDefault() as TextBox;
							Task_Table.Controls.Remove(RptTB);
							TextBox NmTB = Controls.Find("NameTask_TB" + (i), true).FirstOrDefault() as TextBox;
							Task_Table.Controls.Remove(NmTB);
							ComboBox TaskCB = Controls.Find("SelectTask_CB" + (i), true).FirstOrDefault() as ComboBox;
							Task_Table.Controls.Remove(TaskCB);
							Task_Table.RowStyles.RemoveAt(i);
							Task_Table.RowCount--;
						}

						AllLevelProp.RemoveAt(index - 1);
						AllLevelName.RemoveAt(index - 1);
						NumerRepeat.RemoveAt(index - 1);
						EnabledTask.RemoveAt(index - 1);
						BaseIndex.RemoveAt(index - 1);
						Debug.Write("Num List : " + AllLevelProp.Count + " \n");
						for (int i = 0; i < AllLevelProp.Count; i++)
						{
							//add a new RowStyle as a copy of the previous one
							this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));
							this.Task_Table.RowCount++;

							var namebox = new TextBox();
							namebox.Name = "NameTask_TB" + (Task_Table.RowCount - 1);
							namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);

							namebox.Text = AllLevelName[i];
							Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount - 1);

							var Combox = new ComboBox();
							Combox.Items.Add(" ");
							Combox.Items.Add("Design");
							Combox.Items.Add("MGS");
							Combox.Items.Add("VGS");
							Combox.Items.Add("Posner");
							//Combox.Items.Add("Delete");
							Combox.Name = "SelectTask_CB" + (Task_Table.RowCount - 1);
							Debug.Write(" Combo" + Combox.Name + "\n");
							Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
							this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount - 1);
							var txbox = new TextBox();
							txbox.Text = Convert.ToString(NumerRepeat[i]);
							txbox.Name = "NumTrial_TB" + (Task_Table.RowCount - 1);
							txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);

							Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount - 1);
							Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount - 1) }, 3, this.Task_Table.RowCount - 1);
							Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount - 1) }, 4, this.Task_Table.RowCount - 1);
							UpdateData(i + 1);
							UpdateComboBox(i + 1);
						}
						if (AllLevelProp.Count != EnabledTask.Count)
						{
							EnabledTask.RemoveAt(EnabledTask.Count - 1);
							AllLevelName.RemoveAt(AllLevelName.Count - 1);
						}
					}
					else
					{
						AllLevelProp.RemoveAt(0);
						NumerRepeat[0] = 1;
						EnabledTask[0] = 0;
						AllLevelName[0] = "Untitled1";
						BaseIndex[0] = 0;

						Label FrCountLB = Controls.Find("FramePerTask_LB" + 1, true).FirstOrDefault() as Label;
						Task_Table.Controls.Remove(FrCountLB);
						Label TotalTimeLB = Controls.Find("TotalTime_LB" + 1, true).FirstOrDefault() as Label;
						Task_Table.Controls.Remove(TotalTimeLB);
						TextBox RptTB = Controls.Find("NumTrial_TB" + 1, true).FirstOrDefault() as TextBox;
						Task_Table.Controls.Remove(RptTB);
						TextBox NmTB = Controls.Find("NameTask_TB" + 1, true).FirstOrDefault() as TextBox;
						Task_Table.Controls.Remove(NmTB);
						ComboBox TaskCB = Controls.Find("SelectTask_CB" + 1, true).FirstOrDefault() as ComboBox;
						Task_Table.Controls.Remove(TaskCB);
						Task_Table.RowStyles.RemoveAt(1);
						Task_Table.RowCount--;

						//add a new RowStyle as a copy of the previous one
						this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));
						this.Task_Table.RowCount++;


						var namebox = new TextBox();
						namebox.Name = "NameTask_TB" + (Task_Table.RowCount - 1);
						namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);

						namebox.Text = AllLevelName[0];
						Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount - 1);


						var Combox = new ComboBox();
						Combox.Items.Add(" ");
						Combox.Items.Add("Design");

						Combox.Name = "SelectTask_CB" + (Task_Table.RowCount - 1);
						Debug.Write(" Combo" + Combox.Name + "\n");
						Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
						this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount - 1);
						var txbox = new TextBox();
						txbox.Text = Convert.ToString(NumerRepeat[0]);
						txbox.Name = "NumTrial_TB" + (Task_Table.RowCount - 1);
						txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
						Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount - 1);
						Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount - 1) }, 3, this.Task_Table.RowCount - 1);
						Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount - 1) }, 4, this.Task_Table.RowCount - 1);
					}

					break;

				case "Edit":
					Designer EditForm = new Designer(2, index);
					EditForm.FormClosing += delegate { this.Show(); this.UpdateComboBox(index); };
					this.Hide();
					EditForm.Show();
					break;
				case "Load":
					LoadTaskFromFile();
					break;
				default:


					break;
			}


		}

		public void TaskPreview_VisibleChanged(object sender, EventArgs e)
		{
			if (!ChangeHappened)
				return;
			ChangeHappened = false;

			Label FrCountLB = Controls.Find("FramePerTask_LB" + ActiveCol, true).FirstOrDefault() as Label;
			FrCountLB.Text = Convert.ToString(AllLevelProp[ActiveCol - 1].Count);
			UpdateData(ActiveCol);
		}

		private void Add_PB_Click(object sender, EventArgs e)
		{
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
			Combox.Items.Add("Load");

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
				Label timeLB = Controls.Find("TotalTime_LB" + Index, true).FirstOrDefault() as Label;
				Label numFrLB = Controls.Find("FramePerTask_LB" + Index, true).FirstOrDefault() as Label;
				numFrLB.Text = Convert.ToString(AllLevelProp[Index - 1].Count);

				TextBox numtrialTB = Controls.Find("NumTrial_TB" + Index, true).FirstOrDefault() as TextBox;
				numtrialTB.Text = Convert.ToString(NumerRepeat[Index - 1]);
				TextBox nametaskTB = Controls.Find("NameTask_TB" + Index, true).FirstOrDefault() as TextBox;
				nametaskTB.Text = AllLevelName[Index - 1];
				timeLB.Text = Convert.ToString(time * int.Parse(numtrialTB.Text));
			}
			else
			{
				Label timeLB = Controls.Find("TotalTime_LB" + Index, true).FirstOrDefault() as Label;
				Label numFrLB = Controls.Find("FramePerTask_LB" + Index, true).FirstOrDefault() as Label;
				numFrLB.Text = Convert.ToString(0);
				timeLB.Text = Convert.ToString(0);

				TextBox numtrialTB = Controls.Find("NumTrial_TB" + Index, true).FirstOrDefault() as TextBox;
				numtrialTB.Text = Convert.ToString(NumerRepeat[Index - 1]);
				TextBox nametaskTB = Controls.Find("NameTask_TB" + Index, true).FirstOrDefault() as TextBox;
				nametaskTB.Text = AllLevelName[Index - 1];
				timeLB.Text = Convert.ToString(time * int.Parse(numtrialTB.Text));
			}


		}
		
		private void ConnectLan()
		{
			Debug.Write(" LANDebug" + TaskPreview.LocalIP + " " + TaskPreview.LocalPort + " " + TaskPreview.RemoteIP + " " + TaskPreview.RemotePort + " " + LANConnected + " " + UseLan + "\n");

			//set up socket
			TaskPreview.mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			TaskPreview.mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

			//binding sockets
			TaskPreview.epLocal = new IPEndPoint(IPAddress.Parse(TaskPreview.LocalIP), TaskPreview.LocalPort);
			TaskPreview.mySocket.Bind(TaskPreview.epLocal);

			//Connecting To Remote IP
			TaskPreview.epRemote = new IPEndPoint(IPAddress.Parse(TaskPreview.RemoteIP), TaskPreview.RemotePort);
			TaskPreview.mySocket.Connect(TaskPreview.epRemote);
		}

		private void Stop_PB_Click(object sender, EventArgs e)
		{
			StopBT_Pushed = true;
		}

		private void Task_Table_Scroll(object sender, ScrollEventArgs e)
		{
			return;
		}

		private void NumTrial_TB_TextChanged(object sender, EventArgs e)
		{
			TextBox cmb = (TextBox)sender;

			String cmbName = cmb.Name;
			int index = (int)Char.GetNumericValue(cmbName[(cmbName.Length - 1)]);
			NumerRepeat[index - 1] = int.Parse(cmb.Text);
			UpdateData(index);
		}

		private void Start_PB_Click(object sender, EventArgs e)
		{
			StopBT_Pushed = false;
			if (LANConnected & UseLan)
				ConnectLan();
			Debug.Write(" LANDebug" + TaskPreview.LocalIP + " " + TaskPreview.LocalPort + " " + TaskPreview.RemoteIP + " " + TaskPreview.RemotePort + " " + LANConnected + " " + UseLan + "\n");

			ShowFrame ShFrame = new ShowFrame();

			Screen[] screens = Screen.AllScreens;
			if (screens.Length == 2)
			{
				ShFrame.Location = new Point(screens[0].Bounds.X, screens[0].Bounds.Y);
				Debug.Write(screens[0].Bounds + "\n");
			}
			ShFrame.Show();
		}

		private void UpdateComboBox(int index)
		{
			if (EnabledTask[index - 1] == 2)
			{
				ComboBox comb = panel1.Controls.Find("SelectTask_CB" + index, true).FirstOrDefault() as ComboBox;
				comb.Items.Clear();
				//comb.Items.Add("Delete");
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
			TextBox cmb = (TextBox)sender;

			String cmbName = cmb.Name;
			int index = (int)Char.GetNumericValue(cmbName[(cmbName.Length - 1)]);
			Debug.Write("Helpppppp " + AllLevelName.Count + " \n");
			AllLevelName[index - 1] = cmb.Text;
		}

		private void SaveOut_CB_CheckedChanged(object sender, EventArgs e)
		{
			Save_BT.Enabled = SaveOut_CB.Checked;
			Savetask = SaveOut_CB.Checked;
		}

		private void Save_BT_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "CSV Files (*.csv)|*.csv";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				TaskPreview.DataPath = sfd.FileName;
				Path_TB.Text = sfd.FileName;
			}
		}
	}
}
