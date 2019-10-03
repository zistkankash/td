namespace TaskDesigner.TaskLab
{
	partial class SlideThumb
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblId = new MetroFramework.Controls.MetroLabel();
			this.txtbxTime = new MetroFramework.Controls.MetroTextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(196, 114);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// lblId
			// 
			this.lblId.AutoSize = true;
			this.lblId.Location = new System.Drawing.Point(3, 124);
			this.lblId.Name = "lblId";
			this.lblId.Size = new System.Drawing.Size(0, 0);
			this.lblId.TabIndex = 1;
			// 
			// txtbxTime
			// 
			// 
			// 
			// 
			this.txtbxTime.CustomButton.Image = null;
			this.txtbxTime.CustomButton.Location = new System.Drawing.Point(95, 1);
			this.txtbxTime.CustomButton.Name = "";
			this.txtbxTime.CustomButton.Size = new System.Drawing.Size(21, 21);
			this.txtbxTime.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.txtbxTime.CustomButton.TabIndex = 1;
			this.txtbxTime.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.txtbxTime.CustomButton.UseSelectable = true;
			this.txtbxTime.CustomButton.Visible = false;
			this.txtbxTime.Lines = new string[0];
			this.txtbxTime.Location = new System.Drawing.Point(82, 123);
			this.txtbxTime.MaxLength = 32767;
			this.txtbxTime.Name = "txtbxTime";
			this.txtbxTime.PasswordChar = '\0';
			this.txtbxTime.PromptText = "Set Slide Time:";
			this.txtbxTime.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtbxTime.SelectedText = "";
			this.txtbxTime.SelectionLength = 0;
			this.txtbxTime.SelectionStart = 0;
			this.txtbxTime.ShortcutsEnabled = true;
			this.txtbxTime.Size = new System.Drawing.Size(117, 23);
			this.txtbxTime.TabIndex = 2;
			this.txtbxTime.UseSelectable = true;
			this.txtbxTime.WaterMark = "Set Slide Time:";
			this.txtbxTime.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.txtbxTime.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// SlidePanel
			// 
			this.Controls.Add(this.txtbxTime);
			this.Controls.Add(this.lblId);
			this.Controls.Add(this.pictureBox1);
			this.Name = "SlidePanel";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Size = new System.Drawing.Size(202, 152);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private MetroFramework.Controls.MetroLabel lblId;
		private MetroFramework.Controls.MetroTextBox txtbxTime;
	}
}
