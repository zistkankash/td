using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using TaskRunning;
using MetroFramework;
using Psychophysics;
using Analyses;

namespace Basics
{
    public partial class COGLAB : MetroFramework.Forms.MetroForm
    {
		public static TaskServer server;
		TaskOperator runner;

        public COGLAB()
        {
            InitializeComponent();
			Size = new Size(438, 322);
			pnlNetSetting.Visible = false;
        }

        private void btnHeatMap_Click(object sender, EventArgs e)
        {
            HeatMap heat = new HeatMap();
            heat.FormClosed += delegate { Show(); };
            this.Hide();
            heat.Show();
        }

        private void btnCogLab_Click(object sender, EventArgs e)
        {
            Psychophysics.TaskPreview task = new Psychophysics.TaskPreview();
            task.FormClosed += delegate { Show(); };  
            this.Hide();
            task.Show();
            
        }

        private void btnTaskLab_Click(object sender, EventArgs e)
        {
            TaskLab.TaskGen taskLab = new TaskLab.TaskGen(TaskType.lab);
            taskLab.FormClosed += delegate { Show(); };
            this.Hide();
            taskLab.Show();
        }

        private void COGLAB_FormClosing(object sender, FormClosingEventArgs e)
        {
			Application.Exit();
            Application.ExitThread();

            foreach (Process Proc in Process.GetProcesses())
                if (Proc.ProcessName.Equals("TaskDesigner"))
                    Proc.Kill();
        }

        private void btnNetSetting_Click(object sender, EventArgs e)
        {

			if (pnlNetSetting.Visible == true)
			{
				Size = new Size(438, 322);
				pnlNetSetting.Visible = false;
			}
			else
			{
				Size = new Size(438, 426);
				pnlNetSetting.Visible = true;
				pnlNetSetting.BringToFront();
			}
		}

       	private void COGLAB_Load(object sender, EventArgs e)
		{
			TxtbxLIP.Enabled = false;
			
			TxtbxLIP.Text = TaskServer.GetLocalIP();
			setBtnNetSettingText();
			txtbxLport.Text = "5050";
		}
		
		private void metroBtnImageTask_Click(object sender, EventArgs e)
		{
			TaskLab.TaskGen taskLab = new TaskLab.TaskGen(TaskType.picture);
			
			taskLab.FormClosed += delegate { Show(); };
			this.Hide();
			taskLab.Show();
		}

		private void btnTaskRun_Click(object sender, EventArgs e)
		{
		
			NetStatus ns = GetNetStatus();
			if (ns == NetStatus.listening)
			{
				MetroMessageBox.Show((IWin32Window)this,"You pressed Start Connection. press Connect in ET Net window to run a task please.",120);
				return;
			}
			
			runner = new TaskOperator(server);
			runner.FormClosed += delegate { Show(); };
			this.Hide();
			
			runner.Show();
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
			DialogResult dr = DialogResult.Cancel;;
			if (TxtbxLIP.Text != "127.0.0.1")
			{
				dr = MetroMessageBox.Show((IWin32Window)this, "Use 127.0.0.1 in ET connection window.", "Network Address",120);
				if (dr == DialogResult.OK)
				
					TxtbxLIP.Text = "127.0.0.1";
			}
			else
			{
				TxtbxLIP.Text = TaskServer.GetLocalIP();
				if(TxtbxLIP.Text == "127.0.0.1")
				{
					MetroMessageBox.Show((IWin32Window)this, "Network address not found. Use local IP (127.0.0.1) in ET connection window.", "Network Address",120);
				}
			}
			setBtnNetSettingText();
		}

		private void btnConct_Click(object sender, EventArgs e)
		{
			if (server == null || server.serverDisposed)
			{
				server = new TaskServer(short.Parse(txtbxLport.Text), this);
				if (server.StartListening())
				{
					UpdateNetControls();
					coglabRefrshForm.Start();
				}
				else
					MetroMessageBox.Show((IWin32Window)this, "Please change the Port", "COGLAB Connection");
			}
			else
			{
				if (server.GazeTracker == null)
				{
					MetroMessageBox.Show((IWin32Window)this, "Can not disconnect due to lack of ET connection!", "COGLAB Connection", 120);
					return;
				}
				server.Dispose();
				
				btnNetAddressSet.Enabled = true;
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
			NetStatus ns = GetNetStatus();
			if (ns == NetStatus.disconnected)
			{
				txtbxLport.Enabled = true;
				btnConct.Enabled = true;
				btnNetAddressSet.Enabled = true;
				btnConct.Text = "Start Connection";

				return;
			}
			if (ns== NetStatus.listening)
			{
				txtbxLport.Enabled = false;
				btnConct.Enabled = false;
				btnNetAddressSet.Enabled = false; ;
				btnConct.Text = "Waiting for ET to connect";
				return;
			}

			btnConct.Enabled = true;
			txtbxLport.Enabled = false;
			btnNetAddressSet.Enabled = false;
			btnConct.Text = "Disconnect";
			return;


		}

		private NetStatus GetNetStatus()
		{
			if (server == null || server.serverDisposed)
			{
				return NetStatus.disconnected;
			}
			if (server.serverListening)
			{
				return NetStatus.listening;
			}

			return NetStatus.Connected;
		}
	
		private void coglabRefrshForm_Tick(object sender, EventArgs e)
		{
			UpdateNetControls();
		}

		private void COGLAB_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				Close();
		}
	}
	public enum NetStatus { Connected , listening , disconnected}
}
