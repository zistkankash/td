using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Basics;
using TaskDesigner;
using static Psychophysics.Designer;

namespace Psychophysics
{
    public partial class NormalPageSetting : XCoolForm.XCoolForm
    {
        // 
        public int PageCount;
        
		public NormalPageSetting()
        {
            InitializeComponent();
            // some color initialization
            ActiveColor = Color.FromArgb( 30, 100, 230);
            InactiveColor = Color.FromArgb(191, 219, 255);
            //
            EnablePanel.Enabled = EnableFrame_CB.Checked;

            // Screen
            Width = frameList[0].frameWidth;
            Height = frameList[0].frameHeight;
            // Box
            Boxn[0] = new ShowFr();
            Boxn[1] = new ShowFr();

            Boxn[0].Thickness = int.Parse(BoxThickness_ET.Text);
            Boxn[0].Width = int.Parse(BoxWidth_ET.Text);
            Boxn[0].Height = int.Parse(BoxHeight_ET.Text);
            Boxn[1].Thickness = int.Parse(BoxThickness_ET.Text);
            Boxn[1].Width = int.Parse(BoxWidth_ET.Text);
            Boxn[1].Height = int.Parse(BoxHeight_ET.Text);


            //Stimulus
            Stimulus[0] = new ObjectProp();
            Stimulus[1] = new ObjectProp();
            Stimulus[0].Type = 0;
            Stimulus[1].Type = 0;
            Stimulus[0].Xloc = Width / 4;
            Stimulus[0].Yloc = Height / 2;
            Stimulus[1].Xloc = 3 * Width / 4;
            Stimulus[1].Yloc = Height / 2;
            Stimulus[0].Width = int.Parse(StimulusWidth1_TB.Text);
            Stimulus[0].Contrast = int.Parse(StimulusContrast1_TB.Text);
            Stimulus[1].Width = int.Parse(StimulusWidth2_TB.Text);
            Stimulus[1].Contrast = int.Parse(StimulusContrast2_TB.Text);

            // Fixation 
            FixationPoint.Type = 3;
            FixationPoint.Xloc = Width / 4;
            FixationPoint.Yloc = Height / 2;
            FixationPoint.Width = int.Parse(FixationSize_ET.Text);

            //Cue
            ////Arrow
            Cue.ArrowLocX0 = Width / 2 - 50;
            Cue.ArrowLocX1 = Width / 2 + 50;
            Cue.ArrowLocY =  Height / 2;
            Cue.ArrowColor = Color.Black;
            Cue.ArrowWidth = 50;

            ArrowLocX_ET.Text = Convert.ToString(Cue.ArrowLocX0 + Cue.ArrowWidth);
            ArrowLocY_ET.Text = Convert.ToString(Cue.ArrowLocY);
            SizeCue_ET.Text = Convert.ToString(Cue.ArrowWidth);

            ////Box
            Cue.BoxRatio = 2;


        }


        private XmlThemeLoader xtl = new XmlThemeLoader();
        // Tab Control 
        Color ActiveColor = new Color();
        Color InactiveColor = new Color();
        // Stimulus
        ObjectProp[] Stimulus = new ObjectProp[2];

        //Fixation
        ObjectProp FixationPoint = new ObjectProp();
        //Box
        ShowFr[] Boxn = new ShowFr[2];
        //Hint
        HintForm Cue = new HintForm();

        //Repeat
        int RepeatNum = 1;
        int RandomLoc = 0;
        // Screen Size
        new int Width, Height;
        private void NormalPageSetting_Load(object sender, EventArgs e)
        {

            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(60));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(200, "INS"));
            this.StatusBar.BarItems.Add(new XCoolForm.XStatusBar.XBarItem(80, "Done"));
            this.StatusBar.EllipticalGlow = false;

            //this.XCoolFormHolderButtonClick += new XCoolFormHolderButtonClickHandler(frmCoolForm_XCoolFormHolderButtonClick);
            xtl.ThemeForm = this;
            SetTheme();

            //
            // some initialization
            for (int i = 0; i < PageCount-2; i++)
            {
                FrameIndex1_CB.Items.Add(i + 1);
                FrameIndex2_CB.Items.Add(i + 2);
            }
            FrameIndex2_CB.Enabled = false;

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

