using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Media;
using Psychophysics;
using MetroFramework;
using Basics;
using TaskDesigner;

namespace TaskLab
{
    public partial class TaskGen : Form
    {
		public Bitmap map = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
        
		private Bitmap userMap = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
        
		private Image<Rgb, Byte> img = new Image<Rgb, byte>(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
		
		private bool isManupulated = false;
		
		private TaskClient curTask = new TaskClient();

		private int movementNode;
        private bool objectSelect;

		int selectedSlide = 0, slideTime ,picCount;
        private Point[] Priority = new Point[15];
		Point currentLocation;

		private bool circleSelected = false;
		private bool rectSelected = false;
      
        int changedPriority = 100;


		#region mouse move form
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();
		#endregion

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		public TaskGen(TaskType mod)
        {
            InitializeComponent();
			
			switch (mod)
			{
				case TaskType.lab:
					{
						
						curTask = new TaskClient(TaskType.lab);
						
						break;
					}
				case TaskType.media:
					{
						
						curTask = new TaskClient(TaskType.media);
						
						break;
					}
				case TaskType.cognitive:
					{
						break;
					}
			}
			TaskDesignConfig();
		}
     
        private void TaskGen_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
			pbDesign.SizeMode = PictureBoxSizeMode.StretchImage;
			Location = new Point(50,0);          
            btnRemove.Enabled = false;
            btnChange.Enabled = false;
            btnCancel.Enabled = false;
            pnlSetting.Visible = false;
           
			pnlShapeProp.Enabled = false;
            pnlFixation.Enabled = false;
            foreach (var item in Enum.GetValues(typeof(MetroFramework.MetroColorStyle)))
            {
                cmbTheme.Items.Add(item);
            }
            cmbTheme.SelectedIndex = 10;
           
                       
        }

		private void pbDesign_MouseMove(object sender, MouseEventArgs e)
		{
			lblC.Text = e.X.ToString();
			lblR.Text = e.Y.ToString();
			if (objectSelect == true)
			{

				//fixationList[fIndex].pos = new Point(e.X * 3 / 2, e.Y * 3 / 2);
				
				//int sIndex = curTask.PsycoTask.shapeList.IndexOf(movementNode);
				//curTask.PsycoTask.shapeList[sIndex].pos = new Point(e.X * 3 / 2, e.Y * 3 / 2);
				pbDesign.Cursor = Cursors.Arrow;
			}
		}

		private void btnShapeColor_Click(object sender, EventArgs e)
        {
            ColorDialog cDilog = new ColorDialog();
            if (cDilog.ShowDialog() == DialogResult.OK)
            {
                btnShapeColor.BackColor = cDilog.Color;
            }
        }

        private void pbDesign_Click(object sender, EventArgs e)
        {
            //btnInsert.Visible = true;
            int column, row;
            Int32.TryParse(lblR.Text, out column);
            Int32.TryParse(lblC.Text, out row);
            column--;
            row--;
            //if(shapeTree[column,row] != null && shapeTree[column,row].enable == true)
            //{
            //    LoadNode(column, row);
            //    pnlShapeProp.Visible = true;
            //    btnRemove.Visible = true;
            //}
            //else
            //{
            //    LoadDefaultParameters();
            //    btnRemove.Visible = false;
            //}
        }
        		       
	
        
		private void btnInsert_Click(object sender, EventArgs e)
        {
          
        }

            
		
               
		private void btnBackGround_Click(object sender, EventArgs e)
        {
            ColorDialog cDilog = new ColorDialog();
			
			if (cDilog.ShowDialog() == DialogResult.OK)
            {
				//backGround = cDilog.Color;
				btnBackgroundCol.color = cDilog.Color;
				if (curTask.Type == TaskType.lab)
				{
					curTask.PsycoTask.backColor = cDilog.Color;
					curTask.PsycoTask.DrawMap();

				}
				else if (curTask.Type == TaskType.media)
				{
					//pbDesign.BackColor = btnBackgroundCol.color;
					if (selectedSlide != -1)
						curTask.MediaTask.picList[selectedSlide].bgColor = btnBackgroundCol.color;
					DrawSlides();

				}
            }
        }
				
