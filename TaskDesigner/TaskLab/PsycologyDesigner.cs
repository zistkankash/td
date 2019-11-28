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
        //Help: if in change mode and mouse down in pbdesign : selectedNode is valid.
        //if in insert mode selectedNode is valid. 
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
		Node selectedNode;
		float screenPictureboxRatioX;
		float screenPictureboxRatioY;
		PsycologyTask _curTask;
		DesignState designerState;

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

		void PsycologyDesigner_Load(object sender, EventArgs e)
		{
			MARGINS marg = new MARGINS() { Left = -1, Right = -1, Top = -1, Bottom = -1 };
			DwmExtendFrameIntoClientArea(this.Handle, ref marg);
			pnlShapVis = false; pnlShapPropVis = false; pnlFixVis = false; pnlDetalsVis = false; pnlbackVis = false;
		}

		void chboxFixate_CheckedChanged(object sender, EventArgs e)
		{
			pnlFixVis = chboxFixate.Checked;
			PanelModer();

		}

		void pnlBackGround_Paint(object sender, PaintEventArgs e)
		{

		}

		void btnCircle_Click(object sender, EventArgs e)
		{
			if (designerState == DesignState.onDesign)
			{
				
				CircSel = !_circSel;
				if (CircSel)
				{
					designerState = DesignState.onInsert;
				}
				return;
			}
		}

		void btnRect_Click(object sender, EventArgs e)
		{
			RectSel = !_rectSel;
			if (RectSel)
			{
				if (selectedNode == null)
					pbDesign.Cursor = Cursors.Hand;
				pnlShapPropVis = true;
				PanelModer();
			}
		}

		void pbDesign_MouseUp(object sender, MouseEventArgs e)
		{
			if (_curTask == null)
				return;
            int x = 0, y = 0;
			
			Color sColor = Color.Black;
			#region moving node
			if (designerState == DesignState.onChange && selectedNode != null)
			{
				UpdateRatio(e, out x, out y);
				selectedNode = _curTask.CreateNode(selectedNode._id, selectedNode.shape, selectedNode.number, x, y, selectedNode.width, selectedNode.height, selectedNode.shapeColor, selectedNode.textColor);
                return;	
			}
            #endregion
            #region add node
            if (designerState == DesignState.onInsert)
            {
                UpdateRatio(e, out x, out y);
                GiveNode(x, y);
                selectedNode = _curTask.CreateNode(selectedNode);

            }
			#endregion

		}

		void pbDesign_MouseDown(object sender, MouseEventArgs e)
		{
			int x, y;
			if (_curTask == null)
				return;
			if (CircSel | RectSel)
				return;
			UpdateRatio(e, out x, out y);
			selectedNode = _curTask.findNode(x, y);
			if (selectedNode == null)
				return;
			ShowNode(selectedNode);
		}

		void UpdateRatio(MouseEventArgs e, out int x, out int y)
		{
			screenPictureboxRatioX = BasConfigs._monitor_resolution_x / pbDesign.Size.Width;
			screenPictureboxRatioY = BasConfigs._monitor_resolution_y / pbDesign.Size.Height;

			x = (int)screenPictureboxRatioX * e.X;
			y = (int)screenPictureboxRatioY * e.Y;
		}

		void btnFixationColor_Click(object sender, EventArgs e)
		{

		}

		void btnSetting_Click(object sender, EventArgs e)
		{
			pnlSetting.Visible = !pnlSetting.Visible;
		}

		void spltContner_Click(object sender, EventArgs e)
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

		void PanelModer()
		{
			int order = 0;

			if (pnlDetalsVis)
			{
				this.spltContner.Panel1.Controls.SetChildIndex(pnlShapeDetails, order);

				order++;
			}
			if (pnlFixVis)
			{
				this.spltContner.Panel1.Controls.SetChildIndex(pnlFixate, order);

				order++;
			}
			if (pnlShapPropVis)
			{
				this.spltContner.Panel1.Controls.SetChildIndex(pnlShapeProp, order);

				order++;
			}
			if (pnlShapVis)
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

		void btnNewProject_Click(object sender, EventArgs e)
		{
			int x, y, w, h;
			Color sColor;
			int.TryParse(txtWidth.Text, out w);
			int.TryParse(txtHeight.Text, out h);
			if (CircSel)
				sColor = pnlBtnCircle.BackColor;
			if (RectSel)
				sColor = pnlBtnRect.BackColor;

		void btnNumberColor_Click(object sender, EventArgs e)
		{
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				btnNumberColor.ForeColor = cDilog.Color;
			}
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

		void PsycologyDesigner_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!CheckSave(true))
				e.Cancel = true;
		}

		void btnLoad_Click(object sender, EventArgs e)
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

		bool CheckSave(bool showDialog)
		{
			if (!showDialog)
			{
				return _curTask == null || _curTask.Save();
			}

			DialogResult dr = DialogResult.OK;
			if (_curTask != null && !_curTask.Save())
			{
				dr = MetroFramework.MetroMessageBox.Show((IWin32Window)this, "Project not saved. Do you want to continue?", "Save Project", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, 100);
				if (dr == DialogResult.Cancel)
					return false;
				else
					return true;
			}
			else
				return true;
			return false;
		}
	}

	public static class LabTaskUtils
	{

	}

	public enum DesignState { onInsert, onChange, onDesign, idle }
}
