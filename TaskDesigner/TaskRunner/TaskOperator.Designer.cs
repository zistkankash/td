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
			this.btnStart = new MetroFramework.Controls.MetroButton();
			this.txtbxTask = new MetroFramework.Controls.MetroTextBox();
			this.txtSavPath = new MetroFramework.Controls.MetroTextBox();
			this.pbOper = new System.Windows.Forms.PictureBox();
			this.Tabsetting = new MetroFramework.Controls.MetroTabPage();
			this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
			this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
			this.chbx_usemouse = new System.Windows.Forms.CheckBox();
			this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
			this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
			this.chbx_NMshowarrow = new System.Windows.Forms.CheckBox();
			this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
			this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
			this.chbx_sound = new System.Windows.Forms.CheckBox();
			this.chbx_showarrow = new System.Windows.Forms.CheckBox();
			this.chBx_prompt = new System.Windows.Forms.CheckBox();
			this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
			this.rbtn_ccttask = new MetroFramework.Controls.MetroRadioButton();
			this.rbtn_normalreward = new MetroFramework.Controls.MetroRadioButton();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.btStop = new MetroFramework.Controls.MetroButton();
			this.savTimer = new System.Windows.Forms.Timer(this.components);
			this.TabControl_taskoperator.SuspendLayout();
			this.Tabtask.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbOper)).BeginInit();
			this.Tabsetting.SuspendLayout();
			this.metroPanel4.SuspendLayout();
			this.metroPanel3.SuspendLayout();
			this.metroPanel2.SuspendLayout();
			this.metroPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl_taskoperator
			// 
			this.TabControl_taskoperator.Controls.Add(this.Tabtask);
			this.TabControl_taskoperator.Controls.Add(this.Tabsetting);
			this.TabControl_taskoperator.Location = new System.Drawing.Point(-1, 4);
			this.TabControl_taskoperator.Name = "TabControl_taskoperator";
			this.TabControl_taskoperator.SelectedIndex = 0;
			this.TabControl_taskoperator.Size = new System.Drawing.Size(486, 495);
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
			this.Tabtask.Size = new System.Drawing.Size(478, 453);
			this.Tabtask.TabIndex = 0;
			this.Tabtask.Text = "Task Selector";
			this.Tabtask.VerticalScrollbarBarColor = true;
			this.Tabtask.VerticalScrollbarHighlightOnWheel = false;
			this.Tabtask.VerticalScrollbarSize = 10;
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnStart.Enabled = false;
			this.btnStart.ForeColor = System.Drawing.Color.Black;
			this.btnStart.Location = new System.Drawing.Point(74, 422);
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
			this.txtbxTask.Location = new System.Drawing.Point(3, 335);
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
			this.txtSavPath.Location = new System.Drawing.Point(3, 376);
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
			this.pbOper.Size = new System.Drawing.Size(472, 302);
			this.pbOper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbOper.TabIndex = 5;
			this.pbOper.TabStop = false;
			// 
			// Tabsetting
			// 
			this.Tabsetting.Controls.Add(this.metroLabel7);
			this.Tabsetting.Controls.Add(this.metroPanel4);
			this.Tabsetting.Controls.Add(this.metroLabel8);
			this.Tabsetting.Controls.Add(this.metroLabel5);
			this.Tabsetting.Controls.Add(this.metroPanel3);
			this.Tabsetting.Controls.Add(this.metroLabel6);
			this.Tabsetting.Controls.Add(this.metroLabel3);
			this.Tabsetting.Controls.Add(this.metroPanel2);
			this.Tabsetting.Controls.Add(this.metroLabel4);
			this.Tabsetting.Controls.Add(this.metroLabel1);
			this.Tabsetting.Controls.Add(this.metroPanel1);
			this.Tabsetting.Controls.Add(this.metroLabel2);
			this.Tabsetting.HorizontalScrollbarBarColor = true;
			this.Tabsetting.HorizontalScrollbarHighlightOnWheel = false;
			this.Tabsetting.HorizontalScrollbarSize = 10;
			this.Tabsetting.Location = new System.Drawing.Point(4, 38);
			this.Tabsetting.Name = "Tabsetting";
			this.Tabsetting.Size = new System.Drawing.Size(478, 453);
			this.Tabsetting.Style = MetroFramework.MetroColorStyle.Black;
			this.Tabsetting.TabIndex = 1;
			this.Tabsetting.Text = "Setting";
			this.Tabsetting.VerticalScrollbarBarColor = true;
			this.Tabsetting.VerticalScrollbarHighlightOnWheel = false;
			this.Tabsetting.VerticalScrollbarSize = 10;
			// 
			// metroLabel7
			// 
			this.metroLabel7.AutoSize = true;
			this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel7.Location = new System.Drawing.Point(21, 18);
			this.metroLabel7.Name = "metroLabel7";
			this.metroLabel7.Size = new System.Drawing.Size(56, 19);
			this.metroLabel7.TabIndex = 14;
			this.metroLabel7.Text = "General";
			// 
			// metroPanel4
			// 
			this.metroPanel4.Controls.Add(this.chbx_usemouse);
			this.metroPanel4.HorizontalScrollbarBarColor = true;
			this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel4.HorizontalScrollbarSize = 10;
			this.metroPanel4.Location = new System.Drawing.Point(29, 46);
			this.metroPanel4.Name = "metroPanel4";
			this.metroPanel4.Size = new System.Drawing.Size(200, 42);
			this.metroPanel4.TabIndex = 13;
			this.metroPanel4.VerticalScrollbarBarColor = true;
			this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel4.VerticalScrollbarSize = 10;
			// 
			// chbx_usemouse
			// 
			this.chbx_usemouse.AutoSize = true;
			this.chbx_usemouse.BackColor = System.Drawing.Color.White;
			this.chbx_usemouse.Location = new System.Drawing.Point(18, 14);
			this.chbx_usemouse.Name = "chbx_usemouse";
			this.chbx_usemouse.Size = new System.Drawing.Size(81, 17);
			this.chbx_usemouse.TabIndex = 9;
			this.chbx_usemouse.Text = "Use Mouse";
			this.chbx_usemouse.UseVisualStyleBackColor = false;
			// 
			// metroLabel8
			// 
			this.metroLabel8.AutoSize = true;
			this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel8.Location = new System.Drawing.Point(21, 18);
			this.metroLabel8.Name = "metroLabel8";
			this.metroLabel8.Size = new System.Drawing.Size(208, 25);
			this.metroLabel8.TabIndex = 15;
			this.metroLabel8.Text = "____________________________";
			// 
			// metroLabel5
			// 
			this.metroLabel5.AutoSize = true;
			this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel5.Location = new System.Drawing.Point(21, 217);
			this.metroLabel5.Name = "metroLabel5";
			this.metroLabel5.Size = new System.Drawing.Size(85, 19);
			this.metroLabel5.TabIndex = 11;
			this.metroLabel5.Text = "Near_Misses";
			// 
			// metroPanel3
			// 
			this.metroPanel3.Controls.Add(this.chbx_NMshowarrow);
			this.metroPanel3.HorizontalScrollbarBarColor = true;
			this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel3.HorizontalScrollbarSize = 10;
			this.metroPanel3.Location = new System.Drawing.Point(29, 245);
			this.metroPanel3.Name = "metroPanel3";
			this.metroPanel3.Size = new System.Drawing.Size(205, 39);
			this.metroPanel3.TabIndex = 10;
			this.metroPanel3.VerticalScrollbarBarColor = true;
			this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel3.VerticalScrollbarSize = 10;
			// 
			// chbx_NMshowarrow
			// 
			this.chbx_NMshowarrow.AutoSize = true;
			this.chbx_NMshowarrow.BackColor = System.Drawing.Color.White;
			this.chbx_NMshowarrow.Location = new System.Drawing.Point(18, 13);
			this.chbx_NMshowarrow.Name = "chbx_NMshowarrow";
			this.chbx_NMshowarrow.Size = new System.Drawing.Size(83, 17);
			this.chbx_NMshowarrow.TabIndex = 8;
			this.chbx_NMshowarrow.Text = "show Arrow";
			this.chbx_NMshowarrow.UseVisualStyleBackColor = false;
			// 
			// metroLabel6
			// 
			this.metroLabel6.AutoSize = true;
			this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel6.Location = new System.Drawing.Point(21, 217);
			this.metroLabel6.Name = "metroLabel6";
			this.metroLabel6.Size = new System.Drawing.Size(208, 25);
			this.metroLabel6.TabIndex = 12;
			this.metroLabel6.Text = "____________________________";
			// 
			// metroLabel3
			// 
			this.metroLabel3.AutoSize = true;
			this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel3.Location = new System.Drawing.Point(21, 93);
			this.metroLabel3.Name = "metroLabel3";
			this.metroLabel3.Size = new System.Drawing.Size(86, 19);
			this.metroLabel3.TabIndex = 6;
			this.metroLabel3.Text = "Error Setting";
			// 
			// metroPanel2
			// 
			this.metroPanel2.Controls.Add(this.chbx_sound);
			this.metroPanel2.Controls.Add(this.chbx_showarrow);
			this.metroPanel2.Controls.Add(this.chBx_prompt);
			this.metroPanel2.HorizontalScrollbarBarColor = true;
			this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel2.HorizontalScrollbarSize = 10;
			this.metroPanel2.Location = new System.Drawing.Point(29, 121);
			this.metroPanel2.Name = "metroPanel2";
			this.metroPanel2.Size = new System.Drawing.Size(205, 81);
			this.metroPanel2.TabIndex = 5;
			this.metroPanel2.VerticalScrollbarBarColor = true;
			this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel2.VerticalScrollbarSize = 10;
			// 
			// chbx_sound
			// 
			this.chbx_sound.AutoSize = true;
			this.chbx_sound.BackColor = System.Drawing.Color.White;
			this.chbx_sound.Location = new System.Drawing.Point(18, 59);
			this.chbx_sound.Name = "chbx_sound";
			this.chbx_sound.Size = new System.Drawing.Size(92, 17);
			this.chbx_sound.TabIndex = 10;
			this.chbx_sound.Text = "Enable Sound";
			this.chbx_sound.UseVisualStyleBackColor = false;
			// 
			// chbx_showarrow
			// 
			this.chbx_showarrow.AutoSize = true;
			this.chbx_showarrow.BackColor = System.Drawing.Color.White;
			this.chbx_showarrow.Location = new System.Drawing.Point(18, 36);
			this.chbx_showarrow.Name = "chbx_showarrow";
			this.chbx_showarrow.Size = new System.Drawing.Size(91, 17);
			this.chbx_showarrow.TabIndex = 9;
			this.chbx_showarrow.Text = "Enable Arrow";
			this.chbx_showarrow.UseVisualStyleBackColor = false;
			// 
			// chBx_prompt
			// 
			this.chBx_prompt.AutoSize = true;
			this.chBx_prompt.BackColor = System.Drawing.Color.White;
			this.chBx_prompt.Location = new System.Drawing.Point(18, 13);
			this.chBx_prompt.Name = "chBx_prompt";
			this.chBx_prompt.Size = new System.Drawing.Size(97, 17);
			this.chBx_prompt.TabIndex = 8;
			this.chBx_prompt.Text = "Enable prompt";
			this.chBx_prompt.UseVisualStyleBackColor = false;
			// 
			// metroLabel4
			// 
			this.metroLabel4.AutoSize = true;
			this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel4.Location = new System.Drawing.Point(21, 93);
			this.metroLabel4.Name = "metroLabel4";
			this.metroLabel4.Size = new System.Drawing.Size(208, 25);
			this.metroLabel4.TabIndex = 7;
			this.metroLabel4.Text = "____________________________";
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
			this.metroLabel1.Location = new System.Drawing.Point(247, 18);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(100, 19);
			this.metroLabel1.TabIndex = 3;
			this.metroLabel1.Text = "Running Mode";
			// 
			// metroPanel1
			// 
			this.metroPanel1.Controls.Add(this.rbtn_ccttask);
			this.metroPanel1.Controls.Add(this.rbtn_normalreward);
			this.metroPanel1.HorizontalScrollbarBarColor = true;
			this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel1.HorizontalScrollbarSize = 10;
			this.metroPanel1.Location = new System.Drawing.Point(255, 46);
			this.metroPanel1.Name = "metroPanel1";
			this.metroPanel1.Size = new System.Drawing.Size(200, 81);
			this.metroPanel1.TabIndex = 2;
			this.metroPanel1.VerticalScrollbarBarColor = true;
			this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel1.VerticalScrollbarSize = 10;
			// 
			// rbtn_ccttask
			// 
			this.rbtn_ccttask.AutoSize = true;
			this.rbtn_ccttask.Location = new System.Drawing.Point(18, 47);
			this.rbtn_ccttask.Name = "rbtn_ccttask";
			this.rbtn_ccttask.Size = new System.Drawing.Size(72, 15);
			this.rbtn_ccttask.TabIndex = 4;
			this.rbtn_ccttask.Text = "CCT Task";
			this.rbtn_ccttask.UseSelectable = true;
			// 
			// rbtn_normalreward
			// 
			this.rbtn_normalreward.AutoSize = true;
			this.rbtn_normalreward.Location = new System.Drawing.Point(18, 15);
			this.rbtn_normalreward.Name = "rbtn_normalreward";
			this.rbtn_normalreward.Size = new System.Drawing.Size(108, 15);
			this.rbtn_normalreward.TabIndex = 3;
			this.rbtn_normalreward.Text = "Normal Reward ";
			this.rbtn_normalreward.UseSelectable = true;
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
			this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.metroLabel2.Location = new System.Drawing.Point(247, 18);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(208, 25);
			this.metroLabel2.TabIndex = 4;
			this.metroLabel2.Text = "____________________________";
			// 
			// btStop
			// 
			this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btStop.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btStop.Enabled = false;
			this.btStop.ForeColor = System.Drawing.Color.Black;
			this.btStop.Location = new System.Drawing.Point(281, 422);
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
			// savTimer
			// 
			this.savTimer.Interval = 1000;
			this.savTimer.Tick += new System.EventHandler(this.savTimer_Tick);
			// 
			// TaskOperator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(486, 515);
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
			this.Tabsetting.PerformLayout();
			this.metroPanel4.ResumeLayout(false);
			this.metroPanel4.PerformLayout();
			this.metroPanel3.ResumeLayout(false);
			this.metroPanel3.PerformLayout();
			this.metroPanel2.ResumeLayout(false);
			this.metroPanel2.PerformLayout();
			this.metroPanel1.ResumeLayout(false);
			this.metroPanel1.PerformLayout();
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
		private MetroFramework.Controls.MetroLabel metroLabel2;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private MetroFramework.Controls.MetroPanel metroPanel1;
		public MetroFramework.Controls.MetroRadioButton rbtn_normalreward;
		public MetroFramework.Controls.MetroRadioButton rbtn_ccttask;
		private MetroFramework.Controls.MetroLabel metroLabel3;
		private MetroFramework.Controls.MetroPanel metroPanel2;
		private MetroFramework.Controls.MetroLabel metroLabel4;
		private MetroFramework.Controls.MetroLabel metroLabel7;
		private MetroFramework.Controls.MetroPanel metroPanel4;
		public System.Windows.Forms.CheckBox chbx_usemouse;
		private MetroFramework.Controls.MetroLabel metroLabel8;
		private MetroFramework.Controls.MetroLabel metroLabel5;
		private MetroFramework.Controls.MetroPanel metroPanel3;
		public System.Windows.Forms.CheckBox chbx_NMshowarrow;
		private MetroFramework.Controls.MetroLabel metroLabel6;
		public System.Windows.Forms.CheckBox chbx_sound;
		public System.Windows.Forms.CheckBox chbx_showarrow;
		public System.Windows.Forms.CheckBox chBx_prompt;
		private MetroFramework.Controls.MetroButton btStop;
		private System.Windows.Forms.Timer savTimer;
	}
}