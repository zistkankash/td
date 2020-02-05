using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Basics;
using TaskDesigner;
using CefSharp;
using CefSharp.WinForms;
using System.Collections.Generic;

namespace TaskRunning
{
	
	/// <summary>
	///  This class designed and implemented by Mh.T to run 2 type tasks 1-linguistic, 2-psycology tasks.
	///	first call TaskOperator to load a task and create output csv file, then operator can start running the task using TaskRunner.
	///	Operator form has a picturebox to show tracked eye position.
	///	arguments: 
	/// </summary>
	public partial class TaskRunner : Form
	{
        SoundPlayer winSound = new SoundPlayer(Resource.Computer_Error);
		SoundPlayer failSound = new SoundPlayer(Resource.fail);
		#region General Runner Data Scope  
		bool doGaze = false;
		bool brake = false;
		bool _startTask = false;
		Screen[] screens;
		TaskType _type;
		Size secondMonit;
		RunConfig _runnerConfig;
		public RunMod runMod = RunMod.Stop;
		bool _getGaz = false;
		static bool _mouseClicked = false;

		MediaTask _mediaTask;
		PsycologyTask _psycoTask;
		Stopwatch tskWatch;
		int _timeLimit;
		Thread runnerThread;
		TaskOperator tsop;
		Bitmap _runnerBitmap;
		ChromiumWebBrowser _controlWebBrowser;
		ScreenRecorder.Recorder rec;
        PortAccess _portAccess;
		#endregion
		
		#region Lab Runner Data Scope
		int[] strt;
		int _curHeatedNode, _curHeatedGoal, _succededNodeInGroup, _selectedGroup;
		List<int> _labNodeHeats = new List<int>(), _labNodeNearHeats = new List<int>();
		List<LabRunnerNodeMetaData> _labBuffer = new List<LabRunnerNodeMetaData>();
		List<int> _goals = new List<int>();
        int _nearMiseThresh = 5;
        int _misesThresh = 10;
        bool callAllow;
        List<LabRunnerNodeMetaData> toDeleteBuffer = new List<LabRunnerNodeMetaData>(50);
		#endregion
		
		public TaskRunner(object cs,TaskType Type ,TaskOperator pr, bool getGaz)
		{
			InitializeComponent();
			tsop = pr;
			_getGaz = getGaz;
			runMod = RunMod.Stop;
			_type = Type;
           

            if (Type == TaskType.lab)
			{
				_psycoTask = (PsycologyTask)cs;
				_runnerConfig = _psycoTask.runConf;
               
			}

			if (Type == TaskType.media)
			{
				_mediaTask = (MediaTask)cs;
				_runnerConfig = _mediaTask.runConf;
				
				InitBrowser();
                
            }
			InitForm();

            if (_runnerConfig._useCOMPort || _runnerConfig._useParOut)
                _portAccess = new PortAccess(_runnerConfig);
        }
		
		void InitBrowser()
		{
			CefSettings seting = new CefSettings();
			if (!Cef.IsInitialized)
				Cef.Initialize(seting);
			_controlWebBrowser = new ChromiumWebBrowser("www.toosbioresearch.com");
			
			Controls.Add(_controlWebBrowser);
			_controlWebBrowser.LoadingStateChanged += _controlWebBrowser_LoadingStateChanged;
			_controlWebBrowser.LoadError += _controlWebBrowser_LoadError;
			_controlWebBrowser.ActivateBrowserOnCreation = true;
			_controlWebBrowser.Dock = DockStyle.Fill;
			
		}
		
		private void _controlWebBrowser_LoadError(object sender, LoadErrorEventArgs e)
		{
			if(!_startTask)
			{
				_startTask = true;
				RunTask();
			}
		}

		private void _controlWebBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
		{
			if (!_startTask)
			{
				_startTask = true;
				RunTask();
			}

		}

		void InitForm()
		{
			screens = Screen.AllScreens;
			WindowState = FormWindowState.Maximized;
			FormBorderStyle = FormBorderStyle.None;
			StartPosition = FormStartPosition.Manual;
			pctbxFrm.SizeMode = PictureBoxSizeMode.StretchImage;
			LocateForm();
			
			//adding chromium browser to form

		}
			
		void LocateForm()
		{
			Location = new Point(screens[BasConfigs._triableMonitor].Bounds.X, 0);
			//pctbxFrm.Image.Dispose();
			_runnerBitmap = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
			BringToFront();
		}	

