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
using System.Net.Sockets;
using System.Net;
using Basics;

namespace Psychophysics
{
    public partial class ShowFrame : Form
    {
		// Sound
		SoundPlayer winSound = new SoundPlayer(@TaskPreview.WinPath);
		SoundPlayer failSound = new SoundPlayer(@TaskPreview.FailPath);
		// Keyboard
		char keyboardChar = TaskPreview.keyboardChar;
		bool keyState = false;
		bool Mute = TaskPreview.SoundMute;
		// Status
		int status = 0;
		// ROI
		bool InROI = false;
		bool WriteStateInROI = false;
		// LAN
		bool UseLan, LanConnected;
		byte[] buffer;
		int numberOfData = 3;
		bool CloseForm = false;

		public ShowFrame()
		{
			InitializeComponent();
			MappedSigs[0] = 0;
			MappedSigs[1] = 0;
			MappedSigs[2] = 0;

			//Daq initialization
			MakeRandomRepeat(TaskPreview.TypeDisplay);
			for (int i = 0; i < RandForTaskLevel.Length; i++)
			{
				Debug.Write(RandForTaskLevel[i] + "\n");
			}
			UseLan = TaskPreview.UseLan;
			LanConnected = TaskPreview.LANConnected;
			if (UseLan & LanConnected)
			{
				try
				{
					buffer = new byte[numberOfData * sizeof(double)];

					TaskPreview.mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref TaskPreview.epRemote, new AsyncCallback(MessageCallBack), buffer);
				}
				catch
				{

				}

			}
			else
			{
				try
				{
					TaskPreview.instantAiCtrl.SelectedDevice = new DeviceInformation(TaskPreview.DaqName);
					Debug.Write(TaskPreview.DaqName + "\n");
					ErrorCode errorCode = ErrorCode.Success;

					TaskPreview.instantAiCtrl.Channels[0].ValueRange = TaskPreview.InputValRange;
					TaskPreview.instantAiCtrl.Channels[1].ValueRange = TaskPreview.InputValRange;
					TaskPreview.InputValRange = TaskPreview.instantAiCtrl.Channels[1].ValueRange;

					// DAQ
					int channelStart = 0;
					int channelCount = 2;

					double[] outdaq = new double[2];
					outdaq[0] = 0;
					outdaq[1] = 0;

					errorCode = TaskPreview.instantAiCtrl.Read(channelStart, channelCount, outdaq);
				}
				catch
				{

				}

				try
				{
					TaskPreview.instantDoCtrl = new InstantDoCtrl();
					TaskPreview.instantDoCtrl.SelectedDevice = new DeviceInformation(TaskPreview.DaqName);

					Byte Dout = new byte();
					Dout = 0x00;
					TaskPreview.instantDoCtrl.Write(0, Dout);
				}
				catch
				{

				}



				if (TaskPreview.InputValRange.Equals(ValueRange.V_0To5))
				{
					RangeVolIn = 2.5;
					CenterVolIn = 2.5;
				}

				if (TaskPreview.InputValRange.Equals(ValueRange.V_0To10))
				{
					RangeVolIn = 5;
					CenterVolIn = 5;
				}

				if (TaskPreview.InputValRange.Equals(ValueRange.V_Neg5To5))
				{
					RangeVolIn = 5;
					CenterVolIn = 0;
				}

				if (TaskPreview.InputValRange.Equals(ValueRange.V_Neg10To10))
				{
					RangeVolIn = 10;
					CenterVolIn = 0;
				}

				if (TaskPreview.InputValRange.Equals(ValueRange.V_0To1pt25))
				{
					RangeVolIn = 1.25 / 2;
					CenterVolIn = 1.25 / 2;
				}
			}

			Debug.Write("INNNNNNNNNNNNNNNNN " + RangeVolIn + " " + CenterVolIn + " \n");

			// for fullscreen
			FormBorderStyle = FormBorderStyle.None;
			WindowState = FormWindowState.Maximized;
			Debug.Write("RAAAAAAAAAAAAAND" + indexRandForTaskLevel + "\n");
			level = RandForTaskLevel[indexRandForTaskLevel];

			if (TaskPreview.AllLevelProp.Count == 0)
				return;
			
				timelimit = TaskPreview.AllLevelProp[level][frame].FrameTime;
			framelimit = TaskPreview.AllLevelProp[level].Count;
			repeatInfo = new RepeatLinkFrame();
			repeatInfo.SetProperties(TaskPreview.AllLevelProp[level][frame].RepeatInfo.Active, TaskPreview.AllLevelProp[level][frame].RepeatInfo.RepeatationNumber, TaskPreview.AllLevelProp[level][frame].RepeatInfo.Length, TaskPreview.AllLevelProp[level][frame].RepeatInfo.RandomLocation);

			RandForPosnerStimulus = new int[TaskPreview.NumerRepeat[level]];
			RandForPosnerCue = new int[TaskPreview.NumerRepeat[level]];
			for (int k = 0; k < TaskPreview.NumerRepeat[level]; k++)
			{
				Random rnd = new Random();
				RandForPosnerStimulus[k] = (rnd.Next(1, 1000) % 2);
				RandForPosnerCue[k] = (rnd.Next(1, 1000) % 2);
			}

