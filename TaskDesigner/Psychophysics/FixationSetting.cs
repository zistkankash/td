using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basics;
using TaskDesigner;
using static Psychophysics.Old.Designer;

namespace Psychophysics
{
    public partial class FixationSetting : XCoolForm.XCoolForm
    {
        int index;
		
		public FixationSetting(int rewardType, int index)
        {
            InitializeComponent();
            this.index = index;
			//DifineRewardType(rewardType);
			
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

			if(Reward[index] == 1)
			{
				PlayFail_CB.Checked = false;
				PlayWinSound_CB.Checked = false;
			}
			if (Reward[index] == 2)
			{
				PlayFail_CB.Checked = false;
				PlayWinSound_CB.Checked = true;
			}
			if (Reward[index] == 3)
			{
				PlayFail_CB.Checked = true;
				PlayWinSound_CB.Checked = false;
			}
			if (Reward[index] == 4)
			{
				PlayFail_CB.Checked = true;
				PlayWinSound_CB.Checked = true;
			}
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

        private void DifineRewardType(int type)
        {
            byte[] intBytes = BitConverter.GetBytes(type);

            BitArray b = new BitArray(intBytes);
            for (int i  = 0; i < b.Length; i++)
            {
                Debug.Write("Byte"+ i + " " + b[i]+ "\n");
            }


            NextStep_CB.Checked = b[4];
            //SetDaq_CB.Checked = b[3];
            PlayWinSound_CB.Checked = b[2];
            NextTrial_CB.Checked = b[1];
            PlayFail_CB.Checked = b[0];

            CheckFix_CB.Checked = b[6];
            HoldFix_CB.Checked = b[5];

        }

        private void CheckFix_CB_CheckedChanged(object sender, EventArgs e)
        {
            NextStep_CB.Enabled = CheckFix_CB.Checked;
            //SetDaq_CB.Enabled = CheckFix_CB.Checked;
            PlayWinSound_CB.Enabled = CheckFix_CB.Checked;
            NextTrial_CB.Enabled = CheckFix_CB.Checked;
            PlayFail_CB.Enabled = CheckFix_CB.Checked;
        }

        private void HoldFix_CB_CheckedChanged(object sender, EventArgs e)
        {

        }

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
            //byte[] intBytes = BitConverter.GetBytes(0);
            //BitArray b = new BitArray(intBytes);

            //b[6] = CheckFix_CB.Checked;
            //b[5] = HoldFix_CB.Checked;
            //if(b[6])
            //{ 
            //    b[4] = NextStep_CB.Checked & NextStep_CB.Enabled;
            //    b[3] = SetDaq_CB.Checked & SetDaq_CB.Enabled;
            //    b[2] = PlayWinSound_CB.Checked & PlayWinSound_CB.Enabled;
            //    b[1] = NextTrial_CB.Checked & NextTrial_CB.Enabled;
            //    b[0] = PlayFail_CB.Checked & PlayFail_CB.Enabled;

            //    int[] array = new int[1];
            //    b.CopyTo(array, 0);
            //    Reward[index] = array[0];
            //}
            //else if(b[5])
            //{
            //    b[4] = NextStep_CB.Checked & NextStep_CB.Enabled;
            //    b[3] = false;
            //    b[2] = false;
            //    b[1] = NextTrial_CB.Checked & NextTrial_CB.Enabled;
            //    b[0] = PlayFail_CB.Checked & PlayFail_CB.Enabled;
            //    int[] array = new int[1];
            //    b.CopyTo(array, 0);
            //    Reward[index] = array[0];
            //}
            //else
            //{
            //    Reward[index] = 0;
            //}
			if(!PlayFail_CB.Checked && !PlayWinSound_CB.Checked  )
			{
				Reward[index] = 1;
			}
			if (!PlayFail_CB.Checked && PlayWinSound_CB.Checked)
			{
				Reward[index] = 2;
			}
			if (PlayFail_CB.Checked && !PlayWinSound_CB.Checked)
			{
				Reward[index] = 3;
			}
			if (PlayFail_CB.Checked && PlayWinSound_CB.Checked)
			{
				Reward[index] = 4;
			}
			this.Close();
        }
    }
}
