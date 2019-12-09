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
using System.Runtime.InteropServices;

namespace TaskLab
{
    public partial class TaskGen : Form
    {

		#region Appearance
		[StructLayout(LayoutKind.Sequential)]
		public struct MARGINS
		{
			public int Left;
			public int Right;
			public int Top;
			public int Bottom;
		}

		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMargins);
		#endregion

		public Bitmap map = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
        
		Bitmap userMap = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
        
		Image<Rgb, Byte> img = new Image<Rgb, byte>(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
		
		bool isManupulated = false;
		
		MediaTask curTask = new MediaTask();

		int selectedSlide = 0, slideTime ,picCount;
        
		Point currentLocation;

		public TaskGen(TaskType mod)
        {
            InitializeComponent();
			
			switch (mod)
			{
				case TaskType.lab:
					{

						return;
						
					}
				case TaskType.media:
					{
						
						curTask = new MediaTask();
						
						break;
					}
				case TaskType.cognitive:
					{
						break;
					}
			}
			TaskDesignConfig();
		}
     
        void TaskGen_Load(object sender, EventArgs e)
        {
			MARGINS marg = new MARGINS() { Left = -1, Right = -1, Top = -1, Bottom = -1 };
			DwmExtendFrameIntoClientArea(this.Handle, ref marg);
			this.StartPosition = FormStartPosition.Manual;
			pbDesign.SizeMode = PictureBoxSizeMode.StretchImage;
			             
        }

		void pbDesign_MouseMove(object sender, MouseEventArgs e)
		{
			//lblX.Text = e.X.ToString();
			//lblY.Text = e.Y.ToString();
			
		}
				
		void btnBackGround_Click(object sender, EventArgs e)
        {
            ColorDialog cDilog = new ColorDialog();
			
			if (cDilog.ShowDialog() == DialogResult.OK)
            {
				//backGround = cDilog.Color;
				btnBackgroundCol.color = cDilog.Color;
				if (curTask.Type == TaskType.media)
				{
					//pbDesign.BackColor = btnBackgroundCol.color;
					if (selectedSlide != -1)
						curTask.picList[selectedSlide].bgColor = btnBackgroundCol.color;
					DrawSlides();

				}
            }
        }
				
		void btnSave_Click(object sender, EventArgs e)
        {
			if (curTask.Address == null)
				chkSaveData.Checked = true;
			else
				curTask.Save();
			
		}
        		      
        void btnLoad_Click(object sender, EventArgs e)
        {
			if (!CheckSave(true))
				return;
			PicturePanelReset();
			curTask.Load();
			TaskDesignConfig();
           
        }

        void btnStart_Click(object sender, EventArgs e)
        {
			btnStart.TileImage = Resource.stop;
		}
		
        void btnHome_Click(object sender, EventArgs e)
        {
					
			this.Close();
        }

        void btnSetting_Click(object sender, EventArgs e)
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

		//// هنگام فشردن کلید بر روی صفحه کلید وارد این تابع می شویم
		void Form1_KeyUp(object sender, KeyEventArgs e)
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
        void btnNewProject_Click(object sender, EventArgs e)
        {
			TaskType oldTaskType;
			if (CheckSave(true))
			{
				isManupulated = false;
				oldTaskType = curTask.Type;
				selectedSlide = -1;
				curTask = new MediaTask();
				TaskDesignConfig();
			}
				
        }

		bool CheckSave(bool message)
		{
			if (!isManupulated)
				return true;

			if (message && curTask.Address == null)
			{
				DialogResult result = DialogResult.Cancel;

				result = MetroMessageBox.Show((IWin32Window)this, "You did not save project. Continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, 100);
			
				if (result == DialogResult.OK)
				{
					curTask.Clear();


					return true;
				}
				else
					return false;
			}
			else
			{
				if (curTask.Save())
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

		void TaskDesignConfig()
		{
			if (curTask.Type == TaskType.lab)
			{
				
				
			}
			if (curTask.Type == TaskType.media)
			{
				pnlPics.Visible = true;
			
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

		void PicturePanelReset()
		{
			selectedSlide = -1;
			for (int i = pnlPics.Controls.Count - 1; i > 0; i--)
			{
				if (pnlPics.Controls[i].Name.Contains("pnl") && pnlPics.Controls[i].Name != "pnlAddPic")
					pnlPics.Controls.Remove(pnlPics.Controls[i]);
			}
			
			pnlAddPic.Location = new Point(3 + pnlPics.AutoScrollPosition.X, 5 + pnlPics.AutoScrollPosition.Y);
		}

        void btnAddPic_Click(object sender, EventArgs e)
        {
            Size s = SetupPb(picCount);
            AddPicture(s);
			picCount++;
			SelectSlide(picCount - 1);
            isManupulated = true;
        }
        
		void AddPicture(Size slidSize)
        {
			Bitmap b = BitmapManager.TextBitmap("Double Click To Add Media", btnBackgroundCol.BackColor, Brushes.Black, slidSize,15);
			
            Picture p = new Picture(b, null, slideTime);
            p.bgColor = btnBackgroundCol.BackColor;
            p.name = "pic" + picCount.ToString();
            curTask.picList.Add(p);
        }
        
		Size SetupPb(int index)
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
			if (curTask.picList.Count > index && curTask.picList[index].address != null)
			{
				txt.Text = curTask.picList[index].time.ToString();
				p.Image = curTask.picList[index].image;
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
        
		void RemoveSlide()
        {
			if (picCount == 0)
				return;
            foreach (Control pnl in pnlPics.Controls)
            {
                if (pnl.Name == "pnlPic" + selectedSlide.ToString())
                {
					curTask.picList.RemoveAt(selectedSlide);
					DrawSlides();
					SelectSlide(selectedSlide - 1);
					break;
                }
            }
        }
        // رسم اسلایدها درون پنل 
        
		void DrawSlides()
        {
			PicturePanelReset();
			picCount = 0;
			
            foreach (Picture slide in curTask.picList)
            {
                SetupPb(curTask.picList.IndexOf(slide));
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
        void pb_Click(object sender, EventArgs e)
        {
            PictureBox pbTemp = (PictureBox)sender;

			int ind;
            string name = pbTemp.Name;
            string[] index = name.Split('b');
            Int32.TryParse(index[1], out ind);

			SelectSlide(ind);

        }

        ///// هنگام دابل کلیک بر روی تصویر
        void pb_DoubleClick(object sender, EventArgs e)
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
				
				curTask.picList[index].image = new Bitmap(file.FileName);
				curTask.picList[index].address = file.FileName;
				
				pbDesign.Image = curTask.picList[index].image;
				
				SelectSlide(index);
			}
        }

		/// <summary>
		/// Get new slide index, set selectedSlide and setting its border to gray.
		/// Set new slide border to red.
		/// </summary>
		/// <param name="newSel"></param>
		void SelectSlide(int newSel)
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
        void txtPicTime_TextChanged(object sender, EventArgs e)
        {
            pnlPic_Click(sender, e);
        }
        
		//// هنگام کلیک بر روی پنل تصاویر
        void pnlPic_Click(object sender, EventArgs e)
        {
			int newSel;
			Panel pnlTemp = (Panel)sender;
			string[] seperate = pnlTemp.Name.Split('c');
            Int32.TryParse(seperate[1], out newSel);

			SelectSlide(newSel);
			
            //pnlPic_Paint(pnlTemp, new PaintEventArgs(pnlTemp.CreateGraphics(),pnlTemp.ClientRectangle));
        }

		void txtPicTime_Leave(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			string[] s = txt.Name.Split('e');
			int index;
			Int32.TryParse(s[1], out index);    // به دست اوردن اندیس
			int time;
			if (Int32.TryParse(txt.Text, out time))
				curTask.picList[index].time = time;
			else
				txt.Text = curTask.picList[index].time.ToString();
		}
		
		#endregion
		      
        void pnlSetting_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

		void TaskGen_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !CheckSave(true);
		}
				
		void tmrMain_Tick(object sender, EventArgs e)
		{
			if(curTask.Type == TaskType.media)
			{
				if (selectedSlide != -1)
					pbDesign.BackColor = curTask.picList[selectedSlide].bgColor;
				pbDesign.Image = curTask.GetFrame(selectedSlide, pbDesign.Size);
			}
		}

		void pnlPics_Paint(object sender, PaintEventArgs e)
		{
			Panel p = (Panel)sender;
			if (p.BorderStyle == BorderStyle.FixedSingle)
			{
				int thickness = 8;
				int halfThickness = thickness / 2;
				using (Pen pen = new Pen(Color.Black, thickness))
				{
					e.Graphics.DrawRectangle(pen, new Rectangle(halfThickness, halfThickness, p.ClientSize.Width - thickness, p.ClientSize.Height - thickness));
				}
			}
		}

		void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (chkboxChessDraw.Checked)
			{
				
				curTask.drawChess = true;
			}
			else
			{
				curTask.drawChess = false;
				
			}
		}
				
		void chkSaveData_CheckedChanged_1(object sender, EventArgs e)
		{
			if (chkSaveData.Checked)
			{
				if (curTask.Save())
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

		void cmbxSavMod_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbxSavMod.SelectedIndex == 0) ;
				curTask.SavingMode = SaveMod.bin;
				if (cmbxSavMod.SelectedIndex == 1) ;
				curTask.SavingMode = SaveMod.txt;
		}

		void chkbxMakTransprnt_CheckedChanged(object sender, EventArgs e)
		{
			if (chkbxMakTransprnt.Checked)
			{
				ColorDialog cd = new ColorDialog();
				if (cd.ShowDialog() == DialogResult.OK)
				{
					curTask.transColor = cd.Color;
					curTask.setTransparency = true;
				}
				else
					chkbxMakTransprnt.Checked = false;

			}
			else
				curTask.setTransparency = false;
		}

		private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			pnlSetting.Visible = !pnlSetting.Visible;
		}

		void btnHome_MouseEnter(object sender, EventArgs e)
		{
			btnHome.Style = MetroColorStyle.Red;
			tltpHelp.IsBalloon = false;
			tltpHelp.UseFading = true;
		}

		void btnHome_MouseLeave(object sender, EventArgs e)
		{
			btnHome.Style = MetroColorStyle.White;
		}

	}
	
}
