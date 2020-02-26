
namespace Psychophysics
{
	partial class Designer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Fixations");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Stimulus");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Designer));
            this.PicB1 = new System.Windows.Forms.PictureBox();
            this.AddPicB = new System.Windows.Forms.PictureBox();
            this.FrameTime_ET = new System.Windows.Forms.TextBox();
            this.btnSelectImageFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.BgColor_BT = new System.Windows.Forms.Button();
            this.RectangleShape_BT = new System.Windows.Forms.Button();
            this.SquareShape_BT = new System.Windows.Forms.Button();
            this.CircleShape_BT = new System.Windows.Forms.Button();
            this.Popup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Size_LB = new System.Windows.Forms.Label();
            this.pbDesign = new System.Windows.Forms.PictureBox();
            this.expandCollapsePanel1 = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.advancedFlowLayoutPanel1 = new MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel();
            this.expandCollapsePanel2 = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.Objects_TV = new System.Windows.Forms.TreeView();
            this.expandCollapsePanel3 = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.expandCollapsePanel4 = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.pnlFrames = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.expandCollapsePanel6 = new MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel();
            this.rdbImageStim = new System.Windows.Forms.RadioButton();
            this.pnlImageStim = new System.Windows.Forms.Panel();
            this.txtStimY = new System.Windows.Forms.TextBox();
            this.txtStimX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStimHeight = new System.Windows.Forms.TextBox();
            this.txtStimWidth = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStimContrast = new System.Windows.Forms.TextBox();
            this.rdbShapeStim = new System.Windows.Forms.RadioButton();
            this.pnlShapeStim = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PicB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddPicB)).BeginInit();
            this.Popup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesign)).BeginInit();
            this.expandCollapsePanel1.SuspendLayout();
            this.advancedFlowLayoutPanel1.SuspendLayout();
            this.expandCollapsePanel2.SuspendLayout();
            this.expandCollapsePanel3.SuspendLayout();
            this.pnlFrames.SuspendLayout();
            this.expandCollapsePanel6.SuspendLayout();
            this.pnlImageStim.SuspendLayout();
            this.pnlShapeStim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // PicB1
            // 
            this.PicB1.Location = new System.Drawing.Point(36, 53);
            this.PicB1.Name = "PicB1";
            this.PicB1.Size = new System.Drawing.Size(193, 122);
            this.PicB1.TabIndex = 0;
            this.PicB1.TabStop = false;
            this.PicB1.Click += new System.EventHandler(this.PicB_Click);
            // 
            // AddPicB
            // 
            this.AddPicB.BackColor = System.Drawing.Color.White;
            this.AddPicB.Image = global::TaskDesigner.Resource.add;
            this.AddPicB.InitialImage = global::TaskDesigner.Resource.add;
            this.AddPicB.Location = new System.Drawing.Point(36, 201);
            this.AddPicB.Name = "AddPicB";
            this.AddPicB.Size = new System.Drawing.Size(193, 122);
            this.AddPicB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.AddPicB.TabIndex = 0;
            this.AddPicB.TabStop = false;
            this.AddPicB.Click += new System.EventHandler(this.AddPicB_Click);
            // 
            // FrameTime_ET
            // 
            this.FrameTime_ET.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FrameTime_ET.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.FrameTime_ET.Location = new System.Drawing.Point(175, 80);
            this.FrameTime_ET.Name = "FrameTime_ET";
            this.FrameTime_ET.Size = new System.Drawing.Size(68, 20);
            this.FrameTime_ET.TabIndex = 20;
            this.FrameTime_ET.Text = "0";
            this.FrameTime_ET.TextChanged += new System.EventHandler(this.FrameTime_ET_TextChanged);
            // 
            // btnSelectImageFile
            // 
            this.btnSelectImageFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelectImageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectImageFile.Location = new System.Drawing.Point(3, 9);
            this.btnSelectImageFile.Name = "btnSelectImageFile";
            this.btnSelectImageFile.Size = new System.Drawing.Size(207, 28);
            this.btnSelectImageFile.TabIndex = 11;
            this.btnSelectImageFile.Text = "Select Image";
            this.btnSelectImageFile.UseVisualStyleBackColor = false;
            this.btnSelectImageFile.Click += new System.EventHandler(this.Browse_BT);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 20);
            this.textBox1.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label16.Location = new System.Drawing.Point(33, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Frame Time";
            // 
            // BgColor_BT
            // 
            this.BgColor_BT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BgColor_BT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BgColor_BT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BgColor_BT.Location = new System.Drawing.Point(36, 42);
            this.BgColor_BT.Name = "BgColor_BT";
            this.BgColor_BT.Size = new System.Drawing.Size(207, 28);
            this.BgColor_BT.TabIndex = 4;
            this.BgColor_BT.Text = "Back Color";
            this.BgColor_BT.UseVisualStyleBackColor = false;
            this.BgColor_BT.Click += new System.EventHandler(this.btn_CanvasColor_Click_1);
            // 
            // RectangleShape_BT
            // 
            this.RectangleShape_BT.AutoEllipsis = true;
            this.RectangleShape_BT.BackColor = System.Drawing.Color.Transparent;
            this.RectangleShape_BT.BackgroundImage = global::TaskDesigner.Resource.setting;
            this.RectangleShape_BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RectangleShape_BT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RectangleShape_BT.FlatAppearance.BorderSize = 0;
            this.RectangleShape_BT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RectangleShape_BT.Location = new System.Drawing.Point(162, 16);
            this.RectangleShape_BT.Margin = new System.Windows.Forms.Padding(0);
            this.RectangleShape_BT.Name = "RectangleShape_BT";
            this.RectangleShape_BT.Size = new System.Drawing.Size(48, 48);
            this.RectangleShape_BT.TabIndex = 24;
            this.RectangleShape_BT.TabStop = false;
            this.RectangleShape_BT.UseMnemonic = false;
            this.RectangleShape_BT.UseVisualStyleBackColor = false;
            this.RectangleShape_BT.Click += new System.EventHandler(this.btn_Rectangle_Click);
            // 
            // SquareShape_BT
            // 
            this.SquareShape_BT.AutoEllipsis = true;
            this.SquareShape_BT.BackColor = System.Drawing.Color.Transparent;
            this.SquareShape_BT.BackgroundImage = global::TaskDesigner.Resource.setting;
            this.SquareShape_BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SquareShape_BT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SquareShape_BT.FlatAppearance.BorderSize = 0;
            this.SquareShape_BT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SquareShape_BT.Location = new System.Drawing.Point(8, 16);
            this.SquareShape_BT.Margin = new System.Windows.Forms.Padding(0);
            this.SquareShape_BT.Name = "SquareShape_BT";
            this.SquareShape_BT.Size = new System.Drawing.Size(48, 48);
            this.SquareShape_BT.TabIndex = 23;
            this.SquareShape_BT.TabStop = false;
            this.SquareShape_BT.UseMnemonic = false;
            this.SquareShape_BT.UseVisualStyleBackColor = false;
            this.SquareShape_BT.Click += new System.EventHandler(this.btn_Square_Click);
            // 
            // CircleShape_BT
            // 
            this.CircleShape_BT.AutoEllipsis = true;
            this.CircleShape_BT.BackColor = System.Drawing.Color.Transparent;
            this.CircleShape_BT.BackgroundImage = global::TaskDesigner.Resource.setting;
            this.CircleShape_BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CircleShape_BT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CircleShape_BT.FlatAppearance.BorderSize = 0;
            this.CircleShape_BT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CircleShape_BT.Location = new System.Drawing.Point(84, 18);
            this.CircleShape_BT.Margin = new System.Windows.Forms.Padding(0);
            this.CircleShape_BT.Name = "CircleShape_BT";
            this.CircleShape_BT.Size = new System.Drawing.Size(48, 48);
            this.CircleShape_BT.TabIndex = 22;
            this.CircleShape_BT.TabStop = false;
            this.CircleShape_BT.UseMnemonic = false;
            this.CircleShape_BT.UseVisualStyleBackColor = false;
            this.CircleShape_BT.Click += new System.EventHandler(this.btn_Circle_Click);
            // 
            // Popup
            // 
            this.Popup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.Popup.Name = "Popup";
            this.Popup.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Popup.Size = new System.Drawing.Size(108, 48);
            this.Popup.Opening += new System.ComponentModel.CancelEventHandler(this.Popup_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // Size_LB
            // 
            this.Size_LB.AutoSize = true;
            this.Size_LB.Location = new System.Drawing.Point(976, 621);
            this.Size_LB.Name = "Size_LB";
            this.Size_LB.Size = new System.Drawing.Size(0, 13);
            this.Size_LB.TabIndex = 21;
            // 
            // pbDesign
            // 
            this.pbDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDesign.Location = new System.Drawing.Point(0, 0);
            this.pbDesign.Name = "pbDesign";
            this.pbDesign.Size = new System.Drawing.Size(1211, 788);
            this.pbDesign.TabIndex = 22;
            this.pbDesign.TabStop = false;
            this.pbDesign.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_Draw_MouseMove);
            // 
            // expandCollapsePanel1
            // 
            this.expandCollapsePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expandCollapsePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.expandCollapsePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expandCollapsePanel1.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.expandCollapsePanel1.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.expandCollapsePanel1.Controls.Add(this.advancedFlowLayoutPanel1);
            this.expandCollapsePanel1.ExpandedHeight = 0;
            this.expandCollapsePanel1.IsExpanded = true;
            this.expandCollapsePanel1.Location = new System.Drawing.Point(933, 0);
            this.expandCollapsePanel1.Name = "expandCollapsePanel1";
            this.expandCollapsePanel1.Size = new System.Drawing.Size(278, 788);
            this.expandCollapsePanel1.TabIndex = 27;
            this.expandCollapsePanel1.Text = "Design Panel";
            this.expandCollapsePanel1.UseAnimation = true;
            // 
            // advancedFlowLayoutPanel1
            // 
            this.advancedFlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.advancedFlowLayoutPanel1.Controls.Add(this.expandCollapsePanel2);
            this.advancedFlowLayoutPanel1.Controls.Add(this.expandCollapsePanel3);
            this.advancedFlowLayoutPanel1.Controls.Add(this.expandCollapsePanel4);
            this.advancedFlowLayoutPanel1.Controls.Add(this.expandCollapsePanel6);
            this.advancedFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.advancedFlowLayoutPanel1.Location = new System.Drawing.Point(16, 43);
            this.advancedFlowLayoutPanel1.Name = "advancedFlowLayoutPanel1";
            this.advancedFlowLayoutPanel1.Size = new System.Drawing.Size(256, 748);
            this.advancedFlowLayoutPanel1.TabIndex = 1;
            // 
            // expandCollapsePanel2
            // 
            this.expandCollapsePanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.expandCollapsePanel2.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.expandCollapsePanel2.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.expandCollapsePanel2.Controls.Add(this.FrameTime_ET);
            this.expandCollapsePanel2.Controls.Add(this.label16);
            this.expandCollapsePanel2.Controls.Add(this.Objects_TV);
            this.expandCollapsePanel2.Controls.Add(this.BgColor_BT);
            this.expandCollapsePanel2.ExpandedHeight = 243;
            this.expandCollapsePanel2.IsExpanded = false;
            this.expandCollapsePanel2.Location = new System.Drawing.Point(3, 3);
            this.expandCollapsePanel2.Name = "expandCollapsePanel2";
            this.expandCollapsePanel2.Size = new System.Drawing.Size(250, 35);
            this.expandCollapsePanel2.TabIndex = 2;
            this.expandCollapsePanel2.Text = "Frame Configuration";
            this.expandCollapsePanel2.UseAnimation = true;
            // 
            // Objects_TV
            // 
            this.Objects_TV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.Objects_TV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Objects_TV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Objects_TV.Location = new System.Drawing.Point(36, 113);
            this.Objects_TV.Name = "Objects_TV";
            treeNode1.Name = "";
            treeNode1.Text = "Fixations";
            treeNode2.Name = "";
            treeNode2.Text = "Stimulus";
            this.Objects_TV.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.Objects_TV.Size = new System.Drawing.Size(207, 127);
            this.Objects_TV.TabIndex = 26;
            // 
            // expandCollapsePanel3
            // 
            this.expandCollapsePanel3.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.expandCollapsePanel3.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.expandCollapsePanel3.Controls.Add(this.pnlShapeStim);
            this.expandCollapsePanel3.Controls.Add(this.rdbShapeStim);
            this.expandCollapsePanel3.Controls.Add(this.txtStimY);
            this.expandCollapsePanel3.Controls.Add(this.txtStimX);
            this.expandCollapsePanel3.Controls.Add(this.label6);
            this.expandCollapsePanel3.Controls.Add(this.label1);
            this.expandCollapsePanel3.Controls.Add(this.txtStimHeight);
            this.expandCollapsePanel3.Controls.Add(this.txtStimWidth);
            this.expandCollapsePanel3.Controls.Add(this.label11);
            this.expandCollapsePanel3.Controls.Add(this.label17);
            this.expandCollapsePanel3.Controls.Add(this.label5);
            this.expandCollapsePanel3.Controls.Add(this.txtStimContrast);
            this.expandCollapsePanel3.Controls.Add(this.pnlImageStim);
            this.expandCollapsePanel3.Controls.Add(this.rdbImageStim);
            this.expandCollapsePanel3.ExpandedHeight = 273;
            this.expandCollapsePanel3.IsExpanded = true;
            this.expandCollapsePanel3.Location = new System.Drawing.Point(3, 44);
            this.expandCollapsePanel3.Name = "expandCollapsePanel3";
            this.expandCollapsePanel3.Size = new System.Drawing.Size(250, 273);
            this.expandCollapsePanel3.TabIndex = 3;
            this.expandCollapsePanel3.Text = "Stimulus Tool";
            this.expandCollapsePanel3.UseAnimation = true;
            // 
            // expandCollapsePanel4
            // 
            this.expandCollapsePanel4.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.expandCollapsePanel4.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.expandCollapsePanel4.ExpandedHeight = 263;
            this.expandCollapsePanel4.IsExpanded = false;
            this.expandCollapsePanel4.Location = new System.Drawing.Point(3, 323);
            this.expandCollapsePanel4.Name = "expandCollapsePanel4";
            this.expandCollapsePanel4.Size = new System.Drawing.Size(250, 35);
            this.expandCollapsePanel4.TabIndex = 4;
            this.expandCollapsePanel4.Text = "Fixation Tool";
            this.expandCollapsePanel4.UseAnimation = true;
            // 
            // pnlFrames
            // 
            this.pnlFrames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlFrames.AutoScroll = true;
            this.pnlFrames.AutoScrollMinSize = new System.Drawing.Size(50, 10);
            this.pnlFrames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.pnlFrames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFrames.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.pnlFrames.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.pnlFrames.Controls.Add(this.PicB1);
            this.pnlFrames.Controls.Add(this.AddPicB);
            this.pnlFrames.ExpandedHeight = 0;
            this.pnlFrames.IsExpanded = true;
            this.pnlFrames.Location = new System.Drawing.Point(0, 0);
            this.pnlFrames.Name = "pnlFrames";
            this.pnlFrames.Size = new System.Drawing.Size(278, 788);
            this.pnlFrames.TabIndex = 28;
            this.pnlFrames.Text = "Frames";
            this.pnlFrames.UseAnimation = true;
            // 
            // expandCollapsePanel6
            // 
            this.expandCollapsePanel6.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal;
            this.expandCollapsePanel6.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle;
            this.expandCollapsePanel6.Controls.Add(this.dataGridView1);
            this.expandCollapsePanel6.ExpandedHeight = 319;
            this.expandCollapsePanel6.IsExpanded = false;
            this.expandCollapsePanel6.Location = new System.Drawing.Point(3, 364);
            this.expandCollapsePanel6.Name = "expandCollapsePanel6";
            this.expandCollapsePanel6.Size = new System.Drawing.Size(250, 35);
            this.expandCollapsePanel6.TabIndex = 5;
            this.expandCollapsePanel6.Text = "Event Tool";
            this.expandCollapsePanel6.UseAnimation = true;
            // 
            // rdbImageStim
            // 
            this.rdbImageStim.AutoSize = true;
            this.rdbImageStim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.rdbImageStim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.rdbImageStim.Location = new System.Drawing.Point(137, 36);
            this.rdbImageStim.Name = "rdbImageStim";
            this.rdbImageStim.Size = new System.Drawing.Size(60, 19);
            this.rdbImageStim.TabIndex = 1;
            this.rdbImageStim.Text = "Image";
            this.rdbImageStim.UseVisualStyleBackColor = false;
            // 
            // pnlImageStim
            // 
            this.pnlImageStim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.pnlImageStim.Controls.Add(this.textBox1);
            this.pnlImageStim.Controls.Add(this.btnSelectImageFile);
            this.pnlImageStim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pnlImageStim.Location = new System.Drawing.Point(33, 61);
            this.pnlImageStim.Name = "pnlImageStim";
            this.pnlImageStim.Size = new System.Drawing.Size(213, 78);
            this.pnlImageStim.TabIndex = 2;
            // 
            // txtStimY
            // 
            this.txtStimY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtStimY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStimY.Location = new System.Drawing.Point(183, 166);
            this.txtStimY.Name = "txtStimY";
            this.txtStimY.Size = new System.Drawing.Size(62, 20);
            this.txtStimY.TabIndex = 29;
            this.txtStimY.Text = "1";
            // 
            // txtStimX
            // 
            this.txtStimX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtStimX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStimX.Location = new System.Drawing.Point(183, 141);
            this.txtStimX.Name = "txtStimX";
            this.txtStimX.Size = new System.Drawing.Size(62, 20);
            this.txtStimX.TabIndex = 28;
            this.txtStimX.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.label6.Location = new System.Drawing.Point(38, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Position X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.label1.Location = new System.Drawing.Point(38, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Position Y";
            // 
            // txtStimHeight
            // 
            this.txtStimHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtStimHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStimHeight.Location = new System.Drawing.Point(183, 217);
            this.txtStimHeight.Name = "txtStimHeight";
            this.txtStimHeight.Size = new System.Drawing.Size(62, 20);
            this.txtStimHeight.TabIndex = 24;
            this.txtStimHeight.Text = "1";
            // 
            // txtStimWidth
            // 
            this.txtStimWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtStimWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStimWidth.Location = new System.Drawing.Point(183, 191);
            this.txtStimWidth.Name = "txtStimWidth";
            this.txtStimWidth.Size = new System.Drawing.Size(62, 20);
            this.txtStimWidth.TabIndex = 25;
            this.txtStimWidth.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.label11.Location = new System.Drawing.Point(38, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Height";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.label17.Location = new System.Drawing.Point(38, 248);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "Contrast";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.label5.Location = new System.Drawing.Point(38, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Width";
            // 
            // txtStimContrast
            // 
            this.txtStimContrast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtStimContrast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStimContrast.Location = new System.Drawing.Point(183, 243);
            this.txtStimContrast.Name = "txtStimContrast";
            this.txtStimContrast.Size = new System.Drawing.Size(62, 20);
            this.txtStimContrast.TabIndex = 21;
            this.txtStimContrast.Text = "255";
            // 
            // rdbShapeStim
            // 
            this.rdbShapeStim.AutoSize = true;
            this.rdbShapeStim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.rdbShapeStim.Checked = true;
            this.rdbShapeStim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.rdbShapeStim.Location = new System.Drawing.Point(33, 36);
            this.rdbShapeStim.Name = "rdbShapeStim";
            this.rdbShapeStim.Size = new System.Drawing.Size(61, 19);
            this.rdbShapeStim.TabIndex = 30;
            this.rdbShapeStim.TabStop = true;
            this.rdbShapeStim.Text = "Shape";
            this.rdbShapeStim.UseVisualStyleBackColor = false;
            this.rdbShapeStim.CheckedChanged += new System.EventHandler(this.rdbShapeStim_CheckedChanged);
            // 
            // pnlShapeStim
            // 
            this.pnlShapeStim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.pnlShapeStim.Controls.Add(this.RectangleShape_BT);
            this.pnlShapeStim.Controls.Add(this.SquareShape_BT);
            this.pnlShapeStim.Controls.Add(this.CircleShape_BT);
            this.pnlShapeStim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pnlShapeStim.Location = new System.Drawing.Point(33, 60);
            this.pnlShapeStim.Name = "pnlShapeStim";
            this.pnlShapeStim.Size = new System.Drawing.Size(213, 79);
            this.pnlShapeStim.TabIndex = 31;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(217, 272);
            this.dataGridView1.TabIndex = 1;
            // 
            // Designer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 788);
            this.Controls.Add(this.pnlFrames);
            this.Controls.Add(this.expandCollapsePanel1);
            this.Controls.Add(this.Size_LB);
            this.Controls.Add(this.pbDesign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Designer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DesignerForm_Load);
            this.Move += new System.EventHandler(this.Designer_Move);
            ((System.ComponentModel.ISupportInitialize)(this.PicB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddPicB)).EndInit();
            this.Popup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesign)).EndInit();
            this.expandCollapsePanel1.ResumeLayout(false);
            this.expandCollapsePanel1.PerformLayout();
            this.advancedFlowLayoutPanel1.ResumeLayout(false);
            this.expandCollapsePanel2.ResumeLayout(false);
            this.expandCollapsePanel2.PerformLayout();
            this.expandCollapsePanel3.ResumeLayout(false);
            this.expandCollapsePanel3.PerformLayout();
            this.pnlFrames.ResumeLayout(false);
            this.pnlFrames.PerformLayout();
            this.expandCollapsePanel6.ResumeLayout(false);
            this.expandCollapsePanel6.PerformLayout();
            this.pnlImageStim.ResumeLayout(false);
            this.pnlImageStim.PerformLayout();
            this.pnlShapeStim.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button BgColor_BT;
		private System.Windows.Forms.PictureBox AddPicB;
		private System.Windows.Forms.PictureBox PicB1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnSelectImageFile;
		private System.Windows.Forms.TextBox FrameTime_ET;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button CircleShape_BT;
		private System.Windows.Forms.Button RectangleShape_BT;
		private System.Windows.Forms.Button SquareShape_BT;
		private System.Windows.Forms.ContextMenuStrip Popup;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.Label Size_LB;
        private System.Windows.Forms.PictureBox pbDesign;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel expandCollapsePanel1;
        private MakarovDev.ExpandCollapsePanel.AdvancedFlowLayoutPanel advancedFlowLayoutPanel1;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel expandCollapsePanel2;
        private System.Windows.Forms.TreeView Objects_TV;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel expandCollapsePanel3;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel expandCollapsePanel4;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel pnlFrames;
        private MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel expandCollapsePanel6;
        private System.Windows.Forms.Panel pnlImageStim;
        private System.Windows.Forms.RadioButton rdbImageStim;
        private System.Windows.Forms.RadioButton rdbShapeStim;
        private System.Windows.Forms.TextBox txtStimY;
        private System.Windows.Forms.TextBox txtStimX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStimHeight;
        private System.Windows.Forms.TextBox txtStimWidth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStimContrast;
        private System.Windows.Forms.Panel pnlShapeStim;
        private System.Windows.Forms.DataGridView dataGridView1;
    }

}

