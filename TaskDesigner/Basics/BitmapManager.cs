﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Basics
{
	public static class BitmapManager
	{
		
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

		public static Bitmap TextBitmap(string st, Color BackColor, Brush TextColor, Size BitmapSize,short fontSize)
		{
			if (TextColor == null)
				TextColor = Brushes.DimGray;

			Bitmap bmp = new Bitmap(BitmapSize.Width, BitmapSize.Height);

			RectangleF rectf = new RectangleF(10, BitmapSize.Height / 4, BitmapSize.Width, BitmapSize.Height / 2 + 10);

			Graphics g = Graphics.FromImage(bmp);
			g.Clear(BackColor);
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.DrawString(st, new Font("Arial", fontSize), TextColor, rectf);

			g.Flush();

			return bmp;
		}

		/// <summary>
		/// Make a source copy of input bitmap to a new bitmap with specific size and specific back color.
		/// </summary>
		/// <param name="image"></param>
		/// <param name="s"></param>
		/// <param name="bgColor"></param>
		/// <returns></returns>
		public static Bitmap DrawOn(Bitmap image, Size s, Color bgColor)
		{
			if (s.Width == 0)
				return new Bitmap(2,2);
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

		/// <summary>
		/// Make a source over of input bitmap (iamge1) to bitmap image2.
		/// </summary>
		/// <param name="image"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static Bitmap DrawOn(Bitmap image1, Bitmap image2)
		{
			var destRect = new Rectangle(0, 0, image2.Width, image2.Height);
			
			using (var graphics = Graphics.FromImage(image2))
			{
				graphics.CompositingMode = CompositingMode.SourceOver;
				graphics.CompositingQuality = CompositingQuality.GammaCorrected;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				
				//image1.SetResolution(image2.HorizontalResolution, image2.VerticalResolution);
				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image1, destRect, 0, 0, image1.Width, image1.Height, GraphicsUnit.Pixel, wrapMode);
				}
				
			}
			return image2;
		}


		/// <summary>
		/// Make a source over of input bitmap (iamge1) to bitmap image2 with opacity applied to image1.
		/// </summary>
		/// <param name="image"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		public static Bitmap DrawOn(Bitmap image1, Bitmap image2,float opacity)
		{
			var destRect = new Rectangle(0, 0, image2.Width, image2.Height);
			ColorMatrix matrix = new ColorMatrix();
			//set the opacity  
			matrix.Matrix33 = opacity;
			using (var graphics = Graphics.FromImage(image2))
			{
				graphics.CompositingMode = CompositingMode.SourceOver;
				graphics.CompositingQuality = CompositingQuality.GammaCorrected;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				//image1.SetResolution(image2.HorizontalResolution, image2.VerticalResolution);
				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					wrapMode.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
					graphics.DrawImage(image1, destRect, 0, 0, image1.Width, image1.Height, GraphicsUnit.Pixel, wrapMode);
				}

			}
			return image2;
		}
		
		
		public static Bitmap TakeBlurSnapshot(Form form)
		{
			Bitmap bmp = new Bitmap(form.Size.Width, form.Size.Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
			g.CopyFromScreen(form.PointToScreen(form.ClientRectangle.Location), new Point(0, 0), form.ClientRectangle.Size);
			Image<Bgr, byte> btmp = new Image<Bgr, byte>(bmp);
			CvInvoke.GaussianBlur(btmp, btmp, new Size(7,7), 20);
			return btmp.Bitmap;
		}


	}
}
