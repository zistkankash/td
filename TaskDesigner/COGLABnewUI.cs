using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Analyses;
using Psychophysics;
using TaskDesigner;
using TaskRunning;
using System.Diagnostics;

namespace Basics
{
	public partial class COGLABnewUI : Form
	{
		public bool connected = false;
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public COGLABnewUI()
		{
			InitializeComponent();
			Select();
			BasConfigs.GetScreenConfigs();

			#region psychophysics polygon and button
			Point[] p_psychophysics = {
		new Point(330, 50),
		new Point(415,75),
		new Point(518, 120),
		new Point(340,  230)
		};

			GraphicsPath polygon_path_psychophysics = new GraphicsPath(FillMode.Winding);
			polygon_path_psychophysics.AddPolygon(p_psychophysics);

			// Convert the GraphicsPath into a Region.
			Region polygon_region_psychophysics = new Region(polygon_path_psychophysics);

			// Constrain the button to the region.
			btn_psychophysics.Region = polygon_region_psychophysics;

			// Make the button big enough to hold the whole region.
			btn_psychophysics.SetBounds(
				btn_psychophysics.Location.X,
				btn_psychophysics.Location.Y,
				p_psychophysics[1].X + 5, p_psychophysics[3].Y + 5);
			btn_psychophysics.Enabled = true;
			btn_psychophysics.Visible = true;
			#endregion
			#region setting  polygon and button

			Point[] p_setting = {
		new Point(327, 40),
		new Point(230,50),
		new Point(132, 140),
		new Point(317,  230)
		};

			GraphicsPath polygon_path_setting = new GraphicsPath(FillMode.Winding);
			polygon_path_setting.AddPolygon(p_setting);

			// Convert the GraphicsPath into a Region.
			Region polygon_region_setting = new Region(polygon_path_setting);

			// Constrain the button to the region.
			btn_setting.Region = polygon_region_setting;

			// Make the button big enough to hold the whole region.
			btn_setting.SetBounds(
				btn_setting.Location.X,
				btn_setting.Location.Y,
				p_setting[1].X + 5, p_setting[3].Y + 5);
			btn_setting.Enabled = true;
			btn_setting.Visible = true;
			#endregion
			#region psychology polygon and button
			Point[] p_psychology = {
		new Point(513, 135),
		new Point(550,260),
		new Point(530, 350),
		new Point(350,  250)
		};

			GraphicsPath polygon_path_psychology = new GraphicsPath(FillMode.Winding);
			polygon_path_psychology.AddPolygon(p_psychology);

			// Convert the GraphicsPath into a Region.
			Region polygon_region_psychology = new Region(polygon_path_psychology);

			// Constrain the button to the region.
			btn_psychology.Region = polygon_region_psychology;

			// Make the button big enough to hold the whole region.
			btn_psychology.SetBounds(
				btn_psychology.Location.X,
				btn_psychology.Location.Y,
				p_psychology[1].X + 5, p_psychology[3].Y + 5);
			btn_psychology.Enabled = true;
			btn_psychology.Visible = true;
			#endregion
			#region linguistics polygone and button
			Point[] p_linguistics = {
		new Point(515, 345),
		new Point(458,445),
		new Point(330, 500),
		new Point(340,  240)
		};

			GraphicsPath polygon_path_linguistics = new GraphicsPath(FillMode.Winding);
			polygon_path_linguistics.AddPolygon(p_linguistics);

			// Convert the GraphicsPath into a Region.
			Region polygon_region_linguistics = new Region(polygon_path_linguistics);

			// Constrain the button to the region.
			btn_linguistics.Region = polygon_region_linguistics;

			// Make the button big enough to hold the whole region.
			btn_linguistics.SetBounds(
				btn_linguistics.Location.X,
				btn_linguistics.Location.Y,
				p_linguistics[1].X + 5, p_linguistics[3].Y + 5);
			btn_linguistics.Enabled = true;
			btn_linguistics.Visible = true;

			#endregion
			#region analysis polygon and button
			Point[] p_analysis = {
		new Point(322, 500),
		new Point(220,490),
		new Point(130, 390),
		new Point(322,  270)
		};

			GraphicsPath polygon_path_analysis = new GraphicsPath(FillMode.Winding);
			polygon_path_analysis.AddPolygon(p_analysis);

			// Convert the GraphicsPath into a Region.
			Region polygon_region_analysis = new Region(polygon_path_analysis);

			// Constrain the button to the region.
			btn_analysis.Region = polygon_region_analysis;

			// Make the button big enough to hold the whole region.
			btn_analysis.SetBounds(
				btn_analysis.Location.X,
				btn_analysis.Location.Y,
				p_analysis[1].X + 5, p_analysis[3].Y + 5);
			btn_analysis.Enabled = true;
			btn_analysis.Visible = true;
			#endregion
			#region Trunner polygon and button
			Point[] p_trunner = {
		 new Point(125, 380),
		new Point(115,270),
		new Point(115, 140),
		new Point(300,  250)
		};

			GraphicsPath polygon_path_trunner = new GraphicsPath(FillMode.Winding);
			polygon_path_trunner.AddPolygon(p_trunner);

			// Convert the GraphicsPath into a Region.
			Region polygon_region_trunner = new Region(polygon_path_trunner);

			// Constrain the button to the region.
			btn_trunner.Region = polygon_region_trunner;

			// Make the button big enough to hold the whole region.
			btn_trunner.SetBounds(
				btn_trunner.Location.X,
				btn_trunner.Location.Y,
				p_trunner[1].X + 5, p_trunner[3].Y + 5);
			btn_trunner.Enabled = true;
			btn_trunner.Visible = true;

			#endregion
		}

