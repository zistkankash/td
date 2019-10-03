using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Psychophysics
{
    public partial class CTT_result : MetroFramework.Forms.MetroForm
    {
        public CTT_result()
        {
            InitializeComponent();
        }

        private void CTT_result_Load(object sender, EventArgs e)
        {

        }

        private void Tilecolor1_time_Click(object sender, EventArgs e)
        {
            //Tilecolor1_time.Location.X += 10; A: why it doesnt come forward?
            Pnlcolor1_time.Visible = true;
        }

        private void Tilecolor1_error_Click(object sender, EventArgs e)
        {
            Pnlcolor1_error.Visible = true;
        }

        private void Tilecolor1_nearmisses_Click(object sender, EventArgs e)
        {
            Pnlcolor1_nearmisses.Visible = true;
        }

        private void Tcolor1_prompts_Click(object sender, EventArgs e)
        {
            Pnlcolor1_prompts.Visible = true;
        }

        private void Tcolor2_prompts_Click(object sender, EventArgs e)
        {
            Pnlcolor2_prompts.Visible = true;
        }

        private void Tcolor2_nearmisses_Click(object sender, EventArgs e)
        {
            Pnlcolor2_nearmisses.Visible = true;
        }

        private void Tcolor2_error_Click(object sender, EventArgs e)
        {
            Pnlcolor2_error.Visible= true;

        }

        private void Tcolor2_time_Click(object sender, EventArgs e)
        {
            Pnlcolor1_time.Visible = true;
        }
    }
}