			if (screen.Length == 2)
			{
				pictureBox1.Size = new Size(screen[1].Bounds.Width, screen[1].Bounds.Height);
				pictureBox1.SetBounds(this.Bounds.X, this.Bounds.Y, screen[1].Bounds.Width, screen[1].Bounds.Height);

				MappingWidth[0] = screen[1].Bounds.Width;
				MappingWidth[1] = screen[1].Bounds.Height;

				flag = new Bitmap(screen[1].Bounds.Width, screen[1].Bounds.Height);
				flagGraphics = Graphics.FromImage(flag);
				flagGraphics.Clear(TaskPreview.AllLevelProp[level][frame].BGColor);
				int numberstimulus = TaskPreview.AllLevelProp[level][frame].Stimulus.Length;


				if (repeatInfo.RandomLocation == 1)
				{
					repeatInfo.LeftOrRight = 2;
				}
				else if (repeatInfo.RandomLocation == 2)
				{
					repeatInfo.LeftOrRight = 1;
				}
				else if (repeatInfo.RandomLocation == 3)
				{
					repeatInfo.LeftOrRight = repeatInfo.Makerand();
				}
				else
				{
					repeatInfo.LeftOrRight = 0;
				}

				Debug.Write("Random Location " + RandomLocation + " " + repeatInfo.LeftOrRight + " " + TaskPreview.AllLevelProp[level][frame].RepeatInfo.RandomLocation + " \n");


				for (int i = 0; i < numberstimulus; i++)
				{
					FixationPts stimulus = TaskPreview.AllLevelProp[level][frame].Stimulus[i];
					//Use Solid Brush for filling the graphic shapes
					SolidBrush sb = new SolidBrush(Color.FromArgb(stimulus.Contrast, stimulus.ColorPt));
					if (stimulus.Type == 1)
					{
						flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}
					if (stimulus.Type == 2)
					{
						flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}
					if (stimulus.Type == 3)
					{
						flagGraphics.FillEllipse(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 4)
					{
						if (File.Exists(stimulus.PathPic))
						{
							Bitmap bmpvar = new Bitmap(stimulus.PathPic);
							Debug.Write("Path " + stimulus.PathPic + " " + stimulus.Width + " " + stimulus.Height + "\n");
							bmpvar = new Bitmap(bmpvar, new Size(stimulus.Width, stimulus.Height));
							flagGraphics.DrawImage(bmpvar, new Point(stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2));
						}
					}

					if (stimulus.Type == 5)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 0;
						else if (repeatInfo.LeftOrRight == 2)
							i = 1;
						else
							i = 0;


						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillRectangle(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 6)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 0;
						else if (repeatInfo.LeftOrRight == 2)
							i = 1;
						else
							i = 0;
						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillRectangle(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 7)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 0;
						else if (repeatInfo.LeftOrRight == 2)
							i = 1;
						else
							i = 0;

						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillEllipse(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 8)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 0;
						else if (repeatInfo.LeftOrRight == 2)
							i = 1;
						else
							i = 0;
						if (File.Exists(stimulus.PathPic))
						{
							ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
							bmpvar = new Bitmap(stimulus.PathPic);
							bmpvar = new Bitmap(bmpvar, new Size(var.Width, var.Height));
							flagGraphics.DrawImage(bmpvar, new Point(var.CenterX - var.Width / 2, var.CenterY - var.Height / 2));
						}

						bmpvar.Dispose();
					}

					if (stimulus.Type == 9)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 1;
						else if (repeatInfo.LeftOrRight == 2)
							i = 0;
						else
							i = 1;

						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillRectangle(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 10)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 1;
						else if (repeatInfo.LeftOrRight == 2)
							i = 0;
						else
							i = 1;
						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillRectangle(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 11)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 1;
						else if (repeatInfo.LeftOrRight == 2)
							i = 0;
						else
							i = 1;

						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillEllipse(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 12)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 1;
						else if (repeatInfo.LeftOrRight == 2)
							i = 0;
						else
							i = 1;
						if (File.Exists(stimulus.PathPic))
						{
							ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
							bmpvar = new Bitmap(stimulus.PathPic);
							bmpvar = new Bitmap(bmpvar, new Size(var.Width, var.Height));
							flagGraphics.DrawImage(bmpvar, new Point(var.CenterX - var.Width / 2, var.CenterY - var.Height / 2));
						}
						bmpvar.Dispose();
					}
				}

				Debug.Write("State " + containfixation + " " + frame + " " + level + " \n");
				fixationstimulus = TaskPreview.AllLevelProp[level][frame].Fixation;
				//Use Solid Brush for filling the graphic shapes
				Pen fixationp = new Pen(fixationstimulus.ColorPt);
				if (fixationstimulus.Type == 1)
				{
					containfixation = true;
					FixationCenterX = fixationstimulus.Xloc;
					FixationCenterY = fixationstimulus.Yloc;
					FixationCenterWidth = fixationstimulus.Width;
					FixationCenterTime = TaskPreview.AllLevelProp[level][frame].FixationTime;

					FirstTimeInRoi = true;
					//flagGraphics.DrawRectangle(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
				}
				if (fixationstimulus.Type == 2)
				{
					containfixation = true;
					FixationCenterX = fixationstimulus.Xloc;
					FixationCenterY = fixationstimulus.Yloc;
					FixationCenterWidth = fixationstimulus.Width;
					FixationCenterTime = TaskPreview.AllLevelProp[level][frame].FixationTime;
					FirstTimeInRoi = true;
					//flagGraphics.DrawRectangle(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
				}

				if (fixationstimulus.Type == 3)
				{
					containfixation = true;
					FixationCenterX = fixationstimulus.Xloc;
					FixationCenterY = fixationstimulus.Yloc;
					FixationCenterWidth = fixationstimulus.Width;
					FixationCenterTime = TaskPreview.AllLevelProp[level][frame].FixationTime;
					FirstTimeInRoi = true;
					//flagGraphics.DrawEllipse(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
				}

				if (fixationstimulus.Type == 7)
				{
					containfixation = true;
					FixationCenterX = fixationstimulus.Xloc;
					FixationCenterY = fixationstimulus.Yloc;
					FixationCenterWidth = fixationstimulus.Width;
					FixationCenterTime = TaskPreview.AllLevelProp[level][frame].FixationTime;
					FirstTimeInRoi = true;
					//flagGraphics.DrawEllipse(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
				}

				if (containfixation)
					status = 1;
				else
					status = 0;

				int numbox = TaskPreview.AllLevelProp[level][frame].ShowFrame.Length;
				for (int i = 0; i < numbox; i++)
				{
					ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
					Pen framepen = new Pen(var.ColorBox, var.Thickness);
					flagGraphics.DrawRectangle(framepen, var.CenterX - var.Width / 2, var.CenterY - var.Height / 2, var.Width, var.Height);
				}

