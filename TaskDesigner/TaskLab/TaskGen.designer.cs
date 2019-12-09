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
			this.pbDesign = new System.Windows.Forms.PictureBox();
			this.btnSave = new MetroFramework.Controls.MetroTile();
			this.tmrMain = new System.Windows.Forms.Timer(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.pnlconnect = new MetroFramework.Controls.MetroPanel();
			this.Lconnect = new MetroFramework.Controls.MetroLabel();
			this.Ldisconnect = new MetroFramework.Controls.MetroLabel();
			this.tltpHelp = new System.Windows.Forms.ToolTip(this.components);
			this.btnBackgroundCol = new ns1.BunifuTileButton();
			this.btnStart = new MetroFramework.Controls.MetroTile();
			this.btnLoad = new MetroFramework.Controls.MetroTile();
			this.btnSetting = new MetroFramework.Controls.MetroTile();
			this.btnNewProject = new MetroFramework.Controls.MetroTile();
			this.btnHome = new MetroFramework.Controls.MetroTile();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.icndisconnect = new System.Windows.Forms.PictureBox();
			this.icnconnect = new System.Windows.Forms.PictureBox();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pnlPics = new MetroFramework.Controls.MetroPanel();
			this.pnlAddPic = new System.Windows.Forms.Panel();
			this.lblSlideNumber = new System.Windows.Forms.Label();
			this.txtPicTime = new System.Windows.Forms.TextBox();
			this.lblPicTime = new System.Windows.Forms.Label();
			this.btnAddPic = new MetroFramework.Controls.MetroTile();
			this.pnlSetting = new System.Windows.Forms.Panel();
			this.pnlSetButton = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.chkbxMakTransprnt = new MetroFramework.Controls.MetroCheckBox();
			this.chkSaveData = new MetroFramework.Controls.MetroCheckBox();
			this.cmbxSavMod = new MetroFramework.Controls.MetroComboBox();
			this.chkboxChessDraw = new MetroFramework.Controls.MetroCheckBox();
			this.txtPath = new MetroFramework.Controls.MetroTextBox();
			this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDesign)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.icndisconnect)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.icnconnect)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.pnlPics.SuspendLayout();
			this.pnlAddPic.SuspendLayout();
			this.pnlSetting.SuspendLayout();
			this.pnlSetButton.SuspendLayout();
			this.MainMenu.SuspendLayout();
		
			this.SuspendLayout();
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// pbDesign
			// 
			this.pbDesign.BackColor = System.Drawing.Color.Transparent;
			this.pbDesign.Cursor = System.Windows.Forms.Cursors.NoMove2D;
			this.pbDesign.Dock = System.Windows.Forms.DockStyle.Fill;
			this.errorProvider1.SetIconAlignment(this.pbDesign, System.Windows.Forms.ErrorIconAlignment.TopLeft);
			this.pbDesign.Location = new System.Drawing.Point(0, 0);
			this.pbDesign.Name = "pbDesign";
			this.pbDesign.Size = new System.Drawing.Size(964, 747);
			this.pbDesign.TabIndex = 84;
			this.pbDesign.TabStop = false;
			this.pbDesign.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDesign_MouseMove);
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
			this.btnSave.UseSelectable = true;
			this.btnSave.UseStyleColors = true;
			this.btnSave.UseTileImage = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// tmrMain
			// 
			this.tmrMain.Interval = 40;
			this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Yellow;
			this.panel2.Location = new System.Drawing.Point(7, 600);
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
			// btnBackgroundCol
			// 
			this.btnBackgroundCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBackgroundCol.BackColor = System.Drawing.Color.White;
			this.btnBackgroundCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.btnBackgroundCol.color = System.Drawing.Color.White;
			this.btnBackgroundCol.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.btnBackgroundCol.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBackgroundCol.Font = new System.Drawing.Font("Century Gothic", 15.75F);
			this.btnBackgroundCol.ForeColor = System.Drawing.Color.Black;
			this.btnBackgroundCol.Image = null;
			this.btnBackgroundCol.ImagePosition = 20;
			this.btnBackgroundCol.ImageZoom = 50;
			this.btnBackgroundCol.LabelPosition = 41;
			this.btnBackgroundCol.LabelText = "";
			this.btnBackgroundCol.Location = new System.Drawing.Point(912, 47);
			this.btnBackgroundCol.Margin = new System.Windows.Forms.Padding(6);
			this.btnBackgroundCol.Name = "btnBackgroundCol";
			this.btnBackgroundCol.Size = new System.Drawing.Size(40, 40);
			this.btnBackgroundCol.TabIndex = 89;
			this.btnBackgroundCol.Tag = "";
			this.tltpHelp.SetToolTip(this.btnBackgroundCol, "Change BackGround of Task");
			this.btnBackgroundCol.Click += new System.EventHandler(this.btnBackGround_Click);
			// 
			// btnStart
			// 
			this.btnStart.ActiveControl = null;
			this.btnStart.BackColor = System.Drawing.Color.Transparent;
			this.btnStart.Location = new System.Drawing.Point(160, 9);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(38, 38);
			this.btnStart.Style = MetroFramework.MetroColorStyle.White;
			this.btnStart.TabIndex = 56;
			this.btnStart.TileImage = global::TaskDesigner.Properties.Resources.stop;
			this.btnStart.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnStart.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.tltpHelp.SetToolTip(this.btnStart, "Preview");
			this.btnStart.UseCustomBackColor = true;
			this.btnStart.UseSelectable = true;
			this.btnStart.UseStyleColors = true;
			this.btnStart.UseTileImage = true;
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
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(3, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.pnlPics);
			// 
			// splitContainer1.Panel2
			// 
			
			this.splitContainer1.Panel2.Controls.Add(this.pnlSetting);
			this.splitContainer1.Panel2.Controls.Add(this.pbDesign);
			this.splitContainer1.Size = new System.Drawing.Size(1185, 749);
			this.splitContainer1.SplitterDistance = 215;
			this.splitContainer1.TabIndex = 83;
			// 
			// pnlPics
			// 
			this.pnlPics.AutoScroll = true;
			this.pnlPics.BackColor = System.Drawing.Color.Transparent;
			this.pnlPics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPics.Controls.Add(this.pnlAddPic);
			this.pnlPics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPics.HorizontalScrollbar = true;
			this.pnlPics.HorizontalScrollbarBarColor = true;
			this.pnlPics.HorizontalScrollbarHighlightOnWheel = false;
			this.pnlPics.HorizontalScrollbarSize = 10;
			this.pnlPics.Location = new System.Drawing.Point(0, 0);
			this.pnlPics.Name = "pnlPics";
			this.pnlPics.Size = new System.Drawing.Size(213, 747);
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
			this.pnlAddPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlAddPic.Controls.Add(this.lblSlideNumber);
			this.pnlAddPic.Controls.Add(this.txtPicTime);
			this.pnlAddPic.Controls.Add(this.lblPicTime);
			this.pnlAddPic.Controls.Add(this.btnAddPic);
			this.pnlAddPic.Location = new System.Drawing.Point(6, 7);
			this.pnlAddPic.Name = "pnlAddPic";
			this.pnlAddPic.Size = new System.Drawing.Size(200, 150);
			this.pnlAddPic.TabIndex = 78;
			// 
			// lblSlideNumber
			// 
			this.lblSlideNumber.AutoSize = true;
			this.lblSlideNumber.Location = new System.Drawing.Point(10, 122);
			this.lblSlideNumber.Name = "lblSlideNumber";
			this.lblSlideNumber.Size = new System.Drawing.Size(13, 13);
			this.lblSlideNumber.TabIndex = 73;
			this.lblSlideNumber.Text = "1";
			this.lblSlideNumber.Visible = false;
			// 
			// txtPicTime
			// 
			this.txtPicTime.Location = new System.Drawing.Point(98, 119);
			this.txtPicTime.Name = "txtPicTime";
			this.txtPicTime.Size = new System.Drawing.Size(92, 20);
			this.txtPicTime.TabIndex = 3;
			this.txtPicTime.Text = "1000";
			this.txtPicTime.Visible = false;
			this.txtPicTime.TextChanged += new System.EventHandler(this.txtPicTime_Leave);
			// 
			// lblPicTime
			// 
			this.lblPicTime.AutoSize = true;
			this.lblPicTime.Location = new System.Drawing.Point(44, 122);
			this.lblPicTime.Name = "lblPicTime";
			this.lblPicTime.Size = new System.Drawing.Size(52, 13);
			this.lblPicTime.TabIndex = 72;
			this.lblPicTime.Text = "Time:(ms)";
			this.lblPicTime.Visible = false;
			// 
			// btnAddPic
			// 
			this.btnAddPic.ActiveControl = null;
			this.btnAddPic.Location = new System.Drawing.Point(7, 6);
			this.btnAddPic.Name = "btnAddPic";
			this.btnAddPic.Size = new System.Drawing.Size(180, 112);
			this.btnAddPic.Style = MetroFramework.MetroColorStyle.Pink;
			this.btnAddPic.TabIndex = 71;
			this.btnAddPic.Text = "Click To Add Slide";
			this.btnAddPic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnAddPic.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnAddPic.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.btnAddPic.UseSelectable = true;
			this.btnAddPic.UseTileImage = true;
			this.btnAddPic.Click += new System.EventHandler(this.btnAddPic_Click);
			// 
			// pnlSetting
			// 
			this.pnlSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlSetting.BackColor = System.Drawing.Color.AliceBlue;
			this.pnlSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlSetting.Controls.Add(this.pnlSetButton);
			this.pnlSetting.Controls.Add(this.label1);
			this.pnlSetting.Controls.Add(this.chkbxMakTransprnt);
			this.pnlSetting.Controls.Add(this.btnBackgroundCol);
			this.pnlSetting.Controls.Add(this.chkSaveData);
			this.pnlSetting.Controls.Add(this.cmbxSavMod);
			this.pnlSetting.Controls.Add(this.chkboxChessDraw);
			this.pnlSetting.Controls.Add(this.txtPath);
			this.pnlSetting.Location = new System.Drawing.Point(4, 649);
			this.pnlSetting.Name = "pnlSetting";
			this.pnlSetting.Size = new System.Drawing.Size(961, 95);
			this.pnlSetting.TabIndex = 90;
			this.pnlSetting.Visible = false;
			// 
			// pnlSetButton
			// 
			this.pnlSetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pnlSetButton.BackColor = System.Drawing.Color.AliceBlue;
			this.pnlSetButton.Controls.Add(this.btnHome);
			this.pnlSetButton.Controls.Add(this.btnNewProject);
			this.pnlSetButton.Controls.Add(this.btnSetting);
			this.pnlSetButton.Controls.Add(this.btnLoad);
			this.pnlSetButton.Controls.Add(this.btnStart);
			this.pnlSetButton.Controls.Add(this.btnSave);
			this.pnlSetButton.Location = new System.Drawing.Point(-1, -1);
			this.pnlSetButton.Name = "pnlSetButton";
			this.pnlSetButton.Size = new System.Drawing.Size(214, 95);
			this.pnlSetButton.TabIndex = 93;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(782, 74);
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
			// chkSaveData
			// 
			this.chkSaveData.AutoSize = true;
			this.chkSaveData.BackColor = System.Drawing.Color.Transparent;
			this.chkSaveData.Location = new System.Drawing.Point(228, 10);
			this.chkSaveData.Name = "chkSaveData";
			this.chkSaveData.Size = new System.Drawing.Size(47, 15);
			this.chkSaveData.TabIndex = 84;
			this.chkSaveData.Text = "Save";
			this.chkSaveData.UseCustomBackColor = true;
			this.chkSaveData.UseSelectable = true;
			this.chkSaveData.CheckedChanged += new System.EventHandler(this.chkSaveData_CheckedChanged_1);
			// 
			// cmbxSavMod
			// 
			this.cmbxSavMod.BackColor = System.Drawing.Color.Transparent;
			this.cmbxSavMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbxSavMod.FontSize = MetroFramework.MetroComboBoxSize.Small;
			this.cmbxSavMod.FormattingEnabled = true;
			this.cmbxSavMod.ItemHeight = 19;
			this.cmbxSavMod.Items.AddRange(new object[] {
            "Binary mode",
            "Text mode"});
			this.cmbxSavMod.Location = new System.Drawing.Point(281, 8);
			this.cmbxSavMod.Name = "cmbxSavMod";
			this.cmbxSavMod.PromptText = "Saving Mode";
			this.cmbxSavMod.Size = new System.Drawing.Size(122, 25);
			this.cmbxSavMod.TabIndex = 74;
			this.cmbxSavMod.UseCustomBackColor = true;
			this.cmbxSavMod.UseSelectable = true;
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
			this.txtPath.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.txtPath.CustomButton.Image = null;
			this.txtPath.CustomButton.Location = new System.Drawing.Point(354, 1);
			this.txtPath.CustomButton.Name = "";
			this.txtPath.CustomButton.Size = new System.Drawing.Size(23, 23);
			this.txtPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.txtPath.CustomButton.TabIndex = 1;
			this.txtPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.txtPath.CustomButton.UseSelectable = true;
			this.txtPath.CustomButton.Visible = false;
			this.txtPath.Enabled = false;
			this.txtPath.Lines = new string[0];
			this.txtPath.Location = new System.Drawing.Point(409, 8);
			this.txtPath.MaxLength = 32767;
			this.txtPath.Name = "txtPath";
			this.txtPath.PasswordChar = '\0';
			this.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtPath.SelectedText = "";
			this.txtPath.SelectionLength = 0;
			this.txtPath.SelectionStart = 0;
			this.txtPath.ShortcutsEnabled = true;
			this.txtPath.Size = new System.Drawing.Size(378, 25);
			this.txtPath.TabIndex = 72;
			this.txtPath.UseSelectable = true;
			this.txtPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.txtPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(112, 26);
			this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
			this.toolStripMenuItem1.Text = "Setting";
			// 
			// vlcControl1
			// 
			
			// 
			// TaskGen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1188, 749);
			this.ContextMenuStrip = this.MainMenu;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "TaskGen";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.tltpHelp.SetToolTip(this, "Grab form to move it!");
			this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskGen_FormClosing);
			this.Load += new System.EventHandler(this.TaskGen_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDesign)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.icndisconnect)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.icnconnect)).EndInit();
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
			this.MainMenu.ResumeLayout(false);
		
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox icndisconnect;
        public MetroFramework.Controls.MetroLabel Ldisconnect;
        public MetroFramework.Controls.MetroLabel Lconnect;
        public System.Windows.Forms.PictureBox icnconnect;
        public MetroFramework.Controls.MetroPanel pnlconnect;
		private System.Windows.Forms.ToolTip tltpHelp;
		private System.Windows.Forms.Splitter splitter1;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private MetroFramework.Controls.MetroPanel pnlPics;
		private System.Windows.Forms.Panel pnlAddPic;
		private System.Windows.Forms.Label lblSlideNumber;
		private System.Windows.Forms.TextBox txtPicTime;
		private System.Windows.Forms.Label lblPicTime;
		private MetroFramework.Controls.MetroTile btnAddPic;
		private System.Windows.Forms.PictureBox pbDesign;
		private System.Windows.Forms.ContextMenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.Panel pnlSetting;
		private System.Windows.Forms.Panel pnlSetButton;
		private MetroFramework.Controls.MetroTile btnHome;
		private MetroFramework.Controls.MetroTile btnNewProject;
		private MetroFramework.Controls.MetroTile btnSetting;
		private MetroFramework.Controls.MetroTile btnLoad;
		private MetroFramework.Controls.MetroTile btnStart;
		private MetroFramework.Controls.MetroTile btnSave;
		private System.Windows.Forms.Label label1;
		private MetroFramework.Controls.MetroCheckBox chkbxMakTransprnt;
		private ns1.BunifuTileButton btnBackgroundCol;
		private MetroFramework.Controls.MetroCheckBox chkSaveData;
		private MetroFramework.Controls.MetroComboBox cmbxSavMod;
		private MetroFramework.Controls.MetroCheckBox chkboxChessDraw;
		private MetroFramework.Controls.MetroTextBox txtPath;
		
	}
}

