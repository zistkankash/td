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
		Node selectedNode , inserNode;
		float screenPictureboxRatioX;
		float screenPictureboxRatioY;
		PsycologyTask _curTask;
		LabDesignState designerState;

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
					
					_rectSel = false;
				}
				if (value)
				{
					
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
					_circSel = false;
				}
				if (value)
				{
					
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

		#region screen

		void refreshTimer_Tick(object sender, EventArgs e)
		{
			ScreenModer();
			if (_curTask != null)
				pbDesign.Image = _curTask.RenderTask();
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

		#endregion

		
		
		#region pbdesign

		void PsycologyDesigner_Load(object sender, EventArgs e)
		{
			MARGINS marg = new MARGINS() { Left = -1, Right = -1, Top = -1, Bottom = -1 };
			DwmExtendFrameIntoClientArea(this.Handle, ref marg);
			designerState = LabDesignState.idle;
			ScreenModer();
		}

		void PsycologyDesigner_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!CheckSave(true))
				e.Cancel = true;
		}

		void pbDesign_MouseUp(object sender, MouseEventArgs e)
		{
			if (_curTask == null)
				return;
            int x = 0, y = 0;
			
			Color sColor = Color.Black;
			#region moving node
			if (designerState == LabDesignState.onChange && selectedNode != null)
			{
				UpdateRatio(e, out x, out y);
				selectedNode = _curTask.CreateNode(selectedNode._id, selectedNode.shape, selectedNode.number, x, y, selectedNode.width, selectedNode.height, selectedNode.shapeColor, selectedNode.textColor);
                return;	
			}
            #endregion
            #region add node
            if (designerState == LabDesignState.onInsert)
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

		#endregion

		#region panels

		void btnSetting_Click(object sender, EventArgs e)
		{
			pnlSetting.Visible = !pnlSetting.Visible;
		}

		void chboxFixate_CheckedChanged(object sender, EventArgs e)
		{
			pnlFixVis = chboxFixate.Checked;

		}

		void btnCircle_Click(object sender, EventArgs e)
		{
			if (designerState == LabDesignState.onDesign)
			{
				CircSel = !_circSel;
				if (_circSel)
				{
					RectSel = false;
					designerState = LabDesignState.onInsert;
				}
				return;
			}
		}

		void btnRect_Click(object sender, EventArgs e)
		{
			if (designerState == LabDesignState.onDesign)
			{
				RectSel = !_rectSel;
				if (_rectSel)
				{
					CircSel = false;
					designerState = LabDesignState.onInsert;
				}
				return;
			}

		}

		void btnNumberColor_Click(object sender, EventArgs e)
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
			if(_curTask == null)
			{
				return;
			}
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				btnTaskBackColor.ForeColor = cDilog.Color;
				_curTask.backColor = cDilog.Color;
			}
		}

		#endregion

		#region setting panel

		private void chkboxBackImage_CheckedChanged(object sender, EventArgs e)
		{
			_curTask.useBackImage = chkboxUseBackImage.Checked;
			btnBackImage.Visible = chkboxUseBackImage.Checked;
		}

		private void btnBackImage_Click(object sender, EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
			DialogResult dr = of.ShowDialog();
			if (dr == DialogResult.OK)
			{
				
				_curTask.backImage = BitmapData.DrawOn(new Bitmap(of.FileName), new Size(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y), _curTask.backColor);
			}
			else
			if(_curTask.backImage == null)
			{
				chkboxUseBackImage.Checked = false;
			}
		}
		
		private void btnHome_Click(object sender, EventArgs e)
		{
			Close();
		}

		void btnNewProject_Click(object sender, EventArgs e)
		{
			if (!CheckSave(true))
				return;
			if (refreshTimer.Enabled)
				refreshTimer.Stop();
			designerState = LabDesignState.onDesign;
			_curTask = new PsycologyTask();

		}

		void btnLoad_Click(object sender, EventArgs e)
		{
			if (refreshTimer.Enabled)
				refreshTimer.Stop();
			if (_curTask.Load())
			{
				designerState = LabDesignState.onDesign;
				refreshTimer.Start();

			}
		}

		#endregion

		#region handler methods

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
				pnlBtnRect.BackColor = node.shapeColor;
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
			
		}

		void GiveNode(int x, int y)
		{
			int w, h = 0;
			Shape shp = Shape.Circle;
			Color sColor = Color.Red;
			int.TryParse(txtWidth.Text, out w);
			if (CircSel)
			{
				sColor = pnlBtnCircle.BackColor;
			}
			if (RectSel)
			{
				shp = Shape.Rectangle;
				sColor = pnlBtnRect.BackColor;
				int.TryParse(txtHeight.Text, out h);
			}

			if (!chboxFixate.Checked)
				_curTask.CreateNode(-1, shp, (int)numUpDownNode.Value, x, y, w, h, sColor, btnNumberColor.ForeColor);
			else
			{
				int fTm, radFix;
				int.TryParse(txtFixationTime.Text, out fTm);
				int.TryParse(txtRadius.Text, out radFix);
				_curTask.CreateFixateNode(-1, shp, (int)numUpDownNode.Value, x, y, w, h, sColor, btnNumberColor.ForeColor, fTm, btnFixateColor.ForeColor, radFix, (int)numUpDownPriority.Value);
			}
		}

		Node GiveNode()
		{
			Random r = new Random();
			int w, h = 0;
			Shape shp = Shape.Circle;
			Color sColor = Color.Red;
			int x = r.Next(0, BasConfigs._monitor_resolution_x);
			int y = r.Next(0, BasConfigs._monitor_resolution_y);
			int.TryParse(txtWidth.Text, out w);
			if (CircSel)
			{
				sColor = pnlBtnCircle.BackColor;
			}
			if (RectSel)
			{
				shp = Shape.Rectangle;
				sColor = pnlBtnRect.BackColor;
				int.TryParse(txtHeight.Text, out h);
			}
			//create new node for modify in designer not for add to map.
			if (inserNode == null)
			{
				inserNode = new Node(-1, 0, 0, shp, sColor, (int)numUpDownNode.Value, btnNumberColor.ForeColor, w, h);
				return inserNode;
			}
			
			//inserted node is modified so is ready to add to map.
			if (!chboxFixate.Checked) // add normal node to map
				_curTask.CreateNode(inserNode);
			else // add fixate node to map.
			{
				int.TryParse(txtFixationTime.Text, out inserNode.fixationTime);
				int.TryParse(txtRadius.Text, out inserNode.fixationRadius);
				_curTask.CreateNode(inserNode);
			}

			return inserNode;
		}

		void ScreenModer()
		{
			switch (designerState)
			{
				case LabDesignState.idle:
					{
						pbDesign.BackColor = Color.Transparent;
						btnSetting.Enabled = false;
						pnlSetting.Visible = false;
						pnlShapVis = false; pnlShapPropVis = false; pnlDetalsVis = false; pnlbackVis = false; pnlFixVis = false;
						PanelModer();
						break;
					}
				case LabDesignState.onDesign:
					{
						if (_circSel)
						{
							pnlBtnRect.BackColor = SystemColors.ActiveCaption;
						}
						if (_rectSel)
						{
							pnlBtnCircle.BackColor = SystemColors.ActiveCaption;
						}
						btnSetting.Enabled = true;
						pnlShapVis = true; pnlShapPropVis = false; pnlDetalsVis = false; pnlbackVis = true; pnlFixVis = false;
						PanelModer();
						pbDesign.Cursor = Cursors.Default;
						break;
					}
				case LabDesignState.onInsert:
					{
						pnlShapVis = true; pnlShapPropVis = true; pnlDetalsVis = true; pnlbackVis = true;
						PanelModer();
						pbDesign.Cursor = Cursors.Hand;
						btnChangeNode.Text = "Insert";
						btnRemoveNode.Text = "Cancel";
						break;
					}
				case LabDesignState.onChange:
					{
						pnlShapVis = true; pnlShapPropVis = true; pnlDetalsVis = true; pnlbackVis = true;
						PanelModer();
						pbDesign.Cursor = Cursors.Hand;
						btnChangeNode.Text = "Change";
						btnRemoveNode.Text = "Remove";
						break;
					}
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

		void UpdateRatio(MouseEventArgs e, out int x, out int y)
		{
			screenPictureboxRatioX = BasConfigs._monitor_resolution_x / pbDesign.Size.Width;
			screenPictureboxRatioY = BasConfigs._monitor_resolution_y / pbDesign.Size.Height;

			x = (int)screenPictureboxRatioX * e.X;
			y = (int)screenPictureboxRatioY * e.Y;
		}

		#endregion
	}

	public enum LabDesignState { onInsert, onChange, onDesign, idle }
}
