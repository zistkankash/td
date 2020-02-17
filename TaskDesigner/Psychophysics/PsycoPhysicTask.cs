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
		public PsycophysicTasks _tsk = new PsycophysicTasks();
        bool _edited = false;

        public PsycoPhysicTask()
		{
			InitializeComponent();
					
		}
        	
		void TaskPreview_Load(object sender, EventArgs e)
		{
			
            
		}

        #region handler methods

        void AddCondition(NewCondition Cond, int id)
		{
			string name = "";
            int repeat = 1;
            if (Cond == NewCondition.New)
            {
                id = _tsk.AllLevelName.Count;
                name = "Cond" + (id + 1).ToString();
                FrameProperties newFr = new FrameProperties();
                List<FrameProperties> newFrr = new List<FrameProperties>(1);
                newFrr.Add(newFr);
                _tsk.AllLevelProp.Add(newFrr);
            }
            if (Cond == NewCondition.Copy)
            {
                name = _tsk.AllLevelName[id].Name;
                repeat = _tsk.AllLevelName[id].Repeat;
                _tsk.AllLevelProp.Add(FrameProperties.Copy(_tsk.AllLevelProp[id]));
            }

			
			_tsk.AllLevelName.Add(new ConditionData(name, repeat));
            DataGridViewRow dr = new DataGridViewRow();

            dtgvConds.Rows.Add(name, 1, 1, 1000);
		}

		void UpdateRow(int _ind)
		{
            int time = 0;
			if (_tsk.AllLevelProp.Count > _ind)
			{
                for (int i = 0; i < _tsk.AllLevelProp[_ind].Count; i++)
                {

                    time += _tsk.AllLevelProp[_ind][i].FrameTime;

                }
                dtgvConds.Rows[_ind].Cells[3].Value = Convert.ToString(time);
                dtgvConds.Rows[_ind].Cells[2].Value = Convert.ToString(_tsk.AllLevelProp[_ind].Count);

                dtgvConds.Rows[_ind].Cells[1].Value = Convert.ToString(_tsk.AllLevelName[_ind].Repeat);
                dtgvConds.Rows[_ind].Cells[0].Value = Convert.ToString(_tsk.AllLevelName[_ind].Name);
                
			}
			
		}
                
        void FillTable()
        {
            for (int i = 0; i < _tsk.AllLevelProp.Count; i++)
            {
                dtgvConds.Rows.Add(_tsk.AllLevelName[i].Name, _tsk.AllLevelName[i].Repeat, 0, 0);
                UpdateRow(i);
            }
        }

        bool CheckSave()
        {
            if (!_edited)
                return true;
            if (MessageBox.Show("All task data will erased!. Do you want to continue?","Save Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return _tsk.SavePsycoPhysicTask(true);
            }
            else
                return false;
        }

        #endregion

        #region dtdgCond handlers

        private void dtgvConds_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnRepeat_KeyPress);
            if (dtgvConds.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnRepeat_KeyPress);
                }
            }
        }

        private void ColumnRepeat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtgvConds_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.ColumnIndex == 1)
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
        
        private void dtgvConds_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgvConds_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvConds.SelectedRows.Count > 0)
            {
                pnlMenu.Enabled = true;
            }
            else
                pnlMenu.Enabled = false;
        }

        #endregion

        #region menu buttons

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
            if(CheckSave())
            {
                _tsk = new PsycophysicTasks();
            }
        }

        private void btnRemCond_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this condition?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                _tsk.AllLevelProp.RemoveAt(dtgvConds.SelectedRows[0].Index);
                _tsk.AllLevelName.RemoveAt(dtgvConds.SelectedRows[0].Index);
                dtgvConds.Rows.RemoveAt(dtgvConds.SelectedRows[0].Index);
                _edited = true;
            }
        }

        private void btnAddCond_Click(object sender, EventArgs e)
        {
            AddCondition(NewCondition.New, -1);
            _edited = true;
        }

        private void btnEditCond_Click(object sender, EventArgs e)
        {
            Hide();
            Designer dr = new Designer(2, dtgvConds.SelectedRows[0].Index, this);
            dr.FormClosed += ( delegate { UpdateRow(dtgvConds.SelectedRows[0].Index); Show(); _edited = true; });

            dr.Show();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (CheckSave())

                if (_tsk.LoadTaskFromFile(true, ""))
                {
                    FillTable();
                    MessageBox.Show("Selected task was loaded successfully!");
                }
                else
                    MessageBox.Show("Selected task was not loaded! May be corrupted file.");
           

        }
               
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_tsk.SavePsycoPhysicTask(true))
                MessageBox.Show("Task was saved successfully!");
            else
                MessageBox.Show("Task was not saved! May be wrong address file.");

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            AddCondition(NewCondition.Copy, dtgvConds.SelectedRows[0].Index);
        }

        #endregion
    }

    public enum NewCondition { New, Copy}
}
