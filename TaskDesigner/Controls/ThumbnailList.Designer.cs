namespace Controls
{
	partial class ThumbnailList
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
			this.components = new System.ComponentModel.Container();
			this.tblPnlThumb = new System.Windows.Forms.TableLayoutPanel();
			this.tltlpHelp = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// tblPnlThumb
			// 
			this.tblPnlThumb.AutoScroll = true;
			this.tblPnlThumb.ColumnCount = 1;
			this.tblPnlThumb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPnlThumb.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPnlThumb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblPnlThumb.Location = new System.Drawing.Point(0, 0);
			this.tblPnlThumb.Name = "tblPnlThumb";
			this.tblPnlThumb.RowCount = 1;
			this.tblPnlThumb.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPnlThumb.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblPnlThumb.Size = new System.Drawing.Size(241, 161);
			this.tblPnlThumb.TabIndex = 0;
			// 
			// ThumbnailList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tblPnlThumb);
			this.Name = "ThumbnailList";
			this.Size = new System.Drawing.Size(241, 161);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ThumbnailList_MouseClick);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tblPnlThumb;
		private System.Windows.Forms.ToolTip tltlpHelp;
	}
}
