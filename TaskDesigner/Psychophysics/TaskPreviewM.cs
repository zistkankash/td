using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Web.UI;
using Basics;
using Psychophysics.Old;

namespace Psychophysics
{
    public partial class TaskPreviewM : MetroFramework.Forms.MetroForm
    {
        RowStyle SaveRowStyle;
        int TaskName ;
        public static int NFrame = 0;
        public static int NumberCol = 1;
        public static int ActiveCol = 1;
        int index = 1;
        public static List<int> BaseIndex = new List<int>();
        public static List<String> AllLevelName = new List<String>();
        public static FrameProperties[] FrameProps = new FrameProperties[NFrame];
        public static List<List<FrameProperties>> AllLevelProp = new List<List<FrameProperties>>();
       
        public static List<int> EnabledTask = new List<int>();
        public static List<int> NumerRepeat = new List<int>();
        public static int[] TaskIndex = new int[NFrame];
        public static bool ChangeHappened = false;
        public static double userDistance = 0.5;                   //A: make these userdefined at the end !!!!!!
        public static double WidthM = 0.42, HeightM = 0.26;
        public static double WidthP = 1440, HeightP = 900;
        public static Boolean[] selectedtask = new Boolean [10];  //A:pay attention we could just have 10 tasks...fix it later!??!?!?
        public static DataTable tasks = new DataTable();
 
        public TaskPreviewM()
        {
            InitializeComponent();
            AllLevelName.Add("Untitled" + (AllLevelName.Count + 1));
            BaseIndex.Add(0);
            //SaveRowStyle = GridVu.RowStyles[GridVu.RowCount - 1];

            EnabledTask.Add(0);
            NumerRepeat.Add(1);
            tasks.Columns.Add("Name", typeof(string));
            tasks.Columns.Add("Number of repeats", typeof(string));
            tasks.Columns.Add("Time", typeof(string));
            tasks.Columns.Add("Number of frames ", typeof(string));


        }

        private void TaskPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
            //Application.ExitThread();

            //foreach (Process Proc in Process.GetProcesses())
            //    if (Proc.ProcessName.Equals("TaskDesigner"))  //Process Excel?
            //        Proc.Kill();
        }

        private void t_new_Click(object sender, EventArgs e)
        {
            GridVu.Visible = true;
            TaskName = GridVu.RowCount;
            //this.GridVu.RowCount++;
            tasks.Rows.Add("Untitled" + TaskName,0,0,0);
            GridVu.DataSource = tasks;
            GridVu.Visible = true;
            Designer NormalFrm = new Designer(1, 0);
            NormalFrm.FormClosing += delegate { this.Show(); };
            this.Hide();
            NormalFrm.Show();
        }