		private void btn_psychophysics_Click(object sender, EventArgs e)
		{
			try
			{
				Psychophysics.TaskPreview task = new Psychophysics.TaskPreview();
				task.FormClosed += delegate { Show(); Select();};
				this.Hide();
				task.Show();
			}
			catch(Exception)
			{
				return;
			}
		}

		private void btn_setting_Click(object sender, EventArgs e)
		{
			NetSettingForm nt = new NetSettingForm();
			nt.FormClosed += delegate { Show(); Select(); };
			Hide();
			nt.ShowDialog();
		}

		private void btn_psychology_Click(object sender, EventArgs e)
		{
			//try
			//{
			//	TaskLab.TaskGen taskLab = new TaskLab.TaskGen(TaskType.lab);
			//	taskLab.FormClosed += delegate { Show(); Select(); };
			//	this.Hide();
			//	taskLab.Show();
			//}
			//catch(Exception)
			//{
			//	return;
			//}
		}

		private void btn_linguistics_Click(object sender, EventArgs e)
		{
			try
			{
				TaskLab.TaskGen taskLab = new TaskLab.TaskGen(TaskType.picture);
				taskLab.FormClosed += delegate { Show(); Select(); };
				this.Hide();
				taskLab.Show();
			}
			catch(Exception)
			{
				return;
			}
		}

		private void btn_analysis_Click(object sender, EventArgs e)
		{
			try
			{
				HeatMap heat = new HeatMap();
				heat.FormClosed += delegate { Show(); Select(); };
				this.Hide();
				heat.Show();
			}
			catch(Exception)
			{
				return;
			}
		}

		private void btn_trunner_Click(object sender, EventArgs e)
		{
			try
			{
				TaskOperator runner;
				ETStatus ns = BasConfigs.GetNetStatus();
				if (ns == ETStatus.listening)
				{
					MessageBox.Show("You pressed Start Connection but ET not connected to Runner to get gaze data points. Please go to ET connection window and press Connect button.", "");
					
				}

				runner = new TaskOperator();
				runner.FormClosed += delegate { Show(); Select(); };
				this.Hide();

				runner.Show();
			}
			catch(Exception)
			{
				return;
			}

		}

