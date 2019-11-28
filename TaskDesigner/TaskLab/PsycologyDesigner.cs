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
		bool pnlShapVis, pnlShapPropVis, pnlFixVis, pnlDetalsVis, pnlbackVis;

		PsycologyTask _curTask;

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
					pnlBtnRect.BackColor = SystemColors.ActiveCaption;
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
					pnlBtnCircle.BackColor = SystemColors.ActiveCaption;
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
			pnlShapVis = false; pnlShapPropVis = false; pnlFixVis = false; pnlDetalsVis = false; pnlbackVis = false;
		}

		private void chboxFixate_CheckedChanged(object sender, EventArgs e)
		{
			pnlFixVis = chboxFixate.Checked;
			PanelModer();
			
		}

		private void pnlBackGround_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnCircle_Click(object sender, EventArgs e)
		{
			CircSel = !_circSel;
			if (CircSel)
			{
				pbDesign.Cursor = Cursors.Hand;
				pnlShapPropVis = true;
				PanelModer();
			}
		}

		private void btnRect_Click(object sender, EventArgs e)
		{
			RectSel = !_rectSel;
			if (RectSel)
			{
				pbDesign.Cursor = Cursors.Hand;
				pnlShapPropVis = true;
				PanelModer();
			}
		}

		private void pbDesign_MouseMove(object sender, MouseEventArgs e)
		{
			
		}

		private void pbDesign_MouseUp(object sender, MouseEventArgs e)
		{
			
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

		private void PanelModer()
		{
			int order = 0;
			
			if (pnlDetalsVis)
			{
				this.spltContner.Panel1.Controls.SetChildIndex(pnlShapeDetails, order);
				
				order++;
			}
			if(pnlFixVis)
			{
				this.spltContner.Panel1.Controls.SetChildIndex(pnlFixate, order);
				
				order++;
			}
			if(pnlShapPropVis)
			{
				this.spltContner.Panel1.Controls.SetChildIndex(pnlShapeProp, order);
				
				order++;
			}
			if(pnlShapVis)
			{
				this.spltContner.Panel1.Controls.SetChildIndex(pnlShape, order);
				
				order++;
			}
			pnlShape.Visible = pnlShapVis;
			pnlShapeProp.Visible = pnlShapPropVis;
			pnlFixate.Visible = pnlFixVis;
			pnlShapeDetails.Visible = pnlDetalsVis;
			pnlPictureDesign.Visible = pnlbackVis;
		}

		private void btnNewProject_Click(object sender, EventArgs e)
		{
			if (!CheckSave(true))
				return;
			if (refreshTimer.Enabled)
				refreshTimer.Stop();
			_curTask = new PsycologyTask();
			pnlShapVis = true;
			pnlbackVis = true;
			PanelModer();
			btnSetting.Enabled = true;
			refreshTimer.Enabled = true;
			refreshTimer.Start();
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

		private void btnTaskBackColor_Click(object sender, EventArgs e)
		{
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				_curTask.backColor = cDilog.Color;
				btnTaskBackColor.ForeColor = cDilog.Color;
			}
			 
		}

		private void chkSaveData_CheckedChanged(object sender, EventArgs e)
		{
			cmbxSavMod.Enabled = chkSaveData.Checked;
			txtPath.Visible = chkSaveData.Checked;
			if (chkSaveData.Checked)
			{
				cmbxSavMod.DroppedDown = true;
			}
			else
			{
				txtPath.Text = "";
			}
		}

		private void btnBackImage_Click(object sender, EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
			DialogResult dr = of.ShowDialog();
			if (dr == DialogResult.OK)
			{
				_curTask.useBackImage = true;
				_curTask.backImage = BitmapData.DrawOn(new Bitmap(of.FileName), new Size(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y), _curTask.backColor);
			}
			else
			{
				_curTask.useBackImage = false;
			}
		}

		private void chkboxUseBackImage_CheckedChanged(object sender, EventArgs e)
		{
			btnBackImage.Visible = chkboxUseBackImage.Checked;
			
			if (!chkboxUseBackImage.Checked)
			{
				_curTask.useBackImage = false;
				_curTask.backImage = null;
			}
		}

		private void cmbxSavMod_SelectedIndexChanged(object sender, EventArgs e)
		{
			_curTask.SavingMode = SaveMod.txt;
		}

		private void refreshTimer_Tick(object sender, EventArgs e)
		{
			pbDesign.Image = _curTask.GetTaskImage.ToBitmap();
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
			btnSetting.Enabled = false;
			if (refreshTimer.Enabled)
				refreshTimer.Stop();
			if (_curTask.Load())
			{
				refreshTimer.Start();
				btnSetting.Enabled = true;
			}
		}

		private bool CheckSave(bool showDialog)
		{
			if (!showDialog)
			{
				return _curTask == null || _curTask.Save();
			}
				
			DialogResult dr = DialogResult.OK;
			if (_curTask != null && !_curTask.Save())
			{
				dr = MetroFramework.MetroMessageBox.Show((IWin32Window)this, "Project not saved. Do you want to continue?","Save Project",MessageBoxButtons.OKCancel,MessageBoxIcon.Question, 100);
				if (dr == DialogResult.Cancel)
					return false;
				else
					return true;
			}
			else
				return true;
			
		}
	}

	public static class LabTaskUtils
	{

	}
}
