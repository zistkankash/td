using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basics;

namespace TaskLab
{
	public partial class PsycologyDesigner : Form
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

		bool _circSel = false;
		bool _rectSel = false;

		TaskData _curTask;

		public bool RectSel
		{
			get
			{
				return _rectSel;
			}
			set
			{
				if (!value)
				{
					pnlBtnRect.BackColor = Color.Transparent;
					_rectSel = false;
				}
				if (value)
				{
					CircSel = false;
					ColorDialog cDilog = new ColorDialog();
					if (cDilog.ShowDialog() == DialogResult.OK)
					{
						_rectSel = true;
						pnlBtnRect.BackColor = cDilog.Color;
					}
				}
			}
		}

		public bool CircSel
		{
			get
			{
				return _circSel;
			}
			set
			{
				if (!value)
				{
					pnlBtnCircle.BackColor = Color.Transparent;
					_circSel = false;
				}
				if (value)
				{
					RectSel = false;
					ColorDialog cDilog = new ColorDialog();
					if (cDilog.ShowDialog() == DialogResult.OK)
					{
						_circSel = true;
						pnlBtnCircle.BackColor = cDilog.Color;
					}
				}
			}
		}
		
		public PsycologyDesigner()
		{
			InitializeComponent();
		}

		private void PsycologyDesigner_Load(object sender, EventArgs e)
		{
			MARGINS marg = new MARGINS() { Left = -1, Right = -1, Top = -1, Bottom = -1 };
			DwmExtendFrameIntoClientArea(this.Handle, ref marg);
		}

		private void chboxFixate_CheckedChanged(object sender, EventArgs e)
		{
			pnlFixate.Visible = chboxFixate.Checked;
		}

		private void pnlBackGround_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnCircle_Click(object sender, EventArgs e)
		{
			CircSel = !_circSel;
			if(CircSel)
				pbDesign.Cursor = Cursors.Hand;
			PanelModer(true, _rectSel | _circSel, _rectSel | _circSel, true, true);
		}

		private void btnRect_Click(object sender, EventArgs e)
		{
			RectSel = !_rectSel;
			if (RectSel)
				pbDesign.Cursor = Cursors.Hand;
			PanelModer(true, _rectSel | _circSel, _rectSel | _circSel, true, true);
		}

		private void pbDesign_MouseMove(object sender, MouseEventArgs e)
		{
			
		}

		private void pbDesign_MouseUp(object sender, MouseEventArgs e)
		{
			if(_circSel)
			{

			}
			if(_rectSel)
			{

			}
		}

		private void btnFixationColor_Click(object sender, EventArgs e)
		{

		}

		private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		
		private void btnSetting_Click(object sender, EventArgs e)
		{
			pnlSetting.Visible = !pnlSetting.Visible;
		}
		
		private void spltContner_Click(object sender, EventArgs e)
		{
			if (spltContner.SplitterDistance == 0)
			{
				spltContner.SplitterDistance = 160;
			}
			else
			{
				pnlSetting.Visible = false;
				spltContner.SplitterDistance = 0;
			}
		}

		private void PanelModer(bool p1,bool p2, bool p3, bool p4, bool p5)
		{
			pnlShape.Visible = p1;
			pnlShapeProp.Visible = p2;
			pnlFixation.Visible = p3;
			pnlShapeDetails.Visible = p4;
			pnlPictureDesign.Visible = p5;
		}

		private void btnNewProject_Click(object sender, EventArgs e)
		{
			_curTask = new TaskData(TaskType.lab);
			pnlShape.Visible = true;
			pnlShapeDetails.Visible = true;
			pnlPictureDesign.Visible = true;
		}
		
		private void pbDesign_MouseDown(object sender, MouseEventArgs e)
		{
			int x, y, w, h;
			Color sColor;
			int.TryParse(txtWidth.Text, out w);
			int.TryParse(txtHeight.Text, out h);
			if (CircSel)
				sColor = pnlBtnCircle.BackColor;
			if (RectSel)
				sColor = pnlBtnRect.BackColor;

		}

		private void chkboxBackImage_CheckedChanged(object sender, EventArgs e)
		{
			_curTask.PsycoTask.useBackImage = chkboxBackImage.Checked;
			if (chkboxBackImage.Checked)
			{
				btnTaskBackColor.Text = "Task Background";
				OpenFileDialog of = new OpenFileDialog();
				of.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
				DialogResult dr = of.ShowDialog();
				if (dr == DialogResult.OK)
					_curTask.PsycoTask.backImage = BitmapData.DrawOn(new Bitmap(of.FileName),new Size(BasConfigs._monitor_resolution_x,BasConfigs._monitor_resolution_y), _curTask.PsycoTask.backColor);
			}
			else
				btnTaskBackColor.Text = "Task Back Color";
		}

		private void btnNumberColor_Click(object sender, EventArgs e)
		{
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				btnNumberColor.ForeColor = cDilog.Color;
			}
		}

		private void btnFixateColor_Click(object sender, EventArgs e)
		{
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				btnFixateColor.ForeColor = cDilog.Color;
			}
		}

		private void btnHome_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void PsycologyDesigner_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!CheckSave(true))
				e.Cancel = true;
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			_curTask.ClearTask();
		}

		private bool CheckSave(bool showDialog)
		{
			if (!showDialog)
			{
				return _curTask == null || _curTask.SaveTask();
			}
				
			DialogResult dr = DialogResult.OK;
			if (_curTask != null && !_curTask.SaveTask())
			{
				dr = MetroFramework.MetroMessageBox.Show((IWin32Window)this, "Project not saved. Do you want to continue?", 100);
				if (dr == DialogResult.Cancel)
					return false;
			}
			else
				return true;
			return false;
		}
	}

	public static class LabTaskUtils
	{

	}
}