		/// <summary>
		/// This methode perform initializations for running current task.
		/// for example set starting goal node.
		/// </summary>
		/// <param name="tsktyp"></param>
		/// <returns></returns>
		void InitRunningTask()
		{
			tskWatch = new Stopwatch(); //Get a watch for timing operations.
			secondMonit = new Size(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
			if (_getGaz)
			{
				if (_type == TaskType.media)
					RunnerUtils.GazeReady += GetMediaGaze;
				if (_type == TaskType.lab)
					RunnerUtils.GazeReady += GetLabGaze;

				RunnerUtils.StartGaze(true);
			}
			else
				if (_runnerConfig.useCursor)
					Cursor.Position = new Point(BasConfigs._monitor_resolution_x + BasConfigs._monitor_resolution_x / 2, BasConfigs._monitor_resolution_y / 2);

			#region psycology init running task
			if (_type == TaskType.lab)
			{
                //vlcControl1.Visible = false;
                //_controlWebBrowser.Visible = false;
                
                Invoke((Action)delegate { LocateForm(); pctbxFrm.BringToFront(); });
                //clearing data
                _goals.Clear();
				_labNodeHeats.Clear();
				_labNodeNearHeats.Clear();
				_succededNodeInGroup = -1;
				_curHeatedNode = -1;
				_selectedGroup = -1;
				_curHeatedGoal = -1;

                if (_runnerConfig._useGoalSound)
                    winSound.Load();
                if (_runnerConfig._useMissesSound)
                    failSound.Load();
                Invoke((Action)delegate {
                    frameUpdater.Enabled = true;
                    frameUpdater.Start();
                });
                
				if (_runnerConfig.useCursor && !_getGaz)
				{
                    Invoke((Action)delegate { pctbxFrm.MouseMove += pctbxFrm_MouseMoveforLab; });
				}

                CTTaskSelectStartGoal();
                				
				return;
			}
			#endregion
			#region media init run
			if (_type == TaskType.media)
			{
				_mediaTask.showedIndex = 0;
				Invoke((Action)delegate { LocateForm(); SetNextMediaSlide(); tsop.SetNextSlide(); });

				if (_runnerConfig.useCursor && !_getGaz)
				{
					pctbxFrm.MouseMove += pctbxFrm_MouseMoveforMedia;

				}
				while (_mediaTask.showedIndex < _mediaTask.PicList.Count)
				{
					if (runMod == RunMod.Stop)
						return;
					//If gaze was enabled use gaze values to save in file and update pointer in operator in the gaze event.
					//Else if pointer was enabled add the pointer position in file.
					
					
					//Check status to go to next slide...
					if ((_mediaTask.runConf.useCursorNextFrm && _mouseClicked && tskWatch.ElapsedMilliseconds > _timeLimit * 0.1) || tskWatch.ElapsedMilliseconds > _timeLimit || brake)
					{
						doGaze = false;
						_mouseClicked = false;
						_mediaTask.showedIndex++;
						Invoke((Action)delegate { tsop.SetNextSlide(); });
						if (_mediaTask.showedIndex == _mediaTask.PicList.Count)
							break;
						Invoke((Action)delegate { SetNextMediaSlide();  });						
					}
				}
				StopTask();
				
				return;
			}
			#endregion

		}

        void CTTaskSelectStartGoal()
        {
            strt = _psycoTask.FindGroupedShapes();
            _goals.AddRange(strt);
            if (_runnerConfig._showGoalPrompt)
                _psycoTask.DrawNodePrompt(30, strt, Color.Yellow, false);
        }

        bool SetNextMediaSlide()
		{
			brake = false;
			pctbxFrm.Visible = false;
			vlcControl1.Visible = false;
			_controlWebBrowser.Visible = false;
			MediaEelement pic = null;
			if (rec != null)
			{
				rec.Dispose();
				rec = null;
			}
			if (vlcControl1.IsPlaying)
				vlcControl1.Stop();
			if (_mediaTask.showedIndex >= _mediaTask.PicList.Count)
				return false;
			pic = _mediaTask.PicList[_mediaTask.showedIndex];
			if (pic.MediaTaskType == MediaType.Video)
			{
				vlcControl1.Visible = true;
				vlcControl1.Play(new FileInfo(pic.Address));
				vlcControl1.Playing += VlcControl1_Playing;
				vlcControl1.EndReached += VlcControl1_EndReached;	
				
			}
			else
			{
				if (pic.MediaTaskType == MediaType.Image || pic.MediaTaskType == MediaType.Empty)
				{
					pctbxFrm.Visible = true;
					RunnerUtils.MediaPictureRenderer(pic.BGColor, pic.Image, pic.UseTransparency, pic.TransColor, false, ref _runnerBitmap);
					pctbxFrm.Image = _runnerBitmap;
                    if (_portAccess != null)
                        _portAccess.Write(255);
					doGaze = true;	
				}
				else
				{
					rec = new ScreenRecorder.Recorder(new ScreenRecorder.RecorderParams(Path.GetDirectoryName(tsop.txtSavPath.Text) + "\\web" + _mediaTask.showedIndex.ToString() + ".avi", 10, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 50));
					_controlWebBrowser.Visible = true;
					_controlWebBrowser.Load(pic.URL);
                    if (_portAccess != null)
                        _portAccess.Write(255);
                    doGaze = true;
				}
				tskWatch.Restart();
			}
			_timeLimit = pic.Time;
			
			return true;
		}

		void VlcControl1_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
		{
            if (_portAccess != null)
                _portAccess.Write(255);
            doGaze = true;
			tskWatch.Restart();
		}

		void VlcControl1_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
		{
			brake = true;
		}

		void GetMediaGaze(object sender, GazeTriple gzTemp)
		{
			if (doGaze)
				if (gzTemp != null)
				{
					TaskOperator.savedData += gzTemp.x.ToString() + "," + gzTemp.y.ToString() + "," + gzTemp.pupilSize.ToString() + "," + gzTemp.time.ToString() + "\n";
					TaskOperator.gzX = (float)gzTemp.x;
					TaskOperator.gzY = (float)gzTemp.y;
					return;
				}
			
		}
		
		void GetLabGaze(object sender, GazeTriple gzTemp)
		{
			TaskOperator.savedData += gzTemp.x.ToString() + "," + gzTemp.y.ToString() + "," + gzTemp.pupilSize.ToString() + "," + gzTemp.time.ToString() + "\n";
			TaskOperator.gzX = (float)gzTemp.x;
			TaskOperator.gzY = (float)gzTemp.y;

			LabTaskRunnerCore((int)gzTemp.x, (int)gzTemp.y);

			return;
		}
		
		void LabTaskRunnerCore(int x, int y)
		{
            callAllow = true;   
			//Find nodes that match current gaze in its border.
			List<int> ht = _psycoTask.findNode(x, y, 2);

			for (int i = 0; i < _labBuffer.Count; i++)
			{
				int ind = ht.FindIndex(a => a == _labBuffer[i].nodeId);
				if (ind > -1)
				{
					_labBuffer[i].level++;
					_labBuffer[i].outness = 0;
					ht.RemoveAt(ind);
				}
				else
					_labBuffer[i].outness++;
			}
			for (int k = 0; k < ht.Count; k++)
			{
				_labBuffer.Add(new LabRunnerNodeMetaData(ht[k]));
			}
            toDeleteBuffer.Clear();
			//Remove node with outness larger than threshold from buffer and sync buffer with heata and near_heats.
			foreach (LabRunnerNodeMetaData ln in _labBuffer)
				if (ln.outness > 5)
				{
                    toDeleteBuffer.Add(ln);
					if (_labNodeNearHeats.Contains(ln.nodeId))
						_labNodeNearHeats.Remove(ln.nodeId);

					if (_labNodeHeats.Contains(ln.nodeId))
						_labNodeHeats.Remove(ln.nodeId);

					//_labBuffer.Remove(ln);
				}
            foreach (LabRunnerNodeMetaData delNode in toDeleteBuffer)
                _labBuffer.Remove(delNode);

			//Add nodes with level larger than Near_Heat threshold to near_heat buffer.
			foreach (LabRunnerNodeMetaData ln in _labBuffer)
			{
				//A node is near_heated...
				if (ln.level > _nearMiseThresh)
				{
                    if (!_goals.Contains(ln.nodeId))
                        _psycoTask.shapeList[ln.nodeId].NearHeatCountforNode++;

                    if (!_labNodeNearHeats.Contains(ln.nodeId))
					{
                        _labNodeNearHeats.Add(ln.nodeId);

                        if (!_goals.Contains(ln.nodeId))
                        {
                            if (_runnerConfig._showNearMisPrompt)
                                _psycoTask.DrawNodePrompt(30, new int[] { ln.nodeId }, Color.Orange, false);

                            if (_runnerConfig._showGoalPrompt)
                                _psycoTask.DrawNodePrompt(30, _goals.ToArray(), Color.Yellow, false);

                            if (_runnerConfig._nmsShowArrowToGoal)
                                _psycoTask.DrawBlinkArrow(20, new int[1] { ln.nodeId }, _goals.ToArray(), Color.Black, false, 1);
                        }
                    }
				}
                //A node heated...
                if (ln.level > _misesThresh)
                {
                    if (!_goals.Contains(ln.nodeId))
                        _psycoTask.shapeList[ln.nodeId].HeatCountforNode++;

                    if (!_labNodeHeats.Contains(ln.nodeId))
                    {
                        _labNodeHeats.Add(ln.nodeId);
                        _curHeatedNode = ln.nodeId;
                        //wrong node heated so it appointed as misses node
                        if (!_goals.Contains(ln.nodeId))
                        {
                            if (_runnerConfig._showMisPromp)
                                _psycoTask.DrawNodePrompt(30, new int[1] { ln.nodeId }, Color.Red, false);

                            if (_runnerConfig._useMissesSound)
                                failSound.Play();

                            if (_runnerConfig.taskRunMode == TaskRunMod.recursive)
                            {
                                _goals.Clear();
                                _goals.AddRange(strt);
                                _succededNodeInGroup = -1;
                                _curHeatedGoal = -1;
                                _selectedGroup = -1;
                            }
                            if (_runnerConfig.taskRunMode == TaskRunMod.forward)
                                if (_curHeatedGoal > -1 && _runnerConfig._hintArrow)
                                {
                                    _psycoTask.DrawBlinkArrow(20, new int[] { _curHeatedGoal }, _goals.ToArray(), Color.Black, false, 2);
                                }
                        }
                        else
                        {
                            if (_selectedGroup == -1)
                            {
                                _selectedGroup = _psycoTask.NodeGroupIdetifier[ln.nodeId];
                                _curHeatedGoal = 1;
                            }
                            _psycoTask.DrawNodePrompt(30, new int[] { ln.nodeId }, Color.Green, false);
                            if (_runnerConfig._useGoalSound)
                                winSound.Play();
                            _goals.Clear();
                            if (_curHeatedGoal < _psycoTask.groupMembers[_selectedGroup].Count)
                            {
                                _goals.Add(_psycoTask.groupMembers[_selectedGroup][_curHeatedGoal]);
                                if (_runnerConfig._showGoalPrompt)
                                {
                                    _psycoTask.DrawNodePrompt(30, _goals.ToArray(), Color.Yellow, false);

                                }
                            }
                            else
                            {
                                runMod = RunMod.Stop;
                                return;
                            }
                        }
                    }
                }
            }
            callAllow = false;
		}
		
		void pctbxFrm_MouseMoveforLab(object sender, MouseEventArgs e)
		{
            if (!callAllow)
                LabTaskRunnerCore(e.X, e.Y);
		}

		void pctbxFrm_MouseMoveforMedia(object sender, MouseEventArgs e)
		{
			GetMediaCursor(e.X, e.Y);
		}

		void GetMediaCursor(int _mousX, int _mousY)
		{
			TaskOperator.savedData += _mousX.ToString() + "," + _mousY.ToString() + "," + 0.ToString() + "," + tskWatch.ElapsedMilliseconds.ToString() + "\n";
			TaskOperator.gzX = (float)_mousX;
			TaskOperator.gzY = (float)_mousY;
		}
        
		/// <summary>
		/// Update triable screen by task image every 30 miliseconds.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void frameUpdater_Tick(object sender, EventArgs e)
		{
			if (runMod == RunMod.Stop)
			{
				frameUpdater.Stop();
				frameUpdater.Enabled = false;
				return;
			}
			if (_psycoTask != null)
				pctbxFrm.Image = _psycoTask.RenderTask();
		}
		
		public bool RunTask()
		{
			if (runMod == RunMod.Running)       // هنگام اجرای برنامه
			{
				return false;
			}
			runMod = RunMod.Running;
			
			runnerThread = new Thread(new ThreadStart(InitRunningTask));
			runnerThread.Start();

			return true;

		}

		/// <summary>
		/// Call this methode to Stop Running Task in Task Runner
		/// </summary>
		/// <returns></returns>
		public bool StopTask()
		{
			try
			{
				CleanMap();
				if (runMod == RunMod.Stop)       // هنگام اجرای برنامه
				{
					return true;
				}
				if (_getGaz)
				{
					RunnerUtils.EndGaze();
				}
				if (rec != null)
				{
					rec.Dispose();
					rec = null;
				}
				if (vlcControl1.IsPlaying)
					vlcControl1.Stop();

				if(_mediaTask != null)
				{
					if (_mediaTask.runConf.useCursor)
					{
						pctbxFrm.MouseMove -= pctbxFrm_MouseMoveforMedia;

					}
				}
				runMod = RunMod.Stop;
				Invoke((Action)delegate { Close(); });
				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}
		
		void TaskRunner_Load(object sender, EventArgs e)
		{
			pctbxFrm.BackColor = Color.White;
            if (_type == TaskType.lab)
                RunTask();
		}

		public void CleanMap()
		{
			Bitmap img = RunnerUtils.PutString("اتمام تسک",new Point(pctbxFrm.Width / 4, pctbxFrm.Height / 2));
			pctbxFrm.Image = img;
		}

		void TaskRunner_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}
		
		void pctbxFrm_Click(object sender, EventArgs e)
		{
			_mouseClicked = true;
		}
	}
	
	class LabRunnerNodeMetaData
	{
		public int outness; public int nodeId; public int level;
		public LabRunnerNodeMetaData(int Id)
		{
			nodeId = Id; outness = 0; level = 0;
		}
	}
}
