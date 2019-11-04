using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using MetroFramework;
using TaskRunning;

namespace Basics
{
	public partial class NetSettingForm : MetroFramework.Forms.MetroForm
	{
		int _conectMessageShowed = 0;
		public NetSettingForm()
		{
			InitializeComponent();
			
		}

		private void COGLAB_Load(object sender, EventArgs e)
		{
			TxtbxLIP.Enabled = false;
			TxtbxLIP.Text = TaskServer.GetLocalIP();
			setBtnNetSettingText();
			txtbxLport.Text = "5050";
			UpdateNetControls();
			Select();
		}

		private void setBtnNetSettingText()
		{
			if (TxtbxLIP.Text == "127.0.0.1")
				btnNetAddressSet.Text = "Network IP";
			else
				btnNetAddressSet.Text = "Local IP";
		}

		private void btnNetAddressSet_Click(object sender, EventArgs e)
		{
			
			if (TxtbxLIP.Text != "127.0.0.1")
			{
				MetroMessageBox.Show((IWin32Window)this, "Use 127.0.0.1 and Port " + txtbxLport.Text + " in ET connection window.", "Network Address", MessageBoxButtons.OK, MessageBoxIcon.Information, 120);
				TxtbxLIP.Text = "127.0.0.1";
			}
			else
			{
				TxtbxLIP.Text = TaskServer.GetLocalIP();
				if (TxtbxLIP.Text == "127.0.0.1")
				{
					MetroMessageBox.Show((IWin32Window)this, "Network address not found. Use 127.0.0.1 and Port " + txtbxLport.Text + " in ET connection window.", "Network Address", MessageBoxButtons.OK, MessageBoxIcon.Information, 120);
				}
				else
					MetroMessageBox.Show((IWin32Window)this, "Please use IP " + TxtbxLIP.Text + " and Port " + txtbxLport.Text +" in ET connection window.", "Network Address",MessageBoxButtons.OK,MessageBoxIcon.Information,120);
			}
			setBtnNetSettingText();
		}

		private void btnConct_Click(object sender, EventArgs e)
		{
			if (BasConfigs.server == null || BasConfigs.server.serverDisposed)
			{
				BasConfigs.server = new TaskServer(short.Parse(txtbxLport.Text), this);
				if (BasConfigs.server.StartListening())
				{
					UpdateNetControls();
					coglabRefrshForm.Start();
				}
				else
					MetroMessageBox.Show((IWin32Window)this, "Please change the Port", "COGLAB Connection");
			}
			else
			{
				if (BasConfigs.server.GazeTracker == null)
				{
					MetroMessageBox.Show((IWin32Window)this, "Can not disconnect due to lack of ET connection!", "COGLAB Connection", 120);
					return;
				}
				BasConfigs.server.Dispose();

				btnNetAddressSet.Enabled = true;
				MetroMessageBox.Show((IWin32Window)this, "ET Was Disconnected", "ET Connection", MessageBoxButtons.OK, MessageBoxIcon.Stop, 100);
				btnConct.Text = "Start Connection";

				coglabRefrshForm.Stop();
			}
		}

		private void txtbxLport_TextChanged(object sender, EventArgs e)
		{
			try { int.Parse(txtbxLport.Text); txtbxLport.BackColor = Color.AliceBlue; btnConct.Enabled = true; }
			catch (Exception) { txtbxLport.BackColor = Color.Red; btnConct.Enabled = false; }
		}

		private void UpdateNetControls()
		{
			ETStatus ns = BasConfigs.GetNetStatus();
			if (ns == ETStatus.disconnected)
			{
				txtbxLport.Enabled = true;
				btnConct.Enabled = true;
				btnNetAddressSet.Enabled = true;
				btnConct.Text = "Start Connection";
				return;
			}
			if (ns == ETStatus.listening)
			{
				txtbxLport.Enabled = false;
				btnConct.Enabled = false;
				btnNetAddressSet.Enabled = false; ;
				btnConct.Text = "Waiting for ET to connect";
				return;
			}

			if (ns == ETStatus.Connected)
			{
				_conectMessageShowed++;
				btnConct.Enabled = true;
				txtbxLport.Enabled = false;
				btnNetAddressSet.Enabled = false;
				if (_conectMessageShowed == 0)
				{
					coglabRefrshForm.Stop();
					MetroMessageBox.Show((IWin32Window)this, "ET was connected", "ET Connection", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, 100);
					coglabRefrshForm.Start();
				}

				btnConct.Text = "Disconnect";

				if (_conectMessageShowed == 3)
					Close();
			}
			
			return;


		}

		private void coglabRefrshForm_Tick(object sender, EventArgs e)
		{
			UpdateNetControls();
		}

		private void COGLAB_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				if (BasConfigs.GetNetStatus() == ETStatus.listening)
				{
					MetroMessageBox.Show((IWin32Window)this, "Waiting for Et to connect.", "ET Connection", 100);
					return;
				}
				else
					Close();
			}
		}

		private void NetSettingForm_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

		private void NetSettingForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				if (BasConfigs.GetNetStatus() == ETStatus.listening)
				{
					MetroMessageBox.Show((IWin32Window)this, "Waiting for Et to connect.", "ET Connection", 100);
					return;
				}
				else
					Close();
			}
		}
	}
}
