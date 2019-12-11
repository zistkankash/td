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
		public List<MediaEelement> picList;
		public int showedIndex;
		public Color backColor;
		public bool setTransparency = false;
		public bool drawChess = false;
		public Color transColor;
		MediaType TaskMediaType = MediaType.Image;
		private Image<Rgb, byte> tskImg;

		public Image<Rgb, byte> GetTaskImage { get { return tskImg; } }

		public MediaTask()
		{
			base._taskIsReady = false;
			picList = new List<MediaEelement>();
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
			Bitmap b = new Bitmap(5, 5);

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

		public bool LoadFromText(string[] lines)
		{
			SavingMode = SaveMod.txt;
			picList = new List<MediaEelement>();

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
					MediaEelement pic = new MediaEelement(null, null, time);
					pic.bgColor = bg;
					picList.Add(pic);
				}
				if (s[0] == "Image: ")
				{
					string address = s[1];
					int time;
					Int32.TryParse(s[1], out time);
					Bitmap bit = new Bitmap(address);
					MediaEelement pic = new MediaEelement(bit, address, time);
					picList.Add(pic);
				}
				if (s[0] == "Video: ")
				{
					MediaEelement pic = new MediaEelement(s[1], int.Parse(s[2]));
					picList.Add(pic);
					TaskMediaType = MediaType.Video;
				}
			}

			tskImg.Bitmap = picList[0].image;

			return true;
		}

		public bool LoadFromBin(byte[] binTaskFile, int binReadIndex)
		{
			SavingMode = SaveMod.bin;
			binReadIndex = 0;
			long longVar = BitConverter.ToInt64(binTaskFile, binReadIndex);
			binReadIndex += sizeof(Int64);
			DateTime dateTimeVar = DateTime.FromBinary(longVar);
			int count = BitConverter.ToInt32(binTaskFile, binReadIndex);
			binReadIndex += sizeof(Int32);
			ImageConverter imConverter = new ImageConverter();

			picList = new List<MediaEelement>();

			for (int i = 0; i < count; i++)
			{
				int length = BitConverter.ToInt32(binTaskFile, binReadIndex);
				binReadIndex += sizeof(Int32);
				byte[] compImg = new byte[length];
				Buffer.BlockCopy(binTaskFile, binReadIndex, compImg, 0, length);

				Bitmap x = (Bitmap)imConverter.ConvertFrom(ByteManager.Decompress(compImg));
				binReadIndex += length;
				byte R = binTaskFile[binReadIndex];
				byte G = binTaskFile[binReadIndex + 2];
				byte B = binTaskFile[binReadIndex + 4];

				binReadIndex += 6;

				int time = BitConverter.ToInt32(binTaskFile, binReadIndex);
				binReadIndex += sizeof(Int32);
				picList.Add(new MediaEelement(x, Color.FromArgb(R, G, B), time, "image address"));
			}
			tskImg.Bitmap = picList[0].image;

			return true;
		}

		public bool Load()
		{
			if (Load(true))
				if (SavingMode == SaveMod.txt)
					return LoadFromText(lines);
				else
					return LoadFromBin(binTaskFile, binReadIndex);
			else
				return false;
		}

		bool BinImageWrite()
		{
			List<byte> lines = new List<byte>();
			byte[] imgByts;
			lines.AddRange(BitConverter.GetBytes((short)TaskType.media));
			lines.AddRange(BitConverter.GetBytes(System.DateTime.Now.ToBinary()));
			lines.AddRange(BitConverter.GetBytes(picList.Count));

			ImageConverter im = new ImageConverter();
			foreach (MediaEelement slide in picList)
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

		public MediaType GetTaskMediaType()
		{
			foreach (MediaEelement pic in picList)
			{
				if (pic.medType == MediaType.Video)
				{
					TaskMediaType = MediaType.Video;
					return MediaType.Video;
				}
			}
			return MediaType.Image;
		}

		/// <summary>
		/// Saving Image task in bin file 
		/// </summary>
		/// <returns></returns>
		public bool Save()
		{
			if (base._tskAddress == null)
			{
				GetTaskMediaType();
				if (TaskMediaType == MediaType.Video)
					tskSavMod = SaveMod.txt;
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

		bool TextImageWrite()
		{
			return false;
		}

	}
}
