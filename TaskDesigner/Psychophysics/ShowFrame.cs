using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automation.BDaq;
using System.Drawing.Drawing2D;
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
		
		public bool _useGaz = false;
		public bool _useDaq = false;

		int level = -1;
		int frame = -1;
		int framelimit, timeLimit;
		
		bool fixatehappened = false;
		
		public Bitmap flag, opFlag;
		
		Graphics flagGraphics, opFlagGraphics;
		int opFlagSizeX, opFlagSizeY;
		
		FixationPts stimulus;
		FixationPts fixationstimulus;
		Pen fixationp;
		SolidBrush sb;
		Bitmap bmpvar;
		int numberstimulus;
		bool containfixation = false;
		
		double FixationCenterX = 0, FixationCenterY = 0, FixationCenterWidth = 0;
		int FixationCenterTime = 0;
		int FixationRewardType = 0;
		
		Stopwatch FixationSW = new Stopwatch();
								
		public int[] RandForTaskLevel;
		int indexRandForTaskLevel = -1;
				
		int trialCounter;
		
		public string pupilDataPath, eventDataPath;
		string _dataTask = "", _eventData = "";
		//Timer
		
		MicroLibrary.MicroTimer microTimer;
		MicroLibrary.MicroStopwatch _eventMicSW = new MicroLibrary.MicroStopwatch();
		
		public ShowFrame(bool getGaze)
		{
			InitializeComponent();
			
			trialCounter = 0;

			if (PsycoPhysicTask.AllLevelProp.Count == 0)
			{
				
				return;
			}
			if (getGaze)
			{
				_useDaq = true;
				_useGaz = true;
			}
			ScreenConfig();
			failSound.Load();
			winSound.Load();
            MakeRandomRepeat(PsycoPhysicTask.TypeDisplay);

            NextTrial();

            DrawFrame();

            MicroTimerEnable();
            Timer1.Enabled = true;
            Timer1.Start();

            if (_useGaz)
            {
                RunnerUtils.StartGaze();
                _eventMicSW.Start();
                RunnerUtils.ETGaze();

            }
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
            opFlag = new Bitmap(flag.Width, flag.Height);
			opFlagGraphics = Graphics.FromImage(opFlag);
			flagGraphics = Graphics.FromImage(flag);	
		}
		
		private void Timer1_Tick(object sender, EventArgs e)
		{
			if (_useGaz)
				SaveData();

			if (PsycoPhysicTask.brake)
			{
				this.BeginInvoke(new MethodInvoker(Close));
			}

			
			microTimer.Stop();
			Timer1.Stop();

			#region fixatehappened
			
			if (!_useGaz)
			{
				if(!NextFrame())
                    return;
			}
			
			else
			{
				if (FixationRewardType == 0)
				{
                    if (!NextFrame())
                        return;

                }
				else
				{
					if (fixatehappened)
					{
						if (FixationRewardType == 3 || FixationRewardType == 4)
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
			          
			fixatehappened = false;
			InROI = false;
			DrawFrame();
			Timer1.Start();
			microTimer.Start();
			
			return;
		}

		private bool NextFrame()
		{
			frame++;
			if (frame < framelimit)
			{

				Timer1.Interval = PsycoPhysicTask.AllLevelProp[level][frame].FrameTime;
				FixationRewardType = PsycoPhysicTask.AllLevelProp[level][frame].RewardType;

				return true;
			}
			else
				return NextTrial();
		}

		private bool NextTrial()
		{
			if (level > -1)
				if (PsycoPhysicTask.AllLevelProp[level][frame - 1].events.trialEnd != -1)
					_eventData += PsycoPhysicTask.AllLevelProp[level][frame - 1].events.trialEnd.ToString() + "," + _eventMicSW.ElapsedMicroseconds.ToString() + "\n";
			frame = -1;
			indexRandForTaskLevel++;
			trialCounter++;

			if (indexRandForTaskLevel >= RandForTaskLevel.Length)
			{
				StopRun(true);
				return false;
			}
			level = RandForTaskLevel[indexRandForTaskLevel];

			if (PsycoPhysicTask.AllLevelProp[level][0].events.trialStart != -1)
				_eventData += PsycoPhysicTask.AllLevelProp[level][0].events.trialStart.ToString() + "," + _eventMicSW.ElapsedMicroseconds.ToString() + "\n";

			if (PsycoPhysicTask.AllLevelProp[level][0].events.condition != -1)
				_eventData += PsycoPhysicTask.AllLevelProp[level][0].events.condition.ToString() + "," + _eventMicSW.ElapsedMicroseconds.ToString() + "\n";

			framelimit = PsycoPhysicTask.AllLevelProp[level].Count;
			NextFrame();
			return true;
		}
		
		private void DrawFrame()
		{
			
			flagGraphics.Clear(PsycoPhysicTask.AllLevelProp[level][frame].BGColor);
			opFlagGraphics.Clear(PsycoPhysicTask.AllLevelProp[level][frame].BGColor);
			numberstimulus = PsycoPhysicTask.AllLevelProp[level][frame].Stimulus.Length;

			#region add stimulus

			for (int k = 0; k < numberstimulus; k++)
			{
				stimulus = PsycoPhysicTask.AllLevelProp[level][frame].Stimulus[k];
				//Use Solid Brush for filling the graphic shapes
				sb = new SolidBrush(Color.FromArgb(stimulus.Contrast, stimulus.ColorPt));

				if (stimulus.Type == 1)
				{
					flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
                    opFlagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
                }

				if (stimulus.Type == 2)
				{
					flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
                    opFlagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);

                }

                if (stimulus.Type == 3)
				{
					flagGraphics.FillEllipse(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
                    opFlagGraphics.FillEllipse(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);

                }
                //Debug.Write("Stimulius Error :" + k +" " + stimulus.PathPic + " " + numberstimulus  + " " + stimulus.Type+ " " + "\n");

                if (stimulus.Type == 4)
				{
					if (File.Exists(stimulus.PathPic))
					{
						bmpvar = new Bitmap(stimulus.PathPic);
						bmpvar = new Bitmap(bmpvar, new Size(stimulus.Width, stimulus.Height));
						flagGraphics.DrawImage(bmpvar, new Point(stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2));
                        opFlagGraphics.DrawImage(bmpvar, new Point(stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2));

                    }

                    bmpvar.Dispose();
				}

			}
			#endregion
			
			#region add fixation

			flagGraphics.Flush();
            
			fixationstimulus = PsycoPhysicTask.AllLevelProp[level][frame].Fixation;
			//Use Solid Brush for filling the graphic shapes
			fixationp = new Pen(fixationstimulus.ColorPt);
			//Debug.Write("Data  f:" + fixationstimulus.Xloc + " " + fixationstimulus.Yloc + " " + fixationstimulus.Type  + " " + numberstimulus + " " + "\n");
			if (fixationstimulus.Type == 1)
			{
				containfixation = true;
				FixationCenterX = fixationstimulus.Xloc;
				FixationCenterY = fixationstimulus.Yloc;
				FixationCenterWidth = fixationstimulus.Width;
				FixationCenterTime = PsycoPhysicTask.AllLevelProp[level][frame].FixationTime;

				//flagGraphics.DrawRectangle(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
			}

			if (fixationstimulus.Type == 2)
			{
				containfixation = true;
				FixationCenterX = fixationstimulus.Xloc;
				FixationCenterY = fixationstimulus.Yloc;
				FixationCenterWidth = fixationstimulus.Width;
				FixationCenterTime = PsycoPhysicTask.AllLevelProp[level][frame].FixationTime;

				//flagGraphics.DrawRectangle(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
			}

			if (fixationstimulus.Type == 3)
			{
				containfixation = true;
				FixationCenterX = fixationstimulus.Xloc;
				FixationCenterY = fixationstimulus.Yloc;
				FixationCenterWidth = fixationstimulus.Width;
				FixationCenterTime = PsycoPhysicTask.AllLevelProp[level][frame].FixationTime;

				opFlagGraphics.DrawEllipse(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
			}

			#endregion
			pictureBox1.Image = flag;
		}

		private void SaveData()
		{
			if (_useGaz && _dataTask.Length > 0)
			{
				File.AppendAllText(pupilDataPath, _dataTask);
				_dataTask = "";

			}
			if (_useGaz && _eventData.Length > 0)
			{

				File.AppendAllText(eventDataPath, _eventData);
				_eventData = "";
			}
		}

		private void ShowFrame_Load(object sender, EventArgs e)
		{
			
		}

		private void StopRun(bool toClose)
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
			if (_useGaz)
			{
				RunnerUtils.EndGaze();
			}
			if (toClose)
			{
				this.BeginInvoke(new MethodInvoker(Close));
				Close();
			}
		}

		private void ShowFrame_KeyPress(object sender, KeyPressEventArgs e)
		{
			
			
		}

		private void CheckPointInROI(double[] Point)
		{
			double dist = 0;
			dist = (Point[0] - FixationCenterX) * (Point[0] - FixationCenterX) + (Point[1] - FixationCenterY) * (Point[1] - FixationCenterY);
			
			#region check dist fixate
			if (dist < FixationCenterWidth * FixationCenterWidth)
			{
				if (!InROI)
				{
					InROI = true;
					
					FixationCenterTime = PsycoPhysicTask.AllLevelProp[level][frame].FixationTime;
					FixationSW.Restart();
					if (_useGaz)
						_eventData += _eventMicSW.ElapsedMicroseconds.ToString() + "\n";

				}
				else
				{
					
					if (FixationSW.ElapsedMilliseconds >= FixationCenterTime)
					{
						microTimer.Stop();
						
						if (_useGaz)
							_eventData +=  _eventMicSW.ElapsedMicroseconds.ToString() + "\n";
						fixatehappened = true;
						FixationSW.Reset();
						
						InROI = false;
					}

				}
			}
			#endregion
			#region else check fixate
			else
			{
				
				if (InROI && FixationSW.ElapsedMilliseconds < FixationCenterTime)
				{
					if (_useGaz)
						_eventData +=  _eventMicSW.ElapsedMicroseconds.ToString() + "\n";
					InROI = false;
					fixatehappened = false;
					
					FixationSW.Reset();
				}

			}
			#endregion
						
			
		}

		private void ShowFrame_KeyDown(object sender, KeyEventArgs e)
		{
			if (!e.Handled)
				if (e.KeyCode == Keys.Escape)
				{
					e.Handled = true;
					Close();
				}
		}
       
        private void MicroTimerEnable()
		{
			microTimer = new MicroLibrary.MicroTimer();
			microTimer.MicroTimerElapsed += new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);

			microTimer.Interval = 4000; // Call micro timer every 1000µs (1ms)
			microTimer.Enabled = true;
		}

		private void ShowFrame_FormClosed(object sender, FormClosedEventArgs e)
		{
            StopRun(false);
			
		}

		private void OnTimedEvent(object sender,
				  MicroLibrary.MicroTimerEventArgs timerEventArgs)
		{
			GazeTriple gz;
			if (_useGaz)
			{
				gz = RunnerUtils.ETGaze();
				if (gz != null)
				{
					TaskOperator.gzX = (float)gz.x;
					TaskOperator.gzY = (float)gz.y;
					_dataTask += gz.x.ToString() + "," + gz.y.ToString() + "," + gz.pupilSize.ToString() + "," + gz.time.ToString() + "\n";
				}
				else
					return;
				if (containfixation)
				{
					CheckPointInROI(new double[] { gz.x, gz.y });
				}
			}
			
		}

		private void MakeRandomRepeat(int DisplayType)
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
