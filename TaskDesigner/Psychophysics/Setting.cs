using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Automation.BDaq;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Basics;
using TaskDesigner;
namespace Psychophysics
{
    public partial class Setting : XCoolForm.XCoolForm
    {
        public Setting()
        {
            InitializeComponent();

            // some color initialization
            ActiveColor = Color.FromArgb(30, 100, 230);
            InactiveColor = Color.FromArgb(191, 219, 255);
            //test.SetBounds(50, 50, 50, 50);
            //test.TabCount = 2;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    OutputEnable[i, j] = 1;
                    PictureBox selected = this.Controls.Find("pictureBox" + i + j, true).FirstOrDefault() as PictureBox;
                    selected.BackColor = Color.Gray;
                    OutputEnable[i, j] = 0;
                }
            }

            //OutputEnable[0, TaskPreview.DOutIndex[0]] = 1;
            //OutputEnable[1, TaskPreview.DOutIndex[1]] = 1;
            Debug.Write("AInIndex : " + TaskPreview.AInIndex[0] + " " + TaskPreview.AInIndex[1] + "\n");
            if (TaskPreview.AInIndex[0] == 0)
            {
                InputSelect_CB0.SelectedIndex = 0;
            }
            else
            {
                InputSelect_CB0.SelectedIndex = 1;
            }

            if (TaskPreview.AInIndex[1] == 1)
            {
                InputSelect_CB1.SelectedIndex = 1;
            }
            else
            {
                InputSelect_CB1.SelectedIndex = 0;
            }
            this.InputSelect_CB0.SelectedIndexChanged += new System.EventHandler(this.InputSelect_CB_SelectedIndexChanged);
            this.InputSelect_CB1.SelectedIndexChanged += new System.EventHandler(this.InputSelect_CB_SelectedIndexChanged);
            Debug.Write("InputSelect_CB0.SelectedIndex : " + InputSelect_CB0.SelectedIndex + " " + InputSelect_CB0.SelectedIndex + "\n");
            //switch (TaskPreview.InputValRange)
            //{
            //    case ValueRange.V_0To5:
            //        SelectDaqVol_CB.SelectedIndex = 0;
            //        break;
            //    case ValueRange.V_0To10:
            //        SelectDaqVol_CB.SelectedIndex = 1;
            //        break;
            //    case ValueRange.V_Neg5To5:
            //        SelectDaqVol_CB.SelectedIndex = 2;
            //        break;
            //    case ValueRange.V_Neg10To10:
            //        SelectDaqVol_CB.SelectedIndex = 3;
            //        break;
            //    default:
            //        SelectDaqVol_CB.SelectedIndex = 4;
            //        break;
            //}
			
            
                DaqEn_CB.Checked = true;
                DAQPanel.Enabled = true;
                LANPanel.Enabled = false;
            
            //Debug.Write();
            PictureBox varselected = this.Controls.Find("pictureBox" + 0 + TaskPreview.DOutIndex[0], true).FirstOrDefault() as PictureBox;
            varselected.BackColor = Color.Green;
            varselected = this.Controls.Find("pictureBox" + 1 + TaskPreview.DOutIndex[1], true).FirstOrDefault() as PictureBox;
            varselected.BackColor = Color.Green;

            //List<Automation.BDaq.DeviceTreeNode> NameDevices = TaskPreview.instantAiCtrl.SupportedDevices;
            //Devices_CB.Items.Add("");
            //for (int i = 0; i < NameDevices.Count; i++)
            //{
            //    Devices_CB.Items.Add(NameDevices[i].Description);
            //    Devices_CB.SelectedIndex = 0;
            //}

            
            if(TaskPreview.TypeDisplay == 1)
            {
                NormalDisplay_CB.Checked = true;
            }
            else if(TaskPreview.TypeDisplay == 2)
            {
                RandomDisplay_CB.Checked = true;
            }
            Mute_CB.Checked = TaskPreview.SoundMute;
            FailPath_ET.Text = TaskPreview.FailPath;
            WinPath_ET.Text = TaskPreview.WinPath;

            SelectedInBt_ET.Text = TaskPreview.keyboardChar.ToString();

            UserDist_ET.Text = Convert.ToString(TaskPreview.userDistance);
            MonitorWidth_ET.Text = Convert.ToString(TaskPreview.WidthM);
            MonitorHeight_ET.Text = Convert.ToString(TaskPreview.HeightM);

                      
            //get user IP
            //txtLocalIP.Text = GetLocalIP();
            //txtRemoteIP.Text = GetLocalIP();
            txtRemoteIP.Text = "127.0.0.1";
            
