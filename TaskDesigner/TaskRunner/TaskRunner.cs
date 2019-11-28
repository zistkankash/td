using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using TaskLab;
using System.Threading;
using Emgu.CV.Structure;
using Emgu.CV;
using System.IO;
using Psychophysics;
using System.Drawing.Imaging;
using System.Diagnostics;
using Basics;

namespace TaskRunning
{

	/// <summary>
	///  This class designed and implemented by Mh.T to run all task types.
	///	first call TaskOperator to load a task and create output csv file, then operator can start running the task using TaskRunner.
	///	Operator form has a picturebox to show tracked eye position.
	///	arguments: 
	/// </summary>
	public partial class TaskRunner : Form
	{
		SoundPlayer winSound;
		SoundPlayer failSound;

		bool silentMode = false;
		bool brake = false;
		Screen[] screens;
		public static TaskClient curTsk;
		Stopwatch tskWatch;
		Thread runnerThread;
		TaskOperator tsop;
		int showedIndex;
		//FNode goalNodeThrd, goalNodePrevius;
		//FNode goalNode = new FNode(100, new Point(0, 0), 100, -100);
		
		public Size secondMonit = new Size(0,0);
		RunMod runMod = RunMod.stop;
		
		string savedStr = "";
		bool _getGaz = false;
		static bool _mouseClicked = false;
		static int _mousX, _mousY;
					
		public TaskRunner(TaskClient cs,TaskOperator pr)
		{
			InitializeComponent();
			tsop = pr;
			curTsk = cs;
			InitForm();
		}
		
		public TaskRunner(TaskClient cs)
		{
			InitializeComponent();
			silentMode = true;
			curTsk = cs;
			InitForm();
		}

		private void InitForm()
		{
			FormBorderStyle = FormBorderStyle.None;
			StartPosition = FormStartPosition.Manual;
            pctbxFrm.SizeMode = PictureBoxSizeMode.StretchImage;
            screens = Screen.AllScreens;
			if (screens.Length == 2)
			{
				// for fullscreen
				WindowState = FormWindowState.Maximized;
				this.Location = new Point(screens[1].Bounds.X, screens[1].Bounds.Y);
				pctbxFrm.Size = new Size(screens[1].Bounds.Width, screens[1].Bounds.Height);
				
			}
			else
			{
				if (screens.Length == 1)
				{
                    if (!silentMode)
                        MessageBox.Show("Can not find second screen. Using primary screen.", "Task Runner");
                    WindowState = FormWindowState.Normal;
                }
			}
			
		}
				
		/// <summary>
		/// This methode perform initializations for running current task.
		/// for example set starting goal node.
		/// </summary>
		/// <param name="tsktyp"></param>
		/// <returns></returns>
		private void InitRunningTask()
		{
			if (!curTsk.IsReady)// Check to see if curTsk not inited correctly return.
				return;
			tskWatch = new Stopwatch(); //Get a watch for timing operations.
			if (_getGaz)
			{
				RunnerUtils.StartGaze();
			}
			else
				Cursor.Position = new Point(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);

			#region lab tasks
			if (curTsk.Type == TaskType.lab)
			{

				if(curTsk.runConf.taskRunMode == TaskRunMod.recursive)
				{
					CTTaskSelectStartGoal();

				}
				else
				{
					//SetGoalNode();
				}


				return;
			}
			#endregion
			if (curTsk.Type == TaskType.media)
			{
				showedIndex = 0;
				Invoke((Action)delegate { tsop.SetNextSlide(showedIndex); });
				tskWatch.Start();
				frameUpdater.Start();
				
				while (showedIndex < curTsk.MediaTask.picList.Count)
				{
					//If gaze was enabled use gaze values to save in file and update pointer in operator.
					if (_getGaz)
					{
						//Check gaze validity and add it to the end of csv file.
						GetPictureGaze(false);
						//else
						//	continue;
					}
					//Else if pointer was enabled add the pointer position in file.
					else
					{
						GetPictureGaze(curTsk.runConf.useCursor);
						
					}
					
					//Check status to go to next slide...
					if ((curTsk.runConf.useCursorNextFrm && _mouseClicked && tskWatch.ElapsedMilliseconds > curTsk.MediaTask.picList[showedIndex].time * 0.2) || tskWatch.ElapsedMilliseconds > curTsk.MediaTask.picList[showedIndex].time)
					{
						_mouseClicked = false;
						showedIndex++;
						Invoke((Action)delegate { tsop.SetNextSlide(showedIndex); });
						tskWatch.Restart();
					}
				}
				StopTask();
				
				return;
			}

			if(curTsk.Type == TaskType.cognitive)
			{
				return;
			}
			return;
		}
		
