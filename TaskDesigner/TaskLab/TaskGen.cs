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
		
		bool isManupulated = false, reDraw = false;
		
		MediaTask curTask = new MediaTask();

		int selectedSlide = 0, slideTime ,picCount;
        
	
		public TaskGen()
        {
            InitializeComponent();
		}
     
        void TaskGen_Load(object sender, EventArgs e)
        {
			MARGINS marg = new MARGINS() { Left = -1, Right = -1, Top = -1, Bottom = -1 };
			DwmExtendFrameIntoClientArea(this.Handle, ref marg);
			this.StartPosition = FormStartPosition.Manual;
			pbDesign.SizeMode = PictureBoxSizeMode.StretchImage;
			curTask.operationSize = pbDesign.Size;    
        }

		void pbDesign_MouseMove(object sender, MouseEventArgs e)
		{
			lblX.Text = e.X.ToString();
			lblY.Text = e.Y.ToString();

		}
				
		void btnBackGround_Click(object sender, EventArgs e)
        {
            ColorDialog cDilog = new ColorDialog();

			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				//backGround = cDilog.Color;
				btnBackgroundCol.BackColor = cDilog.Color;

				if (selectedSlide != -1)
				{
					curTask.picList[selectedSlide].BGColor = btnBackgroundCol.BackColor;
                    pbDesign.Image = curTask.GetOperationFrame(false, selectedSlide);

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
			
			curTask.Load();
           
        }

        void btnStart_Click(object sender, EventArgs e)
        {
			btnStart.TileImage = Resource.stop;
			vlcControl1.Play(new FileInfo(curTask.picList[selectedSlide].Address));
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
			if (CheckSave(true))
			{
				isManupulated = false;
				curTask = new MediaTask();
                PicturePanelReset(-1);
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

		/// <summary>
		/// Clears  panels in pnlpic from end to slide with offset id itself and resets piccount to number of slides and selSlide to picCount;
		/// </summary>
		void PicturePanelReset(int Offset)
		{
			
			int i = picCount - 1;
			{
				for (; i > Offset;)
                {
                    Panel pnl = (Panel)pnlPics.Controls.Find("pnl" + selectedSlide.ToString(), false)[0];
                    pnlPics.Controls.Remove(pnl);
                }
					
			}
			picCount = Offset + 1;
            selectedSlide = Offset;
            while(curTask.picList.Count > picCount)
            {
                SetupPb(picCount);
                picCount++;
            }
			pnlAddPic.Location = new Point(5 , 155 * picCount + 5);
		}

        void btnAddPic_Click(object sender, EventArgs e)
        {
			AddPicture();
		}
        
		void AddPicture()
        {
			//create empty bitmap with defined color.
			MediaEelement p = new MediaEelement(btnBackgroundCol.BackColor, 0); 
            
			isManupulated = true;
			curTask.picList.Add(p);
            SetupPb(picCount);
            pnlAddPic.Location = new Point(pnlAddPic.Location.X,  5 + pnlAddPic.Height * (picCount + 1));
            SelectSlide(picCount);
            picCount++;
        }
        
		bool SetupPb(int index)
        {
            Panel pnl = new Panel();
            pnlPics.Controls.Add(pnl);
            pnl.Location = pnlAddPic.Location;
            pnl.Size = pnlAddPic.Size;
            pnl.MouseDown += new MouseEventHandler(pnlPic_Click);
            pnl.BorderStyle = BorderStyle.FixedSingle;
			pnl.BackColor = Color.FromArgb(232,216,201);
            pnl.ContextMenuStrip = ThumbPicsMenu;

			PictureBox p = new PictureBox();
            Label l = new Label();
            Label lblNumber = new Label();
            TextBox txt = new TextBox();
            
            p.Size = btnAddPic.Size;
			p.Visible = true;
			p.Location = new Point(10, 4);
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.MouseDown += new MouseEventHandler(pb_Click);
            p.DoubleClick += new EventHandler(pb_DoubleClick);
			p.Image = curTask.picList[index].Image;
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
			
			txt.Text = curTask.picList[index].Time.ToString();
			txt.Location = txtPicTime.Location;
            txt.Click += new EventHandler(txtPicTime_TextChanged);
            
            txt.Leave += new EventHandler(txtPicTime_Leave);
            Int32.TryParse(txtPicTime.Text, out slideTime);

            pnl.Name = "pnl" + index;
            p.Name = "pb" + index;
            txt.Name = "txtPicTime" + index;
            
           
			return true;
		}

        bool UpdateThumbList()
        {
            PictureBox pic = (PictureBox)pnlPics.Controls.Find("pb" + selectedSlide.ToString(), false)[0];
            pic.Image = curTask.picList[selectedSlide].Image;
            return true;
        }
		// پاک کردن اسلایدها
        void RemoveSlide()
        {
			if (picCount == 0)
				return;
			reDraw = true;
            foreach (Control pnl in pnlPics.Controls)
            {
                if (pnl.Name == "pnlPic" + selectedSlide.ToString())
                {
					curTask.picList.RemoveAt(selectedSlide);
					SelectSlide(picCount - 1);
					
					break;
                }
            }
        }
                
		       		
        //// هنگام کلیک بر روی تصویر
        void pb_Click(object sender, EventArgs e)
        {
			PictureBox pbTemp = (PictureBox)sender;

			int ind;
            string name = pbTemp.Name;
            string[] index = name.Split('b');
            Int32.TryParse(index[1], out ind);
			reDraw = true;
			SelectSlide(ind);

        }

        ///// هنگام دابل کلیک بر روی تصویر
        void pb_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files |*.png;*.jpg;*.jpeg;*.bmp | Video Files |*.mp4;*.avi;*.wmv;*.mpeg";
            if (file.ShowDialog() == DialogResult.OK)
            {
				System.Windows.Forms.PictureBox pbTemp = (System.Windows.Forms.PictureBox)sender;
                pbTemp.SizeMode = PictureBoxSizeMode.StretchImage;
								
                string name = pbTemp.Name;
                string[] texts = name.Split('b');
                int index = -1;
                Int32.TryParse(texts[1], out index);
				curTask.picList[index].Address = file.FileName;
				MediaType type = curTask.picList[index].VerifyElement();
				if(type == MediaType.Video)
				{
					TextBox text = (TextBox)pnlPics.Controls.Find("txtPicTime" + index.ToString(),true)[0];
					text.Enabled = false;
					text.Text = curTask.picList[index].Time.ToString();
				}
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
					selectedSlide = picCount - 1;
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
			reDraw = true;
			if(curTask.picList[selectedSlide].MediaTaskType == MediaType.Empty)
            {
                pbDesign.Visible = true;
                webBrowser.Visible = false;
                vlcControl1.Visible = false;
                pbDesign.Image = curTask.picList[selectedSlide].Image;
            }
            if (curTask.picList[selectedSlide].MediaTaskType == MediaType.Image)
            {
                pbDesign.Visible = true;
                webBrowser.Visible = false;
                vlcControl1.Visible = false;
                pbDesign.Image = curTask.picList[selectedSlide].Image;
            }
            if (curTask.picList[selectedSlide].MediaTaskType == MediaType.Video)
            {
                pbDesign.Visible = false;
                webBrowser.Visible = false;
                vlcControl1.Visible = true;
                vlcControl1.BackgroundImage = curTask.picList[selectedSlide].Image;
            }
            if (curTask.picList[selectedSlide].MediaTaskType == MediaType.Web)
            {
                pbDesign.Visible = true;
                webBrowser.Visible = true;
                vlcControl1.Visible = false;
                
                webBrowser.BringToFront();
                webBrowser.Navigate(curTask.picList[selectedSlide].URL);
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
			TextBox txt = (TextBox)sender;
			string[] s = txt.Name.Split('e');
			int index;
			Int32.TryParse(s[1], out index);
			SelectSlide(index);
			txt.Select();
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
				curTask.picList[index].Time = time;
			else
				txt.Text = curTask.picList[index].Time.ToString();
		}
		
		void TaskGen_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !CheckSave(true);
		}
				
		void tmrMain_Tick(object sender, EventArgs e)
		{
			if (!reDraw)
				return;
			if (selectedSlide == -1)
			{
				pbDesign.BackColor = SystemColors.ActiveCaption;
				
				return;
			}

			PictureBox picB = (PictureBox)pnlPics.Controls.Find("pb" + selectedSlide.ToString(), true)[0];
			//if (vlcControl1.IsPlaying)
			//	vlcControl1.Stop();
			if (curTask.picList[selectedSlide].MediaTaskType == MediaType.Image)
			{
				vlcControl1.Visible = false;
				pbDesign.Visible = true;
				btnStart.Enabled = false;
				pbDesign.Image = curTask.GetOperationFrame(reDraw, selectedSlide);
				picB.Image = pbDesign.Image;
			}
			else
			{
				vlcControl1.Visible = true;
				pbDesign.Visible = false;
				btnStart.Enabled = true;
				vlcControl1.BackgroundImageLayout = ImageLayout.Stretch;
				vlcControl1.BackgroundImage = curTask.GetOperationFrame(reDraw, selectedSlide);
				picB.Image = vlcControl1.BackgroundImage;				
			}
			reDraw = false;	
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
			reDraw = true;
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
			if (cmbxSavMod.SelectedIndex == 0) 
				curTask.SavingMode = SaveMod.bin;
				if (cmbxSavMod.SelectedIndex == 1)
				curTask.SavingMode = SaveMod.txt;
		}

		void chkbxMakTransprnt_CheckedChanged(object sender, EventArgs e)
		{
			if (chkbxMakTransprnt.Checked)
			{
				ColorDialog cd = new ColorDialog();
				if (cd.ShowDialog() == DialogResult.OK)
				{
					curTask.picList[selectedSlide].TransColor = cd.Color;
					curTask.picList[selectedSlide].UseTransparency = true;
				}
				else
					chkbxMakTransprnt.Checked = false;

			}
			else
				curTask.picList[selectedSlide].UseTransparency = false;
			reDraw = true;
		}
		
		private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pnlSetting.Visible = true;
        }

        private void enterWebURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
			URLInput url = new URLInput();
			if(url.ShowDialog() == DialogResult.OK)
			{
				curTask.picList[selectedSlide].MediaTaskType = MediaType.Web;
				curTask.picList[selectedSlide].URL = url.txtbxURL.Text;
				url.Dispose(); url = null;
			}
        }

        private void TaskGen_SizeChanged(object sender, EventArgs e)
		{
			curTask.operationSize = pbDesign.Size;
			pnlSetting.Width = pbDesign.Size.Width - 14;
		}
		
	}
	
}
