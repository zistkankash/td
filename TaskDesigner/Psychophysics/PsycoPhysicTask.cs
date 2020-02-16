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
			
            
		}
			                        		
		void AddCondition(bool newCond, int id)
		{
			string name = "", repeat = "1";
            if (newCond)
            {
                id = _tsk.AllLevelName.Count;
                name = "Cond" + id + 1;
                FrameProperties newFr = new FrameProperties();
                List<FrameProperties> newFrr = new List<FrameProperties>(1);
                newFrr.Add(newFr);
                _tsk.AllLevelProp.Add(newFrr);
            }
            else
            {
                name = _tsk.AllLevelName[id].Name;
                _tsk.AllLevelProp.Add(FrameProperties.Copy(_tsk.AllLevelProp[id]));
            }

			
			_tsk.AllLevelName.Add(new ConditionData(name,1));
            DataGridViewRow dr = new DataGridViewRow();

            dtgvConds.Rows.Add("name", 1, 1, 1000);
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

        private void btnRemCond_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this condition?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                
                _tsk.AllLevelProp.RemoveAt(dtgvConds.SelectedRows[0].Index);
                _tsk.AllLevelName.RemoveAt(dtgvConds.SelectedRows[0].Index);
                dtgvConds.Rows.RemoveAt(dtgvConds.SelectedRows[0].Index);

            }
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {

        }

        private void dtgvConds_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                int beta;
                if (int.TryParse((string)dtgvConds.Rows[e.RowIndex].Cells[e.ColumnIndex].Value, out beta))
                    _tsk.AllLevelName[e.RowIndex].Repeat = beta;
                else
                {
                    _tsk.AllLevelName[e.RowIndex].Repeat = 1;
                    dtgvConds.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1.ToString();
                }
            }
        }
        	
	}
}
