namespace TaskRunning
{
	partial class TaskRunner
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskRunner));
			this.pctbxFrm = new System.Windows.Forms.PictureBox();
			this.frameUpdater = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pctbxFrm)).BeginInit();
			this.SuspendLayout();
			// 
			// pctbxFrm
			// 
			this.pctbxFrm.BackColor = System.Drawing.Color.White;
			this.pctbxFrm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pctbxFrm.Location = new System.Drawing.Point(0, 0);
			this.pctbxFrm.Name = "pctbxFrm";
			this.pctbxFrm.Size = new System.Drawing.Size(284, 262);
			this.pctbxFrm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pctbxFrm.TabIndex = 0;
			this.pctbxFrm.TabStop = false;
			this.pctbxFrm.Click += new System.EventHandler(this.pctbxFrm_Click);
			this.pctbxFrm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctbxFrm_MouseMove);
			// 
			// frameUpdater
			// 
			this.frameUpdater.Enabled = true;
			this.frameUpdater.Interval = 40;
			this.frameUpdater.Tick += new System.EventHandler(this.frameUpdater_Tick);
			// 
			// TaskRunner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.pctbxFrm);
			this.Cursor = System.Windows.Forms.Cursors.No;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TaskRunner";
			this.Text = "TaskRunner";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.TaskRunner_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TaskRunner_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.pctbxFrm)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pctbxFrm;
		private System.Windows.Forms.Timer frameUpdater;
	}
}