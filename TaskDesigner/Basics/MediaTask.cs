using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using TaskLab;

namespace Basics
{
	public class MediaTask : TaskData
	{
		public List<Picture> picList;
		public int showedIndex;
		public Color backColor;
		public bool setTransparency = false;
		public bool drawChess = false;
		public Color transColor;

		private Image<Rgb, byte> tskImg;

		public Image<Rgb, byte> GetTaskImage { get { return tskImg; } }

		public MediaTask()
		{
			base._taskIsReady = false;
			picList = new List<Picture>();
			showedIndex = -1;
			tskImg = new Image<Rgb, byte>(BasConfigs._monitor_resolution_x,BasConfigs._monitor_resolution_y);
		}

		public void Clear()
		{
			base._taskIsReady = false;
			if (picList != null)
				picList.Clear();
		}

		public Bitmap GetFrame(int selSlide, Size pbSize)
		{
			Bitmap b = new Bitmap(100, 100);

			if (selSlide == -1 || picList == null || picList.Count == 0 || selSlide == picList.Count)
				return b;

			if (picList[selSlide].address != null)
				b = BitmapManager.DrawOn(picList[selSlide].image, pbSize, picList[selSlide].bgColor);
			else
				b = BitmapManager.DrawOn(null, pbSize, picList[selSlide].bgColor);

			if (setTransparency)
				b.MakeTransparent(transColor);


			if (drawChess)
			{
				BitmapManager.ChessboardDraw(ref b);

			}

			return b;
		}

		public bool Load(string[] lines)
		{
			
				picList = new List<Picture>();
				
				string[] temp = lines[2].Split(' ');
				int count;
				Int32.TryParse(temp[2], out count);
				for (int i = 0; i < count; i++)
				{
					string[] s = lines[i + 3].Split(',');
					if (s[0] == "BackGround: ")
					{
						int r, g, b;
						Int32.TryParse(s[1], out r);
						Int32.TryParse(s[2], out g);
						Int32.TryParse(s[3], out b);
						Color bg = Color.FromArgb(r, g, b);
						int time;
						Int32.TryParse(s[4], out time);
						Picture pic = new Picture(null, null, time);
						pic.bgColor = bg;
						picList.Add(pic);
					}
					else
					{
						string address = s[0];
						int time;
						Int32.TryParse(s[1], out time);
						Bitmap bit = new Bitmap(address);
						Picture pic = new Picture(bit, address, time);
						picList.Add(pic);
					}
				}
				
				tskImg.Bitmap = picList[0].image;

			return true;
		}

		public bool Load(byte[] tskFile, int readIndex)
		{

			long longVar = BitConverter.ToInt64(tskFile, readIndex);
			readIndex += sizeof(Int64);
			//DateTime dateTimeVar = new DateTime(1980, 1, 1).AddMilliseconds(longVar);
			DateTime dateTimeVar = DateTime.FromBinary(longVar);


			int count = BitConverter.ToInt32(tskFile, readIndex);
			readIndex += sizeof(Int32);
			ImageConverter imConverter = new ImageConverter();

			picList = new List<Picture>();

			for (int i = 0; i < count; i++)
			{
				int length = BitConverter.ToInt32(tskFile, readIndex);
				readIndex += sizeof(Int32);
				byte[] compImg = new byte[length];
				Buffer.BlockCopy(tskFile, readIndex, compImg, 0, length);

				Bitmap x = (Bitmap)imConverter.ConvertFrom(ByteManager.Decompress(compImg));
				readIndex += length;
				byte R = tskFile[readIndex];
				byte G = tskFile[readIndex + 2];
				byte B = tskFile[readIndex + 4];

				readIndex += 6;

				int time = BitConverter.ToInt32(tskFile, readIndex);
				readIndex += sizeof(Int32);
				picList.Add(new Picture(x, Color.FromArgb(R, G, B), time, "image address"));
			}
			tskImg.Bitmap = picList[0].image;

			return true;
		}

		private bool BinImageWrite()
		{
			List<byte> lines = new List<byte>();
			byte[] imgByts;
			lines.AddRange(BitConverter.GetBytes((short)TaskType.media));
			lines.AddRange(BitConverter.GetBytes(System.DateTime.Now.ToBinary()));
			lines.AddRange(BitConverter.GetBytes(picList.Count));

			ImageConverter im = new ImageConverter();
			foreach (Picture slide in picList)
			{
				//converting image to bytes.
				imgByts = (byte[])im.ConvertTo(slide.image, typeof(byte[]));
				//compress image to erude bin file
				imgByts = ByteManager.Compress(imgByts);
				//convert length of byted image to byte and add to file. 
				lines.AddRange(BitConverter.GetBytes(imgByts.Length));
				lines.AddRange(imgByts);

				lines.AddRange(BitConverter.GetBytes(slide.bgColor.R));
				lines.AddRange(BitConverter.GetBytes(slide.bgColor.G));
				lines.AddRange(BitConverter.GetBytes(slide.bgColor.B));
				lines.AddRange(BitConverter.GetBytes(slide.time));

			}
			File.WriteAllBytes(base._tskAddress, lines.ToArray());
			return true;
		}

		/// <summary>
		/// Saving Image task in bin file 
		/// </summary>
		/// <returns></returns>
		public bool Save()
		{
			if (base._tskAddress == null)
			{
				SaveFileDialog path = new SaveFileDialog();
				if (tskSavMod == SaveMod.txt)
				{
					path.FileName = "LabPic.txt";
					path.Filter = "Text File |*.txt";
				}
				if (tskSavMod == SaveMod.bin)
				{
					path.FileName = "LapPic.bin";
					path.Filter = "Bin File |*.bin";
				}

				if (path.ShowDialog() == DialogResult.OK)
				{
					base._tskAddress = path.FileName;
				}
				else
					return false;
			}
			try
			{

				if (tskSavMod == SaveMod.bin)
					BinImageWrite();

				if (tskSavMod == SaveMod.txt)
					TextImageWrite();
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Error writing file" + e.Message);
				return false;
			}

		}

		private bool TextImageWrite()
		{
			return false;
		}

	}
}
