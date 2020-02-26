﻿using System;
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
    public partial class Designer : Form
    {
		#region Variables
		// Number and Size of Screens
		Screen[] screen = Screen.AllScreens;
        Color StimColor;
		public static int ScreenWidth = 0, ScreenHeight = 0;
		float ViewSize = 80; //A: main white box size in the midddle of task designer
		
		Graphics _slideImageGraphics;
        Bitmap _picBitmap = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
        Graphics _mainBitmapGraphics;
        //nullable int for storing Null value
        int? initX = null;
		int? initY = null;
		bool drawSquare = false;
		bool drawRectangle = false;
		bool drawCircle = false;
		bool drawImage = false;
		bool moveObject = false;
		int moveObjectX = 0, moveObjectY = 0;
		int indexMoveObject = -1;
		
		public static int PicBCnt = 1, ActivePicB = 1, _fixateAreaSelected;
		bool FixationSelected = false;
		String ImagePath = " ";
		public static List<Bitmap> BitmapPicB = new List<Bitmap>();
		public static List<int> DeletedFrames = new List<int>();
		public static List<int> Reward = new List<int>();
        
        public PsycoPhysicTask _parentTask;
		
				
		// Update
		Bitmap bmpvarforUpdate;
		#endregion
		
        #region Lists
		public static List<ObjectProp> stimulusList = new List<ObjectProp>();
		public static List<List<ObjectProp>> fixationList = new List<List<ObjectProp>>();
		// Type 
		const int filledSquareType = 1;
		const int filledRectangleType = 2;
		const int filledCircleType = 3;
		const int PictureType = 4;
		//// for fixation areas 
		const int SquareType = 1;
		const int RectangleType = 2;
		const int CircleType = 3;

		//Edit Vars
		public int EditedIndex = 0;
		public int Mode = 0;
		// Global Vars
		public static List<FrameProp> frameList = new List<FrameProp>();
		#endregion
				

		private void DesignerForm_Load(object sender, EventArgs e)
		{
					
			PictureBox picb = pnlFrames.Controls.Find("PicB" + ActivePicB, true).FirstOrDefault() as PictureBox;
			using (Graphics newGr = pnlFrames.CreateGraphics())
				newGr.DrawRectangle(new Pen(Color.DimGray, 1), new Rectangle(picb.Location.X - 1, picb.Location.Y - 1, picb.Width + 1, picb.Height + 1));

            expandCollapsePanel1.ForeColor = Color.FromArgb(51,51,51);
            expandCollapsePanel2.ForeColor = Color.FromArgb(51, 51, 51);
            expandCollapsePanel3.ForeColor = Color.FromArgb(51, 51, 51);
            expandCollapsePanel4.ForeColor = Color.FromArgb(51, 51, 51);
            pnlFrames.ForeColor = Color.FromArgb(51, 51, 51);
            expandCollapsePanel6.ForeColor = Color.FromArgb(51, 51, 51);
            //expandCollapsePanel1.BackColor = Color.FromArgb(100,232,216,201);
            //expandCollapsePanel2.BackColor = Color.FromArgb(100, 232, 216, 201);
            //expandCollapsePanel3.BackColor = Color.FromArgb(100, 232, 216, 201);
            //expandCollapsePanel4.BackColor = Color.FromArgb(100, 232, 216, 201);
        }  
			

		public Designer(int mode, int index, PsycoPhysicTask DesignParent)  
        {
            InitializeComponent();
			_parentTask = DesignParent;
            
            Debug.Write("Helll");
            fixationList.Clear();
            stimulusList.Clear();
            Reward.Clear();
                       
            frameList.Clear();
            
            DeletedFrames.Clear();
            ActivePicB = 1;
            PicBCnt = 1;
            _mainBitmapGraphics = Graphics.FromImage(_picBitmap);
           
            if (mode == 1) 
            {
                this.Mode = mode;
               
                // Frame Initialization
                FrameProp frm = new FrameProp();
                frameList.Add(frm);
                
                FrameTime_ET.Text = Convert.ToString(frameList[0].Time);

                // Panel Graphic setting
               
                _mainBitmapGraphics.Clear(Color.Black);

                // Bitmap Graphic setting
                Bitmap bmpVar = new Bitmap(frameList[0].frameWidth, frameList[0].frameHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                BitmapPicB.Add(bmpVar);
                
                _slideImageGraphics = Graphics.FromImage(BitmapPicB[0]);
                _slideImageGraphics.Clear(Color.White);

                
                Reward.Add(0);
                DeletedFrames.Add(0);

                // Fixation setting
                
                List<ObjectProp> fixList = new List<ObjectProp>();
               
                fixationList.Add(fixList);
                
                Bitmap objBitmap = new Bitmap(BitmapPicB[0], new Size(PicB1.Width, PicB1.Height));
                PicB1.Image = objBitmap;
				
				
				UpdateTreeView(ActivePicB - 1);
            }
			
			#region edit mode
			else if ( mode == 2 ) 
            {
                this.Mode = mode;
                LoadParameters(index);
                this.EditedIndex = index ;

                //SelectRewardType_CB.SelectedIndex = Reward[ActivePicB - 1];
                //RewardType_LB.Text = Reward[ActivePicB - 1].ToString();
            }
			#endregion
			Size_LB.Text = " % " + Convert.ToString(ViewSize);
            
			
		}
       
        static Color SetTransparency(int A, Color color)
        {
            return Color.FromArgb(A, color.R, color.G, color.B);
		}         

		
		private void pnl_Draw_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 5)
                pnlFrames.Width = 170;
            initX = e.X;
            initY = e.Y;
			
            double X = ConvertDegreeX(Convert.ToInt16(initX * 100 / ViewSize)) * 180 / 3.1415;
            double Y = ConvertDegreeY(Convert.ToInt16(initY * 100 / ViewSize)) * 180 / 3.1415;
																					          
			
           
            if(moveObject)
            {
                stimulusList[indexMoveObject].Xloc += (Convert.ToInt16(initX * 100 / ViewSize) - moveObjectX);
                stimulusList[indexMoveObject].Yloc += (Convert.ToInt16(initY * 100 / ViewSize) - moveObjectY);
                stimulusList[indexMoveObject].ConvertToDeg();
                moveObjectX = Convert.ToInt16(initX * 100 / ViewSize);
                moveObjectY = Convert.ToInt16(initY * 100 / ViewSize);
                UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList);
            }

		}           

		
		private void pnl_Draw_MouseDown(object sender, MouseEventArgs e)
        {
			
            if (drawSquare)
            {
                //Use Solid Brush for filling the graphic shapes
                SolidBrush sb = new SolidBrush(Color.FromArgb(int.Parse(txtStimContrast.Text), StimColor));
                Pen p = new Pen(SetTransparency(125, StimColor));
                //setting the width and height same for creating square.
                //Getting the width and Heigt value from Textbox(txt_ShapeSize)
                if (!FixationSelected)
                {
                    ObjectProp stimulus = new ObjectProp();
                    double widthd = double.Parse(txtStimWidth.Text);
                    int width = Convert.ToInt16(ConvertPixelWidth(widthd));
                    stimulus.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, width, filledSquareType, ActivePicB, true, StimColor);
                    stimulus.SetContrastPts(int.Parse(txtStimContrast.Text));
                    stimulus.ConvertToDeg();
                    stimulusList.Add(stimulus);
                    _slideImageGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Height / 2, stimulus.Width, stimulus.Height);
                    _mainBitmapGraphics.FillRectangle(sb, e.X - stimulus.Width * ViewSize / 200, e.Y - stimulus.Height * ViewSize / 200, stimulus.Width * ViewSize / 100, stimulus.Height * ViewSize / 100);
                }
                

                //setting startPaint and drawSquare value to false for creating one graphic on one click.
                
                drawSquare = false;
            }
            else if (drawRectangle)
            {
                SolidBrush sb = new SolidBrush(Color.FromArgb(int.Parse(txtStimContrast.Text), StimColor));
                Pen p = new Pen(SetTransparency(125, StimColor));
                //setting the width twice of the height
                if (!FixationSelected)
                {
                    ObjectProp stimulus = new ObjectProp();
                    double widthD = double.Parse(txtStimWidth.Text);
                    double heightD = double.Parse(txtStimHeight.Text);
                    int width = Convert.ToInt16(ConvertPixelWidth(widthD));
                    int height = Convert.ToInt16(ConvertPixelWidth(heightD));
                    stimulus.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, height, filledRectangleType, ActivePicB, true, StimColor);
                    stimulus.SetContrastPts(int.Parse(txtStimContrast.Text));
                    stimulus.ConvertToDeg();
                    stimulusList.Add(stimulus);
                    _slideImageGraphics.FillRectangle(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Height / 2, stimulus.Width, stimulus.Height);
                    _mainBitmapGraphics.FillRectangle(sb, e.X - stimulus.Width * ViewSize / 200, e.Y - stimulus.Height * ViewSize / 200, stimulus.Width * ViewSize / 100, stimulus.Height * ViewSize / 100);
                }
                
                
                drawRectangle = false;
            }
            else if (drawCircle)
            {
                SolidBrush sb = new SolidBrush(Color.FromArgb(int.Parse(txtStimContrast.Text), StimColor));
                Pen p = new Pen(SetTransparency(125, StimColor));
                if (!FixationSelected)
                {
                    ObjectProp stimulus = new ObjectProp();
                    double widthd = double.Parse(txtStimWidth.Text);
                    int width = Convert.ToInt16(ConvertPixelWidth(widthd));
                    stimulus.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, width, filledCircleType, ActivePicB, true, StimColor);
                    stimulus.SetContrastPts(int.Parse(txtStimContrast.Text));
                    stimulus.ConvertToDeg();
                    stimulusList.Add(stimulus);
                    _slideImageGraphics.FillEllipse(sb, stimulus.Xloc - stimulus.Width / 2, stimulus.Yloc - stimulus.Height / 2, stimulus.Width, stimulus.Height);
                    _mainBitmapGraphics.FillEllipse(sb, e.X - stimulus.Width * ViewSize / 200, e.Y - stimulus.Height * ViewSize / 200, stimulus.Width * ViewSize / 100, stimulus.Height * ViewSize / 100);
                }
                else
                {
                    ObjectProp fixation = new ObjectProp();
                    double widthd = double.Parse(txtStimWidth.Text);
                    int width = Convert.ToInt16(ConvertPixelWidth(widthd));

                    fixation.SetProps(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, width, CircleType, ActivePicB, true, StimColor);
                    fixation.ConvertToDeg();
                    fixationList[ActivePicB - 1].Add(fixation);
                   
                    
                    _fixateAreaSelected = fixationList[ActivePicB - 1].Count - 1;
                    //fixation.Time = int.Parse(FixationTime_ET.Text);
                    UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList);

                    Reward[ActivePicB - 1] = 0;
                    
                    
                }

               
                drawCircle = false;
            }
            else if (drawImage)
            {
                ObjectProp stimulus = new ObjectProp();
                double widthd = double.Parse(txtStimWidth.Text);
                int width = Convert.ToInt16(ConvertPixelWidth(widthd));

                double heightd = double.Parse(txtStimHeight.Text);
                int height = Convert.ToInt16(ConvertPixelHeight(heightd));

                stimulus.SetPicture(Convert.ToInt16(e.X * 100 / ViewSize), Convert.ToInt16(e.Y * 100 / ViewSize), width, height, PictureType, ActivePicB, true, ImagePath);
                stimulus.ConvertToDeg();
                stimulusList.Add(stimulus);
                Bitmap bmpvar = new Bitmap(stimulus.PathPic);
                bmpvar = new Bitmap(bmpvar, new Size(stimulus.Width, stimulus.Height));
                _slideImageGraphics.DrawImage(bmpvar, new Point(stimulus.Xloc - width / 2, stimulus.Yloc - height / 2));
                bmpvar = new Bitmap(bmpvar, new Size(Convert.ToInt16(stimulus.Width * ViewSize / 100), Convert.ToInt16(stimulus.Height * ViewSize / 100)));
                _mainBitmapGraphics.DrawImage(bmpvar, new Point(e.X - Convert.ToInt16(width * ViewSize / 200), Convert.ToInt16(e.Y - height * ViewSize / 200)));
                
                drawImage = false;
				
            }
            else
            {
                int x = Convert.ToInt16(e.X * 100 / ViewSize);  //A: why 100/viewsize  ?!
                int y = Convert.ToInt16(e.Y * 100 / ViewSize);
                double Mindis = 0;
                for (int i = 0; i < stimulusList.Count;i++)
                {
                    double dis = Math.Sqrt((stimulusList[i].Xloc - x)* (stimulusList[i].Xloc - x) + (stimulusList[i].Yloc - y) * (stimulusList[i].Yloc - y));
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
                        
			Bitmap objBitmap = new Bitmap(BitmapPicB[ActivePicB - 1], new Size(PicB1.Width, PicB1.Height));
            PictureBox picb = pnlFrames.Controls.Find("PicB" + ActivePicB, true).FirstOrDefault() as PictureBox;
            picb.Image = objBitmap;
		}           
					
		
        private void pnl_Draw_MouseUp(object sender, MouseEventArgs e)
        {
           
            initX = null;
            initY = null;

            moveObject = false;
            moveObjectX = 0;
            moveObjectY = 0;
            indexMoveObject = -1;
		}           //A:DONE

					
		private void PickColor()
        {
            //Open Color Dialog and Set BackColor of btn_PenColor if user click on OK
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                StimColor = c.Color;
            }
        }     

        
        private void btn_CanvasColor_Click_1(object sender, EventArgs e) 
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                _mainBitmapGraphics.Clear(c.Color);
                BgColor_BT.BackColor = c.Color;
                _slideImageGraphics.Clear(c.Color);

                frameList[ActivePicB - 1].frameColor = c.Color;
                UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList);  
            }
		}    
		
		
        private void btn_Square_Click(object sender, EventArgs e)
        {
            drawSquare = true;
           
        }

        
        private void btn_Rectangle_Click(object sender, EventArgs e)
        {
            drawRectangle = true;
           
        }

        
        private void btn_Circle_Click(object sender, EventArgs e) 
        {
            drawCircle = true;
           
        }

        
        private void AddPicB_Click(object sender, EventArgs e)
        {
			// Adding new PictureBox
			pnlFrames.Select();
			
            //toolPanel.Enabled = true;
			PictureBox picb = pnlFrames.Controls.Find("PicB" + ActivePicB, true).FirstOrDefault() as PictureBox;
			using (Graphics newGr = pnlFrames.CreateGraphics())
				newGr.DrawRectangle(new Pen(Color.LightCyan, 1), new Rectangle(picb.Location.X - 1, picb.Location.Y - 1, picb.Width + 1, picb.Height + 1));
			
			PicBCnt++;
            int Yloc = AddPicB.Location.Y;
            ActivePicB = PicBCnt;
           

            PictureBox PicB = new PictureBox();
            pnlFrames.Controls.Add(PicB);
            PicB.Location = AddPicB.Location;
            PicB.Size = AddPicB.Size;
            PicB.Name = "PicB" + PicBCnt;
            PicB.Click += new System.EventHandler(this.PicB_Click);  //A: it seems it doest enter the picB_click event handler,why?!!what is it for?
            PicB.Visible = true;

            // Frame setting
            FrameProp newFrame = new FrameProp();
            frameList.Add(newFrame);
           
            FrameTime_ET.Text = Convert.ToString(frameList[ActivePicB - 1].Time);

            // Fixation setting
            List<ObjectProp> fixList = new List<ObjectProp>();
            fixationList.Add(fixList);
           
            // Adding new Bitmap image to the list
            Bitmap bmpVar = new Bitmap(frameList[0].frameWidth, frameList[0].frameHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            BitmapPicB.Add(bmpVar);
            _slideImageGraphics = Graphics.FromImage(BitmapPicB[ActivePicB - 1]);
            _slideImageGraphics.Clear(Color.White);

            // setting blank Image to the picturebox 
            Bitmap objBitmap = new Bitmap(BitmapPicB[ActivePicB - 1], new Size(PicB.Width, PicB.Height));
            PicB.Image = objBitmap;

            // set blank image to the panel
            _mainBitmapGraphics.DrawImage(BitmapPicB[ActivePicB - 1], new PointF(0, 0));

            Reward.Add(0);
            DeletedFrames.Add(0);
            			
            // Change the location of Add-Picturebox
            AddPicB.Location = new Point(AddPicB.Location.X, AddPicB.Location.Y + AddPicB.Size.Height + 15);
            UpdateTreeView(ActivePicB - 1);
		}      
         

		private void FixationShapeActive_BT_Click(object sender, EventArgs e)
		{
			FixationSelected = true;
           
			
			SquareShape_BT.Visible = false;
			RectangleShape_BT.Visible = false;
			//FixationTime_ET.Enabled = true;
			
		}

		private void StimulusShapeActive_BT_Click(object sender, EventArgs e)     
		{
            FixationSelected = false;
           	SquareShape_BT.Visible = true;
            RectangleShape_BT.Visible = true;
           
		}          

		private void Browse_BT(object sender, EventArgs e)
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
					drawImage = true;
					textBox1.Text = ImagePath;
					break;
				}
			}
			
				

		}                                 

       
		private void Next_PB_Click(object sender, EventArgs e)
        {
            FrameProperties[] AddedFrame = new FrameProperties[PicBCnt];
            List<FrameProperties> ListAddedFrame = new List<FrameProperties>();

            for (int i = 0; i < PicBCnt; i++)
            {
                AddedFrame[i] = new FrameProperties();
                if (DeletedFrames[i] == 1)
                    continue;

                int NumStimulus = 0;
                for (int j = 0; j < stimulusList.Count; j++)
                {
                    if (stimulusList[j].FrameIndex == i + 1)   
                        NumStimulus++;                         
                }

                FixationPts[] StimulusVar = new FixationPts[NumStimulus];
                int indexVar = 0;
                for (int j = 0; j < stimulusList.Count; j++)
                {
                    if (indexVar < NumStimulus)
                        StimulusVar[indexVar] = new FixationPts();
                    if (stimulusList[j].FrameIndex == i + 1)
                    {
                        if (stimulusList[j].Type != 4 && stimulusList[j].Type != 8 && stimulusList[j].Type != 12)  
                        {
                            StimulusVar[indexVar].SetFixationPts(stimulusList[j].Xloc, stimulusList[j].Yloc, stimulusList[j].Width, stimulusList[j].Width, stimulusList[j].Type, stimulusList[j].ColorPt);
                            StimulusVar[indexVar].SetContrastPts(stimulusList[j].Contrast);
                        }
                        else
                            StimulusVar[indexVar].SetPicture(stimulusList[j].Xloc, stimulusList[j].Yloc, stimulusList[j].Width, stimulusList[j].Height, stimulusList[j].Type, stimulusList[j].PathPic);
                        indexVar++;
                    }
                }
                                                             			
				AddedFrame[i].SetProperties(frameList[i].frameColor, frameList[i].Time, fixationList[i], NumStimulus, StimulusVar, Reward[i], null, 0, null, frameList[i].events.NewInstant());
            }
            
            for (int i = 0; i < AddedFrame.Length; i++)
            {
                if (DeletedFrames[i] == 1)
                    continue;
                ListAddedFrame.Add(AddedFrame[i]);
            }
            if (Mode == 1)
            {
                //مود یک خداحافظ 
                				  
            }
            else if (Mode == 2)
            {
				
                _parentTask._tsk.AllLevelProp[EditedIndex] = ListAddedFrame;
               	
            }
			
            this.Close();

		}                            

		private void FrameTime_ET_TextChanged(object sender, EventArgs e)
        {
            int ftime = 1000;
            try
            {
                if (ActivePicB > 0)
                {
                    int.TryParse(FrameTime_ET.Text, out ftime);
                    frameList[ActivePicB - 1].Time = ftime;
                }
            }
            catch(Exception)
            {
                FrameTime_ET.Text = ftime.ToString();
                frameList[ActivePicB - 1].Time = ftime;
            }
		}                  

		private void StimulusPictureActive_BT_Click(object sender, EventArgs e)
        {
			
            FixationSelected = false;
           
		}          

		private void PicB_Click(object sender, EventArgs e)
        {
			pnlFrames.Select();
           
            //toolPanel.Enabled = true;
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
			PictureBox picb = pnlFrames.Controls.Find("PicB" + ActivePicB, true).FirstOrDefault() as PictureBox;
			using (Graphics newGr = pnlFrames.CreateGraphics())
				newGr.DrawRectangle(new Pen(Color.LightCyan, 1), new Rectangle(picb.Location.X - 1, picb.Location.Y - 1, picb.Width + 1, picb.Height + 1));

			// Get position of the button that has been clicked
			int index = 0;
            index = int.Parse(Regex.Match(PicBName, @"\d+").Value);
            ActivePicB = index;
            
            Bitmap objBitmap = new Bitmap(BitmapPicB[ActivePicB - 1], new Size(PicB1.Width, PicB1.Height));

            picb = pnlFrames.Controls.Find("PicB" + ActivePicB, true).FirstOrDefault() as PictureBox;
            picb.Image = objBitmap;

			using (Graphics newGr = pnlFrames.CreateGraphics())
			newGr.DrawRectangle(new Pen(Color.Red, 1), new Rectangle(picb.Location.X - 1, picb.Location.Y - 1, picb.Width + 1, picb.Height + 1));

			FrameTime_ET.Text = Convert.ToString(frameList[ActivePicB - 1].Time);
           
            _slideImageGraphics = Graphics.FromImage(BitmapPicB[ActivePicB - 1]);
                       
            BgColor_BT.BackColor = frameList[ActivePicB - 1].frameColor;
			
            UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList);
            UpdateTreeView(ActivePicB - 1);
		}                              
        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This deletes all the material related to the current active Page. Are you sure you want to continue it?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                PictureBox picbremoved = pnlFrames.Controls.Find("PicB" + ActivePicB, true).FirstOrDefault() as PictureBox;
                picbremoved.Dispose();
                DeletedFrames[ActivePicB - 1] = 1;
                int VisibleFrames = 0;
                for (int i = 0; i < DeletedFrames.Count; i++)
                {
                    if (DeletedFrames[i] == 0)
                        VisibleFrames++;
                }
                int index = -1;
                if (VisibleFrames > 0)
                {

                    for (int i = ActivePicB; i < DeletedFrames.Count; i++)
                    {
                        if (DeletedFrames[i] == 0)
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index == -1)
                    {
                        for (int i = ActivePicB - 2; i > -1; i--)
                        {
                            if (DeletedFrames[i] == 0)
                            {
                                index = i;
                                break;
                            }
                        }
                        if (index != -1)
                        {
                            ActivePicB = index + 1;
                            _slideImageGraphics = Graphics.FromImage(BitmapPicB[ActivePicB - 1]);
                            UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList);
                        }
                    }
                    else
                    {
                        for (int i = ActivePicB; i < PicBCnt + 1; i++)
                        {
                            if (DeletedFrames[i - 1] == 1)
                                continue;
                            PictureBox picb = pnlFrames.Controls.Find("PicB" + i, true).FirstOrDefault() as PictureBox;
                            picb.Location = new Point(picb.Location.X, picb.Location.Y - picb.Size.Height - 15);
                        }
                        ActivePicB = index + 1;
                        _slideImageGraphics = Graphics.FromImage(BitmapPicB[ActivePicB - 1]);
                        UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList);
                    }
                }
                else
                {
                    _mainBitmapGraphics.Clear(Color.FromArgb(191, 219, 255));
                    
                    //toolPanel.Enabled = false;

                }
                
				AddPicB.Location = new Point(AddPicB.Location.X, AddPicB.Location.Y - AddPicB.Size.Height - 15);
            }
        }  

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("This erases all the material related to the current active Page. Are you sure you want to continue it?", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                fixationList[ActivePicB - 1] = new List<ObjectProp>();

                for (int i = 0; i < stimulusList.Count; i++)
                {
                    if (stimulusList[i].FrameIndex == ActivePicB)
                    {
                        stimulusList.RemoveAt(i);
                        i = i - 1;
                    }
                }

                for (int i = 0; i < Reward.Count; i++)
                {
                    Reward[i] = -1;
                }

                UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        
		#region TreeView-D
		
        private void UpdateTreeView(int index)
        {
            Objects_TV.Nodes[0].Nodes.Clear();
           
			if(fixationList[index].Count != 0)
			{
				//Objects_TV.Nodes[0].Nodes.Add("Fixation window:");
                for (int i = 0; i < fixationList[index].Count(); i++)
                {
                    Objects_TV.Nodes[0].Nodes.Add("Fixation " + i);
                }
            }
			Objects_TV.Nodes[1].Nodes.Clear();
           
            for (int i = 0; i < stimulusList.Count(); i++)
            {
                if (stimulusList[i].FrameIndex != index + 1)
                    continue;
               
                Objects_TV.Nodes[1].Nodes.Add("Stimulus " + i);
            }
            

        }


		void FixationEditWidth(int index, String Value)
        {
            try
            {
                fixationList[index][_fixateAreaSelected].Widthd = double.Parse(Value);
                fixationList[index][_fixateAreaSelected].ConvertToPix();
            }
            catch (Exception)
            {
                //MessageBox.Show("Please insert numerical data in field", "Input Error");
            }
        }
        
		void FixationEditX(int index, String Value)
        {
            try
            {
                fixationList[index][_fixateAreaSelected].Xlocd = double.Parse(Value);
                fixationList[index][_fixateAreaSelected].ConvertToPix();
            }
            catch (Exception)
            {
                //MessageBox.Show("Please insert numerical data in field", "Input Error");
            }
            
        }

        void FixationEditY(int index, String Value)
        {
            try
            {
                fixationList[index][_fixateAreaSelected].Ylocd = double.Parse(Value);
                fixationList[index][_fixateAreaSelected].ConvertToPix();
            }
            catch (Exception)
            {
                //MessageBox.Show("Please insert numerical data in field", "Input Error");
            }
            
        }

        void FixationEditTime(int index, String Value)
        {
            try
            {
                fixationList[index][_fixateAreaSelected].Time = int.Parse(Value);
            }
            catch (Exception)
            {
                //MessageBox.Show("Please insert numerical data in field", "Input Error");
            }
            
        }

        void FixationRemove(int index)
        {
            fixationList[index] = new List<ObjectProp>();
        }

        void StimulusEditWidth(int index, String Value)
        {
            try
            {
                stimulusList[index].Widthd = double.Parse(Value);
                stimulusList[index].ConvertToPix();
            }
            catch (Exception)
            {
               // MessageBox.Show("Please insert numerical data in field", "Input Error");
            }
            
        }
        
		void StimulusEditHeight(int index, String Value)
        {
            try
            {
                stimulusList[index].Heightd = double.Parse(Value);
                stimulusList[index].ConvertToPix();
            }
            catch (Exception)
            {
                //MessageBox.Show("Please insert numerical data in field", "Input Error");
            }
            
        }
        
		void StimulusEditX(int index, String Value)
        {
            try
            {
                stimulusList[index].Xlocd = double.Parse(Value);
                stimulusList[index].ConvertToPix();
            }
            catch (Exception)
            {
                //MessageBox.Show("Please insert numerical data in field", "Input Error");
            }
           
        }

        void StimulusEditY(int index, String Value)
        {
            try
            {
                stimulusList[index].Ylocd = double.Parse(Value);
                stimulusList[index].ConvertToPix();
            }
            catch (Exception)
            {
                //MessageBox.Show("Please insert numerical data in field", "Input Error");
            }
           
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
            try
            {
                stimulusList[index].Contrast = int.Parse(Value);
            }
            catch (Exception)
            {
                //MessageBox.Show("Please insert numerical data in field", "Input Error");
            }
            
        }

        void StimulusRemove(int index)
        {
            stimulusList.RemoveAt(index);
        }

        
		#endregion        

		#region EditR-D

		private void LoadParameters(int index)
        {
            PicBCnt = _parentTask._tsk.AllLevelProp[index].Count;
           
            for (int i = 0; i < PicBCnt; i++)
            {
                // Frame setting
                FrameProp newFrame = new FrameProp();
                newFrame.setFrameProp(newFrame.frameWidth, newFrame.frameHeight, _parentTask._tsk.AllLevelProp[index][i].FrameTime, _parentTask._tsk.AllLevelProp[index][i].BGColor, _parentTask._tsk.AllLevelProp[index][i].events);
                frameList.Add(newFrame);

                Reward.Add(_parentTask._tsk.AllLevelProp[index][i].RewardType);
                DeletedFrames.Add(0);
                
            }

            for (int i = 0; i < PicBCnt; i++)
            {
                // Adding new Bitmap image to the list
                Bitmap bmpVar = new Bitmap(frameList[0].frameWidth, frameList[0].frameHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                BitmapPicB.Add(bmpVar);
                _slideImageGraphics = Graphics.FromImage(BitmapPicB[i]);
                _slideImageGraphics.Clear(Color.White);
            }

            // setting blank Image to the picturebox 
            Bitmap objBitmap = new Bitmap(BitmapPicB[0], new Size(PicB1.Width, PicB1.Height));
            PicB1.Image = objBitmap;

            for (int i = 1; i < PicBCnt; i++)
            {
                int Yloc = AddPicB.Location.Y;
                PictureBox PicB = new PictureBox();
                pnlFrames.Controls.Add(PicB);
                PicB.Location = AddPicB.Location;
                PicB.Size = AddPicB.Size;
                PicB.Name = "PicB" + (i + 1);
                PicB.Click += new System.EventHandler(this.PicB_Click);
                PicB.Visible = true;

                // setting blank Image to the picturebox 
                objBitmap = new Bitmap(BitmapPicB[i], new Size(PicB.Width, PicB.Height));
                PicB.Image = objBitmap;

                // Change the location of Add-Picturebox
                AddPicB.Location = new Point(AddPicB.Location.X, AddPicB.Location.Y + AddPicB.Size.Height + 15);
            }

            for (int i = 0; i < PicBCnt; i++)
            {
                
                //fixationProp.SetFixationPts(_parentTask._tsk.AllLevelProp[index][i].Fixation.Xloc,_parentTask._tsk.AllLevelProp[index][i].Fixation.Yloc, _parentTask._tsk.AllLevelProp[index][i].Fixation.Width, _parentTask._tsk.AllLevelProp[index][i].Fixation.Height, _parentTask._tsk.AllLevelProp[index][i].Fixation.Type, i + 1, true, _parentTask._tsk.AllLevelProp[index][i].Fixation.ColorPt);
                
                
                fixationList.Add(_parentTask._tsk.AllLevelProp[index][i].Fixation.GetRange(0, _parentTask._tsk.AllLevelProp[index][i].Fixation.Count));
                
            }

            for (int i = 0; i < PicBCnt; i++)
            {
                for (int j = 0; j < _parentTask._tsk.AllLevelProp[index][i].NumberSaccade; j++)
                {
                    ObjectProp stimulusProp = new ObjectProp();
                    if (_parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Type == 4 | _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Type == 8 | _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Type == 12)
                    {
                        stimulusProp.SetPicture(_parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Xloc, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Yloc, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Width, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Height, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Type, i + 1, true, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].PathPic);
                    }
                    else
                    {
                        stimulusProp.SetProps(_parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Xloc, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Yloc, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Width, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Height, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Type, i + 1, true, _parentTask._tsk.AllLevelProp[index][i].Stimulus[j].ColorPt);
                        stimulusProp.SetContrastPts(_parentTask._tsk.AllLevelProp[index][i].Stimulus[j].Contrast);
                    }
                    stimulusProp.ConvertToDeg();
                    stimulusList.Add(stimulusProp);
                }
            }
           
            ActivePicB = PicBCnt;

            // Panel Graphic setting
           

            for (int i = 0; i < PicBCnt; i++)
            {
                _slideImageGraphics = Graphics.FromImage(BitmapPicB[i]);
                
                UpdateFrame(i, frameList, fixationList[i], stimulusList);
                
                UpdateTreeView(i);
            }
            //UpdateFrame(ActivePicB - 1, frameList, fixationList, stimulusList);
            
		}         
        
        #endregion

        #region UpdatePictures-D

        private void UpdateFrame(int index, List<FrameProp> FrameObjs, List<ObjectProp> FixationObjs, List<ObjectProp> StimulusObjs)
        {
            if (index < 0)
                return;
            _mainBitmapGraphics.Clear(FrameObjs[index].frameColor);
            _slideImageGraphics.Clear(FrameObjs[index].frameColor);
                        
            for (int i = 0; i < StimulusObjs.Count; i++)
            {

                if (StimulusObjs[i].FrameIndex != index + 1)
                    continue;

                //Use Solid Brush for filling the graphic shapes
                SolidBrush sb = new SolidBrush(Color.FromArgb(StimulusObjs[i].Contrast, StimulusObjs[i].ColorPt));

                if (StimulusObjs[i].Type == 1 || StimulusObjs[i].Type == 5 || StimulusObjs[i].Type == 9)
                {
                    _mainBitmapGraphics.FillRectangle(sb, (StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100, (StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2) * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100);
                    _slideImageGraphics.FillRectangle(sb, StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Width, StimulusObjs[i].Width);
                }

                if (StimulusObjs[i].Type == 2)
                {
                    _mainBitmapGraphics.FillRectangle(sb, (StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100, (StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2) * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100);
                    _slideImageGraphics.FillRectangle(sb, StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Width, StimulusObjs[i].Width);
                }

                if (StimulusObjs[i].Type == 3 || StimulusObjs[i].Type == 7 || StimulusObjs[i].Type == 11)
                {
                    _mainBitmapGraphics.FillEllipse(sb, (StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100, (StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2) * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100, StimulusObjs[i].Width * ViewSize / 100);
                    _slideImageGraphics.FillEllipse(sb, StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Width, StimulusObjs[i].Width);
                }

                if (StimulusObjs[i].Type == 4 || StimulusObjs[i].Type == 8 || StimulusObjs[i].Type == 12)
                {
                    //Bitmap bmpvar = new Bitmap(StimulusObjs[i].PathPic);
                    try
                    {
                        if(File.Exists(StimulusObjs[i].PathPic))
                        { 
                            bmpvarforUpdate = new Bitmap(StimulusObjs[i].PathPic);
                            bmpvarforUpdate = new Bitmap(bmpvarforUpdate, new Size(StimulusObjs[i].Width, StimulusObjs[i].Height));
                            _slideImageGraphics.DrawImage(bmpvarforUpdate, new Point(StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2, StimulusObjs[i].Yloc - StimulusObjs[i].Height / 2));
                            bmpvarforUpdate = new Bitmap(bmpvarforUpdate, new Size(Convert.ToInt16(StimulusObjs[i].Width * ViewSize / 100), Convert.ToInt16(StimulusObjs[i].Height * ViewSize / 100)));
                            _mainBitmapGraphics.DrawImage(bmpvarforUpdate, new Point(Convert.ToInt16((StimulusObjs[i].Xloc - StimulusObjs[i].Width / 2) * ViewSize / 100), Convert.ToInt16((StimulusObjs[i].Yloc - StimulusObjs[i].Height / 2) * ViewSize / 100)));
                        }
                        bmpvarforUpdate.Dispose();
                    }
                    catch(OutOfMemoryException)
                    {

                    }

                }

            }


            //Debug.Write("FixTime#$% : " + fixationList[0].Time + "\n");
            //Debug.Write("FixTime#$% : " + fixationList[1].Time + "\n");
            for (int j = 0; j < FixationObjs.Count; j++)
            {
                if (FixationObjs[j].Enable)
                {
                    Pen boxp = new Pen(FixationObjs[j].ColorPt);
                    switch (FixationObjs[j].Type)
                    {
                        case 1:
                            _slideImageGraphics.DrawRectangle(boxp, FixationObjs[j].Xloc - FixationObjs[j].Width / 2, FixationObjs[j].Yloc - FixationObjs[j].Width / 2, FixationObjs[j].Width, FixationObjs[j].Width);
                            _mainBitmapGraphics.DrawRectangle(boxp, (FixationObjs[j].Xloc - FixationObjs[j].Width / 2) * ViewSize / 100, (FixationObjs[j].Yloc - FixationObjs[j].Width / 2) * ViewSize / 100, (FixationObjs[j].Width) * ViewSize / 100, (FixationObjs[j].Width) * ViewSize / 100);
                            break;
                        case 3:
                        case 7:
                            _slideImageGraphics.DrawEllipse(boxp, FixationObjs[j].Xloc - FixationObjs[j].Width / 2, FixationObjs[j].Yloc - FixationObjs[j].Width / 2, FixationObjs[j].Width, FixationObjs[j].Width);
                            _mainBitmapGraphics.DrawEllipse(boxp, (FixationObjs[j].Xloc - FixationObjs[j].Width / 2) * ViewSize / 100, (FixationObjs[j].Yloc - FixationObjs[j].Width / 2) * ViewSize / 100, FixationObjs[j].Width * ViewSize / 100, FixationObjs[j].Width * ViewSize / 100);
                            break;
                        default:
                            break;
                    }

                }
            }
            // Add drawing commands here
            Bitmap objBitmap = new Bitmap(BitmapPicB[index], new Size(PicB1.Width, PicB1.Height));
            PictureBox picb = pnlFrames.Controls.Find("PicB" + (index + 1), true).FirstOrDefault() as PictureBox;
            picb.Image = objBitmap;
			
			
		}   

        #endregion
        
        #region FrameProp-D
        
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
				events = new TriggerEvents();
            }

            public void setFrameProp(int w, int h, int t, Color c, TriggerEvents ev)
            {
                frameWidth = w;
                frameHeight = h;
                Time = t;
                frameColor = c;
				events = ev;
            }

        }
        
        #endregion
        
        #region objectprop-D

        public class ObjectProp
        {
            public int Xloc, Yloc, Width, Height, Type, FrameIndex, Time;
            public double Xlocd, Ylocd, Widthd, Heightd;
            public bool Enable;
            public int Contrast;
            public Color ColorPt;
            public string PathPic;

            public int CorrectEventCode = -1, INcorrectEventCode = -1, _rewardType = -1,  EFW = -1, ETW = -1;

			public ObjectProp()
            {
                Xloc = -1;
                Yloc = -1;
                Width = 0;
                Height = 0;
                Type = 0;
                Time = 100;
                FrameIndex = -1;
                Enable = false;
                Contrast = 255;
                PathPic = "";
                ColorPt = Color.Black;
                CorrectEventCode = -1;
                INcorrectEventCode = -1;
                _rewardType = -1;
            }

            public void SetContrastPts(int contrast)
            {
                Contrast = contrast;
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
                double ValX = Math.Atan((Xp - BasConfigs._monitor_resolution_x / 2) * BasConfigs.WidthM / (BasConfigs._monitor_resolution_x * BasConfigs.userDistance));
                Debug.Write(" Xp: "+ Xp + " WidthP : " + BasConfigs._monitor_resolution_x + " WidthM:" + BasConfigs.WidthM + " userDistance:" + BasConfigs.userDistance + " " + ((Xp - BasConfigs._monitor_resolution_x / 2) * BasConfigs.WidthM / (BasConfigs._monitor_resolution_x * BasConfigs.userDistance)) + "\n");
                return ValX;
            }

            private double ConvertDegreeY(int Yp)
            {
                double ValY = Math.Atan((Yp - BasConfigs._monitor_resolution_y / 2) * BasConfigs.HeightM / (BasConfigs._monitor_resolution_y * BasConfigs.userDistance));
                return ValY;
            }

            private double ConvertDegreeWidth(int Xp)
            {
                double ValX = Math.Atan(Xp * BasConfigs.WidthM / (BasConfigs._monitor_resolution_x * BasConfigs.userDistance));
                Debug.Write(" Xp: " + Xp + " WidthP : " + BasConfigs._monitor_resolution_x + " WidthM:" + BasConfigs.WidthM + " userDistance:" + BasConfigs.userDistance + " " + ((Xp - BasConfigs._monitor_resolution_x / 2) * BasConfigs.WidthM / (BasConfigs._monitor_resolution_x * BasConfigs.userDistance)) + "\n");
                return ValX;
            }

            private double ConvertDegreeHeight(int Yp)
            {
                double ValY = Math.Atan(Yp * BasConfigs.HeightM / (BasConfigs._monitor_resolution_y * BasConfigs.userDistance));
                return ValY;
            }
			
            private int ConvertPixelX(double Xd)
            {
                int ValX = Convert.ToInt16(Math.Tan(Xd * 3.1415 / 180) * BasConfigs._monitor_resolution_x * BasConfigs.userDistance / BasConfigs.WidthM + BasConfigs._monitor_resolution_x / 2);
                return ValX;
            }

            private int ConvertPixelY(double Yd)
            {
                int ValY = Convert.ToInt16(Math.Tan(Yd*3.1415/180) * BasConfigs._monitor_resolution_y * BasConfigs.userDistance / BasConfigs.HeightM + BasConfigs._monitor_resolution_y / 2);
                return ValY;
            }

            private int ConvertPixelWidth(double Xd)
            {
                int ValX = Convert.ToInt16(Math.Tan(Xd * 3.1415 / 180) * BasConfigs._monitor_resolution_x * BasConfigs.userDistance / BasConfigs.WidthM );
                return ValX;
            }

            private int ConvertPixelHeight(double Yd)
            {
                int ValY = Convert.ToInt16(Math.Tan(Yd * 3.1415 / 180) * BasConfigs._monitor_resolution_y * BasConfigs.userDistance / BasConfigs.HeightM );
                return ValY;
            }

        }
        #endregion

        private double ConvertDegreeX ( int Xp )
        {
            double ValX = Math.Atan((Xp - BasConfigs._monitor_resolution_x / 2) * BasConfigs.WidthM / (BasConfigs._monitor_resolution_x * BasConfigs.userDistance));
            //Debug.Write(" Xp: " + Xp + " WidthP : " + TaskPreview.WidthP + " WidthM:" + TaskPreview.WidthM + " userDistance:" + TaskPreview.userDistance + " " + ((Xp - TaskPreview.WidthP / 2) * TaskPreview.WidthM / (TaskPreview.WidthP * TaskPreview.userDistance)) + "\n");
            return ValX;
        }

        private double ConvertDegreeY(int Yp)
        {
            double ValY = Math.Atan((Yp - BasConfigs._monitor_resolution_y / 2) * BasConfigs.HeightM / (BasConfigs._monitor_resolution_y * BasConfigs.userDistance));
            return ValY;
        }
		
        private void Designer_Move(object sender, EventArgs e)
        {
            UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList);
        }

		private void Popup_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}
		
		private void txtEvent_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

        private void rdbShapeStim_CheckedChanged(object sender, EventArgs e)
        {
            pnlImageStim.Visible = !rdbShapeStim.Checked;
            pnlShapeStim.Visible = rdbShapeStim.Checked;
        }

        private void Objects_TV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 0)
                return;
            String Name = e.Node.Text;
            char IdName = Name[0];
            if (IdName == 'F')
            {
                _fixateAreaSelected = int.Parse(Regex.Match(Name, @"\d+").Value);


               
                //prompt.Text = "Fixation Edit Panel";
                Label SizeLabel = new Label() { Left = 30, Top = 30, Height = 15, Text = "Size :" };
                TextBox SizeTextBox = new TextBox { Left = 160, Top = 30, Width = 60, Text = Convert.ToString(fixationList[ActivePicB - 1][_fixateAreaSelected].Widthd) };
                SizeTextBox.TextChanged += delegate { this.FixationEditWidth(ActivePicB - 1, SizeTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };
                Label XLabel = new Label() { Left = 30, Top = 70, Height = 15, Text = "X :" };
                TextBox XTextBox = new TextBox { Left = 160, Top = 70, Width = 60, Text = Convert.ToString(fixationList[ActivePicB - 1][_fixateAreaSelected].Xlocd) };
                XTextBox.TextChanged += delegate { this.FixationEditX(ActivePicB - 1, XTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };
                Label YLabel = new Label() { Left = 30, Top = 110, Height = 15, Text = "Y :" };
                TextBox YTextBox = new TextBox { Left = 160, Top = 110, Width = 60, Text = Convert.ToString(fixationList[ActivePicB - 1][_fixateAreaSelected].Ylocd) };
                YTextBox.TextChanged += delegate { this.FixationEditY(ActivePicB - 1, YTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };
                Label TimeLabel = new Label() { Left = 30, Top = 150, Height = 15, Text = "Fixation Time :" };
                TextBox TimeTextBox = new TextBox { Left = 160, Top = 150, Width = 60, Text = Convert.ToString(fixationList[ActivePicB - 1][_fixateAreaSelected].Time) };
                TimeTextBox.TextChanged += delegate { this.FixationEditTime(ActivePicB - 1, TimeTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };
                Button RemoveButton = new Button { Left = 75, Top = 190, Width = 80, Text = Convert.ToString("Remove") };
                RemoveButton.Click += delegate { this.FixationRemove(ActivePicB - 1); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); UpdateTreeView(ActivePicB - 1); };

                FixationSetting FixationSettingForm = new FixationSetting();
                FixationSettingForm.ShowDialog();

            }

            if (IdName == 'S')
            {
                int IdIndex = int.Parse(Regex.Match(Name, @"\d+").Value);

                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm();
                prompt.ShowIcon = false;
                prompt.Name = "StimulusForm";
                prompt.Width = 250;
                prompt.Height = 300;
                //prompt.Text = "Stimulus Edit Panel";
                //Width
                Label SizeWLabel = new Label() { Left = 30, Top = 30, Text = "Size :" };
                TextBox SizeWTextBox = new TextBox { Left = 160, Top = 30, Width = 60, Text = Convert.ToString(stimulusList[IdIndex].Widthd) };
                SizeWTextBox.TextChanged += delegate { this.StimulusEditWidth(IdIndex, SizeWTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };
                //Height
                Label SizeHLabel = new Label() { Left = 30, Top = 70, Text = "Size :" };
                TextBox SizeHTextBox = new TextBox { Left = 160, Top = 70, Width = 60, Text = Convert.ToString(stimulusList[IdIndex].Heightd) };
                SizeHTextBox.TextChanged += delegate { this.StimulusEditHeight(IdIndex, SizeHTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };
                //X
                Label XLabel = new Label() { Left = 30, Top = 110, Text = "X :" };
                TextBox XTextBox = new TextBox { Left = 160, Top = 110, Width = 60, Text = Convert.ToString(stimulusList[IdIndex].Xlocd) };
                XTextBox.TextChanged += delegate { this.StimulusEditX(IdIndex, XTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };
                //Y
                Label YLabel = new Label() { Left = 30, Top = 150, Text = "Y :" };
                TextBox YTextBox = new TextBox { Left = 160, Top = 150, Width = 60, Text = Convert.ToString(stimulusList[IdIndex].Ylocd) };
                YTextBox.TextChanged += delegate { this.StimulusEditY(IdIndex, YTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };

                if (stimulusList[IdIndex].Type == 4 || stimulusList[IdIndex].Type == 8 || stimulusList[IdIndex].Type == 12)
                {
                    prompt.Height = 270;
                    //Path
                    Label PathLabel = new Label() { Left = 30, Top = 190, Width = 40, Text = "Path :" };
                    TextBox PathTextBox = new TextBox { Left = 75, Top = 190, Width = 120, Text = Convert.ToString(stimulusList[IdIndex].PathPic) };
                    Button PathButton = new Button() { Left = 200, Top = 190, Width = 30, Height = PathTextBox.Height, Text = "..." };
                    PathButton.Click += delegate { string VarPath = this.StimulusEditPath(IdIndex); PathTextBox.Text = VarPath; this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };

                    Button RemoveButton = new Button { Left = 85, Top = 230, Width = 80, Text = Convert.ToString("Remove") };
                    RemoveButton.Click += delegate { this.StimulusRemove(IdIndex); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); UpdateTreeView(ActivePicB - 1); prompt.Close(); };

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
                    Label ColorLabel = new Label() { Left = 30, Top = 180, Text = "Color :" };
                    Button ColorButton = new Button() { Left = 160, Top = 175, Width = 30, Height = 30, BackColor = stimulusList[IdIndex].ColorPt };
                    ColorButton.Click += delegate { this.StimulusEditColor(IdIndex); ColorButton.BackColor = stimulusList[IdIndex].ColorPt; this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };
                    //Contrast
                    Label ContrastLabel = new Label() { Left = 30, Top = 210, Text = "Contrast :" };
                    TextBox ContrastTextBox = new TextBox { Left = 160, Top = 210, Width = 60, Text = Convert.ToString(stimulusList[IdIndex].Contrast) };
                    ContrastTextBox.TextChanged += delegate { this.StimulusEditContrast(IdIndex, ContrastTextBox.Text); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); };

                    Button RemoveButton = new Button { Left = 85, Top = 250, Width = 80, Text = Convert.ToString("Remove") };
                    RemoveButton.Click += delegate { this.StimulusRemove(IdIndex); this.UpdateFrame(ActivePicB - 1, frameList, fixationList[ActivePicB - 1], stimulusList); UpdateTreeView(ActivePicB - 1); prompt.Close(); };

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
                prompt.ShowDialog();
            }

        }
		

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			PictureBox picb = pnlFrames.Controls.Find("PicB" + ActivePicB, true).FirstOrDefault() as PictureBox;
			using (Graphics newGr = pnlFrames.CreateGraphics())
				newGr.DrawRectangle(new Pen(Color.Red, 1), new Rectangle(picb.Location.X - 1, picb.Location.Y - 1, picb.Width + 1, picb.Height + 1));
		}
				
        private int ConvertPixelWidth(double Xd)
        {
            int ValX = Convert.ToInt16(Math.Tan(Xd * 3.1415 / 180) * BasConfigs._monitor_resolution_x * BasConfigs.userDistance / BasConfigs.WidthM);
            return ValX;
        }

        private int ConvertPixelHeight(double Yd)
        {
            int ValY = Convert.ToInt16(Math.Tan(Yd * 3.1415 / 180) * BasConfigs._monitor_resolution_y * BasConfigs.userDistance / BasConfigs.HeightM);
            return ValY;
        }

    }
}