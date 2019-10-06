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

namespace Psychophysics
{
    public partial class DesignerM : MetroFramework.Forms.MetroForm
    {
		#region Variables 
		float ViewSize = 80; //A: main white box size in the midddle of task designer
		Graphics g, gr;
		int? initX = null;
		int? initY = null;
		bool moveObject = false;
		int moveObjectX = 0, moveObjectY = 0;
		int indexMoveObject = -1;
		public static List<ObjectProp> stimulusList = new List<ObjectProp>();
		public static List<ObjectProp> fixationList = new List<ObjectProp>();
		int PicBCnt = 1, ActivePicB = 1;
		public static List<FrameProp> frameList = new List<FrameProp>();
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

		private void pnl_Draw_MouseDown(object sender, MouseEventArgs e)
		{

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
		#endregion
		
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
			//	//FixationTime_ET.Text = Convert.ToString(fixationList[index].Time);
			//	//    Debug.Write("Fixate Timing "+ FixationTime_ET.Text + " " + fixationList[index].Time + " " + index + "\n");
			//	//    Debug.Write("FixTime#% : " + fixationList[0].Time + "\n");
			//	//    Debug.Write("FixTime#% : " + fixationList[1].Time + "\n");
			//}

			//// Add drawing commands here
			//Bitmap objBitmap = new Bitmap(BitmapPicB[index], new Size(PicB1.Width, PicB1.Height));
			//PictureBox picb = panel1.Controls.Find("PicB" + (index + 1), true).FirstOrDefault() as PictureBox;
			//picb.Image = objBitmap;
		}
		
	}
}