		private void btnSave_Click(object sender, EventArgs e)
        {
			if (curTask.Address == null)
				chkSaveData.Checked = true;
			else
				curTask.SaveTask();
			
		}
        		      
        private void btnLoad_Click(object sender, EventArgs e)
        {
			if (!CheckSave(true))
				return;
			PicturePanelReset();
			curTask.LoadTask(true);
			TaskDesignConfig();
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
			btnStart.TileImage = Resource.stop;
		}
		
     //   private void SetFixation()
     //   {
     //       for (int i = 0; i < curTask.PsycoTask.fixationList.Count; i++)
     //       {
     //           if (curTask.PsycoTask.fixationList[i] != null && curTask.PsycoTask.fixationList[i].enable == true)
     //           {
     //               ROIPos = curTask.PsycoTask.fixationList[i].pos;
     //               ROISize = curTask.PsycoTask.fixationList[i].width;
     //               ROITime = curTask.PsycoTask.fixationList[i].fixationTime;
					//curTask.PsycoTask.fixationList[i].enable = false;
     //               return;
     //           }
     //       }
     //   }
        
		//private void rbShape_CheckedChanged(object sender, EventArgs e)
  //      {
  //          //if (rbShape.Checked)
  //          if (true)
  //          {
  //              pnlShapeProp.Visible = true;
  //              pnlShapeProp.Enabled = true;
  //              pnlShapeProp.BringToFront();
  //              //cmbShape.SelectedIndex = 0;
  //              cmbNumber.SelectedIndex = 0;
  //          }
  //      }