		private void COGLABnewUI_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.ExitThread();
			Application.Exit();

			foreach (Process Proc in Process.GetProcesses())
				if (Proc.ProcessName.Equals("TaskDesigner"))
					Proc.Kill();
		}

		private void COGLABnewUI_KeyUp(object sender, KeyEventArgs e)
		{
			//if (e.KeyCode == Keys.Escape)
				//Close();
		}

		private void COGLABnewUI_Load(object sender, EventArgs e)
		{
			this.CenterToScreen();
		}
		
		public bool ThumbnailCallback()
		{
			return false;
		}

		private void COGLABnewUI_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private void backUpdater_Tick(object sender, EventArgs e)
		{
			
		}

		private void COGLABnewUI_Paint(object sender, PaintEventArgs e)
		{
			if (BasConfigs.GetNetStatus() == ETStatus.Connected)
			{
				connected = true;
			}
			else
				connected = false;

			//this.BackgroundImage = BitmapData.TakeBlurSnapshot(this);
			//BackColor = Color.FromArgb(25, pnl_cntrl.BackColor);
			//var hb = new HatchBrush(HatchStyle.Sphere, this.TransparencyKey);

			//e.Graphics.FillRectangle(hb, this.DisplayRectangle);
		}

		private void pnl_cntrl_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private void btn_analysis_MouseClick(object sender, MouseEventArgs e)
		{

		}

		private void COGLABnewUI_KeyDown(object sender, KeyEventArgs e)
		{
			if (!e.Handled)
				if (e.KeyCode == Keys.Escape)
				{
					Close();
				}
		}
		
		private void mtlCls_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void mtlMov_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private void btn_analysis_MouseEnter(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3_analysis_selected_green;
			else
				pnl_cntrl.BackgroundImage = Resource.main3_analysis_selected;
		}

		private void btn_analysis_MouseLeave(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3_connected;
			else
				pnl_cntrl.BackgroundImage = Resource.main3_final;
		}

		private void btn_linguistics_MouseEnter(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3_linguistics_selected_green;
			else
				pnl_cntrl.BackgroundImage = Resource.main3_linguistics_selected;
		}

		private void btn_linguistics_MouseLeave(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3_connected;
			else
				pnl_cntrl.BackgroundImage = Resource.main3_final;
		}

		private void btn_psychology_MouseEnter(object sender, EventArgs e)
		{
			//if (connected)
			//	pnl_cntrl.BackgroundImage = Resource.main3_psycologyselected_green;
			//else
			//	pnl_cntrl.BackgroundImage = Resource.main3_psycologyselected;
		}

		private void btn_psychology_MouseLeave(object sender, EventArgs e)
		{
			//if (connected)
			//	pnl_cntrl.BackgroundImage = Resource.main3_connected;
			//else
			//	pnl_cntrl.BackgroundImage = Resource.main3_final;
		}

		private void btn_psychophysics_MouseEnter(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3__psychophysics_seleced_green;
			else
				pnl_cntrl.BackgroundImage = Resource.main3__psychophysics_seleced;
		}

		private void btn_psychophysics_MouseLeave(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3_connected;
			else
				pnl_cntrl.BackgroundImage = Resource.main3_final;
		}

		private void btn_setting_MouseEnter(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3_setting_selected_green;
			else
				pnl_cntrl.BackgroundImage = Resource.main3_setting_selected;
		}

		private void btn_trunner_MouseEnter(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3_runner_selected_green;
			else
				pnl_cntrl.BackgroundImage = Resource.main3_runnerselected;
		}

		private void btn_trunner_MouseLeave(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3_connected;
			else
				pnl_cntrl.BackgroundImage = Resource.main3_final;
		}

		private void btn_setting_MouseLeave(object sender, EventArgs e)
		{
			if (connected)
				pnl_cntrl.BackgroundImage = Resource.main3_connected;
			else
				pnl_cntrl.BackgroundImage = Resource.main3_final;
		}

		private void btnMinmiz_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
	}
}
