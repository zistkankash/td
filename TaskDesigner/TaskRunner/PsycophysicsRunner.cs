using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using TaskDesigner;
using Basics;
using static Psychophysics.Designer;

namespace TaskRunning
{
    public partial class PsycophysicsRunner : Form
    {
		// Sound
		SoundPlayer winSound = new SoundPlayer(Resource.coin);
		SoundPlayer failSound = new SoundPlayer(Resource.fail);
		PsycophysicTasks _task;
		
		// ROI
		int InROI = -1;
		bool sacInAppend;
		public bool _useGaz = false, _userClosed = true;
		bool ETW, EFW, AFW;
		int level = -1;
		int frame = -1, framelimit;
        bool fixatehappened = false, fixateBreak = false;
		public Bitmap flag, opFlag;
		public int opFlagWidth, opFlagHeight;
		Graphics flagGraphics;
		Graphics opFlagGraphics;
		float _screenRationX, _screenRatioY;
		FixationPts stimulus;
        ObjectProp[] _frameFixates;
		Pen fixationp;
		SolidBrush sb;
		Bitmap bmpvar, bmpvarOp;
		int numberstimulus;
		readonly object timerLock = new object(), eventLock = new object();
		bool containfixation = false;
		
		double preFixationCenterX, preFixationCenterY, preFixationCenterWidth;
        int _frameTimeLimit;
        Stopwatch FixationSW = new Stopwatch(), _frameWatch = new Stopwatch();
		public int[] RandForTaskLevel;
		int indexRandForTaskLevel = -1;
		//int trialCounter;
		public string pupilDataPath, eventDataPath;
		StringBuilder _dataTask = new StringBuilder(1000000), _eventData = new StringBuilder(1000000), temp = new StringBuilder(10000) ;
		MicroLibrary.MicroTimer microTimer;
		MicroLibrary.MicroStopwatch _eventMicSW = new MicroLibrary.MicroStopwatch();
		GazeTriple gz;
		StringBuilder _pupilStringBiulder = new StringBuilder(1000000);
        PortAccess _portAccess;

		public PsycophysicsRunner(bool getGaze, int operWidth, int operHeight, PsycophysicTasks RunningTask)
		{
			InitializeComponent();
			if (RunningTask.AllLevelProp.Count == 0)
			{
				return;
			}
			_task = RunningTask;
			_useGaz = getGaze;
			
			opFlagWidth = operWidth;
			opFlagHeight = operHeight;
			ScreenConfig();
			failSound.Load();
			winSound.Load();
            MakeRandomRepeat(RunningTask.SeqRandTaskRunner);
            if (RunningTask.runConf._useCOMPort || RunningTask.runConf._useParOut)
                _portAccess = new PortAccess(RunningTask.runConf);
        }

		public void ScreenConfig()
		{
			Screen[] screen = Screen.AllScreens;
			WindowState = FormWindowState.Maximized;
			Location = new Point(screen[BasConfigs._triableMonitor].Bounds.X, 0);
			flag = new Bitmap(screen[BasConfigs._triableMonitor].Bounds.Width, screen[BasConfigs._triableMonitor].Bounds.Height);
			if(opFlagWidth != 0)
			{
				opFlag = new Bitmap(opFlagWidth, opFlagHeight);
				opFlagGraphics = Graphics.FromImage(opFlag);
				
			}
		    
			_screenRationX = (float)opFlagWidth / (float)screen[BasConfigs._triableMonitor].Bounds.Width;
			_screenRatioY = (float)opFlagHeight / (float)screen[BasConfigs._triableMonitor].Bounds.Height;
			flagGraphics = Graphics.FromImage(flag);
			
		}

