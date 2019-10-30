using TaskDesigner;
namespace Basics
{
    partial class frmCoolForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Task_Table = new System.Windows.Forms.TableLayoutPanel();
            this.NumTrial_TB1 = new System.Windows.Forms.TextBox();
            this.FramePerTask_LB1 = new System.Windows.Forms.Label();
            this.TotalTime_LB1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Time_LB = new System.Windows.Forms.Label();
            this.SelectTask_CB1 = new System.Windows.Forms.ComboBox();
            this.Start_PB = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.Task_Table.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.Task_Table);
            this.panel1.Location = new System.Drawing.Point(88, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 130);
            this.panel1.TabIndex = 3;
            // 
            // Task_Table
            // 
            this.Task_Table.AutoSize = true;
            this.Task_Table.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Task_Table.ColumnCount = 4;
            this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53F));
            this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.Task_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.Task_Table.Controls.Add(this.NumTrial_TB1, 1, 1);
            this.Task_Table.Controls.Add(this.FramePerTask_LB1, 3, 1);
            this.Task_Table.Controls.Add(this.TotalTime_LB1, 2, 1);
            this.Task_Table.Controls.Add(this.label3, 3, 0);
            this.Task_Table.Controls.Add(this.label2, 1, 0);
            this.Task_Table.Controls.Add(this.Time_LB, 2, 0);
            this.Task_Table.Controls.Add(this.SelectTask_CB1, 0, 1);
            this.Task_Table.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Task_Table.Location = new System.Drawing.Point(40, 15);
            this.Task_Table.Name = "Task_Table";
            this.Task_Table.RowCount = 2;
            this.Task_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Task_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Task_Table.Size = new System.Drawing.Size(614, 54);
            this.Task_Table.TabIndex = 3;
            // 
            // NumTrial_TB1
            // 
            this.NumTrial_TB1.Location = new System.Drawing.Point(128, 30);
            this.NumTrial_TB1.Name = "NumTrial_TB1";
            this.NumTrial_TB1.Size = new System.Drawing.Size(100, 21);
            this.NumTrial_TB1.TabIndex = 4;
            this.NumTrial_TB1.Text = "1";
            // 
            // FramePerTask_LB1
            // 
            this.FramePerTask_LB1.AutoSize = true;
            this.FramePerTask_LB1.Location = new System.Drawing.Point(382, 27);
            this.FramePerTask_LB1.Name = "FramePerTask_LB1";
            this.FramePerTask_LB1.Size = new System.Drawing.Size(13, 13);
            this.FramePerTask_LB1.TabIndex = 4;
            this.FramePerTask_LB1.Text = "0";
            // 
            // TotalTime_LB1
            // 
            this.TotalTime_LB1.AutoSize = true;
            this.TotalTime_LB1.Location = new System.Drawing.Point(268, 27);
            this.TotalTime_LB1.Name = "TotalTime_LB1";
            this.TotalTime_LB1.Size = new System.Drawing.Size(13, 13);
            this.TotalTime_LB1.TabIndex = 4;
            this.TotalTime_LB1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Number of Frames";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Repeatation";
            // 
            // Time_LB
            // 
            this.Time_LB.AutoSize = true;
            this.Time_LB.Location = new System.Drawing.Point(268, 0);
            this.Time_LB.Name = "Time_LB";
            this.Time_LB.Size = new System.Drawing.Size(29, 13);
            this.Time_LB.TabIndex = 2;
            this.Time_LB.Text = "Time";
            // 
            // SelectTask_CB1
            // 
            this.SelectTask_CB1.FormattingEnabled = true;
            this.SelectTask_CB1.Items.AddRange(new object[] {
            "",
            "Normal",
            "MGS",
            "VGS",
            "Posner",
            "Discrimination",
            "Delete"});
            this.SelectTask_CB1.Location = new System.Drawing.Point(3, 30);
            this.SelectTask_CB1.Name = "SelectTask_CB1";
            this.SelectTask_CB1.Size = new System.Drawing.Size(119, 21);
            this.SelectTask_CB1.TabIndex = 0;
            // 
            // Start_PB
            // 
            this.Start_PB.AutoEllipsis = true;
            this.Start_PB.BackColor = System.Drawing.Color.Transparent;
            this.Start_PB.BackgroundImage = Resource.next;
            this.Start_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Start_PB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Start_PB.FlatAppearance.BorderSize = 0;
            this.Start_PB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_PB.Location = new System.Drawing.Point(400, 462);
            this.Start_PB.Margin = new System.Windows.Forms.Padding(0);
            this.Start_PB.Name = "Start_PB";
            this.Start_PB.Size = new System.Drawing.Size(48, 48);
            this.Start_PB.TabIndex = 4;
            this.Start_PB.TabStop = false;
            this.Start_PB.UseMnemonic = false;
            this.Start_PB.UseVisualStyleBackColor = false;
            // 
            // frmCoolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(886, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Start_PB);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCoolForm";
            this.Text = "XCoolForm";
            this.Load += new System.EventHandler(this.frmCoolForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Task_Table.ResumeLayout(false);
            this.Task_Table.PerformLayout();
            this.ResumeLayout(false);

        }






        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel Task_Table;
        private System.Windows.Forms.TextBox NumTrial_TB1;
        private System.Windows.Forms.Label FramePerTask_LB1;
        private System.Windows.Forms.Label TotalTime_LB1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Time_LB;
        private System.Windows.Forms.ComboBox SelectTask_CB1;
        private System.Windows.Forms.Button Start_PB;
    }
}

