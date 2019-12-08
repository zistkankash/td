using System.Drawing;
using System.Windows.Forms;
using TaskDesigner;

namespace Basics
{
	partial class PsycoPhysicTask
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PsycoPhysicTask));
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.Task_Table = new System.Windows.Forms.TableLayoutPanel();
			this.FramePerTask_LB0 = new System.Windows.Forms.Label();
			this.TotalTime_LB0 = new System.Windows.Forms.Label();
			this.SelectTask_CB0 = new System.Windows.Forms.ComboBox();
			this.NumTrial_TB0 = new System.Windows.Forms.TextBox();
			this.NameTask_TB0 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Time_LB = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Start_PB = new System.Windows.Forms.Button();
			this.Stop_PB = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.chkRandom = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.Task_Table.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.Task_Table);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.Time_LB);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(28, 43);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(685, 300);
			this.panel1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(539, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Number of Frames";
			// 
			// Task_Table
			// 
			this.Task_Table.AutoScroll = true;
			this.Task_Table.AutoSize = true;
			this.Task_Table.ColumnCount = 5;
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
			this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
			this.Task_Table.Controls.Add(this.FramePerTask_LB0, 4, 0);
			this.Task_Table.Controls.Add(this.TotalTime_LB0, 3, 0);
			this.Task_Table.Controls.Add(this.SelectTask_CB0, 1, 0);
			this.Task_Table.Controls.Add(this.NumTrial_TB0, 2, 0);
			this.Task_Table.Controls.Add(this.NameTask_TB0, 0, 0);
			this.Task_Table.Location = new System.Drawing.Point(16, 53);
			this.Task_Table.Name = "Task_Table";
			this.Task_Table.RowCount = 1;
			this.Task_Table.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.Task_Table.Size = new System.Drawing.Size(637, 30);
			this.Task_Table.TabIndex = 3;
			this.Task_Table.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Task_Table_Scroll);
			// 
			// FramePerTask_LB0
			// 
			this.FramePerTask_LB0.AutoSize = true;
			this.FramePerTask_LB0.Location = new System.Drawing.Point(529, 0);
			this.FramePerTask_LB0.Name = "FramePerTask_LB0";
			this.FramePerTask_LB0.Size = new System.Drawing.Size(13, 13);
			this.FramePerTask_LB0.TabIndex = 4;
			this.FramePerTask_LB0.Text = "0";
			// 
			// TotalTime_LB0
			// 
			this.TotalTime_LB0.AutoSize = true;
			this.TotalTime_LB0.Location = new System.Drawing.Point(467, 0);
			this.TotalTime_LB0.Name = "TotalTime_LB0";
			this.TotalTime_LB0.Size = new System.Drawing.Size(13, 13);
			this.TotalTime_LB0.TabIndex = 4;
			this.TotalTime_LB0.Text = "0";
			// 
			// SelectTask_CB0
			// 
			this.SelectTask_CB0.FormattingEnabled = true;
			this.SelectTask_CB0.Items.AddRange(new object[] {
            "",
            "Design"});
			this.SelectTask_CB0.Location = new System.Drawing.Point(167, 3);
			this.SelectTask_CB0.Name = "SelectTask_CB0";
			this.SelectTask_CB0.Size = new System.Drawing.Size(94, 21);
			this.SelectTask_CB0.TabIndex = 4;
			this.SelectTask_CB0.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
			// 
			// NumTrial_TB0
			// 
			this.NumTrial_TB0.Location = new System.Drawing.Point(336, 3);
			this.NumTrial_TB0.Name = "NumTrial_TB0";
			this.NumTrial_TB0.Size = new System.Drawing.Size(56, 20);
			this.NumTrial_TB0.TabIndex = 4;
			this.NumTrial_TB0.Text = "1";
			this.NumTrial_TB0.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
			// 
			// NameTask_TB0
			// 
			this.NameTask_TB0.Location = new System.Drawing.Point(3, 3);
			this.NameTask_TB0.Name = "NameTask_TB0";
			this.NameTask_TB0.Size = new System.Drawing.Size(104, 20);
			this.NameTask_TB0.TabIndex = 0;
			this.NameTask_TB0.Text = "1";
			this.NameTask_TB0.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name";
			// 
			// Time_LB
			// 
			this.Time_LB.AutoSize = true;
			this.Time_LB.Location = new System.Drawing.Point(473, 22);
			this.Time_LB.Name = "Time_LB";
			this.Time_LB.Size = new System.Drawing.Size(55, 13);
			this.Time_LB.TabIndex = 2;
			this.Time_LB.Text = "Time (ms):";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(177, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Operation Selection";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(344, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Number of Repeats";
			// 
			// Start_PB
			// 
			this.Start_PB.AutoEllipsis = true;
			this.Start_PB.BackColor = System.Drawing.Color.Transparent;
			this.Start_PB.BackgroundImage = global::TaskDesigner.Resource.next;
			this.Start_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Start_PB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.Start_PB.FlatAppearance.BorderSize = 0;
			this.Start_PB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.Start_PB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.Start_PB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Start_PB.Location = new System.Drawing.Point(28, 379);
			this.Start_PB.Margin = new System.Windows.Forms.Padding(0);
			this.Start_PB.Name = "Start_PB";
			this.Start_PB.Size = new System.Drawing.Size(48, 48);
			this.Start_PB.TabIndex = 2;
			this.Start_PB.TabStop = false;
			this.toolTip1.SetToolTip(this.Start_PB, "Preview of task");
			this.Start_PB.UseMnemonic = false;
			this.Start_PB.UseVisualStyleBackColor = false;
			this.Start_PB.Click += new System.EventHandler(this.Start_PB_Click);
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
			this.Stop_PB.Location = new System.Drawing.Point(665, 379);
			this.Stop_PB.Margin = new System.Windows.Forms.Padding(0);
			this.Stop_PB.Name = "Stop_PB";
			this.Stop_PB.Size = new System.Drawing.Size(48, 48);
			this.Stop_PB.TabIndex = 25;
			this.Stop_PB.TabStop = false;
			this.Stop_PB.UseMnemonic = false;
			this.Stop_PB.UseVisualStyleBackColor = false;
			this.Stop_PB.Visible = false;
			this.Stop_PB.Click += new System.EventHandler(this.Stop_PB_Click);
			// 
			// chkRandom
			// 
			this.chkRandom.AutoSize = true;
			this.chkRandom.ForeColor = System.Drawing.Color.Black;
			this.chkRandom.Location = new System.Drawing.Point(93, 396);
			this.chkRandom.Name = "chkRandom";
			this.chkRandom.Size = new System.Drawing.Size(134, 17);
			this.chkRandom.TabIndex = 26;
			this.chkRandom.Text = "Make Random Repeat";
			this.chkRandom.UseVisualStyleBackColor = true;
			// 
			// PsycoPhysicTask
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.ClientSize = new System.Drawing.Size(737, 455);
			this.Controls.Add(this.chkRandom);
			this.Controls.Add(this.Stop_PB);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Start_PB);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PsycoPhysicTask";
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
		private System.Windows.Forms.TextBox NumTrial_TB0;
		private System.Windows.Forms.Label TotalTime_LB0;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label Time_LB;
		private System.Windows.Forms.ComboBox SelectTask_CB0;
		private System.Windows.Forms.Button Start_PB;
		private Label label3;
		private Label FramePerTask_LB0;
		private Label label1;
		private TextBox NameTask_TB0;
		private Button Stop_PB;
		private Label label4;
		private ToolTip toolTip1;
		private CheckBox chkRandom;
	}
}