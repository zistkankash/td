using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskLab
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
				Uri uriResult;
				bool result = Uri.TryCreate(txtbxURL.Text, UriKind.Absolute, out uriResult)
					&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
				if(!result)
				{
					MetroFramework.MetroMessageBox.Show((IWin32Window)this, "URL is not valid. Check it please!");
					return;
				}
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void URLInput_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.Cancel)
				txtbxURL.Text = "";
		}

	}
}