		void ShowFrame_Load(object sender, EventArgs e)
		{
			//if (_useGaz)
			//	opFlagGraphics = Graphics.FromImage(opFlag);
			
			
			_dataTask.Clear();
			_eventData.Clear();
			_dataTask.AppendLine(BasConfigs._monitor_resolution_x.ToString() + "," + BasConfigs._monitor_resolution_y);
			NextTrial();
			//MicroTimerEnable();

			Timer1.Enabled = true;
			Timer1.Start();
			//LoopWatch.Start();
			
			if (_useGaz)
			{
				RunnerUtils.GazeReady += OnRunnerGazeReady;
				RunnerUtils.StartGaze(true);
				_eventMicSW.Start();
				
			}
		}

        void Timer1_Tick(object sender, EventArgs e)
        {
            if (!(fixatehappened || fixateBreak || _frameWatch.ElapsedMilliseconds > _frameTimeLimit))
                return;
            Timer1.Stop();
            Timer1.Enabled = false;

            if (_task.Brake)
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
                        Debug.Write("true fixate falsed");
                        fixatehappened = false;
                        if (_task.AllLevelProp[level][frame].RewardType == 2 || _task.AllLevelProp[level][frame].RewardType == 4)
                            winSound.Play();

                        if (!NextFrame())
                            return;
                    }
                    else
                    {
                        if (_task.AllLevelProp[level][frame].RewardType == 3 || _task.AllLevelProp[level][frame].RewardType == 4)
                            failSound.Play();

                        if (!NextTrial())
                            return;

                    }
                }
            }

            #endregion
            Timer1.Start();
            Timer1.Enabled = true;
            //LoopWatch.Restart();


            return;
        }

		bool NextFrame()
		{
			frame++;
			Debug.Write("\n" + level.ToString() + " " + frame.ToString() + "\n");
			InROI = -1;
            sacInAppend = true;
			fixatehappened = false;
			fixateBreak = false;
			if (frame < framelimit)
			{
                Timer1.Interval = 15;
                _frameWatch.Reset();
                _frameTimeLimit = _task.AllLevelProp[level][frame].FrameTime;
                _frameFixates = null;
               
				if (_task.AllLevelProp[level][frame].Fixation.Count > 0)
				{
					containfixation = true;
                    _frameFixates = _task.AllLevelProp[level][frame].Fixation.ToArray();

                }
				else
					containfixation = false;

				AllocateFrame();
				GenFrameEvents();
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
			if (indexRandForTaskLevel > -1)
				if (_task.AllLevelProp[level][frame].events.trialEnd != -1)
				{
					if (_portAccess != null)
                        _portAccess.Write((short)_task.AllLevelProp[level][frame].events.trialEnd);
					AppendEventData("TEnd", _task.AllLevelProp[level][frame].events.trialEnd.ToString());
				}
			indexRandForTaskLevel++;
			if (indexRandForTaskLevel == RandForTaskLevel.Length)
			{
				_userClosed = false;
				StopRun(true);
				return false;
			}
			level = RandForTaskLevel[indexRandForTaskLevel];
			
			frame = -1;
			
			framelimit = _task.AllLevelProp[level].Count;
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
				//	TaskOperator.gzX = (float)100;
				//	TaskOperator.gzY = (float)100;
				//}
				else
					return;

			}

		}

		void OnRunnerGazeReady(object sender,  GazeTriple gz)
		{
			if (_useGaz)
			{
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
				//	TaskOperator.gzX = (float)100;
				//	TaskOperator.gzY = (float)100;
				//}
				else
					return;

			}

		}

		void GenFrameEvents()
		{
			if (indexRandForTaskLevel < RandForTaskLevel.Length)
			{
				if (_task.AllLevelProp[level][frame].events.trialStart != -1)
				{
					if (_portAccess != null)
						_portAccess.Write((short)_task.AllLevelProp[level][frame].events.trialStart);
					AppendEventData("TStart", _task.AllLevelProp[level][frame].events.trialStart.ToString());
				}
				if (_task.AllLevelProp[level][frame].events.condition != -1)
				{
					if (_portAccess != null)
                        _portAccess.Write((short)_task.AllLevelProp[level][frame].events.condition);
					AppendEventData("Cond", _task.AllLevelProp[level][frame].events.condition.ToString());
				}
				
				if (_task.AllLevelProp[level][frame].events.fixOn != -1)
				{
					if (_portAccess != null)
                        _portAccess.Write((short) _task.AllLevelProp[level][frame].events.fixOn);
					AppendEventData("FixOn", _task.AllLevelProp[level][frame].events.fixOn.ToString());
				}
				if (_task.AllLevelProp[level][frame].events.fixOff != -1)
				{
					if (_portAccess != null)
                        _portAccess.Write((short)_task.AllLevelProp[level][frame].events.fixOff);
					AppendEventData("FixOff", _task.AllLevelProp[level][frame].events.fixOff.ToString());
				}
				if (_task.AllLevelProp[level][frame].events.stimOn != -1)
				{
					if (_portAccess != null)
                        _portAccess.Write((short)_task.AllLevelProp[level][frame].events.stimOn);
					AppendEventData("StimOn", _task.AllLevelProp[level][frame].events.stimOn.ToString());
				}
				if (_task.AllLevelProp[level][frame].events.stimOff != -1)
				{
					if (_portAccess != null)
                        _portAccess.Write((short)_task.AllLevelProp[level][frame].events.stimOff);
					AppendEventData("StimOff", _task.AllLevelProp[level][frame].events.stimOff.ToString());
				}
				
				if (_task.AllLevelProp[level][frame].events.abortFixWindow != -1)
					AFW = true;
				else
					AFW = false;
				
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
				flagGraphics.Clear(_task.AllLevelProp[level][frame].BGColor);
                if (opFlagWidth != 0)
                    opFlagGraphics.Clear(_task.AllLevelProp[level][frame].BGColor);
				numberstimulus = _task.AllLevelProp[level][frame].Stimulus.Length;

				#region add stimulus and fixation

				for (int k = 0; k < numberstimulus; k++)
				{
					stimulus = _task.AllLevelProp[level][frame].Stimulus[k];
					//Use Solid Brush for filling the graphic shapes
					sb = new SolidBrush(Color.FromArgb(stimulus.Contrast, stimulus.ColorPt));

					if (stimulus.Type == 1)
					{
						flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, _screenRatioY * (stimulus.Yloc - stimulus.Width / 2), stimulus.Width, stimulus.Width);
						if (opFlagWidth != 0)
							opFlagGraphics.FillRectangle(sb, _screenRationX * (stimulus.Xloc - stimulus.Width / 2), _screenRatioY * (stimulus.Yloc - stimulus.Width / 2), _screenRationX * stimulus.Width, _screenRatioY * stimulus.Width);
					}

					if (stimulus.Type == 2)
					{
						flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
						if (opFlagWidth != 0)
							opFlagGraphics.FillRectangle(sb, _screenRationX * (stimulus.Xloc - stimulus.Width / 2), _screenRatioY * (stimulus.Yloc - stimulus.Width / 2), _screenRationX * stimulus.Width, _screenRatioY * stimulus.Width);

					}

					if (stimulus.Type == 3)
					{
						flagGraphics.FillEllipse(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
						if (opFlagWidth != 0)
							opFlagGraphics.FillEllipse(sb, _screenRationX * (stimulus.Xloc - stimulus.Width / 2), _screenRatioY * (stimulus.Yloc - stimulus.Width / 2), _screenRationX * stimulus.Width, _screenRatioY * stimulus.Width);

					}

					if (stimulus.Type == 4)
					{
						if (File.Exists(stimulus.PathPic))
						{
							bmpvar = new Bitmap(stimulus.PathPic);
							bmpvar = new Bitmap(bmpvar, new Size(stimulus.Width, stimulus.Height));
							flagGraphics.DrawImage(bmpvar, new Point(stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2));
							if (opFlagWidth != 0)
							{
								bmpvarOp = new Bitmap(bmpvar, new Size((int)_screenRationX * stimulus.Width, (int)(_screenRatioY * stimulus.Height)));
								opFlagGraphics.DrawImage(bmpvarOp, new Point(stimulus.Xloc - stimulus.Width / 2, (int)_screenRatioY * (stimulus.Yloc - stimulus.Width / 2)));
								bmpvarOp.Dispose();
							}
						}

						bmpvar.Dispose();
					}

				}
				//flagGraphics.Flush();

				if (containfixation && opFlagGraphics != null)
				{

                    #region add fixation
                    //opFlag = BitmapManager.DrawOn(flag, new Size(opFlagWidth, opFlagHeight), Color.White);
                    for (int fixC = 0; fixC < _frameFixates.Length; fixC++)
                    {
                        //Use Solid Brush for filling the graphic shapes
                        fixationp = new Pen(_frameFixates[fixC].ColorPt);
                                             
                        opFlagGraphics.DrawEllipse(fixationp, _screenRationX * (_frameFixates[fixC].Xloc - _frameFixates[fixC].Width / 2), _screenRatioY * (_frameFixates[fixC].Yloc - _frameFixates[fixC].Width / 2), _frameFixates[fixC].Width * _screenRationX, _frameFixates[fixC].Width * _screenRatioY);
                            
                    }
                    #endregion
                    opFlagGraphics.Flush();
                }
				#endregion
				

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
			{
				RunnerUtils.EndGaze();
				_eventMicSW.Reset();
				SaveData();
				
			}
			if (microTimer != null)
			{
				microTimer.Enabled = false;
				microTimer.Stop();
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

            if (!containfixation  || fixatehappened || fixateBreak)
                return;

            double dist1, dist2;
            
            if (sacInAppend && _task.AllLevelProp[level][frame].events.saccadInit != -1)
            {
                
                dist2 = (Point[0] - preFixationCenterX) * (Point[0] - preFixationCenterX) + (Point[1] - preFixationCenterY) * (Point[1] - preFixationCenterY);
                if (dist2 > preFixationCenterWidth * preFixationCenterWidth)
                {
                    if (_portAccess != null)
                        _portAccess.Write((short)_task.AllLevelProp[level][frame].events.saccadInit);
                    sacInAppend = false;
                    AppendEventData("SacIn", _task.AllLevelProp[level][frame].events.saccadInit.ToString());
                }
            }
            int selFix = -1;
            for (int fixIter = 0; fixIter < _frameFixates.Length; fixIter++)
            {
                dist1 = (Point[0] - _frameFixates[fixIter].Xloc) * (Point[0] - _frameFixates[fixIter].Xloc) + (Point[1] - _frameFixates[fixIter].Yloc) * (Point[1] - _frameFixates[fixIter].Yloc);
                //Debug.Write("d2" + dist1.ToString() + "\n");

                #region check dist fixate
                if (dist1 < _frameFixates[fixIter].Width * _frameFixates[fixIter].Width)
                {
                    //Debug.Write("in : d1 " + dist1.ToString() + "\n");
                    selFix = fixIter;
                }
            }
            if (selFix > -1) // check the fixation selected............................
            {
                if (InROI == -1)
                {
                    InROI = selFix;
                    FixationSW.Reset();
                    FixationSW.Start();
                    if (_task.AllLevelProp[level][frame].Fixation[selFix].ETW > -1)
                    {
                        if (_portAccess != null)
                            _portAccess.Write((short)_task.AllLevelProp[level][frame].Fixation[selFix].ETW);
                        AppendEventData("ETW" + selFix.ToString(), _task.AllLevelProp[level][frame].Fixation[selFix].ETW.ToString());
                    }
                    if (_task.AllLevelProp[level][frame].Fixation[selFix].EFW > -1)
                    {
                        if (_portAccess != null)
                            _portAccess.Write((short)_task.AllLevelProp[level][frame].Fixation[selFix].EFW);
                        AppendEventData("EFW" + selFix.ToString(), _task.AllLevelProp[level][frame].Fixation[selFix].EFW.ToString());
                    }
                }
                else
                {
                    //Debug.Write("ROI true" + FixationSW.ElapsedMilliseconds.ToString() + "  " + FixationCenterTime + " " + dist1.ToString() + "\n");
                    if (InROI == selFix)
                    {
                        if (FixationSW.ElapsedMilliseconds >= _task.AllLevelProp[level][frame].Fixation[selFix].Time)
                        {
                            //Debug.Write("hold " + level.ToString() + " " + frame.ToString() + "\n");
                            if (_task.AllLevelProp[level][frame].events.saccadLand > -1)
                            {
                                if (_portAccess != null)
                                    _portAccess.Write((short)_task.AllLevelProp[level][frame].events.saccadLand);
                                AppendEventData("SacLan", _task.AllLevelProp[level][frame].events.saccadLand.ToString());
                            }
                            if (_task.AllLevelProp[level][frame].Fixation[selFix].CorrectEventCode > -1)
                            {
                                if (_portAccess != null)
                                    _portAccess.Write((short)_task.AllLevelProp[level][frame].Fixation[selFix].CorrectEventCode);
                                AppendEventData("Correct" + selFix.ToString(), _task.AllLevelProp[level][frame].Fixation[selFix].CorrectEventCode.ToString());
                            }
                            if (_task.AllLevelProp[level][frame].Fixation[selFix].INcorrectEventCode > -1)
                            {
                                if (_portAccess != null)
                                    _portAccess.Write((short)_task.AllLevelProp[level][frame].Fixation[selFix].INcorrectEventCode);
                                AppendEventData("Incorrect" + selFix.ToString(), _task.AllLevelProp[level][frame].Fixation[selFix].INcorrectEventCode.ToString());
                            }
                            preFixationCenterWidth = _task.AllLevelProp[level][frame].Fixation[selFix].Width;
                            preFixationCenterX = _task.AllLevelProp[level][frame].Fixation[selFix].Xloc;
                            preFixationCenterY = _task.AllLevelProp[level][frame].Fixation[selFix].Yloc;
                            fixateBreak = false;
                            FixationSW.Reset();
                            fixatehappened = true;
                             
                            
                            return;
                        }
                    }
                    else
                    {
                       
                        if (AFW)
                        {
                            if (_portAccess != null)
                                _portAccess.Write((short)_task.AllLevelProp[level][frame].events.abortFixWindow);
                            AppendEventData("AFW", _task.AllLevelProp[level][frame].events.abortFixWindow.ToString());
                        }
                        InROI = -1;
                        fixatehappened = false;
                        fixateBreak = true;
                       
                    }

                }
            }

            #endregion
            #region else check fixate
            else
            {
                //Debug.Write("out : d1 " + FixationSW.ElapsedMilliseconds + " " + FixationCenterTime + " " + dist1.ToString() + "\n");
                if (InROI > -1 && FixationSW.ElapsedMilliseconds < _task.AllLevelProp[level][frame].Fixation[selFix].Time)
                {
                    if (AFW)
                    {
                        if (_portAccess != null)
                            _portAccess.Write((short)_task.AllLevelProp[level][frame].events.abortFixWindow);
                        AppendEventData("AFW", _task.AllLevelProp[level][frame].events.abortFixWindow.ToString());
                    }
                    InROI = -1;
                    fixatehappened = false;
                    FixationSW.Reset();
                    fixateBreak = true;
                                     
                    return;
                }


            }
            #endregion

        }

		void ShowFrame_KeyDown(object sender, KeyEventArgs e)
		{
			if (!e.Handled)
				if (e.KeyCode == Keys.Escape)
				{
					StopRun(true);
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
			for (int i = 0; i < _task.NumerRepeat.Count; i++)
			{
				totalRepeat += _task.NumerRepeat[i];
			}
			RandForTaskLevel = new int[totalRepeat];
			int index = 0;
			for (int i = 0; i < _task.NumerRepeat.Count; i++)
			{
				for (int j = 0; j < _task.NumerRepeat[i]; j++)
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
