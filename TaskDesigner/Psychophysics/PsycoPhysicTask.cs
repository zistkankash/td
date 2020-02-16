using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Basics;
using TaskRunning;

namespace Psychophysics
{
    public partial class PsycoPhysicTask : Form
    {
		public PsycophysicTasks _tsk = new PsycophysicTasks(20);
				
		Size namTxt, numTrilTxt, cmbSiz;
		public int ActiveCol;
		// Display Option
		
		//
		int TaskName = 1;
				
		
		RowStyle SaveRowStyle;

		List<List<int>> test = new List<List<int>>();
			
		
        bool eventLock = false;

        public PsycoPhysicTask()
		{
			InitializeComponent();
					
		}
        		
		
		void TaskPreview_Load(object sender, EventArgs e)
		{
								
            eventLock = true;
		}
		
		void frmCoolForm_XCoolFormHolderButtonClick(XCoolForm.XCoolForm.XCoolFormHolderButtonClickArgs e)
		{
			switch (e.ButtonIndex)
			{
				case 0:
					if (_tsk.EnabledTask.Count == _tsk.AllLevelProp.Count)
					{
						TaskName++;
						Add_PB_Click(null, null);
						
					}
					break;
				case 1:
					{
						if (_tsk.LoadTaskFromFile(true, null))
						{
							MessageBox.Show("Selected task loaded successfully!", "Load Task");
							FillTaskTable();
						}

					}
					break;
				case 2:
					{
						if (_tsk.SavePsycoPhysicTask(true))
							MessageBox.Show("Selected task saved successfully!", "Save Task");
					}
					break;
				case 4:
					//Setting SettingFrm = new Setting();
					//SettingFrm.FormClosing += delegate { this.Show(); };
					//this.Hide();
					//SettingFrm.Show();
					break;
							
				
				case 5:
					break;
				case 6:
					break;
			}

		}
		
        void FillTaskTable()
        {
            
            for (int i = 0; i < _tsk.AllLevelProp.Count; i++)
            {
                //add a new RowStyle as a copy of the previous one
                this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));

