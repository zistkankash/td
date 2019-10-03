namespace Psychophysics
{
	partial class MainDesigner
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDesigner));
			this.spltContainer = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.pbDesign = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.spltContainer)).BeginInit();
			this.spltContainer.Panel1.SuspendLayout();
			this.spltContainer.Panel2.SuspendLayout();
			this.spltContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbDesign)).BeginInit();
			this.SuspendLayout();
			// 
			// spltContainer
			// 
			this.spltContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltContainer.Location = new System.Drawing.Point(20, 60);
			this.spltContainer.Name = "spltContainer";
			// 
			// spltContainer.Panel1
			// 
			this.spltContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// spltContainer.Panel2
			// 
			this.spltContainer.Panel2.Controls.Add(this.pbDesign);
			this.spltContainer.Size = new System.Drawing.Size(1142, 557);
			this.spltContainer.SplitterDistance = 264;
			this.spltContainer.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 557);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// pbDesign
			// 
			this.pbDesign.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbDesign.Location = new System.Drawing.Point(0, 0);
			this.pbDesign.Name = "pbDesign";
			this.pbDesign.Size = new System.Drawing.Size(874, 557);
			this.pbDesign.TabIndex = 0;
			this.pbDesign.TabStop = false;
			// 
			// MainDesigner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1182, 637);
			this.Controls.Add(this.spltContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainDesigner";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Style = MetroFramework.MetroColorStyle.White;
			this.TransparencyKey = System.Drawing.Color.White;
			this.Load += new System.EventHandler(this.MainDesigner_Load);
			this.spltContainer.Panel1.ResumeLayout(false);
			this.spltContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spltContainer)).EndInit();
			this.spltContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbDesign)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer spltContainer;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.PictureBox pbDesign;
	}
}