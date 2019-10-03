﻿using TaskDesigner;
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
            this.SetDaq_CB = new System.Windows.Forms.CheckBox();
            this.NextStep_CB = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Ok_PB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckFix_CB
            // 
            this.CheckFix_CB.AutoSize = true;
            this.CheckFix_CB.BackColor = System.Drawing.Color.Transparent;
            this.CheckFix_CB.Location = new System.Drawing.Point(35, 150);
            this.CheckFix_CB.Name = "CheckFix_CB";
            this.CheckFix_CB.Size = new System.Drawing.Size(121, 17);
            this.CheckFix_CB.TabIndex = 0;
            this.CheckFix_CB.Text = "Check Fixation Area";
            this.CheckFix_CB.UseVisualStyleBackColor = false;
            this.CheckFix_CB.CheckedChanged += new System.EventHandler(this.Condition_CB_CheckedChanged);
            // 
            // HoldFix_CB
            // 
            this.HoldFix_CB.AutoSize = true;
            this.HoldFix_CB.BackColor = System.Drawing.Color.Transparent;
            this.HoldFix_CB.Location = new System.Drawing.Point(35, 193);
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
            this.NextTrial_CB.Location = new System.Drawing.Point(425, 155);
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
            this.PlayFail_CB.Location = new System.Drawing.Point(425, 193);
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
            this.PlayWinSound_CB.Location = new System.Drawing.Point(220, 236);
            this.PlayWinSound_CB.Name = "PlayWinSound_CB";
            this.PlayWinSound_CB.Size = new System.Drawing.Size(120, 17);
            this.PlayWinSound_CB.TabIndex = 1;
            this.PlayWinSound_CB.Text = "Play the Win Sound";
            this.PlayWinSound_CB.UseVisualStyleBackColor = false;
            // 
            // SetDaq_CB
            // 
            this.SetDaq_CB.AutoSize = true;
            this.SetDaq_CB.BackColor = System.Drawing.Color.Transparent;
            this.SetDaq_CB.Location = new System.Drawing.Point(220, 193);
            this.SetDaq_CB.Name = "SetDaq_CB";
            this.SetDaq_CB.Size = new System.Drawing.Size(104, 17);
            this.SetDaq_CB.TabIndex = 2;
            this.SetDaq_CB.Text = "Set DAQ output ";
            this.SetDaq_CB.UseVisualStyleBackColor = false;
            // 
            // NextStep_CB
            // 
            this.NextStep_CB.AutoSize = true;
            this.NextStep_CB.BackColor = System.Drawing.Color.Transparent;
            this.NextStep_CB.Location = new System.Drawing.Point(220, 150);
            this.NextStep_CB.Name = "NextStep_CB";
            this.NextStep_CB.Size = new System.Drawing.Size(120, 17);
            this.NextStep_CB.TabIndex = 3;
            this.NextStep_CB.Text = "Go To the next step";
            this.NextStep_CB.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fixation Condition";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "If the condition is satisfied";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "else";
            // 
            // Ok_PB
            // 
            this.Ok_PB.AutoEllipsis = true;
            this.Ok_PB.BackColor = System.Drawing.Color.Transparent;
            this.Ok_PB.BackgroundImage = Resource._checked;
            this.Ok_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ok_PB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Ok_PB.FlatAppearance.BorderSize = 0;
            this.Ok_PB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ok_PB.Location = new System.Drawing.Point(292, 295);
            this.Ok_PB.Margin = new System.Windows.Forms.Padding(0);
            this.Ok_PB.Name = "Ok_PB";
            this.Ok_PB.Size = new System.Drawing.Size(48, 48);
            this.Ok_PB.TabIndex = 9;
            this.Ok_PB.TabStop = false;
            this.Ok_PB.UseMnemonic = false;
            this.Ok_PB.UseVisualStyleBackColor = false;
            this.Ok_PB.Click += new System.EventHandler(this.Ok_PB_Click);
            // 
            // FixationSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.Controls.Add(this.Ok_PB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayWinSound_CB);
            this.Controls.Add(this.SetDaq_CB);
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
        private System.Windows.Forms.CheckBox SetDaq_CB;
        private System.Windows.Forms.CheckBox NextStep_CB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Ok_PB;
    }
}