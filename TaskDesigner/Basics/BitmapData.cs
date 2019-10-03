using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Basics
{
	public static class BitmapData
	{
		public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
		{
			Bitmap result = new Bitmap(width, height);
			using (Graphics g = Graphics.FromImage(result))
			{
				g.DrawImage(bmp, 0, 0, width, height);
			}

			return result;
		}

		public static void ChessboardDraw(ref Bitmap input)
		{
			Graphics g = Graphics.FromImage(input);

			Pen myPen = new Pen(Color.Black);
			myPen.Width = 0.05F;
			float[] dashValues = { 5, 2 };
			myPen.DashPattern = dashValues;

			int hg = input.Height / 20;
			int wg = input.Width / 20;

			for (int i = 1; i < 21; i++)
			{
				g.DrawLine(myPen, new Point(0, i * hg), new Point(input.Width, i * hg));

				g.DrawLine(myPen, new Point(i * wg + 1, 0), new Point(i * wg + 1, input.Height));

			}

		}

		public static Bitmap PutText(string st, Color bc, Size sz)
		{
			Bitmap bmp = new Bitmap(sz.Width, sz.Height);

			RectangleF rectf = new RectangleF(10, sz.Height / 4, sz.Width, sz.Height / 2 + 10);

			Graphics g = Graphics.FromImage(bmp);
			g.Clear(bc);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.DrawString(st, new Font("Calibri", 20), Brushes.Black, rectf);

			g.Flush();

			return bmp;
		}

		public static Bitmap ResizeToFit(Bitmap imageData, Size size, bool expand)
		{
			try
			{

				if (size.Width == imageData.Width &&
					size.Height == imageData.Height)
				{
					return imageData;
				}

				var width = (float)size.Width;
				var height = (float)size.Height;

				var xRatio = width / imageData.Width;
				var yRatio = height / imageData.Height;

				var ratio = Math.Min(xRatio, yRatio);

				// If we are not expanding the image to fit and the resulting ratio indicates expansion, do not transform the image.
				if (!expand && ratio >= 1.0f)
				{
					return imageData;
				}

				var newSize = new Size(Math.Min(size.Width, (int)Math.Round(imageData.Width * ratio, MidpointRounding.AwayFromZero)), Math.Min(size.Height, (int)Math.Round(imageData.Height * ratio, MidpointRounding.AwayFromZero)));

				// Invialidate internally stored thumbnails.
				imageData.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
				imageData.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

				var newImage = new Bitmap(newSize.Width, newSize.Height);

				using (var g = Graphics.FromImage(newImage))
				{
					g.SmoothingMode = SmoothingMode.HighQuality;
					g.InterpolationMode = InterpolationMode.HighQualityBicubic;
					g.PixelOffsetMode = PixelOffsetMode.HighQuality;
					g.DrawImage(imageData, new Rectangle(new Point(0, 0), newSize));
				}

				//using (MemoryStream outStream = new MemoryStream(1024))
				//{
				//	//newImage.Save(outStream, ImageFormat.Jpeg);


				//}
				return newImage;


			}
			catch
			{
				return imageData;
			}
		}

		public static Bitmap DrawOn(Bitmap image, Size s, Color bgColor)
		{
			var destRect = new Rectangle(0, 0, s.Width, s.Height);
			var destImage = new Bitmap(s.Width, s.Height);
			
			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				if(bgColor != null)
					graphics.Clear(bgColor);
				if (image != null)
				{
					destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
					using (var wrapMode = new ImageAttributes())
					{
						wrapMode.SetWrapMode(WrapMode.TileFlipXY);
						graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
					}
				}
			}
			return destImage;
		}
	}
}
