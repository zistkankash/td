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
			this.btnHeatPic = new System.Windows.Forms.Button();
			this.txtHeatPic = new System.Windows.Forms.TextBox();
			this.btnHeatPath = new System.Windows.Forms.Button();
			this.txtHeatPath = new System.Windows.Forms.TextBox();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.btnCreateHeatMap = new System.Windows.Forms.Button();
			this.pbHeat = new System.Windows.Forms.PictureBox();
			this.txtSave = new System.Windows.Forms.TextBox();
			this.chkSave = new System.Windows.Forms.CheckBox();
			this.btnBatchAnalyz = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbHeat)).BeginInit();
			this.SuspendLayout();
			// 
			// btnHeatPic
			// 
			this.btnHeatPic.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnHeatPic.Location = new System.Drawing.Point(517, 615);
			this.btnHeatPic.Name = "btnHeatPic";
			this.btnHeatPic.Size = new System.Drawing.Size(75, 23);
			this.btnHeatPic.TabIndex = 9;
			this.btnHeatPic.Text = "Pic";
			this.btnHeatPic.UseVisualStyleBackColor = true;
			this.btnHeatPic.Click += new System.EventHandler(this.btnHeatPic_Click);
			// 
			// txtHeatPic
			// 
			this.txtHeatPic.Location = new System.Drawing.Point(314, 617);
			this.txtHeatPic.Name = "txtHeatPic";
			this.txtHeatPic.Size = new System.Drawing.Size(200, 20);
			this.txtHeatPic.TabIndex = 8;
			// 
			// btnHeatPath
			// 
			this.btnHeatPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnHeatPath.Location = new System.Drawing.Point(203, 615);
			this.btnHeatPath.Name = "btnHeatPath";
			this.btnHeatPath.Size = new System.Drawing.Size(75, 23);
			this.btnHeatPath.TabIndex = 7;
			this.btnHeatPath.Text = "Path";
			this.btnHeatPath.UseVisualStyleBackColor = true;
			this.btnHeatPath.Click += new System.EventHandler(this.btnHeatPath_Click);
			// 
			// txtHeatPath
			// 
			this.txtHeatPath.Location = new System.Drawing.Point(0, 617);
			this.txtHeatPath.Name = "txtHeatPath";
			this.txtHeatPath.Size = new System.Drawing.Size(200, 20);
			this.txtHeatPath.TabIndex = 6;
			// 
			// cmbType
			// 
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Items.AddRange(new object[] {
            "Heat Map",
            "Heat Movie",
            "Heat Point",
            "Heat Chart",
            "Chart Movie"});
			this.cmbType.Location = new System.Drawing.Point(673, 615);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(121, 21);
			this.cmbType.TabIndex = 12;
			// 
			// btnCreateHeatMap
			// 
			this.btnCreateHeatMap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnCreateHeatMap.Location = new System.Drawing.Point(825, 613);
			this.btnCreateHeatMap.Name = "btnCreateHeatMap";
			this.btnCreateHeatMap.Size = new System.Drawing.Size(75, 23);
			this.btnCreateHeatMap.TabIndex = 10;
			this.btnCreateHeatMap.Text = "Start";
			this.btnCreateHeatMap.UseVisualStyleBackColor = true;
			this.btnCreateHeatMap.Click += new System.EventHandler(this.btnCreateHeatMap_Click);
			// 
			// pbHeat
			// 
			this.pbHeat.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pbHeat.Location = new System.Drawing.Point(0, 0);
			this.pbHeat.Name = "pbHeat";
			this.pbHeat.Size = new System.Drawing.Size(900, 600);
			this.pbHeat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbHeat.TabIndex = 0;
			this.pbHeat.TabStop = false;
			// 
			// txtSave
			// 
			this.txtSave.Enabled = false;
			this.txtSave.Location = new System.Drawing.Point(754, 691);
			this.txtSave.Name = "txtSave";
			this.txtSave.Size = new System.Drawing.Size(200, 20);
			this.txtSave.TabIndex = 13;
			// 
			// chkSave
			// 
			this.chkSave.AutoSize = true;
			this.chkSave.Location = new System.Drawing.Point(697, 693);
			this.chkSave.Name = "chkSave";
			this.chkSave.Size = new System.Drawing.Size(51, 17);
			this.chkSave.TabIndex = 15;
			this.chkSave.Text = "Save";
			this.chkSave.UseVisualStyleBackColor = true;
			this.chkSave.CheckedChanged += new System.EventHandler(this.chkSave_CheckedChanged);
			// 
			// btnBatchAnalyz
			// 
			this.btnBatchAnalyz.Location = new System.Drawing.Point(12, 687);
			this.btnBatchAnalyz.Name = "btnBatchAnalyz";
			this.btnBatchAnalyz.Size = new System.Drawing.Size(75, 23);
			this.btnBatchAnalyz.TabIndex = 16;
			this.btnBatchAnalyz.Text = "Start Batch";
			this.btnBatchAnalyz.UseVisualStyleBackColor = true;
			this.btnBatchAnalyz.Click += new System.EventHandler(this.btnBatchAnalyz_Click);
			// 
			// HeatMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 726);
			this.Controls.Add(this.btnBatchAnalyz);
			this.Controls.Add(this.chkSave);
			this.Controls.Add(this.txtSave);
			this.Controls.Add(this.cmbType);
			this.Controls.Add(this.btnCreateHeatMap);
			this.Controls.Add(this.btnHeatPic);
			this.Controls.Add(this.txtHeatPic);
			this.Controls.Add(this.btnHeatPath);
			this.Controls.Add(this.txtHeatPath);
			this.Controls.Add(this.pbHeat);
			this.Name = "HeatMap";
			this.Text = "HeatMap";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HeatMap_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.pbHeat)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHeat;
        private System.Windows.Forms.Button btnCreateHeatMap;
        private System.Windows.Forms.Button btnHeatPic;
        private System.Windows.Forms.TextBox txtHeatPic;
        private System.Windows.Forms.Button btnHeatPath;
        private System.Windows.Forms.TextBox txtHeatPath;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.CheckBox chkSave;
		private System.Windows.Forms.Button btnBatchAnalyz;
	}
}