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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDesigner));
			this.mainSplitter = new System.Windows.Forms.SplitContainer();
			this.splitterItems = new System.Windows.Forms.SplitContainer();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
			this.mainSplitter.Panel1.SuspendLayout();
			this.mainSplitter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitterItems)).BeginInit();
			this.splitterItems.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainSplitter
			// 
			this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplitter.Location = new System.Drawing.Point(0, 0);
			this.mainSplitter.Name = "mainSplitter";
			this.mainSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// mainSplitter.Panel1
			// 
			this.mainSplitter.Panel1.Controls.Add(this.splitterItems);
			// 
			// mainSplitter.Panel2
			// 
			this.mainSplitter.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.mainSplitter.Size = new System.Drawing.Size(1182, 637);
			this.mainSplitter.SplitterDistance = 510;
			this.mainSplitter.TabIndex = 0;
			// 
			// splitterItems
			// 
			this.splitterItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitterItems.Location = new System.Drawing.Point(0, 0);
			this.splitterItems.Name = "splitterItems";
			this.splitterItems.Size = new System.Drawing.Size(1182, 510);
			this.splitterItems.SplitterDistance = 243;
			this.splitterItems.TabIndex = 0;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Chrysanthemum.jpg");
			this.imageList1.Images.SetKeyName(1, "Desert.jpg");
			this.imageList1.Images.SetKeyName(2, "Hydrangeas.jpg");
			this.imageList1.Images.SetKeyName(3, "Penguins.jpg");
			this.imageList1.Images.SetKeyName(4, "Tulips.jpg");
			// 
			// MainDesigner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1182, 637);
			this.Controls.Add(this.mainSplitter);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainDesigner";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.TransparencyKey = System.Drawing.Color.White;
			this.Load += new System.EventHandler(this.MainDesigner_Load);
			this.mainSplitter.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
			this.mainSplitter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitterItems)).EndInit();
			this.splitterItems.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer mainSplitter;
		private System.Windows.Forms.SplitContainer splitterItems;
		private System.Windows.Forms.ImageList imageList1;
	}
}