                var namebox = new TextBox();
                namebox.Name = "NameTask_TB" + (Task_Table.RowCount);
                namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);
                namebox.Size = namTxt;
                namebox.Text = _tsk.AllLevelName[i];
                Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount);
               

                
				
                txbox.Text = Convert.ToString(_tsk.NumerRepeat[i]);
                txbox.Name = "NumTrial_TB" + (Task_Table.RowCount);
                txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
                txbox.Size = numTrilTxt;
                Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount);
                Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount).ToString() }, 3, this.Task_Table.RowCount);
                Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount).ToString() }, 4, this.Task_Table.RowCount);
                this.Task_Table.RowCount++;
                UpdateData(i + 1);
                UpdateComboBox(i);
            }
        }

        void SelectTask_CB_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (!eventLock)
                return;
			ComboBox cmb = (ComboBox)sender;

			String cmbName = cmb.Name;
			int index = int.Parse(cmbName.Substring(13));
            ActiveCol = index + 1;
			int selectedIndex = cmb.SelectedIndex;
			String selectedText = cmb.Text;
			
			switch (selectedText)
			{
				case "VGS":
					break;
				case "MGS":
					break;
				case "Design":
					//this.Visible = false;
					Designer NormalFrm = new Designer(1, 0, this);
					NormalFrm.FormClosing += delegate { this.Show(); this.UpdateComboBox(index); };
					this.Hide();
					NormalFrm.Show();
					break;
				case "Copy":
					AddCondition(false, index);
					NameTask_TB0.Select();
					break; 
				case "Posner":
					break;
				case "Discrimination":
					break;
				case "Delete":
					if (MessageBox.Show("Do you want to delete this condition?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
					{
						if (_tsk.AllLevelProp.Count > 0)//&& AllLevelProp[index - 1].Count > 1
						{

							_tsk.AllLevelProp.RemoveAt(index);
							_tsk.AllLevelName.RemoveAt(index);
							_tsk.NumerRepeat.RemoveAt(index);
							_tsk.EnabledTask.RemoveAt(index);
							_tsk.BaseIndex.RemoveAt(index);

							FillTaskTable();
						}
					}
					NameTask_TB0.Select();
					break;

				case "Edit":
					Designer EditForm = new Designer(2, index, this);
					EditForm.FormClosing += delegate { this.Show(); this.UpdateComboBox(index); };
					this.Hide();
					EditForm.Show();
					break;
				
				default:


					break;
			}


		}

		public void TaskPreview_VisibleChanged(object sender, EventArgs e)
		{
			if ( !eventLock || !this.Visible)
				return;
			NameTask_TB0.Select();
			if (ActiveCol > 0 && _tsk.AllLevelProp. Count > 0)
			{
				Label FrCountLB = Controls.Find("FramePerTask_LB" + (ActiveCol - 1), true).FirstOrDefault() as Label;
				FrCountLB.Text = Convert.ToString(_tsk.AllLevelProp[ActiveCol - 1].Count);
				UpdateData(ActiveCol);
			}
		}

		void Add_PB_Click(object sender, EventArgs e)
		{
            eventLock = false;
			//add a new RowStyle as a copy of the previous one
			AddCondition(true, -1);
            eventLock = true;
		}

		void AddCondition(bool newCond, int id)
		{
			this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));
			this.Task_Table.RowCount++;

			string name = "", repeat = "1";
			if (newCond)
				name = "Untitled" + TaskName;
				
			else
			{
				name = _tsk.AllLevelName[id];
				_tsk.AllLevelProp.Add(FrameProperties.Copy(_tsk.AllLevelProp[id]));
				_tsk.EnabledTask.Add(2);
				repeat = _tsk.NumerRepeat[id].ToString();
			}

			var namebox = new TextBox();
			namebox.Name = "NameTask_TB" + (Task_Table.RowCount - 1);
			namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);

			_tsk.AllLevelName.Add(name);
			_tsk.BaseIndex.Add(0);
			namebox.Text = name;
			namebox.Size = namTxt;
			Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount - 1);

			_tsk.NumerRepeat.Add(1);
			var Combox = new ComboBox();
			Combox.Size = cmbSiz;
			Combox.Items.Add(" ");
			if (newCond)
				Combox.Items.Add("Design");
			else
			{
				Combox.Items.Add("Delete");
				Combox.Items.Add("Edit");
				Combox.Items.Add("Copy");
			}
			

			Combox.Name = "SelectTask_CB" + (Task_Table.RowCount - 1);
			Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
			this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount - 1);
			var txbox = new TextBox();
			txbox.Text = repeat;
			txbox.Name = "NumTrial_TB" + (Task_Table.RowCount - 1);
			txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
			txbox.Size = numTrilTxt;
			Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount - 1);
			
			Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount - 1) }, 3, this.Task_Table.RowCount - 1);
			Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount - 1) }, 4, this.Task_Table.RowCount - 1);
			if(!newCond)
				UpdateData(Task_Table.RowCount);
		}

		void UpdateSelectedRow()
		{
            int _ind = dtgvConds.SelectedRows[0].Index;
			int time = 0;
			if (_tsk.AllLevelProp.Count > 0)
			{
                for (int i = 0; i < _tsk.AllLevelProp[_ind].Count; i++)
                {

                    time += _tsk.AllLevelProp[_ind][i].FrameTime;

                }
                dtgvConds.SelectedRows[0].Cells[3].Value = Convert.ToString(time);
                dtgvConds.SelectedRows[0].Cells[2].Value = Convert.ToString(_tsk.AllLevelProp[_ind].Count);

                dtgvConds.SelectedRows[0].Cells[1].Value = Convert.ToString(_tsk.AllLevelName[_ind].Repeat);
                dtgvConds.SelectedRows[0].Cells[0].Value = Convert.ToString(_tsk.AllLevelName[_ind].Name);
                
			}
			
		}
		
		void Stop_PB_Click(object sender, EventArgs e)
		{
			_tsk.Brake = true;
		}

		void Task_Table_Scroll(object sender, ScrollEventArgs e)
		{
			return;
		}

		void NumTrial_TB_TextChanged(object sender, EventArgs e)
		{
            if (!eventLock)
                return;
			TextBox cmb = (TextBox)sender;

			String cmbName = cmb.Name;
			int index = int.Parse(cmbName.Substring(11));
			try
            {
				_tsk.NumerRepeat[index] = int.Parse(cmb.Text);
                
            }
            catch(Exception)
            {
				_tsk.NumerRepeat[index] = 1;
				cmb.Text = "";
                
            }
            UpdateData(index + 1);
        }

        void Start_PB_Click(object sender, EventArgs e)
        {
            if (_tsk.AllLevelProp.Count == 0)
            {
                MessageBox.Show("Can not show empty task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _tsk.Brake = false;

            _tsk.SeqRandTaskRunner = 2;
            
            PsycophysicsRunner ShFrame = new PsycophysicsRunner(false, 0, 0, _tsk);

            ShFrame.Show();
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {

        }

        void UpdateComboBox()
		{
			if (_tsk.EnabledTask[index] == 2)
			{
				ComboBox comb = Task_Table.Controls.Find("SelectTask_CB" + index, true).FirstOrDefault() as ComboBox;
				comb.Items.Clear();
				comb.Items.Add("Delete");
				comb.Items.Add("Edit");
				comb.Items.Add("Copy");
			}
		}
               
                
		void NameTask_TB_TextChanged(object sender, EventArgs e)
		{
            if (!eventLock)
                return;
			TextBox cmb = (TextBox)sender;
			String cmbName = cmb.Name;
			int index = int.Parse(cmbName.Substring(11));
			_tsk.AllLevelName[index] = cmb.Text;
		}

		
	}
}
