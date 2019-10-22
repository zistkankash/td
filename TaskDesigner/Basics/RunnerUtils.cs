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
	}
}
