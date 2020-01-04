namespace TaskDesigner.TaskLab
{
    partial class URLInput
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
            this.txtbxURL = new MetroFramework.Controls.MetroTextBox();
            this.btnAccept = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtbxURL
            // 
            this.txtbxURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            // 
            // 
            // 
            this.txtbxURL.CustomButton.Image = null;
            this.txtbxURL.CustomButton.Location = new System.Drawing.Point(354, 1);
            this.txtbxURL.CustomButton.Name = "";
            this.txtbxURL.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbxURL.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbxURL.CustomButton.TabIndex = 1;
            this.txtbxURL.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbxURL.CustomButton.UseSelectable = true;
            this.txtbxURL.CustomButton.Visible = false;
            this.txtbxURL.Lines = new string[0];
            this.txtbxURL.Location = new System.Drawing.Point(12, 12);
            this.txtbxURL.MaxLength = 32767;
            this.txtbxURL.Name = "txtbxURL";
            this.txtbxURL.PasswordChar = '\0';
            this.txtbxURL.PromptText = "Enter Web Page URL";
            this.txtbxURL.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbxURL.SelectedText = "";
            this.txtbxURL.SelectionLength = 0;
            this.txtbxURL.SelectionStart = 0;
            this.txtbxURL.ShortcutsEnabled = true;
            this.txtbxURL.Size = new System.Drawing.Size(376, 23);
            this.txtbxURL.TabIndex = 0;
            this.txtbxURL.UseCustomBackColor = true;
            this.txtbxURL.UseSelectable = true;
            this.txtbxURL.WaterMark = "Enter Web Page URL";
            this.txtbxURL.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbxURL.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAccept.Location = new System.Drawing.Point(50, 46);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(106, 23);
            this.btnAccept.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Enter";
            this.btnAccept.UseCustomBackColor = true;
            this.btnAccept.UseSelectable = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.metroButton1.Location = new System.Drawing.Point(227, 46);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(108, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Brown;
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Cancel";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseSelectable = true;
            // 
            // URLInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(400, 80);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtbxURL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "URLInput";
            this.Text = "URLInput";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtbxURL;
        private MetroFramework.Controls.MetroButton btnAccept;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}