using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework;
using Basics;
using TaskDesigner;
using System.Runtime.InteropServices;
using CefSharp;
using CefSharp.WinForms;


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
		int selectedSlide = -1, slideTime , picCount, oldInd;
		List<Panel> thumbs = new List<Panel>();
		Color _formBackColor = Color.FromArgb(232, 216, 201);
        public ChromiumWebBrowser webBrowser;

        public void InitBrowser()
        {
            Cef.Initialize(new CefSettings());
            webBrowser = new ChromiumWebBrowser("www.google.com");
            splitContainer1.Panel2.Controls.Add(webBrowser);
            webBrowser.Dock = DockStyle.Fill;
            //browser.Visible = false;
        }

        public TaskGen()
        {
            InitializeComponent();
            InitBrowser();
		}
            
		/// <summary>
		/// Clears  panels in pnlpic from end to slide with offset id itself and resets piccount to number of slides and selSlide to picCount;
		/// </summary>
		void PicturePanelReset(int Offset)
		{
			Point newLocation;
			int i = picCount - 1;
			{
				for (; i > Offset;)
                {
                    pnlPics.Controls.Remove(thumbs[i]);
					thumbs.RemoveAt(i);
					i--;
                }
					
			}
			picCount = Offset + 1;
            selectedSlide = Offset;

			if (thumbs.Count == 0)
				newLocation = new Point(5, 5);
			else
				newLocation = new Point(thumbs[thumbs.Count - 1].Location.X , thumbs[thumbs.Count - 1].Location.Y + thumbs[thumbs.Count - 1].Height + 10);
			
			while (curTask.picList.Count > picCount)
            {
				thumbs.Add(CreateSlide(picCount, newLocation));
				newLocation = new Point(thumbs[thumbs.Count - 1].Location.X, thumbs[thumbs.Count - 1].Location.Y + thumbs[thumbs.Count - 1].Height + 10);
				picCount++;
            }
			if(thumbs.Count > 0)
				pnlAddPic.Location = new Point(thumbs[picCount - 1].Location.X , thumbs[picCount - 1].Location.Y + thumbs[picCount - 1].Height + 10);
			else
				pnlAddPic.Location = new Point(5 , 5);
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
			picCount++;
			thumbs.Add(CreateSlide(picCount - 1, pnlAddPic.Location));
			pnlAddPic.Location = new Point(pnlAddPic.Location.X, pnlAddPic.Location.Y + pnlAddPic.Height + 10);
			SelectSlide(picCount - 1);
		}
        
		Panel CreateSlide(int index, Point panelLocation)
        {
			try
			{
				//Create new panel
				Panel pnl = new Panel();
				pnl.Location = panelLocation;
				pnl.Size = pnlAddPic.Size;
				pnl.MouseDown += new MouseEventHandler(pnlPic_Click);
				pnl.BackColor = _formBackColor;
				pnl.ContextMenuStrip = ThumbPicsMenu;
				pnl.Move += Thumb_Move;

				PictureBox p = new PictureBox();
				Label l = new Label();
				Label lblNumber = new Label();
				TextBox txt = new TextBox();
				//Create picturebox for panel
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

				//Create number label for panel
				lblNumber.Text = (index).ToString();
				lblNumber.Location = lblSlideNumber.Location;
				lblNumber.Size = new Size(39, 13);
				pnl.Controls.Add(lblNumber);
				
				//Create textbox for panel	
				txt.Size = txtPicTime.Size;
				txt.Text = curTask.picList[index].Time.ToString();
				
				if (curTask.picList[index].MediaTaskType == MediaType.Video)
					txt.Enabled = false;

				txt.Location = txtPicTime.Location;
				txt.Click += new EventHandler(txtPicTime_TextChanged);
				txt.Leave += new EventHandler(txtPicTime_Leave);
				Int32.TryParse(txtPicTime.Text, out slideTime);
				pnl.Controls.Add(txt);

				pnl.Name = "pnl" + index;
				p.Name = "pb" + index;
				txt.Name = "txtPicTime" + index;
				pnlPics.Controls.Add(pnl);
				return pnl;
			}
			catch(Exception)
			{
				return null;
			}
		}
				
        void RemoveSlide()
        {
			if (picCount == 0 || selectedSlide >= picCount || selectedSlide < 0)
				return;
			curTask.picList.RemoveAt(selectedSlide);
			PicturePanelReset(selectedSlide - 1);
			SelectSlide(selectedSlide);
		}
               
        void pb_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files |*.png;*.jpg;*.jpeg;*.bmp | Video Files |*.mp4;*.avi;*.wmv;*.mpeg";
            if (file.ShowDialog() == DialogResult.OK)
            {
				PictureBox pbTemp = (PictureBox)sender;
               								
                string name = pbTemp.Name;
                string[] texts = name.Split('b');
                int index = -1;
                Int32.TryParse(texts[1], out index);
				
				MediaType type = curTask.picList[index].VerifyElementbyAddress(file.FileName, false);
				
				if(type == MediaType.Video)
				{
					TextBox text = (TextBox)pnlPics.Controls.Find("txtPicTime" + index.ToString(),true)[0];
					text.Enabled = false;
					text.Text = curTask.picList[index].Time.ToString();
					pbTemp.Image = curTask.picList[index].Image;
				}
				if(type == MediaType.Image)
				{
					pbTemp.Image = curTask.picList[index].Image;
				}
				if(type == MediaType.Empty)
				{
					MetroMessageBox.Show((IWin32Window)this, "Could not open media file!", 50);
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
			oldInd = selectedSlide;
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
				{
					selectedSlide = 0;
				}
				else
				{
					selectedSlide = newSel;
				}
			}
			btnBackgroundCol.BackColor = curTask.picList[selectedSlide].BGColor;
			if (oldInd != selectedSlide)
				if (vlcControl1.IsPlaying)
				{
					vlcControl1.Stop();
					btnStart.BackgroundImage = Resource.Run;
					vlcControl1.Visible = false;
					pbDesign.Visible = true;
				}
			if (curTask.picList[selectedSlide].MediaTaskType == MediaType.Empty)
            {
				btnStart.Enabled = false;
				pbDesign.Visible = true;
                webBrowser.Visible = false;
                vlcControl1.Visible = false;
                pbDesign.Image = curTask.GetOperationFrame(true, selectedSlide);
            }
            if (curTask.picList[selectedSlide].MediaTaskType == MediaType.Image)
            {
				btnStart.Enabled = false;
				pbDesign.Visible = true;
                webBrowser.Visible = false;
                vlcControl1.Visible = false;
                pbDesign.Image = curTask.GetOperationFrame(true, selectedSlide);
            }
            if (curTask.picList[selectedSlide].MediaTaskType == MediaType.Video)
            {
				
				pbDesign.Visible = true;
                webBrowser.Visible = false;
                vlcControl1.Visible = false;
				pbDesign.Image = curTask.GetOperationFrame(true, selectedSlide);
				btnStart.Enabled = true;
            }
            if (curTask.picList[selectedSlide].MediaTaskType == MediaType.Web)
            {
				btnStart.Enabled = false;
				pbDesign.Visible = true;
                webBrowser.Visible = true;
                webBrowser.BringToFront();
                vlcControl1.Visible = false;
                //webBrowser.BringToFront();
                webBrowser.Load(curTask.picList[selectedSlide].URL);
                //webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
            }
			if (oldInd > -1)
				DrawBorderPanels(oldInd);
			DrawBorderPanels(selectedSlide);
		}

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        void txtPicTime_TextChanged(object sender, EventArgs e)
        {
			TextBox txt = (TextBox)sender;
			string[] s = txt.Name.Split('e');
			int index;
			Int32.TryParse(s[1], out index);
			SelectSlide(index);
			txt.Select();
		}

		void DrawBorderPanels(int id)
		{
			if (id != selectedSlide)
			{
				Graphics border1 = thumbs[id].CreateGraphics();
				border1.DrawRectangle(new Pen(Color.Gray, 1), new Rectangle(new Point(0, 0), new Size(thumbs[id].Size.Width - 1, thumbs[id].Size.Height - 1)));
			}
			else
			{
				Graphics redBorder = thumbs[selectedSlide].CreateGraphics();
				redBorder.DrawRectangle(new Pen(Color.Red, 1), new Rectangle(new Point(0, 0), new Size(thumbs[selectedSlide].Size.Width - 1, thumbs[selectedSlide].Size.Height - 1)));
			}
		}

        void pnlPic_Click(object sender, EventArgs e)
        {
			int newSel;
			Panel pnlTemp = (Panel)sender;
			string[] seperate = pnlTemp.Name.Split('l');
            Int32.TryParse(seperate[1], out newSel);
			SelectSlide(newSel);
        }

		void Thumb_Move(object sender, EventArgs e)
		{
			int newSel;
			Panel pnlTemp = (Panel)sender;
			string[] seperate = pnlTemp.Name.Split('l');
			Int32.TryParse(seperate[1], out newSel);
			DrawBorderPanels(newSel);
		}

		void txtPicTime_Leave(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			string[] s = txt.Name.Split('e');
			int index;
			Int32.TryParse(s[1], out index);   
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
			if (cmbxSavMod.SelectedIndex == 0) 
				curTask.SavingMode = SaveMod.txt;
				if (cmbxSavMod.SelectedIndex == 1)
				curTask.SavingMode = SaveMod.bin;
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
				curTask.picList[selectedSlide].VerifyElementbyAddress(url.txtbxURL.Text, true);
				url.Dispose(); url = null;
			}
        }

       	void TaskGen_Load(object sender, EventArgs e)
		{
			MARGINS marg = new MARGINS() { Left = -1, Right = -1, Top = -1, Bottom = -1 };
			DwmExtendFrameIntoClientArea(this.Handle, ref marg);
			this.StartPosition = FormStartPosition.Manual;
			pbDesign.SizeMode = PictureBoxSizeMode.StretchImage;
			curTask.OperationalImageSize = pbDesign.Size;
			vlcControl1.EndReached += PreviewStoped;
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
				btnBackgroundCol.BackColor = cDilog.Color;

				if (thumbs.Count > 0)
				{
					curTask.picList[selectedSlide].BGColor = btnBackgroundCol.BackColor;
					pbDesign.Image = curTask.GetOperationFrame(true, selectedSlide);
					PictureBox p = (PictureBox)thumbs[selectedSlide].Controls.Find("pb" + selectedSlide, false)[0];
					p.Image = curTask.GetOperationFrame(false, selectedSlide);
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
			pbDesign.Visible = false;
			vlcControl1.Visible = true;
			vlcControl1.SetMedia(new FileInfo(curTask.picList[selectedSlide].Address));
			vlcControl1.Play();
			btnStart.BackgroundImage = Resource.stop;
		}

		void PreviewStoped(object sender, EventArgs e)
		{
			btnStart.BackgroundImage = Resource.Run;
			Invoke((Action) delegate { vlcControl1.Visible = false; pbDesign.Visible = true; });
			
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
			if (e.KeyCode == Keys.Up)
			{
				if (curTask.Type == TaskType.media)
				{
					SelectSlide(selectedSlide - 1);
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


		private void pnlPics_Layout(object sender, LayoutEventArgs e)
		{
			for (int i = 0; i < thumbs.Count; i++)
				DrawBorderPanels(i);
		}

		private void TaskGen_Resize(object sender, EventArgs e)
		{
			curTask.OperationalImageSize = new Size(splitContainer1.Panel2.Width, splitContainer1.Panel2.Height);
			SelectSlide(selectedSlide);
			pnlSetting.Width = splitContainer1.Panel2.Width - 14;
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

		void tmrMain_Tick(object sender, EventArgs e)
		{

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
				pbDesign.Image = curTask.GetOperationFrame(true, selectedSlide);
				picB.Image = pbDesign.Image;
			}
			else
			{
				vlcControl1.Visible = true;
				pbDesign.Visible = false;
				btnStart.Enabled = true;
				vlcControl1.BackgroundImageLayout = ImageLayout.Stretch;
				vlcControl1.BackgroundImage = curTask.GetOperationFrame(true, selectedSlide);
				picB.Image = vlcControl1.BackgroundImage;
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

			SelectSlide(ind);

		}
	}
	
}
