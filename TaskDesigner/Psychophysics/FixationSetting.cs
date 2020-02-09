using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Basics;
using TaskDesigner;

namespace Psychophysics
{
    public partial class FixationSetting : XCoolForm.XCoolForm
    {
       	
		public FixationSetting()
        {
            InitializeComponent();
          	
        }
        #region Theme
        
		private XmlThemeLoader xtl = new XmlThemeLoader();
        // this function just sets a theme for the application
        
		private void SetTheme()
        {
            this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.Flat;

            this.TitleBar.TitleBarBackImage = Resource.engineer;
            this.TitleBar.TitleBarCaption = "Fixation Setting";
            this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
            this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
            this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
            this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Angular;
            this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.UpperGlow;

            this.MenuIcon = Resource.brain.GetThumbnailImage(25, 25, null, IntPtr.Zero);

            this.StatusBar.EllipticalGlow = false;
            this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Left;

            xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"Themes\BlueWinterTheme.xml"));
        }
        
		private void FixationSetting_Load(object sender, EventArgs e)
        {
            this.StatusBar.EllipticalGlow = false;

			if(Designer.Reward[Designer.ActivePicB - 1] == 1)
			{
				PlayFail_CB.Checked = false;
				PlayWinSound_CB.Checked = false;
			}
			if (Designer.Reward[Designer.ActivePicB - 1] == 2)
			{
				PlayFail_CB.Checked = false;
				PlayWinSound_CB.Checked = true;
			}
			if (Designer.Reward[Designer.ActivePicB - 1] == 3)
			{
				PlayFail_CB.Checked = true;
				PlayWinSound_CB.Checked = false;
			}
			if (Designer.Reward[Designer.ActivePicB - 1] == 4)
			{
				PlayFail_CB.Checked = true;
				PlayWinSound_CB.Checked = true;
			}
            
            if (Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].CorrectEventCode > -1)
            {
                txtCorrectCode.Text = Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].CorrectEventCode.ToString();
            }
            if (Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].INcorrectEventCode > -1)
            {
                txtIncorrectCode.Text = Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].INcorrectEventCode.ToString();
            }
            if (Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].ETW > -1)
            {
                txtFixETW.Text = Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].ETW.ToString();
            }
            if (Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].EFW > -1)
            {
                txtFixEFW.Text = Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].EFW.ToString();
            }
            
            txtFixationTime_ET.Text = Convert.ToString(Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].Time);

            this.XCoolFormHolderButtonClick += new XCoolFormHolderButtonClickHandler(frmCoolForm_XCoolFormHolderButtonClick);
            xtl.ThemeForm = this;
            SetTheme();


        }

        private void frmCoolForm_XCoolFormHolderButtonClick(XCoolForm.XCoolForm.XCoolFormHolderButtonClickArgs e)
        {
            switch (e.ButtonIndex)
            {
                case 0:
                    break;
                case 1:
                case 2:
                    break;
                case 3:
                    break;
            }

        }

        #endregion
          

        private void Condition_CB_CheckedChanged(object sender, EventArgs e)
        {
            String SenderName = ((CheckBox)sender).Name;
            if (CheckFix_CB.Checked)
            {
                if(SenderName.Equals(CheckFix_CB.Name))
                    HoldFix_CB.Checked = false;
                else
                    CheckFix_CB.Checked = false;

                NextStep_CB.Enabled = true;
                //SetDaq_CB.Enabled = true;
                PlayWinSound_CB.Enabled = true;
                NextTrial_CB.Enabled = true;
                PlayFail_CB.Enabled = true;

                //SetDaq_CB.Visible = true;
                PlayWinSound_CB.Visible = true;
            }
            else if(HoldFix_CB.Checked)
            {
                if (SenderName.Equals(HoldFix_CB.Name))
                    CheckFix_CB.Checked = false;
                else
                    HoldFix_CB.Checked = false;

                NextStep_CB.Enabled = true;
                //SetDaq_CB.Enabled = false;
                PlayWinSound_CB.Enabled = false;
                NextTrial_CB.Enabled = true;
                PlayFail_CB.Enabled = true;

                //SetDaq_CB.Visible = false;
                PlayWinSound_CB.Visible = false;
            }
            else
            {
                NextStep_CB.Enabled = false;
                //SetDaq_CB.Enabled = false;
                PlayWinSound_CB.Enabled = false;
                NextTrial_CB.Enabled = false;
                PlayFail_CB.Enabled = false;
            }


        }

        private void Ok_PB_Click(object sender, EventArgs e)
        {
            
			if(!PlayFail_CB.Checked && !PlayWinSound_CB.Checked  )
			{
				Designer.Reward[Designer.ActivePicB -1] = 1;
			}
			if (!PlayFail_CB.Checked && PlayWinSound_CB.Checked)
			{
				Designer.Reward[Designer.ActivePicB - 1] = 2;
			}
			if (PlayFail_CB.Checked && !PlayWinSound_CB.Checked)
			{
				Designer.Reward[Designer.ActivePicB - 1] = 3;
			}
			if (PlayFail_CB.Checked && PlayWinSound_CB.Checked)
			{
				Designer.Reward[Designer.ActivePicB - 1] = 4;
			}
			this.Close();
        }

        private void txtCorrectCode_TextChanged(object sender, EventArgs e)
        {
            Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].CorrectEventCode = int.Parse(txtCorrectCode.Text);
        }

        private void txtCorrectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
        private void txtFixETW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFixEFW_TextChanged(object sender, EventArgs e)
        {
            Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].EFW = int.Parse(txtFixEFW.Text);
        }

        private void txtFixEFW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIncorrectCode_TextChanged(object sender, EventArgs e)
        {
            Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].INcorrectEventCode = int.Parse(txtIncorrectCode.Text);
        }

        private void txtIncorrectCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFixETW_TextChanged(object sender, EventArgs e)
        {
            Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].ETW = int.Parse(txtFixETW.Text);
        }

        private void txtFixationTime_ET_TextChanged(object sender, EventArgs e)
        {
            Designer.fixationList[Designer.ActivePicB - 1][Designer._fixateAreaSelected].Time = int.Parse(txtFixationTime_ET.Text);
        }

        private void txtFixationTime_ET_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
