using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using TaskDesigner;
using Basics;
using TaskRunning;

namespace Psychophysics
{
    public partial class ShowFrame : Form
    {
		// Sound
		SoundPlayer winSound = new SoundPlayer(Resource.coin);
		SoundPlayer failSound = new SoundPlayer(Resource.fail);
					
		// ROI
		bool InROI = false;
		bool sacInAppend;
		public bool _useGaz = false, _userClosed = true;
		bool ETW, EFW, AFW;
		int level = -1;
		int frame = -1, lastFrame;
		int framelimit, timeLimit;
		bool fixatehappened = false;
		public Bitmap flag, opFlag, opFlagTemp;
		public int opFlagWidth, opFlagHeight;
		Graphics flagGraphics, opFlagGraphics;
		FixationPts stimulus;
		FixationPts fixationstimulus;
		Pen fixationp;
		SolidBrush sb;
		Bitmap bmpvar;
		int numberstimulus;
		readonly object timerLock = new object(), eventLock = new object();
		bool containfixation = false;
		double FixationCenterX = 0, FixationCenterY = 0, FixationCenterWidth = 0;
		double preFixationCenterX, preFixationCenterY, preFixationCenterWidth;
		int FixationCenterTime = 0;
		int FixationRewardType = 0;
		Stopwatch FixationSW = new Stopwatch(), LoopWatch = new Stopwatch();
		public int[] RandForTaskLevel;
		int indexRandForTaskLevel = -1;
		int trialCounter;
		public string pupilDataPath, eventDataPath;
		StringBuilder _dataTask = new StringBuilder(1000000), _eventData = new StringBuilder(1000000), temp = new StringBuilder(10000) ;
		MicroLibrary.MicroTimer microTimer;
		MicroLibrary.MicroStopwatch _eventMicSW = new MicroLibrary.MicroStopwatch();
		GazeTriple gz;
		StringBuilder _pupilStringBiulder = new StringBuilder(1000000);

		public ShowFrame(bool getGaze, int operWidth, int operHeight)
		{
			InitializeComponent();
			
			trialCounter = 0;

			if (PsycoPhysicTask.AllLevelProp.Count == 0)
			{
				
				return;
			}
			if (getGaze)
			{
				
				_useGaz = true;
			}
			opFlagWidth = operWidth;
			opFlagHeight = operHeight;
			ScreenConfig();
			failSound.Load();
			winSound.Load();
            MakeRandomRepeat(PsycoPhysicTask.TypeDisplay);
        }

		public void ScreenConfig()
		{
			Screen[] screen = Screen.AllScreens;
			if (screen.Length == 2)
			{
				this.Size = new Size(screen[1].Bounds.Width, screen[1].Bounds.Height);
				this.WindowState = FormWindowState.Maximized;
				this.Location = new Point(screen[0].Bounds.Width, 0);
				flag = new Bitmap(screen[1].Bounds.Width, screen[1].Bounds.Height);
				
			}
			else
			{
				this.WindowState = FormWindowState.Maximized;
				flag = new Bitmap(screen[0].Bounds.Width, screen[0].Bounds.Height);
			}
            if(_useGaz)
			{
				opFlagTemp = new Bitmap(flag.Width, flag.Height);
				opFlag = new Bitmap(opFlagWidth, opFlagHeight);
				opFlagGraphics = Graphics.FromImage(opFlagTemp);
			}
			flagGraphics = Graphics.FromImage(flag);	
		}

		void ShowFrame_Load(object sender, EventArgs e)
		{
			
			NextTrial();
					
			MicroTimerEnable();
			Timer1.Enabled = true;
			Timer1.Start();
			LoopWatch.Start();
			
			if (_useGaz)
			{
				RunnerUtils.StartGaze();
				_eventMicSW.Start();
				RunnerUtils.ETGaze();

			}
		}

		void Timer1_Tick(object sender, EventArgs e)
		{
			lock (timerLock)
			{

				if (!(fixatehappened || LoopWatch.ElapsedMilliseconds > timeLimit))
					return;

				if (PsycoPhysicTask.brake)
				{
					StopRun(true);
					return;
				}


				#region fixatehappened

				if (!_useGaz)
				{
					if (!NextFrame())
						return;
				}

				else
				{
					if (!containfixation)
					{

						if (!NextFrame())

							return;

					}
					else
					{
						if (fixatehappened)
						{
							Debug.Write("fixate falsed");
							fixatehappened = false;
							if (FixationRewardType == 2 || FixationRewardType == 4)
								winSound.Play();


							if (!NextFrame())
								return;


						}
						else
						{
							if (FixationRewardType == 3 || FixationRewardType == 4)
								failSound.Play();

							if (!NextTrial())
								return;

						}
					}
				}

				#endregion


				LoopWatch.Restart();
			}
			return;
		}