		private bool GetPictureGaze(bool useCursor)
		{
			GazeTriple gzTemp;
			if (useCursor)
			{
				TaskOperator.savedData += _mousX.ToString() + "," + _mousY.ToString() + "," + 0.ToString() + "," + tskWatch.ElapsedMilliseconds.ToString() + "," + showedIndex.ToString() + "\n";
				TaskOperator.gzX = (float)_mousX;
				TaskOperator.gzY = (float)_mousY;
				return true;
			}
			if (!_getGaz)
				return false;
			gzTemp = BasConfigs.server.getGaze;
			if (gzTemp.time != -1)
			{
				TaskOperator.savedData += gzTemp.x.ToString() + "," + gzTemp.y.ToString() + "," + gzTemp.pupilSize.ToString() + "," + gzTemp.time.ToString() + "," + showedIndex.ToString() + "\n";
				TaskOperator.gzX = (float)gzTemp.x;
				TaskOperator.gzY = (float)gzTemp.y;
				return true;
			}
			else
				return false;
		}

		public static bool SetCurrentFixate()
		{ //for lab tasks
			//int min = 1000;
			//int index = -1;
			//foreach (Node n in fixationList)
			//{
			//	if (n.enable == true)
			//	{
			//		if (n.priority < min)
			//		{
			//			isCondition = true;
			//			min = n.priority;
			//			currentFNode.pos = n.pos;
			//			currentFNode.time = n.fixationTime;
			//			currentFNode.sound = true;
			//			currentFNode.count = n.fixationTime / 8;
			//			currentFNode.radius = n.width;
			//			index = fixationList.IndexOf(n);
			//		}
			//	}
			//}
			//if (oldFNode.pos.X != -1)
			//{
			//	Image<Rgb, byte> im = new Image<Rgb, byte>(userMap);
			//	int r, g, b;
			//	r = btnArrowColor.BackColor.R;
			//	g = btnArrowColor.BackColor.G;
			//	b = btnArrowColor.BackColor.B;
			//	CvInvoke.ArrowedLine(im, oldFNode.pos, currentFNode.pos, new MCvScalar(r, g, b), 2);
			//	userMap = im.ToBitmap();
			//	frame.DrawPic(userMap);
			//	SetImage();
			//}
			//if (currentFNode.pos.X != -1)
			//{
			//	oldFNode.pos = currentFNode.pos;
			//}
			//if (index != -1)
			//{
			//	fixationList[index].enable = false;
			//}
			//else if (index == -1 && isCondition == true)
			//{
			//	StartStop();
			//}
			//if (min != 1000)
			//	return true;
			//else
			return false;
		}
		
		private void NormalLabRunner()
		{
			int temp = 0;
			int currentIndex = -1;
			int oldIndex = -1;
			int fixCounter = 0;
			FNode currentNode = new FNode(-1,10, new Point(-1, -1), 100, -100);
			//int roiCounter = 0;
			int h = 0;
			
			
			while (true)
			{
				try
				{
					temp++;

					if (curTsk.runConf.useCursor == false)       // گرفتن مختصات از روی خیرگی
					{
						//currentNode = new FNode(10, new Point(-1, -1), 100, 'C', -100);
						//currentIndex = 0;
						//int score = 0;
						//foreach (FNode node in TaskGen.positiveFixates)
						//{
						//	if (Math.Sqrt(Math.Pow(Math.Abs(node.pos.X - MappedSigs[0]), 2) + Math.Pow(Math.Abs(node.pos.Y - MappedSigs[1]), 2)) <= node.radius)
						//	{
						//		currentNode = node;
						//		currentIndex = node.priority;
						//	}
						//}
						//foreach (FNode node in TaskGen.negativeFixates)
						//{
						//	if (Math.Sqrt(Math.Pow(Math.Abs(node.pos.X - MappedSigs[0]), 2) + Math.Pow(Math.Abs(node.pos.Y - MappedSigs[1]), 2)) <= node.radius)
						//	{
						//		currentNode = node;
						//		currentIndex = node.priority;
						//	}
						//}
						//if (currentIndex == oldIndex)
						//{
						//	if (currentNode != goalNode)
						//	{
						//		fixCounter++;
						//		if (currentNode.priority != -100)
						//		{
						//			if (fixCounter == currentNode.time / 8)
						//			{
						//				failSound.Play();
						//				//score = -1;
						//			}
						//		}
						//	}
						//}
						//else
						//{
						//	fixCounter = 0;
						//	oldIndex = currentIndex;
						//}
						//if (Math.Sqrt(Math.Pow(goalNode.pos.X - MappedSigs[0], 2) + Math.Pow(goalNode.pos.Y - MappedSigs[1], 2)) <= goalNode.radius)
						//{
						//	h++;
						//	if (h >= goalNode.time / 8)
						//	{
						//		winSound.Play();
						//		score = 1;
						//		int y = TLNormalSetGoalNode();
						//		if (y == -1)
						//			StartStop();
						//	}
						//}
						//else
						//	h = 0;
						//savedStr = MappedSigs[0].ToString() + "," + MappedSigs[1].ToString() + "," + MappedSigs[2].ToString() + "," + currentIndex.ToString() + "," + MappedSigs[3].ToString() + "," + score.ToString() + "\n";
						//savedData += savedStr;
						//savedStr = "";
					}
					else        // گرفتن مختصات از روی موقعیت موس
					{
						int mouseX = Cursor.Position.X + BasConfigs._monitor_resolution_x;
						int mouseY = Cursor.Position.Y;
						//currentFixate.priority = 0;
						currentNode = new FNode(-1,10, new Point(-1, -1), 100, -100);
						currentIndex = 0;
						//score = 0;
						//foreach (FNode node in curTsk.Fixates)
						//{
						//	if (Math.Sqrt(Math.Pow(Math.Abs(node.pos.X - mouseX), 2) + Math.Pow(Math.Abs(node.pos.Y - mouseY), 2)) <= node.radius)
						//	{
						//		currentNode = node;
						//		currentIndex = node.priority;
						//	}
						//}
						

						//if (currentIndex == oldIndex)
						//{
						//	if (currentNode != goalNode)
						//	{
						//		fixCounter++;
						//		if (currentNode.priority != -100)
						//		{
						//			if (fixCounter == currentNode.time / 8)
						//			{
						//				failSound.Play();
						//				//score = -1;
						//			}
						//		}
						//	}
						//}
						//else
						//{
						//	fixCounter = 0;
						//	oldIndex = currentIndex;
						//}
						//if (Math.Sqrt(Math.Pow(goalNode.pos.X - mouseX, 2) + Math.Pow(goalNode.pos.Y - mouseY, 2)) <= goalNode.radius)
						//{
						//	h++;
						//	if (h >= goalNode.time / 8)
						//	{
						//		winSound.Play();
						//		//score = 1;
						//		int y = TLNormalSetGoalNode();
						//		//if (y == -1)
						//		//	StartStop();
						//	}
						//}
						//else
						//	h = 0;
						//savedStr = (Cursor.Position.X + 1440).ToString() + "," + Cursor.Position.Y.ToString() + "," + currentIndex.ToString() + "," + MappedSigs[3].ToString() + "," + score.ToString() + "\n";
						//savedData += savedStr;
						savedStr = "";
					}


					//Thread.Sleep(7);

				}
				catch { }
			}
		}

