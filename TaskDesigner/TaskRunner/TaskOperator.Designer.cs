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
            this.krbTabControl2 = new KRBTabControl.KRBTabControl();
            this.tabPageEx1 = new KRBTabControl.TabPageEx();
            this.pbOper = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtSavPath = new MetroFramework.Controls.MetroTextBox();
            this.txtbxTask = new MetroFramework.Controls.MetroTextBox();
            this.tabPageEx4 = new KRBTabControl.TabPageEx();
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
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.cmbTriableScreen = new System.Windows.Forms.ComboBox();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.txtNumGazeSmth = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.pnlRunMode = new MetroFramework.Controls.MetroPanel();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.krbTabControl2.SuspendLayout();
            this.tabPageEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOper)).BeginInit();
            this.tabPageEx4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlErr1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pnlRunMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // refTimer
            // 
            this.refTimer.Interval = 15;
            this.refTimer.Tick += new System.EventHandler(this.refTimer_Tick);
            // 
            // krbTabControl2
            // 
            this.krbTabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.krbTabControl2.Alignments = KRBTabControl.KRBTabControl.TabAlignments.Bottom;
            this.krbTabControl2.AllowDrop = true;
            this.krbTabControl2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.krbTabControl2.BackgroundHatcher.HatchType = System.Drawing.Drawing2D.HatchStyle.DashedVertical;
            this.krbTabControl2.Controls.Add(this.tabPageEx1);
            this.krbTabControl2.Controls.Add(this.tabPageEx4);
            this.krbTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krbTabControl2.IsCaptionVisible = false;
            this.krbTabControl2.IsDocumentTabStyle = true;
            this.krbTabControl2.ItemSize = new System.Drawing.Size(0, 26);
            this.krbTabControl2.Location = new System.Drawing.Point(0, 0);
            this.krbTabControl2.Name = "krbTabControl2";
            this.krbTabControl2.SelectedIndex = 1;
            this.krbTabControl2.Size = new System.Drawing.Size(489, 490);
            this.krbTabControl2.TabBorderColor = System.Drawing.Color.Gray;
            this.krbTabControl2.TabGradient.ColorEnd = System.Drawing.Color.Gainsboro;
            this.krbTabControl2.TabIndex = 110;
            this.krbTabControl2.TabStyles = KRBTabControl.KRBTabControl.TabStyle.VS2010;
            this.krbTabControl2.UpDownStyle = KRBTabControl.KRBTabControl.UpDown32Style.BlackGlass;
            this.krbTabControl2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.krbTabControl2_KeyDown);
            this.krbTabControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.krbTabControl2_MouseDown);
            this.krbTabControl2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.krbTabControl2_PreviewKeyDown);
            // 
            // tabPageEx1
            // 
            this.tabPageEx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.tabPageEx1.Controls.Add(this.pbOper);
            this.tabPageEx1.Controls.Add(this.btnStop);
            this.tabPageEx1.Controls.Add(this.btnStart);
            this.tabPageEx1.Controls.Add(this.txtSavPath);
            this.tabPageEx1.Controls.Add(this.txtbxTask);
            this.tabPageEx1.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageEx1.IsClosable = false;
            this.tabPageEx1.Location = new System.Drawing.Point(1, 5);
            this.tabPageEx1.Name = "tabPageEx1";
            this.tabPageEx1.Size = new System.Drawing.Size(487, 453);
            this.tabPageEx1.TabIndex = 2;
            this.tabPageEx1.Text = "Runner";
            this.tabPageEx1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPageEx1_MouseDown);
            this.tabPageEx1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tabPageEx1_PreviewKeyDown);
            // 
            // pbOper
            // 
            this.pbOper.BackColor = System.Drawing.Color.Gray;
            this.pbOper.Location = new System.Drawing.Point(3, 3);
            this.pbOper.Name = "pbOper";
            this.pbOper.Size = new System.Drawing.Size(480, 300);
            this.pbOper.TabIndex = 0;
            this.pbOper.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(292, 406);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(108, 34);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop Task";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnStart.Enabled = false;
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(86, 406);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(108, 34);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Task";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // txtSavPath
            // 
            // 
            // 
            // 
            this.txtSavPath.CustomButton.Image = null;
            this.txtSavPath.CustomButton.Location = new System.Drawing.Point(458, 1);
            this.txtSavPath.CustomButton.Name = "";
            this.txtSavPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSavPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSavPath.CustomButton.TabIndex = 1;
            this.txtSavPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSavPath.CustomButton.UseSelectable = true;
            this.txtSavPath.CustomButton.Visible = false;
            this.txtSavPath.Lines = new string[0];
            this.txtSavPath.Location = new System.Drawing.Point(3, 366);
            this.txtSavPath.MaxLength = 32767;
            this.txtSavPath.Name = "txtSavPath";
            this.txtSavPath.PasswordChar = '\0';
            this.txtSavPath.PromptText = "Select Output";
            this.txtSavPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSavPath.SelectedText = "";
            this.txtSavPath.SelectionLength = 0;
            this.txtSavPath.SelectionStart = 0;
            this.txtSavPath.ShortcutsEnabled = true;
            this.txtSavPath.Size = new System.Drawing.Size(480, 23);
            this.txtSavPath.TabIndex = 101;
            this.txtSavPath.TabStop = false;
            this.txtSavPath.UseCustomBackColor = true;
            this.txtSavPath.UseSelectable = true;
            this.txtSavPath.WaterMark = "Select Output";
            this.txtSavPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSavPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSavPath.Click += new System.EventHandler(this.txtPath_Click);
            // 
            // txtbxTask
            // 
            // 
            // 
            // 
            this.txtbxTask.CustomButton.Image = null;
            this.txtbxTask.CustomButton.Location = new System.Drawing.Point(458, 1);
            this.txtbxTask.CustomButton.Name = "";
            this.txtbxTask.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbxTask.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbxTask.CustomButton.TabIndex = 1;
            this.txtbxTask.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbxTask.CustomButton.UseSelectable = true;
            this.txtbxTask.CustomButton.Visible = false;
            this.txtbxTask.Lines = new string[0];
            this.txtbxTask.Location = new System.Drawing.Point(3, 324);
            this.txtbxTask.MaxLength = 32767;
            this.txtbxTask.Name = "txtbxTask";
            this.txtbxTask.PasswordChar = '\0';
            this.txtbxTask.PromptText = "Select Task";
            this.txtbxTask.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbxTask.SelectedText = "";
            this.txtbxTask.SelectionLength = 0;
            this.txtbxTask.SelectionStart = 0;
            this.txtbxTask.ShortcutsEnabled = true;
            this.txtbxTask.Size = new System.Drawing.Size(480, 23);
            this.txtbxTask.TabIndex = 1;
            this.txtbxTask.UseCustomBackColor = true;
            this.txtbxTask.UseSelectable = true;
            this.txtbxTask.WaterMark = "Select Task";
            this.txtbxTask.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbxTask.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtbxTask.Click += new System.EventHandler(this.txtbxTask_Click);
            // 
            // tabPageEx4
            // 
            this.tabPageEx4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.tabPageEx4.Controls.Add(this.groupBox2);
            this.tabPageEx4.Controls.Add(this.groupBox3);
            this.tabPageEx4.Controls.Add(this.groupBox4);
            this.tabPageEx4.Controls.Add(this.groupBox5);
            this.tabPageEx4.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageEx4.IsClosable = false;
            this.tabPageEx4.Location = new System.Drawing.Point(1, 5);
            this.tabPageEx4.Name = "tabPageEx4";
            this.tabPageEx4.Size = new System.Drawing.Size(487, 453);
            this.tabPageEx4.TabIndex = 1;
            this.tabPageEx4.Text = "Settings";
            this.tabPageEx4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPageEx4_MouseDown);
            this.tabPageEx4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tabPageEx4_PreviewKeyDown);
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
            this.groupBox2.Location = new System.Drawing.Point(247, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 183);
            this.groupBox2.TabIndex = 29;
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
            this.groupBox3.Location = new System.Drawing.Point(247, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 129);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel17.Location = new System.Drawing.Point(3, 12);
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
            this.groupBox4.Controls.Add(this.metroLabel19);
            this.groupBox4.Controls.Add(this.cmbTriableScreen);
            this.groupBox4.Controls.Add(this.metroLabel20);
            this.groupBox4.Controls.Add(this.metroLabel21);
            this.groupBox4.Controls.Add(this.metroLabel22);
            this.groupBox4.Controls.Add(this.txtNumGazeSmth);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 129);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel19.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel19.Location = new System.Drawing.Point(7, 58);
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
            this.cmbTriableScreen.Location = new System.Drawing.Point(172, 52);
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
            this.metroLabel21.Location = new System.Drawing.Point(10, 95);
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
            this.txtNumGazeSmth.Location = new System.Drawing.Point(172, 90);
            this.txtNumGazeSmth.Name = "txtNumGazeSmth";
            this.txtNumGazeSmth.Size = new System.Drawing.Size(43, 23);
            this.txtNumGazeSmth.TabIndex = 16;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.metroLabel23);
            this.groupBox5.Controls.Add(this.pnlRunMode);
            this.groupBox5.Controls.Add(this.metroLabel24);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(3, 138);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(238, 183);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Visible = false;
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
            this.pnlRunMode.Size = new System.Drawing.Size(200, 78);
            this.pnlRunMode.TabIndex = 5;
            this.pnlRunMode.UseCustomBackColor = true;
            this.pnlRunMode.VerticalScrollbarBarColor = true;
            this.pnlRunMode.VerticalScrollbarHighlightOnWheel = false;
            this.pnlRunMode.VerticalScrollbarSize = 10;
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Location = new System.Drawing.Point(3, 43);
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
            this.metroRadioButton2.Location = new System.Drawing.Point(3, 13);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(108, 15);
            this.metroRadioButton2.TabIndex = 3;
            this.metroRadioButton2.Text = "Normal Reward ";
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
            this.ClientSize = new System.Drawing.Size(489, 490);
            this.Controls.Add(this.krbTabControl2);
            this.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskOperator";
            this.Text = "Task Runner Operator";
            this.Load += new System.EventHandler(this.TaskOperator_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TaskOperator_KeyDown);
            this.krbTabControl2.ResumeLayout(false);
            this.tabPageEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOper)).EndInit();
            this.tabPageEx4.ResumeLayout(false);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.pnlRunMode.ResumeLayout(false);
            this.pnlRunMode.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer refTimer;
		private KRBTabControl.KRBTabControl krbTabControl2;
		private KRBTabControl.TabPageEx tabPageEx4;
		private System.Windows.Forms.GroupBox groupBox2;
		private MetroFramework.Controls.MetroLabel metroLabel15;
		private MetroFramework.Controls.MetroLabel metroLabel16;
		private MetroFramework.Controls.MetroPanel pnlErr1;
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
		private MetroFramework.Controls.MetroLabel metroLabel19;
		private System.Windows.Forms.ComboBox cmbTriableScreen;
		private MetroFramework.Controls.MetroLabel metroLabel20;
		private MetroFramework.Controls.MetroLabel metroLabel21;
		private MetroFramework.Controls.MetroLabel metroLabel22;
		private System.Windows.Forms.TextBox txtNumGazeSmth;
		private System.Windows.Forms.GroupBox groupBox5;
		private MetroFramework.Controls.MetroLabel metroLabel23;
		private MetroFramework.Controls.MetroPanel pnlRunMode;
		public MetroFramework.Controls.MetroRadioButton metroRadioButton1;
		public MetroFramework.Controls.MetroRadioButton metroRadioButton2;
		private MetroFramework.Controls.MetroLabel metroLabel24;
		private KRBTabControl.TabPageEx tabPageEx1;
		private System.Windows.Forms.PictureBox pbOper;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnStart;
		private MetroFramework.Controls.MetroTextBox txtSavPath;
		private MetroFramework.Controls.MetroTextBox txtbxTask;
		public System.Windows.Forms.CheckBox chkb_nmsPrompt;
	}
}