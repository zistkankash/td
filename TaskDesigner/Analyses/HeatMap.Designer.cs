namespace Analyses
{
    partial class HeatMap
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnBatchAnalyz = new System.Windows.Forms.Button();
			this.chkSave = new System.Windows.Forms.CheckBox();
			this.txtSave = new System.Windows.Forms.TextBox();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.btnCreateHeatMap = new System.Windows.Forms.Button();
			this.btnHeatPic = new System.Windows.Forms.Button();
			this.txtHeatPic = new System.Windows.Forms.TextBox();
			this.btnHeatPath = new System.Windows.Forms.Button();
			this.txtHeatPath = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pbHeat = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbHeat)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnBatchAnalyz);
			this.panel1.Controls.Add(this.chkSave);
			this.panel1.Controls.Add(this.txtSave);
			this.panel1.Controls.Add(this.cmbType);
			this.panel1.Controls.Add(this.btnCreateHeatMap);
			this.panel1.Controls.Add(this.btnHeatPic);
			this.panel1.Controls.Add(this.txtHeatPic);
			this.panel1.Controls.Add(this.btnHeatPath);
			this.panel1.Controls.Add(this.txtHeatPath);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 606);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1008, 120);
			this.panel1.TabIndex = 1;
			// 
			// btnBatchAnalyz
			// 
			this.btnBatchAnalyz.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnBatchAnalyz.Location = new System.Drawing.Point(17, 87);
			this.btnBatchAnalyz.Name = "btnBatchAnalyz";
			this.btnBatchAnalyz.Size = new System.Drawing.Size(75, 23);
			this.btnBatchAnalyz.TabIndex = 25;
			this.btnBatchAnalyz.Text = "Start Batch";
			this.btnBatchAnalyz.UseVisualStyleBackColor = true;
			this.btnBatchAnalyz.Visible = false;
			// 
			// chkSave
			// 
			this.chkSave.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkSave.AutoSize = true;
			this.chkSave.Location = new System.Drawing.Point(605, 91);
			this.chkSave.Name = "chkSave";
			this.chkSave.Size = new System.Drawing.Size(51, 17);
			this.chkSave.TabIndex = 24;
			this.chkSave.Text = "Save";
			this.chkSave.UseVisualStyleBackColor = true;
			this.chkSave.CheckedChanged += new System.EventHandler(this.chkSave_CheckedChanged);
			this.chkSave.Click += new System.EventHandler(this.chkSave_CheckedChanged);
			// 
			// txtSave
			// 
			this.txtSave.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtSave.Enabled = false;
			this.txtSave.Location = new System.Drawing.Point(662, 89);
			this.txtSave.Name = "txtSave";
			this.txtSave.Size = new System.Drawing.Size(319, 20);
			this.txtSave.TabIndex = 23;
			// 
			// cmbType
			// 
			this.cmbType.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Items.AddRange(new object[] {
            "Heat Map",
            "Heat Movie",
            "Heat Point",
            "Heat Chart",
            "Chart Movie"});
			this.cmbType.Location = new System.Drawing.Point(819, 18);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(143, 21);
			this.cmbType.TabIndex = 22;
			// 
			// btnCreateHeatMap
			// 
			this.btnCreateHeatMap.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnCreateHeatMap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnCreateHeatMap.Location = new System.Drawing.Point(837, 50);
			this.btnCreateHeatMap.Name = "btnCreateHeatMap";
			this.btnCreateHeatMap.Size = new System.Drawing.Size(104, 23);
			this.btnCreateHeatMap.TabIndex = 21;
			this.btnCreateHeatMap.Text = "Analyze";
			this.btnCreateHeatMap.UseVisualStyleBackColor = true;
			this.btnCreateHeatMap.Click += new System.EventHandler(this.btnCreateHeatMap_Click);
			// 
			// btnHeatPic
			// 
			this.btnHeatPic.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnHeatPic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnHeatPic.Location = new System.Drawing.Point(420, 50);
			this.btnHeatPic.Name = "btnHeatPic";
			this.btnHeatPic.Size = new System.Drawing.Size(153, 23);
			this.btnHeatPic.TabIndex = 20;
			this.btnHeatPic.Text = "Pick Task or Image";
			this.btnHeatPic.UseVisualStyleBackColor = true;
			this.btnHeatPic.Click += new System.EventHandler(this.btnHeatPic_Click);
			// 
			// txtHeatPic
			// 
			this.txtHeatPic.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtHeatPic.Location = new System.Drawing.Point(371, 19);
			this.txtHeatPic.Name = "txtHeatPic";
			this.txtHeatPic.Size = new System.Drawing.Size(285, 20);
			this.txtHeatPic.TabIndex = 19;
			// 
			// btnHeatPath
			// 
			this.btnHeatPath.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnHeatPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnHeatPath.Location = new System.Drawing.Point(93, 50);
			this.btnHeatPath.Name = "btnHeatPath";
			this.btnHeatPath.Size = new System.Drawing.Size(150, 23);
			this.btnHeatPath.TabIndex = 18;
			this.btnHeatPath.Text = "Pick Task Output File";
			this.btnHeatPath.UseVisualStyleBackColor = true;
			this.btnHeatPath.Click += new System.EventHandler(this.btnHeatPath_Click);
			// 
			// txtHeatPath
			// 
			this.txtHeatPath.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtHeatPath.Location = new System.Drawing.Point(23, 19);
			this.txtHeatPath.Name = "txtHeatPath";
			this.txtHeatPath.Size = new System.Drawing.Size(307, 20);
			this.txtHeatPath.TabIndex = 17;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.pbHeat);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1008, 600);
			this.panel2.TabIndex = 2;
			// 
			// pbHeat
			// 
			this.pbHeat.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pbHeat.Dock = System.Windows.Forms.DockStyle.Top;
			this.pbHeat.Location = new System.Drawing.Point(0, 0);
			this.pbHeat.Name = "pbHeat";
			this.pbHeat.Size = new System.Drawing.Size(1008, 600);
			this.pbHeat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbHeat.TabIndex = 1;
			this.pbHeat.TabStop = false;
			// 
			// HeatMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 726);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "HeatMap";
			this.Text = "HeatMap";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HeatMap_FormClosing);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbHeat)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnBatchAnalyz;
		private System.Windows.Forms.CheckBox chkSave;
		private System.Windows.Forms.TextBox txtSave;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Button btnCreateHeatMap;
		private System.Windows.Forms.Button btnHeatPic;
		private System.Windows.Forms.TextBox txtHeatPic;
		private System.Windows.Forms.Button btnHeatPath;
		private System.Windows.Forms.TextBox txtHeatPath;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pbHeat;
	}
}