		private void CTTaskSelectStartGoal()
		{
			int[] strt = curTsk.PsycoTask.FindStartShapes();
			

		}
			
		private int TLNormalSetGoalNode()
		{
			//int tempPriority = 100;
			//int tempIndex = -1;
			//foreach (FNode node in TaskGen.positiveFixates)
			//{
			//	if (node.priority > goalNode.priority && node.priority < tempPriority)
			//	{
			//		tempPriority = node.priority;
			//		tempIndex = TaskGen.positiveFixates.IndexOf(node);
			//	}
			//}
			//if (tempIndex >= 0)
			//{
			//	goalNodeThrd = goalNodePrevius;
			//	goalNodePrevius = goalNode;
			//	goalNode = positiveFixates[tempIndex];
			//	if (goalNodeThrd.priority != -100)
			//	{
			//		Image<Rgb, byte> tempImg = new Image<Rgb, byte>(userMap.Data);
			//		CvInvoke.ArrowedLine(tempImg, goalNodeThrd.pos, goalNodePrevius.pos, new MCvScalar(120, 230, 50), 2);
			//		pctbxFrm.Image = tempImg.ToBitmap();

			//	}
			//}
			//return tempIndex;
			return 0;
		}

		public bool RunTask(bool getGaz)
		{
			if (runMod == RunMod.running)       // هنگام اجرای برنامه
			{
				return false;
			}
			_getGaz = getGaz;
			runnerThread = new Thread(new ThreadStart(InitRunningTask));
			runMod = RunMod.running;
			runnerThread.Start();

			return true;

		}

		public bool StopTask()
		{
			CleanMap();
			if (runMod == RunMod.stop)       // هنگام اجرای برنامه
			{
				return true;
			}
			brake = true;
			runnerThread.Abort();
			runMod = RunMod.stop;
			Invoke((Action)delegate { Hide(); });
			if (_getGaz)
			{
				RunnerUtils.EndGaze();
			}
			return true;
		}

		/// <summary>
		/// Update triable screen by task image every 30 miliseconds.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frameUpdater_Tick(object sender, EventArgs e)
		{
			if (curTsk.Type == TaskType.media)
			{
				if (runMod == RunMod.running)
				{
					if (brake)
					{
						brake = false;
						frameUpdater.Stop();
						CleanMap();
						return;
					}
					if (showedIndex < curTsk.MediaTask.picList.Count)
					{
						pctbxFrm.BackColor = curTsk.MediaTask.picList[showedIndex].bgColor;
						pctbxFrm.Image = curTsk.GetFrameImage(showedIndex, pctbxFrm.Size);
					}
				}
			}
		}

		private void TaskRunner_Load(object sender, EventArgs e)
		{
			pctbxFrm.BackColor = Color.White;
			
		}

		public void CleanMap()
		{
			Bitmap img = RunnerUtils.PutString("اتمام تسک",new Point(pctbxFrm.Width / 4, pctbxFrm.Height / 2));
			pctbxFrm.Image = img;
		}

		private void TaskRunner_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void pctbxFrm_MouseMove(object sender, MouseEventArgs e)
		{
			_mousX = e.X; _mousY = e.Y;
		}

        private void TaskRunner_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTask();
        }

        private void pctbxFrm_Click(object sender, EventArgs e)
		{
			_mouseClicked = true;
		}
	}
	
}
