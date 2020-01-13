namespace TaskDesigner
{
	partial class HelpForm
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
			this.pnlNetHelp = new System.Windows.Forms.Panel();
			this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
			this.pnlNetHelp.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlNetHelp
			// 
			this.pnlNetHelp.Controls.Add(this.richEditControl1);
			this.pnlNetHelp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlNetHelp.Location = new System.Drawing.Point(0, 0);
			this.pnlNetHelp.Name = "pnlNetHelp";
			this.pnlNetHelp.Size = new System.Drawing.Size(989, 562);
			this.pnlNetHelp.TabIndex = 0;
			// 
			// richEditControl1
			// 
			this.richEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richEditControl1.Location = new System.Drawing.Point(0, 0);
			this.richEditControl1.Name = "richEditControl1";
			this.richEditControl1.ReadOnly = true;
			this.richEditControl1.Size = new System.Drawing.Size(989, 562);
			this.richEditControl1.TabIndex = 1;
			this.richEditControl1.Click += new System.EventHandler(this.richEditControl1_Click);
			// 
			// HelpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
			this.ClientSize = new System.Drawing.Size(989, 562);
			this.Controls.Add(this.pnlNetHelp);
			this.Name = "HelpForm";
			this.Text = "HelpForm";
			this.Load += new System.EventHandler(this.HelpForm_Load);
			this.pnlNetHelp.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlNetHelp;
		private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
	}
}