				if (numbox == 2)
				{
					if (TaskPreview.AllLevelProp[level][frame].Cue.type == 2)
					{
						HintForm varBoxHint = TaskPreview.AllLevelProp[level][frame].Cue;

						Debug.Write("Debug Box Hint: " + (repeatInfo.LeftOrRight - 1) + " \n");
						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[repeatInfo.LeftOrRight - 1];
						Pen framepen = new Pen(var.ColorBox, varBoxHint.BoxRatio * var.Thickness);

						flagGraphics.DrawRectangle(framepen, var.CenterX - var.Width / 2, var.CenterY - var.Height / 2, var.Width, var.Height);
					}

					if (TaskPreview.AllLevelProp[level][frame].Cue.type == 1)
					{
						HintForm vararrow = TaskPreview.AllLevelProp[level][frame].Cue;

						Pen pen = new Pen(vararrow.ArrowColor, vararrow.ArrowWidth);
						pen.StartCap = LineCap.ArrowAnchor;
						//pen.EndCap = LineCap.RoundAnchor;

						if (repeatInfo.LeftOrRight == 1)
							flagGraphics.DrawLine(pen, vararrow.ArrowLocX0, vararrow.ArrowLocY, vararrow.ArrowLocX1, vararrow.ArrowLocY);
						else if (repeatInfo.LeftOrRight == 2)
							flagGraphics.DrawLine(pen, vararrow.ArrowLocX1, vararrow.ArrowLocY, vararrow.ArrowLocX0, vararrow.ArrowLocY);
						else
							flagGraphics.DrawLine(pen, vararrow.ArrowLocX0, vararrow.ArrowLocY, vararrow.ArrowLocX1, vararrow.ArrowLocY);
					}
				}
				Debug.Write("CueType " + TaskPreview.AllLevelProp[level][frame].Cue.type + " \n");
				pictureBox1.Image = flag;
				sw = Stopwatch.StartNew();
			}
			Timer1.Start();
			//MessageBox.Show("box2");
			//label1.Text = "Step2";
			// پارامتر مربوط به ذخیره داده ها
			if (TaskPreview.Savetask)
			{
				string DataStr = "Signal X" + "," + "Signal Y" + "," + "Level" + "," + "Frame" + "," + "In ROI?" + "," + "Time (ms)";
				// CSV File
				//DataStr += MappedSigs[0] + ";" + MappedSigs[1] + ";" + level + ";" + frame + ";" + repeat + ";" + repeatInfo.CurrentRepeatationNumber + ";" + repeatInfo.CurrentIndex + ";" + DateTime.Now.Minute + ";" + DateTime.Now.Second + ";" + DateTime.Now.Millisecond + "\n";
				DataTask += DataStr;


				MicroTimerLiveEnable();
				microTimerLive.Enabled = true;
			}

			//if (containfixation)
			//DaqTimer.Start();