        private void FrameTab_BT_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = FrameTab;
            FrameTab_BT.BackColor = ActiveColor;
            RewardTab_BT.BackColor = InactiveColor;
            CueTab_BT.BackColor = InactiveColor;
        }

        private void RewardTab_BT_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = RewardTab;
            FrameTab_BT.BackColor = InactiveColor;
            RewardTab_BT.BackColor = ActiveColor;
            CueTab_BT.BackColor = InactiveColor;
        }
        private void CueTab_BT_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = CueTab;
            FrameTab_BT.BackColor = InactiveColor;
            RewardTab_BT.BackColor = InactiveColor;
            CueTab_BT.BackColor = ActiveColor;

            UseCue_CB.Enabled = EnableFrame_CB.Checked;

            if (UseCue_CB.Enabled && UseCue_CB.Checked)
            {
                Box_CB.Enabled = true;
                Arrow_CB.Enabled = true;
            }
            else
            {
                Box_CB.Enabled = false;
                Arrow_CB.Enabled = false;
            }

            BoxPanel.Enabled = Box_CB.Checked;
            ArrowPanel.Enabled = Arrow_CB.Checked;
        }

        private void FrameIndex1_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FrameIndex2_CB.SelectedIndex = FrameIndex1_CB.SelectedIndex ;
        }

        private void EnableFrame_CB_CheckedChanged(object sender, EventArgs e)
        {
            EnablePanel.Enabled = EnableFrame_CB.Checked;
            BoxPropPanel.Enabled = EnableFrame_CB.Checked;
            UseCue_CB.Enabled = EnableFrame_CB.Checked;
            
        }

        private void StimulusType_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            String cmbName = cmb.Name;
            int index = (int)Char.GetNumericValue(cmbName[(cmbName.Length - 4)]);
            String value = (String)cmb.SelectedItem;
            Debug.Write("Type " + value + "\n");
            char type = value[0];

            Panel PicPanel = Controls.Find("PathPicPanel" + index, true).FirstOrDefault() as Panel;
            Panel ShapePanel = Controls.Find("ShapePropPanel" + index, true).FirstOrDefault() as Panel;
            Debug.Write("Type " + type + "\n");
            switch (type)
            {
                case 'S':
                    if(index == 1)
                        Stimulus[index - 1].Type = 5;
                    else
                        Stimulus[index - 1].Type = 9;
                    ShapePanel.Enabled = true;
                    PicPanel.Enabled = false;
                    break;
                case 'C':
                    if (index == 1)
                        Stimulus[index - 1].Type = 7;
                    else
                        Stimulus[index - 1].Type = 11;
                    ShapePanel.Enabled = true;
                    PicPanel.Enabled = false;
                    break;
                case 'P':
                    if (index == 1)
                        Stimulus[index - 1].Type = 8;
                    else
                        Stimulus[index - 1].Type = 12;
                    ShapePanel.Enabled = false;
                    PicPanel.Enabled = true;
                    Debug.Write("P "+ PicPanel.Enabled  + " " + ShapePanel.Enabled + "\n");
                    break;
                default:
                    Stimulus[index - 1].Type = 5;
                    ShapePanel.Enabled = false;
                    PicPanel.Enabled = false;
                    break;
            }
            Debug.Write("Type " + Stimulus[0].Type + " " + Stimulus[1].Type + "\n");

        }

        private void StimulusColor_BT_Click(object sender, EventArgs e)
        {
            Button colorbt = (Button)sender;

            String colorbtName = colorbt.Name;
            int index = (int)Char.GetNumericValue(colorbtName[(colorbtName.Length - 4)]);

            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                Stimulus[index - 1].ColorPt = c.Color;
                colorbt.BackColor = c.Color;
            }
        }

        private void PictureBrowse_PB_Click(object sender, EventArgs e)
        {
            Button PicBrowse = (Button)sender;
            String PicBrowseName = PicBrowse.Name;
            int index = (int)Char.GetNumericValue(PicBrowseName[(PicBrowseName.Length - 4)]);

            TextBox PicPanel = Controls.Find("PathPic" + index + "_ET", true).FirstOrDefault() as TextBox;

            OpenFileDialog ofd = new OpenFileDialog();
            string PictureFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.InitialDirectory = PictureFolder;
            ofd.Title = "Pick a picture; any picture";
            ofd.CustomPlaces.Add(@"C:\");
            ofd.CustomPlaces.Add(@"C:\Program Files\");
            ofd.CustomPlaces.Add(@"K:\Documents\Pictures\");
            //ofd.Multiselect = true;
            ofd.Filter = "Pictures|*.jpg; *.bmp; *.png|Documents|*.txt; *.doc; *.log|All|*.*";
            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //userSelectedFilePath = ofd.FileName;
                foreach (string fileName in ofd.FileNames)
                {
                    Stimulus[index - 1].PathPic = fileName;
                    Stimulus[index - 1].Width = Boxn[index - 1].Width;
                    Stimulus[index - 1].Height = Boxn[index - 1].Height;
                    PicPanel.Text = fileName;
                    break;
                }
            }
        }

        private void StimulusContrast_TB_TextChanged(object sender, EventArgs e)
        {
            TextBox ContrastVal = (TextBox)sender;
            String ContrastValName = ContrastVal.Name;
            int index = (int)Char.GetNumericValue(ContrastValName[(ContrastValName.Length - 4)]);

            Stimulus[index - 1].SetContrastPts(int.Parse(ContrastVal.Text));
        }

        private void FixationSize_ET_TextChanged(object sender, EventArgs e)
        {
            FixationPoint.Width = int.Parse(FixationSize_ET.Text);

        }

        private void BoxColor_BT_Click(object sender, EventArgs e)
        {

            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {

                Boxn[0].ColorBox = c.Color;
                Boxn[1].ColorBox = c.Color;
                BoxColor_BT.BackColor = c.Color;
            }
        }

        private void BoxWidth_ET_TextChanged(object sender, EventArgs e)
        {
            Boxn[0].Width = int.Parse(BoxWidth_ET.Text);
            Boxn[1].Width = int.Parse(BoxWidth_ET.Text);
        }

        private void BoxThickness_ET_TextChanged(object sender, EventArgs e)
        {
            Boxn[0].Thickness = int.Parse(BoxThickness_ET.Text);
            Boxn[1].Thickness = int.Parse(BoxThickness_ET.Text);
        }

        private void BoxHeight_ET_TextChanged(object sender, EventArgs e)
        {
            Boxn[0].Height = int.Parse(BoxHeight_ET.Text);
            Boxn[1].Height = int.Parse(BoxHeight_ET.Text);
        }

        private void StimulusWidth_TB_TextChanged(object sender, EventArgs e)
        {
            TextBox WidthVal = (TextBox)sender;
            String WidthValName = WidthVal.Name;
            int index = (int)Char.GetNumericValue(WidthValName[(WidthValName.Length - 4)]);

            Stimulus[index - 1].Width = int.Parse(WidthVal.Text);
        }

        private void UseCue_CB_CheckedChanged(object sender, EventArgs e)
        {
            Box_CB.Enabled = UseCue_CB.Checked;
            Arrow_CB.Enabled = UseCue_CB.Checked;
        }

        private void Arrow_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Arrow_CB.Checked)
                Box_CB.Checked = false;
            ArrowPanel.Enabled = Arrow_CB.Checked;
            
        }

        private void Box_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Box_CB.Checked)
                Arrow_CB.Checked = false;
            BoxPanel.Enabled = Box_CB.Checked;
        }

        private void ArrowLocX_ET_TextChanged(object sender, EventArgs e)
        {
            Cue.ArrowLocX0 = int.Parse(ArrowLocX_ET.Text) - Cue.ArrowWidth;
            Cue.ArrowLocX1 = int.Parse(ArrowLocX_ET.Text) + Cue.ArrowWidth;
        }

        private void ArrowLocY_ET_TextChanged(object sender, EventArgs e)
        {
            Cue.ArrowLocY = int.Parse(ArrowLocY_ET.Text) ;
        }

        private void SizeCue_ET_TextChanged(object sender, EventArgs e)
        {
            Cue.ArrowWidth = int.Parse(SizeCue_ET.Text);
        }

        private void ArrowColor_PB_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                ArrowColor_PB.BackColor = c.Color;
                Cue.ArrowColor = c.Color;
            }
        }

        private void RatioBox_ET_TextChanged(object sender, EventArgs e)
        {
            Cue.BoxRatio = float.Parse(RatioBox_ET.Text);
        }

        private void RepeatNumber_TextChanged(object sender, EventArgs e)
        {
            RepeatNum = int.Parse(RepeatNumber.Text);
        }

        private void LocationChoice_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            String value = (String)cmb.SelectedItem;

            char type = value[1];
            if (type == 'i')
                RandomLoc = 1;
            else if(type == 'e')
                RandomLoc = 2;
            else if(type == 'a')
                RandomLoc = 3;
            else
                RandomLoc = 0;

        }

        private void Change_PB_Click(object sender, EventArgs e)
        {
            if(EnableFrame_CB.Checked)
            {
                string selected = FrameIndex1_CB.GetItemText(FrameIndex1_CB.SelectedItem);

                if (int.Parse(selected) > 0)
                {
                    // frame 
                    int frameindex = int.Parse(selected);
                    ShowFr[] CopiedBox1 = new ShowFr[2];
                    Boxn[0].CenterX = Width / 4;
                    Boxn[0].CenterY = Height / 2;
                    Boxn[1].CenterX = 3 * Width / 4;
                    Boxn[1].CenterY = Height / 2;

                    CopiedBox1[0] = new ShowFr();
                    CopiedBox1[1] = new ShowFr();
                    if (Box_CB.Checked)
                    {
                        CopiedBox1[0].Thickness = Boxn[0].Thickness * Cue.BoxRatio;
                        CopiedBox1[0].SetShowFrameProp(Boxn[0].CenterX, Boxn[0].CenterY, Boxn[0].Width, Boxn[0].Height, CopiedBox1[0].Thickness, Boxn[0].ColorBox);
                    }
                    else
                        CopiedBox1[0] = Boxn[0];

                    CopiedBox1[1] = Boxn[1];

                    ShowBoxes.Add(CopiedBox1[0]);
                    ShowBoxes.Add(CopiedBox1[1]);
                    FrameIndexes.Add(frameindex);
                   FrameIndexes.Add(frameindex);

                    ShowFr[] CopiedBox2 = new ShowFr[2];
                    CopiedBox2[0] = new ShowFr();
                    CopiedBox2[1] = new ShowFr();
                    CopiedBox2[0] = Boxn[0];
                    CopiedBox2[1] = Boxn[1];

                   ShowBoxes.Add(CopiedBox2[0]);
                    ShowBoxes.Add(CopiedBox2[1]);
                    FrameIndexes.Add(frameindex + 1);
                    FrameIndexes.Add(frameindex + 1);

                    // stimulus
                    //FixationPts emptyStimulus = new FixationPts();
                    //Form1.AddedStimulusbyFrameTool.Add(emptyStimulus);
                    //Form1.AddedStimulusbyFrameTool.Add(emptyStimulus);

                    //Form1.StimulusIndexes.Add(frameindex);
                    //Form1.StimulusIndexes.Add(frameindex);

                    //Form1.AddedStimulusbyFrameTool.Add(Stimulus[0]);
                    //Form1.AddedStimulusbyFrameTool.Add(Stimulus[1]);
                    //Debug.Write("S0 " + Stimulus[0].Xloc + " " + Stimulus[1].Xloc + " " + " \n");
                    //Form1.StimulusIndexes.Add(frameindex + 1);
                    //Form1.StimulusIndexes.Add(frameindex + 1);

                    Stimulus[0].FrameIndex = frameindex + 1;
                    Stimulus[1].FrameIndex = frameindex + 1;
                    stimulusList.Add(Stimulus[0]);
                    stimulusList.Add(Stimulus[1]);

                    //// fixation
                    //Debug.Write("Deb " + " " + Form1.AddedStimulusbyFrameTool[0].Xloc + " " + Form1.AddedStimulusbyFrameTool[0].Yloc + " " + Form1.AddedStimulusbyFrameTool[0].Width  +  " " + Form1.StimulusIndexes[0] + "\n");
                    //Debug.Write("Deb " + " " + Form1.AddedStimulusbyFrameTool[1].Xloc + " " + Form1.AddedStimulusbyFrameTool[1].Yloc + " " + Form1.AddedStimulusbyFrameTool[1].Width +  " " + Form1.StimulusIndexes[0] + "\n");
                    //Form1.AddedFixationbyFrameTool.Add(FixationPoint);
                    //Form1.FixationIndexes.Add(frameindex + 1);

                    FixationPoint.FrameIndex = frameindex + 1;
                    FixationPoint.Type = 7;
                    FixationPoint.Enable = true;
                    fixationList[frameindex] = FixationPoint;

                    if (Arrow_CB.Checked)
                    {
                        Cue.BoxRatio = 1;
                        Cue.type = 1;
                        AddedHintsbyFrameTool.Add(Cue);
                        HintIndexes.Add(frameindex);
                    }
                    else if (Box_CB.Checked)
                    {
                        Cue.ArrowWidth = 0;
                        Cue.type = 2;
                        AddedHintsbyFrameTool.Add(Cue);
                        HintIndexes.Add(frameindex);
                    }
                    //else if (Contrast_CB.Checked)
                    //{

                    //}
                    //else
                    //{
                        
                    //}



                    int numRepeat = int.Parse(RepeatNumber.Text);
                    
                    if(numRepeat > 0)
                    {
                        RepeatedFrame[frameindex - 1] = numRepeat;
                        RepeatationLength[frameindex - 1] = 3;
                        RepeatedRandomLocation[frameindex - 1] = RandomLoc;
                    }
                    
                }

            }
            this.Close();
            
        }
    }
}
