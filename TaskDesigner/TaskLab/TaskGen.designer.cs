using Basics;
namespace TaskLab
{
    partial class TaskGen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskGen));
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.btnSave = new MetroFramework.Controls.MetroTile();
			this.pbDesign = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pnlconnect = new MetroFramework.Controls.MetroPanel();
			this.Lconnect = new MetroFramework.Controls.MetroLabel();
			this.Ldisconnect = new MetroFramework.Controls.MetroLabel();
			this.tltpHelp = new System.Windows.Forms.ToolTip(this.components);
			this.btnHome = new MetroFramework.Controls.MetroTile();
			this.btnNewProject = new MetroFramework.Controls.MetroTile();
			this.btnSetting = new MetroFramework.Controls.MetroTile();
			this.btnLoad = new MetroFramework.Controls.MetroTile();
			this.btnBackgroundCol = new System.Windows.Forms.Button();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.icndisconnect = new System.Windows.Forms.PictureBox();
			this.icnconnect = new System.Windows.Forms.PictureBox();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblX = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblY = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pnlPics = new MetroFramework.Controls.MetroPanel();
			this.pnlAddPic = new System.Windows.Forms.Panel();
			this.lblSlideNumber = new System.Windows.Forms.Label();
			this.txtPicTime = new System.Windows.Forms.TextBox();
			this.lblPicTime = new System.Windows.Forms.Label();
			this.btnAddPic = new MetroFramework.Controls.MetroTile();
			this.pnlSetting = new System.Windows.Forms.Panel();
			this.pnlSetButton = new System.Windows.Forms.Panel();
			this.btnStart = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.chkbxMakTransprnt = new MetroFramework.Controls.MetroCheckBox();
			this.cmbxSavMod = new MetroFramework.Controls.MetroComboBox();
			this.chkboxChessDraw = new MetroFramework.Controls.MetroCheckBox();
			this.txtPath = new MetroFramework.Controls.MetroTextBox();
			this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
			this.enterWebURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ThumbPicsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.setVideoMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setImageMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showSettingsPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDesign)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.icndisconnect)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.icnconnect)).BeginInit();
			this.MainMenu.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.pnlPics.SuspendLayout();
			this.pnlAddPic.SuspendLayout();
			this.pnlSetting.SuspendLayout();
			this.pnlSetButton.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
			this.ThumbPicsMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// btnSave
			// 
			this.btnSave.ActiveControl = null;
			this.errorProvider1.SetIconAlignment(this.btnSave, System.Windows.Forms.ErrorIconAlignment.TopLeft);
			this.btnSave.Location = new System.Drawing.Point(160, 52);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(38, 38);
			this.btnSave.Style = MetroFramework.MetroColorStyle.White;
			this.btnSave.TabIndex = 53;
			this.btnSave.TileImage = global::TaskDesigner.Resource.save;
			this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnSave.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.tltpHelp.SetToolTip(this.btnSave, "Save Project");
			this.btnSave.UseCustomBackColor = true;
			this.btnSave.UseSelectable = true;
			this.btnSave.UseStyleColors = true;
			this.btnSave.UseTileImage = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pbDesign
			// 
			this.pbDesign.BackColor = System.Drawing.Color.Transparent;
			this.pbDesign.Cursor = System.Windows.Forms.Cursors.NoMove2D;
			this.pbDesign.Dock = System.Windows.Forms.DockStyle.Fill;
			this.errorProvider1.SetIconAlignment(this.pbDesign, System.Windows.Forms.ErrorIconAlignment.TopLeft);
			this.pbDesign.Location = new System.Drawing.Point(0, 0);
			this.pbDesign.Name = "pbDesign";
			this.pbDesign.Size = new System.Drawing.Size(954, 725);
			this.pbDesign.TabIndex = 84;
			this.pbDesign.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Yellow;
			this.panel2.Location = new System.Drawing.Point(0, 744);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1180, 5);
			this.panel2.TabIndex = 70;
			// 
			// pnlconnect
			// 
			this.pnlconnect.HorizontalScrollbarBarColor = true;
			this.pnlconnect.HorizontalScrollbarHighlightOnWheel = false;
			this.pnlconnect.HorizontalScrollbarSize = 10;
			this.pnlconnect.Location = new System.Drawing.Point(0, 0);
			this.pnlconnect.Name = "pnlconnect";
			this.pnlconnect.Size = new System.Drawing.Size(200, 100);
			this.pnlconnect.TabIndex = 0;
			this.pnlconnect.VerticalScrollbarBarColor = true;
			this.pnlconnect.VerticalScrollbarHighlightOnWheel = false;
			this.pnlconnect.VerticalScrollbarSize = 10;
			// 
			// Lconnect
			// 
			this.Lconnect.Location = new System.Drawing.Point(0, 0);
			this.Lconnect.Name = "Lconnect";
			this.Lconnect.Size = new System.Drawing.Size(100, 23);
			this.Lconnect.TabIndex = 0;
			// 
			// Ldisconnect
			// 
			this.Ldisconnect.Location = new System.Drawing.Point(0, 0);
			this.Ldisconnect.Name = "Ldisconnect";
			this.Ldisconnect.Size = new System.Drawing.Size(100, 23);
			this.Ldisconnect.TabIndex = 0;
			// 
			// tltpHelp
			// 
			this.tltpHelp.AutoPopDelay = 10000;
			this.tltpHelp.InitialDelay = 500;
			this.tltpHelp.IsBalloon = true;
			this.tltpHelp.ReshowDelay = 100;
			// 
			// btnHome
			// 
			this.btnHome.ActiveControl = null;
			this.btnHome.BackColor = System.Drawing.Color.Transparent;
			this.btnHome.Location = new System.Drawing.Point(15, 52);
			this.btnHome.Name = "btnHome";
			this.btnHome.Size = new System.Drawing.Size(38, 38);
			this.btnHome.Style = MetroFramework.MetroColorStyle.White;
			this.btnHome.TabIndex = 63;
			this.btnHome.TileImage = global::TaskDesigner.Resource.Home;
			this.btnHome.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnHome.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.tltpHelp.SetToolTip(this.btnHome, "Go to Home");
			this.btnHome.UseCustomBackColor = true;
			this.btnHome.UseSelectable = true;
			this.btnHome.UseStyleColors = true;
			this.btnHome.UseTileImage = true;
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			// 
			// btnNewProject
			// 
			this.btnNewProject.ActiveControl = null;
			this.btnNewProject.BackColor = System.Drawing.Color.Transparent;
			this.btnNewProject.Location = new System.Drawing.Point(85, 52);
			this.btnNewProject.Name = "btnNewProject";
			this.btnNewProject.Size = new System.Drawing.Size(38, 38);
			this.btnNewProject.Style = MetroFramework.MetroColorStyle.White;
			this.btnNewProject.TabIndex = 74;
			this.btnNewProject.TileImage = global::TaskDesigner.Properties.Resources.new_project;
			this.btnNewProject.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnNewProject.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.tltpHelp.SetToolTip(this.btnNewProject, "Create New Project");
			this.btnNewProject.UseCustomBackColor = true;
			this.btnNewProject.UseSelectable = true;
			this.btnNewProject.UseStyleColors = true;
			this.btnNewProject.UseTileImage = true;
			this.btnNewProject.Click += new System.EventHandler(this.btnNewProject_Click);
			// 
			// btnSetting
			// 
			this.btnSetting.ActiveControl = null;
			this.btnSetting.BackColor = System.Drawing.Color.Transparent;
			this.btnSetting.Location = new System.Drawing.Point(15, 11);
			this.btnSetting.Name = "btnSetting";
			this.btnSetting.Size = new System.Drawing.Size(38, 38);
			this.btnSetting.Style = MetroFramework.MetroColorStyle.White;
			this.btnSetting.TabIndex = 61;
			this.btnSetting.TileImage = global::TaskDesigner.Properties.Resources.setting;
			this.btnSetting.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnSetting.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.tltpHelp.SetToolTip(this.btnSetting, "Setting");
			this.btnSetting.UseCustomBackColor = true;
			this.btnSetting.UseSelectable = true;
			this.btnSetting.UseStyleColors = true;
			this.btnSetting.UseTileImage = true;
			this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.ActiveControl = null;
			this.btnLoad.BackColor = System.Drawing.Color.Transparent;
			this.btnLoad.Location = new System.Drawing.Point(85, 11);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(38, 38);
			this.btnLoad.Style = MetroFramework.MetroColorStyle.White;
			this.btnLoad.TabIndex = 55;
			this.btnLoad.TileImage = global::TaskDesigner.Properties.Resources.open;
			this.btnLoad.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnLoad.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.tltpHelp.SetToolTip(this.btnLoad, "Open Project");
			this.btnLoad.UseCustomBackColor = true;
			this.btnLoad.UseSelectable = true;
			this.btnLoad.UseStyleColors = true;
			this.btnLoad.UseTileImage = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnBackgroundCol
			// 
			this.btnBackgroundCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBackgroundCol.BackColor = System.Drawing.Color.DimGray;
			this.btnBackgroundCol.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBackgroundCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBackgroundCol.Font = new System.Drawing.Font("Century Gothic", 15.75F);
			this.btnBackgroundCol.ForeColor = System.Drawing.Color.Black;
			this.btnBackgroundCol.Location = new System.Drawing.Point(891, 47);
			this.btnBackgroundCol.Margin = new System.Windows.Forms.Padding(6);
			this.btnBackgroundCol.Name = "btnBackgroundCol";
			this.btnBackgroundCol.Size = new System.Drawing.Size(40, 40);
			this.btnBackgroundCol.TabIndex = 89;
			this.btnBackgroundCol.Tag = "";
			this.tltpHelp.SetToolTip(this.btnBackgroundCol, "Change BackGround of Task");
			this.btnBackgroundCol.UseVisualStyleBackColor = false;
			this.btnBackgroundCol.Click += new System.EventHandler(this.btnBackGround_Click);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(0, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 749);
			this.splitter1.TabIndex = 82;
			this.splitter1.TabStop = false;
			// 
			// icndisconnect
			// 
			this.icndisconnect.Location = new System.Drawing.Point(0, 0);
			this.icndisconnect.Name = "icndisconnect";
			this.icndisconnect.Size = new System.Drawing.Size(100, 50);
			this.icndisconnect.TabIndex = 0;
			this.icndisconnect.TabStop = false;
			// 
			// icnconnect
			// 
			this.icnconnect.Location = new System.Drawing.Point(0, 0);
			this.icnconnect.Name = "icnconnect";
			this.icnconnect.Size = new System.Drawing.Size(100, 50);
			this.icnconnect.TabIndex = 0;
			this.icnconnect.TabStop = false;
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(144, 26);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
			this.toolStripMenuItem1.Text = "Show Setting";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblX,
            this.toolStripStatusLabel3,
            this.lblY});
			this.statusStrip1.Location = new System.Drawing.Point(3, 727);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1185, 22);
			this.statusStrip1.TabIndex = 84;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(23, 17);
			this.toolStripStatusLabel1.Text = "X:  ";
			// 
			// lblX
			// 
			this.lblX.Name = "lblX";
			this.lblX.Size = new System.Drawing.Size(0, 17);
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(26, 17);
			this.toolStripStatusLabel3.Text = ", Y: ";
			// 
			// lblY
			// 
			this.lblY.Name = "lblY";
			this.lblY.Size = new System.Drawing.Size(0, 17);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1185, 727);
			this.panel1.TabIndex = 85;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.pnlPics);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.splitContainer1.Panel2.BackgroundImage = global::TaskDesigner.Resource.linguistics_brown_big;
			this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.splitContainer1.Panel2.Controls.Add(this.pnlSetting);
			this.splitContainer1.Panel2.Controls.Add(this.pbDesign);
			this.splitContainer1.Panel2.Controls.Add(this.vlcControl1);
			this.splitContainer1.Size = new System.Drawing.Size(1185, 727);
			this.splitContainer1.SplitterDistance = 225;
			this.splitContainer1.TabIndex = 84;
			// 
			// pnlPics
			// 
			this.pnlPics.AutoScroll = true;
			this.pnlPics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
			this.pnlPics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPics.Controls.Add(this.pnlAddPic);
			this.pnlPics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPics.HorizontalScrollbar = true;
			this.pnlPics.HorizontalScrollbarBarColor = true;
			this.pnlPics.HorizontalScrollbarHighlightOnWheel = false;
			this.pnlPics.HorizontalScrollbarSize = 10;
			this.pnlPics.Location = new System.Drawing.Point(0, 0);
			this.pnlPics.Name = "pnlPics";
			this.pnlPics.Size = new System.Drawing.Size(223, 725);
			this.pnlPics.Style = MetroFramework.MetroColorStyle.Silver;
			this.pnlPics.TabIndex = 86;
			this.pnlPics.UseCustomBackColor = true;
			this.pnlPics.UseStyleColors = true;
			this.pnlPics.VerticalScrollbar = true;
			this.pnlPics.VerticalScrollbarBarColor = true;
			this.pnlPics.VerticalScrollbarHighlightOnWheel = true;
			this.pnlPics.VerticalScrollbarSize = 5;
			// 
			// pnlAddPic
			// 
			this.pnlAddPic.Controls.Add(this.lblSlideNumber);
			this.pnlAddPic.Controls.Add(this.txtPicTime);
			this.pnlAddPic.Controls.Add(this.lblPicTime);
			this.pnlAddPic.Controls.Add(this.btnAddPic);
			this.pnlAddPic.Location = new System.Drawing.Point(5, 5);
			this.pnlAddPic.Name = "pnlAddPic";
			this.pnlAddPic.Size = new System.Drawing.Size(200, 150);
			this.pnlAddPic.TabIndex = 78;
			this.pnlAddPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAddPic_Click);
			// 
			// lblSlideNumber
			// 
			this.lblSlideNumber.AutoSize = true;
			this.lblSlideNumber.Location = new System.Drawing.Point(7, 126);
			this.lblSlideNumber.Name = "lblSlideNumber";
			this.lblSlideNumber.Size = new System.Drawing.Size(13, 13);
			this.lblSlideNumber.TabIndex = 73;
			this.lblSlideNumber.Text = "1";
			this.lblSlideNumber.Visible = false;
			// 
			// txtPicTime
			// 
			this.txtPicTime.Location = new System.Drawing.Point(94, 123);
			this.txtPicTime.Name = "txtPicTime";
			this.txtPicTime.Size = new System.Drawing.Size(92, 20);
			this.txtPicTime.TabIndex = 3;
			this.txtPicTime.Text = "1000";
			this.txtPicTime.Visible = false;
			// 
			// lblPicTime
			// 
			this.lblPicTime.AutoSize = true;
			this.lblPicTime.Location = new System.Drawing.Point(26, 126);
			this.lblPicTime.Name = "lblPicTime";
			this.lblPicTime.Size = new System.Drawing.Size(52, 13);
			this.lblPicTime.TabIndex = 72;
			this.lblPicTime.Text = "Time:(ms)";
			this.lblPicTime.Visible = false;
			// 
			// btnAddPic
			// 
			this.btnAddPic.ActiveControl = null;
			this.btnAddPic.ForeColor = System.Drawing.SystemColors.Control;
			this.btnAddPic.Location = new System.Drawing.Point(7, 6);
			this.btnAddPic.Name = "btnAddPic";
			this.btnAddPic.Size = new System.Drawing.Size(180, 112);
			this.btnAddPic.Style = MetroFramework.MetroColorStyle.Pink;
			this.btnAddPic.TabIndex = 71;
			this.btnAddPic.Text = "Click To Add Slide";
			this.btnAddPic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnAddPic.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnAddPic.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.btnAddPic.UseCustomForeColor = true;
			this.btnAddPic.UseSelectable = true;
			this.btnAddPic.UseTileImage = true;
			this.btnAddPic.Click += new System.EventHandler(this.btnAddPic_Click);
			// 
			// pnlSetting
			// 
			this.pnlSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
			this.pnlSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlSetting.Controls.Add(this.pnlSetButton);
			this.pnlSetting.Controls.Add(this.label1);
			this.pnlSetting.Controls.Add(this.chkbxMakTransprnt);
			this.pnlSetting.Controls.Add(this.btnBackgroundCol);
			this.pnlSetting.Controls.Add(this.cmbxSavMod);
			this.pnlSetting.Controls.Add(this.chkboxChessDraw);
			this.pnlSetting.Controls.Add(this.txtPath);
			this.pnlSetting.Location = new System.Drawing.Point(7, 622);
			this.pnlSetting.Name = "pnlSetting";
			this.pnlSetting.Size = new System.Drawing.Size(940, 95);
			this.pnlSetting.TabIndex = 90;
			// 
			// pnlSetButton
			// 
			this.pnlSetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlSetButton.BackColor = System.Drawing.Color.Transparent;
			this.pnlSetButton.Controls.Add(this.btnStart);
			this.pnlSetButton.Controls.Add(this.btnHome);
			this.pnlSetButton.Controls.Add(this.btnNewProject);
			this.pnlSetButton.Controls.Add(this.btnSetting);
			this.pnlSetButton.Controls.Add(this.btnLoad);
			this.pnlSetButton.Controls.Add(this.btnSave);
			this.pnlSetButton.Location = new System.Drawing.Point(-1, -1);
			this.pnlSetButton.Name = "pnlSetButton";
			this.pnlSetButton.Size = new System.Drawing.Size(214, 95);
			this.pnlSetButton.TabIndex = 93;
			// 
			// btnStart
			// 
			this.btnStart.BackgroundImage = global::TaskDesigner.Resource.Run;
			this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnStart.FlatAppearance.BorderSize = 0;
			this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStart.Location = new System.Drawing.Point(159, 11);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(38, 38);
			this.btnStart.TabIndex = 75;
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(785, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 13);
			this.label1.TabIndex = 92;
			this.label1.Text = "Image Background";
			// 
			// chkbxMakTransprnt
			// 
			this.chkbxMakTransprnt.AutoSize = true;
			this.chkbxMakTransprnt.BackColor = System.Drawing.Color.Transparent;
			this.chkbxMakTransprnt.Location = new System.Drawing.Point(228, 43);
			this.chkbxMakTransprnt.Name = "chkbxMakTransprnt";
			this.chkbxMakTransprnt.Size = new System.Drawing.Size(157, 15);
			this.chkbxMakTransprnt.TabIndex = 85;
			this.chkbxMakTransprnt.Text = "Make Transparent Picture";
			this.chkbxMakTransprnt.UseCustomBackColor = true;
			this.chkbxMakTransprnt.UseSelectable = true;
			this.chkbxMakTransprnt.CheckedChanged += new System.EventHandler(this.chkbxMakTransprnt_CheckedChanged);
			// 
			// cmbxSavMod
			// 
			this.cmbxSavMod.BackColor = System.Drawing.Color.Transparent;
			this.cmbxSavMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbxSavMod.FontSize = MetroFramework.MetroComboBoxSize.Small;
			this.cmbxSavMod.FormattingEnabled = true;
			this.cmbxSavMod.ItemHeight = 19;
			this.cmbxSavMod.Items.AddRange(new object[] {
            "Text mode"});
			this.cmbxSavMod.Location = new System.Drawing.Point(228, 8);
			this.cmbxSavMod.Name = "cmbxSavMod";
			this.cmbxSavMod.PromptText = "Saving Mode";
			this.cmbxSavMod.Size = new System.Drawing.Size(122, 25);
			this.cmbxSavMod.TabIndex = 74;
			this.cmbxSavMod.UseCustomBackColor = true;
			this.cmbxSavMod.UseSelectable = true;
			this.cmbxSavMod.SelectedIndexChanged += new System.EventHandler(this.cmbxSavMod_SelectedIndexChanged);
			// 
			// chkboxChessDraw
			// 
			this.chkboxChessDraw.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkboxChessDraw.AutoSize = true;
			this.chkboxChessDraw.BackColor = System.Drawing.Color.Transparent;
			this.chkboxChessDraw.Location = new System.Drawing.Point(228, 74);
			this.chkboxChessDraw.Name = "chkboxChessDraw";
			this.chkboxChessDraw.Size = new System.Drawing.Size(115, 15);
			this.chkboxChessDraw.TabIndex = 73;
			this.chkboxChessDraw.Text = "Chessboard Draw";
			this.chkboxChessDraw.UseCustomBackColor = true;
			this.chkboxChessDraw.UseSelectable = true;
			this.chkboxChessDraw.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
			// 
			// txtPath
			// 
			this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
			// 
			// 
			// 
			this.txtPath.CustomButton.Image = null;
			this.txtPath.CustomButton.Location = new System.Drawing.Point(383, 1);
			this.txtPath.CustomButton.Name = "";
			this.txtPath.CustomButton.Size = new System.Drawing.Size(23, 23);
			this.txtPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.txtPath.CustomButton.TabIndex = 1;
			this.txtPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.txtPath.CustomButton.UseSelectable = true;
			this.txtPath.CustomButton.Visible = false;
			this.txtPath.Enabled = false;
			this.txtPath.Lines = new string[0];
			this.txtPath.Location = new System.Drawing.Point(369, 8);
			this.txtPath.MaxLength = 32767;
			this.txtPath.Name = "txtPath";
			this.txtPath.PasswordChar = '\0';
			this.txtPath.PromptText = "Task Saving Address";
			this.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPath.SelectedText = "";
			this.txtPath.SelectionLength = 0;
			this.txtPath.SelectionStart = 0;
			this.txtPath.ShortcutsEnabled = true;
			this.txtPath.Size = new System.Drawing.Size(407, 25);
			this.txtPath.TabIndex = 72;
			this.txtPath.UseCustomBackColor = true;
			this.txtPath.UseSelectable = true;
			this.txtPath.WaterMark = "Task Saving Address";
			this.txtPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.txtPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// vlcControl1
			// 
			this.vlcControl1.BackColor = System.Drawing.Color.Black;
			this.vlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vlcControl1.Location = new System.Drawing.Point(0, 0);
			this.vlcControl1.Name = "vlcControl1";
			this.vlcControl1.Size = new System.Drawing.Size(954, 725);
			this.vlcControl1.Spu = -1;
			this.vlcControl1.TabIndex = 91;
			this.vlcControl1.Text = "vlcControl1";
			this.vlcControl1.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcControl1.VlcLibDirectory")));
			this.vlcControl1.VlcMediaplayerOptions = null;
			// 
			// enterWebURLToolStripMenuItem
			// 
			this.enterWebURLToolStripMenuItem.Name = "enterWebURLToolStripMenuItem";
			this.enterWebURLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.enterWebURLToolStripMenuItem.Text = "Enter Web URL";
			this.enterWebURLToolStripMenuItem.Click += new System.EventHandler(this.enterWebURLToolStripMenuItem_Click);
			// 
			// ThumbPicsMenu
			// 
			this.ThumbPicsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterWebURLToolStripMenuItem,
            this.setVideoMediaToolStripMenuItem,
            this.setImageMediaToolStripMenuItem,
            this.showSettingsPanelToolStripMenuItem});
			this.ThumbPicsMenu.Name = "ThumbPicsMenu";
			this.ThumbPicsMenu.Size = new System.Drawing.Size(181, 92);
			// 
			// setVideoMediaToolStripMenuItem
			// 
			this.setVideoMediaToolStripMenuItem.Name = "setVideoMediaToolStripMenuItem";
			this.setVideoMediaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.setVideoMediaToolStripMenuItem.Text = "Set Video Media";
			this.setVideoMediaToolStripMenuItem.Click += new System.EventHandler(this.setVideoMediaToolStripMenuItem_Click);
			// 
			// setImageMediaToolStripMenuItem
			// 
			this.setImageMediaToolStripMenuItem.Name = "setImageMediaToolStripMenuItem";
			this.setImageMediaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.setImageMediaToolStripMenuItem.Text = "Set Image Media";
			this.setImageMediaToolStripMenuItem.Click += new System.EventHandler(this.setImageMediaToolStripMenuItem_Click);
			// 
			// showSettingsPanelToolStripMenuItem
			// 
			this.showSettingsPanelToolStripMenuItem.Name = "showSettingsPanelToolStripMenuItem";
			this.showSettingsPanelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.showSettingsPanelToolStripMenuItem.Text = "Show Settings Panel";
			this.showSettingsPanelToolStripMenuItem.Click += new System.EventHandler(this.showSettingsPanelToolStripMenuItem_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// TaskGen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.BackgroundImage = global::TaskDesigner.Resource.linguistics_brown_big;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1188, 749);
			this.ContextMenuStrip = this.MainMenu;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "TaskGen";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Linguistic Task Designer";
			this.tltpHelp.SetToolTip(this, "Grab form to move it!");
			this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskGen_FormClosing);
			this.Load += new System.EventHandler(this.TaskGen_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.Resize += new System.EventHandler(this.TaskGen_Resize);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDesign)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.icndisconnect)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.icnconnect)).EndInit();
			this.MainMenu.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.pnlPics.ResumeLayout(false);
			this.pnlAddPic.ResumeLayout(false);
			this.pnlAddPic.PerformLayout();
			this.pnlSetting.ResumeLayout(false);
			this.pnlSetting.PerformLayout();
			this.pnlSetButton.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
			this.ThumbPicsMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel2;
		
		public System.Windows.Forms.PictureBox icndisconnect;
        public MetroFramework.Controls.MetroLabel Ldisconnect;
        public MetroFramework.Controls.MetroLabel Lconnect;
        public System.Windows.Forms.PictureBox icnconnect;
        public MetroFramework.Controls.MetroPanel pnlconnect;
		private System.Windows.Forms.ToolTip tltpHelp;
		private System.Windows.Forms.Splitter splitter1;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.ContextMenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private MetroFramework.Controls.MetroPanel pnlPics;
		private System.Windows.Forms.Panel pnlAddPic;
		private System.Windows.Forms.Label lblSlideNumber;
		private System.Windows.Forms.TextBox txtPicTime;
		private System.Windows.Forms.Label lblPicTime;
		private MetroFramework.Controls.MetroTile btnAddPic;
		private System.Windows.Forms.Panel pnlSetting;
		private System.Windows.Forms.Panel pnlSetButton;
		private MetroFramework.Controls.MetroTile btnHome;
		private MetroFramework.Controls.MetroTile btnNewProject;
		private MetroFramework.Controls.MetroTile btnSetting;
		private MetroFramework.Controls.MetroTile btnLoad;
		private MetroFramework.Controls.MetroTile btnSave;
		private System.Windows.Forms.Label label1;
		private MetroFramework.Controls.MetroCheckBox chkbxMakTransprnt;
		private System.Windows.Forms.Button btnBackgroundCol;
		private MetroFramework.Controls.MetroComboBox cmbxSavMod;
		private MetroFramework.Controls.MetroCheckBox chkboxChessDraw;
		private MetroFramework.Controls.MetroTextBox txtPath;
		private System.Windows.Forms.PictureBox pbDesign;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel lblX;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel lblY;
		private Vlc.DotNet.Forms.VlcControl vlcControl1;
        private System.Windows.Forms.ContextMenuStrip ThumbPicsMenu;
        private System.Windows.Forms.ToolStripMenuItem enterWebURLToolStripMenuItem;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.ToolStripMenuItem setVideoMediaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setImageMediaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showSettingsPanelToolStripMenuItem;
		private System.Windows.Forms.Timer timer1;
	}
}