		bool NextFrame()
		{
			frame++;
			Debug.Write(level.ToString() + " " + frame.ToString() + "\n");
			InROI = false;
			fixatehappened = false;

			if (frame < framelimit)
			{

				AllocateFrame();
				GenFrameEvents();
				timeLimit = PsycoPhysicTask.AllLevelProp[level][frame].FrameTime;
				FixationRewardType = PsycoPhysicTask.AllLevelProp[level][frame].RewardType;
				fixationstimulus = PsycoPhysicTask.AllLevelProp[level][frame].Fixation;
				if (fixationstimulus.Xloc != -1)
				{
					containfixation = true;
					if (fixationstimulus.Type == 3)
					{

						preFixationCenterX = FixationCenterX;
						FixationCenterX = fixationstimulus.Xloc;
						preFixationCenterY = FixationCenterY;
						FixationCenterY = fixationstimulus.Yloc;
						preFixationCenterWidth = FixationCenterWidth;
						FixationCenterWidth = fixationstimulus.Width;
						FixationCenterTime = PsycoPhysicTask.AllLevelProp[level][frame].FixationTime;
					}
				}
				else
					containfixation = false;

				return true;
			}
			else
			{
				frame--;
				return NextTrial();
			}
		}

		bool NextTrial()
		{
			if (indexRandForTaskLevel > 0)
				if (PsycoPhysicTask.AllLevelProp[level][lastFrame].events.trialEnd != -1)
				{
					AppendEventData("TEnd", PsycoPhysicTask.AllLevelProp[level][frame].events.trialEnd.ToString());
				}
			indexRandForTaskLevel++;
			if (indexRandForTaskLevel == RandForTaskLevel.Length)
			{
				_userClosed = false;
				StopRun(true);
				return false;
			}
			level = RandForTaskLevel[indexRandForTaskLevel];
			lastFrame = frame;
			frame = -1;
			//trialCounter++;
			framelimit = PsycoPhysicTask.AllLevelProp[level].Count;
			NextFrame();
			return true;
		}

		void OnTimedEvent(object sender,
				  MicroLibrary.MicroTimerEventArgs timerEventArgs)
		{
			if (_useGaz)
			{
				gz = RunnerUtils.ETGaze();
				if (gz != null)
				{
					TaskOperator.gzX = (float)gz.x;
					TaskOperator.gzY = (float)gz.y;
					_pupilStringBiulder.Clear();
					_pupilStringBiulder.Append(gz.x.ToString()); _pupilStringBiulder.Append(","); _pupilStringBiulder.Append(gz.y.ToString());
					_pupilStringBiulder.Append(","); _pupilStringBiulder.Append(gz.pupilSize.ToString()); _pupilStringBiulder.Append(",");
					_pupilStringBiulder.Append(gz.time.ToString());
					_dataTask.AppendLine(_pupilStringBiulder.ToString());
					if (containfixation)
					{
						CheckPointInROI(new double[] { gz.x, gz.y });
						//CheckPointInROI(new double[] { 720, 450 });
					}
				}
				//if (containfixation)
				//{
				//	CheckPointInROI(new double[] { gz.x, gz.y });
				//	CheckPointInROI(new double[] { 720, 450 });
				//}
				else
					return;

			}

		}

		void GenFrameEvents()
		{
			if (indexRandForTaskLevel < RandForTaskLevel.Length)
			{
				if (PsycoPhysicTask.AllLevelProp[level][frame].events.trialStart != -1)
				{
					AppendEventData("TStart",PsycoPhysicTask.AllLevelProp[level][frame].events.trialStart.ToString());
				}
				if (PsycoPhysicTask.AllLevelProp[level][frame].events.condition != -1)
				{
					AppendEventData("Cond",PsycoPhysicTask.AllLevelProp[level][frame].events.condition.ToString());
				}
				
				if (PsycoPhysicTask.AllLevelProp[level][frame].events.fixOn != -1)
				{
					AppendEventData("FixOn",PsycoPhysicTask.AllLevelProp[level][frame].events.fixOn.ToString());
				}
				if (PsycoPhysicTask.AllLevelProp[level][frame].events.fixOff != -1)
				{
					AppendEventData("FixOff",PsycoPhysicTask.AllLevelProp[level][frame].events.fixOff.ToString());
				}
				if (PsycoPhysicTask.AllLevelProp[level][frame].events.stimOn != -1)
				{
					AppendEventData("StimOn",PsycoPhysicTask.AllLevelProp[level][frame].events.stimOn.ToString());
				}
				if (PsycoPhysicTask.AllLevelProp[level][frame].events.stimOff != -1)
				{
					AppendEventData("StimOff",PsycoPhysicTask.AllLevelProp[level][frame].events.stimOff.ToString());
				}
				if (PsycoPhysicTask.AllLevelProp[level][frame].events.enterFixWindow != -1)
					EFW = true;
				else
					EFW = false;
				if (PsycoPhysicTask.AllLevelProp[level][frame].events.abortFixWindow != -1)
					AFW = true;
				else
					AFW = false;
				if (PsycoPhysicTask.AllLevelProp[level][frame].events.enterTargetWindow != -1)
				{
					ETW = true;
					sacInAppend = true;
				}
				else
				{ 
					ETW = false;
					sacInAppend = false;
				}
			}
		}