        private void rbFixation_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbFixation.Checked)
            if (true)
            {
                //pnlFixationProp.Visible = true;
                //pnlFixationProp.Enabled = true;
                //pnlFixationProp.BringToFront();
                //cmbPriority.SelectedIndex = 0;
            }
        }
			
		private void treObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (tempFixate != -1)
            //    cmbPriority.Items.Remove(tempFixate);
            //if (e.Node.Level == 1)
            //{ 
            //    if (e.Node.Parent.Name == "nodeShapes")
            //    {
            //        btnInsert.Visible = false;
            //        btnCancel.Visible = true;
            //        btnChange.Visible = true;
            //        btnRemove.Visible = true;
            //        pnlShape.Enabled = true;

            //        string[] sp = e.Node.Text.Split('S');
            //        int index;
            //        Int32.TryParse(sp[1], out index);
            //        if(changedPriority != 100)
            //        {
            //            if (changedPriority > 0)
            //                positivePriority.Remove(changedPriority.ToString());
            //            else if (changedPriority < 0)
            //                negativePriority.Remove(changedPriority.ToString());
            //        }
            //        ShowNode(curTask.PsycoTask.shapeList[index]);
            //        btnRemove.Enabled = true;
            //    }
            //}
        }

        private void btnFixationColor_Click(object sender, EventArgs e)
        {
            ColorDialog cDilog = new ColorDialog();
            if (cDilog.ShowDialog() == DialogResult.OK)
            {
                btnFixationColor.BackColor = cDilog.Color;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if(changedPriority != 100)
            //{
            //    if(changedPriority > 0)
            //    {
            //        positivePriority.Remove(changedPriority.ToString());
            //        changedPriority = 100;
            //    }
            //    if (changedPriority < 0)
            //    {
            //        negativePriority.Remove(changedPriority.ToString());
            //        changedPriority = 100;
            //    }
            //}
            //pnlShape.Enabled = false;
            //chkROI.Checked = false;
            //cmbPriority.Items.Remove(tempFixate);
            //tempFixate = -1;
            ////cmbPriority.SelectedIndex = 0;
            //btnChange.Visible = false;
            //btnRemove.Visible = false;
            //btnCancel.Visible = false;
            //btnInsert.Visible = true;
            ////rbFixation.Visible = true;
            ////rbShape.Visible = true;
            //treObjects.CollapseAll();
        }

       				
        //// انتخاب کردن اشیا جهت ادیت و حذف و جابجایی
        private void pbDesign_MouseDown(object sender, MouseEventArgs e)
        {
		
		
        }

		private void pbDesign_MouseUp(object sender, MouseEventArgs e)
		{
			
		}
        //// کامل کردن نمایش درختی
        
		        
		private void UpdateTree(int index, int label)
        {
            treObjects.Nodes[0].Nodes.Add("S" + label.ToString());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
					
			this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
			if (!pnlSetting.Visible)
			{
				btnSetting.Style = MetroColorStyle.Yellow;
				
				pnlSetting.BringToFront();
				pnlSetting.Visible = true;
			}
			else
			{
				btnSetting.Style = MetroColorStyle.White;
				
				pnlSetting.BringToFront();
				pnlSetting.Visible = false; ;
			}

        }

		//// برای تغییر تم برنامه و تغییر رنگ ابزارها
        private void ChangeTheme()
        {
           
            btnSave.Style = (MetroFramework.MetroColorStyle)cmbTheme.SelectedIndex;
            btnSave.Refresh();
            btnLoad.Style = (MetroFramework.MetroColorStyle)cmbTheme.SelectedIndex;
            btnLoad.Refresh();
            btnStart.Style = (MetroFramework.MetroColorStyle)cmbTheme.SelectedIndex;
            btnStart.Refresh();
           
            btnSetting.Style = (MetroFramework.MetroColorStyle)cmbTheme.SelectedIndex;
            btnSetting.Refresh();
            
            
            btnHome.Style = (MetroFramework.MetroColorStyle)cmbTheme.SelectedIndex;
            btnHome.Refresh();
            btnNewProject.Style = (MetroFramework.MetroColorStyle)cmbTheme.SelectedIndex;
            btnNewProject.Refresh();
            btnAddPic.Style = (MetroFramework.MetroColorStyle)cmbTheme.SelectedIndex;
            btnAddPic.Refresh();
            //txttemp.LineIdleColor = Color.FromName(cmbTheme.SelectedItem.ToString());
        }

        private Color getMetroColor()  //A: "color" type is drawing and "metrocolor." also gives a drawing type
        {
            switch (cmbTheme.SelectedIndex)
            {
                case 0:
                    return MetroColors.Pink;
                case 1:
                    return MetroColors.Black;
                case 2:
                    return MetroColors.White;
                case 3:
                    return MetroColors.Silver;
                case 4:
                    return MetroColors.Blue;
                case 5:
                    return MetroColors.Green;
                case 6:
                    return MetroColors.Lime;
                case 7:
                    return MetroColors.Teal;
                case 8:
                    return MetroColors.Orange;
                case 9:
                    return MetroColors.Brown;
                case 10:
                    return MetroColors.Pink;
                case 11:
                    return MetroColors.Magenta;
                case 12:
                    return MetroColors.Purple;
                case 13:
                    return MetroColors.Red;
                case 14:
                    return MetroColors.Yellow;
                default:
                    return MetroColors.Blue;

            }


        }

		//// هنگام فشردن کلید بر روی صفحه کلید وارد این تابع می شویم
		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (pnlPics.Visible == true)
				{
					RemoveSlide();
					
				}
			}
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();

			}
			if(e.KeyCode == Keys.Up)
			{
				if(curTask.Type == TaskType.media)
				{
					SelectSlide(selectedSlide-1);
				}
			}
			if (e.KeyCode == Keys.Down)
			{
				if (curTask.Type == TaskType.media)
				{
					SelectSlide(selectedSlide + 1);
				}
			}
		}

        //// ایجاد پروژه جدید
        private void btnNewProject_Click(object sender, EventArgs e)
        {
			TaskType oldTaskType;
			if (CheckSave(true))
			{
				isManupulated = false;
				oldTaskType = curTask.Type;
				selectedSlide = -1;
				curTask = new TaskClient(oldTaskType);
				TaskDesignConfig();
			}
				
        }

		private bool CheckSave(bool message)
		{
			if (!isManupulated)
				return true;

			if (message && curTask.Address == null)
			{
				DialogResult result = DialogResult.Cancel;

				result = MetroMessageBox.Show((IWin32Window)this, "You did not save project. Continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, 100);
			
				if (result == DialogResult.OK)
				{
					curTask.ClearTask();


					return true;
				}
				else
					return false;
			}
			else
			{
				if (curTask.SaveTask())
					return true;
				else
				{
					if (message)
						if (MetroMessageBox.Show((IWin32Window)this, "Can not save project in file or cancel pressed. continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, 100) == DialogResult.OK)
							return true;
						else
							return false;
					else
						return false;
				}
			}
		}

		private void TaskDesignConfig()
		{
			if (curTask.Type == TaskType.lab)
			{
				pnlPics.Visible = false;
				pnlTask.Visible = true;
				pnlFixation.Visible = true;
				pnlShape.Visible = true;
				
			}
			if (curTask.Type == TaskType.media)
			{
				pnlPics.Visible = true;
				pnlTask.Visible = false;
				selectedSlide = -1;
				DrawSlides();
				tmrMain.Start();
			}
			if (curTask.Type == TaskType.cognitive)
			{
				Close();
			}
		}

		#region Picture Task

		private void PicturePanelReset()
		{
			selectedSlide = -1;
			for (int i = pnlPics.Controls.Count - 1; i > 0; i--)
			{
				if (pnlPics.Controls[i].Name.Contains("pnl") && pnlPics.Controls[i].Name != "pnlAddPic")
					pnlPics.Controls.Remove(pnlPics.Controls[i]);
			}
			
			pnlAddPic.Location = new Point(3 + pnlPics.AutoScrollPosition.X, 5 + pnlPics.AutoScrollPosition.Y);
		}

        private void btnAddPic_Click(object sender, EventArgs e)
        {
            Size s = SetupPb(picCount);
            AddPicture(s);
			picCount++;
			SelectSlide(picCount - 1);
            isManupulated = true;
        }
        
		private void AddPicture(Size slidSize)
        {
			Bitmap b = BitmapManager.TextBitmap("Double Click To Add Image", btnBackgroundCol.BackColor, Brushes.Black, slidSize,15);
			
            Picture p = new Picture(b, null, slideTime);
            p.bgColor = btnBackgroundCol.BackColor;
            p.name = "pic" + picCount.ToString();
            curTask.MediaTask.picList.Add(p);
        }
        
		private Size SetupPb(int index)
        {
            Panel pnl = new Panel();
            pnlPics.Controls.Add(pnl);
            pnl.Location = pnlAddPic.Location;
            pnl.Size = pnlAddPic.Size;
            pnl.Click += new EventHandler(pnlPic_Click);
			pnl.BorderStyle = BorderStyle.FixedSingle;
           

            PictureBox p = new PictureBox();
            Label l = new Label();
            Label lblNumber = new Label();
            TextBox txt = new TextBox();
            

            p.Size = btnAddPic.Size;
			p.Visible = true;
			p.Image = BitmapManager.TextBitmap("Double Click To Add Image",btnBackgroundCol.BackColor, Brushes.Black, p.Size,15);

            p.Location = new Point(10, 4);
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Click += new EventHandler(pb_Click);
            p.DoubleClick += new EventHandler(pb_DoubleClick);
			pnl.Controls.Add(p);
			
            l.Text = "Time:(ms)";
           
            l.Location = lblPicTime.Location;
            l.Size = new Size(52, 13);
			pnl.Controls.Add(l);
			lblNumber.Text = (picCount + 1).ToString();
            pnl.Controls.Add(lblNumber);
            
            lblNumber.Location = lblSlideNumber.Location;
            lblNumber.Size = new Size(39, 13);
            pnl.Controls.Add(txt);
            txt.Size = txtPicTime.Size;
			if (curTask.MediaTask.picList.Count > index && curTask.MediaTask.picList[index].address != null)
			{
				txt.Text = curTask.MediaTask.picList[index].time.ToString();
				p.Image = curTask.MediaTask.picList[index].image;
			}
			else
				txt.Text = txtPicTime.Text;
            
            txt.Location = txtPicTime.Location;
            txt.Click += new EventHandler(txtPicTime_TextChanged);
            
            txt.Leave += new EventHandler(txtPicTime_Leave);
            Int32.TryParse(txtPicTime.Text, out slideTime);

            pnl.Name = "pnlPic" + index;
            p.Name = "pb" + index;
            txt.Name = "txtPicTime" + index;

            pnlAddPic.Location = new Point(pnlAddPic.Location.X, pnlAddPic.Location.Y + 160);
            currentLocation = pnlAddPic.Location;
			return p.Size;
		}
        
		// پاک کردن اسلایدها
        
		private void RemoveSlide()
        {
			if (picCount == 0)
				return;
            foreach (Control pnl in pnlPics.Controls)
            {
                if (pnl.Name == "pnlPic" + selectedSlide.ToString())
                {
					curTask.MediaTask.picList.RemoveAt(selectedSlide);
					DrawSlides();
					SelectSlide(selectedSlide - 1);
					break;
                }
            }
        }
        // رسم اسلایدها درون پنل 
        
		private void DrawSlides()
        {
			PicturePanelReset();
			picCount = 0;
			
            foreach (Picture slide in curTask.MediaTask.picList)
            {
                SetupPb(curTask.MediaTask.picList.IndexOf(slide));
				picCount++;
            }
        }
       
		 //// رسم کردن اسلاید اضاقه کردن
        //private void DrawAddSlide()
        //{
        //    Panel pnl = new Panel();
        //    MetroFramework.Controls.MetroTile mTile = new MetroFramework.Controls.MetroTile();
        //    Label l = new Label();
        //    TextBox txt = new TextBox();

        //    pnlPics.Controls.Add(pnl);
        //    pnl.Size = new Size(200, 150);
        //    pnl.Location = new Point(3, 5);
        //    pnl.Name = "pnlAddPic";
        //    pnl.Controls.Add(mTile);
        //    pnl.Controls.Add(l);
        //    pnl.Controls.Add(txt);

        //    mTile.Size = new Size(180, 112);
        //    mTile.Location = new Point(10, 4);
        //    mTile.Text = "ADD";
        //    mTile.TileImage = Resource.addpic;
        //    mTile.Style = MetroFramework.MetroColorStyle.Pink;
        //    mTile.Click += new EventHandler(btnAddPic_Click);

        //    txt.Size = new Size(100, 20);
        //    txt.Location = new Point(89, 122);
        //    txt.Text = curTask.picList[curTask.picList.Count - 1].time.ToString();
        //    txt.TextChanged += new EventHandler(txtPicTime_TextChanged);
        //    txt.Name = "txtPicTime";

        //    l.Text = "Time:";
        //    l.Size = new Size(33, 13);
        //    l.Location = new Point(9, 124);
        //}

        //// هنگام کلیک بر روی تصویر
        private void pb_Click(object sender, EventArgs e)
        {
            PictureBox pbTemp = (PictureBox)sender;

			int ind;
            string name = pbTemp.Name;
            string[] index = name.Split('b');
            Int32.TryParse(index[1], out ind);

			SelectSlide(ind);

        }

        ///// هنگام دابل کلیک بر روی تصویر
        private void pb_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files |*.png;*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                PictureBox pbTemp = (PictureBox)sender;
                pbTemp.SizeMode = PictureBoxSizeMode.StretchImage;
                pbTemp.Image = new Bitmap(file.FileName);

                string name = pbTemp.Name;
                string[] texts = name.Split('b');
                int index;
                Int32.TryParse(texts[1], out index);
				
				curTask.MediaTask.picList[index].image = new Bitmap(file.FileName);
				curTask.MediaTask.picList[index].address = file.FileName;
				
				pbDesign.Image = curTask.MediaTask.picList[index].image;
				
				SelectSlide(index);
			}
        }

		/// <summary>
		/// Get new slide index, set selectedSlide and setting its border to gray.
		/// Set new slide border to red.
		/// </summary>
		/// <param name="newSel"></param>
		private void SelectSlide(int newSel)
		{
			int oldInd = -1;
			if (newSel == -1)
			{
				if (picCount > 0)
					selectedSlide = 0;
				else
				{
					selectedSlide = -1;
					return;
				}
			}
			else
			{
				if (newSel == picCount)
					return;
				else
				{
					oldInd = selectedSlide;
					selectedSlide = newSel;
				}
			}
			
			 
			foreach (Control c in pnlPics.Controls)
			{
				if (c.Name == "pnlPic" + oldInd.ToString())
				{
					Panel pnlTemp = (Panel)c;
					ControlPaint.DrawBorder(pnlTemp.CreateGraphics(), pnlTemp.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
				}
				if (c.Name == "pnlPic" + newSel.ToString())
				{
					Panel pnlTemp = (Panel)c;
					ControlPaint.DrawBorder(pnlTemp.CreateGraphics(), pnlTemp.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
					pnlTemp.Select();
				}
			}
		}

        //// هنگام کلیک بر روی تکست باکس زمان
        private void txtPicTime_TextChanged(object sender, EventArgs e)
        {
            //pnlPic_Click(sender, e);
        }
        
		//// هنگام کلیک بر روی پنل تصاویر
        private void pnlPic_Click(object sender, EventArgs e)
        {
			int newSel;
			Panel pnlTemp = (Panel)sender;
			string[] seperate = pnlTemp.Name.Split('c');
            Int32.TryParse(seperate[1], out newSel);

			SelectSlide(newSel);
			
            //pnlPic_Paint(pnlTemp, new PaintEventArgs(pnlTemp.CreateGraphics(),pnlTemp.ClientRectangle));
        }

		private void txtPicTime_Leave(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			string[] s = txt.Name.Split('e');
			int index;
			Int32.TryParse(s[1], out index);    // به دست اوردن اندیس
			int time;
			if (Int32.TryParse(txt.Text, out time))
				curTask.MediaTask.picList[index].time = time;
			else
				txt.Text = curTask.MediaTask.picList[index].time.ToString();
		}
		
		#endregion
		
		private void chkROI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkROI.Checked == true)
            {
                pnlFixation.Enabled = true;
                rbPFixate.Checked = true;
            }
            else
            {
                pnlFixation.Enabled = false;
                rbPFixate.Checked = false;
            }
        }

        private void btnFixationColor_Click_1(object sender, EventArgs e)
        {
            ColorDialog cDilog = new ColorDialog();
            if (cDilog.ShowDialog() == DialogResult.OK)
            {
                btnFixationColor.BackColor = cDilog.Color;
            }
        }

        private void rbPFixate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPFixate.Checked == true)
            {
                //UpdateCmbPriority('P');
            }
        }

        //private void UpdateCmbPriority(char priority)
        //{
        //    if (priority == 'P')
        //    {
        //        //foreach (FNode node in positiveFixates)
        //        //{
        //        //    if(node.priority != changedPriority)
        //        //        positivePriority.Remove(node.priority.ToString());
        //        //}
        //        cmbPriority.Items.Clear();
        //        foreach (string s in positivePriority)
        //        {
        //            cmbPriority.Items.Add(s);
        //        }
        //        cmbPriority.SelectedIndex = 0;
        //    }
        //    else if(priority == 'N')
        //    {
        //        //foreach (FNode node in negativeFixates)
        //        //{
        //        //    if (node.priority != changedPriority)
        //        //        negativePriority.Remove(node.priority.ToString());
        //        //}
        //        cmbPriority.Items.Clear();
        //        foreach (string s in negativePriority)
        //        {
        //            cmbPriority.Items.Add(s);
        //        }
        //        cmbPriority.SelectedIndex = 0;
        //    }
        //}

        private void pnlSetting_MouseClick(object sender, MouseEventArgs e)
        {
            //pnlguide.Visible = false;
            //pnlSetting.Visible = false;
           
        }

       	private void pbDesign_MouseClick(object sender, MouseEventArgs e)
		{
			txtPosX.Text = e.X.ToString();
			txtPosY.Text = e.Y.ToString();
		}

		private void TaskGen_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !CheckSave(true);
		}

		
		private void tmrMain_Tick(object sender, EventArgs e)
		{
			if(curTask.Type == TaskType.media)
			{
				if (selectedSlide != -1)
					pbDesign.BackColor = curTask.MediaTask.picList[selectedSlide].bgColor;
				pbDesign.Image = curTask.GetFrameImage(selectedSlide, pbDesign.Size);
			}
		}

		private void pnlPics_Paint(object sender, PaintEventArgs e)
		{
			Panel p = (Panel)sender;
			if (p.BorderStyle == BorderStyle.FixedSingle)
			{
				int thickness = 8;
				int halfThickness = thickness / 2;
				using (Pen pen = new Pen(Color.Black, thickness))
				{
					e.Graphics.DrawRectangle(pen, new Rectangle(halfThickness, halfThickness, p.ClientSize.Width - thickness, pnlTree.ClientSize.Height - thickness));
				}
			}
		}

		private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (chkboxChessDraw.Checked)
			{
				
				curTask.MediaTask.drawChess = true;
			}
			else
			{
				curTask.MediaTask.drawChess = false;
				
			}
		}

		private void btnCircle_Click_1(object sender, EventArgs e)
		{
			if (!circleSelected)
			{
				circleSelected = true;
				rectSelected = false;
				pnlShapeProp.Enabled = true;
				btnCircle.BackColor = Color.Gray;
				btnRectangle.BackColor = Color.Transparent;
			}
			else
			{
				circleSelected = false;
				pnlShapeProp.Enabled = false;
				chkROI.Checked = false;
				btnCircle.BackColor = Color.Transparent;
			}
		}

		private void btnRectangle_Click_1(object sender, EventArgs e)
		{
			if (!rectSelected)
			{
				rectSelected = true;
				circleSelected = false;
				pnlShapeProp.Enabled = true;
				btnRectangle.BackColor = Color.Gray;
				btnCircle.BackColor = Color.Transparent;
			}
			else
			{
				rectSelected = false;
				pnlShapeProp.Enabled = false;
				chkROI.Checked = false;
				btnRectangle.BackColor = Color.Transparent;
			}
		}

		private void chkSaveData_CheckedChanged_1(object sender, EventArgs e)
		{
			if (chkSaveData.Checked)
			{
				if (curTask.SaveTask())
					txtPath.Text = curTask.Address;
				else
					chkSaveData.Checked = false;
			}
			else
			{
				txtPath.Text = "";
				curTask.UnSave();
			}
		}

		private void cmbxSavMod_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbxSavMod.SelectedIndex == 0) ;
				//curTask.tskSavMod = SaveMod.bin;
				if (cmbxSavMod.SelectedIndex == 1) ;
				//curTask.tskSavMod = SaveMod.txt;
		}

		private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e)
		{
			ChangeTheme();
		}

		private void chkbxMakTransprnt_CheckedChanged(object sender, EventArgs e)
		{
			if (chkbxMakTransprnt.Checked)
			{
				ColorDialog cd = new ColorDialog();
				if (cd.ShowDialog() == DialogResult.OK)
				{
					curTask.MediaTask.transColor = cd.Color;
					curTask.MediaTask.setTransparency = true;
				}
				else
					chkbxMakTransprnt.Checked = false;

			}
			else
				curTask.MediaTask.setTransparency = false;
		}

		
		private void btnHome_MouseEnter(object sender, EventArgs e)
		{
			btnHome.Style = MetroColorStyle.Red;
			tltpHelp.IsBalloon = false;
			tltpHelp.UseFading = true;
		}

		private void btnHome_MouseLeave(object sender, EventArgs e)
		{
			btnHome.Style = MetroColorStyle.White;
		}

	}
	
}
