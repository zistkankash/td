﻿using System;
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
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public COGLABnewUI()
		{
			InitializeComponent();
			#region psychophysics polygon and button
			Point[] p_psychophysics = {
		new Point(330, 20),
		new Point(428,40),
		new Point(518, 120),
		new Point(330,  250)
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
		new Point(327, 20),
		new Point(217,40),
		new Point(117, 130),
		new Point(327,  250)
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
		new Point(520, 125),
		new Point(570,260),
		new Point(540, 355),
		new Point(332,  250)
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
		new Point(528, 355),
		new Point(478,460),
		new Point(330, 500),
		new Point(330,  250)
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
		new Point(332,  250)
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
		new Point(75,270),
		new Point(115, 140),
		new Point(317,  250)
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
			Psychophysics.TaskPreview task = new Psychophysics.TaskPreview();
			task.FormClosed += delegate { Show(); };
			this.Hide();
			task.Show();
		}

		private void btn_setting_Click(object sender, EventArgs e)
		{
			NetSettingForm nt = new NetSettingForm();
			nt.ShowDialog();
		}

		private void btn_psychology_Click(object sender, EventArgs e)
		{
			TaskLab.TaskGen taskLab = new TaskLab.TaskGen(TaskType.lab);
			taskLab.FormClosed += delegate { Show(); };
			this.Hide();
			taskLab.Show();
		}

		private void btn_linguistics_Click(object sender, EventArgs e)
		{
			TaskLab.TaskGen taskLab = new TaskLab.TaskGen(TaskType.picture);
			taskLab.FormClosed += delegate { Show(); };
			this.Hide();
			taskLab.Show();
		}

		private void btn_analysis_Click(object sender, EventArgs e)
		{
			HeatMap heat = new HeatMap();
			heat.FormClosed += delegate { Show(); };
			this.Hide();
			heat.Show();
		}

		private void btn_trunner_Click(object sender, EventArgs e)
		{
			TaskOperator runner;
			ETStatus ns = BasConfigs.GetNetStatus();
			if (ns == ETStatus.listening)
			{
				MessageBox.Show("You pressed Start Connection. press Connect in ET Net window to run a task please.","");
				return;
			}

			runner = new TaskOperator(BasConfigs.server);
			runner.FormClosed += delegate { Show(); };
			this.Hide();

			runner.Show();
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
			if (e.KeyCode == Keys.Escape)
				Close();
		}

		private void COGLABnewUI_Load(object sender, EventArgs e)
		{
			//backUpdater.Start();
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
	}
}