			MicroTimerEnable();
			microTimer.Enabled = true;
			//MessageBox.Show("box3");
			//label1.Text = "Step3";
		}

		// Number and Size of Screens
		Screen[] screen = Screen.AllScreens;
		int counter = 0;
		int level = 0;
		int frame = 0;
		int timelimit = 0;
		int framelimit = 0;
		int repeat = 0;
		int baseframe = 0;
		bool fixatehappened = false;
		Stopwatch sw = Stopwatch.StartNew();
		Bitmap flag;
		Graphics flagGraphics;
		FixationPts stimulus;
		FixationPts fixationstimulus;
		Pen fixationp;
		SolidBrush sb;
		Bitmap bmpvar;
		int numberstimulus;
		int i;
		bool containfixation = false;
		double CenterVolIn = 0, RangeVolIn = 0;
		double[] MappingWidth = new double[2];
		double[] MappedSigs = new double[3];
		double FixationCenterX = 0, FixationCenterY = 0, FixationCenterWidth = 0;
		int FixationCenterTime = 0, FixationOutTime = 200;
		int FixationRewardType = 0;
		Stopwatch FixationSW = Stopwatch.StartNew();
		bool FirstTimeInRoi = true;

		int[] RandForPosnerStimulus, RandForPosnerCue;
		public int[] RandForTaskLevel, RepeatationIndex;
		int indexRandForTaskLevel = 0;
		RepeatLinkFrame repeatInfo = new RepeatLinkFrame();
		int RandomLocation = 0;
		string DataTask = "";
		//Timer
		MicroLibrary.MicroTimer microTimer;
		MicroLibrary.MicroTimer microTimerLive;
		// Daq 
		//int Xindex = TaskPreview.
		
		private void Timer1_Tick(object sender, EventArgs e)
		{
			//// Save 
			//if (TaskPreview.Savetask)
			//{
			//    // CSV File
			//    string DataStr = MappedSigs[0] + ";" + MappedSigs[1] + ";" + level + ";" + frame + ";" + repeat + ";" + repeatInfo.CurrentRepeatationNumber + ";" + repeatInfo.CurrentIndex + ";" + DateTime.Now.Minute + ";" + DateTime.Now.Second + ";" + DateTime.Now.Millisecond + "\n";
			//    DataTask += DataStr;
			//}

			if (TaskPreview.StopBT_Pushed)
			{
				CloseForm = true;
				if (TaskPreview.mySocket != null)
				{
					TaskPreview.mySocket.Close();
					TaskPreview.mySocket.Dispose();
				}
				//this.Close();
				this.BeginInvoke(new MethodInvoker(Close));
			}

			// داده ها درون فایل csv ذخیره میشود
			if (TaskPreview.Savetask && DataTask.Length > 0)
			{
				File.AppendAllText(TaskPreview.DataPath, DataTask);
				DataTask = "";
			}

			if (sw.ElapsedMilliseconds < timelimit)
			{
				counter++;
				return;
			}

			Byte Dout = new byte();
			Dout = 0x00;
			//if (!UseLan && TaskPreview.instantDoCtrl != null)
			//    TaskPreview.instantDoCtrl.Write(0, Dout);
			counter = 0;
			//Test_LB.Text = sw.ElapsedMilliseconds + "ms \n";
			sw = Stopwatch.StartNew();
			if (FixationRewardType == 83 || FixationRewardType == 50 || FixationRewardType == 87 || FixationRewardType == 51)
			{
				Debug.Write("Fixate1 " + frame + "\n");
				if (fixatehappened)
				{
					Debug.Write("Fixate2 " + frame + "\n");
					frame++;
					if (frame == framelimit)
					{
						status = 4;
						if (TaskPreview.Savetask)
						{
							string DataStr;
							DataStr = "," + status.ToString();
							DataTask += DataStr;
						}
					}

					if (repeatInfo.Active)
					{
						repeatInfo.CurrentIndex++;
						if (!(repeatInfo.CurrentIndex < repeatInfo.Length))
						{
							repeatInfo.CurrentRepeatationNumber++;
							if (repeatInfo.CurrentRepeatationNumber < repeatInfo.RepeatationNumber)
							{
								frame = frame - repeatInfo.CurrentIndex;
								repeatInfo.CurrentIndex = 0;
							}
							else
							{
								repeatInfo.Active = false;
							}
						}
					}

					containfixation = false;
					//if (FixationRewardType != 5)
					//    fixatehappened = false;

					//DaqTimer.Stop();
					//microTimer.Enabled = false;
					if (frame < framelimit)
					{
						timelimit = TaskPreview.AllLevelProp[level][frame].FrameTime;
					}
					else
					{
						frame = 0;
						indexRandForTaskLevel++;
						if (indexRandForTaskLevel >= RandForTaskLevel.Length)
						{
							Timer1.Stop();
							CloseForm = true;
							if (TaskPreview.mySocket != null)
							{
								TaskPreview.mySocket.Close();
								TaskPreview.mySocket.Dispose();
							}
							//this.Close();
							this.BeginInvoke(new MethodInvoker(Close));
							return;
						}
						level = RandForTaskLevel[indexRandForTaskLevel];

						timelimit = TaskPreview.AllLevelProp[level][frame].FrameTime;
						framelimit = TaskPreview.AllLevelProp[level].Count;

					}
					Debug.Write("Fixate \n");
				}
				else
				{
					Debug.Write("Fixate*** " + frame + " " + FixationRewardType + "\n");

					if (FixationRewardType == 87 || FixationRewardType == 83)
					{
						status = 2;
						//if(!Mute)
						//failSound.Play();
					}

					if (FixationRewardType == 50 || FixationRewardType == 51)
					{
						status = 3;
					}

					frame = baseframe;
					if (repeatInfo.Active)
					{
						repeatInfo.CurrentIndex = 0;
						if (!(repeatInfo.CurrentIndex < repeatInfo.Length))
						{
							repeatInfo.CurrentRepeatationNumber++;
							if (repeatInfo.CurrentRepeatationNumber < repeatInfo.RepeatationNumber)
							{
								frame = frame - repeatInfo.CurrentIndex;
								repeatInfo.CurrentIndex = 0;
							}
							else
							{
								repeatInfo.Active = false;
							}
						}
					}

					containfixation = false;
					keyState = false;
					//fixatehappened = false;
					//DaqTimer.Stop();
					//microTimer.Enabled = false;
					if (TaskPreview.Savetask)
					{
						string DataStr;
						// CSV File
						DataStr = "," + status.ToString();
						DataTask += DataStr;
					}
					if (TaskPreview.Savetask && DataTask.Length > 0)
					{
						File.AppendAllText(TaskPreview.DataPath, DataTask);
						DataTask = "";
					}

					indexRandForTaskLevel++;
					if (indexRandForTaskLevel >= RandForTaskLevel.Length)
					{
						Timer1.Stop();
						CloseForm = true;
						if (TaskPreview.mySocket != null)
						{
							TaskPreview.mySocket.Close();
							TaskPreview.mySocket.Dispose();
						}
						//this.Close();
						this.BeginInvoke(new MethodInvoker(Close));
						return;
					}
					level = RandForTaskLevel[indexRandForTaskLevel];

					timelimit = TaskPreview.AllLevelProp[level][frame].FrameTime;
					framelimit = TaskPreview.AllLevelProp[level].Count;
				}

			}
			else
			{
				frame++;
				if (repeatInfo.Active)
				{
					repeatInfo.CurrentIndex++;
					if (!(repeatInfo.CurrentIndex < repeatInfo.Length))
					{
						repeatInfo.CurrentRepeatationNumber++;
						if (repeatInfo.CurrentRepeatationNumber < repeatInfo.RepeatationNumber)
						{
							frame = frame - repeatInfo.CurrentIndex;
							repeatInfo.CurrentIndex = 0;
						}
						else
						{
							repeatInfo.Active = false;
						}

					}
				}


				containfixation = false;
				fixatehappened = false;
				keyState = false;
				//microTimer.Enabled = false;

				if (frame < framelimit)
				{
					timelimit = TaskPreview.AllLevelProp[level][frame].FrameTime;
				}
				else
				{
					frame = 0;
					indexRandForTaskLevel++;
					if (indexRandForTaskLevel >= RandForTaskLevel.Length)
					{
						Timer1.Stop();
						CloseForm = true;
						if (TaskPreview.mySocket != null)
						{
							TaskPreview.mySocket.Close();
							TaskPreview.mySocket.Dispose();
						}
						//TaskPreview.mySocket.Shutdown(SocketShutdown.Both);

						//TaskPreview.mySocket.Disconnect(false);
						//this.Close();
						this.BeginInvoke(new MethodInvoker(Close));
						return;
					}
					level = RandForTaskLevel[indexRandForTaskLevel];
					timelimit = TaskPreview.AllLevelProp[level][frame].FrameTime;
					framelimit = TaskPreview.AllLevelProp[level].Count;
				}
			}

			if (screen.Length == 2)
			{
				flagGraphics.Clear(Color.White);
				flagGraphics.Clear(TaskPreview.AllLevelProp[level][frame].BGColor);
				numberstimulus = TaskPreview.AllLevelProp[level][frame].Stimulus.Length;
				if (TaskPreview.AllLevelProp[level][frame].RepeatInfo.Active)
				{
					if (repeatInfo.RandomLocation == 1)
					{
						repeatInfo.LeftOrRight = 2;
					}
					else if (repeatInfo.RandomLocation == 2)
					{
						repeatInfo.LeftOrRight = 1;
					}
					else if (repeatInfo.RandomLocation == 3)
					{
						repeatInfo.LeftOrRight = repeatInfo.Makerand();
					}
					else
					{
						RandomLocation = 0;
					}
				}
				//Debug.Write("Random Location " + frame + " " + RandomLocation + " " + repeatInfo.LeftOrRight + " " + TaskPreview.AllLevelProp[level][frame].RepeatInfo.RandomLocation + " \n");

				//Debug.Write("NUm " + numberstimulus + " \n");
				for (int k = 0; k < numberstimulus; k++)
				{
					stimulus = TaskPreview.AllLevelProp[level][frame].Stimulus[k];
					//Use Solid Brush for filling the graphic shapes
					sb = new SolidBrush(Color.FromArgb(stimulus.Contrast, stimulus.ColorPt));

					if (stimulus.Type == 1)
					{
						flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 2)
					{
						flagGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 3)
					{
						flagGraphics.FillEllipse(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}
					//Debug.Write("Stimulius Error :" + k +" " + stimulus.PathPic + " " + numberstimulus  + " " + stimulus.Type+ " " + "\n");

					if (stimulus.Type == 4)
					{
						if (File.Exists(stimulus.PathPic))
						{
							bmpvar = new Bitmap(stimulus.PathPic);
							bmpvar = new Bitmap(bmpvar, new Size(stimulus.Width, stimulus.Height));
							flagGraphics.DrawImage(bmpvar, new Point(stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Width / 2));
						}

						bmpvar.Dispose();
					}

					if (stimulus.Type == 5)
					{

						if (repeatInfo.LeftOrRight == 1)
							i = 0;
						else if (repeatInfo.LeftOrRight == 2)
							i = 1;
						else
							i = 0;

						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillRectangle(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 6)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 0;
						else if (repeatInfo.LeftOrRight == 2)
							i = 1;
						else
							i = 0;
						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillRectangle(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 7)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 0;
						else if (repeatInfo.LeftOrRight == 2)
							i = 1;
						else
							i = 0;
						//if (RandForPosnerStimulus[repeat] == 0)
						//    i = 0;
						//else
						//    i = 1;
						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillEllipse(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 8)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 0;
						else if (repeatInfo.LeftOrRight == 2)
							i = 1;
						else
							i = 0;
						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						//Debug.Write("PathPic :" + stimulus.PathPic+ "\n " );
						if (File.Exists(stimulus.PathPic))
						{
							bmpvar = new Bitmap(stimulus.PathPic);
							bmpvar = new Bitmap(bmpvar, new Size(var.Width, var.Height));
							flagGraphics.DrawImage(bmpvar, new Point(var.CenterX - var.Width / 2, var.CenterY - var.Height / 2));
						}


						bmpvar.Dispose();
					}

					if (stimulus.Type == 9)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 1;
						else if (repeatInfo.LeftOrRight == 2)
							i = 0;
						else
							i = 1;

						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillRectangle(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 10)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 1;
						else if (repeatInfo.LeftOrRight == 2)
							i = 0;
						else
							i = 1;
						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillRectangle(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 11)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 1;
						else if (repeatInfo.LeftOrRight == 2)
							i = 0;
						else
							i = 1;

						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						flagGraphics.FillEllipse(sb, var.CenterX - stimulus.Width / 2, var.CenterY - stimulus.Width / 2, stimulus.Width, stimulus.Width);
					}

					if (stimulus.Type == 12)
					{
						if (repeatInfo.LeftOrRight == 1)
							i = 1;
						else if (repeatInfo.LeftOrRight == 2)
							i = 0;
						else
							i = 1;
						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
						if (File.Exists(stimulus.PathPic))
						{
							bmpvar = new Bitmap(stimulus.PathPic);
							bmpvar = new Bitmap(bmpvar, new Size(var.Width, var.Height));
							flagGraphics.DrawImage(bmpvar, new Point(var.CenterX - var.Width / 2, var.CenterY - var.Height / 2));
						}
						bmpvar.Dispose();
					}

				}
				fixationstimulus = TaskPreview.AllLevelProp[level][frame].Fixation;
				//Use Solid Brush for filling the graphic shapes
				fixationp = new Pen(fixationstimulus.ColorPt);
				//Debug.Write("Data  f:" + fixationstimulus.Xloc + " " + fixationstimulus.Yloc + " " + fixationstimulus.Type  + " " + numberstimulus + " " + "\n");
				if (fixationstimulus.Type == 1)
				{
					containfixation = true;
					FixationCenterX = fixationstimulus.Xloc;
					FixationCenterY = fixationstimulus.Yloc;
					FixationCenterWidth = fixationstimulus.Width;
					FixationCenterTime = TaskPreview.AllLevelProp[level][frame].FixationTime;
					FirstTimeInRoi = true;
					//flagGraphics.DrawRectangle(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
				}

				if (fixationstimulus.Type == 2)
				{
					containfixation = true;
					FixationCenterX = fixationstimulus.Xloc;
					FixationCenterY = fixationstimulus.Yloc;
					FixationCenterWidth = fixationstimulus.Width;
					FixationCenterTime = TaskPreview.AllLevelProp[level][frame].FixationTime;
					FirstTimeInRoi = true;
					//flagGraphics.DrawRectangle(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
				}

				if (fixationstimulus.Type == 3)
				{
					containfixation = true;
					FixationCenterX = fixationstimulus.Xloc;
					FixationCenterY = fixationstimulus.Yloc;
					FixationCenterWidth = fixationstimulus.Width;
					FixationCenterTime = TaskPreview.AllLevelProp[level][frame].FixationTime;
					FirstTimeInRoi = true;
					//flagGraphics.DrawEllipse(fixationp, fixationstimulus.Xloc - fixationstimulus.Width / 2, fixationstimulus.Yloc - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
				}

				if (fixationstimulus.Type == 7)
				{
					if (repeatInfo.LeftOrRight == 1)
						i = 0;
					else if (repeatInfo.LeftOrRight == 2)
						i = 1;
					else
						i = 0;
					//if (RandForPosnerStimulus[repeat] == 0)
					//    i = 0;
					//else
					//    i = 1;
					ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
					//Debug.Write("Fixationnnnnnnnnnnnnnnnn :" + repeatInfo.LeftOrRight + " " + i + frame + "\n");
					containfixation = true;
					FixationCenterX = var.CenterX;
					FixationCenterY = var.CenterY;
					FixationCenterWidth = fixationstimulus.Width;
					FixationCenterTime = TaskPreview.AllLevelProp[level][frame].FixationTime;
					FirstTimeInRoi = true;
					//flagGraphics.DrawEllipse(fixationp, var.CenterX - fixationstimulus.Width / 2, var.CenterY - fixationstimulus.Width / 2, fixationstimulus.Width, fixationstimulus.Width);
				}

				int numbox = TaskPreview.AllLevelProp[level][frame].ShowFrame.Length;
				for (i = 0; i < numbox; i++)
				{
					ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[i];
					Pen framepen = new Pen(var.ColorBox, var.Thickness);
					flagGraphics.DrawRectangle(framepen, var.CenterX - var.Width / 2, var.CenterY - var.Height / 2, var.Width, var.Height);
				}
				//Debug.Write("Fixationnnnn1111111111111 :" + repeatInfo.LeftOrRight + " " + i + " " +  frame + "\n");
				//Debug.Write("DebugCue : " + TaskPreview.AllLevelProp[level][frame].Cue.type  + " " + numbox  + "  " +  frame + " \n");
				if (numbox == 2)
				{
					if (TaskPreview.AllLevelProp[level][frame].Cue.type == 2)
					{
						HintForm varBoxHint = TaskPreview.AllLevelProp[level][frame].Cue;

						Debug.Write("Error Here :" + frame + " " + level + "\n");
						ShowFr var = TaskPreview.AllLevelProp[level][frame].ShowFrame[repeatInfo.LeftOrRight - 1];
						//Debug.Write("Debug Var: " + var.CenterX + " " + TaskPreview.AllLevelProp[level][frame].ShowFrame[repeatInfo.LeftOrRight - 1].CenterX + " " + varBoxHint.BoxRatio + " \n");
						Pen framepen = new Pen(var.ColorBox, varBoxHint.BoxRatio * var.Thickness);

						flagGraphics.DrawRectangle(framepen, var.CenterX - var.Width / 2, var.CenterY - var.Height / 2, var.Width, var.Height);

					}

					if (TaskPreview.AllLevelProp[level][frame].Cue.type == 1)
					{
						HintForm vararrow = TaskPreview.AllLevelProp[level][frame].Cue;

						Pen pen = new Pen(vararrow.ArrowColor, vararrow.ArrowWidth);
						pen.StartCap = LineCap.ArrowAnchor;
						//pen.EndCap = LineCap.RoundAnchor;

						if (repeatInfo.LeftOrRight == 1)
							flagGraphics.DrawLine(pen, vararrow.ArrowLocX0, vararrow.ArrowLocY, vararrow.ArrowLocX1, vararrow.ArrowLocY);
						else if (repeatInfo.LeftOrRight == 2)
							flagGraphics.DrawLine(pen, vararrow.ArrowLocX1, vararrow.ArrowLocY, vararrow.ArrowLocX0, vararrow.ArrowLocY);
						else
							flagGraphics.DrawLine(pen, vararrow.ArrowLocX0, vararrow.ArrowLocY, vararrow.ArrowLocX1, vararrow.ArrowLocY);
					}
				}
				Debug.Write("Repeatation : " + frame + " " + repeatInfo.CurrentRepeatationNumber + " " + repeatInfo.CurrentIndex + " " + level + " \n");
				if (repeatInfo.Active == false)
				{
					repeatInfo.SetProperties(TaskPreview.AllLevelProp[level][frame].RepeatInfo.Active, TaskPreview.AllLevelProp[level][frame].RepeatInfo.RepeatationNumber, TaskPreview.AllLevelProp[level][frame].RepeatInfo.Length, TaskPreview.AllLevelProp[level][frame].RepeatInfo.RandomLocation);
				}
				FixationRewardType = TaskPreview.AllLevelProp[level][frame].RewardType;
				if (FixationRewardType != 51 && FixationRewardType != 50)
					fixatehappened = false;
				if (containfixation)
				{
					if (TaskPreview.AllLevelProp[level][frame].RewardType == 0)
					{
						status = 0;
					}
					else
					{
						//microTimer.Enabled = true;
						status = 1;
						//DaqTimer.Start();
					}
				}
				else
				{
					status = 0;
				}
				pictureBox1.Image = flag;
				//flag.Dispose();
			}
			//MessageBox.Show("box5");
			//label1.Text = "Step4";
			return;
		}
		
		private void ShowFrame_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == keyboardChar)
				keyState = true;
			else
				keyState = false;

		}

		private void CheckPointInROI(double[] Point, int rewardtype)
		{
			double dist = 0;
			dist = (Point[0] - FixationCenterX) * (Point[0] - FixationCenterX) + (Point[1] - FixationCenterY) * (Point[1] - FixationCenterY);
			Debug.Write("In ROI : " + dist + " " + FixationCenterX + " " + FixationCenterY + " " + Point[0] + " " + Point[1] + " \n");
			if (rewardtype == 83 || rewardtype == 87)
			{
				if (keyState)
				{
					FirstTimeInRoi = true;
					FixationSW.Stop();
					FixationSW.Reset();

					fixatehappened = true;
					timelimit = 0;

					if (rewardtype == 87 && (!Mute))
						winSound.Play();
				}
			}
			keyState = false;

			if (dist < FixationCenterWidth * FixationCenterWidth && timelimit > 0)
			{
				InROI = true;
				if (rewardtype == 74)
				{
					if (FirstTimeInRoi & timelimit > 0)
					{
						//Debug.Write("Helllllllllllllllllllllllllllllllllllllllllllllo2\n");
						if (sw.ElapsedMilliseconds + FixationCenterTime + FixationOutTime >= timelimit)
						{
							timelimit = Convert.ToInt16(sw.ElapsedMilliseconds) + FixationCenterTime + FixationOutTime + 20;
						}

						FixationSW = Stopwatch.StartNew();
						Byte Dout = new byte();
						Dout = 0x00;
						//if (TaskPreview.instantDoCtrl != null)
						//    TaskPreview.instantDoCtrl.Write(0, Dout);
						FirstTimeInRoi = false;
					}

					if (FixationSW.ElapsedMilliseconds > FixationCenterTime)
					{
						Byte Dout = new byte();
						Dout = 0x01;
						//if (!UseLan && TaskPreview.instantDoCtrl != null)
						//    TaskPreview.instantDoCtrl.Write(0, Dout);
						//Debug.Write("Helllllllllllllllllllllllllllllllllllllllllllllo\n");
					}

					if (FixationSW.ElapsedMilliseconds > FixationCenterTime + FixationOutTime)
					{
						//Debug.Write("Helllllllllllllllllllllllllllllllllllllllllllllo1\n");
						//FixationSW = Stopwatch.StartNew();
						FixationSW.Stop();
						FixationSW.Reset();

						Byte Dout = new byte();
						Dout = 0x00;
						//if (!UseLan && TaskPreview.instantDoCtrl != null)
						//    TaskPreview.instantDoCtrl.Write(0, Dout);
						//FirstTimeInRoi = true;
					}
				}
				if (rewardtype == 83)
				{
					if (FirstTimeInRoi & timelimit > 0)
					{
						//Debug.Write("Helllllllllllllllllllllllllllllllllllllllllllllo2\n");
						if (sw.ElapsedMilliseconds + FixationCenterTime >= timelimit)
						{
							timelimit = Convert.ToInt16(sw.ElapsedMilliseconds) + FixationCenterTime + FixationOutTime + 20;
						}
						FixationSW = Stopwatch.StartNew();
						FirstTimeInRoi = false;
					}

					if ((FixationSW.ElapsedMilliseconds > FixationCenterTime))
					{
						FirstTimeInRoi = true;
						FixationSW.Stop();
						FixationSW.Reset();
						fixatehappened = true;
						timelimit = 0;
						keyState = false;
					}
				}

				if (rewardtype == 90)
				{
					if (FirstTimeInRoi & timelimit > 0)
					{
						if (sw.ElapsedMilliseconds + FixationCenterTime + FixationOutTime >= timelimit)
						{
							timelimit = Convert.ToInt16(sw.ElapsedMilliseconds) + FixationCenterTime + FixationOutTime + 20;
						}

						//Debug.Write("Helllllllllllllllllllllllllllllllllllllllllllllo2\n");
						FixationSW = Stopwatch.StartNew();
						Byte Dout = new byte();
						Dout = 0x00;
						//if (!UseLan && TaskPreview.instantDoCtrl != null)
						//    TaskPreview.instantDoCtrl.Write(0, Dout);
						FirstTimeInRoi = false;
					}
					if (FixationSW.ElapsedMilliseconds > FixationCenterTime)
					{
						Byte Dout = new byte();
						Dout = 0x01;
						//if (!UseLan && TaskPreview.instantDoCtrl != null)
						//    TaskPreview.instantDoCtrl.Write(0, Dout);
						//Debug.Write("Helllllllllllllllllllllllllllllllllllllllllllllo\n");
					}
					if (FixationSW.ElapsedMilliseconds > FixationCenterTime + FixationOutTime)
					{
						//Debug.Write("Helllllllllllllllllllllllllllllllllllllllllllllo1\n");
						//FixationSW = Stopwatch.StartNew();
						FixationSW.Stop();
						FixationSW.Reset();

						Byte Dout = new byte();
						Dout = 0x00;
						//if (!UseLan && TaskPreview.instantDoCtrl != null)
						//    TaskPreview.instantDoCtrl.Write(0, Dout);
						FirstTimeInRoi = true;
						timelimit = 0;
					}
				}

				if (rewardtype == 82)
				{
					if (FirstTimeInRoi & timelimit > 0)
					{
						//Debug.Write("Helllllllllllllllllllllllllllllllllllllllllllllo2\n");
						if (sw.ElapsedMilliseconds + FixationCenterTime >= timelimit)
						{
							timelimit = Convert.ToInt16(sw.ElapsedMilliseconds) + FixationCenterTime + 20;
						}
						FixationSW = Stopwatch.StartNew();
						FirstTimeInRoi = false;
					}

					if (FixationSW.ElapsedMilliseconds > FixationCenterTime)
					{
						FirstTimeInRoi = true;
						FixationSW.Stop();
						FixationSW.Reset();
						timelimit = 0;
						baseframe = TaskPreview.BaseIndex[level];
						//Debug.Write("Helllllllllllllllllllllllllllllllllllllllllllllo\n");
					}

				}
				//Debug.Write("rewardtype : " + rewardtype + "\n");
				if (rewardtype == 87)
				{
					if (FirstTimeInRoi & timelimit > 0)
					{
						if (sw.ElapsedMilliseconds + FixationCenterTime >= timelimit)
						{
							timelimit = Convert.ToInt16(sw.ElapsedMilliseconds) + FixationCenterTime + 20;
						}
						FixationSW = Stopwatch.StartNew();
						FirstTimeInRoi = false;
						Debug.Write("timelimit : " + timelimit + " " + sw.ElapsedMilliseconds + " FixationSW " + FixationSW.ElapsedMilliseconds + "\n");
					}

					if (FixationSW.ElapsedMilliseconds >= FixationCenterTime)
					{
						Debug.Write("timelimit : " + timelimit + " " + sw.ElapsedMilliseconds + " FixationSW " + FixationSW.ElapsedMilliseconds + "\n");
						FirstTimeInRoi = true;
						FixationSW.Stop();
						FixationSW.Reset();
						fixatehappened = true;
						keyState = false;
						timelimit = 0;
						if (!Mute)
							winSound.Play();
					}
				}

				if (rewardtype == 35)
				{

				}

				if (rewardtype == 34)
				{

				}

			}
			else
			{
				InROI = false;
				if (rewardtype == 51)
				{
					timelimit = 0;
					fixatehappened = false;

					if (!Mute)
						failSound.Play();

					//frame = baseframe;
				}
				if (rewardtype == 50)
				{
					timelimit = 0;
					fixatehappened = false;
				}
				if (rewardtype == 87 || rewardtype == 82 || rewardtype == 74 || rewardtype == 83 || rewardtype == 90)
				{
					if (FirstTimeInRoi == false && timelimit > 0)
					{
						Debug.Write("timelimit1 : " + timelimit + " " + sw.ElapsedMilliseconds + " FixationSW " + FixationSW.ElapsedMilliseconds + "\n");
						timelimit = TaskPreview.AllLevelProp[level][frame].FrameTime;
						Debug.Write("timelimit2 : " + timelimit + " " + sw.ElapsedMilliseconds + " FixationSW " + FixationSW.ElapsedMilliseconds + "\n");
					}
				}

				FirstTimeInRoi = true;
				FixationSW.Stop();
				FixationSW.Reset();

				Byte Dout = new byte();
				Dout = 0x00;
				//if (!UseLan && TaskPreview.instantDoCtrl != null)
				//    TaskPreview.instantDoCtrl.Write(0, Dout);
			}
		}
		
		private void ChangeDaqValue(double[] OutDaq, int NumOfSignals, double InputVolCenter, double InputVolRange, double[] Width, double[] MappedSignals)
		{
			if (InputVolCenter == 0)
			{
				for (int i = 0; i < NumOfSignals; i++)
				{
					MappedSignals[i] = OutDaq[i] * Width[i] / (InputVolRange * 2) + Width[i] / 2;
				}
			}
			else
			{
				for (int i = 0; i < NumOfSignals; i++)
				{
					MappedSignals[i] = OutDaq[i] * Width[i] / (InputVolRange * 2);
				}
			}

		}
		
		private void MicroTimerEnable()
		{
			microTimer = new MicroLibrary.MicroTimer();
			microTimer.MicroTimerElapsed += new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);

			microTimer.Interval = 4000; // Call micro timer every 1000µs (1ms)
		}

		private void ShowFrame_FormClosed(object sender, FormClosedEventArgs e)
		{
			//TaskPreview.mySocket.Disconnect(true);
			//TaskPreview.mySocket.Shutdown(SocketShutdown.Both);
			//TaskPreview.mySocket.Close();
			if (microTimer != null)
			{
				microTimer.Enabled = false;
				if (TaskPreview.Savetask)
				{
					microTimerLive.Enabled = false;
				}
			}
			Timer1.Enabled = false;
		}

		private void MicroTimerLiveEnable()
		{
			microTimerLive = new MicroLibrary.MicroTimer();
			microTimerLive.MicroTimerElapsed += new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEventLive);

			microTimerLive.Interval = 4000; // Call micro timer every 1000µs (1ms)
		}

		private void ShowFrame_FormClosing(object sender, FormClosingEventArgs e)
		{
			//TaskPreview.mySocket.Disconnect(true);
			//TaskPreview.mySocket.Shutdown(SocketShutdown.Both);
			//TaskPreview.mySocket.Close();
		}

		private void OnTimedEventLive(object sender,
		  MicroLibrary.MicroTimerEventArgs timerEventArgs)
		{
			// تبدیل پیکسل به درجه
			double x = ConvertDegreeX(MappedSigs[0]) * 180 / 3.1415;
			double y = ConvertDegreeY(MappedSigs[1]) * 180 / 3.1415;
			string DataStr = "";

			// CSV File
			if (WriteStateInROI != InROI)
			{
				WriteStateInROI = InROI;
				if (WriteStateInROI)
				{
					//DataStr = "\n" + x + "," + y + "," + level + "," + frame + "," + 1 + "," + timerEventArgs.ElapsedMicroseconds / 1000;

					DataStr = "\n" + MappedSigs[0] + "," + MappedSigs[1] + "," + level + "," + frame + "," + 1 + "," + timerEventArgs.ElapsedMicroseconds / 1000;
				}
				else
				{
					DataStr = "\n" + MappedSigs[0] + "," + MappedSigs[1] + "," + level + "," + frame + "," + 0 + "," + timerEventArgs.ElapsedMicroseconds / 1000;
				}
			}
			else
			{
				DataStr = "\n" + MappedSigs[0] + "," + MappedSigs[1] + "," + level + "," + frame + "," + 0 + "," + timerEventArgs.ElapsedMicroseconds / 1000;
			}
			DataTask += DataStr;

		}

		private void OnTimedEvent(object sender,
				  MicroLibrary.MicroTimerEventArgs timerEventArgs)
		{
			if (!UseLan)
			{
				double[] outdaq = new double[2];
				outdaq[0] = 1;
				outdaq[1] = 1;

				// DAQ
				int channelStart = 0;
				int channelCount = 2;

				ErrorCode errorCode = ErrorCode.Success;
				//errorCode = TaskPreview.instantAiCtrl.Read(channelStart, channelCount, outdaq);
				ChangeDaqValue(outdaq, 2, CenterVolIn, RangeVolIn, MappingWidth, MappedSigs);
			}


			if (containfixation)
			{
				CheckPointInROI(MappedSigs, FixationRewardType);
			}
			else
			{
				InROI = false;
				FixationSW.Stop();
				FixationSW.Reset();
			}

			if (InvokeRequired)
			{
				BeginInvoke((MethodInvoker)delegate
				{
					//label1.Text = "Step"+ timerEventArgs.ElapsedMicroseconds;
				});
			}

			Invalidate();
		}

		private double ConvertDegreeX(double Xp)
		{
			double ValX = Math.Atan((Xp - TaskPreview.WidthP / 2) * TaskPreview.WidthM / (TaskPreview.WidthP * TaskPreview.userDistance));
			Debug.Write(" Xp: " + Xp + " WidthP : " + TaskPreview.WidthP + " WidthM:" + TaskPreview.WidthM + " userDistance:" + TaskPreview.userDistance + " " + ((Xp - TaskPreview.WidthP / 2) * TaskPreview.WidthM / (TaskPreview.WidthP * TaskPreview.userDistance)) + "\n");
			return ValX;
		}

		private double ConvertDegreeY(double Yp)
		{
			double ValY = Math.Atan((Yp - TaskPreview.HeightP / 2) * TaskPreview.HeightM / (TaskPreview.HeightP * TaskPreview.userDistance));
			return ValY;
		}

		private void MakeRandomRepeat(int DisplayType)
		{
			int totalRepeat = 0;
			for (int i = 0; i < TaskPreview.NumerRepeat.Count; i++)
			{
				totalRepeat += TaskPreview.NumerRepeat[i];
			}
			RandForTaskLevel = new int[totalRepeat];
			int index = 0;
			for (int i = 0; i < TaskPreview.NumerRepeat.Count; i++)
			{
				for (int j = 0; j < TaskPreview.NumerRepeat[i]; j++)
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
					Debug.Write("a and b " + a + " " + b + "\n");
					int varindex = RandForTaskLevel[a];
					RandForTaskLevel[a] = RandForTaskLevel[b];
					RandForTaskLevel[b] = varindex;
				}
			}
			int VarCnt = 0;
			RepeatationIndex = new int[totalRepeat];
			for (int i = 0; i < TaskPreview.NumerRepeat.Count; i++)
			{
				VarCnt = 0;
				for (int j = 0; j < RandForTaskLevel.Length; j++)
				{
					if (RandForTaskLevel[j] == i)
					{
						RepeatationIndex[j] = VarCnt;
						VarCnt++;
					}
				}

			}

		}

		private void MessageCallBack(IAsyncResult aResult)
		{
			try
			{
				byte[] RecivedData = new byte[numberOfData * sizeof(double)];
				RecivedData = (byte[])aResult.AsyncState;
				double[] rec = new double[numberOfData];
				Buffer.BlockCopy(RecivedData, 0, rec, 0, RecivedData.Length);


				MappedSigs[0] = rec[0];
				MappedSigs[1] = rec[1];
				MappedSigs[2] = rec[2];
				if (CloseForm)
					return;
				Debug.Write(" Val ::: " + Convert.ToString(MappedSigs[0]) + " " + Convert.ToString(MappedSigs[1]));
				buffer = new byte[numberOfData * sizeof(double)];
				TaskPreview.mySocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref TaskPreview.epRemote, new AsyncCallback(MessageCallBack), buffer);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}


	}
}
