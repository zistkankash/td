namespace Basics
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
			this.btnMinmiz = new System.Windows.Forms.Button();
			this.btnCls = new System.Windows.Forms.Button();
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
			this.pnl_cntrl.BackgroundImage = global::TaskDesigner.Resource.main3_final;
			this.pnl_cntrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pnl_cntrl.Controls.Add(this.btnMinmiz);
			this.pnl_cntrl.Controls.Add(this.btnCls);
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
			// btnMinmiz
			// 
			this.btnMinmiz.FlatAppearance.BorderSize = 0;
			this.btnMinmiz.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnMinmiz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnMinmiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMinmiz.Location = new System.Drawing.Point(90, 104);
			this.btnMinmiz.Name = "btnMinmiz";
			this.btnMinmiz.Size = new System.Drawing.Size(33, 31);
			this.btnMinmiz.TabIndex = 8;
			this.btnMinmiz.UseVisualStyleBackColor = true;
			this.btnMinmiz.Click += new System.EventHandler(this.btnMinmiz_Click);
			// 
			// btnCls
			// 
			this.btnCls.FlatAppearance.BorderSize = 0;
			this.btnCls.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnCls.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnCls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCls.Location = new System.Drawing.Point(530, 95);
			this.btnCls.Name = "btnCls";
			this.btnCls.Size = new System.Drawing.Size(36, 30);
			this.btnCls.TabIndex = 6;
			this.btnCls.UseVisualStyleBackColor = true;
			this.btnCls.Click += new System.EventHandler(this.mtlCls_Click);
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
			this.btn_trunner.MouseEnter += new System.EventHandler(this.btn_trunner_MouseEnter);
			this.btn_trunner.MouseLeave += new System.EventHandler(this.btn_trunner_MouseLeave);
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
			this.btn_analysis.MouseEnter += new System.EventHandler(this.btn_analysis_MouseEnter);
			this.btn_analysis.MouseLeave += new System.EventHandler(this.btn_analysis_MouseLeave);
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
			this.btn_linguistics.MouseEnter += new System.EventHandler(this.btn_linguistics_MouseEnter);
			this.btn_linguistics.MouseLeave += new System.EventHandler(this.btn_linguistics_MouseLeave);
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
			this.btn_psychology.MouseEnter += new System.EventHandler(this.btn_psychology_MouseEnter);
			this.btn_psychology.MouseLeave += new System.EventHandler(this.btn_psychology_MouseLeave);
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
			this.btn_setting.MouseEnter += new System.EventHandler(this.btn_setting_MouseEnter);
			this.btn_setting.MouseLeave += new System.EventHandler(this.btn_setting_MouseLeave);
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
			this.btn_psychophysics.MouseEnter += new System.EventHandler(this.btn_psychophysics_MouseEnter);
			this.btn_psychophysics.MouseLeave += new System.EventHandler(this.btn_psychophysics_MouseLeave);
			// 
			// COGLABnewUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(655, 508);
			this.Controls.Add(this.pnl_cntrl);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "COGLABnewUI";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
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
		private System.Windows.Forms.Button btnMinmiz;
		private System.Windows.Forms.Button btnCls;
	}
}