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
		LabDesignState designerState, lastState;

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
				spltContner.SplitterDistance = 210;
			}
			else
			{
				pnlSetting.Visible = false;
				spltContner.SplitterDistance = 0;
			}
		}

        void PsycologyDesigner_Load(object sender, EventArgs e)
        {
            MARGINS marg = new MARGINS() { Left = -1, Right = -1, Top = -1, Bottom = -1 };
            DwmExtendFrameIntoClientArea(this.Handle, ref marg);
            designerState = LabDesignState.start;
            ScreenModer();
        }

        void PsycologyDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckSave(true))
                e.Cancel = true;
        }

        #endregion

        #region pbdesign

        void pbDesign_MouseUp(object sender, MouseEventArgs e)
		{
			if (_curTask == null)
				return;
            int x = 0, y = 0;
			
			Color sColor = Color.Black;
			#region moving node
			if (lastState == LabDesignState.onChange && selectedNode != null)
			{
				UpdateRatio(e, out x, out y);
				UpdateNode(x, y);
				selectedNode.enable = false;
				designerState = LabDesignState.onChange;
                return;	
			}
            #endregion
            #region add node
            if (lastState == LabDesignState.onInsert)
            {
				if (!inserNode.enable)
				{
					UpdateRatio(e, out x, out y);
					GiveNode(x, y);
					designerState = LabDesignState.onInsert;
				}  

            }
			#endregion

		}

		void pbDesign_MouseDown(object sender, MouseEventArgs e)
		{
			int x, y;
			if (_curTask == null)
				return;
			
			UpdateRatio(e, out x, out y);
			Node tempSel = _curTask.findNode(x, y);
			pnlSetting.Visible = false;

			if (lastState == LabDesignState.onDesign)
			{
				if (tempSel != null)
				{
					designerState = LabDesignState.onChange;
					selectedNode = tempSel;
					selectedNode.enable = true;
					ShowNode(selectedNode);
					
				}
				return;
			}
			if(lastState == LabDesignState.onChange)
			{
				if (tempSel == null)
				{
					
					designerState = LabDesignState.onDesign;
				}
				else
				{
					selectedNode = tempSel;
					selectedNode.enable = true;
					ShowNode(selectedNode);
					
				}
			}
			if (lastState == LabDesignState.onInsert)
			{
				if (tempSel == null)
					return;
				if (tempSel._id == inserNode._id)
				{
					inserNode.enable = false;
				}
				
				return;
			}

		}

		#endregion

		#region panels

		private void btnChangeNode_Click(object sender, EventArgs e)
		{
			GiveNode(true);
			
			CircSel = false;
			RectSel = false;
			inserNode = null;
			selectedNode = null;

			designerState = LabDesignState.onDesign;
		}

		private void btnRemoveNode_Click(object sender, EventArgs e)
		{
			
			CircSel = false;
			RectSel = false;
			if (lastState == LabDesignState.onInsert)
			{
				if(inserNode.enable)
				{
					_curTask.RemoveNode(inserNode._id);
				}
				inserNode = null;
			}

			if (lastState == LabDesignState.onChange)
			{
				_curTask.RemoveNode(selectedNode._id);
				selectedNode = null;
			}
			designerState = LabDesignState.onDesign;
		}

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
            CircSel = !_circSel;
            if (_circSel)
            {
                if (lastState == LabDesignState.onDesign)
                {
                    designerState = LabDesignState.onInsert;
					GiveNode(false);
				}
                RectSel = false;
				// To update  Node
				if(lastState == LabDesignState.onChange)
				{
					UpdateNode(-1,-1);
				}
			}
            return;
        }

        void btnRect_Click(object sender, EventArgs e)
        {
            RectSel = !_rectSel;
           
            if (_rectSel)
            {
                if (lastState == LabDesignState.onDesign)
                {
                    designerState = LabDesignState.onInsert;
					GiveNode(false);
				}
                CircSel = false;
                 // To update  Node
				if (lastState == LabDesignState.onChange)
				{
					UpdateNode(-1,-1);
				}
			}
            return;

        }

		void btnNumberColor_Click(object sender, EventArgs e)
		{
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				btnNumberColor.BackColor = cDilog.Color;
			}
		}
		
		private void btnFixateColor_Click(object sender, EventArgs e)
		{
			ColorDialog cDilog = new ColorDialog();
			if (cDilog.ShowDialog() == DialogResult.OK)
			{
				btnFixateColor.BackColor = cDilog.Color;
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
				_curTask.Invalidate();
			}
		}

		private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}

		}

		private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void txtFixationTime_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void txtRadius_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
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
				
				_curTask.backImage = BitmapManager.DrawOn(new Bitmap(of.FileName), new Size(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y), _curTask.backColor);
				_curTask.Invalidate();
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
			_curTask = new PsycologyTask();
			designerState = LabDesignState.onDesign;
			refreshTimer.Start();
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
			if (node.shape == Shape.Circle)
			{
				pnlBtnCircle.BackColor = node.shapeColor;
				txtHeight.Enabled = false;
			}
			else if (node.shape == Shape.Rectangle)
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
			if (inserNode == null)
			{
				inserNode = new Node(-1, x, y, shp, sColor, (int)numUpDownNode.Value, btnNumberColor.BackColor, w, h);
			}
			inserNode.pos.X = x;
			inserNode.pos.Y = y;
			//inserted node is modified so is ready to add to map.
			inserNode.enable = true;

			if (!chboxFixate.Checked) // add normal node to map
				_curTask.CreateNode(inserNode);
			else // add fixate node to map.
			{
				int.TryParse(txtFixationTime.Text, out inserNode.fixationTime);
				int.TryParse(txtRadius.Text, out inserNode.fixationRadius);
				inserNode.fixationColor = btnFixateColor.ForeColor;
				inserNode.priority = (int)numUpDownPriority.Value;
				_curTask.CreateNode(inserNode);
			}
		}

		Node GiveNode(bool MusbBeEnabled)
		{
			Random r = new Random();
			int w, h = 0, x, y;
			Shape shp = Shape.Circle;
			Color sColor = Color.Red;

			x = r.Next(0, BasConfigs._monitor_resolution_x);
			y = r.Next(0, BasConfigs._monitor_resolution_y);

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
				inserNode = new Node(-1, x, y, shp, sColor, (int)numUpDownNode.Value, btnNumberColor.BackColor, w, h);
			else
			{
				inserNode.shape = shp;
				inserNode.height = h; inserNode.width = w; inserNode.number = (int)numUpDownNode.Value;
			}
			if (MusbBeEnabled && !inserNode.enable)
			{
				inserNode.enable = true;

			}
			if (inserNode.enable)
			{
				//inserted node is modified so is ready to add to map.

				if (!chboxFixate.Checked) // add normal node to map
					_curTask.CreateNode(inserNode);
				else // add fixate node to map.
				{
					int.TryParse(txtFixationTime.Text, out inserNode.fixationTime);
					int.TryParse(txtRadius.Text, out inserNode.fixationRadius);
					inserNode.fixationColor = btnFixateColor.ForeColor;
					inserNode.priority = (int)numUpDownPriority.Value;
					_curTask.CreateNode(inserNode);
				}

			}
			return inserNode;
		}

		void UpdateNode(int x, int y)
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
			selectedNode.shape = shp;
			selectedNode.height = h; selectedNode.width = w; selectedNode.number = (int)numUpDownNode.Value;
			
			if (x != -1)
				selectedNode.pos.X = x;
			if (y != -1)
				selectedNode.pos.Y = y;

			if (!chboxFixate.Checked) // add normal node to map
				_curTask.CreateNode(selectedNode);
			else // add fixate node to map.
			{
				int.TryParse(txtFixationTime.Text, out inserNode.fixationTime);
				int.TryParse(txtRadius.Text, out inserNode.fixationRadius);
				selectedNode.fixationColor = btnFixateColor.ForeColor;
				selectedNode.priority = (int)numUpDownPriority.Value;
				_curTask.CreateNode(selectedNode);
			}
		}

		void ScreenModer()
		{
			switch (designerState)
			{
				case LabDesignState.idle:
					{
						PanelModer();
						break;
					}
				case LabDesignState.start:
					{
						pbDesign.BackColor = Color.Transparent;
						btnSetting.Enabled = false;
						pnlSetting.Visible = false;
						pnlShapVis = false; pnlShapPropVis = false; pnlDetalsVis = false; pnlbackVis = false; pnlFixVis = false;
						PanelModer();
						designerState = LabDesignState.idle;
						break;
					}
				case LabDesignState.onDesign:
					{
						if (_circSel)
						{
							txtHeight.Enabled = false;
						}
						else
							pnlBtnCircle.BackColor = SystemColors.ActiveCaption;
						if (_rectSel)
						{
							
							txtHeight.Enabled = true;
						}
						else
							pnlBtnRect.BackColor = SystemColors.ActiveCaption;
						btnSetting.Enabled = true;
						pnlShapVis = true; pnlShapPropVis = false; pnlDetalsVis = false; pnlbackVis = true; pnlFixVis = false;
						chboxFixate.Checked = false;
						PanelModer();
						pbDesign.Cursor = Cursors.Default;
						_curTask.UndrawPrmpt();
						lastState = LabDesignState.onDesign;
						designerState = LabDesignState.idle;
						break;
					}
				case LabDesignState.onInsert:
					{
						if (_circSel)
						{
							pnlBtnRect.BackColor = SystemColors.ActiveCaption;
							txtHeight.Enabled = false;
						}
						if (_rectSel)
						{
							pnlBtnCircle.BackColor = SystemColors.ActiveCaption;
							txtHeight.Enabled = true;
						}
						pnlShapVis = true; pnlShapPropVis = true; pnlDetalsVis = true; pnlbackVis = true;
						PanelModer();
						if (inserNode.enable)
							pbDesign.Cursor = Cursors.Default;
						else
							pbDesign.Cursor = Cursors.Hand;
						if (inserNode.enable)
							_curTask.DrawPrompt(10, inserNode._id, Color.AliceBlue, true);
						btnChangeNode.Text = "Insert";
						btnRemoveNode.Text = "Cancel";
						lastState = LabDesignState.onInsert;
						designerState = LabDesignState.idle;
						break;
					}
				case LabDesignState.onChange:
					{
						if (_circSel)
						{
							pnlBtnRect.BackColor = SystemColors.ActiveCaption;
							txtHeight.Enabled = false;
						}
						if (_rectSel)
						{
							pnlBtnCircle.BackColor = SystemColors.ActiveCaption;
							txtHeight.Enabled = true;
						}
						pnlShapVis = true; pnlShapPropVis = true; pnlDetalsVis = true; pnlbackVis = true;
						PanelModer();
						if (selectedNode.enable)
							pbDesign.Cursor = Cursors.Hand;
						else
							pbDesign.Cursor = Cursors.Default;
						_curTask.DrawPrompt(10, selectedNode._id, Color.AliceBlue, true);
						btnChangeNode.Text = "Change";
						btnRemoveNode.Text = "Remove";
						lastState = LabDesignState.onChange;
						designerState = LabDesignState.idle;
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

			x = Math.Max((int)screenPictureboxRatioX * e.X,  10);
			y = Math.Max((int)screenPictureboxRatioY * e.Y, 10);
		}

		#endregion
	}

	public enum LabDesignState { onInsert, onChange, onDesign, idle , start }
}