		void AppendEventData(string eventName, string eventCode)
		{
			lock (eventLock)
			{
				temp.Clear();
				temp.Append(eventName);
				temp.Append(",");
				temp.Append(eventCode);
				temp.Append(",");
				temp.Append(_eventMicSW.ElapsedMicroseconds.ToString());
				_eventData.AppendLine(temp.ToString());
			}
		}

		void AllocateFrame()
		{
			try
			{
				flagGraphics.Clear(PsycoPhysicTask.AllLevelProp[level][frame].BGColor);

				numberstimulus = PsycoPhysicTask.AllLevelProp[level][frame].Stimulus.Length;

				#region add stimulus fixation

				for (int k = 0; k < numberstimulus; k++)
				{
					stimulus = PsycoPhysicTask.AllLevelProp[level][frame].Stimulus[k];
					//Use Solid Brush for filling the graphic shapes
					sb = new SolidBrush(Color.FromArgb(stimulus.Contrast, stimulus.ColorPt));

					if (stimulus.Type == 1)
					{
						flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
						//if (_useGaz)
						//	opFlagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 2)
					{
						flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
						//if (_useGaz)
						//	opFlagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);

					}

					if (stimulus.Type == 3)
					{
						flagGraphics.FillEllipse(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
						//if (_useGaz)
						//	opFlagGraphics.FillEllipse(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);

					}

					if (stimulus.Type == 4)
					{
						if (File.Exists(stimulus.PathPic))
						{
							bmpvar = new Bitmap(stimulus.PathPic);
							bmpvar = new Bitmap(bmpvar, new Size(stimulus.Width, stimulus.Height));
							flagGraphics.DrawImage(bmpvar, new Point(stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2));
							//if (_useGaz)
							//	opFlagGraphics.DrawImage(bmpvar, new Point(stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2));

						}

						bmpvar.Dispose();
					}

				}
				//flagGraphics.Flush();

				//if (_useGaz)
				//{
				//	#region add fixation
				//	opFlagGraphics.Clear(PsycoPhysicTask.AllLevelProp[level][frame].BGColor);


				//	fixationstimulus = PsycoPhysicTask.AllLevelProp[level][frame].Fixation;
				//	//Use Solid Brush for filling the graphic shapes
				//	fixationp = new Pen(fixationstimulus.ColorPt);

				//	if (fixationstimulus.Type == 3)
				//	{
				//		containfixation = true;
				//		preFixationCenterX = FixationCenterX;
				//		FixationCenterX = fixationstimulus.Xloc;
				//		preFixationCenterY = FixationCenterY;
				//		FixationCenterY = fixationstimulus.Yloc;
				//		preFixationCenterWidth = FixationCenterWidth;
				//		FixationCenterWidth = fixationstimulus.Width;
				//		FixationCenterTime = PsycoPhysicTask.AllLevelProp[level][frame].FixationTime;

				//		opFlagGraphics.DrawEllipse(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
				//		opFlag = BitmapManager.DrawOn(opFlagTemp, new Size(opFlagWidth, opFlagHeight), Color.White);
				//	}
				//}
				#endregion
				if (_useGaz)
					opFlag = BitmapManager.DrawOn(flag, new Size(opFlagWidth, opFlagHeight), PsycoPhysicTask.AllLevelProp[level][frame].BGColor);
				
				pictureBox1.Image = flag;
			}
			catch (Exception)
			{
				Debug.Write("graphic error");
				return;
			}
		}

		void SaveData()
		{
			try
			{
				if (_useGaz && _dataTask.Length > 0)
				{
					File.WriteAllText(pupilDataPath, _dataTask.ToString());
					_dataTask.Clear();

				}
				if (_useGaz && _eventData.Length > 0)
				{

					File.WriteAllText(eventDataPath, _eventData.ToString());
					_eventData.Clear();
				}
			}
			catch(Exception)
			{
				MessageBox.Show("Can not save file. may be its used by another program.");
				return;
			}
		}

		void StopRun(bool toClose)
		{
			if (_useGaz)
				SaveData();
            if (microTimer != null)
            {
                microTimer.Enabled = false;
                if (_useGaz)
                {
                    RunnerUtils.EndGaze();
                    _eventMicSW.Reset();
                }
            }
            Timer1.Enabled = false;
           
			TaskOperator._stopped = true;
			
			if (toClose)
			{
				
				Close();
				
			}
		}

		void CheckPointInROI(double[] Point)
		{
			lock (timerLock)
			{
				if (fixatehappened)
					return;

				double dist1, dist2;
				dist1 = (Point[0] - FixationCenterX) * (Point[0] - FixationCenterX) + (Point[1] - FixationCenterY) * (Point[1] - FixationCenterY);
				if (sacInAppend)
				{
					Debug.Write("d2" + dist1.ToString() + "\n");
					dist2 = (Point[0] - preFixationCenterX) * (Point[0] - preFixationCenterX) + (Point[1] - preFixationCenterY) * (Point[1] - preFixationCenterY);
					if (dist2 > preFixationCenterWidth * preFixationCenterWidth)
					{
						sacInAppend = false;
						AppendEventData("SacIn",PsycoPhysicTask.AllLevelProp[level][frame].events.saccadInit.ToString());
					}
				}

				#region check dist fixate
				if (dist1 < FixationCenterWidth * FixationCenterWidth)
				{
					Debug.Write("in : d1 " + dist1.ToString() + "\n");
					if (!InROI)
					{
						Debug.Write("ROI false" + dist1.ToString() + "\n");
						InROI = true;
						FixationCenterTime = PsycoPhysicTask.AllLevelProp[level][frame].FixationTime;
						FixationSW.Start();
						if (ETW)
							AppendEventData("ETW",PsycoPhysicTask.AllLevelProp[level][frame].events.enterTargetWindow.ToString());
						if (EFW)
							AppendEventData("EFW",PsycoPhysicTask.AllLevelProp[level][frame].events.enterFixWindow.ToString());
					}
					else
					{
						Debug.Write("ROI true" + dist1.ToString() + "\n");
						if (FixationSW.ElapsedMilliseconds >= FixationCenterTime)
						{
							Debug.Write("hold " + level.ToString() + " " + frame.ToString() + "\n");
							if (ETW)
								AppendEventData("SacLan",PsycoPhysicTask.AllLevelProp[level][frame].events.saccadLand.ToString());
							fixatehappened = true;
							FixationSW.Reset();
							InROI = false;
							return;
						}

					}
				}
				#endregion
				#region else check fixate
				else
				{
					Debug.Write("out : d1 " + dist1.ToString() + "\n");
					if (InROI && FixationSW.ElapsedMilliseconds < FixationCenterTime)
					{
						if (AFW)
							AppendEventData("AFW",PsycoPhysicTask.AllLevelProp[level][frame].events.abortFixWindow.ToString());
						InROI = false;
						fixatehappened = false;
						FixationSW.Reset();
					}

				}
				#endregion
			}
		}

		void ShowFrame_KeyDown(object sender, KeyEventArgs e)
		{
			if (!e.Handled)
				if (e.KeyCode == Keys.Escape)
				{
					e.Handled = true;
					Close();
				}
		}
       
        void MicroTimerEnable()
		{
			microTimer = new MicroLibrary.MicroTimer();
			microTimer.MicroTimerElapsed += new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);

			microTimer.Interval = 4000; // Call micro timer every 1000µs (1ms)
			microTimer.Enabled = true;
		}

		void ShowFrame_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_userClosed)
				StopRun(false);
			
		}
		
		void MakeRandomRepeat(int DisplayType)
		{
			int totalRepeat = 0;
			for (int i = 0; i < PsycoPhysicTask.NumerRepeat.Count; i++)
			{
				totalRepeat += PsycoPhysicTask.NumerRepeat[i];
			}
			RandForTaskLevel = new int[totalRepeat];
			int index = 0;
			for (int i = 0; i < PsycoPhysicTask.NumerRepeat.Count; i++)
			{
				for (int j = 0; j < PsycoPhysicTask.NumerRepeat[i]; j++)
				{

					RandForTaskLevel[index] = i;
					index++;
				}
			}

			if (DisplayType == 2)
			{
				int a, b;
				Random rnd = new Random();
				for (int i = 0; i < totalRepeat * 10; i++)
				{
					a = (rnd.Next(1, 1000) % totalRepeat);
					b = (rnd.Next(1, 1000) % totalRepeat);
					//Debug.Write("a and b " + a + " " + b + "\n");
					int varindex = RandForTaskLevel[a];
					RandForTaskLevel[a] = RandForTaskLevel[b];
					RandForTaskLevel[b] = varindex;
				}
			}
			
		}
	
	}
}
