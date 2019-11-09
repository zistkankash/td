using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
	public static class RunnerUtils
	{
		public static int GazeSmoothPots = 11;
		static int _counter = 0;
		static double[,] pts = new double[2, GazeSmoothPots];
		
		public static MicroLibrary.MicroStopwatch microTimerLive;
		
		public static double twoDist(double px, double py, double ox, double oy)
		{
			return Math.Sqrt(Math.Pow(Math.Abs(px - ox), 2) + Math.Pow(Math.Abs(py - oy), 2));
		}

		public static Bitmap PutString(string putex,Point pt)
		{
			var img = new Bitmap(Basics.BasConfigs._monitor_resolution_x, Basics.BasConfigs._monitor_resolution_y, PixelFormat.Format32bppArgb);
			var graphics = Graphics.FromImage(img);
			graphics.DrawString(putex, new Font("Arial", 72), Brushes.White, pt);
			return img;
		}

		public static double MeanPts(short row)
		{
			double res = 0;
			for (int i = 0; i < GazeSmoothPots; i++)
			{
				if (pts[row, i] != 0)
					res += pts[row, i];	
			}
			return res / GazeSmoothPots;
		}

		public static bool StartGaze()
		{
			if (BasConfigs.server != null && BasConfigs.server.IsCalibrated == ETStatus.ready)
			{
				return  BasConfigs.server.StartGaze();
			}
			return false;

		}
		
		public static GazeTriple ETGaze()
		{
			GazeTriple gzTemp = BasConfigs.server.getGaze;
			if (gzTemp.time != -1)
			{
				
				pts[0, _counter] = gzTemp.x;
				pts[1, _counter] = gzTemp.y;
				_counter = (_counter + 1) % GazeSmoothPots;
			}
			else
				return null;
			gzTemp.x = MeanPts(0);
			gzTemp.y = MeanPts(1);
			return gzTemp;
		}

		public static bool EndGaze()
		{
			if (BasConfigs.server != null && BasConfigs.server.IsCalibrated == ETStatus.ready)
			{
				return BasConfigs.server.EndGaze();
			}
			return false;
		}
		
		public static void ClearGaze()
		{
			_counter = 0;
			Array.Clear(pts, 0, pts.Length);
		}
	}
}
