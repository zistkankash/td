using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Basics;
using TaskDesigner;

namespace Psychophysics
{
    public partial class DesignerM : MetroFramework.Forms.MetroForm
	{
		#region Variables 
		float ViewSize = 80; //A: main white box size in the midddle of task designer
		Graphics g, gr;
		int? initX = null;
		int? initY = null;
		bool startPaint = false;
		bool drawSquare = false;
		bool drawRectangle = false;
		bool drawCircle = false;
		bool drawImage = false;
		bool moveObject = false;
		int moveObjectX = 0, moveObjectY = 0;
		int indexMoveObject = -1;
		bool FixationSelected = false;
		int PicBCnt = 1, ActivePicB = 1;
		String ImagePath = " ";
		Bitmap bmpvarforUpdate;
		// Type --------------------
		const int filledSquareType = 1;
		const int filledRectangleType = 2;
		const int filledCircleType = 3;
		const int PictureType = 4;
		//// for fixation areas 
		const int SquareType = 1;
		const int RectangleType = 2;
		const int CircleType = 3;
		//-------------------------
		//Edit Vars
		public int EditedIndex = 0;
		public int Mode = 0;
		public static List<ObjectProp> stimulusList = new List<ObjectProp>();
		public static List<ObjectProp> fixationList = new List<ObjectProp>();
		public static List<int> Reward = new List<int>();
		public static List<FrameProp> frameList = new List<FrameProp>();
		// Hint Arrow Added By FrameTool
		public static List<HintForm> AddedHintsbyFrameTool = new List<HintForm>();
		public static List<int> HintIndexes = new List<int>();
		public static List<Bitmap> BitmapPicB = new List<Bitmap>();
		public static List<int> DeletedFrames = new List<int>();
		// Repeat 
		public static List<int> RepeatedFrame = new List<int>();
		public static List<int> RepeatationLength = new List<int>();
		public static List<int> RepeatedRandomLocation = new List<int>();
		// ShowFrame
		public static List<ShowFr> ShowBoxes = new List<ShowFr>();
		public static List<int> FrameIndexes = new List<int>();
		#endregion
		public DesignerM(int mode, int index)  //A:loading the new designer
		{
			InitializeComponent();

			Debug.Write("Helll");
			fixationList.Clear();
			stimulusList.Clear();
			Reward.Clear();
			AddedHintsbyFrameTool.Clear();
			HintIndexes.Clear();
			RepeatedFrame.Clear();
			RepeatationLength.Clear();
			RepeatedRandomLocation.Clear();
			ShowBoxes.Clear();
			frameList.Clear();
			FrameIndexes.Clear();
			DeletedFrames.Clear();

			txtb_monitorwidth.Enabled = false;
			txtb_monitorheight.Enabled = false;

			if (mode == 1) //A: new designer
			{
				this.Mode = mode;

				// Frame Initialization
				FrameProp frm = new FrameProp();
				frameList.Add(frm);
				txtb_monitorwidth.Text = Convert.ToString(frameList[0].frameWidth);

				txtb_monitorheight.Text = Convert.ToString(frameList[0].frameHeight);

				FrameTime_ET.Text = Convert.ToString(frameList[0].Time);

				// Panel Graphic setting
				pnl_Draw.Size = new Size(Convert.ToInt16(frameList[0].frameWidth * (ViewSize / 100)), Convert.ToInt16(frameList[0].frameHeight * (ViewSize / 100)));
				g = pnl_Draw.CreateGraphics();
				g.Clear(Color.Black);

				// Bitmap Graphic setting
				Bitmap bmpVar = new Bitmap(frameList[0].frameWidth, frameList[0].frameHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				BitmapPicB.Add(bmpVar);
				ActivePicB = 1;
				gr = Graphics.FromImage(BitmapPicB[0]);
				gr.Clear(Color.White);

				RepeatedFrame.Add(0);
				RepeatationLength.Add(0);
				RepeatedRandomLocation.Add(0);
				Reward.Add(0);
				DeletedFrames.Add(0);

				// Fixation setting
				ObjectProp fixation = new ObjectProp();
				fixationList.Add(fixation);
				txb_fixationtime.Text = Convert.ToString(fixationList[0].Time);
				txb_fixationtime.Enabled = false;

				Bitmap objBitmap = new Bitmap(BitmapPicB[0], new Size(PicB1.Width, PicB1.Height));
				PicB1.Image = objBitmap;

				//SelectRewardType_CB.SelectedIndex = Reward[ActivePicB - 1];
				RewardType_LB.Text = Reward[ActivePicB - 1].ToString();
				UpdateTreeView(ActivePicB - 1);
			}
			else if (mode == 2) //A: a designer for editing the current task
			{
				this.Mode = mode;
				LoadParameters(index);
				this.EditedIndex = index;

				//SelectRewardType_CB.SelectedIndex = Reward[ActivePicB - 1];
				RewardType_LB.Text = Reward[ActivePicB - 1].ToString();
			}
			Size_LB.Text = " % " + Convert.ToString(ViewSize);
			//ParentPanel.MouseWheel += ParentPanel_Wheel; 
			SelectedPage_LB.Text = "Selected Page : " + Convert.ToString(ActivePicB);

		}

		public class ObjectProp
		{
			public int Xloc, Yloc, Width, Height, Type, FrameIndex, Time;
			public double Xlocd, Ylocd, Widthd, Heightd;
			public bool Enable;
			public int Contrast;
			public Color ColorPt;
			public string PathPic;
			public ObjectProp()
			{
				Xloc = -1;
				Yloc = -1;
				Width = 0;
				Height = 0;
				Type = 0;
				Time = 500;
				FrameIndex = -1;
				Enable = false;
				Contrast = 255;
				PathPic = "";
				ColorPt = Color.Black;
			}

			public void SetContrastPts(int contrast)
			{
				Contrast = contrast;
			}

			public void SetTime(int time) // time in millisecond
			{
				Time = time;
			}
			public void SetProps(int x, int y, int w, int h, int type, int index, bool enable, Color color)
			{
				Xloc = x;
				Yloc = y;
				Width = w;
				Height = h;
				Type = type;
				FrameIndex = index;
				Enable = enable;
				ColorPt = color;
			}
			public void SetFixationPts(int x, int y, int w, int h, int type, int index, bool enable, Color color)
			{
				Xloc = x;
				Yloc = y;
				Width = w;
				Height = h;
				Type = type;
				FrameIndex = index;
				Enable = enable;
				ColorPt = color;
			}
			public void ConvertToDeg()
			{
				Xlocd = ConvertDegreeX(Xloc) * 180 / 3.1415;
				Ylocd = ConvertDegreeY(Yloc) * 180 / 3.1415;
				Widthd = ConvertDegreeWidth(Width) * 180 / 3.1415;
				Heightd = ConvertDegreeHeight(Height) * 180 / 3.1415;
				Debug.Write(" ConvertToDeg" + Xlocd + " " + Ylocd + " " + Widthd + " " + Heightd + " \n");
			}

			public void ConvertToPix()
			{
				Xloc = ConvertPixelX(Xlocd);
				Yloc = ConvertPixelY(Ylocd);
				Width = ConvertPixelWidth(Widthd);
				Height = ConvertPixelHeight(Heightd);
				Debug.Write(" ConvertToPix" + Xloc + " " + Yloc + " " + Width + " " + Height + " \n");
			}

			public void SetPicture(int x, int y, int w, int h, int type, int index, bool enable, String path)
			{
				Xloc = x;
				Yloc = y;
				Width = w;
				Height = h;
				Type = type;
				FrameIndex = index;
				Enable = enable;
				PathPic = path;
			}


			private double ConvertDegreeX(int Xp)
			{
				double ValX = Math.Atan((Xp - PsycoPhysicTask.WidthP / 2) * PsycoPhysicTask.WidthM / (PsycoPhysicTask.WidthP * PsycoPhysicTask.userDistance));
				Debug.Write(" Xp: " + Xp + " WidthP : " + PsycoPhysicTask.WidthP + " WidthM:" + PsycoPhysicTask.WidthM + " userDistance:" + PsycoPhysicTask.userDistance + " " + ((Xp - PsycoPhysicTask.WidthP / 2) * PsycoPhysicTask.WidthM / (PsycoPhysicTask.WidthP * PsycoPhysicTask.userDistance)) + "\n");
				return ValX;
			}

			private double ConvertDegreeY(int Yp)
			{
				double ValY = Math.Atan((Yp - PsycoPhysicTask.HeightP / 2) * PsycoPhysicTask.HeightM / (PsycoPhysicTask.HeightP * PsycoPhysicTask.userDistance));
				return ValY;
			}

			private double ConvertDegreeWidth(int Xp)
			{
				double ValX = Math.Atan(Xp * PsycoPhysicTask.WidthM / (PsycoPhysicTask.WidthP * PsycoPhysicTask.userDistance));
				Debug.Write(" Xp: " + Xp + " WidthP : " + PsycoPhysicTask.WidthP + " WidthM:" + PsycoPhysicTask.WidthM + " userDistance:" + PsycoPhysicTask.userDistance + " " + ((Xp - PsycoPhysicTask.WidthP / 2) * PsycoPhysicTask.WidthM / (PsycoPhysicTask.WidthP * PsycoPhysicTask.userDistance)) + "\n");
				return ValX;
			}

			private double ConvertDegreeHeight(int Yp)
			{
				double ValY = Math.Atan(Yp * PsycoPhysicTask.HeightM / (PsycoPhysicTask.HeightP * PsycoPhysicTask.userDistance));
				return ValY;
			}


			private int ConvertPixelX(double Xd)
			{
				int ValX = Convert.ToInt16(Math.Tan(Xd * 3.1415 / 180) * PsycoPhysicTask.WidthP * PsycoPhysicTask.userDistance / PsycoPhysicTask.WidthM + PsycoPhysicTask.WidthP / 2);
				return ValX;
			}

			private int ConvertPixelY(double Yd)
			{
				int ValY = Convert.ToInt16(Math.Tan(Yd * 3.1415 / 180) * PsycoPhysicTask.HeightP * PsycoPhysicTask.userDistance / PsycoPhysicTask.HeightM + PsycoPhysicTask.HeightP / 2);
				return ValY;
			}

			private int ConvertPixelWidth(double Xd)
			{
				int ValX = Convert.ToInt16(Math.Tan(Xd * 3.1415 / 180) * PsycoPhysicTask.WidthP * PsycoPhysicTask.userDistance / PsycoPhysicTask.WidthM);
				return ValX;
			}

			private int ConvertPixelHeight(double Yd)
			{
				int ValY = Convert.ToInt16(Math.Tan(Yd * 3.1415 / 180) * PsycoPhysicTask.HeightP * PsycoPhysicTask.userDistance / PsycoPhysicTask.HeightM);
				return ValY;
			}

		}
		public class FrameProp
		{
			public int frameWidth, frameHeight, Time;
			public Color frameColor;
			public TriggerEvents events;
			public FrameProp()
			{
				Screen[] availableScreen = Screen.AllScreens;
				if (availableScreen.Length == 2)
				{
					frameWidth = availableScreen[1].Bounds.Width;
					frameHeight = availableScreen[1].Bounds.Height;
				}
				else
				{
					frameWidth = availableScreen[0].Bounds.Width;
					frameHeight = availableScreen[0].Bounds.Height;
				}
				Time = 1000; // default value
				frameColor = Color.White;
			}

			public void setFrameProp(int w, int h, int t, Color c)
			{
				frameWidth = w;
				frameHeight = h;
				Time = t;
				frameColor = c;
			}

		}
		private void label18_Click(object sender, EventArgs e)
        {
            
        }

		private void btn_PenColor_Click(object sender, EventArgs e)
		{
			ColorDialog c = new ColorDialog();
			if (c.ShowDialog() == DialogResult.OK)
			{
				btn_PenColor.BackColor = c.Color;
			}
		}
		private void pnl_Draw_MouseMove(object sender, MouseEventArgs e)
		{
			initX = e.X;
			initY = e.Y;

			double X = ConvertDegreeX(Convert.ToInt16(initX * 100 / ViewSize)) * 180 / 3.1415;//A: convert the cursur position in percent to radian whyyyy?!!
			double Y = ConvertDegreeY(Convert.ToInt16(initY * 100 / ViewSize)) * 180 / 3.1415;//A:it seems the ConvertDegree suppost to give the degree of the position 
																							  //A:didnt use it later?!just showing it!
			txbx_mousePradianX.Text = Convert.ToString(X); //A: shows it on the text box
			txbx_mousePradianY.Text = Convert.ToString(Y);
			if (moveObject)
			{
				//Debug.Write("indexMoveObject " + indexMoveObject + "\n");
				stimulusList[indexMoveObject].Xloc += (Convert.ToInt16(initX * 100 / ViewSize) - moveObjectX);
				stimulusList[indexMoveObject].Yloc += (Convert.ToInt16(initY * 100 / ViewSize) - moveObjectY);
				stimulusList[indexMoveObject].ConvertToDeg();
				moveObjectX = Convert.ToInt16(initX * 100 / ViewSize);
				moveObjectY = Convert.ToInt16(initY * 100 / ViewSize);
				UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);
			}
		}
		private void pnl_Draw_MouseDown(object sender, MouseEventArgs e)
		{
			if (drawSquare)
			{
				//Use Solid Brush for filling the graphic shapes
				SolidBrush sb = new SolidBrush(Color.FromArgb(int.Parse(Contrast_ET.Text), btn_PenColor.BackColor));
				Pen p = new Pen(SetTransparency(125, btn_PenColor.BackColor));
				//setting the width and height same for creating square.
				//Getting the width and Heigt value from Textbox(txt_ShapeSize)
				if (!FixationSelected)
				{
					ObjectProp stimulus = new ObjectProp();
					double widthd = double.Parse(txt_ShapeSize.Text);
					int width = Convert.ToInt16(ConvertPixelWidth(widthd));
					stimulus.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, width, filledSquareType, ActivePicB, true, btn_PenColor.BackColor);
					stimulus.SetContrastPts(int.Parse(Contrast_ET.Text));
					stimulus.ConvertToDeg();
					stimulusList.Add(stimulus);
					gr.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Height / 2, stimulus.Width, stimulus.Height);
					g.FillRectangle(sb, e.X - stimulus.Width * ViewSize / 200, e.Y - stimulus.Height * ViewSize / 200, stimulus.Width * ViewSize / 100, stimulus.Height * ViewSize / 100);
				}
				else
				{
					ObjectProp fixation = new ObjectProp();
					double widthd = double.Parse(txt_ShapeSize.Text);
					int width = Convert.ToInt16(ConvertPixelWidth(widthd));
					fixation.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, width, SquareType, ActivePicB, true, btn_PenColor.BackColor);
					fixation.ConvertToDeg();
					fixation.Time = int.Parse(txb_fixationtime.Text);
					fixationList[ActivePicB - 1] = fixation;

					UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);

					//gr.DrawRectangle(p, fixation.Xloc - fixation.Width / 2, fixation.Yloc - fixation.Height / 2, fixation.Width, fixation.Height);
					//g.DrawRectangle(p, e.X - fixation.Width * ViewSize / 200, e.Y - fixation.Height * ViewSize / 200, fixation.Width * ViewSize / 100, fixation.Height * ViewSize / 100);

					Reward[ActivePicB - 1] = 0;
					txb_fixationtime.Text = Convert.ToString(fixationList[ActivePicB - 1].Time);
					txb_fixationtime.Enabled = true;
				}

				//setting startPaint and drawSquare value to false for creating one graphic on one click.
				startPaint = false;
				drawSquare = false;
			}
			else if (drawRectangle)
			{
				SolidBrush sb = new SolidBrush(Color.FromArgb(int.Parse(Contrast_ET.Text), btn_PenColor.BackColor));
				Pen p = new Pen(SetTransparency(125, btn_PenColor.BackColor));
				//setting the width twice of the height
				if (!FixationSelected)
				{
					ObjectProp stimulus = new ObjectProp();
					double widthd = double.Parse(txt_ShapeSize.Text);
					int width = Convert.ToInt16(ConvertPixelWidth(widthd));
					stimulus.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), 2 * width, width, filledRectangleType, ActivePicB, true, btn_PenColor.BackColor);
					stimulus.SetContrastPts(int.Parse(Contrast_ET.Text));
					stimulus.ConvertToDeg();
					stimulusList.Add(stimulus);
					gr.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Height / 2, stimulus.Width, stimulus.Height);
					g.FillRectangle(sb, e.X - stimulus.Width * ViewSize / 200, e.Y - stimulus.Height * ViewSize / 200, stimulus.Width * ViewSize / 100, stimulus.Height * ViewSize / 100);
				}
				else
				{
					ObjectProp fixation = new ObjectProp();
					double widthd = double.Parse(txt_ShapeSize.Text);
					int width = Convert.ToInt16(ConvertPixelWidth(widthd));
					fixation.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), 2 * width, width, RectangleType, ActivePicB, true, btn_PenColor.BackColor);
					fixation.ConvertToDeg();
					fixationList[ActivePicB - 1] = fixation;
					fixation.Time = int.Parse(txb_fixationtime.Text);
					UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);

					Reward[ActivePicB - 1] = 0;
					txb_fixationtime.Text = Convert.ToString(fixationList[ActivePicB - 1].Time);
					txb_fixationtime.Enabled = true;
				}

				startPaint = false;
				drawRectangle = false;
			}
			else if (drawCircle)
			{
				SolidBrush sb = new SolidBrush(Color.FromArgb(int.Parse(Contrast_ET.Text), btn_PenColor.BackColor));
				Pen p = new Pen(SetTransparency(125, btn_PenColor.BackColor));
				if (!FixationSelected)
				{
					ObjectProp stimulus = new ObjectProp();
					double widthd = double.Parse(txt_ShapeSize.Text);
					int width = Convert.ToInt16(ConvertPixelWidth(widthd));
					stimulus.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, width, filledCircleType, ActivePicB, true, btn_PenColor.BackColor);
					stimulus.SetContrastPts(int.Parse(Contrast_ET.Text));
					stimulus.ConvertToDeg();
					stimulusList.Add(stimulus);
					gr.FillEllipse(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Height / 2, stimulus.Width, stimulus.Height);
					g.FillEllipse(sb, e.X - stimulus.Width * ViewSize / 200, e.Y - stimulus.Height * ViewSize / 200, stimulus.Width * ViewSize / 100, stimulus.Height * ViewSize / 100);
				}
				else
				{
					ObjectProp fixation = new ObjectProp();
					double widthd = double.Parse(txt_ShapeSize.Text);
					int width = Convert.ToInt16(ConvertPixelWidth(widthd));

					fixation.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, width, CircleType, ActivePicB, true, btn_PenColor.BackColor);
					fixation.ConvertToDeg();
					fixationList[ActivePicB - 1] = fixation;
					fixation.Time = int.Parse(txb_fixationtime.Text);
					UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);

					Reward[ActivePicB - 1] = 0;
					txb_fixationtime.Text = Convert.ToString(fixationList[ActivePicB - 1].Time);
					txb_fixationtime.Enabled = false;
				}

				startPaint = false;
				drawCircle = false;
			}
			else if (drawImage)
			{
				ObjectProp stimulus = new ObjectProp();
				double widthd = double.Parse(ImageWidth_TB.Text);
				int width = Convert.ToInt16(ConvertPixelWidth(widthd));

				double heightd = double.Parse(Imageheight_TB.Text);
				int height = Convert.ToInt16(ConvertPixelHeight(heightd));

				stimulus.SetPicture(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, height, PictureType, ActivePicB, true, ImagePath);
				stimulus.ConvertToDeg();
				stimulusList.Add(stimulus);
				Bitmap bmpvar = new Bitmap(stimulus.PathPic);
				bmpvar = new Bitmap(bmpvar, new Size(stimulus.Width, stimulus.Height));
				gr.DrawImage(bmpvar, new Point(stimulus.Xloc - width / 2, stimulus.Yloc - height / 2));
				bmpvar = new Bitmap(bmpvar, new Size(Convert.ToInt16(stimulus.Width * ViewSize / 100), Convert.ToInt16(stimulus.Height * ViewSize / 100)));
				g.DrawImage(bmpvar, new Point(e.X - Convert.ToInt16(width * ViewSize / 200), Convert.ToInt16(e.Y - height * ViewSize / 200)));
				startPaint = false;
				drawImage = false;
			}
			else
			{
				int x = Convert.ToInt16(e.X * 100 / ViewSize);  //A: why 100/viewsize  ?!
				int y = Convert.ToInt16(e.Y * 100 / ViewSize);
				double Mindis = 0;
				for (int i = 0; i < stimulusList.Count; i++)
				{
					double dis = Math.Sqrt((stimulusList[i].Xloc - x) * (stimulusList[i].Xloc - x) + (stimulusList[i].Yloc - y) * (stimulusList[i].Yloc - y));
					if (dis < stimulusList[i].Width)
					{
						moveObject = true;
						moveObjectX = x;
						moveObjectY = y;
						indexMoveObject = i;
						if (i == 0)
						{
							Mindis = dis;
						}
						else
						{
							if (dis < Mindis)
							{
								Mindis = dis;
								indexMoveObject = i;
							}
						}
					}



				}
			}

			UpdateTreeView(ActivePicB - 1);
			
			tb_toolbar.SelectedIndex = 0;
			this.BackColor= Color.Transparent;
			this.Enabled = false;
			//tb_addpics.BackColor = Color.Transparent; //A: because it seems i can not modify the enable of the tab like this..so I didnt used this way.
			//tb_addpics.En
			tb_toolbar.SelectedIndex = 1;
			this.BackColor = Color.Transparent;
			this.Enabled = false;
			Bitmap objBitmap = new Bitmap(BitmapPicB[ActivePicB - 1], new Size(PicB1.Width, PicB1.Height));
			PictureBox picb = panel1.Controls.Find("PicB" + ActivePicB, true).FirstOrDefault() as PictureBox;
			picb.Image = objBitmap;

		}
		private void BgColor_BT_Click(object sender, EventArgs e)      
		{
			ColorDialog c = new ColorDialog();
			if (c.ShowDialog() == DialogResult.OK)  
			{
				g.Clear(c.Color);
				BgColor_BT.BackColor = c.Color;
				gr.Clear(c.Color);

				frameList[ActivePicB - 1].frameColor = c.Color;
				UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);  //A: update the whole task
			}
		}
	
		private void pnl_Draw_MouseUp(object sender, MouseEventArgs e)
		{
			startPaint = false;
			initX = null;
			initY = null;

			moveObject = false;
			moveObjectX = 0;
			moveObjectY = 0;
			indexMoveObject = -1;
		}

		private void tb_toolbar_Selecting(object sender, TabControlCancelEventArgs e)
		{
			if (tb_toolbar.SelectedTab == tb_toolbar.TabPages["tb_addshapes"])   //A:if it doesnt work try to use the sender index instead
			{
				FixationSelected = false;
				pnl_shape.Enabled = true;
				SquareShape_BT.Enabled = true;
				RectangleShape_BT.Enabled = true;
				pnl_shape.BackColor = Color.Green;

			} 
			if (tb_toolbar.SelectedTab==tb_toolbar.TabPages["tb_addpics"])
			 {
				FixationSelected = false;
				pnl_pics.Enabled = true;
				pnl_pics.BackColor = Color.Green;
			}
			if(tb_toolbar.SelectedTab == tb_toolbar.TabPages["tb_finishsetting"]) 
			{
				
			}
			


		}  //A:stimulus and pic enable

		private void ChB_isfixation_CheckedChanged(object sender, EventArgs e)
		{
			if (ChB_isfixation.Checked)
			{
				FixationSelected = true;
				pnl_shape.Enabled = true;
				SquareShape_BT.Enabled = false;
				RectangleShape_BT.Enabled = false;
				txb_fixationtime.Enabled = true;
				pnl_shape.BackColor = Color.Green;
			}
		}    //A:fixation enable

		private void RectangleShape_BT_Click(object sender, EventArgs e)
		{
			drawRectangle = true;
		}

		private void SquareShape_BT_Click(object sender, EventArgs e)
		{
			drawSquare = true;
		}

		private void CircleShape_BT_Click(object sender, EventArgs e)
		{
			drawCircle = true;
		}

		private void t_addslide_Click(object sender, EventArgs e)
		{
			// Adding new PictureBox
			//StimulusPanel.Enabled = true;
			//FixationPanel.Enabled = true;

			PicBCnt++;
			int Yloc = t_addslide.Location.Y;
			ActivePicB = PicBCnt;
			SelectedPage_LB.Text = "Selected Page : " + Convert.ToString(ActivePicB);

			PictureBox PicB = new PictureBox();
			panel1.Controls.Add(PicB);
			PicB.Location = t_addslide.Location;
			PicB.Size = t_addslide.Size;
			PicB.Name = "PicB" + PicBCnt;
			PicB.Click += new System.EventHandler(this.PicB1_Click);  
			PicB.Visible = true;

			// Frame setting
			FrameProp newFrame = new FrameProp();
			frameList.Add(newFrame);
			txtb_monitorwidth.Text = Convert.ToString(frameList[ActivePicB - 1].frameWidth);
			txtb_monitorheight.Text = Convert.ToString(frameList[ActivePicB - 1].frameHeight);
			FrameTime_ET.Text = Convert.ToString(frameList[ActivePicB - 1].Time);

			// Fixation setting
			ObjectProp fixation = new ObjectProp();
			fixationList.Add(fixation);
			txb_fixationtime.Text = Convert.ToString(fixationList[ActivePicB - 1].Time);
			txb_fixationtime.Enabled = false;

			// Adding new Bitmap image to the list
			Bitmap bmpVar = new Bitmap(frameList[0].frameWidth, frameList[0].frameHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			BitmapPicB.Add(bmpVar);
			gr = Graphics.FromImage(BitmapPicB[ActivePicB - 1]);
			gr.Clear(Color.White);

			// setting blank Image to the picturebox 
			Bitmap objBitmap = new Bitmap(BitmapPicB[ActivePicB - 1], new Size(PicB.Width, PicB.Height));
			PicB.Image = objBitmap;

			// set blank image to the panel
			g.DrawImage(BitmapPicB[ActivePicB - 1], new PointF(0, 0));

			Reward.Add(0);
			DeletedFrames.Add(0);
			RepeatedFrame.Add(0);
			RepeatationLength.Add(0);
			RepeatedRandomLocation.Add(0);
			// Change the location of Add-Picturebox
			t_addslide.Location = new Point(t_addslide.Location.X, t_addslide.Location.Y + t_addslide.Size.Height + 15);
			UpdateTreeView(ActivePicB - 1);
		}  //adding new slide

		private void PicB1_Click(object sender, EventArgs e)
		{
			
			MouseEventArgs me = (MouseEventArgs)e;
			switch (me.Button)
			{
				case MouseButtons.Right:
					Popup.Show(Cursor.Position);
					break;
				case MouseButtons.Left:
					break;
			}
			String PicBName = ((PictureBox)sender).Name;
			// Get position of the button that has been clicked
			int index = 0;
			index = int.Parse(Regex.Match(PicBName, @"\d+").Value);
			ActivePicB = index;
			SelectedPage_LB.Text = "Selected Page : " + Convert.ToString(ActivePicB);
			Bitmap objBitmap = new Bitmap(BitmapPicB[ActivePicB - 1], new Size(PicB1.Width, PicB1.Height));

			PictureBox picb = panel1.Controls.Find("PicB" + ActivePicB, true).FirstOrDefault() as PictureBox;
			picb.Image = objBitmap;

			FrameTime_ET.Text = Convert.ToString(frameList[ActivePicB - 1].Time);
			txb_fixationtime.Text = Convert.ToString(fixationList[ActivePicB - 1].Time);
			gr = Graphics.FromImage(BitmapPicB[ActivePicB - 1]);

			txb_fixationtime.Text = Convert.ToString(fixationList[ActivePicB - 1].Time);
			BgColor_BT.BackColor = frameList[ActivePicB - 1].frameColor;

			if (fixationList[ActivePicB - 1].Type == 1)
				txb_fixationtime.Enabled = true;
			else
				txb_fixationtime.Enabled = false;
			Debug.Write("Debug Rew: " + Reward[ActivePicB - 1] + "\n");
			//SelectRewardType_CB.SelectedIndex = Reward[ActivePicB - 1];
			RewardType_LB.Text = Reward[ActivePicB - 1].ToString();
			UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);
			UpdateTreeView(ActivePicB - 1);
		}

		private void btn_browse_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			string PictureFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			ofd.InitialDirectory = PictureFolder;
			ofd.Title = "Pick a picture; any picture";
			ofd.CustomPlaces.Add(@"C:\");
			ofd.CustomPlaces.Add(@"C:\Program Files\");
			ofd.CustomPlaces.Add(@"K:\Documents\Pictures\");
			//ofd.Multiselect = true;
			ofd.Filter = "Pictures|*.jpg; *.bmp; *.png|Documents|*.txt; *.doc; *.log|All|*.*";
			System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				//userSelectedFilePath = ofd.FileName;
				foreach (string fileName in ofd.FileNames)
				{
					ImagePath = fileName;
					break;
				}
			}
			drawImage = true;
			txtb_browsepath.Text = ImagePath;
		}

		private void pb_finish_Click(object sender, EventArgs e)
		{
			FrameProperties[] AddedFrame = new FrameProperties[PicBCnt];
			List<Basics.FrameProperties> ListAddedFrame = new List<Basics.FrameProperties>();

			for (int i = 0; i < PicBCnt; i++)
			{
				AddedFrame[i] = new FrameProperties();
				if (DeletedFrames[i] == 1)
					continue;

				int NumStimulus = 0;
				for (int j = 0; j < stimulusList.Count; j++)
				{
					if (stimulusList[j].FrameIndex == i + 1)   //A:why i+1 ? how does he know that its always lower than the PicBCnt ??? 
						NumStimulus++;                         //A: asan why counts the stimulus? it can use stimulus.count !!!
				}

				FixationPts[] StimulusVar = new FixationPts[NumStimulus];
				int indexVar = 0;
				for (int j = 0; j < stimulusList.Count; j++)
				{
					if (indexVar < NumStimulus)
						StimulusVar[indexVar] = new FixationPts();
					if (stimulusList[j].FrameIndex == i + 1)
					{
						if (stimulusList[j].Type != 4 && stimulusList[j].Type != 8 && stimulusList[j].Type != 12)  //A: what are type 8,12 ?!
						{
							StimulusVar[indexVar].SetFixationPts(stimulusList[j].Xloc, stimulusList[j].Yloc, stimulusList[j].Width, stimulusList[j].Width, stimulusList[j].Type, stimulusList[j].ColorPt);
							StimulusVar[indexVar].SetContrastPts(stimulusList[j].Contrast);
						}
						else
							StimulusVar[indexVar].SetPicture(stimulusList[j].Xloc, stimulusList[j].Yloc, stimulusList[j].Width, stimulusList[j].Height, stimulusList[j].Type, stimulusList[j].PathPic);
						indexVar++;
					}
				}
				FixationPts FixationVar = new FixationPts();
				FixationVar.SetFixationPts(fixationList[i].Xloc, fixationList[i].Yloc, fixationList[i].Width, fixationList[i].Height, fixationList[i].Type, fixationList[i].ColorPt);

				List<ShowFr> BoxesList = new List<ShowFr>();
				for (int k = 0; k < ShowBoxes.Count; k++)
				{
					if (FrameIndexes[k] == i + 1)
					{
						ShowFr VarShowFr = new ShowFr();
						VarShowFr.SetShowFrameProp(ShowBoxes[k].CenterX, ShowBoxes[k].CenterY, ShowBoxes[k].Width, ShowBoxes[k].Height, 20, ShowBoxes[k].ColorBox);
						BoxesList.Add(VarShowFr);
					}
				}

				ShowFr[] ShowFrameArray;
				int numbox = 1;
				if (BoxesList.Count > 0)
				{
					numbox = BoxesList.Count;
					ShowFrameArray = new ShowFr[BoxesList.Count];
				}
				else
				{
					numbox = 1;
					ShowFrameArray = new ShowFr[1];
					ShowFrameArray[0] = new ShowFr();
				}
				for (int k = 0; k < BoxesList.Count; k++)
				{
					ShowFrameArray[k] = new ShowFr();
					ShowFrameArray[k].SetShowFrameProp(BoxesList[k].CenterX, BoxesList[k].CenterY, BoxesList[k].Width, BoxesList[k].Height, BoxesList[k].Thickness, BoxesList[k].ColorBox);
				}

				HintForm VarHint = new HintForm();
				for (int k = 0; k < AddedHintsbyFrameTool.Count; k++)
				{
					if (HintIndexes[k] == i + 1)
					{
						if (AddedHintsbyFrameTool[k].BoxRatio == 1)
						{
							VarHint.SetArrowProp(AddedHintsbyFrameTool[k].ArrowLocY, AddedHintsbyFrameTool[k].ArrowLocX0, AddedHintsbyFrameTool[k].ArrowLocX1, AddedHintsbyFrameTool[k].Valid, AddedHintsbyFrameTool[k].ArrowColor);
							VarHint.type = AddedHintsbyFrameTool[k].type;
							VarHint.ArrowWidth = AddedHintsbyFrameTool[k].ArrowWidth;
						}
						if (AddedHintsbyFrameTool[k].BoxRatio != 1)
						{
							VarHint.SetBoxProp(1, AddedHintsbyFrameTool[k].BoxRatio, AddedHintsbyFrameTool[k].BoxColor);
							VarHint.type = AddedHintsbyFrameTool[k].type;
						}
					}
				}

				//AddedFrame[i].SetProperties(frameList[i].frameColor, frameList[i].Time, FixationVar, fixationList[i].Time, NumStimulus, StimulusVar, Reward[i], VarHint, numbox, ShowFrameArray, frameList[i].);

				if (RepeatedFrame[i] > 0)
					AddedFrame[i].RepeatInfo.SetProperties(true, RepeatedFrame[i], RepeatationLength[i], RepeatedRandomLocation[i]);
				else
					AddedFrame[i].RepeatInfo.SetProperties(false, RepeatedFrame[i], RepeatationLength[i], RepeatedRandomLocation[i]);
			}

			for (int i = 0; i < AddedFrame.Length; i++)
			{
				if (DeletedFrames[i] == 1)
					continue;
				ListAddedFrame.Add(AddedFrame[i]);
			}
			if (Mode == 1)
			{
				if (TaskPreviewM.AllLevelProp.Count == TaskPreviewM.ActiveCol)
				{
					for (int i = 0; i < PicBCnt; i++)
						TaskPreviewM.AllLevelProp[TaskPreviewM.ActiveCol - 1].Add(ListAddedFrame[i]);
				}
				else
					TaskPreviewM.AllLevelProp.Add(ListAddedFrame);

				TaskPreviewM.EnabledTask[TaskPreviewM.AllLevelProp.Count - 1] = 2;   //A:error here by clicking the tick?! fixxxxxxxx it!
			}
			else if (Mode == 2)
			{
				TaskPreviewM.AllLevelProp[EditedIndex].Clear();
				TaskPreviewM.AllLevelProp[EditedIndex] = ListAddedFrame;
				TaskPreviewM.ChangeHappened = true;
				TaskPreviewM.EnabledTask[EditedIndex] = 2;
			}

			TaskPreviewM.ChangeHappened = true;
			this.Close();
		}   //Finishing off click

		private void FrameTime_ET_TextChanged(object sender, EventArgs e)
		{
			if (ActivePicB > 0)
				frameList[ActivePicB - 1].Time = int.Parse(FrameTime_ET.Text);
		}

		private void txbx_taskname_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtbx_path2save_Click(object sender, EventArgs e)
		{

		}

		private void Objects_TV_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Level == 0)
				return;
			String Name = e.Node.Text;
			char IdName = Name[0];
			if (IdName == 'F')
			{
				MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm();
				prompt.ShowIcon = false;
				prompt.Name = "FixationForm";
				prompt.Width = 250;
				prompt.Height = 190;
				prompt.Text = "Fixation Edit Panel";
				Label SizeLabel = new Label() { Left = 30, Top = 20, Height = 15, Text = "Size :" };
				TextBox SizeTextBox = new TextBox { Left = 160, Top = 20, Width = 40, Text = Convert.ToString(fixationList[ActivePicB - 1].Widthd) };
				SizeTextBox.TextChanged += delegate { this.FixationEditWidth(ActivePicB - 1, SizeTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
				Label XLabel = new Label() { Left = 30, Top = 40, Height = 15, Text = "X :" };
				TextBox XTextBox = new TextBox { Left = 160, Top = 40, Width = 40, Text = Convert.ToString(fixationList[ActivePicB - 1].Xlocd) };
				XTextBox.TextChanged += delegate { this.FixationEditX(ActivePicB - 1, XTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
				Label YLabel = new Label() { Left = 30, Top = 60, Height = 15, Text = "Y :" };
				TextBox YTextBox = new TextBox { Left = 160, Top = 60, Width = 40, Text = Convert.ToString(fixationList[ActivePicB - 1].Ylocd) };
				YTextBox.TextChanged += delegate { this.FixationEditY(ActivePicB - 1, YTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
				Label TimeLabel = new Label() { Left = 30, Top = 80, Height = 15, Text = "Fixation Time :" };
				TextBox TimeTextBox = new TextBox { Left = 160, Top = 80, Width = 40, Text = Convert.ToString(fixationList[ActivePicB - 1].Time) };
				TimeTextBox.TextChanged += delegate { this.FixationEditTime(ActivePicB - 1, TimeTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
				Button RemoveButton = new Button { Left = 75, Top = 120, Width = 80, Text = Convert.ToString("Remove") };
				RemoveButton.Click += delegate { this.FixationRemove(ActivePicB - 1); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); UpdateTreeView(ActivePicB - 1); prompt.Close(); };

				prompt.Controls.Add(SizeLabel);
				prompt.Controls.Add(SizeTextBox);
				prompt.Controls.Add(XLabel);
				prompt.Controls.Add(XTextBox);
				prompt.Controls.Add(YLabel);
				prompt.Controls.Add(YTextBox);
				prompt.Controls.Add(TimeLabel);
				prompt.Controls.Add(TimeTextBox);
				prompt.Controls.Add(RemoveButton);
				prompt.Show();
				prompt.BringToFront();
			}

			if (IdName == 'S')
			{
				int IdIndex = int.Parse(Regex.Match(Name, @"\d+").Value);

				MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm();
				prompt.ShowIcon = false;
				prompt.Name = "StimulusForm";
				prompt.Width = 250;
				prompt.Height = 300;
				prompt.Text = "Stimulus Edit Panel";
				//Width
				Label SizeWLabel = new Label() { Left = 30, Top = 20, Text = "Size :" };
				TextBox SizeWTextBox = new TextBox { Left = 160, Top = 20, Width = 40, Text = Convert.ToString(stimulusList[IdIndex].Widthd) };
				SizeWTextBox.TextChanged += delegate { this.StimulusEditWidth(IdIndex, SizeWTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
				//Height
				Label SizeHLabel = new Label() { Left = 30, Top = 50, Text = "Size :" };
				TextBox SizeHTextBox = new TextBox { Left = 160, Top = 50, Width = 40, Text = Convert.ToString(stimulusList[IdIndex].Heightd) };
				SizeHTextBox.TextChanged += delegate { this.StimulusEditHeight(IdIndex, SizeHTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
				//X
				Label XLabel = new Label() { Left = 30, Top = 80, Text = "X :" };
				TextBox XTextBox = new TextBox { Left = 160, Top = 80, Width = 40, Text = Convert.ToString(stimulusList[IdIndex].Xlocd) };
				XTextBox.TextChanged += delegate { this.StimulusEditX(IdIndex, XTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
				//Y
				Label YLabel = new Label() { Left = 30, Top = 110, Text = "Y :" };
				TextBox YTextBox = new TextBox { Left = 160, Top = 110, Width = 40, Text = Convert.ToString(stimulusList[IdIndex].Ylocd) };
				YTextBox.TextChanged += delegate { this.StimulusEditY(IdIndex, YTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };

				if (stimulusList[IdIndex].Type == 4 || stimulusList[IdIndex].Type == 8 || stimulusList[IdIndex].Type == 12)
				{
					prompt.Height = 270;
					//Path
					Label PathLabel = new Label() { Left = 30, Top = 140, Width = 40, Text = "Path :" };
					TextBox PathTextBox = new TextBox { Left = 75, Top = 140, Width = 120, Text = Convert.ToString(stimulusList[IdIndex].PathPic) };
					Button PathButton = new Button() { Left = 200, Top = 140, Width = 30, Height = PathTextBox.Height, Text = "..." };
					PathButton.Click += delegate { string VarPath = this.StimulusEditPath(IdIndex); PathTextBox.Text = VarPath; this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };

					Button RemoveButton = new Button { Left = 85, Top = 180, Width = 80, Text = Convert.ToString("Remove") };
					RemoveButton.Click += delegate { this.StimulusRemove(IdIndex); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); UpdateTreeView(ActivePicB - 1); prompt.Close(); };

					prompt.Controls.Add(SizeWLabel);
					prompt.Controls.Add(SizeWTextBox);
					prompt.Controls.Add(SizeHLabel);
					prompt.Controls.Add(SizeHTextBox);
					prompt.Controls.Add(XLabel);
					prompt.Controls.Add(XTextBox);
					prompt.Controls.Add(YLabel);
					prompt.Controls.Add(YTextBox);
					prompt.Controls.Add(PathLabel);
					prompt.Controls.Add(PathButton);
					prompt.Controls.Add(PathTextBox);
					prompt.Controls.Add(RemoveButton);
				}
				else
				{
					//Color
					Label ColorLabel = new Label() { Left = 30, Top = 140, Text = "Color :" };
					Button ColorButton = new Button() { Left = 160, Top = 135, Width = 30, Height = 30, BackColor = stimulusList[IdIndex].ColorPt };
					ColorButton.Click += delegate { this.StimulusEditColor(IdIndex); ColorButton.BackColor = stimulusList[IdIndex].ColorPt; this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
					//Contrast
					Label ContrastLabel = new Label() { Left = 30, Top = 170, Text = "Contrast :" };
					TextBox ContrastTextBox = new TextBox { Left = 160, Top = 170, Width = 40, Text = Convert.ToString(stimulusList[IdIndex].Contrast) };
					ContrastTextBox.TextChanged += delegate { this.StimulusEditContrast(IdIndex, ContrastTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };

					Button RemoveButton = new Button { Left = 85, Top = 210, Width = 80, Text = Convert.ToString("Remove") };
					RemoveButton.Click += delegate { this.StimulusRemove(IdIndex); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); UpdateTreeView(ActivePicB - 1); prompt.Close(); };

					prompt.Controls.Add(SizeWLabel);
					prompt.Controls.Add(SizeWTextBox);
					prompt.Controls.Add(SizeHLabel);
					prompt.Controls.Add(SizeHTextBox);
					prompt.Controls.Add(XLabel);
					prompt.Controls.Add(XTextBox);
					prompt.Controls.Add(YLabel);
					prompt.Controls.Add(YTextBox);
					prompt.Controls.Add(ColorLabel);
					prompt.Controls.Add(ColorButton);
					prompt.Controls.Add(ContrastLabel);
					prompt.Controls.Add(ContrastTextBox);
					prompt.Controls.Add(RemoveButton);
				}
				prompt.Show();
			}

			if (IdName == 'H')
			{
				int IdIndex = int.Parse(Regex.Match(Name, @"\d+").Value);

				MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm();
				prompt.ShowIcon = false;
				prompt.Name = "HintForm";
				prompt.Width = 250;

				prompt.Text = "Hint Edit Panel";
				//Type
				if (AddedHintsbyFrameTool[IdIndex].type == 1)
				{
					prompt.Height = 250;

					//X0
					Label X0ArrowLabel = new Label() { Left = 30, Top = 30, Text = "X :" };
					TextBox X0ArrowTextBox = new TextBox { Left = 160, Top = 30, Width = 40, Text = Convert.ToString(AddedHintsbyFrameTool[IdIndex].ArrowLocX0 + AddedHintsbyFrameTool[IdIndex].ArrowWidth) };
					X0ArrowTextBox.TextChanged += delegate { this.HintEditX0(IdIndex, X0ArrowTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };

					//Y
					Label YLabel = new Label() { Left = 30, Top = 60, Text = "Y :" };
					TextBox YTextBox = new TextBox { Left = 160, Top = 60, Width = 40, Text = Convert.ToString(AddedHintsbyFrameTool[IdIndex].ArrowLocY) };
					YTextBox.TextChanged += delegate { this.HintEditY(IdIndex, YTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };

					//Width
					Label WidthLabel = new Label() { Left = 30, Top = 90, Text = "Width :" };
					TextBox WidthTextBox = new TextBox { Left = 160, Top = 90, Width = 40, Text = Convert.ToString(AddedHintsbyFrameTool[IdIndex].ArrowWidth) };
					WidthTextBox.TextChanged += delegate { this.HintEditWidth(IdIndex, YTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
					WidthTextBox.Enabled = false;
					//Color
					Label ColorLabel = new Label() { Left = 30, Top = 120, Text = "Color :" };
					Button ColorButton = new Button() { Left = 160, Top = 120, Width = 30, Height = 30, BackColor = AddedHintsbyFrameTool[IdIndex].ArrowColor };
					ColorButton.Click += delegate { this.HintEditColor(IdIndex); ColorButton.BackColor = AddedHintsbyFrameTool[IdIndex].ArrowColor; this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };

					prompt.Controls.Add(X0ArrowLabel);
					prompt.Controls.Add(X0ArrowTextBox);
					prompt.Controls.Add(YLabel);
					prompt.Controls.Add(WidthLabel);
					prompt.Controls.Add(YTextBox);
					prompt.Controls.Add(WidthTextBox);
					prompt.Controls.Add(ColorLabel);
					prompt.Controls.Add(ColorButton);

				}

				//Type
				if (AddedHintsbyFrameTool[IdIndex].type == 2)
				{
					prompt.Height = 150;
					//Ratio
					Label RatioBoxLabel = new Label() { Left = 30, Top = 30, Text = "Ratio :" };
					TextBox RatioBoxTextBox = new TextBox { Left = 160, Top = 30, Width = 40, Text = Convert.ToString(AddedHintsbyFrameTool[IdIndex].BoxRatio) };
					RatioBoxTextBox.TextChanged += delegate { this.HintEditRatio(IdIndex, RatioBoxTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList); };
					prompt.Controls.Add(RatioBoxLabel);
					prompt.Controls.Add(RatioBoxTextBox);

				}
				prompt.Show();
			}
		}
		
		private void b_condition_Click(object sender, EventArgs e)
		{
			FixationSetting FixationSettingForm = new FixationSetting(Reward[ActivePicB - 1], ActivePicB - 1);
			FixationSettingForm.Show();
			FixationSettingForm.FormClosing += delegate {
				UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);
				UpdateTreeView(ActivePicB - 1);
				RewardType_LB.Text = Reward[ActivePicB - 1].ToString();
			};
		}

		static Color SetTransparency(int A, Color color)  

		{
			return Color.FromArgb(A, color.R, color.G, color.B);
		}   //A:extract RGB and alpha
		private void UpdateFrame(int index, List<FrameProp> FrameObjs, List<ObjectProp> FixationObjs, List<ObjectProp> StimulusObjs) 
		{
			if (index < 0)
				return;
			g.Clear(FrameObjs[index].frameColor);
			gr.Clear(FrameObjs[index].frameColor);

			for (int i = 0; i < ShowBoxes.Count; i++)
			{
				if (FrameIndexes[i] == index + 1)
				{
					Pen boxp = new Pen(ShowBoxes[i].ColorBox, ShowBoxes[i].Thickness);
					gr.DrawRectangle(boxp, ShowBoxes[i].CenterX - ShowBoxes[i].Width / 2, ShowBoxes[i].CenterY - ShowBoxes[i].Height / 2, ShowBoxes[i].Width, ShowBoxes[i].Height);
					g.DrawRectangle(boxp, (ShowBoxes[i].CenterX - ShowBoxes[i].Width / 2) * ViewSize / 100, (ShowBoxes[i].CenterY - ShowBoxes[i].Height / 2) * ViewSize / 100, (ShowBoxes[i].Width) * ViewSize / 100, (ShowBoxes[i].Height) * ViewSize / 100);
				}
			}

			for (int i = 0; i < AddedHintsbyFrameTool.Count; i++)
			{
				if (FrameIndexes[i] == index + 1)
				{
					Graphics graphic = Graphics.FromImage(BitmapPicB[HintIndexes[i] - 1]);

					if (AddedHintsbyFrameTool[i].BoxRatio == 1)
					{
						Pen pen = new Pen(AddedHintsbyFrameTool[i].ArrowColor, AddedHintsbyFrameTool[i].ArrowWidth);
						pen.StartCap = LineCap.ArrowAnchor;
						gr.DrawLine(pen, AddedHintsbyFrameTool[i].ArrowLocX0, AddedHintsbyFrameTool[i].ArrowLocY, AddedHintsbyFrameTool[i].ArrowLocX1, AddedHintsbyFrameTool[i].ArrowLocY);
						pen = new Pen(AddedHintsbyFrameTool[i].ArrowColor, (AddedHintsbyFrameTool[i].ArrowWidth) * ViewSize / 100);
						pen.StartCap = LineCap.ArrowAnchor;
						g.DrawLine(pen, (AddedHintsbyFrameTool[i].ArrowLocX0) * ViewSize / 100, (AddedHintsbyFrameTool[i].ArrowLocY) * ViewSize / 100, (AddedHintsbyFrameTool[i].ArrowLocX1) * ViewSize / 100, (AddedHintsbyFrameTool[i].ArrowLocY) * ViewSize / 100);

					}
				}
			}


			for (int i = 0; i < StimulusObjs.Count; i++)
			{

				if (StimulusObjs[i].FrameIndex != index + 1)
					continue;

				//Use Solid Brush for filling the graphic shapes
				SolidBrush sb = new SolidBrush(Color.FromArgb(StimulusObjs[i].Contrast, StimulusObjs[i].ColorPt));

				if (StimulusObjs[i].Type == 1 || StimulusObjs[i].Type == 5 || StimulusObjs[i].Type == 9)
				{
					g.FillRectangle(sb, (StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100, (StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2) * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100);
					gr.FillRectangle(sb, StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Width, StimulusObjs[i].Width);
				}

				if (StimulusObjs[i].Type == 2)
				{
					g.FillRectangle(sb, (StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100, (StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2) * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100);
					gr.FillRectangle(sb, StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Width, StimulusObjs[i].Width);
				}

				if (StimulusObjs[i].Type == 3 || StimulusObjs[i].Type == 7 || StimulusObjs[i].Type == 11)
				{
					g.FillEllipse(sb, (StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100, (StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2) * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100);
					gr.FillEllipse(sb, StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Width, StimulusObjs[i].Width);
				}

				if (StimulusObjs[i].Type == 4 || StimulusObjs[i].Type == 8 || StimulusObjs[i].Type == 12)
				{
					//Bitmap bmpvar = new Bitmap(StimulusObjs[i].PathPic);
					try
					{
						if (File.Exists(StimulusObjs[i].PathPic))
						{
							bmpvarforUpdate = new Bitmap(StimulusObjs[i].PathPic);
							bmpvarforUpdate = new Bitmap(bmpvarforUpdate, new Size(StimulusObjs[i].Width, StimulusObjs[i].Height));
							gr.DrawImage(bmpvarforUpdate, new Point(StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Height / 2));
							bmpvarforUpdate = new Bitmap(bmpvarforUpdate, new Size(Convert.ToInt16(StimulusObjs[i].Width * ViewSize / 100), Convert.ToInt16(StimulusObjs[i].Height * ViewSize / 100)));
							g.DrawImage(bmpvarforUpdate, new Point(Convert.ToInt16((StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100), Convert.ToInt16((StimulusObjs[i].Yloc - StimulusObjs[i].Height / 2) * ViewSize / 100)));
						}
						bmpvarforUpdate.Dispose();
					}
					catch (OutOfMemoryException)
					{

					}

				}

			}


			//Debug.Write("FixTime#$% : " + fixationList[0].Time + "\n");
			//Debug.Write("FixTime#$% : " + fixationList[1].Time + "\n");
			if (FixationObjs[index].Enable)
			{
				Pen boxp = new Pen(fixationList[index].ColorPt);
				switch (fixationList[index].Type)
				{
					case 1:
						gr.DrawRectangle(boxp, fixationList[index].Xloc - fixationList[index].Width / 2, fixationList[index].Yloc - fixationList[index].Width / 2, fixationList[index].Width, fixationList[index].Width);
						g.DrawRectangle(boxp, (fixationList[index].Xloc - fixationList[index].Width / 2) * ViewSize / 100, (fixationList[index].Yloc - fixationList[index].Width / 2) * ViewSize / 100, (fixationList[index].Width) * ViewSize / 100, (fixationList[index].Width) * ViewSize / 100);
						break;
					case 3:
					case 7:
						gr.DrawEllipse(boxp, fixationList[index].Xloc - fixationList[index].Width / 2, fixationList[index].Yloc - fixationList[index].Width / 2, fixationList[index].Width, fixationList[index].Width);
						g.DrawEllipse(boxp, (fixationList[index].Xloc - fixationList[index].Width / 2) * ViewSize / 100, (fixationList[index].Yloc - fixationList[index].Width / 2) * ViewSize / 100, fixationList[index].Width * ViewSize / 100, fixationList[index].Width * ViewSize / 100);
						break;
					default:
						break;
				}
				//txb_fixationtime.Text = Convert.ToString(fixationList[index].Time);
				//    Debug.Write("Fixate Timing "+ txb_fixationtime.Text + " " + fixationList[index].Time + " " + index + "\n");
				//    Debug.Write("FixTime#% : " + fixationList[0].Time + "\n");
				//    Debug.Write("FixTime#% : " + fixationList[1].Time + "\n");
			}

			// Add drawing commands here
			Bitmap objBitmap = new Bitmap(BitmapPicB[index], new Size(PicB1.Width, PicB1.Height));
			PictureBox picb = panel1.Controls.Find("PicB" + (index + 1), true).FirstOrDefault() as PictureBox;
			picb.Image = objBitmap;
		}
		private void UpdateTreeView(int index)
		{
			Objects_TV.Nodes[0].Nodes.Clear();
			Objects_TV.Nodes[0].Nodes.Add("Fx");

			Objects_TV.Nodes[1].Nodes.Clear();
			int id = 0;
			for (int i = 0; i < stimulusList.Count(); i++)
			{
				if (stimulusList[i].FrameIndex != index + 1)
					continue;
				id++;
				Objects_TV.Nodes[1].Nodes.Add("St" + i);
			}
			Objects_TV.Nodes[3].Nodes.Clear();
			for (int i = 0; i < AddedHintsbyFrameTool.Count(); i++)
			{
				if (HintIndexes[i] == index + 1)
				{
					Objects_TV.Nodes[3].Nodes.Add("Ht" + i);
				}
			}

		}
		private void LoadParameters(int index)
		{
			PicBCnt = TaskPreviewM.AllLevelProp[index].Count;
			for (int i = 0; i < PicBCnt; i++)
			{
				// Frame setting
				FrameProp newFrame = new FrameProp();
				newFrame.setFrameProp(newFrame.frameWidth, newFrame.frameHeight, TaskPreviewM.AllLevelProp[index][i].FrameTime, TaskPreviewM.AllLevelProp[index][i].BGColor);
				frameList.Add(newFrame);

				Reward.Add(TaskPreviewM.AllLevelProp[index][i].RewardType);
				DeletedFrames.Add(0);
				RepeatedFrame.Add(TaskPreviewM.AllLevelProp[index][i].RepeatInfo.RepeatationNumber);
				RepeatationLength.Add(TaskPreviewM.AllLevelProp[index][i].RepeatInfo.Length);
				RepeatedRandomLocation.Add(TaskPreviewM.AllLevelProp[index][i].RepeatInfo.RandomLocation);
			}

			for (int i = 0; i < PicBCnt; i++)
			{
				// Adding new Bitmap image to the list
				Bitmap bmpVar = new Bitmap(frameList[0].frameWidth, frameList[0].frameHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				BitmapPicB.Add(bmpVar);
				gr = Graphics.FromImage(BitmapPicB[i]);
				gr.Clear(Color.White);
			}

			// setting blank Image to the picturebox 
			Bitmap objBitmap = new Bitmap(BitmapPicB[0], new Size(PicB1.Width, PicB1.Height));
			PicB1.Image = objBitmap;

			for (int i = 1; i < PicBCnt; i++)
			{
				int Yloc = t_addslide.Location.Y;
				PictureBox PicB = new PictureBox();
				panel1.Controls.Add(PicB);
				PicB.Location = t_addslide.Location;
				PicB.Size = t_addslide.Size;
				PicB.Name = "PicB" + (i + 1);
				PicB.Click += new System.EventHandler(this.PicB1_Click);
				PicB.Visible = true;

				// setting blank Image to the picturebox 
				objBitmap = new Bitmap(BitmapPicB[i], new Size(PicB.Width, PicB.Height));
				PicB.Image = objBitmap;

				// Change the location of Add-Picturebox
				t_addslide.Location = new Point(t_addslide.Location.X, t_addslide.Location.Y + t_addslide.Size.Height + 15);
			}

			for (int i = 0; i < PicBCnt; i++)
			{
				ObjectProp fixationProp = new ObjectProp();
				fixationProp.SetFixationPts(TaskPreviewM.AllLevelProp[index][i].Fixation.Xloc, TaskPreviewM.AllLevelProp[index][i].Fixation.Yloc, TaskPreviewM.AllLevelProp[index][i].Fixation.Width, TaskPreviewM.AllLevelProp[index][i].Fixation.Height, TaskPreviewM.AllLevelProp[index][i].Fixation.Type, i + 1, true, TaskPreviewM.AllLevelProp[index][i].Fixation.ColorPt);
				fixationProp.Time = TaskPreviewM.AllLevelProp[index][i].FixationTime;
				fixationProp.ConvertToDeg();

				fixationList.Add(fixationProp);
				Debug.Write("FixTime : " + fixationProp.Time + " " + fixationList[i].Time + "\n");
			}

			for (int i = 0; i < PicBCnt; i++)
			{
				for (int j = 0; j < TaskPreviewM.AllLevelProp[index][i].NumberSaccade; j++)
				{
					ObjectProp stimulusProp = new ObjectProp();
					if (TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Type == 4 | TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Type == 8 | TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Type == 12)
					{
						stimulusProp.SetPicture(TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Xloc, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Yloc, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Width, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Height, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Type, i + 1, true, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].PathPic);
					}
					else
					{
						stimulusProp.SetProps(TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Xloc, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Yloc, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Width, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Height, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Type, i + 1, true, TaskPreviewM.AllLevelProp[index][i].Stimulus[j].ColorPt);
						stimulusProp.SetContrastPts(TaskPreviewM.AllLevelProp[index][i].Stimulus[j].Contrast);
					}
					stimulusProp.ConvertToDeg();
					stimulusList.Add(stimulusProp);
				}
			}

			for (int i = 0; i < PicBCnt; i++)
			{
				if (TaskPreviewM.AllLevelProp[index][i].ShowFrame.Length > 1)
				{
					for (int j = 0; j < TaskPreviewM.AllLevelProp[index][i].ShowFrame.Length; j++)
					{
						ShowFr varshowfr = new ShowFr();
						varshowfr.SetShowFrameProp(TaskPreviewM.AllLevelProp[index][i].ShowFrame[j].CenterX, TaskPreviewM.AllLevelProp[index][i].ShowFrame[j].CenterY, TaskPreviewM.AllLevelProp[index][i].ShowFrame[j].Width, TaskPreviewM.AllLevelProp[index][i].ShowFrame[j].Height, TaskPreviewM.AllLevelProp[index][i].ShowFrame[j].Thickness, TaskPreviewM.AllLevelProp[index][i].ShowFrame[j].ColorBox);
						ShowBoxes.Add(varshowfr);
						FrameIndexes.Add(i + 1);
					}
				}
			}

			for (int i = 0; i < PicBCnt; i++)
			{
				if (TaskPreviewM.AllLevelProp[index][i].Cue.type != 0)
				{
					HintForm varhintform = new HintForm();
					varhintform.SetArrowProp(TaskPreviewM.AllLevelProp[index][i].Cue.ArrowLocY, TaskPreviewM.AllLevelProp[index][i].Cue.ArrowLocX0, TaskPreviewM.AllLevelProp[index][i].Cue.ArrowLocX1, TaskPreviewM.AllLevelProp[index][i].Cue.Valid, TaskPreviewM.AllLevelProp[index][i].Cue.ArrowColor);
					varhintform.SetBoxProp(TaskPreviewM.AllLevelProp[index][i].Cue.BoxThickness, TaskPreviewM.AllLevelProp[index][i].Cue.BoxRatio, TaskPreviewM.AllLevelProp[index][i].Cue.BoxColor);
					varhintform.type = TaskPreviewM.AllLevelProp[index][i].Cue.type;
					varhintform.ArrowWidth = TaskPreviewM.AllLevelProp[index][i].Cue.ArrowWidth;
					AddedHintsbyFrameTool.Add(varhintform);
					HintIndexes.Add(i + 1);
				}
			}
			ActivePicB = PicBCnt;

			// Panel Graphic setting
			pnl_Draw.Size = new Size(Convert.ToInt16(frameList[0].frameWidth * (ViewSize / 100)), Convert.ToInt16(frameList[0].frameHeight * (ViewSize / 100)));
			g = pnl_Draw.CreateGraphics();

			for (int i = 0; i < PicBCnt; i++)
			{
				gr = Graphics.FromImage(BitmapPicB[i]);
				Debug.Write("before : " + fixationList[i].Time + " " + i + "\n");
				UpdateFrame(i, frameList, fixationList, stimulusList);
				Debug.Write("after : " + fixationList[i].Time + " " + i + "\n");
				UpdateTreeView(ActivePicB - 1);
			}
			//UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);
			pnl_Draw.BackgroundImage = new Bitmap(BitmapPicB[ActivePicB - 1], pnl_Draw.Size);
		}

		#region conversion
		private double ConvertDegreeX(int Xp)
		{
			double ValX = Math.Atan((Xp - TaskPreviewM.WidthP / 2) * TaskPreviewM.WidthM / (TaskPreviewM.WidthP * TaskPreviewM.userDistance));
			return ValX;
		}
		private double ConvertDegreeY(int Yp)
		{
			double ValY = Math.Atan((Yp - TaskPreviewM.HeightP / 2) * TaskPreviewM.HeightM / (TaskPreviewM.HeightP * TaskPreviewM.userDistance));
			return ValY;
		}
		private double ConvertDegreeWidth(int Xp)
		{
			double ValX = Math.Atan(Xp * PsycoPhysicTask.WidthM / (PsycoPhysicTask.WidthP * PsycoPhysicTask.userDistance));
			Debug.Write(" Xp: " + Xp + " WidthP : " + PsycoPhysicTask.WidthP + " WidthM:" + PsycoPhysicTask.WidthM + " userDistance:" + PsycoPhysicTask.userDistance + " " + ((Xp - PsycoPhysicTask.WidthP / 2) * PsycoPhysicTask.WidthM / (PsycoPhysicTask.WidthP * PsycoPhysicTask.userDistance)) + "\n");
			return ValX;
		}
		private double ConvertDegreeHeight(int Yp)
		{
			double ValY = Math.Atan(Yp * PsycoPhysicTask.HeightM / (PsycoPhysicTask.HeightP * PsycoPhysicTask.userDistance));
			return ValY;
		}
		private int ConvertPixelHeight(double Yd)
		{
			int ValY = Convert.ToInt16(Math.Tan(Yd * 3.1415 / 180) * PsycoPhysicTask.HeightP * PsycoPhysicTask.userDistance / PsycoPhysicTask.HeightM);
			return ValY;
		}
		private int ConvertPixelWidth(double Xd)
		{
			int ValX = Convert.ToInt16(Math.Tan(Xd * 3.1415 / 180) * PsycoPhysicTask.WidthP * PsycoPhysicTask.userDistance / PsycoPhysicTask.WidthM);
			return ValX;
		}
		#endregion
		#region stimulus functions
		void StimulusEditWidth(int index, String Value)
		{
			stimulusList[index].Widthd = double.Parse(Value);
			stimulusList[index].ConvertToPix();
		}
		void StimulusEditHeight(int index, String Value)
		{
			stimulusList[index].Heightd = double.Parse(Value);
			stimulusList[index].ConvertToPix();
		}
		void StimulusEditX(int index, String Value)
		{
			stimulusList[index].Xlocd = double.Parse(Value);
			stimulusList[index].ConvertToPix();
		}

		void StimulusEditY(int index, String Value)
		{
			stimulusList[index].Ylocd = double.Parse(Value);
			stimulusList[index].ConvertToPix();
		}

		void StimulusEditColor(int index)
		{
			ColorDialog c = new ColorDialog();
			if (c.ShowDialog() == DialogResult.OK)
			{
				stimulusList[index].ColorPt = c.Color;
			}
		}

		String StimulusEditPath(int index)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			string PictureFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			ofd.InitialDirectory = PictureFolder;
			ofd.Title = "Pick a picture; any picture";
			ofd.CustomPlaces.Add(@"C:\");
			ofd.CustomPlaces.Add(@"C:\Program Files\");
			ofd.CustomPlaces.Add(@"K:\Documents\Pictures\");
			//ofd.Multiselect = true;
			ofd.Filter = "Pictures|*.jpg; *.bmp; *.png|Documents|*.txt; *.doc; *.log|All|*.*";
			System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				foreach (string fileName in ofd.FileNames)
				{
					stimulusList[index].PathPic = fileName;
				}
			}
			return stimulusList[index].PathPic;
		}

		void StimulusEditContrast(int index, String Value)
		{
			stimulusList[index].Contrast = int.Parse(Value);
		}

		void StimulusRemove(int index)
		{
			stimulusList.RemoveAt(index);
		}
		#endregion
		#region Fixation functions
		void FixationEditWidth(int index, String Value)
		{
			fixationList[index].Widthd = double.Parse(Value);
			fixationList[index].ConvertToPix();
		}
		void FixationEditX(int index, String Value)
		{
			fixationList[index].Xlocd = double.Parse(Value);
			fixationList[index].ConvertToPix();
		}

		void FixationEditY(int index, String Value)
		{
			fixationList[index].Ylocd = double.Parse(Value);
			fixationList[index].ConvertToPix();
		}

		void FixationEditTime(int index, String Value)
		{
			fixationList[index].Time = int.Parse(Value);
		}

		void FixationRemove(int index)
		{
			fixationList[index] = new ObjectProp();
		}
		#endregion
		#region Hint functions
		void HintEditY(int index, String Value)
		{
			AddedHintsbyFrameTool[index].ArrowLocY = int.Parse(Value);
		}
		void HintEditX0(int index, String Value)
		{
			AddedHintsbyFrameTool[index].ArrowLocX0 = int.Parse(Value) - AddedHintsbyFrameTool[index].ArrowWidth;
			AddedHintsbyFrameTool[index].ArrowLocX1 = int.Parse(Value) + AddedHintsbyFrameTool[index].ArrowWidth;
		}

		private void DesignerM_Move(object sender, EventArgs e)
		{
			UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);
		}

		void HintEditWidth(int index, String Value)
		{
			AddedHintsbyFrameTool[index].ArrowWidth = int.Parse(Value);
		}
		void HintEditColor(int index)
		{
			ColorDialog c = new ColorDialog();
			if (c.ShowDialog() == DialogResult.OK)
			{
				AddedHintsbyFrameTool[index].ArrowColor = c.Color;
			}
		}
		void HintEditRatio(int index, String Value)
		{
			for (int i = 0; i < ShowBoxes.Count; i++)
			{
				if (HintIndexes[index] == FrameIndexes[i])
				{
					ShowBoxes[i].Thickness = (ShowBoxes[i].Thickness / AddedHintsbyFrameTool[index].BoxRatio) * float.Parse(Value);
					break;
				}
			}
			AddedHintsbyFrameTool[index].BoxRatio = float.Parse(Value);
		}
		#endregion

	}
}
