namespace Basics
{
	partial class COGLAB
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COGLAB));
			this.label1 = new System.Windows.Forms.Label();
			this.pnlNetSetting = new MetroFramework.Controls.MetroPanel();
			this.TxtbxLIP = new MetroFramework.Controls.MetroTextBox();
			this.txtbxLport = new MetroFramework.Controls.MetroTextBox();
			this.btnNetAddressSet = new MetroFramework.Controls.MetroTile();
			this.labelLIP = new MetroFramework.Controls.MetroLabel();
			this.btnConct = new MetroFramework.Controls.MetroTile();
			this.LabelLport = new MetroFramework.Controls.MetroLabel();
			this.btnTaskRun = new MetroFramework.Controls.MetroTile();
			this.metroBtnImageTask = new MetroFramework.Controls.MetroTile();
			this.btnNetSetting = new MetroFramework.Controls.MetroTile();
			this.btnTaskLab = new MetroFramework.Controls.MetroTile();
			this.btnHeatMap = new MetroFramework.Controls.MetroTile();
			this.btnCogLab = new MetroFramework.Controls.MetroTile();
			this.ToolTipHelp = new MetroFramework.Components.MetroToolTip();
			this.coglabRefrshForm = new System.Windows.Forms.Timer(this.components);
			this.pnlNetSetting.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Bauhaus 93", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Tomato;
			this.label1.Location = new System.Drawing.Point(142, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 42);
			this.label1.TabIndex = 4;
			this.label1.Text = "CogLab";
			// 
			// pnlNetSetting
			// 
			this.pnlNetSetting.BackColor = System.Drawing.Color.AliceBlue;
			this.pnlNetSetting.Controls.Add(this.TxtbxLIP);
			this.pnlNetSetting.Controls.Add(this.txtbxLport);
			this.pnlNetSetting.Controls.Add(this.btnNetAddressSet);
			this.pnlNetSetting.Controls.Add(this.labelLIP);
			this.pnlNetSetting.Controls.Add(this.btnConct);
			this.pnlNetSetting.Controls.Add(this.LabelLport);
			this.pnlNetSetting.HorizontalScrollbarBarColor = true;
			this.pnlNetSetting.HorizontalScrollbarHighlightOnWheel = false;
			this.pnlNetSetting.HorizontalScrollbarSize = 10;
			this.pnlNetSetting.Location = new System.Drawing.Point(7, 322);
			this.pnlNetSetting.Name = "pnlNetSetting";
			this.pnlNetSetting.Size = new System.Drawing.Size(421, 95);
			this.pnlNetSetting.Style = MetroFramework.MetroColorStyle.Blue;
			this.pnlNetSetting.TabIndex = 64;
			this.pnlNetSetting.UseCustomBackColor = true;
			this.pnlNetSetting.UseCustomForeColor = true;
			this.pnlNetSetting.VerticalScrollbarBarColor = true;
			this.pnlNetSetting.VerticalScrollbarHighlightOnWheel = false;
			this.pnlNetSetting.VerticalScrollbarSize = 10;
			this.pnlNetSetting.Visible = false;
			// 
			// TxtbxLIP
			// 
			this.TxtbxLIP.BackColor = System.Drawing.Color.AliceBlue;
			// 
			// 
			// 
			this.TxtbxLIP.CustomButton.Image = null;
			this.TxtbxLIP.CustomButton.Location = new System.Drawing.Point(74, 1);
			this.TxtbxLIP.CustomButton.Name = "";
			this.TxtbxLIP.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.TxtbxLIP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.TxtbxLIP.CustomButton.TabIndex = 1;
			this.TxtbxLIP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.TxtbxLIP.CustomButton.UseSelectable = true;
			this.TxtbxLIP.CustomButton.Visible = false;
			this.TxtbxLIP.Enabled = false;
			this.TxtbxLIP.ForeColor = System.Drawing.Color.Black;
			this.TxtbxLIP.Lines = new string[0];
			this.TxtbxLIP.Location = new System.Drawing.Point(34, 12);
			this.TxtbxLIP.MaxLength = 32767;
			this.TxtbxLIP.Name = "TxtbxLIP";
			this.TxtbxLIP.PasswordChar = '\0';
			this.TxtbxLIP.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TxtbxLIP.SelectedText = "";
			this.TxtbxLIP.SelectionLength = 0;
			this.TxtbxLIP.SelectionStart = 0;
			this.TxtbxLIP.ShortcutsEnabled = true;
			this.TxtbxLIP.Size = new System.Drawing.Size(96, 23);
			this.TxtbxLIP.TabIndex = 78;
			this.ToolTipHelp.SetToolTip(this.TxtbxLIP, "Enter this  IP address in Coglab address field in ET");
			this.TxtbxLIP.UseCustomBackColor = true;
			this.TxtbxLIP.UseCustomForeColor = true;
			this.TxtbxLIP.UseSelectable = true;
			this.TxtbxLIP.UseStyleColors = true;
			this.TxtbxLIP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.TxtbxLIP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// txtbxLport
			// 
			// 
			// 
			// 
			this.txtbxLport.CustomButton.Image = null;
			this.txtbxLport.CustomButton.Location = new System.Drawing.Point(69, 1);
			this.txtbxLport.CustomButton.Name = "";
			this.txtbxLport.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.txtbxLport.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.txtbxLport.CustomButton.TabIndex = 1;
			this.txtbxLport.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.txtbxLport.CustomButton.UseSelectable = true;
			this.txtbxLport.CustomButton.Visible = false;
			this.txtbxLport.ForeColor = System.Drawing.Color.Black;
			this.txtbxLport.Lines = new string[0];
			this.txtbxLport.Location = new System.Drawing.Point(186, 12);
			this.txtbxLport.MaxLength = 32767;
			this.txtbxLport.Name = "txtbxLport";
			this.txtbxLport.PasswordChar = '\0';
			this.txtbxLport.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtbxLport.SelectedText = "";
			this.txtbxLport.SelectionLength = 0;
			this.txtbxLport.SelectionStart = 0;
			this.txtbxLport.ShortcutsEnabled = true;
			this.txtbxLport.Size = new System.Drawing.Size(91, 23);
			this.txtbxLport.TabIndex = 80;
			this.ToolTipHelp.SetToolTip(this.txtbxLport, "Enter this  Port address in Coglab Port address field in ET");
			this.txtbxLport.UseCustomBackColor = true;
			this.txtbxLport.UseCustomForeColor = true;
			this.txtbxLport.UseSelectable = true;
			this.txtbxLport.UseStyleColors = true;
			this.txtbxLport.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.txtbxLport.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// btnNetAddressSet
			// 
			this.btnNetAddressSet.ActiveControl = null;
			this.btnNetAddressSet.BackColor = System.Drawing.Color.Black;
			this.btnNetAddressSet.ForeColor = System.Drawing.Color.Black;
			this.btnNetAddressSet.Location = new System.Drawing.Point(290, 7);
			this.btnNetAddressSet.Name = "btnNetAddressSet";
			this.btnNetAddressSet.Size = new System.Drawing.Size(121, 35);
			this.btnNetAddressSet.Style = MetroFramework.MetroColorStyle.Blue;
			this.btnNetAddressSet.TabIndex = 79;
			this.btnNetAddressSet.Text = "Network IP";
			this.btnNetAddressSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnNetAddressSet.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.btnNetAddressSet.TileImage = ((System.Drawing.Image)(resources.GetObject("btnNetAddressSet.TileImage")));
			this.btnNetAddressSet.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.ToolTipHelp.SetToolTip(this.btnNetAddressSet, "Address Helper");
			this.btnNetAddressSet.UseSelectable = true;
			this.btnNetAddressSet.Click += new System.EventHandler(this.btnNetAddressSet_Click);
			// 
			// labelLIP
			// 
			this.labelLIP.AutoSize = true;
			this.labelLIP.BackColor = System.Drawing.Color.AliceBlue;
			this.labelLIP.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelLIP.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.labelLIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.labelLIP.Location = new System.Drawing.Point(7, 14);
			this.labelLIP.Name = "labelLIP";
			this.labelLIP.Size = new System.Drawing.Size(21, 15);
			this.labelLIP.Style = MetroFramework.MetroColorStyle.Blue;
			this.labelLIP.TabIndex = 77;
			this.labelLIP.Text = "IP:";
			this.labelLIP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelLIP.UseCustomBackColor = true;
			// 
			// btnConct
			// 
			this.btnConct.ActiveControl = null;
			this.btnConct.BackColor = System.Drawing.Color.Black;
			this.btnConct.ForeColor = System.Drawing.Color.Black;
			this.btnConct.Location = new System.Drawing.Point(112, 48);
			this.btnConct.Name = "btnConct";
			this.btnConct.Size = new System.Drawing.Size(205, 44);
			this.btnConct.Style = MetroFramework.MetroColorStyle.Blue;
			this.btnConct.TabIndex = 75;
			this.btnConct.Text = "Start Connection";
			this.btnConct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnConct.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.btnConct.TileImage = ((System.Drawing.Image)(resources.GetObject("btnConct.TileImage")));
			this.btnConct.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.ToolTipHelp.SetToolTip(this.btnConct, "Press to start connection to ET");
			this.btnConct.UseSelectable = true;
			this.btnConct.Click += new System.EventHandler(this.btnConct_Click);
			// 
			// LabelLport
			// 
			this.LabelLport.AutoSize = true;
			this.LabelLport.FontSize = MetroFramework.MetroLabelSize.Small;
			this.LabelLport.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.LabelLport.Location = new System.Drawing.Point(143, 14);
			this.LabelLport.Name = "LabelLport";
			this.LabelLport.Size = new System.Drawing.Size(34, 15);
			this.LabelLport.Style = MetroFramework.MetroColorStyle.Blue;
			this.LabelLport.TabIndex = 79;
			this.LabelLport.Text = "Port:";
			this.LabelLport.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.LabelLport.UseCustomBackColor = true;
			// 
			// btnTaskRun
			// 
			this.btnTaskRun.ActiveControl = null;
			this.btnTaskRun.BackColor = System.Drawing.Color.Tomato;
			this.btnTaskRun.ForeColor = System.Drawing.Color.White;
			this.btnTaskRun.Location = new System.Drawing.Point(228, 236);
			this.btnTaskRun.Name = "btnTaskRun";
			this.btnTaskRun.Size = new System.Drawing.Size(200, 75);
			this.btnTaskRun.Style = MetroFramework.MetroColorStyle.Blue;
			this.btnTaskRun.TabIndex = 66;
			this.btnTaskRun.Text = "Task Runner";
			this.btnTaskRun.TileImage = ((System.Drawing.Image)(resources.GetObject("btnTaskRun.TileImage")));
			this.btnTaskRun.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTaskRun.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.btnTaskRun.UseCustomBackColor = true;
			this.btnTaskRun.UseCustomForeColor = true;
			this.btnTaskRun.UseSelectable = true;
			this.btnTaskRun.UseStyleColors = true;
			this.btnTaskRun.UseTileImage = true;
			this.btnTaskRun.Click += new System.EventHandler(this.btnTaskRun_Click);
			// 
			// metroBtnImageTask
			// 
			this.metroBtnImageTask.ActiveControl = null;
			this.metroBtnImageTask.BackColor = System.Drawing.Color.White;
			this.metroBtnImageTask.Location = new System.Drawing.Point(228, 150);
			this.metroBtnImageTask.Name = "metroBtnImageTask";
			this.metroBtnImageTask.Size = new System.Drawing.Size(200, 75);
			this.metroBtnImageTask.Style = MetroFramework.MetroColorStyle.Red;
			this.metroBtnImageTask.TabIndex = 65;
			this.metroBtnImageTask.Text = "Image Tasks";
			this.metroBtnImageTask.TileImage = ((System.Drawing.Image)(resources.GetObject("metroBtnImageTask.TileImage")));
			this.metroBtnImageTask.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.metroBtnImageTask.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.metroBtnImageTask.UseSelectable = true;
			this.metroBtnImageTask.UseTileImage = true;
			this.metroBtnImageTask.Click += new System.EventHandler(this.metroBtnImageTask_Click);
			// 
			// btnNetSetting
			// 
			this.btnNetSetting.ActiveControl = null;
			this.btnNetSetting.Location = new System.Drawing.Point(7, 237);
			this.btnNetSetting.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
			this.btnNetSetting.Name = "btnNetSetting";
			this.btnNetSetting.Size = new System.Drawing.Size(200, 75);
			this.btnNetSetting.Style = MetroFramework.MetroColorStyle.Blue;
			this.btnNetSetting.TabIndex = 63;
			this.btnNetSetting.Text = "Network Setting";
			this.btnNetSetting.TileImage = global::TaskDesigner.Properties.Resources.network;
			this.btnNetSetting.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnNetSetting.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.btnNetSetting.UseSelectable = true;
			this.btnNetSetting.UseTileImage = true;
			this.btnNetSetting.Click += new System.EventHandler(this.btnNetSetting_Click);
			// 
			// btnTaskLab
			// 
			this.btnTaskLab.ActiveControl = null;
			this.btnTaskLab.Location = new System.Drawing.Point(228, 63);
			this.btnTaskLab.Name = "btnTaskLab";
			this.btnTaskLab.Size = new System.Drawing.Size(200, 75);
			this.btnTaskLab.Style = MetroFramework.MetroColorStyle.Magenta;
			this.btnTaskLab.TabIndex = 3;
			this.btnTaskLab.Text = "Design Laburatory";
			this.btnTaskLab.TileImage = ((System.Drawing.Image)(resources.GetObject("btnTaskLab.TileImage")));
			this.btnTaskLab.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnTaskLab.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.btnTaskLab.UseSelectable = true;
			this.btnTaskLab.UseTileImage = true;
			this.btnTaskLab.Click += new System.EventHandler(this.btnTaskLab_Click);
			// 
			// btnHeatMap
			// 
			this.btnHeatMap.ActiveControl = null;
			this.btnHeatMap.Location = new System.Drawing.Point(7, 150);
			this.btnHeatMap.Name = "btnHeatMap";
			this.btnHeatMap.Size = new System.Drawing.Size(200, 75);
			this.btnHeatMap.Style = MetroFramework.MetroColorStyle.Teal;
			this.btnHeatMap.TabIndex = 2;
			this.btnHeatMap.Text = "Analyses";
			this.btnHeatMap.TileImage = ((System.Drawing.Image)(resources.GetObject("btnHeatMap.TileImage")));
			this.btnHeatMap.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnHeatMap.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.btnHeatMap.UseSelectable = true;
			this.btnHeatMap.UseTileImage = true;
			this.btnHeatMap.Click += new System.EventHandler(this.btnHeatMap_Click);
			// 
			// btnCogLab
			// 
			this.btnCogLab.ActiveControl = null;
			this.btnCogLab.Location = new System.Drawing.Point(7, 63);
			this.btnCogLab.Name = "btnCogLab";
			this.btnCogLab.Size = new System.Drawing.Size(200, 75);
			this.btnCogLab.Style = MetroFramework.MetroColorStyle.Purple;
			this.btnCogLab.TabIndex = 1;
			this.btnCogLab.Text = "Psychophysics";
			this.btnCogLab.TileImage = ((System.Drawing.Image)(resources.GetObject("btnCogLab.TileImage")));
			this.btnCogLab.TileImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCogLab.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
			this.btnCogLab.UseSelectable = true;
			this.btnCogLab.UseStyleColors = true;
			this.btnCogLab.UseTileImage = true;
			this.btnCogLab.Click += new System.EventHandler(this.btnCogLab_Click);
			// 
			// ToolTipHelp
			// 
			this.ToolTipHelp.AutoPopDelay = 15000;
			this.ToolTipHelp.InitialDelay = 500;
			this.ToolTipHelp.ReshowDelay = 100;
			this.ToolTipHelp.Style = MetroFramework.MetroColorStyle.Blue;
			this.ToolTipHelp.StyleManager = null;
			this.ToolTipHelp.Theme = MetroFramework.MetroThemeStyle.Light;
			// 
			// coglabRefrshForm
			// 
			this.coglabRefrshForm.Interval = 1000;
			this.coglabRefrshForm.Tick += new System.EventHandler(this.coglabRefrshForm_Tick);
			// 
			// COGLAB
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(438, 426);
			this.Controls.Add(this.btnTaskRun);
			this.Controls.Add(this.metroBtnImageTask);
			this.Controls.Add(this.pnlNetSetting);
			this.Controls.Add(this.btnNetSetting);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnTaskLab);
			this.Controls.Add(this.btnHeatMap);
			this.Controls.Add(this.btnCogLab);
			this.Font = new System.Drawing.Font("Marlett", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(2)), true);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "COGLAB";
			this.Resizable = false;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.COGLAB_FormClosing);
			this.Load += new System.EventHandler(this.COGLAB_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.COGLAB_KeyUp);
			this.pnlNetSetting.ResumeLayout(false);
			this.pnlNetSetting.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroTile btnCogLab;
		private MetroFramework.Controls.MetroTile btnHeatMap;
		private MetroFramework.Controls.MetroTile btnTaskLab;
		private System.Windows.Forms.Label label1;
		private MetroFramework.Controls.MetroTile btnNetSetting;
		private MetroFramework.Controls.MetroPanel pnlNetSetting;
		private MetroFramework.Controls.MetroTile metroBtnImageTask;
		private MetroFramework.Controls.MetroTile btnConct;
		private MetroFramework.Controls.MetroTile btnTaskRun;
		private MetroFramework.Controls.MetroTile btnNetAddressSet;
		private MetroFramework.Components.MetroToolTip ToolTipHelp;
		public MetroFramework.Controls.MetroTextBox TxtbxLIP;
		public MetroFramework.Controls.MetroTextBox txtbxLport;
		private MetroFramework.Controls.MetroLabel labelLIP;
		private MetroFramework.Controls.MetroLabel LabelLport;
		private System.Windows.Forms.Timer coglabRefrshForm;
	}
}