            ////get user IP
            //txtLocalIP.Text = GetLocalIP();
            //txtRemoteIP.Text = GetLocalIP();

            //txtLocalPort.Text = Convert.ToString(TaskPreview.LocalPort);
            //txtRemotePort.Text = Convert.ToString(TaskPreview.RemotePort);
        }
        MyTabControl test = new MyTabControl();
        private XmlThemeLoader xtl = new XmlThemeLoader();

        //ValueRange InputValRange = ValueRange.V_0To1;
        String DaqName = TaskPreview.DaqName;
        // Analog input
        //InstantAiCtrl instantAiCtrl = new InstantAiCtrl();
        //int RangeOutDaq = 0;
        //bool EnAInput = false;

        // output
        //InstantDoCtrl instantDoCtrl = new InstantDoCtrl();
        //bool EnDOutput = false;
        int[,] OutputEnable = new int[2, 8];

        // Tab Control 
        Color ActiveColor = new Color();
        Color InactiveColor = new Color();
        private void Setting_Load(object sender, EventArgs e)
        {

            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(60));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(200, "INS"));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(80, "Done"));
            this.StatusBar.EllipticalGlow = false;

            //this.XCoolFormHolderButtonClick += new XCoolFormHolderButtonClickHandler(frmCoolForm_XCoolFormHolderButtonClick);
            xtl.ThemeForm = this;
            SetTheme();
            
        }

        private void SetTheme()
        {
            this.Border.BorderStyle = XCoolForm.X3DBorderPrimitive.XBorderStyle.Flat;
            this.TitleBar.TitleBarBackImage = Resource.engineer;
            this.TitleBar.TitleBarCaption = "Setting";

            this.TitleBar.TitleBarButtons[2].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
            this.TitleBar.TitleBarButtons[1].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;
            this.TitleBar.TitleBarButtons[0].ButtonFillMode = XCoolForm.XTitleBarButton.XButtonFillMode.None;

            this.TitleBar.TitleBarType = XCoolForm.XTitleBar.XTitleBarType.Angular;
            this.MenuIcon = Resource.brain.GetThumbnailImage(25, 25, null, IntPtr.Zero);
            this.StatusBar.EllipticalGlow = false;

            this.TitleBar.TitleBarFill = XCoolForm.XTitleBar.XTitleBarFill.UpperGlow;

            //this.StatusBar.BarBackImage = TaskDesigner.Properties.Resources.Funshine_Bear_1;
            this.StatusBar.BarImageAlign = XCoolForm.XStatusBar.XStatusBarBackImageAlign.Left;

            this.StatusBar.BarItems[1].BarItemText = "";
            this.StatusBar.BarItems[1].ItemTextAlign = StringAlignment.Center;

            xtl.ApplyTheme(Path.Combine(Environment.CurrentDirectory, @"Themes\BlueWinterTheme.xml"));

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1:

                    break;
                case 2:

                    break;
                default:
                break;
            }
        }



        //private void SelectDaqVol_CB_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int index = SelectDaqVol_CB.SelectedIndex;
        //    switch (index)
        //    {
        //        case 0:
        //            TaskPreview.InputValRange = ValueRange.V_0To5;
        //            break;
        //        case 1:
        //            TaskPreview.InputValRange = ValueRange.V_0To10;
        //            break;
        //        case 2:
        //            TaskPreview.InputValRange = ValueRange.V_Neg5To5;
        //            break;
        //        case 3:
        //            TaskPreview.InputValRange = ValueRange.V_Neg10To10;
        //            break;
        //        default:
        //            TaskPreview.InputValRange = ValueRange.V_0To1pt25;
        //            break;
        //    }
        //}

        private void InputSelect_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ComboBName = ((ComboBox)sender).Name;
            int index = (int)Char.GetNumericValue(ComboBName[(ComboBName.Length - 1)]);

            if (index == 0)
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {

                    ComboBox unselected = this.Controls.Find("InputSelect_CB" + 1, true).FirstOrDefault() as ComboBox;
                    unselected.SelectedIndex = 1;
                    TaskPreview.AInIndex[0] = 0;
                    TaskPreview.AInIndex[1] = 1;
                }
                else
                {
                    ComboBox unselected = this.Controls.Find("InputSelect_CB" + 1, true).FirstOrDefault() as ComboBox;
                    unselected.SelectedIndex = 0;
                    TaskPreview.AInIndex[0] = 1;
                    TaskPreview.AInIndex[1] = 0;
                }
            }
            else
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    ComboBox unselected = this.Controls.Find("InputSelect_CB" + 0, true).FirstOrDefault() as ComboBox;
                    unselected.SelectedIndex = 1;
                    TaskPreview.AInIndex[0] = 1;
                    TaskPreview.AInIndex[1] = 0;
                }
                else
                {
                    ComboBox unselected = this.Controls.Find("InputSelect_CB" + 0, true).FirstOrDefault() as ComboBox;
                    unselected.SelectedIndex = 0;
                    TaskPreview.AInIndex[0] = 0;
                    TaskPreview.AInIndex[1] = 1;
                }

            }
        }

        private void pictureBoxOut_Click(object sender, EventArgs e)
        {
            String picB = ((PictureBox)sender).Name;
            int index = (int)Char.GetNumericValue(picB[(picB.Length - 1)]);
            int row = (int)Char.GetNumericValue(picB[(picB.Length - 2)]);

            if (row == 0)
            {
                if (OutputEnable[1, index] == 0)
                {
                    OutputEnable[0, index] = 1;
                    PictureBox selected = this.Controls.Find("pictureBox0" + index, true).FirstOrDefault() as PictureBox;
                    selected.BackColor = Color.Green;
                    for (int i = 0; i < 8; i++)
                    {
                        if (i == index)
                            continue;
                        OutputEnable[0, i] = 0;
                        PictureBox unselected = this.Controls.Find("pictureBox0" + i, true).FirstOrDefault() as PictureBox;
                        unselected.BackColor = Color.Gray;
                    }
                }
            }
            else
            {
                if (OutputEnable[0, index] == 0)
                {
                    OutputEnable[1, index] = 1;
                    PictureBox selected = this.Controls.Find("pictureBox1" + index, true).FirstOrDefault() as PictureBox;
                    selected.BackColor = Color.Green;
                    for (int i = 0; i < 8; i++)
                    {
                        if (i == index)
                            continue;
                        OutputEnable[1, i] = 0;
                        PictureBox unselected = this.Controls.Find("pictureBox1" + i, true).FirstOrDefault() as PictureBox;
                        unselected.BackColor = Color.Gray;
                    }
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

            // This event is called once for each tab button in your tab control

            // First paint the background with a color based on the current tab

            // e.Index is the index of the tab in the TabPages collection.
            TabPage page = tabControl1.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void DaqTab_BT_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = DaqTab;
            KeyTab_BT.BackColor = InactiveColor;
            ETTab_BT.BackColor = InactiveColor;
            DaqTab_BT.BackColor = ActiveColor;
            SoundTab_BT.BackColor = InactiveColor;
        }

        private void ETTab_BT_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = DisplayTab;
            KeyTab_BT.BackColor = InactiveColor;
            ETTab_BT.BackColor = ActiveColor;
            DaqTab_BT.BackColor = InactiveColor;
            SoundTab_BT.BackColor = InactiveColor;

        }

        private void Ok_PB_Click(object sender, EventArgs e)
        {
            int Deviceindex = Devices_CB.SelectedIndex;
            if(Devices_CB.Items.Count>0)
                TaskPreview.DaqName = Devices_CB.Items[Deviceindex].ToString();
           
            this.Close();
        }

        private void NormalDisplay_CB_CheckedChanged(object sender, EventArgs e)
        {
            if(NormalDisplay_CB.Checked)
            {
                RandomDisplay_CB.Checked = false;
                TaskPreview.TypeDisplay = 1;
            }
            else
            {
                RandomDisplay_CB.Checked = true;
                TaskPreview.TypeDisplay = 2;
            }
        }

        private void RandomDisplay_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (RandomDisplay_CB.Checked)
            {
                NormalDisplay_CB.Checked = false;
                TaskPreview.TypeDisplay = 2;
            }
            else
            {
                NormalDisplay_CB.Checked = true;
                TaskPreview.TypeDisplay = 1;
            }
        }

        private void Devices_CB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SoundTab_BT_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = SoundTab;
            KeyTab_BT.BackColor = InactiveColor;
            ETTab_BT.BackColor = InactiveColor;
            DaqTab_BT.BackColor = InactiveColor;
            SoundTab_BT.BackColor = ActiveColor;
        }

        private void KeyTab_BT_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = KeyTab;
            KeyTab_BT.BackColor = ActiveColor;
            ETTab_BT.BackColor = InactiveColor;
            DaqTab_BT.BackColor = InactiveColor;
            SoundTab_BT.BackColor = InactiveColor;
        }

        private void WinPath_BT_Click(object sender, EventArgs e)
        {

            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Sounds (*.wav)|*.wav";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if(File.Exists(sfd.FileName))
                { 
                    TaskPreview.WinPath = sfd.FileName;
                    WinPath_ET.Text = sfd.FileName;
                }
            }
        }

        private void FailPath_BT_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Sounds (*.wav)|*.wav";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                {
                    TaskPreview.FailPath = sfd.FileName;
                    FailPath_ET.Text = sfd.FileName;
                }
            }
        }

        private void Mute_CB_CheckedChanged(object sender, EventArgs e)
        {
            TaskPreview.SoundMute = Mute_CB.Checked;
        }

        private void Reset_BT_Click(object sender, EventArgs e)
        {
            TaskPreview.FailPath = "./Resources/coin.wav";
            FailPath_ET.Text = TaskPreview.FailPath;
            TaskPreview.WinPath = "./Resources/fail.wav";
            WinPath_ET.Text = TaskPreview.WinPath;
        }

        private void SelectedInBt_ET_TextChanged(object sender, EventArgs e)
        {
            string str = SelectedInBt_ET.Text;
            if (str.Length > 0)
                TaskPreview.keyboardChar = str[0];
        }

        private void UserDist_ET_TextChanged(object sender, EventArgs e)
        {
            TaskPreview.userDistance = double.Parse(UserDist_ET.Text);
        }

        private void MonitorWidth_ET_TextChanged(object sender, EventArgs e)
        {
            TaskPreview.WidthM = double.Parse(MonitorWidth_ET.Text);
        }

        private void MonitorHeight_ET_TextChanged(object sender, EventArgs e)
        {
            TaskPreview.HeightM = double.Parse(MonitorHeight_ET.Text);
        }

        private void DaqEn_CB_CheckedChanged(object sender, EventArgs e)
        {
            if(DaqEn_CB.Checked)
            {
                DAQPanel.Enabled = true;
                LANPanel.Enabled = false;
               
            }
            else
            {
                DAQPanel.Enabled = false;
            }

        }

    }

    class MyTabControl : TabControl
    {
        public MyTabControl()
        {
            // Take over the painting completely, we want transparency and double-buffering
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            this.DoubleBuffered = this.ResizeRedraw = true;
        }

        public override Color BackColor
        {
            // Override TabControl.BackColor, we need transparency
            get { return Color.Transparent; }
            set { base.BackColor = Color.Transparent; }
        }

        protected virtual void DrawTabRectangle(Graphics g, int index, Rectangle r)
        {
            if (index == 0) r = new Rectangle(r.Left - 2, r.Top, r.Width + 2, r.Height);
            if (index != this.SelectedIndex) r = new Rectangle(r.Left, r.Top + 2, r.Width, r.Height - 2);
            Color tabColor;
            if (index == this.SelectedIndex) tabColor = Color.FromKnownColor(KnownColor.Window);
            else tabColor = Color.FromArgb(0xf0, 0xf0, 0xf0);
            using (var br = new SolidBrush(tabColor))
            {
                g.FillRectangle(br, r);
            }
        }

        protected virtual void DrawTab(Graphics g, int index, Rectangle r)
        {
            r.Inflate(-1, -1);
            TextRenderer.DrawText(g, this.TabPages[index].Text, this.Font,
                r, Color.FromKnownColor(KnownColor.WindowText),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }




        protected override void OnPaint(PaintEventArgs e)
        {

            if (TabCount <= 0) return;
            // Draw tabpage area
            Rectangle r = ClientRectangle;
            var top = this.GetTabRect(0).Bottom;
            using (var br = new SolidBrush(Color.FromKnownColor(KnownColor.Window)))
            {
                e.Graphics.FillRectangle(br, new Rectangle(r.Left, top, r.Width, r.Height - top));
            }
            // Draw tabs
            for (int index = 0; index < TabCount; index++)
            {
                r = GetTabRect(index);
                DrawTabRectangle(e.Graphics, index, r);
                DrawTab(e.Graphics, index, r);
                if (index == this.SelectedIndex)
                {
                    r.Inflate(-1, -1);
                    ControlPaint.DrawFocusRectangle(e.Graphics, r);
                }
            }
        }

    }
}
