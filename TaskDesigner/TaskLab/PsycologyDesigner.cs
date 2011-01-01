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
			int x = 0, y = 0, w, h = 0;
			char shape = 'c';
			Color sColor = Color.Black;
			#region moving node
			if (selectedNode != null)
			{
				pnlDetalsVis = false; pnlShapPropVis = false; pnlFixVis = false;
				PanelModer();
				UpdateRatio(e, out x, out y);
				_curTask.CreateNode(selectedNode._id, selectedNode.shape, selectedNode.number, x, y, selectedNode.width, selectedNode.height, selectedNode.shapeColor, selectedNode.textColor);
				selectedNode = null;

			}
			#endregion
			#region add node
			else
			{
				int.TryParse(txtWidth.Text, out w);
				if (CircSel)
				{
					sColor = pnlBtnCircle.BackColor;
				}
				if (RectSel)
				{
					shape = 'r';
					sColor = pnlBtnRect.BackColor;
					int.TryParse(txtHeight.Text, out h);
				}
				UpdateRatio(e, out x, out y);
				if (!chboxFixate.Checked)
					_curTask.CreateNode(-1, shape, (int)numUpDownNode.Value, x, y, w, h, sColor, btnNumberColor.ForeColor);
				else
				{
					int fTm, radFix;
					int.TryParse(txtFixationTime.Text, out fTm);
					int.TryParse(txtRadius.Text, out radFix);
					_curTask.CreateFixateNode(-1, shape, (int)numUpDownNode.Value, x, y, w, h, sColor, btnNumberColor.ForeColor, fTm, btnFixateColor.ForeColor, radFix, (int)numUpDownPriority.Value);
				}
				pbDesign.Cursor = Cursors.Default;
				pnlFixVis = false; pnlShapPropVis = false;
				PanelModer();
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

		void btnNumberColor_Click(object sender, EventArgs e)
		{
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				btnNumberColor.ForeColor = cDilog.Color;
			}
		}

		void btnFixateColor_Click(object sender, EventArgs e)
		{
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				btnFixateColor.ForeColor = cDilog.Color;
			}
		}

		void btnTaskBackColor_Click(object sender, EventArgs e)
		{
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				_curTask.backColor = cDilog.Color;
				btnTaskBackColor.ForeColor = cDilog.Color;
			}

		}

		void chkSaveData_CheckedChanged(object sender, EventArgs e)
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

		void btnBackImage_Click(object sender, EventArgs e)
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

		void chkboxUseBackImage_CheckedChanged(object sender, EventArgs e)
		{
			btnBackImage.Visible = chkboxUseBackImage.Checked;

			if (!chkboxUseBackImage.Checked)
			{
				_curTask.useBackImage = false;
				_curTask.backImage = null;
			}
		}

		void cmbxSavMod_SelectedIndexChanged(object sender, EventArgs e)
		{
			_curTask.SavingMode = SaveMod.txt;
		}

		void refreshTimer_Tick(object sender, EventArgs e)
		{
			ScreenModer();
			if (_curTask != null)
				pbDesign.Image = _curTask.RenderTask();
		}

		void btnSave_Click(object sender, EventArgs e)
		{
			CheckSave(false);
		}

		void btnChangeNode_Click(object sender, EventArgs e)
		{
			if (selectedNode == null)
				return;
			int.TryParse(txtWidth.Text, out w);
			if (CircSel)
			{
				sColor = pnlBtnCircle.BackColor;
			}
			if (RectSel)
			{
				shape = 'r';
				sColor = pnlBtnRect.BackColor;
				int.TryParse(txtHeight.Text, out h);
			}
			UpdateRatio(e, out x, out y);
			if (!chboxFixate.Checked)
				_curTask.CreateNode(-1, shape, (int)numUpDownNode.Value, x, y, w, h, sColor, btnNumberColor.ForeColor);
			else
			{
				int fTm, radFix;
				int.TryParse(txtFixationTime.Text, out fTm);
				int.TryParse(txtRadius.Text, out radFix);
				_curTask.CreateFixateNode(-1, shape, (int)numUpDownNode.Value, x, y, w, h, sColor, btnNumberColor.ForeColor, fTm, btnFixateColor.ForeColor, radFix, (int)numUpDownPriority.Value);
			}
			pnlFixVis = false; pnlShapPropVis = false;
			PanelModer();
		}

		void ShowNode(Node node)        //نمایش مشخصات گره
		{
			if (node.shape == 'c')
			{
				pnlBtnCircle.BackColor = node.shapeColor;
				txtHeight.Enabled = false;
			}
			else if (node.shape == 'r')
			{
				txtHeight.Text = node.height.ToString();
				pnlBtnRectangle.BackColor = node.shapeColor;
			}
			txtWidth.Text = node.width.ToString();
			numUpDownNode.Value = node.number;
			//cmbNumber.Text = node.number.ToString();
			btnNumberColor.ForeColor = node.textColor;
			if (node.fixationTime > 0)
			{
				chboxFixate.Checked = true;

				numUpDownPriority.Value = node.priority;

				txtFixationTime.Text = node.fixationTime.ToString();

				btnFixateColor.ForeColor = node.fixationColor;
				txtRadius.Text = node.fixationRadius.ToString();
			}
			pnlShapePropVis = true;
			pnlShapVis = true;
			pnlDetalsVis = true;
			PanelModer();
		}

		void btnHome_Click(object sender, EventArgs e)
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

		}

		void ScreenModer()
		{
			switch (designerState)
			{
				case DesignState.idle:
					{
						pbDesign.BackColor = Color.Transparent;
						btnSetting.Enabled = false;
						pnlSetting.Visible = false;
						pnlShapeVis = false; pnlShapPropVis = false; pnlDetalsVis = false; pnlbackVis = false; pnlFixVis = false;
						PanelModer();
						break;
					}
				case DesignState.onDesign:
					{
						btnSetting.Enabled = true;
						pnlShapeVis = true; pnlShapPropVis = false; pnlDetalsVis = false; pnlbackVis = true; pnlFixVis = false;
						PanelModer();
						pbDesign.Cursor = Cursors.Default;
						break;
					}
				case DesignState.onInsert:
					{
						pnlShapeVis = true; pnlShapPropVis = true; pnlDetalsVis = true; pnlbackVis = true;
						PanelModer();
						pbDesign.Cursor = Cursors.Hand;
						btnChangeNode.Text = "Insert";
						btnRemoveNode.Text = "Cancel":
						break;
					}
				case DesignState.onChange:
					{
						pnlShapeVis = true; pnlShapPropVis = true; pnlDetalsVis = true; pnlbackVis = true;
						PanelModer();
						pbDesign.Cursor = Cursors.Hand;
						btnChangeNode.Text = "Change";
						btnRemoveNode.Text = "Remove":
						break;
					}
			}
		}

	}

	public enum DesignState { onInsert, onChange, onDesign, idle }
}
