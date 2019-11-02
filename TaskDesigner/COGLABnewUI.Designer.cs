﻿namespace Basics
{
	partial class COGLABnewUI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COGLABnewUI));
			this.backUpdater = new System.Windows.Forms.Timer(this.components);
			this.pnl_cntrl = new System.Windows.Forms.Panel();
			this.mtlCls = new MetroFramework.Controls.MetroTile();
			this.mtlMov = new MetroFramework.Controls.MetroTile();
			this.btn_trunner = new System.Windows.Forms.Button();
			this.btn_analysis = new System.Windows.Forms.Button();
			this.btn_linguistics = new System.Windows.Forms.Button();
			this.btn_psychology = new System.Windows.Forms.Button();
			this.btn_setting = new System.Windows.Forms.Button();
			this.btn_psychophysics = new System.Windows.Forms.Button();
			this.pnl_cntrl.SuspendLayout();
			this.SuspendLayout();
			// 
			// backUpdater
			// 
			this.backUpdater.Interval = 40;
			this.backUpdater.Tick += new System.EventHandler(this.backUpdater_Tick);
			// 
			// pnl_cntrl
			// 
			this.pnl_cntrl.BackColor = System.Drawing.Color.Transparent;
			this.pnl_cntrl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_cntrl.BackgroundImage")));
			this.pnl_cntrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pnl_cntrl.Controls.Add(this.mtlCls);
			this.pnl_cntrl.Controls.Add(this.mtlMov);
			this.pnl_cntrl.Controls.Add(this.btn_trunner);
			this.pnl_cntrl.Controls.Add(this.btn_analysis);
			this.pnl_cntrl.Controls.Add(this.btn_linguistics);
			this.pnl_cntrl.Controls.Add(this.btn_psychology);
			this.pnl_cntrl.Controls.Add(this.btn_setting);
			this.pnl_cntrl.Controls.Add(this.btn_psychophysics);
			this.pnl_cntrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnl_cntrl.Location = new System.Drawing.Point(0, 0);
			this.pnl_cntrl.Name = "pnl_cntrl";
			this.pnl_cntrl.Size = new System.Drawing.Size(655, 508);
			this.pnl_cntrl.TabIndex = 1;
			this.pnl_cntrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_cntrl_MouseDown);
			// 
			// mtlCls
			// 
			this.mtlCls.ActiveControl = null;
			this.mtlCls.Location = new System.Drawing.Point(539, 32);
			this.mtlCls.Name = "mtlCls";
			this.mtlCls.PaintTileCount = false;
			this.mtlCls.Size = new System.Drawing.Size(28, 26);
			this.mtlCls.Style = MetroFramework.MetroColorStyle.Black;
			this.mtlCls.TabIndex = 7;
			this.mtlCls.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mtlCls.TileImage = global::TaskDesigner.Resource._512px_Cross_red_circle_svg;
			this.mtlCls.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mtlCls.UseSelectable = true;
			this.mtlCls.UseTileImage = true;
			this.mtlCls.Click += new System.EventHandler(this.mtlCls_Click);
			// 
			// mtlMov
			// 
			this.mtlMov.ActiveControl = null;
			this.mtlMov.Cursor = System.Windows.Forms.Cursors.NoMove2D;
			this.mtlMov.Location = new System.Drawing.Point(90, 32);
			this.mtlMov.Name = "mtlMov";
			this.mtlMov.Size = new System.Drawing.Size(28, 26);
			this.mtlMov.Style = MetroFramework.MetroColorStyle.Black;
			this.mtlMov.TabIndex = 6;
			this.mtlMov.Theme = MetroFramework.MetroThemeStyle.Dark;
			this.mtlMov.TileImage = global::TaskDesigner.Resource.Button_Blank_Yellow_icon;
			this.mtlMov.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mtlMov.UseSelectable = true;
			this.mtlMov.UseTileImage = true;
			this.mtlMov.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mtlMov_MouseDown);
			// 
			// btn_trunner
			// 
			this.btn_trunner.BackColor = System.Drawing.Color.Transparent;
			this.btn_trunner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btn_trunner.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_trunner.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_trunner.Location = new System.Drawing.Point(0, 0);
			this.btn_trunner.Name = "btn_trunner";
			this.btn_trunner.Size = new System.Drawing.Size(655, 508);
			this.btn_trunner.TabIndex = 5;
			this.btn_trunner.UseVisualStyleBackColor = false;
			this.btn_trunner.Click += new System.EventHandler(this.btn_trunner_Click);
			// 
			// btn_analysis
			// 
			this.btn_analysis.BackColor = System.Drawing.Color.Transparent;
			this.btn_analysis.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_analysis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_analysis.Location = new System.Drawing.Point(0, 0);
			this.btn_analysis.Name = "btn_analysis";
			this.btn_analysis.Size = new System.Drawing.Size(655, 508);
			this.btn_analysis.TabIndex = 4;
			this.btn_analysis.UseVisualStyleBackColor = false;
			this.btn_analysis.Click += new System.EventHandler(this.btn_analysis_Click);
			this.btn_analysis.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_analysis_MouseClick);
			// 
			// btn_linguistics
			// 
			this.btn_linguistics.BackColor = System.Drawing.Color.Transparent;
			this.btn_linguistics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_linguistics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_linguistics.Location = new System.Drawing.Point(0, 0);
			this.btn_linguistics.Name = "btn_linguistics";
			this.btn_linguistics.Size = new System.Drawing.Size(655, 508);
			this.btn_linguistics.TabIndex = 3;
			this.btn_linguistics.UseVisualStyleBackColor = false;
			this.btn_linguistics.Click += new System.EventHandler(this.btn_linguistics_Click);
			// 
			// btn_psychology
			// 
			this.btn_psychology.BackColor = System.Drawing.Color.Transparent;
			this.btn_psychology.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_psychology.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_psychology.Location = new System.Drawing.Point(0, 0);
			this.btn_psychology.Name = "btn_psychology";
			this.btn_psychology.Size = new System.Drawing.Size(655, 508);
			this.btn_psychology.TabIndex = 2;
			this.btn_psychology.UseVisualStyleBackColor = false;
			this.btn_psychology.Click += new System.EventHandler(this.btn_psychology_Click);
			// 
			// btn_setting
			// 
			this.btn_setting.BackColor = System.Drawing.Color.Transparent;
			this.btn_setting.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_setting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_setting.Location = new System.Drawing.Point(0, 0);
			this.btn_setting.Name = "btn_setting";
			this.btn_setting.Size = new System.Drawing.Size(655, 508);
			this.btn_setting.TabIndex = 1;
			this.btn_setting.UseVisualStyleBackColor = false;
			this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
			// 
			// btn_psychophysics
			// 
			this.btn_psychophysics.BackColor = System.Drawing.Color.Transparent;
			this.btn_psychophysics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_psychophysics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btn_psychophysics.Location = new System.Drawing.Point(0, 0);
			this.btn_psychophysics.Name = "btn_psychophysics";
			this.btn_psychophysics.Size = new System.Drawing.Size(655, 508);
			this.btn_psychophysics.TabIndex = 0;
			this.btn_psychophysics.UseVisualStyleBackColor = false;
			this.btn_psychophysics.Click += new System.EventHandler(this.btn_psychophysics_Click);
			// 
			// COGLABnewUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(655, 508);
			this.Controls.Add(this.pnl_cntrl);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "COGLABnewUI";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Black;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.COGLABnewUI_FormClosed);
			this.Load += new System.EventHandler(this.COGLABnewUI_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.COGLABnewUI_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.COGLABnewUI_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.COGLABnewUI_KeyUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.COGLABnewUI_MouseDown);
			this.pnl_cntrl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer backUpdater;
		public System.Windows.Forms.Button btn_psychophysics;
		public System.Windows.Forms.Button btn_setting;
		public System.Windows.Forms.Button btn_psychology;
		public System.Windows.Forms.Button btn_linguistics;
		public System.Windows.Forms.Button btn_analysis;
		private System.Windows.Forms.Panel pnl_cntrl;
		public System.Windows.Forms.Button btn_trunner;
		private MetroFramework.Controls.MetroTile mtlMov;
		private MetroFramework.Controls.MetroTile mtlCls;
	}
}