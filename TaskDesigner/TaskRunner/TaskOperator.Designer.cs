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
            this.pnl3 = new System.Windows.Forms.GroupBox();
            this.numericComPort = new System.Windows.Forms.NumericUpDown();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.rdbComPort = new MetroFramework.Controls.MetroRadioButton();
            this.rdbParAdress = new MetroFramework.Controls.MetroRadioButton();
            this.txtbxParAddress = new MetroFramework.Controls.MetroTextBox();
            this.pnl5 = new System.Windows.Forms.GroupBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.pnlErr1 = new MetroFramework.Controls.MetroPanel();
            this.chkbxArrwHintGoals = new MetroFramework.Controls.MetroCheckBox();
            this.chkbxGoalsPrompt = new MetroFramework.Controls.MetroCheckBox();
            this.chkbxGoalSound = new MetroFramework.Controls.MetroCheckBox();
            this.chkbxMisSound = new MetroFramework.Controls.MetroCheckBox();
            this.chbxNearMisHintArrow = new MetroFramework.Controls.MetroCheckBox();
            this.chkbNearMisPrompt = new MetroFramework.Controls.MetroCheckBox();
            this.chkbxMissesPrompt = new MetroFramework.Controls.MetroCheckBox();
            this.pnl2 = new System.Windows.Forms.GroupBox();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.chbuseMouseNextFrm = new MetroFramework.Controls.MetroCheckBox();
            this.chbx_useMouseGaze = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.pnl1 = new System.Windows.Forms.GroupBox();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.cmbTriableScreen = new System.Windows.Forms.ComboBox();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.txtNumGazeSmth = new System.Windows.Forms.TextBox();
            this.pnl4 = new System.Windows.Forms.GroupBox();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.pnlRunMode = new MetroFramework.Controls.MetroPanel();
            this.rdbRecursRun = new MetroFramework.Controls.MetroRadioButton();
            this.rdbNormFormRun = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOper)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.pnl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericComPort)).BeginInit();
            this.pnl5.SuspendLayout();
            this.pnlErr1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.pnl4.SuspendLayout();
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
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
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.btnHelp.FlatAppearance.BorderSize = 2;
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
            this.btnClose.FlatAppearance.BorderSize = 2;
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
            this.label2.Location = new System.Drawing.Point(5, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 132;
            this.label2.Text = "Output Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 131;
            this.label1.Text = "Task Address:";
            // 
            // pbOper
            // 
            this.pbOper.BackColor = System.Drawing.Color.Gray;
            this.pbOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOper.Location = new System.Drawing.Point(8, 8);
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
            this.btnStop.FlatAppearance.BorderSize = 2;
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
            this.tabPage2.Controls.Add(this.pnl3);
            this.tabPage2.Controls.Add(this.pnl5);
            this.tabPage2.Controls.Add(this.pnl2);
            this.tabPage2.Controls.Add(this.pnl1);
            this.tabPage2.Controls.Add(this.pnl4);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(490, 444);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setting";
            this.tabPage2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPageEx4_MouseDown);
            // 
            // pnl3
            // 
            this.pnl3.BackColor = System.Drawing.Color.Transparent;
            this.pnl3.Controls.Add(this.numericComPort);
            this.pnl3.Controls.Add(this.metroLabel3);
            this.pnl3.Controls.Add(this.metroLabel2);
            this.pnl3.Controls.Add(this.metroLabel1);
            this.pnl3.Controls.Add(this.rdbComPort);
            this.pnl3.Controls.Add(this.rdbParAdress);
            this.pnl3.Controls.Add(this.txtbxParAddress);
            this.pnl3.Location = new System.Drawing.Point(4, 124);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(238, 122);
            this.pnl3.TabIndex = 130;
            this.pnl3.TabStop = false;
            // 
            // numericComPort
            // 
            this.numericComPort.Enabled = false;
            this.numericComPort.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericComPort.Location = new System.Drawing.Point(187, 81);
            this.numericComPort.Name = "numericComPort";
            this.numericComPort.Size = new System.Drawing.Size(43, 25);
            this.numericComPort.TabIndex = 136;
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
            this.metroLabel3.Location = new System.Drawing.Point(146, 85);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(35, 15);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 141;
            this.metroLabel3.Text = "COM";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(7, 15);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(140, 19);
            this.metroLabel2.TabIndex = 140;
            this.metroLabel2.Text = "Output Trigger Setup";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(8, 15);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(222, 25);
            this.metroLabel1.TabIndex = 139;
            this.metroLabel1.Text = "______________________________";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // rdbComPort
            // 
            this.rdbComPort.AutoSize = true;
            this.rdbComPort.Location = new System.Drawing.Point(16, 85);
            this.rdbComPort.Name = "rdbComPort";
            this.rdbComPort.Size = new System.Drawing.Size(98, 15);
            this.rdbComPort.TabIndex = 137;
            this.rdbComPort.Text = "Use COM Port";
            this.rdbComPort.UseCustomBackColor = true;
            this.rdbComPort.UseSelectable = true;
            // 
            // rdbParAdress
            // 
            this.rdbParAdress.AutoSize = true;
            this.rdbParAdress.Location = new System.Drawing.Point(15, 51);
            this.rdbParAdress.Name = "rdbParAdress";
            this.rdbParAdress.Size = new System.Drawing.Size(108, 15);
            this.rdbParAdress.TabIndex = 138;
            this.rdbParAdress.Text = "Use Parallel Port";
            this.rdbParAdress.UseCustomBackColor = true;
            this.rdbParAdress.UseSelectable = true;
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
        "DFF8"};
            this.txtbxParAddress.Location = new System.Drawing.Point(189, 44);
            this.txtbxParAddress.MaxLength = 32767;
            this.txtbxParAddress.Name = "txtbxParAddress";
            this.txtbxParAddress.PasswordChar = '\0';
            this.txtbxParAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbxParAddress.SelectedText = "";
            this.txtbxParAddress.SelectionLength = 0;
            this.txtbxParAddress.SelectionStart = 0;
            this.txtbxParAddress.ShortcutsEnabled = true;
            this.txtbxParAddress.Size = new System.Drawing.Size(43, 23);
            this.txtbxParAddress.TabIndex = 135;
            this.txtbxParAddress.Text = "DFF8";
            this.txtbxParAddress.UseSelectable = true;
            this.txtbxParAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbxParAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pnl5
            // 
            this.pnl5.BackColor = System.Drawing.Color.Transparent;
            this.pnl5.Controls.Add(this.metroLabel15);
            this.pnl5.Controls.Add(this.metroLabel16);
            this.pnl5.Controls.Add(this.pnlErr1);
            this.pnl5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pnl5.Font = new System.Drawing.Font("Ebrima", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl5.Location = new System.Drawing.Point(4, 246);
            this.pnl5.Name = "pnl5";
            this.pnl5.Size = new System.Drawing.Size(482, 190);
            this.pnl5.TabIndex = 126;
            this.pnl5.TabStop = false;
            this.pnl5.Visible = false;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel15.Location = new System.Drawing.Point(8, 12);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(204, 19);
            this.metroLabel15.TabIndex = 31;
            this.metroLabel15.Text = "Psycology Tasks Prompt Setting";
            this.metroLabel15.UseCustomBackColor = true;
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel16.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel16.Location = new System.Drawing.Point(7, 12);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(467, 25);
            this.metroLabel16.TabIndex = 32;
            this.metroLabel16.Text = "_________________________________________________________________";
            this.metroLabel16.UseCustomBackColor = true;
            // 
            // pnlErr1
            // 
            this.pnlErr1.Controls.Add(this.chkbxArrwHintGoals);
            this.pnlErr1.Controls.Add(this.chkbxGoalsPrompt);
            this.pnlErr1.Controls.Add(this.chkbxGoalSound);
            this.pnlErr1.Controls.Add(this.chkbxMisSound);
            this.pnlErr1.Controls.Add(this.chbxNearMisHintArrow);
            this.pnlErr1.Controls.Add(this.chkbNearMisPrompt);
            this.pnlErr1.Controls.Add(this.chkbxMissesPrompt);
            this.pnlErr1.Font = new System.Drawing.Font("Ebrima", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlErr1.HorizontalScrollbarBarColor = true;
            this.pnlErr1.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlErr1.HorizontalScrollbarSize = 10;
            this.pnlErr1.Location = new System.Drawing.Point(0, 40);
            this.pnlErr1.Name = "pnlErr1";
            this.pnlErr1.Size = new System.Drawing.Size(473, 144);
            this.pnlErr1.TabIndex = 30;
            this.pnlErr1.UseCustomBackColor = true;
            this.pnlErr1.VerticalScrollbarBarColor = true;
            this.pnlErr1.VerticalScrollbarHighlightOnWheel = false;
            this.pnlErr1.VerticalScrollbarSize = 10;
            // 
            // chkbxArrwHintGoals
            // 
            this.chkbxArrwHintGoals.AutoSize = true;
            this.chkbxArrwHintGoals.BackColor = System.Drawing.Color.Transparent;
            this.chkbxArrwHintGoals.Location = new System.Drawing.Point(15, 49);
            this.chkbxArrwHintGoals.Name = "chkbxArrwHintGoals";
            this.chkbxArrwHintGoals.Size = new System.Drawing.Size(152, 15);
            this.chkbxArrwHintGoals.TabIndex = 140;
            this.chkbxArrwHintGoals.Text = "Draw Arrow Hint to Goal";
            this.chkbxArrwHintGoals.UseCustomBackColor = true;
            this.chkbxArrwHintGoals.UseSelectable = true;
            // 
            // chkbxGoalsPrompt
            // 
            this.chkbxGoalsPrompt.AutoSize = true;
            this.chkbxGoalsPrompt.BackColor = System.Drawing.Color.Transparent;
            this.chkbxGoalsPrompt.Checked = true;
            this.chkbxGoalsPrompt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxGoalsPrompt.Location = new System.Drawing.Point(15, 15);
            this.chkbxGoalsPrompt.Name = "chkbxGoalsPrompt";
            this.chkbxGoalsPrompt.Size = new System.Drawing.Size(95, 15);
            this.chkbxGoalsPrompt.TabIndex = 139;
            this.chkbxGoalsPrompt.Text = "Goals Prompt";
            this.chkbxGoalsPrompt.UseCustomBackColor = true;
            this.chkbxGoalsPrompt.UseSelectable = true;
            // 
            // chkbxGoalSound
            // 
            this.chkbxGoalSound.AutoSize = true;
            this.chkbxGoalSound.BackColor = System.Drawing.Color.Transparent;
            this.chkbxGoalSound.Checked = true;
            this.chkbxGoalSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxGoalSound.Location = new System.Drawing.Point(15, 83);
            this.chkbxGoalSound.Name = "chkbxGoalSound";
            this.chkbxGoalSound.Size = new System.Drawing.Size(131, 15);
            this.chkbxGoalSound.TabIndex = 138;
            this.chkbxGoalSound.Text = "Play Sound on Goals";
            this.chkbxGoalSound.UseCustomBackColor = true;
            this.chkbxGoalSound.UseSelectable = true;
            // 
            // chkbxMisSound
            // 
            this.chkbxMisSound.AutoSize = true;
            this.chkbxMisSound.BackColor = System.Drawing.Color.Transparent;
            this.chkbxMisSound.Checked = true;
            this.chkbxMisSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxMisSound.Location = new System.Drawing.Point(15, 117);
            this.chkbxMisSound.Name = "chkbxMisSound";
            this.chkbxMisSound.Size = new System.Drawing.Size(137, 15);
            this.chkbxMisSound.TabIndex = 137;
            this.chkbxMisSound.Text = "Play Sound on Misses";
            this.chkbxMisSound.UseCustomBackColor = true;
            this.chkbxMisSound.UseSelectable = true;
            // 
            // chbxNearMisHintArrow
            // 
            this.chbxNearMisHintArrow.AutoSize = true;
            this.chbxNearMisHintArrow.BackColor = System.Drawing.Color.Transparent;
            this.chbxNearMisHintArrow.Location = new System.Drawing.Point(253, 83);
            this.chbxNearMisHintArrow.Name = "chbxNearMisHintArrow";
            this.chbxNearMisHintArrow.Size = new System.Drawing.Size(209, 15);
            this.chbxNearMisHintArrow.TabIndex = 136;
            this.chbxNearMisHintArrow.Text = "Draw Arrow to Goal on Near Misses";
            this.chbxNearMisHintArrow.UseCustomBackColor = true;
            this.chbxNearMisHintArrow.UseSelectable = true;
            // 
            // chkbNearMisPrompt
            // 
            this.chkbNearMisPrompt.AutoSize = true;
            this.chkbNearMisPrompt.BackColor = System.Drawing.Color.Transparent;
            this.chkbNearMisPrompt.Location = new System.Drawing.Point(253, 49);
            this.chkbNearMisPrompt.Name = "chkbNearMisPrompt";
            this.chkbNearMisPrompt.Size = new System.Drawing.Size(129, 15);
            this.chkbNearMisPrompt.TabIndex = 135;
            this.chkbNearMisPrompt.Text = "Near Misses Prompt";
            this.chkbNearMisPrompt.UseCustomBackColor = true;
            this.chkbNearMisPrompt.UseSelectable = true;
            // 
            // chkbxMissesPrompt
            // 
            this.chkbxMissesPrompt.AutoSize = true;
            this.chkbxMissesPrompt.BackColor = System.Drawing.Color.Transparent;
            this.chkbxMissesPrompt.Checked = true;
            this.chkbxMissesPrompt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxMissesPrompt.Location = new System.Drawing.Point(253, 15);
            this.chkbxMissesPrompt.Name = "chkbxMissesPrompt";
            this.chkbxMissesPrompt.Size = new System.Drawing.Size(101, 15);
            this.chkbxMissesPrompt.TabIndex = 134;
            this.chkbxMissesPrompt.Text = "Misses Prompt";
            this.chkbxMissesPrompt.UseCustomBackColor = true;
            this.chkbxMissesPrompt.UseSelectable = true;
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.Color.Transparent;
            this.pnl2.Controls.Add(this.metroLabel17);
            this.pnl2.Controls.Add(this.metroPanel1);
            this.pnl2.Controls.Add(this.metroLabel18);
            this.pnl2.Location = new System.Drawing.Point(248, 3);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(238, 121);
            this.pnl2.TabIndex = 128;
            this.pnl2.TabStop = false;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel17.Location = new System.Drawing.Point(4, 12);
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
            this.metroPanel1.Location = new System.Drawing.Point(7, 40);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(225, 75);
            this.metroPanel1.TabIndex = 16;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // chbuseMouseNextFrm
            // 
            this.chbuseMouseNextFrm.AutoSize = true;
            this.chbuseMouseNextFrm.Location = new System.Drawing.Point(10, 43);
            this.chbuseMouseNextFrm.Name = "chbuseMouseNextFrm";
            this.chbuseMouseNextFrm.Size = new System.Drawing.Size(219, 15);
            this.chbuseMouseNextFrm.TabIndex = 19;
            this.chbuseMouseNextFrm.Text = "Use Mouse Click to Go to Next Frame";
            this.chbuseMouseNextFrm.UseCustomBackColor = true;
            this.chbuseMouseNextFrm.UseSelectable = true;
            // 
            // chbx_useMouseGaze
            // 
            this.chbx_useMouseGaze.AutoSize = true;
            this.chbx_useMouseGaze.Location = new System.Drawing.Point(10, 9);
            this.chbx_useMouseGaze.Name = "chbx_useMouseGaze";
            this.chbx_useMouseGaze.Size = new System.Drawing.Size(208, 15);
            this.chbx_useMouseGaze.TabIndex = 19;
            this.chbx_useMouseGaze.Text = "Use Mouse Pointer Instead of Gaze ";
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
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.Transparent;
            this.pnl1.Controls.Add(this.metroLabel19);
            this.pnl1.Controls.Add(this.cmbTriableScreen);
            this.pnl1.Controls.Add(this.metroLabel20);
            this.pnl1.Controls.Add(this.metroLabel21);
            this.pnl1.Controls.Add(this.metroLabel22);
            this.pnl1.Controls.Add(this.txtNumGazeSmth);
            this.pnl1.Location = new System.Drawing.Point(4, 3);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(238, 121);
            this.pnl1.TabIndex = 129;
            this.pnl1.TabStop = false;
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel19.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel19.Location = new System.Drawing.Point(7, 49);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(165, 15);
            this.metroLabel19.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel19.TabIndex = 84;
            this.metroLabel19.Text = "Screen Number to Show Task:";
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
            this.cmbTriableScreen.Location = new System.Drawing.Point(189, 49);
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
            this.metroLabel20.Size = new System.Drawing.Size(189, 19);
            this.metroLabel20.TabIndex = 17;
            this.metroLabel20.Text = "General Task Running Setting";
            this.metroLabel20.UseCustomBackColor = true;
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel21.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel21.Location = new System.Drawing.Point(8, 83);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(182, 15);
            this.metroLabel21.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel21.TabIndex = 85;
            this.metroLabel21.Text = "Number of Data to Smooth Gaze:";
            this.metroLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel21.UseCustomBackColor = true;
            this.metroLabel21.WrapToLine = true;
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
            this.txtNumGazeSmth.Location = new System.Drawing.Point(189, 83);
            this.txtNumGazeSmth.Name = "txtNumGazeSmth";
            this.txtNumGazeSmth.Size = new System.Drawing.Size(43, 22);
            this.txtNumGazeSmth.TabIndex = 16;
            this.txtNumGazeSmth.Text = "5";
            // 
            // pnl4
            // 
            this.pnl4.BackColor = System.Drawing.Color.Transparent;
            this.pnl4.Controls.Add(this.metroLabel23);
            this.pnl4.Controls.Add(this.pnlRunMode);
            this.pnl4.Controls.Add(this.metroLabel24);
            this.pnl4.Location = new System.Drawing.Point(248, 124);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(238, 122);
            this.pnl4.TabIndex = 127;
            this.pnl4.TabStop = false;
            this.pnl4.Visible = false;
            // 
            // metroLabel23
            // 
            this.metroLabel23.AutoSize = true;
            this.metroLabel23.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel23.Location = new System.Drawing.Point(7, 12);
            this.metroLabel23.Name = "metroLabel23";
            this.metroLabel23.Size = new System.Drawing.Size(202, 19);
            this.metroLabel23.TabIndex = 6;
            this.metroLabel23.Text = "Psycology Tasks Running Mode";
            this.metroLabel23.UseCustomBackColor = true;
            // 
            // pnlRunMode
            // 
            this.pnlRunMode.Controls.Add(this.rdbRecursRun);
            this.pnlRunMode.Controls.Add(this.rdbNormFormRun);
            this.pnlRunMode.HorizontalScrollbarBarColor = true;
            this.pnlRunMode.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlRunMode.HorizontalScrollbarSize = 10;
            this.pnlRunMode.Location = new System.Drawing.Point(3, 43);
            this.pnlRunMode.Name = "pnlRunMode";
            this.pnlRunMode.Size = new System.Drawing.Size(200, 69);
            this.pnlRunMode.TabIndex = 5;
            this.pnlRunMode.UseCustomBackColor = true;
            this.pnlRunMode.VerticalScrollbarBarColor = true;
            this.pnlRunMode.VerticalScrollbarHighlightOnWheel = false;
            this.pnlRunMode.VerticalScrollbarSize = 10;
            // 
            // rdbRecursRun
            // 
            this.rdbRecursRun.AutoSize = true;
            this.rdbRecursRun.Location = new System.Drawing.Point(8, 43);
            this.rdbRecursRun.Name = "rdbRecursRun";
            this.rdbRecursRun.Size = new System.Drawing.Size(118, 15);
            this.rdbRecursRun.TabIndex = 4;
            this.rdbRecursRun.Text = "Recursive running";
            this.rdbRecursRun.UseCustomBackColor = true;
            this.rdbRecursRun.UseSelectable = true;
            // 
            // rdbNormFormRun
            // 
            this.rdbNormFormRun.AutoSize = true;
            this.rdbNormFormRun.Checked = true;
            this.rdbNormFormRun.Location = new System.Drawing.Point(8, 9);
            this.rdbNormFormRun.Name = "rdbNormFormRun";
            this.rdbNormFormRun.Size = new System.Drawing.Size(109, 15);
            this.rdbNormFormRun.TabIndex = 3;
            this.rdbNormFormRun.TabStop = true;
            this.rdbNormFormRun.Text = "Normal Forward";
            this.rdbNormFormRun.UseCustomBackColor = true;
            this.rdbNormFormRun.UseSelectable = true;
            // 
            // metroLabel24
            // 
            this.metroLabel24.AutoSize = true;
            this.metroLabel24.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel24.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel24.Location = new System.Drawing.Point(7, 15);
            this.metroLabel24.Name = "metroLabel24";
            this.metroLabel24.Size = new System.Drawing.Size(222, 25);
            this.metroLabel24.TabIndex = 7;
            this.metroLabel24.Text = "______________________________";
            this.metroLabel24.UseCustomBackColor = true;
            // 
            // TaskOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
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
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericComPort)).EndInit();
            this.pnl5.ResumeLayout(false);
            this.pnl5.PerformLayout();
            this.pnlErr1.ResumeLayout(false);
            this.pnlErr1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl4.ResumeLayout(false);
            this.pnl4.PerformLayout();
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
		private System.Windows.Forms.GroupBox pnl5;
		private MetroFramework.Controls.MetroLabel metroLabel15;
		private MetroFramework.Controls.MetroLabel metroLabel16;
		private MetroFramework.Controls.MetroPanel pnlErr1;
		private System.Windows.Forms.GroupBox pnl2;
		private MetroFramework.Controls.MetroLabel metroLabel17;
		private MetroFramework.Controls.MetroPanel metroPanel1;
		private MetroFramework.Controls.MetroCheckBox chbuseMouseNextFrm;
		private MetroFramework.Controls.MetroCheckBox chbx_useMouseGaze;
		private MetroFramework.Controls.MetroLabel metroLabel18;
		private System.Windows.Forms.GroupBox pnl1;
		private MetroFramework.Controls.MetroLabel metroLabel19;
		private System.Windows.Forms.ComboBox cmbTriableScreen;
		private MetroFramework.Controls.MetroLabel metroLabel20;
		private MetroFramework.Controls.MetroLabel metroLabel21;
		private MetroFramework.Controls.MetroLabel metroLabel22;
		private System.Windows.Forms.TextBox txtNumGazeSmth;
		private System.Windows.Forms.GroupBox pnl4;
		private MetroFramework.Controls.MetroLabel metroLabel23;
		private MetroFramework.Controls.MetroPanel pnlRunMode;
		public MetroFramework.Controls.MetroRadioButton rdbRecursRun;
		public MetroFramework.Controls.MetroRadioButton rdbNormFormRun;
		private MetroFramework.Controls.MetroLabel metroLabel24;
        private System.Windows.Forms.GroupBox pnl3;
        private System.Windows.Forms.NumericUpDown numericComPort;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroRadioButton rdbComPort;
        private MetroFramework.Controls.MetroRadioButton rdbParAdress;
        private MetroFramework.Controls.MetroTextBox txtbxParAddress;
        private MetroFramework.Controls.MetroCheckBox chkbxMisSound;
        private MetroFramework.Controls.MetroCheckBox chbxNearMisHintArrow;
        private MetroFramework.Controls.MetroCheckBox chkbNearMisPrompt;
        private MetroFramework.Controls.MetroCheckBox chkbxMissesPrompt;
        private MetroFramework.Controls.MetroCheckBox chkbxGoalsPrompt;
        private MetroFramework.Controls.MetroCheckBox chkbxGoalSound;
        private MetroFramework.Controls.MetroCheckBox chkbxArrwHintGoals;
    }
}