        private void txbx_saveto_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Text File
                String SaveText = "";
                SaveText += "Number Of Levels\n";
                int levelcnt = AllLevelProp.Count;
                SaveText += levelcnt + "\n";
                for (int i = 0; i < levelcnt; i++)
                {
                    SaveText += "___Name\n";
                    SaveText += "___" + AllLevelName[i] + "\n";
                    SaveText += "___Number Of Repeatation\n";
                    int repeatnum = NumerRepeat[i];
                    SaveText += "___" + repeatnum + "\n";
                    SaveText += "___Number Of Frames\n";
                    int framecnt = AllLevelProp[i].Count;
                    SaveText += "___" + framecnt + "\n";
                    for (int j = 0; j < framecnt; j++)
                    {
                        SaveText += "______Frame" + j + "\n______" + AllLevelProp[i][j].FrameTime + " " + AllLevelProp[i][j].BGColor.R + " " + AllLevelProp[i][j].BGColor.G + " " + AllLevelProp[i][j].BGColor.B + "\n";
                        SaveText += "_________Fixation\n";
                        SaveText += "_________" + AllLevelProp[i][j].Fixation.Xloc + " " + AllLevelProp[i][j].Fixation.Yloc + " " + AllLevelProp[i][j].Fixation.Width + " " + AllLevelProp[i][j].Fixation.Type + " " + AllLevelProp[i][j].FixationTime + " " + AllLevelProp[i][j].Fixation.ColorPt.R + " " + AllLevelProp[i][j].Fixation.ColorPt.G + " " + AllLevelProp[i][j].Fixation.ColorPt.B + "\n";
                        int stimuluscnt = AllLevelProp[i][j].NumberSaccade;
                        SaveText += "_________Number Of Stimulus\n";
                        SaveText += "_________" + stimuluscnt + "\n";
                        for (int k = 0; k < stimuluscnt; k++)
                        {
                            SaveText += "_________Stimulus\n";
                            if (AllLevelProp[i][j].Stimulus[k].Type == 1 || AllLevelProp[i][j].Stimulus[k].Type == 5 || AllLevelProp[i][j].Stimulus[k].Type == 9)
                            {
                                SaveText += "_________" + AllLevelProp[i][j].Stimulus[k].Type + " " + AllLevelProp[i][j].Stimulus[k].Xloc + " " + AllLevelProp[i][j].Stimulus[k].Yloc + " " + AllLevelProp[i][j].Stimulus[k].Width + " " + AllLevelProp[i][j].Stimulus[k].Height + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.R + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.G + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.B + " " + AllLevelProp[i][j].Stimulus[k].Contrast + "\n";
                            }
                            if (AllLevelProp[i][j].Stimulus[k].Type == 2 || AllLevelProp[i][j].Stimulus[k].Type == 6 || AllLevelProp[i][j].Stimulus[k].Type == 10)
                            {
                                SaveText += "_________" + AllLevelProp[i][j].Stimulus[k].Type + " " + AllLevelProp[i][j].Stimulus[k].Xloc + " " + AllLevelProp[i][j].Stimulus[k].Yloc + " " + AllLevelProp[i][j].Stimulus[k].Width + " " + AllLevelProp[i][j].Stimulus[k].Height + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.R + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.G + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.B + " " + AllLevelProp[i][j].Stimulus[k].Contrast + "\n";
                            }
                            if (AllLevelProp[i][j].Stimulus[k].Type == 3 || AllLevelProp[i][j].Stimulus[k].Type == 7 || AllLevelProp[i][j].Stimulus[k].Type == 11)
                            {
                                SaveText += "_________" + AllLevelProp[i][j].Stimulus[k].Type + " " + AllLevelProp[i][j].Stimulus[k].Xloc + " " + AllLevelProp[i][j].Stimulus[k].Yloc + " " + AllLevelProp[i][j].Stimulus[k].Width + " " + AllLevelProp[i][j].Stimulus[k].Height + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.R + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.G + " " + AllLevelProp[i][j].Stimulus[k].ColorPt.B + " " + AllLevelProp[i][j].Stimulus[k].Contrast + "\n";
                            }
                            if (AllLevelProp[i][j].Stimulus[k].Type == 4 || AllLevelProp[i][j].Stimulus[k].Type == 8 || AllLevelProp[i][j].Stimulus[k].Type == 12)
                            {
                                if (File.Exists(AllLevelProp[i][j].Stimulus[k].PathPic))
                                {
                                    Uri uriFilePath = new Uri(@AllLevelProp[i][j].Stimulus[k].PathPic);
                                    SaveText += "_________" + AllLevelProp[i][j].Stimulus[k].Type + " " + AllLevelProp[i][j].Stimulus[k].Xloc + " " + AllLevelProp[i][j].Stimulus[k].Yloc + " " + AllLevelProp[i][j].Stimulus[k].Width + " " + AllLevelProp[i][j].Stimulus[k].Height + "\n_________" + AllLevelProp[i][j].Stimulus[k].PathPic + "\n";
                                }
                            }
                        }

                        SaveText += "_________Showframe\n";
                        int showframecnt = AllLevelProp[i][j].ShowFrame.Length;
                        SaveText += "_________" + showframecnt + "\n";
                        for (int k = 0; k < showframecnt; k++)
                        {
                            SaveText += "_________Showframe" + k + "\n";
                            SaveText += "_________" + AllLevelProp[i][j].ShowFrame[k].CenterX + " " + AllLevelProp[i][j].ShowFrame[k].CenterY + " " + AllLevelProp[i][j].ShowFrame[k].Width + " " + AllLevelProp[i][j].ShowFrame[k].Height + " " + AllLevelProp[i][j].ShowFrame[k].Thickness + " " + AllLevelProp[i][j].ShowFrame[k].ColorBox.R + " " + AllLevelProp[i][j].ShowFrame[k].ColorBox.R + " " + AllLevelProp[i][j].ShowFrame[k].ColorBox.R + "\n";
                        }

                        SaveText += "_________Cue\n";
                        if (AllLevelProp[i][j].Cue.type == 1)
                        {
                            SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.ArrowLocX0 + " " + AllLevelProp[i][j].Cue.ArrowLocX1 + " " + AllLevelProp[i][j].Cue.ArrowLocY + " " + AllLevelProp[i][j].Cue.Valid + " " + AllLevelProp[i][j].Cue.ArrowColor.R + " " + AllLevelProp[i][j].Cue.ArrowColor.G + " " + AllLevelProp[i][j].Cue.ArrowColor.B + " " + AllLevelProp[i][j].Cue.ArrowWidth + "\n";
                        }
                        else if (AllLevelProp[i][j].Cue.type == 2)
                        {
                            SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.BoxRatio + "\n";
                        }
                        else
                        {
                            SaveText += "_________" + AllLevelProp[i][j].Cue.type + "\n";
                        }

                        SaveText += "_________Reward\n";
                        SaveText += "_________" + AllLevelProp[i][j].RewardType + "\n";

                        SaveText += "_________RepeatInfo\n";
                        SaveText += "_________" + AllLevelProp[i][j].RepeatInfo.Active + " " + AllLevelProp[i][j].RepeatInfo.RepeatationNumber + " " + AllLevelProp[i][j].RepeatInfo.Length + " " + AllLevelProp[i][j].RepeatInfo.RandomLocation + "\n";
                    }
                }
                SaveText += "Distance " + userDistance + "\n";
                SaveText += "MoniTorWidth(m) " + WidthM + "\n";
                SaveText += "MoniTorHeight(m) " + HeightM + "\n";
                SaveText += "MoniTorWidth(pixel) " + WidthP + "\n";
                SaveText += "MoniTorHeight(pixel) " + HeightP + "\n";
                File.WriteAllText(sfd.FileName, SaveText);
            }
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {

        }

        private void t_delete_Click(object sender, EventArgs e)
        {
           
            for (int i = tasks.Rows.Count; i > 0; i--)
            {
                DataRow dr = tasks.Rows[i-1];
                if (selectedtask[i-1] == true)
                {
                    tasks.Rows.Remove(dr);
                    GridVu.DataSource = tasks;
                }
                    

            }
            tasks.AcceptChanges();

     
        }

        private void NumTrial_TB1_TextChanged(object sender, EventArgs e)
        {

        }

        private void t_edit_Click(object sender, EventArgs e)
        {
            Designer EditForm = new Designer(2, index);
            EditForm.FormClosing += delegate { this.Show(); };
            this.Hide();
            EditForm.Show();
           
        }

        private void GridVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //selectedtask[e.RowIndex] = true;  //A:which row have selected
        }

        private void GridVu_SelectionChanged(object sender, EventArgs e)
        {
           // selectedtask[e] = true;  //A:which row have selected
          
        }

        private void GridVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedtask[e.RowIndex] = true;  //A:which row have selected
        }

        private void t_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "Text Files (*.txt)|*.txt";
            theDialog.InitialDirectory = @"..";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                
                AllLevelProp.Clear();
                AllLevelName.Clear();
                BaseIndex.Clear();
                NumerRepeat.Clear();
                EnabledTask.Clear();
                using (var fs = File.OpenRead(theDialog.FileName))
                using (var reader = new StreamReader(fs))
                {
                    var line = reader.ReadLine();
                    line = reader.ReadLine();
                    int NumberLevel = int.Parse(line);
                    for (int i = 0; i < NumberLevel; i++)
                    {
                        BaseIndex.Add(0);
                        List<FrameProperties> ListAddedFrame = new List<FrameProperties>();

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        AllLevelName.Add(line.Substring(3));

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        int repeatnumber = int.Parse(line.Substring(3));
                        NumerRepeat.Add(repeatnumber);
                        EnabledTask.Add(2);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        int NumberFrame = int.Parse(line.Substring(3));

                        for (int j = 0; j < NumberFrame; j++)
                        {
                            FrameProperties varFrame = new FrameProperties();

                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            var values = line.Substring(6).Split(' ');
                            int FrameTime = int.Parse(values[0]);
                            //Debug.Write("Load Debug " + line.Substring(6) + " " + values[0] + "\n");
                            Color BGColor = Color.FromArgb(255, int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));

                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            values = line.Substring(9).Split(' ');
                            FixationPts varFixation = new FixationPts();
                            //varFixation.SetFixationPts(int.Parse(), int.Parse(), int.Parse(), int.Parse(),Color.FromArgb(255, int.Parse(), int.Parse(), int.Parse()));
                            Color fixationColor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
                            varFixation.SetFixationPts(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), fixationColor);
                            int fixationtime = int.Parse(values[4]);
                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            //Debug.Write("Load Debug " + line.Substring(9)+ "\n");
                            int NumberStimulus = int.Parse(line.Substring(9));
                            FixationPts[] varStimulus = new FixationPts[NumberStimulus];

                            for (int k = 0; k < NumberStimulus; k++)
                            {
                                line = reader.ReadLine();
                                line = reader.ReadLine();
                                values = line.Substring(9).Split(' ');
                                Debug.Write("Load Debug " + line.Substring(9) + "\n");

                                varStimulus[k] = new FixationPts();
                                if (int.Parse(values[0]) == 4 || int.Parse(values[0]) == 8 || int.Parse(values[0]) == 12)
                                {
                                    line = reader.ReadLine();
                                    varStimulus[k].SetPicture(int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[0]), line.Substring(9));
                                }
                                else
                                {
                                    Color stimulusColor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
                                    varStimulus[k].SetFixationPts(int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[0]), stimulusColor);
                                    varStimulus[k].SetContrastPts(int.Parse(values[8]));
                                }
                            }
                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            int NumberShowFrame = int.Parse(line.Substring(9));
                            ShowFr[] varShowFrame = new ShowFr[NumberShowFrame];
                            for (int k = 0; k < NumberShowFrame; k++)
                            {
                                varShowFrame[k] = new ShowFr();
                                line = reader.ReadLine();
                                line = reader.ReadLine();
                                values = line.Substring(9).Split(' ');
                                Color showframecolor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
                                varShowFrame[k].SetShowFrameProp(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), showframecolor);
                            }
                            //MainForm.MeanX_PupilCenter[i] = Double.Parse(values[0]);

                            HintForm varCue = new HintForm();
                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            values = line.Substring(9).Split(' ');

                            varCue.type = int.Parse(values[0]);
                            if (int.Parse(values[0]) == 1)
                            {
                                //SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.ArrowLocX0 + " " + AllLevelProp[i][j].Cue.ArrowLocX1 + " " + AllLevelProp[i][j].Cue.ArrowLocY + " " + AllLevelProp[i][j].Cue.ArrowColor.R + " " + AllLevelProp[i][j].Cue.ArrowColor.G + " " + AllLevelProp[i][j].Cue.ArrowColor.B + " " + AllLevelProp[i][j].Cue.ArrowWidth;
                                Color showframecolor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));

                                varCue.ArrowWidth = int.Parse(values[8]);
                                varCue.SetArrowProp(int.Parse(values[3]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[4]), showframecolor);
                            }
                            else if (int.Parse(values[0]) == 2)
                            {
                                //SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.BoxRatio + "\n";
                                varCue.SetBoxProp(20, int.Parse(values[1]), Color.Black);
                            }
                            else
                            {

                            }


                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            int reward = int.Parse(line.Substring(9));
                            ////Debug.Write("Load Debug " + line.Substring(9) + "\n");

                            varFrame.SetProperties(BGColor, FrameTime, varFixation, fixationtime, NumberStimulus, varStimulus, reward, varCue, NumberShowFrame, varShowFrame);
                            Debug.Write("FixTime1 : " + varFrame.FixationTime + "\n");

                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            values = line.Substring(9).Split(' ');
                            RepeatLinkFrame repeatInfo = new RepeatLinkFrame();
                            repeatInfo.SetProperties(bool.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));

                            varFrame.RepeatInfo = repeatInfo;

                            ListAddedFrame.Add(varFrame);
                        }
                        AllLevelProp.Add(ListAddedFrame);
                    }
                    line = reader.ReadLine();
                    var value = line.Split(' ');
                    userDistance = double.Parse(value[1]);

                    line = reader.ReadLine();
                    value = line.Split(' ');
                    WidthM = double.Parse(value[1]);

                    line = reader.ReadLine();
                    value = line.Split(' ');
                    HeightM = double.Parse(value[1]);

                    line = reader.ReadLine();
                    value = line.Split(' ');
                    WidthP = double.Parse(value[1]);

                    line = reader.ReadLine();
                    value = line.Split(' ');
                    HeightP = double.Parse(value[1]);

                    for (int i = 0; i < AllLevelProp.Count; i++)
                    {
                        //add a new RowStyle as a copy of the previous one
                       // this.GridVu.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));
                        this.GridVu.RowCount++;

                        var namebox = new TextBox();
                        namebox.Name = "NameTask_TB" + (GridVu.RowCount - 1);
                        //namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);

                        namebox.Text = AllLevelName[i];
                      //  GridVu.Controls.Add(namebox, 0, this.GridVu.RowCount - 1);


                        /* var Combox = new ComboBox();
                         Combox.Items.Add(" ");
                         Combox.Items.Add("Normal");
                         Combox.Items.Add("MGS");
                         Combox.Items.Add("VGS");
                         Combox.Items.Add("Posner");
                         Combox.Items.Add("Delete");
                         Combox.Name = "SelectTask_CB" + (GridVu.RowCount - 1);
                         Debug.Write(" Combo" + Combox.Name + "\n");*/
                        //Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
                        //this.GridVu.Controls.Add(Combox, 1, this.GridVu.RowCount - 1);
                        var txbox = new TextBox();
                        txbox.Text = Convert.ToString(NumerRepeat[i]);
                        txbox.Name = "NumTrial_TB" + (GridVu.RowCount - 1);
                        //txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);

                        //GridVu.Controls.Add(txbox, 2, this.GridVu.RowCount - 1);
                        //GridVu.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (GridVu.RowCount - 1) }, 3, this.GridVu.RowCount - 1);
                        //GridVu.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (GridVu.RowCount - 1) }, 4, this.GridVu.RowCount - 1);
                        ////UpdateData(i + 1);
                        //UpdateComboBox(i + 1);
                    }



                }
            }
        }

        private void UpdateData(int Index)
        {
            int time = 0;
            if (AllLevelProp.Count > 0)
            {
                for (int i = 0; i < AllLevelProp[Index - 1].Count; i++)
                {
                    if (AllLevelProp[Index - 1][i].RepeatInfo.Active)
                    {
                        int varTime = 0;
                        for (int j = 0; j < AllLevelProp[Index - 1][i].RepeatInfo.Length; j++)
                            varTime += AllLevelProp[Index - 1][i + j].FrameTime;
                        time += AllLevelProp[Index - 1][i].RepeatInfo.RepeatationNumber * varTime;
                        i = i + AllLevelProp[Index - 1][i].RepeatInfo.Length - 1;
                    }
                    else
                    {
                        time += AllLevelProp[Index - 1][i].FrameTime;
                    }
                }
                Label timeLB = Controls.Find("TotalTime_LB" + Index, true).FirstOrDefault() as Label;
                Label numFrLB = Controls.Find("FramePerTask_LB" + Index, true).FirstOrDefault() as Label;
                numFrLB.Text = Convert.ToString(AllLevelProp[Index - 1].Count);

                TextBox numtrialTB = Controls.Find("NumTrial_TB" + Index, true).FirstOrDefault() as TextBox;
                numtrialTB.Text = Convert.ToString(NumerRepeat[Index - 1]);
                TextBox nametaskTB = Controls.Find("NameTask_TB" + Index, true).FirstOrDefault() as TextBox;
                nametaskTB.Text = AllLevelName[Index - 1];
                timeLB.Text = Convert.ToString(time * int.Parse(numtrialTB.Text));
            }
            else //A: probably it goes in this when all the tasks deleted 
            {
                Label timeLB = Controls.Find("TotalTime_LB" + Index, true).FirstOrDefault() as Label;
                Label numFrLB = Controls.Find("FramePerTask_LB" + Index, true).FirstOrDefault() as Label;
                numFrLB.Text = Convert.ToString(0);
                timeLB.Text = Convert.ToString(0);

                TextBox numtrialTB = Controls.Find("NumTrial_TB" + Index, true).FirstOrDefault() as TextBox;
                numtrialTB.Text = Convert.ToString(NumerRepeat[Index - 1]);
                TextBox nametaskTB = Controls.Find("NameTask_TB" + Index, true).FirstOrDefault() as TextBox;
                nametaskTB.Text = AllLevelName[Index - 1];
                timeLB.Text = Convert.ToString(time * int.Parse(numtrialTB.Text));
            }


        }





    }
}
