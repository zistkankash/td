using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Psychophysics.Designer;

namespace Basics
{
	public class PsycophysicTasks : TaskData
	{
		public int NFrame = 0;
		public FrameProperties[] FrameProps;
		public List<List<FrameProperties>> AllLevelProp = new List<List<FrameProperties>>();
		public List<int> BaseIndex = new List<int>();
		public List<String> AllLevelName = new List<String>();
		public List<int> EnabledTask = new List<int>();
		public List<int> NumerRepeat = new List<int>();
		public bool Savetask = false;
		public string DataPath = "";
		public int SeqRandTaskRunner = 2;
		public bool Brake;
		

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
					SaveText += "_________Number Of Fixations\n";
                    SaveText += "_________" + AllLevelProp[i][j].Fixation.Count + "\n";
                    for (int k=0; k < AllLevelProp[i][j].Fixation.Count; k++)
                    {
                        SaveText += "_________" + AllLevelProp[i][j].Fixation[k].Xloc + " " + AllLevelProp[i][j].Fixation[k].Yloc + " " + AllLevelProp[i][j].Fixation[k].Width + " " + AllLevelProp[i][j].Fixation[k].Type + " " + AllLevelProp[i][j].Fixation[k].Time + " " + AllLevelProp[i][j].Fixation[k].ColorPt.R + " " + AllLevelProp[i][j].Fixation[k].ColorPt.G + " " + AllLevelProp[i][j].Fixation[k].ColorPt.B + "\n";
                    }
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
			SaveText += "Distance " + BasConfigs.userDistance + "\n";
			SaveText += "MoniTorWidth(m) " + BasConfigs.WidthM + "\n";
			SaveText += "MoniTorHeight(m) " + BasConfigs.HeightM + "\n";
			SaveText += "MoniTorWidth(pixel) " + BasConfigs._monitor_resolution_x + "\n";
			SaveText += "MoniTorHeight(pixel) " + BasConfigs._monitor_resolution_y + "\n";
			File.WriteAllText(DataPath, SaveText);
			return true;
		}

		public bool LoadTaskFromFile(bool _getAddress, string TaskAddress)
		{
			try
			{
				if (!_getAddress)
					_tskAddress = TaskAddress;
				else
				{
					if (Load(true, TaskType.cognitive).Result != ResultState.OK)
						return false;
				}
				AllLevelProp.Clear();
				AllLevelName.Clear();
				BaseIndex.Clear();
				NumerRepeat.Clear();
				EnabledTask.Clear();

				using (var fs = File.OpenRead(_tskAddress))
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

                            //Read fixations......................................................................................
							line = reader.ReadLine();
							line = reader.ReadLine();
                            int NumberFixations = int.Parse(line.Substring(9));
                            List<ObjectProp> fixations = new List<ObjectProp>(NumberFixations);
                            for (int fixC = 0; fixC < NumberFixations; fixC++)
                            {
                                line = reader.ReadLine();
                                values = line.Substring(9).Split(' ');
                                int fixationtime = int.Parse(values[4]);
                                Color fixationColor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
                                ObjectProp newFix = new ObjectProp();
                                newFix.Xloc = int.Parse(values[0]); newFix.Yloc = int.Parse(values[1]); newFix.Width = int.Parse(values[2]);
                                newFix.Type = int.Parse(values[3]); newFix.Time = int.Parse(values[4]); newFix.ColorPt = fixationColor;
                                //newFix.ConvertToDeg();
                                newFix.Enable = true;
                                fixations.Add(newFix);
                            }
                            
                            //Read stimuluses........................................................................................
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
							varFrame.SetProperties(BGColor, FrameTime, fixations, NumberStimulus, varStimulus, reward, null, 0, null, tg);

							ListAddedFrame.Add(varFrame);
						}
						AllLevelProp.Add(ListAddedFrame);
					}
					line = reader.ReadLine();
					var value = line.Split(' ');
					BasConfigs.userDistance = double.Parse(value[1]);

					line = reader.ReadLine();
					value = line.Split(' ');
					BasConfigs.WidthM = double.Parse(value[1]);

					line = reader.ReadLine();
					value = line.Split(' ');
					BasConfigs.HeightM = double.Parse(value[1]);

					TaskAddress = _tskAddress;
					
					return true;
				}
			}
			catch (Exception)
			{
				
				return false;
			}
			
			
		}

		public PsycophysicTasks(int numFrame)
		{
			NFrame = numFrame;
		}
	}
}
