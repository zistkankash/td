using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Basics;

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
		#endregion
		public DesignerM()
        {
            InitializeComponent();
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
				double ValX = Math.Atan((Xp - TaskPreview.WidthP / 2) * TaskPreview.WidthM / (TaskPreview.WidthP * TaskPreview.userDistance));
				Debug.Write(" Xp: " + Xp + " WidthP : " + TaskPreview.WidthP + " WidthM:" + TaskPreview.WidthM + " userDistance:" + TaskPreview.userDistance + " " + ((Xp - TaskPreview.WidthP / 2) * TaskPreview.WidthM / (TaskPreview.WidthP * TaskPreview.userDistance)) + "\n");
				return ValX;
			}

			private double ConvertDegreeY(int Yp)
			{
				double ValY = Math.Atan((Yp - TaskPreview.HeightP / 2) * TaskPreview.HeightM / (TaskPreview.HeightP * TaskPreview.userDistance));
				return ValY;
			}

			private double ConvertDegreeWidth(int Xp)
			{
				double ValX = Math.Atan(Xp * TaskPreview.WidthM / (TaskPreview.WidthP * TaskPreview.userDistance));
				Debug.Write(" Xp: " + Xp + " WidthP : " + TaskPreview.WidthP + " WidthM:" + TaskPreview.WidthM + " userDistance:" + TaskPreview.userDistance + " " + ((Xp - TaskPreview.WidthP / 2) * TaskPreview.WidthM / (TaskPreview.WidthP * TaskPreview.userDistance)) + "\n");
				return ValX;
			}

			private double ConvertDegreeHeight(int Yp)
			{
				double ValY = Math.Atan(Yp * TaskPreview.HeightM / (TaskPreview.HeightP * TaskPreview.userDistance));
				return ValY;
			}


			private int ConvertPixelX(double Xd)
			{
				int ValX = Convert.ToInt16(Math.Tan(Xd * 3.1415 / 180) * TaskPreview.WidthP * TaskPreview.userDistance / TaskPreview.WidthM + TaskPreview.WidthP / 2);
				return ValX;
			}

			private int ConvertPixelY(double Yd)
			{
				int ValY = Convert.ToInt16(Math.Tan(Yd * 3.1415 / 180) * TaskPreview.HeightP * TaskPreview.userDistance / TaskPreview.HeightM + TaskPreview.HeightP / 2);
				return ValY;
			}

			private int ConvertPixelWidth(double Xd)
			{
				int ValX = Convert.ToInt16(Math.Tan(Xd * 3.1415 / 180) * TaskPreview.WidthP * TaskPreview.userDistance / TaskPreview.WidthM);
				return ValX;
			}

			private int ConvertPixelHeight(double Yd)
			{
				int ValY = Convert.ToInt16(Math.Tan(Yd * 3.1415 / 180) * TaskPreview.HeightP * TaskPreview.userDistance / TaskPreview.HeightM);
				return ValY;
			}

		}
		public class FrameProp
		{
			public int frameWidth, frameHeight, Time;
			public Color frameColor;

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
		public void ConvertToDeg()                                          //A: uncomment it at the end!!!!!!
		{
			//Xlocd = ConvertDegreeX(Xloc) * 180 / 3.1415;
			//Ylocd = ConvertDegreeY(Yloc) * 180 / 3.1415;
			//Widthd = ConvertDegreeWidth(Width) * 180 / 3.1415;
			//Heightd = ConvertDegreeHeight(Height) * 180 / 3.1415;
			//Debug.Write(" ConvertToDeg" + Xlocd + " " + Ylocd + " " + Widthd + " " + Heightd + " \n");
		}
		private double ConvertDegreeWidth(int Xp)
		{
			double ValX = Math.Atan(Xp * TaskPreview.WidthM / (TaskPreview.WidthP * TaskPreview.userDistance));
			Debug.Write(" Xp: " + Xp + " WidthP : " + TaskPreview.WidthP + " WidthM:" + TaskPreview.WidthM + " userDistance:" + TaskPreview.userDistance + " " + ((Xp - TaskPreview.WidthP / 2) * TaskPreview.WidthM / (TaskPreview.WidthP * TaskPreview.userDistance)) + "\n");
			return ValX;
		}
		private double ConvertDegreeHeight(int Yp)
		{
			double ValY = Math.Atan(Yp * TaskPreview.HeightM / (TaskPreview.HeightP * TaskPreview.userDistance));
			return ValY;
		}
		private int ConvertPixelHeight(double Yd)
		{
			int ValY = Convert.ToInt16(Math.Tan(Yd * 3.1415 / 180) * TaskPreview.HeightP * TaskPreview.userDistance / TaskPreview.HeightM);
			return ValY;
		}
		private int ConvertPixelWidth(double Xd)
		{
			int ValX = Convert.ToInt16(Math.Tan(Xd * 3.1415 / 180) * TaskPreview.WidthP * TaskPreview.userDistance / TaskPreview.WidthM);
			return ValX;
		}
		#endregion

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
		}

		private void PicB1_Click(object sender, EventArgs e)
		{

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

		static Color SetTransparency(int A, Color color)  

		{
			return Color.FromArgb(A, color.R, color.G, color.B);
		}   //A:extract RGB and alpha
		private void UpdateFrame(int index, List<FrameProp> FrameObjs, List<ObjectProp> FixationObjs, List<ObjectProp> StimulusObjs) //A: uncomment it at the end!!!!!!
		{
			//if (index < 0)
			//	return;
			//g.Clear(FrameObjs[index].frameColor);
			//gr.Clear(FrameObjs[index].frameColor);

			//for (int i = 0; i < ShowBoxes.Count; i++)
			//{
			//	if (FrameIndexes[i] == index + 1)
			//	{
			//		Pen boxp = new Pen(ShowBoxes[i].ColorBox, ShowBoxes[i].Thickness);
			//		gr.DrawRectangle(boxp, ShowBoxes[i].CenterX - ShowBoxes[i].Width / 2, ShowBoxes[i].CenterY - ShowBoxes[i].Height / 2, ShowBoxes[i].Width, ShowBoxes[i].Height);
			//		g.DrawRectangle(boxp, (ShowBoxes[i].CenterX - ShowBoxes[i].Width / 2) * ViewSize / 100, (ShowBoxes[i].CenterY - ShowBoxes[i].Height / 2) * ViewSize / 100, (ShowBoxes[i].Width) * ViewSize / 100, (ShowBoxes[i].Height) * ViewSize / 100);
			//	}
			//}

			//for (int i = 0; i < AddedHintsbyFrameTool.Count; i++)
			//{
			//	if (FrameIndexes[i] == index + 1)
			//	{
			//		Graphics graphic = Graphics.FromImage(BitmapPicB[HintIndexes[i] - 1]);

			//		if (AddedHintsbyFrameTool[i].BoxRatio == 1)
			//		{
			//			Pen pen = new Pen(AddedHintsbyFrameTool[i].ArrowColor, AddedHintsbyFrameTool[i].ArrowWidth);
			//			pen.StartCap = LineCap.ArrowAnchor;
			//			gr.DrawLine(pen, AddedHintsbyFrameTool[i].ArrowLocX0, AddedHintsbyFrameTool[i].ArrowLocY, AddedHintsbyFrameTool[i].ArrowLocX1, AddedHintsbyFrameTool[i].ArrowLocY);
			//			pen = new Pen(AddedHintsbyFrameTool[i].ArrowColor, (AddedHintsbyFrameTool[i].ArrowWidth) * ViewSize / 100);
			//			pen.StartCap = LineCap.ArrowAnchor;
			//			g.DrawLine(pen, (AddedHintsbyFrameTool[i].ArrowLocX0) * ViewSize / 100, (AddedHintsbyFrameTool[i].ArrowLocY) * ViewSize / 100, (AddedHintsbyFrameTool[i].ArrowLocX1) * ViewSize / 100, (AddedHintsbyFrameTool[i].ArrowLocY) * ViewSize / 100);

			//		}
			//	}
			//}


			//for (int i = 0; i < StimulusObjs.Count; i++)
			//{

			//	if (StimulusObjs[i].FrameIndex != index + 1)
			//		continue;

			//	//Use Solid Brush for filling the graphic shapes
			//	SolidBrush sb = new SolidBrush(Color.FromArgb(StimulusObjs[i].Contrast, StimulusObjs[i].ColorPt));

			//	if (StimulusObjs[i].Type == 1 || StimulusObjs[i].Type == 5 || StimulusObjs[i].Type == 9)
			//	{
			//		g.FillRectangle(sb, (StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100, (StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2) * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100);
			//		gr.FillRectangle(sb, StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Width, StimulusObjs[i].Width);
			//	}

			//	if (StimulusObjs[i].Type == 2)
			//	{
			//		g.FillRectangle(sb, (StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100, (StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2) * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100);
			//		gr.FillRectangle(sb, StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Width, StimulusObjs[i].Width);
			//	}

			//	if (StimulusObjs[i].Type == 3 || StimulusObjs[i].Type == 7 || StimulusObjs[i].Type == 11)
			//	{
			//		g.FillEllipse(sb, (StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100, (StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2) * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100);
			//		gr.FillEllipse(sb, StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Width, StimulusObjs[i].Width);
			//	}

			//	if (StimulusObjs[i].Type == 4 || StimulusObjs[i].Type == 8 || StimulusObjs[i].Type == 12)
			//	{
			//		//Bitmap bmpvar = new Bitmap(StimulusObjs[i].PathPic);
			//		try
			//		{
			//			if (File.Exists(StimulusObjs[i].PathPic))
			//			{
			//				bmpvarforUpdate = new Bitmap(StimulusObjs[i].PathPic);
			//				bmpvarforUpdate = new Bitmap(bmpvarforUpdate, new Size(StimulusObjs[i].Width, StimulusObjs[i].Height));
			//				gr.DrawImage(bmpvarforUpdate, new Point(StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Height / 2));
			//				bmpvarforUpdate = new Bitmap(bmpvarforUpdate, new Size(Convert.ToInt16(StimulusObjs[i].Width * ViewSize / 100), Convert.ToInt16(StimulusObjs[i].Height * ViewSize / 100)));
			//				g.DrawImage(bmpvarforUpdate, new Point(Convert.ToInt16((StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100), Convert.ToInt16((StimulusObjs[i].Yloc - StimulusObjs[i].Height / 2) * ViewSize / 100)));
			//			}
			//			bmpvarforUpdate.Dispose();
			//		}
			//		catch (OutOfMemoryException)
			//		{

			//		}

			//	}

			//}


			////Debug.Write("FixTime#$% : " + fixationList[0].Time + "\n");
			////Debug.Write("FixTime#$% : " + fixationList[1].Time + "\n");
			//if (FixationObjs[index].Enable)
			//{
			//	Pen boxp = new Pen(fixationList[index].ColorPt);
			//	switch (fixationList[index].Type)
			//	{
			//		case 1:
			//			gr.DrawRectangle(boxp, fixationList[index].Xloc - fixationList[index].Width / 2, fixationList[index].Yloc - fixationList[index].Width / 2, fixationList[index].Width, fixationList[index].Width);
			//			g.DrawRectangle(boxp, (fixationList[index].Xloc - fixationList[index].Width / 2) * ViewSize / 100, (fixationList[index].Yloc - fixationList[index].Width / 2) * ViewSize / 100, (fixationList[index].Width) * ViewSize / 100, (fixationList[index].Width) * ViewSize / 100);
			//			break;
			//		case 3:
			//		case 7:
			//			gr.DrawEllipse(boxp, fixationList[index].Xloc - fixationList[index].Width / 2, fixationList[index].Yloc - fixationList[index].Width / 2, fixationList[index].Width, fixationList[index].Width);
			//			g.DrawEllipse(boxp, (fixationList[index].Xloc - fixationList[index].Width / 2) * ViewSize / 100, (fixationList[index].Yloc - fixationList[index].Width / 2) * ViewSize / 100, fixationList[index].Width * ViewSize / 100, fixationList[index].Width * ViewSize / 100);
			//			break;
			//		default:
			//			break;
			//	}
			//	//txb_fixationtime.Text = Convert.ToString(fixationList[index].Time);
			//	//    Debug.Write("Fixate Timing "+ txb_fixationtime.Text + " " + fixationList[index].Time + " " + index + "\n");
			//	//    Debug.Write("FixTime#% : " + fixationList[0].Time + "\n");
			//	//    Debug.Write("FixTime#% : " + fixationList[1].Time + "\n");
			//}

			//// Add drawing commands here
			//Bitmap objBitmap = new Bitmap(BitmapPicB[index], new Size(PicB1.Width, PicB1.Height));
			//PictureBox picb = panel1.Controls.Find("PicB" + (index + 1), true).FirstOrDefault() as PictureBox;
			//picb.Image = objBitmap;
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
		

	}
}
