using System;
using System.Drawing;
using System.IO.Ports;
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
		double screenPictureboxRatioX;
		double screenPictureboxRatioY;
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
					pnlBtnRect.BackColor = SystemColors.ActiveCaption;
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
					pnlBtnCircle.BackColor = SystemColors.ActiveCaption;
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
            if (_curTask != null)
                _curTask.OperationalSize = new Size(spltContner.Panel2.Width, spltContner.Panel2.Height);

        }

        void PsycologyDesigner_Load(object sender, EventArgs e)
        {
            MARGINS marg = new MARGINS() { Left = -1, Right = -1, Top = -1, Bottom = -1 };
            DwmExtendFrameIntoClientArea(this.Handle, ref marg);
            designerState = LabDesignState.start;
            ScreenModer();
           
        }

		private void PsycologyDesigner_Resize(object sender, EventArgs e)
		{
			pnlSetting.Width = pbDesign.Width - 14;
            if (_curTask != null)
                _curTask.OperationalSize = new Size(spltContner.Panel2.Width, spltContner.Panel2.Height);
        }

		void PsycologyDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckSave(true))
                e.Cancel = true;
        }

		private void spltContner_SplitterMoved(object sender, SplitterEventArgs e)
		{
			
		}

		#endregion

		#region pbdesign

		void pbDesign_MouseUp(object sender, MouseEventArgs e)
		{
			if (_curTask == null)
				return;
			
			Color sColor = Color.Black;
			#region moving node
			if (lastState == LabDesignState.onChange && selectedNode != null)
			{
				//UpdateRatio(e, out x, out y);
				UpdateNode(e.X, e.Y);
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
					//UpdateRatio(e, out x, out y);
					GiveNode(e.X, e.Y);
					designerState = LabDesignState.onInsert;
				}  

            }
			#endregion

		}

		void pbDesign_MouseDown(object sender, MouseEventArgs e)
		{
			
			if (_curTask == null)
				return;

			//UpdateRatio(e, out x, out y);
			
			Node tempSel = _curTask.findNode(e.X, e.Y);
			pnlSetting.Visible = false;

			if (lastState == LabDesignState.onDesign)
			{
				if (tempSel != null)
				{
					
					selectedNode = tempSel;
					selectedNode.enable = true;
					ShowNode(selectedNode);
					designerState = LabDesignState.onChange;
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
					designerState = LabDesignState.onChange;
				}
			}
			if (lastState == LabDesignState.onInsert)
			{
				if (tempSel == null)
					return;
				if (tempSel._id == inserNode._id)
				{

					inserNode.enable = false;
					designerState = LabDesignState.onInsert;
				}
				
				return;
			}

		}

		#endregion

		#region panels

		private void btnChangeNode_Click(object sender, EventArgs e)
		{
			if (lastState == LabDesignState.onInsert)
				GiveNode(true);
			if (lastState == LabDesignState.onChange)
				UpdateNode(-1, -1);
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
                   	GiveNode(false);
					designerState = LabDesignState.onInsert;
				}
                RectSel = false;
				// To update  Node
				if(lastState == LabDesignState.onChange)
				{
					UpdateNode(-1, -1);
				}
				if (lastState == LabDesignState.onInsert)
				{
					GiveNode(false);
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
                   
					GiveNode(false);
					designerState = LabDesignState.onInsert;
				}
                CircSel = false;
                 // To update  Node
				if (lastState == LabDesignState.onChange)
				{
					UpdateNode(-1, -1);
				}
				if (lastState == LabDesignState.onInsert)
				{
					GiveNode(false);
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
				btnTaskBackColor.BackColor = cDilog.Color;
				_curTask.backColor = cDilog.Color;
				
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
            _curTask.OperationalSize = new Size(spltContner.Panel2.Width, spltContner.Panel2.Height);
            designerState = LabDesignState.onDesign;
			refreshTimer.Start();
		}

		void btnLoad_Click(object sender, EventArgs e)
		{
			if (refreshTimer.Enabled)
				refreshTimer.Stop();
			if (_curTask == null)
				_curTask = new PsycologyTask();
			if (_curTask.Load(true))
			{
				LoadTaskDesigner();
				designerState = LabDesignState.onDesign;
				refreshTimer.Start();

			}
		}

		void btnSetting_Click(object sender, EventArgs e)
		{
			pnlSetting.Visible = !pnlSetting.Visible;
		}

		private void cmbxSavMod_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbxSavMod.SelectedIndex == 0)
			{
				_curTask.SavingMode = SaveMod.txt;
				_curTask.Save();
				if (_curTask.Address != null)
					txtPath.Text = _curTask.Address;
			}
		}

		private void chkSaveData_CheckedChanged(object sender, EventArgs e)
		{
			if (!chkSaveData.Checked)
			{
				_curTask.UnSave();
				txtPath.Text = "";
			}
			else
				cmbxSavMod.DroppedDown = true;
			
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!chkSaveData.Checked)
			{
				chkSaveData.Checked = true;
				pnlSetting.Visible = true;
				cmbxSavMod.DroppedDown = true;
			}
			else
				CheckSave(false);
		}

		#endregion

		#region handler methods

		void ShowNode(Node node)        //نمایش مشخصات گره
		{
			if (node.shape == Shape.Circle)
			{
				pnlBtnCircle.BackColor = node.shapeColor;
				txtHeight.Enabled = false;
				_circSel = true;
			}
			else if (node.shape == Shape.Rectangle)
			{
				_rectSel = true;
				txtHeight.Text = node.height.ToString();
				pnlBtnRect.BackColor = node.shapeColor;
			}
			txtWidth.Text = node.width.ToString();
			numUpDownNode.Value = node.number;
			//cmbNumber.Text = node.number.ToString();
			btnNumberColor.BackColor = node.textColor;
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
		
			inserNode.relationalPosition.X = (float)x / pbDesign.Width;
			inserNode.relationalPosition.Y = (float)y / pbDesign.Height;
            inserNode.absolutePosition.X = x;
            inserNode.absolutePosition.Y = y;
            inserNode.shape = shp;
			inserNode.height = h; inserNode.width = w; inserNode.number = (int)numUpDownNode.Value; inserNode.textColor = btnNumberColor.BackColor;
			inserNode.shapeColor = sColor;
			//inserted node is drawed on image so is ready to add to map.
			inserNode.enable = true;

			// add normal node to map
			if (!chboxFixate.Checked) 
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
			int w, h = 0;
			float x, y;
			Shape shp = Shape.Circle;
			Color sColor = Color.Red;

			x = (float)r.Next(0, 100) / 100;
			y = (float)r.Next(0, 100) / 100;

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
                inserNode = new Node(-1, new PointF(x, y), shp, sColor, (int)numUpDownNode.Value, btnNumberColor.BackColor, w, h, pbDesign.Size);
            }
            else
            {
                inserNode.shape = shp;
                inserNode.height = h; inserNode.width = w; inserNode.number = (int)numUpDownNode.Value; inserNode.textColor = btnNumberColor.BackColor;
                inserNode.shapeColor = sColor;
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
		
		/// <summary>
		/// update node features for example  width or height.
		/// use  input x and y  -1 to avoid update node position.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
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
			selectedNode.shapeColor = sColor;
			if (x != -1)
			{
				selectedNode.relationalPosition.X = (float)x / pbDesign.Width;
				selectedNode.relationalPosition.Y = (float)y / pbDesign.Height;
                selectedNode.absolutePosition.X = x;
                selectedNode.absolutePosition.Y = y;
            }
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
						lastState = LabDesignState.start;
						designerState = LabDesignState.idle;
						break;
					}
				case LabDesignState.onDesign:
					{
						_rectSel = false;
						_circSel = false;
						pnlBtnCircle.BackColor = SystemColors.ActiveCaption;
						pnlBtnRect.BackColor = SystemColors.ActiveCaption;
						btnSetting.Enabled = true;
						pnlShapVis = true; pnlShapPropVis = false; pnlDetalsVis = false; pnlbackVis = false; pnlFixVis = false;
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
						pnlShapVis = true; pnlShapPropVis = true; pnlDetalsVis = true; pnlbackVis = false;
						PanelModer();
						if (inserNode.enable)
							pbDesign.Cursor = Cursors.Default;
						else
							pbDesign.Cursor = Cursors.Hand;
						if (inserNode.enable)
							_curTask.DrawNodePrompt(10, new int[1] { inserNode._id }, Color.Yellow, true);
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
						pnlShapVis = true; pnlShapPropVis = true; pnlDetalsVis = true; pnlbackVis = false;
						PanelModer();
						if (selectedNode.enable)
							pbDesign.Cursor = Cursors.Hand;
						else
							pbDesign.Cursor = Cursors.Default;
						_curTask.DrawNodePrompt(10, new int[1] { selectedNode._id }, Color.Yellow, true);
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

		bool CheckSave(bool showDialogtoContinue)
		{
			if (!showDialogtoContinue)
			{
				return _curTask == null || _curTask.Save();
			}

			DialogResult dr = DialogResult.Yes;
			if (_curTask != null && !_curTask.Save())
			{
				dr = MetroFramework.MetroMessageBox.Show((IWin32Window)this, "Project not saved. Do you want to continue?", "Save Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 100);
				if (dr == DialogResult.No)
					return false;
				else
					return true;
			}
			else
				return true;
			
		}

		void UpdateRatio(MouseEventArgs e, out int x, out int y)
		{
			screenPictureboxRatioX = (double)BasConfigs._monitor_resolution_x / pbDesign.Size.Width;
			screenPictureboxRatioY = (double)BasConfigs._monitor_resolution_y / pbDesign.Size.Height;

			x = Math.Max((int)(screenPictureboxRatioX * e.X),  10);
			y = Math.Max((int)(screenPictureboxRatioY * e.Y), 10);
		}

		void LoadTaskDesigner()
		{
			if (_curTask == null)
				return;
			if (_curTask.useBackImage)
				chkboxUseBackImage.Checked = true;
			if (_curTask.Address != null)
			{
				chkSaveData.Checked = true;
				txtPath.Text = _curTask.Address;
			}
			btnTaskBackColor.BackColor = _curTask.backColor;
            _curTask.OperationalSize = new Size(spltContner.Panel2.Width, spltContner.Panel2.Height);

        }

		#endregion
	}

	public enum LabDesignState { onInsert, onChange, onDesign, idle , start }
}
