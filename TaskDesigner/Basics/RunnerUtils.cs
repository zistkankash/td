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
		public static Queue<GazeTriple> Gaze = new Queue<GazeTriple>();
		public static int GazeSmoothPots = 1;
		static int _counter = 0;
		static double[,] pts = new double[2, GazeSmoothPots];

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

		public static double Mean(short row)
		{
			double res = 0;
			for (int i = 0; i < GazeSmoothPots; i++)
			{
				if (pts[0, i] != 0)
					res += pts[0, i];	
			}
			return res / GazeSmoothPots;
		}

		public static void ETGaze()
		{
			GazeTriple gzTemp = BasConfigs.server.getGaze;
			if (gzTemp.time != -1)
			{
				_counter = (_counter + 1) % GazeSmoothPots;
				pts[0, _counter] = gzTemp.x;
				pts[1, _counter] = gzTemp.y;
			}
			else
				return;
			gzTemp.x = Mean(0);
			gzTemp.y = Mean(1);
			Gaze.Enqueue(gzTemp);
		}
	}
}
