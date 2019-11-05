namespace TaskRunning
{
	partial class TaskOperator
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskOperator));
			this.TabControl_taskoperator = new MetroFramework.Controls.MetroTabControl();
			this.Tabtask = new MetroFramework.Controls.MetroTabPage();
			this.btStop = new MetroFramework.Controls.MetroButton();
			this.btnStart = new MetroFramework.Controls.MetroButton();
			this.txtbxTask = new MetroFramework.Controls.MetroTextBox();
			this.txtSavPath = new MetroFramework.Controls.MetroTextBox();
			this.pbOper = new System.Windows.Forms.PictureBox();
			this.Tabsetting = new MetroFramework.Controls.MetroTabPage();
			this.pnlGen = new System.Windows.Forms.GroupBox();
			this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
			this.pnlPsycophysics = new MetroFramework.Controls.MetroPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNumGazeSmth = new System.Windows.Forms.TextBox();
			this.chbuseMouseNextFrm = new System.Windows.Forms.CheckBox();
			this.chbx_useMouseGaze = new System.Windows.Forms.CheckBox();
			this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
			this.pnlRunMod = new System.Windows.Forms.GroupBox();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
			this.rbtn_ccttask = new MetroFramework.Controls.MetroRadioButton();
			this.rbtn_normalreward = new MetroFramework.Controls.MetroRadioButton();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.pnlPsycology = new System.Windows.Forms.GroupBox();
			this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
			this.pnlErr2 = new MetroFramework.Controls.MetroPanel();
			this.chkb_nmsSound = new System.Windows.Forms.CheckBox();
			this.chkb_nmsPrompt = new System.Windows.Forms.CheckBox();
			this.chbx_NMshowarrow = new System.Windows.Forms.CheckBox();
			this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
			this.pnlErr1 = new MetroFramework.Controls.MetroPanel();
			this.chbx_sound = new System.Windows.Forms.CheckBox();
			this.chbx_showarrow = new System.Windows.Forms.CheckBox();
			this.chBx_prompt = new System.Windows.Forms.CheckBox();
			this.refTimer = new System.Windows.Forms.Timer(this.components);
			this.TabControl_taskoperator.SuspendLayout();
			this.Tabtask.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbOper)).BeginInit();
			this.Tabsetting.SuspendLayout();
			this.pnlGen.SuspendLayout();
			this.pnlPsycophysics.SuspendLayout();
			this.pnlRunMod.SuspendLayout();
			this.metroPanel1.SuspendLayout();
			this.pnlPsycology.SuspendLayout();
			this.pnlErr2.SuspendLayout();
			this.pnlErr1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl_taskoperator
			// 
			this.TabControl_taskoperator.Controls.Add(this.Tabtask);
			this.TabControl_taskoperator.Controls.Add(this.Tabsetting);
			this.TabControl_taskoperator.Location = new System.Drawing.Point(-1, 4);
			this.TabControl_taskoperator.Name = "TabControl_taskoperator";
			this.TabControl_taskoperator.SelectedIndex = 1;
			this.TabControl_taskoperator.Size = new System.Drawing.Size(486, 534);
			this.TabControl_taskoperator.TabIndex = 5;
			this.TabControl_taskoperator.UseSelectable = true;
			// 
			// Tabtask
			// 
			this.Tabtask.BackColor = System.Drawing.Color.Maroon;
			this.Tabtask.Controls.Add(this.btStop);
			this.Tabtask.Controls.Add(this.btnStart);
			this.Tabtask.Controls.Add(this.txtbxTask);
			this.Tabtask.Controls.Add(this.txtSavPath);
			this.Tabtask.Controls.Add(this.pbOper);
			this.Tabtask.HorizontalScrollbarBarColor = true;
			this.Tabtask.HorizontalScrollbarHighlightOnWheel = false;
			this.Tabtask.HorizontalScrollbarSize = 10;
			this.Tabtask.Location = new System.Drawing.Point(4, 38);
			this.Tabtask.Name = "Tabtask";
			this.Tabtask.Size = new System.Drawing.Size(478, 492);
			this.Tabtask.TabIndex = 0;
			this.Tabtask.Text = "Task Selector";
			this.Tabtask.VerticalScrollbarBarColor = true;
			this.Tabtask.VerticalScrollbarHighlightOnWheel = false;
			this.Tabtask.VerticalScrollbarSize = 10;
			// 
			// btStop
			// 
			this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btStop.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btStop.Enabled = false;
			this.btStop.ForeColor = System.Drawing.Color.Black;
			this.btStop.Location = new System.Drawing.Point(276, 397);
			this.btStop.Name = "btStop";
			this.btStop.Size = new System.Drawing.Size(111, 28);
			this.btStop.Style = MetroFramework.MetroColorStyle.White;
			this.btStop.TabIndex = 9;
			this.btStop.Text = "Stop Task";
			this.btStop.UseCustomBackColor = true;
			this.btStop.UseCustomForeColor = true;
			this.btStop.UseSelectable = true;
			this.btStop.UseStyleColors = true;
			this.btStop.Click += new System.EventHandler(this.btStop_Click);
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnStart.Enabled = false;
			this.btnStart.ForeColor = System.Drawing.Color.Black;
			this.btnStart.Location = new System.Drawing.Point(85, 397);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(111, 28);
			this.btnStart.Style = MetroFramework.MetroColorStyle.White;
			this.btnStart.TabIndex = 7;
			this.btnStart.Text = "Run Task";
			this.btnStart.UseCustomBackColor = true;
			this.btnStart.UseCustomForeColor = true;
			this.btnStart.UseSelectable = true;
			this.btnStart.UseStyleColors = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
			// 
			// txtbxTask
			// 
			// 
			// 
			// 
			this.txtbxTask.CustomButton.Image = null;
			this.txtbxTask.CustomButton.Location = new System.Drawing.Point(450, 1);
			this.txtbxTask.CustomButton.Name = "";
			this.txtbxTask.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.txtbxTask.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.txtbxTask.CustomButton.TabIndex = 1;
			this.txtbxTask.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.txtbxTask.CustomButton.UseSelectable = true;
			this.txtbxTask.CustomButton.Visible = false;
			this.txtbxTask.Lines = new string[0];
			this.txtbxTask.Location = new System.Drawing.Point(3, 311);
			this.txtbxTask.MaxLength = 32767;
			this.txtbxTask.Name = "txtbxTask";
			this.txtbxTask.PasswordChar = '\0';
			this.txtbxTask.PromptText = "Select the Task";
			this.txtbxTask.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtbxTask.SelectedText = "";
			this.txtbxTask.SelectionLength = 0;
			this.txtbxTask.SelectionStart = 0;
			this.txtbxTask.ShortcutsEnabled = true;
			this.txtbxTask.Size = new System.Drawing.Size(472, 23);
			this.txtbxTask.TabIndex = 8;
			this.txtbxTask.UseSelectable = true;
			this.txtbxTask.WaterMark = "Select the Task";
			this.txtbxTask.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.txtbxTask.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.txtbxTask.Click += new System.EventHandler(this.txtbxTask_Click);
			// 
			// txtSavPath
			// 
			// 
			// 
			// 
			this.txtSavPath.CustomButton.Image = null;
			this.txtSavPath.CustomButton.Location = new System.Drawing.Point(450, 1);
			this.txtSavPath.CustomButton.Name = "";
			this.txtSavPath.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.txtSavPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.txtSavPath.CustomButton.TabIndex = 1;
			this.txtSavPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.txtSavPath.CustomButton.UseSelectable = true;
			this.txtSavPath.CustomButton.Visible = false;
			this.txtSavPath.Lines = new string[0];
			this.txtSavPath.Location = new System.Drawing.Point(2, 353);
			this.txtSavPath.MaxLength = 32767;
			this.txtSavPath.Name = "txtSavPath";
			this.txtSavPath.PasswordChar = '\0';
			this.txtSavPath.PromptText = "Path to save eye tracker data";
			this.txtSavPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSavPath.SelectedText = "";
			this.txtSavPath.SelectionLength = 0;
			this.txtSavPath.SelectionStart = 0;
			this.txtSavPath.ShortcutsEnabled = true;
			this.txtSavPath.Size = new System.Drawing.Size(472, 23);
			this.txtSavPath.TabIndex = 6;
			this.txtSavPath.UseSelectable = true;
			this.txtSavPath.WaterMark = "Path to save eye tracker data";
			this.txtSavPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.txtSavPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.txtSavPath.Click += new System.EventHandler(this.txtSavPath_Click);
			// 
			// pbOper
			// 
			this.pbOper.BackColor = System.Drawing.Color.Gray;
			this.pbOper.Location = new System.Drawing.Point(3, 16);
			this.pbOper.Name = "pbOper";
			this.pbOper.Size = new System.Drawing.Size(472, 273);
			this.pbOper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbOper.TabIndex = 5;
			this.pbOper.TabStop = false;
			// 
			// Tabsetting
			// 
			this.Tabsetting.Controls.Add(this.pnlGen);
			this.Tabsetting.Controls.Add(this.pnlRunMod);
			this.Tabsetting.Controls.Add(this.pnlPsycology);
			this.Tabsetting.HorizontalScrollbarBarColor = true;
			this.Tabsetting.HorizontalScrollbarHighlightOnWheel = false;
			this.Tabsetting.HorizontalScrollbarSize = 10;
			this.Tabsetting.Location = new System.Drawing.Point(4, 38);
			this.Tabsetting.Name = "Tabsetting";
			this.Tabsetting.Size = new System.Drawing.Size(478, 492);
			this.Tabsetting.Style = MetroFramework.MetroColorStyle.Black;
			this.Tabsetting.TabIndex = 1;
			this.Tabsetting.Text = "Task Setting";
			this.Tabsetting.VerticalScrollbarBarColor = true;
			this.Tabsetting.VerticalScrollbarHighlightOnWheel = false;
			this.Tabsetting.VerticalScrollbarSize = 10;
			// 
			// pnlGen
			// 
			this.pnlGen.BackColor = System.Drawing.Color.White;
			this.pnlGen.Controls.Add(this.metroLabel7);
			this.pnlGen.Controls.Add(this.pnlPsycophysics);
			this.pnlGen.Controls.Add(this.metroLabel8);
			this.pnlGen.Location = new System.Drawing.Point(3, 6);
			this.pnlGen.Name = "pnlGen";
			this.pnlGen.Size = new System.Drawing.Size(229, 154);
			this.pnlGen.TabIndex = 27;
			this.pnlGen.TabStop = false;
			// 
			// metroLabel7
			// 
			this.metroLabel7.AutoSize = true;
			this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel7.Location = new System.Drawing.Point(3, 12);
			this.metroLabel7.Name = "metroLabel7";
			this.metroLabel7.Size = new System.Drawing.Size(56, 19);
			this.metroLabel7.TabIndex = 17;
			this.metroLabel7.Text = "General";
			// 
			// pnlPsycophysics
			// 
			this.pnlPsycophysics.Controls.Add(this.label1);
			this.pnlPsycophysics.Controls.Add(this.txtNumGazeSmth);
			this.pnlPsycophysics.Controls.Add(this.chbuseMouseNextFrm);
			this.pnlPsycophysics.Controls.Add(this.chbx_useMouseGaze);
			this.pnlPsycophysics.HorizontalScrollbarBarColor = true;
			this.pnlPsycophysics.HorizontalScrollbarHighlightOnWheel = false;
			this.pnlPsycophysics.HorizontalScrollbarSize = 10;
			this.pnlPsycophysics.Location = new System.Drawing.Point(11, 40);
			this.pnlPsycophysics.Name = "pnlPsycophysics";
			this.pnlPsycophysics.Size = new System.Drawing.Size(205, 105);
			this.pnlPsycophysics.TabIndex = 16;
			this.pnlPsycophysics.VerticalScrollbarBarColor = true;
			this.pnlPsycophysics.VerticalScrollbarHighlightOnWheel = false;
			this.pnlPsycophysics.VerticalScrollbarSize = 10;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(54, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 22);
			this.label1.TabIndex = 16;
			this.label1.Text = "Points to smooth gaze";
			// 
			// txtNumGazeSmth
			// 
			this.txtNumGazeSmth.Location = new System.Drawing.Point(18, 70);
			this.txtNumGazeSmth.Name = "txtNumGazeSmth";
			this.txtNumGazeSmth.Size = new System.Drawing.Size(30, 22);
			this.txtNumGazeSmth.TabIndex = 16;
			// 
			// chbuseMouseNextFrm
			// 
			this.chbuseMouseNextFrm.AutoSize = true;
			this.chbuseMouseNextFrm.BackColor = System.Drawing.Color.White;
			this.chbuseMouseNextFrm.Location = new System.Drawing.Point(19, 41);
			this.chbuseMouseNextFrm.Name = "chbuseMouseNextFrm";
			this.chbuseMouseNextFrm.Size = new System.Drawing.Size(145, 17);
			this.chbuseMouseNextFrm.TabIndex = 10;
			this.chbuseMouseNextFrm.Text = "Click to show next frame";
			this.chbuseMouseNextFrm.UseVisualStyleBackColor = false;
			// 
			// chbx_useMouseGaze
			// 
			this.chbx_useMouseGaze.BackColor = System.Drawing.Color.White;
			this.chbx_useMouseGaze.Location = new System.Drawing.Point(18, 9);
			this.chbx_useMouseGaze.Name = "chbx_useMouseGaze";
			this.chbx_useMouseGaze.Size = new System.Drawing.Size(146, 31);
			this.chbx_useMouseGaze.TabIndex = 9;
			this.chbx_useMouseGaze.Text = "Use mouse to feed gaze ";
			this.chbx_useMouseGaze.UseVisualStyleBackColor = false;
			// 
			// metroLabel8
			// 
			this.metroLabel8.AutoSize = true;
			this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel8.Location = new System.Drawing.Point(3, 12);
			this.metroLabel8.Name = "metroLabel8";
			this.metroLabel8.Size = new System.Drawing.Size(208, 25);
			this.metroLabel8.TabIndex = 18;
			this.metroLabel8.Text = "____________________________";
			// 
			// pnlRunMod
			// 
			this.pnlRunMod.BackColor = System.Drawing.Color.White;
			this.pnlRunMod.Controls.Add(this.metroLabel1);
			this.pnlRunMod.Controls.Add(this.metroPanel1);
			this.pnlRunMod.Controls.Add(this.metroLabel2);
			this.pnlRunMod.Enabled = false;
			this.pnlRunMod.Location = new System.Drawing.Point(238, 6);
			this.pnlRunMod.Name = "pnlRunMod";
			this.pnlRunMod.Size = new System.Drawing.Size(237, 154);
			this.pnlRunMod.TabIndex = 26;
			this.pnlRunMod.TabStop = false;
			this.pnlRunMod.Visible = false;
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel1.Location = new System.Drawing.Point(7, 12);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(100, 19);
			this.metroLabel1.TabIndex = 6;
			this.metroLabel1.Text = "Running Mode";
			// 
			// metroPanel1
			// 
			this.metroPanel1.Controls.Add(this.rbtn_ccttask);
			this.metroPanel1.Controls.Add(this.rbtn_normalreward);
			this.metroPanel1.HorizontalScrollbarBarColor = true;
			this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel1.HorizontalScrollbarSize = 10;
			this.metroPanel1.Location = new System.Drawing.Point(15, 40);
			this.metroPanel1.Name = "metroPanel1";
			this.metroPanel1.Size = new System.Drawing.Size(200, 105);
			this.metroPanel1.TabIndex = 5;
			this.metroPanel1.VerticalScrollbarBarColor = true;
			this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel1.VerticalScrollbarSize = 10;
			// 
			// rbtn_ccttask
			// 
			this.rbtn_ccttask.AutoSize = true;
			this.rbtn_ccttask.Location = new System.Drawing.Point(18, 55);
			this.rbtn_ccttask.Name = "rbtn_ccttask";
			this.rbtn_ccttask.Size = new System.Drawing.Size(118, 15);
			this.rbtn_ccttask.TabIndex = 4;
			this.rbtn_ccttask.Text = "Recursive running";
			this.rbtn_ccttask.UseSelectable = true;
			// 
			// rbtn_normalreward
			// 
			this.rbtn_normalreward.AutoSize = true;
			this.rbtn_normalreward.Location = new System.Drawing.Point(18, 25);
			this.rbtn_normalreward.Name = "rbtn_normalreward";
			this.rbtn_normalreward.Size = new System.Drawing.Size(105, 15);
			this.rbtn_normalreward.TabIndex = 3;
			this.rbtn_normalreward.Text = "Normal reward ";
			this.rbtn_normalreward.UseSelectable = true;
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel2.Location = new System.Drawing.Point(7, 12);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(208, 25);
			this.metroLabel2.TabIndex = 7;
			this.metroLabel2.Text = "____________________________";
			// 
			// pnlPsycology
			// 
			this.pnlPsycology.BackColor = System.Drawing.Color.White;
			this.pnlPsycology.Controls.Add(this.metroLabel5);
			this.pnlPsycology.Controls.Add(this.pnlErr2);
			this.pnlPsycology.Controls.Add(this.metroLabel6);
			this.pnlPsycology.Controls.Add(this.metroLabel3);
			this.pnlPsycology.Controls.Add(this.metroLabel4);
			this.pnlPsycology.Controls.Add(this.pnlErr1);
			this.pnlPsycology.Enabled = false;
			this.pnlPsycology.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.pnlPsycology.Font = new System.Drawing.Font("Ebrima", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlPsycology.Location = new System.Drawing.Point(3, 162);
			this.pnlPsycology.Name = "pnlPsycology";
			this.pnlPsycology.Size = new System.Drawing.Size(229, 274);
			this.pnlPsycology.TabIndex = 25;
			this.pnlPsycology.TabStop = false;
			this.pnlPsycology.Visible = false;
			// 
			// metroLabel5
			// 
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel5.Location = new System.Drawing.Point(19, 158);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(85, 19);
			this.metroLabel5.TabIndex = 34;
			this.metroLabel5.Text = "Near_Misses";
			// 
			// pnlErr2
			// 
			this.pnlErr2.Controls.Add(this.chkb_nmsSound);
			this.pnlErr2.Controls.Add(this.chkb_nmsPrompt);
			this.pnlErr2.Controls.Add(this.chbx_NMshowarrow);
			this.pnlErr2.Font = new System.Drawing.Font("Ebrima", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlErr2.HorizontalScrollbarBarColor = true;
			this.pnlErr2.HorizontalScrollbarHighlightOnWheel = false;
			this.pnlErr2.HorizontalScrollbarSize = 10;
			this.pnlErr2.Location = new System.Drawing.Point(19, 186);
			this.pnlErr2.Name = "pnlErr2";
			this.pnlErr2.Size = new System.Drawing.Size(196, 75);
			this.pnlErr2.TabIndex = 33;
			this.pnlErr2.VerticalScrollbarBarColor = true;
			this.pnlErr2.VerticalScrollbarHighlightOnWheel = false;
			this.pnlErr2.VerticalScrollbarSize = 10;
			// 
			// chkb_nmsSound
			// 
			this.chkb_nmsSound.AutoSize = true;
			this.chkb_nmsSound.BackColor = System.Drawing.Color.White;
			this.chkb_nmsSound.Location = new System.Drawing.Point(18, 53);
			this.chkb_nmsSound.Name = "chkb_nmsSound";
			this.chkb_nmsSound.Size = new System.Drawing.Size(97, 19);
			this.chkb_nmsSound.TabIndex = 12;
			this.chkb_nmsSound.Text = "Enable sound";
			this.chkb_nmsSound.UseVisualStyleBackColor = false;
			// 
			// chkb_nmsPrompt
			// 
			this.chkb_nmsPrompt.AutoSize = true;
			this.chkb_nmsPrompt.BackColor = System.Drawing.Color.White;
			this.chkb_nmsPrompt.Location = new System.Drawing.Point(18, 7);
			this.chkb_nmsPrompt.Name = "chkb_nmsPrompt";
			this.chkb_nmsPrompt.Size = new System.Drawing.Size(103, 19);
			this.chkb_nmsPrompt.TabIndex = 11;
			this.chkb_nmsPrompt.Text = "Enable prompt";
			this.chkb_nmsPrompt.UseVisualStyleBackColor = false;
			// 
			// chbx_NMshowarrow
			// 
			this.chbx_NMshowarrow.AutoSize = true;
			this.chbx_NMshowarrow.BackColor = System.Drawing.Color.White;
			this.chbx_NMshowarrow.Location = new System.Drawing.Point(18, 30);
			this.chbx_NMshowarrow.Name = "chbx_NMshowarrow";
			this.chbx_NMshowarrow.Size = new System.Drawing.Size(88, 19);
			this.chbx_NMshowarrow.TabIndex = 8;
			this.chbx_NMshowarrow.Text = "Show arrow";
			this.chbx_NMshowarrow.UseVisualStyleBackColor = false;
			// 
			// metroLabel6
			// 
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel6.Location = new System.Drawing.Point(11, 158);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new System.Drawing.Size(187, 25);
			this.metroLabel6.TabIndex = 35;
			this.metroLabel6.Text = "_________________________";
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel3.Location = new System.Drawing.Point(10, 26);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(86, 19);
			this.metroLabel3.TabIndex = 31;
			this.metroLabel3.Text = "Error Setting";
			// 
			// metroLabel4
			// 
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel4.Location = new System.Drawing.Point(10, 26);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(187, 25);
			this.metroLabel4.TabIndex = 32;
			this.metroLabel4.Text = "_________________________";
			// 
			// pnlErr1
			// 
			this.pnlErr1.Controls.Add(this.chbx_sound);
			this.pnlErr1.Controls.Add(this.chbx_showarrow);
			this.pnlErr1.Controls.Add(this.chBx_prompt);
			this.pnlErr1.Font = new System.Drawing.Font("Ebrima", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlErr1.HorizontalScrollbarBarColor = true;
			this.pnlErr1.HorizontalScrollbarHighlightOnWheel = false;
			this.pnlErr1.HorizontalScrollbarSize = 10;
			this.pnlErr1.Location = new System.Drawing.Point(18, 54);
			this.pnlErr1.Name = "pnlErr1";
			this.pnlErr1.Size = new System.Drawing.Size(197, 91);
			this.pnlErr1.TabIndex = 30;
			this.pnlErr1.VerticalScrollbarBarColor = true;
			this.pnlErr1.VerticalScrollbarHighlightOnWheel = false;
			this.pnlErr1.VerticalScrollbarSize = 10;
			// 
			// chbx_sound
			// 
			this.chbx_sound.AutoSize = true;
			this.chbx_sound.BackColor = System.Drawing.Color.White;
			this.chbx_sound.Location = new System.Drawing.Point(18, 59);
			this.chbx_sound.Name = "chbx_sound";
			this.chbx_sound.Size = new System.Drawing.Size(97, 19);
			this.chbx_sound.TabIndex = 10;
			this.chbx_sound.Text = "Enable sound";
			this.chbx_sound.UseVisualStyleBackColor = false;
			// 
			// chbx_showarrow
			// 
			this.chbx_showarrow.AutoSize = true;
			this.chbx_showarrow.BackColor = System.Drawing.Color.White;
			this.chbx_showarrow.Location = new System.Drawing.Point(18, 36);
			this.chbx_showarrow.Name = "chbx_showarrow";
			this.chbx_showarrow.Size = new System.Drawing.Size(94, 19);
			this.chbx_showarrow.TabIndex = 9;
			this.chbx_showarrow.Text = "Enable arrow";
			this.chbx_showarrow.UseVisualStyleBackColor = false;
			// 
			// chBx_prompt
			// 
			this.chBx_prompt.AutoSize = true;
			this.chBx_prompt.BackColor = System.Drawing.Color.White;
			this.chBx_prompt.Location = new System.Drawing.Point(18, 13);
			this.chBx_prompt.Name = "chBx_prompt";
			this.chBx_prompt.Size = new System.Drawing.Size(103, 19);
			this.chBx_prompt.TabIndex = 8;
			this.chBx_prompt.Text = "Enable prompt";
			this.chBx_prompt.UseVisualStyleBackColor = false;
			// 
			// refTimer
			// 
			this.refTimer.Interval = 40;
			this.refTimer.Tick += new System.EventHandler(this.refTimer_Tick);
			// 
			// TaskOperator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 487);
			this.Controls.Add(this.TabControl_taskoperator);
			this.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "TaskOperator";
			this.Resizable = false;
			this.Text = "Task Runner Operator";
			this.Load += new System.EventHandler(this.TaskOperator_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TaskOperator_KeyDown);
			this.TabControl_taskoperator.ResumeLayout(false);
			this.Tabtask.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbOper)).EndInit();
			this.Tabsetting.ResumeLayout(false);
			this.pnlGen.ResumeLayout(false);
			this.pnlGen.PerformLayout();
			this.pnlPsycophysics.ResumeLayout(false);
			this.pnlPsycophysics.PerformLayout();
			this.pnlRunMod.ResumeLayout(false);
			this.pnlRunMod.PerformLayout();
			this.metroPanel1.ResumeLayout(false);
			this.metroPanel1.PerformLayout();
			this.pnlPsycology.ResumeLayout(false);
			this.pnlPsycology.PerformLayout();
			this.pnlErr2.ResumeLayout(false);
			this.pnlErr2.PerformLayout();
			this.pnlErr1.ResumeLayout(false);
			this.pnlErr1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroTabControl TabControl_taskoperator;
		private MetroFramework.Controls.MetroTabPage Tabtask;
		private MetroFramework.Controls.MetroButton btnStart;
		private MetroFramework.Controls.MetroTextBox txtbxTask;
		private MetroFramework.Controls.MetroTextBox txtSavPath;
		private System.Windows.Forms.PictureBox pbOper;
		private MetroFramework.Controls.MetroTabPage Tabsetting;
		private MetroFramework.Controls.MetroButton btStop;
		private System.Windows.Forms.Timer refTimer;
		private System.Windows.Forms.GroupBox pnlPsycology;
		private MetroFramework.Controls.MetroLabel metroLabel5;
		private MetroFramework.Controls.MetroPanel pnlErr2;
		public System.Windows.Forms.CheckBox chkb_nmsSound;
		public System.Windows.Forms.CheckBox chkb_nmsPrompt;
		public System.Windows.Forms.CheckBox chbx_NMshowarrow;
		private MetroFramework.Controls.MetroLabel metroLabel6;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private MetroFramework.Controls.MetroLabel metroLabel4;
		private MetroFramework.Controls.MetroPanel pnlErr1;
		public System.Windows.Forms.CheckBox chbx_sound;
		public System.Windows.Forms.CheckBox chbx_showarrow;
		public System.Windows.Forms.CheckBox chBx_prompt;
		private System.Windows.Forms.GroupBox pnlRunMod;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroPanel metroPanel1;
		public MetroFramework.Controls.MetroRadioButton rbtn_ccttask;
		public MetroFramework.Controls.MetroRadioButton rbtn_normalreward;
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private System.Windows.Forms.GroupBox pnlGen;
		private MetroFramework.Controls.MetroLabel metroLabel7;
		private MetroFramework.Controls.MetroPanel pnlPsycophysics;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumGazeSmth;
		public System.Windows.Forms.CheckBox chbuseMouseNextFrm;
		public System.Windows.Forms.CheckBox chbx_useMouseGaze;
		private MetroFramework.Controls.MetroLabel metroLabel8;
	}
}