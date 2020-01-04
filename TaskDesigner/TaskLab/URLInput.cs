using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskDesigner.TaskLab
{
    public partial class URLInput : Form
    {
        public URLInput()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtbxURL.Text == "")
            {
                DialogResult dr = MetroFramework.MetroMessageBox.Show((IWin32Window)this, "URL is empty. Do you want to continue?", "Enter URL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 50);
                if (dr == DialogResult.No)
                    return;
                Hide();
            }
        }
    }
}
