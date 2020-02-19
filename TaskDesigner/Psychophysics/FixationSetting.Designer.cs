namespace Psychophysics
{
    partial class FixationSetting
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
            this.CheckFix_CB = new System.Windows.Forms.CheckBox();
            this.HoldFix_CB = new System.Windows.Forms.CheckBox();
            this.NextTrial_CB = new System.Windows.Forms.CheckBox();
            this.PlayFail_CB = new System.Windows.Forms.CheckBox();
            this.PlayWinSound_CB = new System.Windows.Forms.CheckBox();
            this.NextStep_CB = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ok_PB = new System.Windows.Forms.Button();
            this.txtCorrectCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIncorrectCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFixETW = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFixEFW = new System.Windows.Forms.TextBox();
            this.txtFixationTime_ET = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckFix_CB
            // 
            this.CheckFix_CB.AutoSize = true;
            this.CheckFix_CB.BackColor = System.Drawing.Color.Transparent;
            this.CheckFix_CB.Enabled = false;
            this.CheckFix_CB.Location = new System.Drawing.Point(35, 180);
            this.CheckFix_CB.Name = "CheckFix_CB";
            this.CheckFix_CB.Size = new System.Drawing.Size(121, 17);
            this.CheckFix_CB.TabIndex = 0;
            this.CheckFix_CB.Text = "Check Fixation Area";
            this.CheckFix_CB.UseVisualStyleBackColor = false;
            this.CheckFix_CB.Visible = false;
            this.CheckFix_CB.CheckedChanged += new System.EventHandler(this.Condition_CB_CheckedChanged);
            // 
            // HoldFix_CB
            // 
            this.HoldFix_CB.AutoSize = true;
            this.HoldFix_CB.BackColor = System.Drawing.Color.Transparent;
            this.HoldFix_CB.Checked = true;
            this.HoldFix_CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HoldFix_CB.Enabled = false;
            this.HoldFix_CB.Location = new System.Drawing.Point(35, 137);
            this.HoldFix_CB.Name = "HoldFix_CB";
            this.HoldFix_CB.Size = new System.Drawing.Size(112, 17);
            this.HoldFix_CB.TabIndex = 0;
            this.HoldFix_CB.Text = "Hold Fixation Area";
            this.HoldFix_CB.UseVisualStyleBackColor = false;
            this.HoldFix_CB.CheckedChanged += new System.EventHandler(this.Condition_CB_CheckedChanged);
            // 
            // NextTrial_CB
            // 
            this.NextTrial_CB.AutoSize = true;
            this.NextTrial_CB.BackColor = System.Drawing.Color.Transparent;
            this.NextTrial_CB.Checked = true;
            this.NextTrial_CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NextTrial_CB.Enabled = false;
            this.NextTrial_CB.Location = new System.Drawing.Point(464, 137);
            this.NextTrial_CB.Name = "NextTrial_CB";
            this.NextTrial_CB.Size = new System.Drawing.Size(116, 17);
            this.NextTrial_CB.TabIndex = 0;
            this.NextTrial_CB.Text = "Go To the next trial";
            this.NextTrial_CB.UseVisualStyleBackColor = false;
            // 
            // PlayFail_CB
            // 
            this.PlayFail_CB.AutoSize = true;
            this.PlayFail_CB.BackColor = System.Drawing.Color.Transparent;
            this.PlayFail_CB.Location = new System.Drawing.Point(464, 180);
            this.PlayFail_CB.Name = "PlayFail_CB";
            this.PlayFail_CB.Size = new System.Drawing.Size(114, 17);
            this.PlayFail_CB.TabIndex = 0;
            this.PlayFail_CB.Text = "Play the fail Sound";
            this.PlayFail_CB.UseVisualStyleBackColor = false;
            // 
            // PlayWinSound_CB
            // 
            this.PlayWinSound_CB.AutoSize = true;
            this.PlayWinSound_CB.BackColor = System.Drawing.Color.Transparent;
            this.PlayWinSound_CB.Location = new System.Drawing.Point(220, 180);
            this.PlayWinSound_CB.Name = "PlayWinSound_CB";
            this.PlayWinSound_CB.Size = new System.Drawing.Size(120, 17);
            this.PlayWinSound_CB.TabIndex = 1;
            this.PlayWinSound_CB.Text = "Play the Win Sound";
            this.PlayWinSound_CB.UseVisualStyleBackColor = false;
            // 
            // NextStep_CB
            // 
            this.NextStep_CB.AutoSize = true;
            this.NextStep_CB.BackColor = System.Drawing.Color.Transparent;
            this.NextStep_CB.Checked = true;
            this.NextStep_CB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NextStep_CB.Enabled = false;
            this.NextStep_CB.Location = new System.Drawing.Point(220, 137);
            this.NextStep_CB.Name = "NextStep_CB";
            this.NextStep_CB.Size = new System.Drawing.Size(120, 17);
            this.NextStep_CB.TabIndex = 3;
            this.NextStep_CB.Text = "Go To the next step";
            this.NextStep_CB.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fixation Condition";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(217, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "If the condition is satisfied";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(461, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "else";
            // 
            // Ok_PB
            // 
            this.Ok_PB.AutoEllipsis = true;
            this.Ok_PB.BackColor = System.Drawing.Color.Transparent;
            this.Ok_PB.BackgroundImage = global::TaskDesigner.Resource.Run;
            this.Ok_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ok_PB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Ok_PB.FlatAppearance.BorderSize = 0;
            this.Ok_PB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ok_PB.Location = new System.Drawing.Point(310, 308);
            this.Ok_PB.Margin = new System.Windows.Forms.Padding(0);
            this.Ok_PB.Name = "Ok_PB";
            this.Ok_PB.Size = new System.Drawing.Size(48, 48);
            this.Ok_PB.TabIndex = 9;
            this.Ok_PB.TabStop = false;
            this.Ok_PB.UseMnemonic = false;
            this.Ok_PB.UseVisualStyleBackColor = false;
            this.Ok_PB.Click += new System.EventHandler(this.Ok_PB_Click);
            // 
            // txtCorrectCode
            // 
            this.txtCorrectCode.Location = new System.Drawing.Point(203, 227);
            this.txtCorrectCode.Name = "txtCorrectCode";
            this.txtCorrectCode.Size = new System.Drawing.Size(37, 20);
            this.txtCorrectCode.TabIndex = 10;
            this.txtCorrectCode.TextChanged += new System.EventHandler(this.txtCorrectCode_TextChanged);
            this.txtCorrectCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorrectCode_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(32, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "TCorrect Event Code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(381, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "TIncorrect Event Code:";
            // 
            // txtIncorrectCode
            // 
            this.txtIncorrectCode.Location = new System.Drawing.Point(533, 227);
            this.txtIncorrectCode.Name = "txtIncorrectCode";
            this.txtIncorrectCode.Size = new System.Drawing.Size(37, 20);
            this.txtIncorrectCode.TabIndex = 12;
            this.txtIncorrectCode.TextChanged += new System.EventHandler(this.txtIncorrectCode_TextChanged);
            this.txtIncorrectCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIncorrectCode_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(382, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Enter Target Window Event:";
            // 
            // txtFixETW
            // 
            this.txtFixETW.Location = new System.Drawing.Point(533, 273);
            this.txtFixETW.Name = "txtFixETW";
            this.txtFixETW.Size = new System.Drawing.Size(37, 20);
            this.txtFixETW.TabIndex = 16;
            this.txtFixETW.TextChanged += new System.EventHandler(this.txtFixETW_TextChanged);
            this.txtFixETW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFixETW_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(32, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Enter Fixation Window Event:";
            // 
            // txtFixEFW
            // 
            this.txtFixEFW.Location = new System.Drawing.Point(203, 271);
            this.txtFixEFW.Name = "txtFixEFW";
            this.txtFixEFW.Size = new System.Drawing.Size(37, 20);
            this.txtFixEFW.TabIndex = 14;
            this.txtFixEFW.TextChanged += new System.EventHandler(this.txtFixEFW_TextChanged);
            this.txtFixEFW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFixEFW_KeyPress);
            // 
            // txtFixationTime_ET
            // 
            this.txtFixationTime_ET.Location = new System.Drawing.Point(203, 318);
            this.txtFixationTime_ET.Name = "txtFixationTime_ET";
            this.txtFixationTime_ET.Size = new System.Drawing.Size(37, 20);
            this.txtFixationTime_ET.TabIndex = 22;
            this.txtFixationTime_ET.Text = "0";
            this.txtFixationTime_ET.TextChanged += new System.EventHandler(this.txtFixationTime_ET_TextChanged);
            this.txtFixationTime_ET.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFixationTime_ET_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(32, 321);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Fixation Time";
            // 
            // FixationSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.Controls.Add(this.txtFixationTime_ET);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFixETW);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFixEFW);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIncorrectCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCorrectCode);
            this.Controls.Add(this.Ok_PB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayWinSound_CB);
            this.Controls.Add(this.NextStep_CB);
            this.Controls.Add(this.HoldFix_CB);
            this.Controls.Add(this.PlayFail_CB);
            this.Controls.Add(this.NextTrial_CB);
            this.Controls.Add(this.CheckFix_CB);
            this.Name = "FixationSetting";
            this.Text = "FixationSetting";
            this.Load += new System.EventHandler(this.FixationSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckFix_CB;
        private System.Windows.Forms.CheckBox HoldFix_CB;
        private System.Windows.Forms.CheckBox NextTrial_CB;
        private System.Windows.Forms.CheckBox PlayFail_CB;
        private System.Windows.Forms.CheckBox PlayWinSound_CB;
        private System.Windows.Forms.CheckBox NextStep_CB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Ok_PB;
        private System.Windows.Forms.TextBox txtCorrectCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIncorrectCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFixETW;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFixEFW;
        private System.Windows.Forms.TextBox txtFixationTime_ET;
        private System.Windows.Forms.Label label13;
    }
}