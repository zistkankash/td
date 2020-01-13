namespace Basics
{
	partial class NetSettingForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetSettingForm));
			this.pnlNetSetting = new MetroFramework.Controls.MetroPanel();
			this.TxtbxLIP = new MetroFramework.Controls.MetroTextBox();
			this.txtbxLport = new MetroFramework.Controls.MetroTextBox();
			this.labelLIP = new MetroFramework.Controls.MetroLabel();
			this.LabelLport = new MetroFramework.Controls.MetroLabel();
			this.ToolTipHelp = new MetroFramework.Components.MetroToolTip();
			this.coglabRefrshForm = new System.Windows.Forms.Timer(this.components);
			this.btnHelp = new System.Windows.Forms.Button();
			this.btnNetAddressSet = new MetroFramework.Controls.MetroTile();
			this.btnConct = new MetroFramework.Controls.MetroTile();
			this.pnlNetSetting.SuspendLayout();
			this.SuspendLayout();
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
			this.pnlNetSetting.Location = new System.Drawing.Point(4, 30);
			this.pnlNetSetting.Name = "pnlNetSetting";
			this.pnlNetSetting.Size = new System.Drawing.Size(524, 118);
			this.pnlNetSetting.Style = MetroFramework.MetroColorStyle.Blue;
			this.pnlNetSetting.TabIndex = 64;
			this.pnlNetSetting.UseCustomBackColor = true;
			this.pnlNetSetting.UseCustomForeColor = true;
			this.pnlNetSetting.VerticalScrollbarBarColor = true;
			this.pnlNetSetting.VerticalScrollbarHighlightOnWheel = false;
			this.pnlNetSetting.VerticalScrollbarSize = 10;
			// 
			// TxtbxLIP
			// 
			this.TxtbxLIP.BackColor = System.Drawing.Color.AliceBlue;
			// 
			// 
			// 
			this.TxtbxLIP.CustomButton.Image = null;
			this.TxtbxLIP.CustomButton.Location = new System.Drawing.Point(95, 1);
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
			this.TxtbxLIP.Location = new System.Drawing.Point(135, 24);
			this.TxtbxLIP.MaxLength = 32767;
			this.TxtbxLIP.Name = "TxtbxLIP";
			this.TxtbxLIP.PasswordChar = '\0';
			this.TxtbxLIP.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.TxtbxLIP.SelectedText = "";
			this.TxtbxLIP.SelectionLength = 0;
			this.TxtbxLIP.SelectionStart = 0;
			this.TxtbxLIP.ShortcutsEnabled = true;
			this.TxtbxLIP.Size = new System.Drawing.Size(117, 23);
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
			this.txtbxLport.CustomButton.Location = new System.Drawing.Point(95, 1);
			this.txtbxLport.CustomButton.Name = "";
			this.txtbxLport.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.txtbxLport.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.txtbxLport.CustomButton.TabIndex = 1;
			this.txtbxLport.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.txtbxLport.CustomButton.UseSelectable = true;
			this.txtbxLport.CustomButton.Visible = false;
			this.txtbxLport.ForeColor = System.Drawing.Color.Black;
			this.txtbxLport.Lines = new string[0];
			this.txtbxLport.Location = new System.Drawing.Point(388, 24);
			this.txtbxLport.MaxLength = 32767;
			this.txtbxLport.Name = "txtbxLport";
			this.txtbxLport.PasswordChar = '\0';
			this.txtbxLport.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtbxLport.SelectedText = "";
			this.txtbxLport.SelectionLength = 0;
			this.txtbxLport.SelectionStart = 0;
			this.txtbxLport.ShortcutsEnabled = true;
			this.txtbxLport.Size = new System.Drawing.Size(117, 23);
			this.txtbxLport.TabIndex = 80;
			this.ToolTipHelp.SetToolTip(this.txtbxLport, "Enter this  Port address in Coglab Port address field in ET");
			this.txtbxLport.UseCustomBackColor = true;
			this.txtbxLport.UseCustomForeColor = true;
			this.txtbxLport.UseSelectable = true;
			this.txtbxLport.UseStyleColors = true;
			this.txtbxLport.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.txtbxLport.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelLIP
			// 
			this.labelLIP.AutoSize = true;
			this.labelLIP.BackColor = System.Drawing.Color.AliceBlue;
			this.labelLIP.FontSize = MetroFramework.MetroLabelSize.Small;
			this.labelLIP.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.labelLIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.labelLIP.Location = new System.Drawing.Point(7, 28);
			this.labelLIP.Name = "labelLIP";
			this.labelLIP.Size = new System.Drawing.Size(101, 15);
			this.labelLIP.Style = MetroFramework.MetroColorStyle.Blue;
			this.labelLIP.TabIndex = 77;
			this.labelLIP.Text = "Task Designer IP:";
			this.labelLIP.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelLIP.UseCustomBackColor = true;
			// 
			// LabelLport
			// 
			this.LabelLport.AutoSize = true;
			this.LabelLport.FontSize = MetroFramework.MetroLabelSize.Small;
			this.LabelLport.FontWeight = MetroFramework.MetroLabelWeight.Bold;
			this.LabelLport.Location = new System.Drawing.Point(268, 28);
			this.LabelLport.Name = "LabelLport";
			this.LabelLport.Size = new System.Drawing.Size(114, 15);
			this.LabelLport.Style = MetroFramework.MetroColorStyle.Blue;
			this.LabelLport.TabIndex = 79;
			this.LabelLport.Text = "Task Designer Port:";
			this.LabelLport.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.LabelLport.UseCustomBackColor = true;
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
			// btnHelp
			// 
			this.btnHelp.BackgroundImage = global::TaskDesigner.Resource.help_black;
			this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.btnHelp.FlatAppearance.BorderSize = 0;
			this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHelp.Location = new System.Drawing.Point(491, 9);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(12, 12);
			this.btnHelp.TabIndex = 150;
			this.btnHelp.UseVisualStyleBackColor = true;
			// 
			// btnNetAddressSet
			// 
			this.btnNetAddressSet.ActiveControl = null;
			this.btnNetAddressSet.BackColor = System.Drawing.Color.Black;
			this.btnNetAddressSet.ForeColor = System.Drawing.Color.Black;
			this.btnNetAddressSet.Location = new System.Drawing.Point(268, 62);
			this.btnNetAddressSet.Name = "btnNetAddressSet";
			this.btnNetAddressSet.Size = new System.Drawing.Size(239, 44);
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
			// btnConct
			// 
			this.btnConct.ActiveControl = null;
			this.btnConct.BackColor = System.Drawing.Color.Black;
			this.btnConct.ForeColor = System.Drawing.Color.Black;
			this.btnConct.Location = new System.Drawing.Point(6, 62);
			this.btnConct.Name = "btnConct";
			this.btnConct.Size = new System.Drawing.Size(245, 44);
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
			// NetSettingForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(533, 154);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.pnlNetSetting);
			this.Font = new System.Drawing.Font("Marlett", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(2)), true);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NetSettingForm";
			this.Resizable = false;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetSettingForm_FormClosing);
			this.Load += new System.EventHandler(this.COGLAB_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NetSettingForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.COGLAB_KeyUp);
			this.pnlNetSetting.ResumeLayout(false);
			this.pnlNetSetting.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private MetroFramework.Controls.MetroPanel pnlNetSetting;
		private MetroFramework.Controls.MetroTile btnConct;
		private MetroFramework.Controls.MetroTile btnNetAddressSet;
		private MetroFramework.Components.MetroToolTip ToolTipHelp;
		public MetroFramework.Controls.MetroTextBox TxtbxLIP;
		public MetroFramework.Controls.MetroTextBox txtbxLport;
		private MetroFramework.Controls.MetroLabel labelLIP;
		private MetroFramework.Controls.MetroLabel LabelLport;
		private System.Windows.Forms.Timer coglabRefrshForm;
		private System.Windows.Forms.Button btnHelp;
	}
}