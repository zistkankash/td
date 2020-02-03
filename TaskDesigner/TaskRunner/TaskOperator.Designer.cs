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
            this.refTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbOper = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtSavPath = new MetroFramework.Controls.MetroTextBox();
            this.txtbxTask = new MetroFramework.Controls.MetroTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.pnlErr1 = new MetroFramework.Controls.MetroPanel();
            this.chkb_nmsPrompt = new System.Windows.Forms.CheckBox();
            this.chbx_sound = new System.Windows.Forms.CheckBox();
            this.chbx_showarrow = new System.Windows.Forms.CheckBox();
            this.chBx_prompt = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.chbuseMouseNextFrm = new MetroFramework.Controls.MetroCheckBox();
            this.chbx_useMouseGaze = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericComPort = new System.Windows.Forms.NumericUpDown();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.rdbComPort = new MetroFramework.Controls.MetroRadioButton();
            this.rdbParAdress = new MetroFramework.Controls.MetroRadioButton();
            this.txtbxParAddress = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.cmbTriableScreen = new System.Windows.Forms.ComboBox();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.txtNumGazeSmth = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.pnlRunMode = new MetroFramework.Controls.MetroPanel();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOper)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlErr1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericComPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlRunMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // refTimer
            // 
            this.refTimer.Interval = 15;
            this.refTimer.Tick += new System.EventHandler(this.refTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 479);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(498, 477);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPageEx1_MouseDown);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.tabPage1.Controls.Add(this.btnHelp);
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pbOper);
            this.tabPage1.Controls.Add(this.btnStop);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.txtSavPath);
            this.tabPage1.Controls.Add(this.txtbxTask);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(490, 444);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Run Page";
            this.tabPage1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPageEx1_MouseDown);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Location = new System.Drawing.Point(311, 398);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(72, 34);
            this.btnHelp.TabIndex = 134;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.AliceBlue;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(409, 398);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 34);
            this.btnClose.TabIndex = 133;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 132;
            this.label2.Text = "Output Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 131;
            this.label1.Text = "Task Address:";
            // 
            // pbOper
            // 
            this.pbOper.BackColor = System.Drawing.Color.Gray;
            this.pbOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOper.Location = new System.Drawing.Point(10, 8);
            this.pbOper.Name = "pbOper";
            this.pbOper.Size = new System.Drawing.Size(472, 278);
            this.pbOper.TabIndex = 126;
            this.pbOper.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(211, 398);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(72, 34);
            this.btnStop.TabIndex = 129;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(113, 398);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 34);
            this.btnStart.TabIndex = 127;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // txtSavPath
            // 
            // 
            // 
            // 
            this.txtSavPath.CustomButton.Image = null;
            this.txtSavPath.CustomButton.Location = new System.Drawing.Point(339, 1);
            this.txtSavPath.CustomButton.Name = "";
            this.txtSavPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSavPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSavPath.CustomButton.TabIndex = 1;
            this.txtSavPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSavPath.CustomButton.UseSelectable = true;
            this.txtSavPath.CustomButton.Visible = false;
            this.txtSavPath.Lines = new string[0];
            this.txtSavPath.Location = new System.Drawing.Point(120, 356);
            this.txtSavPath.MaxLength = 32767;
            this.txtSavPath.Name = "txtSavPath";
            this.txtSavPath.PasswordChar = '\0';
            this.txtSavPath.PromptText = "Click to Select Output";
            this.txtSavPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSavPath.SelectedText = "";
            this.txtSavPath.SelectionLength = 0;
            this.txtSavPath.SelectionStart = 0;
            this.txtSavPath.ShortcutsEnabled = true;
            this.txtSavPath.Size = new System.Drawing.Size(361, 23);
            this.txtSavPath.TabIndex = 130;
            this.txtSavPath.TabStop = false;
            this.txtSavPath.UseCustomBackColor = true;
            this.txtSavPath.UseSelectable = true;
            this.txtSavPath.WaterMark = "Click to Select Output";
            this.txtSavPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSavPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSavPath.Click += new System.EventHandler(this.txtPath_Click);
            this.txtSavPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSavPath_KeyDown);
            // 
            // txtbxTask
            // 
            // 
            // 
            // 
            this.txtbxTask.CustomButton.Image = null;
            this.txtbxTask.CustomButton.Location = new System.Drawing.Point(339, 1);
            this.txtbxTask.CustomButton.Name = "";
            this.txtbxTask.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbxTask.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbxTask.CustomButton.TabIndex = 1;
            this.txtbxTask.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbxTask.CustomButton.UseSelectable = true;
            this.txtbxTask.CustomButton.Visible = false;
            this.txtbxTask.Lines = new string[0];
            this.txtbxTask.Location = new System.Drawing.Point(120, 311);
            this.txtbxTask.MaxLength = 32767;
            this.txtbxTask.Name = "txtbxTask";
            this.txtbxTask.PasswordChar = '\0';
            this.txtbxTask.PromptText = "Click to Select Task";
            this.txtbxTask.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbxTask.SelectedText = "";
            this.txtbxTask.SelectionLength = 0;
            this.txtbxTask.SelectionStart = 0;
            this.txtbxTask.ShortcutsEnabled = true;
            this.txtbxTask.Size = new System.Drawing.Size(361, 23);
            this.txtbxTask.TabIndex = 128;
            this.txtbxTask.UseCustomBackColor = true;
            this.txtbxTask.UseSelectable = true;
            this.txtbxTask.WaterMark = "Click to Select Task";
            this.txtbxTask.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbxTask.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbxTask.Click += new System.EventHandler(this.txtbxTask_Click);
            this.txtbxTask.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxTask_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(490, 444);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setting";
            this.tabPage2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPageEx4_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.metroLabel15);
            this.groupBox2.Controls.Add(this.metroLabel16);
            this.groupBox2.Controls.Add(this.pnlErr1);
            this.groupBox2.Enabled = false;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Ebrima", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(239, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 163);
            this.groupBox2.TabIndex = 126;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel15.Location = new System.Drawing.Point(11, 12);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(86, 19);
            this.metroLabel15.TabIndex = 31;
            this.metroLabel15.Text = "Error Setting";
            this.metroLabel15.UseCustomBackColor = true;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel16.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel16.Location = new System.Drawing.Point(7, 12);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(222, 25);
            this.metroLabel16.TabIndex = 32;
            this.metroLabel16.Text = "______________________________";
            this.metroLabel16.UseCustomBackColor = true;
            // 
            // pnlErr1
            // 
            this.pnlErr1.Controls.Add(this.chkb_nmsPrompt);
            this.pnlErr1.Controls.Add(this.chbx_sound);
            this.pnlErr1.Controls.Add(this.chbx_showarrow);
            this.pnlErr1.Controls.Add(this.chBx_prompt);
            this.pnlErr1.Font = new System.Drawing.Font("Ebrima", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlErr1.HorizontalScrollbarBarColor = true;
            this.pnlErr1.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlErr1.HorizontalScrollbarSize = 10;
            this.pnlErr1.Location = new System.Drawing.Point(0, 40);
            this.pnlErr1.Name = "pnlErr1";
            this.pnlErr1.Size = new System.Drawing.Size(197, 118);
            this.pnlErr1.TabIndex = 30;
            this.pnlErr1.UseCustomBackColor = true;
            this.pnlErr1.VerticalScrollbarBarColor = true;
            this.pnlErr1.VerticalScrollbarHighlightOnWheel = false;
            this.pnlErr1.VerticalScrollbarSize = 10;
            // 
            // chkb_nmsPrompt
            // 
            this.chkb_nmsPrompt.AutoSize = true;
            this.chkb_nmsPrompt.BackColor = System.Drawing.Color.Transparent;
            this.chkb_nmsPrompt.Location = new System.Drawing.Point(15, 33);
            this.chkb_nmsPrompt.Name = "chkb_nmsPrompt";
            this.chkb_nmsPrompt.Size = new System.Drawing.Size(169, 19);
            this.chkb_nmsPrompt.TabIndex = 12;
            this.chkb_nmsPrompt.Text = "Enable Near Misses Prompt";
            this.chkb_nmsPrompt.UseVisualStyleBackColor = false;
            // 
            // chbx_sound
            // 
            this.chbx_sound.AutoSize = true;
            this.chbx_sound.BackColor = System.Drawing.Color.Transparent;
            this.chbx_sound.Location = new System.Drawing.Point(15, 82);
            this.chbx_sound.Name = "chbx_sound";
            this.chbx_sound.Size = new System.Drawing.Size(98, 19);
            this.chbx_sound.TabIndex = 10;
            this.chbx_sound.Text = "Enable Sound";
            this.chbx_sound.UseVisualStyleBackColor = false;
            // 
            // chbx_showarrow
            // 
            this.chbx_showarrow.AutoSize = true;
            this.chbx_showarrow.BackColor = System.Drawing.Color.Transparent;
            this.chbx_showarrow.Location = new System.Drawing.Point(15, 57);
            this.chbx_showarrow.Name = "chbx_showarrow";
            this.chbx_showarrow.Size = new System.Drawing.Size(96, 19);
            this.chbx_showarrow.TabIndex = 9;
            this.chbx_showarrow.Text = "Enable Arrow";
            this.chbx_showarrow.UseVisualStyleBackColor = false;
            // 
            // chBx_prompt
            // 
            this.chBx_prompt.AutoSize = true;
            this.chBx_prompt.BackColor = System.Drawing.Color.Transparent;
            this.chBx_prompt.Location = new System.Drawing.Point(15, 9);
            this.chBx_prompt.Name = "chBx_prompt";
            this.chBx_prompt.Size = new System.Drawing.Size(103, 19);
            this.chBx_prompt.TabIndex = 8;
            this.chBx_prompt.Text = "Enable Prompt";
            this.chBx_prompt.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.metroLabel17);
            this.groupBox3.Controls.Add(this.metroPanel1);
            this.groupBox3.Controls.Add(this.metroLabel18);
            this.groupBox3.Location = new System.Drawing.Point(248, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 173);
            this.groupBox3.TabIndex = 128;
            this.groupBox3.TabStop = false;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel17.Location = new System.Drawing.Point(7, 12);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(98, 19);
            this.metroLabel17.TabIndex = 17;
            this.metroLabel17.Text = "Data Acuistion";
            this.metroLabel17.UseCustomBackColor = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.chbuseMouseNextFrm);
            this.metroPanel1.Controls.Add(this.chbx_useMouseGaze);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(15, 40);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(205, 73);
            this.metroPanel1.TabIndex = 16;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // chbuseMouseNextFrm
            // 
            this.chbuseMouseNextFrm.AutoSize = true;
            this.chbuseMouseNextFrm.Location = new System.Drawing.Point(4, 42);
            this.chbuseMouseNextFrm.Name = "chbuseMouseNextFrm";
            this.chbuseMouseNextFrm.Size = new System.Drawing.Size(199, 15);
            this.chbuseMouseNextFrm.TabIndex = 19;
            this.chbuseMouseNextFrm.Text = "Use mouse click to go next frame";
            this.chbuseMouseNextFrm.UseCustomBackColor = true;
            this.chbuseMouseNextFrm.UseSelectable = true;
            // 
            // chbx_useMouseGaze
            // 
            this.chbx_useMouseGaze.AutoSize = true;
            this.chbx_useMouseGaze.Location = new System.Drawing.Point(4, 12);
            this.chbx_useMouseGaze.Name = "chbx_useMouseGaze";
            this.chbx_useMouseGaze.Size = new System.Drawing.Size(151, 15);
            this.chbx_useMouseGaze.TabIndex = 19;
            this.chbx_useMouseGaze.Text = "Use mouse to feed gaze ";
            this.chbx_useMouseGaze.UseCustomBackColor = true;
            this.chbx_useMouseGaze.UseSelectable = true;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel18.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel18.Location = new System.Drawing.Point(3, 12);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(222, 25);
            this.metroLabel18.TabIndex = 18;
            this.metroLabel18.Text = "______________________________";
            this.metroLabel18.UseCustomBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.numericComPort);
            this.groupBox4.Controls.Add(this.metroLabel3);
            this.groupBox4.Controls.Add(this.metroLabel2);
            this.groupBox4.Controls.Add(this.metroLabel1);
            this.groupBox4.Controls.Add(this.rdbComPort);
            this.groupBox4.Controls.Add(this.rdbParAdress);
            this.groupBox4.Controls.Add(this.txtbxParAddress);
            this.groupBox4.Controls.Add(this.metroLabel19);
            this.groupBox4.Controls.Add(this.cmbTriableScreen);
            this.groupBox4.Controls.Add(this.metroLabel20);
            this.groupBox4.Controls.Add(this.metroLabel21);
            this.groupBox4.Controls.Add(this.metroLabel22);
            this.groupBox4.Controls.Add(this.txtNumGazeSmth);
            this.groupBox4.Location = new System.Drawing.Point(4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 266);
            this.groupBox4.TabIndex = 129;
            this.groupBox4.TabStop = false;
            // 
            // numericComPort
            // 
            this.numericComPort.Enabled = false;
            this.numericComPort.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericComPort.Location = new System.Drawing.Point(183, 217);
            this.numericComPort.Name = "numericComPort";
            this.numericComPort.Size = new System.Drawing.Size(32, 25);
            this.numericComPort.TabIndex = 130;
            this.numericComPort.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(147, 221);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(35, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 134;
            this.metroLabel3.Text = "COM";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(3, 150);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(90, 19);
            this.metroLabel2.TabIndex = 132;
            this.metroLabel2.Text = "Trigger Setup";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(0, 150);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(222, 25);
            this.metroLabel1.TabIndex = 131;
            this.metroLabel1.Text = "______________________________";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // rdbComPort
            // 
            this.rdbComPort.AutoSize = true;
            this.rdbComPort.Location = new System.Drawing.Point(7, 221);
            this.rdbComPort.Name = "rdbComPort";
            this.rdbComPort.Size = new System.Drawing.Size(98, 15);
            this.rdbComPort.TabIndex = 130;
            this.rdbComPort.Text = "Use COM Port";
            this.rdbComPort.UseCustomBackColor = true;
            this.rdbComPort.UseSelectable = true;
            this.rdbComPort.CheckedChanged += new System.EventHandler(this.rdbComPort_CheckedChanged);
            // 
            // rdbParAdress
            // 
            this.rdbParAdress.AutoSize = true;
            this.rdbParAdress.Location = new System.Drawing.Point(7, 186);
            this.rdbParAdress.Name = "rdbParAdress";
            this.rdbParAdress.Size = new System.Drawing.Size(108, 15);
            this.rdbParAdress.TabIndex = 130;
            this.rdbParAdress.Text = "Use Parallel Port";
            this.rdbParAdress.UseCustomBackColor = true;
            this.rdbParAdress.UseSelectable = true;
            this.rdbParAdress.CheckedChanged += new System.EventHandler(this.rdbParAdress_CheckedChanged);
            // 
            // txtbxParAddress
            // 
            // 
            // 
            // 
            this.txtbxParAddress.CustomButton.Image = null;
            this.txtbxParAddress.CustomButton.Location = new System.Drawing.Point(21, 1);
            this.txtbxParAddress.CustomButton.Name = "";
            this.txtbxParAddress.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbxParAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbxParAddress.CustomButton.TabIndex = 1;
            this.txtbxParAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbxParAddress.CustomButton.UseSelectable = true;
            this.txtbxParAddress.CustomButton.Visible = false;
            this.txtbxParAddress.Enabled = false;
            this.txtbxParAddress.Lines = new string[] {
        "DFF0"};
            this.txtbxParAddress.Location = new System.Drawing.Point(172, 183);
            this.txtbxParAddress.MaxLength = 32767;
            this.txtbxParAddress.Name = "txtbxParAddress";
            this.txtbxParAddress.PasswordChar = '\0';
            this.txtbxParAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbxParAddress.SelectedText = "";
            this.txtbxParAddress.SelectionLength = 0;
            this.txtbxParAddress.SelectionStart = 0;
            this.txtbxParAddress.ShortcutsEnabled = true;
            this.txtbxParAddress.Size = new System.Drawing.Size(43, 23);
            this.txtbxParAddress.TabIndex = 33;
            this.txtbxParAddress.Text = "DFF0";
            this.txtbxParAddress.UseSelectable = true;
            this.txtbxParAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbxParAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel19.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel19.Location = new System.Drawing.Point(7, 45);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(82, 15);
            this.metroLabel19.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel19.TabIndex = 84;
            this.metroLabel19.Text = "Triable Screen:";
            this.metroLabel19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.metroLabel19.UseCustomBackColor = true;
            // 
            // cmbTriableScreen
            // 
            this.cmbTriableScreen.Font = new System.Drawing.Font("Marlett", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(2)), true);
            this.cmbTriableScreen.FormattingEnabled = true;
            this.cmbTriableScreen.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbTriableScreen.Location = new System.Drawing.Point(172, 40);
            this.cmbTriableScreen.Name = "cmbTriableScreen";
            this.cmbTriableScreen.Size = new System.Drawing.Size(43, 21);
            this.cmbTriableScreen.TabIndex = 83;
            this.cmbTriableScreen.SelectedIndexChanged += new System.EventHandler(this.cmbTriableScreen_SelectedIndexChanged);
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel20.Location = new System.Drawing.Point(3, 12);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(49, 19);
            this.metroLabel20.TabIndex = 17;
            this.metroLabel20.Text = "Screen";
            this.metroLabel20.UseCustomBackColor = true;
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel21.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel21.Location = new System.Drawing.Point(7, 76);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(125, 15);
            this.metroLabel21.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel21.TabIndex = 85;
            this.metroLabel21.Text = "Points to smooth gaze";
            this.metroLabel21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.metroLabel21.UseCustomBackColor = true;
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel22.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel22.Location = new System.Drawing.Point(3, 12);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(222, 25);
            this.metroLabel22.TabIndex = 18;
            this.metroLabel22.Text = "______________________________";
            this.metroLabel22.UseCustomBackColor = true;
            // 
            // txtNumGazeSmth
            // 
            this.txtNumGazeSmth.Location = new System.Drawing.Point(172, 71);
            this.txtNumGazeSmth.Name = "txtNumGazeSmth";
            this.txtNumGazeSmth.Size = new System.Drawing.Size(43, 22);
            this.txtNumGazeSmth.TabIndex = 16;
            this.txtNumGazeSmth.Text = "5";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.metroLabel23);
            this.groupBox1.Controls.Add(this.pnlRunMode);
            this.groupBox1.Controls.Add(this.metroLabel24);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(4, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 141);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // metroLabel23
            // 
            this.metroLabel23.AutoSize = true;
            this.metroLabel23.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel23.Location = new System.Drawing.Point(7, 12);
            this.metroLabel23.Name = "metroLabel23";
            this.metroLabel23.Size = new System.Drawing.Size(100, 19);
            this.metroLabel23.TabIndex = 6;
            this.metroLabel23.Text = "Running Mode";
            this.metroLabel23.UseCustomBackColor = true;
            // 
            // pnlRunMode
            // 
            this.pnlRunMode.Controls.Add(this.metroRadioButton1);
            this.pnlRunMode.Controls.Add(this.metroRadioButton2);
            this.pnlRunMode.HorizontalScrollbarBarColor = true;
            this.pnlRunMode.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlRunMode.HorizontalScrollbarSize = 10;
            this.pnlRunMode.Location = new System.Drawing.Point(11, 40);
            this.pnlRunMode.Name = "pnlRunMode";
            this.pnlRunMode.Size = new System.Drawing.Size(200, 123);
            this.pnlRunMode.TabIndex = 5;
            this.pnlRunMode.UseCustomBackColor = true;
            this.pnlRunMode.VerticalScrollbarBarColor = true;
            this.pnlRunMode.VerticalScrollbarHighlightOnWheel = false;
            this.pnlRunMode.VerticalScrollbarSize = 10;
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Location = new System.Drawing.Point(8, 61);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(118, 15);
            this.metroRadioButton1.TabIndex = 4;
            this.metroRadioButton1.Text = "Recursive running";
            this.metroRadioButton1.UseCustomBackColor = true;
            this.metroRadioButton1.UseSelectable = true;
            // 
            // metroRadioButton2
            // 
            this.metroRadioButton2.AutoSize = true;
            this.metroRadioButton2.Location = new System.Drawing.Point(8, 31);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(109, 15);
            this.metroRadioButton2.TabIndex = 3;
            this.metroRadioButton2.Text = "Normal Forward";
            this.metroRadioButton2.UseCustomBackColor = true;
            this.metroRadioButton2.UseSelectable = true;
            // 
            // metroLabel24
            // 
            this.metroLabel24.AutoSize = true;
            this.metroLabel24.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel24.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel24.Location = new System.Drawing.Point(7, 12);
            this.metroLabel24.Name = "metroLabel24";
            this.metroLabel24.Size = new System.Drawing.Size(222, 25);
            this.metroLabel24.TabIndex = 7;
            this.metroLabel24.Text = "______________________________";
            this.metroLabel24.UseCustomBackColor = true;
            // 
            // TaskOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 479);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TaskOperator";
            this.Text = "Task Runner Operator";
            this.Load += new System.EventHandler(this.TaskOperator_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TaskOperator_KeyDown);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOper)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlErr1.ResumeLayout(false);
            this.pnlErr1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericComPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlRunMode.ResumeLayout(false);
            this.pnlRunMode.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer refTimer;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pbOper;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnStart;
		public MetroFramework.Controls.MetroTextBox txtSavPath;
		private MetroFramework.Controls.MetroTextBox txtbxTask;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox2;
		private MetroFramework.Controls.MetroLabel metroLabel15;
		private MetroFramework.Controls.MetroLabel metroLabel16;
		private MetroFramework.Controls.MetroPanel pnlErr1;
		public System.Windows.Forms.CheckBox chkb_nmsPrompt;
		public System.Windows.Forms.CheckBox chbx_sound;
		public System.Windows.Forms.CheckBox chbx_showarrow;
		public System.Windows.Forms.CheckBox chBx_prompt;
		private System.Windows.Forms.GroupBox groupBox3;
		private MetroFramework.Controls.MetroLabel metroLabel17;
		private MetroFramework.Controls.MetroPanel metroPanel1;
		private MetroFramework.Controls.MetroCheckBox chbuseMouseNextFrm;
		private MetroFramework.Controls.MetroCheckBox chbx_useMouseGaze;
		private MetroFramework.Controls.MetroLabel metroLabel18;
		private System.Windows.Forms.GroupBox groupBox4;
		private MetroFramework.Controls.MetroTextBox txtbxParAddress;
		private MetroFramework.Controls.MetroLabel metroLabel19;
		private System.Windows.Forms.ComboBox cmbTriableScreen;
		private MetroFramework.Controls.MetroLabel metroLabel20;
		private MetroFramework.Controls.MetroLabel metroLabel21;
		private MetroFramework.Controls.MetroLabel metroLabel22;
		private System.Windows.Forms.TextBox txtNumGazeSmth;
		private System.Windows.Forms.GroupBox groupBox1;
		private MetroFramework.Controls.MetroLabel metroLabel23;
		private MetroFramework.Controls.MetroPanel pnlRunMode;
		public MetroFramework.Controls.MetroRadioButton metroRadioButton1;
		public MetroFramework.Controls.MetroRadioButton metroRadioButton2;
		private MetroFramework.Controls.MetroLabel metroLabel24;
        private System.Windows.Forms.NumericUpDown numericComPort;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroRadioButton rdbComPort;
        private MetroFramework.Controls.MetroRadioButton rdbParAdress;
    }
}