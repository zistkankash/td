using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text;

namespace Basics
{
	public static class RunnerUtils
	{
		public static bool _onEventGaze = false;
		public static int _gazeSmoothPots = 1;
		static int _counter = 0;
		static double[,] pts;
		//public delegate void RunnerGazeDelegate(GazeTriple args);
		public static event EventHandler<GazeTriple> GazeReady;
		public static MicroLibrary.MicroStopwatch microTimerLive;
		
		public static double TwoPointDist(double px, double py, double ox, double oy)
		{
			return Math.Sqrt(Math.Pow(Math.Abs(px - ox), 2) + Math.Pow(Math.Abs(py - oy), 2));
		}

        public static string ToFarsiNumber(this string input)
        {
            var arabicDigits = CultureInfo.GetCultureInfo("fa-IR").NumberFormat.NativeDigits;
            var rb = new StringBuilder();
            foreach (var c in input)
            {
                rb.Append(char.IsDigit(c) ? arabicDigits[int.Parse(c.ToString())] : c.ToString());
            }
            return rb.ToString();
        }

        public static Bitmap PutString(string putex,Point pt)
		{
			var img = new Bitmap(Basics.BasConfigs._monitor_resolution_x, Basics.BasConfigs._monitor_resolution_y, PixelFormat.Format32bppArgb);
			var graphics = Graphics.FromImage(img);
			graphics.DrawString(putex, new Font("Arial", 72), Brushes.White, pt);
			return img;
		}

        public static void PutString(string putex, Point pt, SolidBrush TextColor, ref Bitmap Context)
        {
            var graphics = Graphics.FromImage(Context);
            graphics.DrawString(putex, new Font("Arial", 18), TextColor, pt);
            
        }

        public static double MeanPts(short row)
		{
			double res = 0;
			for (int i = 0; i < _gazeSmoothPots; i++)
			{
				if (pts[row, i] != 0)
					res += pts[row, i];	
			}
			return res / _gazeSmoothPots;
		}

		public static bool StartGaze(bool EventualGaze)
		{
			if (BasConfigs.server != null)// && BasConfigs.server.IsCalibrated == ETStatus.ready)
			{
				pts = new double[2, _gazeSmoothPots];
				_counter = 0;
				if (EventualGaze)
				{
					if (GazeReady == null)
						return false;
					BasConfigs.server.OnGaze += EventGaze;
				}
				return  BasConfigs.server.StartGaze();
			}
			return false;

		}

		public static void EventGaze(object sender, GazeTriple gzTemp)
		{
			//GazeTriple gzTemp = null;

			//gzTemp = BasConfigs.server.getGaze;
			if (gzTemp.time != -1)
			{
				pts[0, _counter] = gzTemp.x;
				pts[1, _counter] = gzTemp.y;
				_counter = (_counter + 1) % _gazeSmoothPots;
			}
			else
				return;
			gzTemp.x = MeanPts(0);
			gzTemp.y = MeanPts(1);
			GazeReady(null, gzTemp);

			return;
		}

		public static GazeTriple ETGaze()
		{
			GazeTriple gzTemp = null;
			if (BasConfigs.server != null && BasConfigs.server.getGaze != null)
			{
				gzTemp = BasConfigs.server.getGaze;
				if (gzTemp.time != -1)
				{
					pts[0, _counter] = gzTemp.x;
					pts[1, _counter] = gzTemp.y;
					_counter = (_counter + 1) % _gazeSmoothPots;
				}
				else
					return null;
				gzTemp.x = MeanPts(0);
				gzTemp.y = MeanPts(1);
			}
			return gzTemp;
		}
				
		public static bool EndGaze()
		{
			if (BasConfigs.server != null && !BasConfigs.server._endGaze)
			{
				BasConfigs.server.OnGaze -= EventGaze;
				return BasConfigs.server.EndGaze();
			}
			return false;
		}
		
		public static void ClearGaze()
		{
			_counter = 0;
			Array.Clear(pts, 0, pts.Length);
		}

		/// <summary>
		/// Give a bitmap as input and make up BitIn as output bitmap using config options. If BitIn equala null return false else true.
		/// </summary>
		/// <param name="BgColor"></param>
		/// <param name="Image"></param>
		/// <param name="SetTransparent"></param>
		/// <param name="TransBGColor"></param>
		/// <param name="ChessDraw"></param>
		/// <param name="BitIn">Output bitmap must be assigned.</param>
		/// <returns></returns>
		public static bool MediaPictureRenderer(Color BgColor, Bitmap Image, bool SetTransparent, Color TransBGColor,bool ChessDraw, ref Bitmap BitIn)
		{
			if (BitIn == null)
				return false;
			BitIn = BitmapManager.DrawOn(Image, BitIn.Size, BgColor);
			if (SetTransparent)
				BitIn.MakeTransparent(TransBGColor);
			if (ChessDraw)
				BitmapManager.ChessboardDraw(ref BitIn);
			return true;
		}
	}
}
