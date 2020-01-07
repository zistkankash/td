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
		bool  _notToClosed = false;

		public URLInput()
		{
			InitializeComponent();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{

			if (txtbxURL.Text == "")
			{
				DialogResult dr = MetroFramework.MetroMessageBox.Show((IWin32Window)this, "URL is empty", "Enter URL", MessageBoxButtons.OK, MessageBoxIcon.Question, 100);
				_notToClosed = true;
			}
			else
			{
				if (!txtbxURL.Text.Contains("www"))
				{
					txtbxURL.Text = "www." + txtbxURL.Text;
				}
				if (!txtbxURL.Text.Contains("http"))
				{
					txtbxURL.Text = "http://" + txtbxURL.Text;
				}
				Uri uriResult;
				bool result = Uri.TryCreate(txtbxURL.Text, UriKind.Absolute, out uriResult)
					&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
				if (!result)
				{
					MetroFramework.MetroMessageBox.Show((IWin32Window)this, "URL is not valid. Check it please!", 100);
					_notToClosed = true;
				}
				else
				{
					DialogResult = DialogResult.OK;
					return;
				}
			}
			
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void URLInput_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_notToClosed)
			{
				e.Cancel = true;
				_notToClosed = false;
			}
			if (DialogResult == DialogResult.Cancel)
				txtbxURL.Text = "";
		}

	}
}
