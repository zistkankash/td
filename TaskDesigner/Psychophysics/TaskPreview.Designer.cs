using System.Drawing;
using System.Windows.Forms;
using TaskDesigner;

namespace Psychophysics
{
	partial class TaskPreview
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPreview));
			this.panel1 = new System.Windows.Forms.Panel();
			this.Task_Table = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.FramePerTask_LB1 = new System.Windows.Forms.Label();
			this.Time_LB = new System.Windows.Forms.Label();
			this.TotalTime_LB1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SelectTask_CB1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.NameTask_TB1 = new System.Windows.Forms.TextBox();
			this.NumTrial_TB1 = new System.Windows.Forms.TextBox();
			this.Start_PB = new System.Windows.Forms.Button();
			this.Save_BT = new System.Windows.Forms.Button();
			this.Path_TB = new System.Windows.Forms.TextBox();
			this.SaveOut_CB = new System.Windows.Forms.CheckBox();
			this.Stop_PB = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.Task_Table.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.Task_Table);
			this.panel1.Location = new System.Drawing.Point(28, 140);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(685, 130);
			this.panel1.TabIndex = 0;
			// 
			// Task_Table
			// 
			this.Task_Table.AutoSize = true;
			this.Task_Table.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Task_Table.ColumnCount = 5;
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53F));
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
			this.Task_Table.Controls.Add(this.label3, 4, 0);
			this.Task_Table.Controls.Add(this.FramePerTask_LB1, 4, 1);
			this.Task_Table.Controls.Add(this.Time_LB, 3, 0);
			this.Task_Table.Controls.Add(this.TotalTime_LB1, 3, 1);
			this.Task_Table.Controls.Add(this.label2, 2, 0);
			this.Task_Table.Controls.Add(this.SelectTask_CB1, 1, 1);
			this.Task_Table.Controls.Add(this.label1, 0, 0);
			this.Task_Table.Controls.Add(this.NameTask_TB1, 0, 1);
			this.Task_Table.Controls.Add(this.NumTrial_TB1, 2, 1);
			this.Task_Table.Location = new System.Drawing.Point(33, 25);
			this.Task_Table.Name = "Task_Table";
			this.Task_Table.RowCount = 2;
			this.Task_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.Task_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.Task_Table.Size = new System.Drawing.Size(629, 54);
			this.Task_Table.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(470, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Number of Frames";
			// 
			// FramePerTask_LB1
			// 
			this.FramePerTask_LB1.AutoSize = true;
			this.FramePerTask_LB1.Location = new System.Drawing.Point(470, 27);
			this.FramePerTask_LB1.Name = "FramePerTask_LB1";
			this.FramePerTask_LB1.Size = new System.Drawing.Size(13, 13);
			this.FramePerTask_LB1.TabIndex = 4;
			this.FramePerTask_LB1.Text = "0";
			// 
			// Time_LB
			// 
			this.Time_LB.AutoSize = true;
			this.Time_LB.Location = new System.Drawing.Point(384, 0);
			this.Time_LB.Name = "Time_LB";
			this.Time_LB.Size = new System.Drawing.Size(30, 13);
			this.Time_LB.TabIndex = 2;
			this.Time_LB.Text = "Time";
			// 
			// TotalTime_LB1
			// 
			this.TotalTime_LB1.AutoSize = true;
			this.TotalTime_LB1.Location = new System.Drawing.Point(384, 27);
			this.TotalTime_LB1.Name = "TotalTime_LB1";
			this.TotalTime_LB1.Size = new System.Drawing.Size(13, 13);
			this.TotalTime_LB1.TabIndex = 4;
			this.TotalTime_LB1.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(238, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Number of Repeats";
			// 
			// SelectTask_CB1
			// 
			this.SelectTask_CB1.FormattingEnabled = true;
			this.SelectTask_CB1.Items.AddRange(new object[] {
            "",
            "Normal",
            "Load"});
			this.SelectTask_CB1.Location = new System.Drawing.Point(113, 30);
			this.SelectTask_CB1.Name = "SelectTask_CB1";
			this.SelectTask_CB1.Size = new System.Drawing.Size(119, 21);
			this.SelectTask_CB1.TabIndex = 0;
			this.SelectTask_CB1.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name";
			// 
			// NameTask_TB1
			// 
			this.NameTask_TB1.Location = new System.Drawing.Point(3, 30);
			this.NameTask_TB1.Name = "NameTask_TB1";
			this.NameTask_TB1.Size = new System.Drawing.Size(87, 20);
			this.NameTask_TB1.TabIndex = 4;
			this.NameTask_TB1.Text = "1";
			this.NameTask_TB1.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);
			// 
			// NumTrial_TB1
			// 
			this.NumTrial_TB1.Location = new System.Drawing.Point(238, 30);
			this.NumTrial_TB1.Name = "NumTrial_TB1";
			this.NumTrial_TB1.Size = new System.Drawing.Size(86, 20);
			this.NumTrial_TB1.TabIndex = 4;
			this.NumTrial_TB1.Text = "1";
			this.NumTrial_TB1.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
			// 
			// Start_PB
			// 
			this.Start_PB.AutoEllipsis = true;
			this.Start_PB.BackColor = System.Drawing.Color.Transparent;
			this.Start_PB.BackgroundImage = global::TaskDesigner.Resource.next;
			this.Start_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Start_PB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Start_PB.FlatAppearance.BorderSize = 0;
			this.Start_PB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Start_PB.Location = new System.Drawing.Point(316, 358);
			this.Start_PB.Margin = new System.Windows.Forms.Padding(0);
			this.Start_PB.Name = "Start_PB";
			this.Start_PB.Size = new System.Drawing.Size(48, 48);
			this.Start_PB.TabIndex = 2;
			this.Start_PB.TabStop = false;
			this.Start_PB.UseMnemonic = false;
			this.Start_PB.UseVisualStyleBackColor = false;
			this.Start_PB.Click += new System.EventHandler(this.Start_PB_Click);
			// 
			// Save_BT
			// 
			this.Save_BT.BackColor = System.Drawing.Color.White;
			this.Save_BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Save_BT.FlatAppearance.BorderSize = 0;
			this.Save_BT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Save_BT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Save_BT.Location = new System.Drawing.Point(292, 310);
			this.Save_BT.Name = "Save_BT";
			this.Save_BT.Size = new System.Drawing.Size(26, 25);
			this.Save_BT.TabIndex = 24;
			this.Save_BT.Text = "...";
			this.Save_BT.UseVisualStyleBackColor = false;
			this.Save_BT.Click += new System.EventHandler(this.Save_BT_Click);
			// 
			// Path_TB
			// 
			this.Path_TB.Location = new System.Drawing.Point(67, 312);
			this.Path_TB.Name = "Path_TB";
			this.Path_TB.Size = new System.Drawing.Size(219, 20);
			this.Path_TB.TabIndex = 23;
			// 
			// SaveOut_CB
			// 
			this.SaveOut_CB.AutoSize = true;
			this.SaveOut_CB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.SaveOut_CB.Location = new System.Drawing.Point(67, 289);
			this.SaveOut_CB.Name = "SaveOut_CB";
			this.SaveOut_CB.Size = new System.Drawing.Size(113, 17);
			this.SaveOut_CB.TabIndex = 22;
			this.SaveOut_CB.Text = "Save Data Stream";
			this.SaveOut_CB.UseVisualStyleBackColor = true;
			this.SaveOut_CB.CheckedChanged += new System.EventHandler(this.SaveOut_CB_CheckedChanged);
			// 
			// Stop_PB
			// 
			this.Stop_PB.AutoEllipsis = true;
			this.Stop_PB.BackColor = System.Drawing.Color.Transparent;
			this.Stop_PB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Stop_PB.BackgroundImage")));
			this.Stop_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Stop_PB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Stop_PB.FlatAppearance.BorderSize = 0;
			this.Stop_PB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Stop_PB.Location = new System.Drawing.Point(381, 358);
			this.Stop_PB.Margin = new System.Windows.Forms.Padding(0);
			this.Stop_PB.Name = "Stop_PB";
			this.Stop_PB.Size = new System.Drawing.Size(48, 48);
			this.Stop_PB.TabIndex = 25;
			this.Stop_PB.TabStop = false;
			this.Stop_PB.UseMnemonic = false;
			this.Stop_PB.UseVisualStyleBackColor = false;
			this.Stop_PB.Click += new System.EventHandler(this.Stop_PB_Click);
			// 
			// TaskPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.ClientSize = new System.Drawing.Size(737, 455);
			this.Controls.Add(this.Stop_PB);
			this.Controls.Add(this.Save_BT);
			this.Controls.Add(this.Path_TB);
			this.Controls.Add(this.SaveOut_CB);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Start_PB);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TaskPreview";
			this.Tag = "TaskP";
			this.Text = "TaskPreview";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskPreview_FormClosing);
			this.Load += new System.EventHandler(this.TaskPreview_Load);
			this.VisibleChanged += new System.EventHandler(this.TaskPreview_VisibleChanged);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.Task_Table.ResumeLayout(false);
			this.Task_Table.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel Task_Table;
		private System.Windows.Forms.TextBox NumTrial_TB1;
		private System.Windows.Forms.Label TotalTime_LB1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label Time_LB;
		private System.Windows.Forms.ComboBox SelectTask_CB1;
		private System.Windows.Forms.Button Start_PB;
		private Label label3;
		private Label FramePerTask_LB1;
		private Label label1;
		private TextBox NameTask_TB1;
		private Button Save_BT;
		private TextBox Path_TB;
		private CheckBox SaveOut_CB;
		private Button Stop_PB;
	}
}