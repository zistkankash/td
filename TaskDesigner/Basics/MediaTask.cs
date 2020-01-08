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
		public List<MediaEelement> PicList;
		public int showedIndex;
		public bool drawChess = false;
		public Bitmap operTaskImg;
        int curOperSlide = -1;
        Size _operationSize;
		public Size _thumbSize;

		public Size OperationalImageSize { get { return _operationSize; } set { _operationSize = value; operTaskImg = new Bitmap(_operationSize.Width, _operationSize.Height); } }

		public MediaTask()
		{
            base._taskIsReady = false;
			PicList = new List<MediaEelement>();
			showedIndex = -1;
			tskSavMod = SaveMod.txt;
			_thumbSize = new Size(300, 250);
		}

		public void Clear()
		{
			base._taskIsReady = false;
			if (PicList != null)
				PicList.Clear();
			_operationSize = new Size(500,500);
			if (operTaskImg != null)
				operTaskImg.Dispose();
			
		}

		public Bitmap GetOperationFrame(bool Refresh, int selSlide)
		{
			if (selSlide == -1 || PicList == null || PicList.Count == 0 || selSlide == PicList.Count)
				return operTaskImg;

			if (operTaskImg == null && _operationSize.Width != 0)
				operTaskImg = new Bitmap(_operationSize.Width, _operationSize.Height);

			if (Refresh || curOperSlide != selSlide)
			{
				curOperSlide = selSlide;
				RunnerUtils.MediaPictureRenderer(PicList[selSlide].BGColor, PicList[selSlide].Image, PicList[selSlide].UseTransparency, PicList[selSlide].TransColor, drawChess, ref operTaskImg);
			}
			return operTaskImg;
		}

		public bool GetOperationFrame(int selSlide, ref Bitmap BitIn)
		{
			if (selSlide == -1 || PicList == null || PicList.Count == 0 || selSlide == PicList.Count)
				return false;
							
			RunnerUtils.MediaPictureRenderer(PicList[selSlide].BGColor, PicList[selSlide].Image, PicList[selSlide].UseTransparency, PicList[selSlide].TransColor, drawChess, ref BitIn);
			
			return true;
		}

		public bool LoadFromText(string[] lines)
		{
			try
			{
				PicList = new List<MediaEelement>();
				string[] temp = lines[1].Split(' ');
				int count;
				Int32.TryParse(temp[0], out count);
				for (int i = 0; i < count; i++)
				{
					string[] s = lines[i + 2].Split(',');
					if (s[0] == "Background:")
					{
						int r, g, b;
						Int32.TryParse(s[1], out r);
						Int32.TryParse(s[2], out g);
						Int32.TryParse(s[3], out b);
						Color bg = Color.FromArgb(r, g, b);
						int time;
						Int32.TryParse(s[4], out time);
						MediaEelement pic = new MediaEelement(bg, time, this);
						pic.BGColor = bg;
						PicList.Add(pic);
					}
					if (s[0] == "Image:")
					{
						string address = s[1];
						int time;
						Int32.TryParse(s[2], out time);
						bool transUse;
						int r, g, b;
						
						Int32.TryParse(s[3], out r);
						Int32.TryParse(s[4], out g);
						Int32.TryParse(s[5], out b);
						Color bg = Color.FromArgb(r, g, b);
						bool.TryParse(s[6], out transUse);
						Int32.TryParse(s[7], out r);
						Int32.TryParse(s[8], out g);
						Int32.TryParse(s[9], out b);
						MediaEelement pic = new MediaEelement(bg, address, time, transUse , Color.FromArgb(r,g,b), this);
						PicList.Add(pic);
					}
					if (s[0] == "Video:")
					{
						MediaEelement pic = new MediaEelement(s[1], this);
						PicList.Add(pic);
						
					}
					if (s[0] == "Web:")
					{
						int time;
						Int32.TryParse(s[2], out time);
						MediaEelement pic = new MediaEelement(s[1], time, this);
						PicList.Add(pic);

					}
				}
				SavingMode = SaveMod.txt;
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show("Load Error!" + ex.Message,"Error");
				return false;
			}
		}

		public bool LoadFromBin(byte[] binTaskFile)
		{
			binReadIndex = 2;
			long longVar = BitConverter.ToInt64(binTaskFile, binReadIndex);
			binReadIndex += sizeof(Int64);
			DateTime dateTimeVar = DateTime.FromBinary(longVar);
			int count = BitConverter.ToInt32(binTaskFile, binReadIndex);
			binReadIndex += sizeof(Int32);
			ImageConverter imConverter = new ImageConverter();

			PicList = new List<MediaEelement>();

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
				PicList.Add(new MediaEelement(Color.FromArgb(R, G, B), time, this));
			}
			//tskImg.Bitmap = picList[0].image;
			SavingMode = SaveMod.bin;
			return true;
		}

		public bool Load()
		{
			ResultForm res = Load(true, TaskType.media);
			if (res.Result == ResultState.OK)
				if (res.FileMode == SaveMod.txt)
					return LoadFromText(lines);
				else
					return LoadFromBin(binTaskFile);
			else
				return false;
		}

		bool BinImageWrite()
		{
			List<byte> lines = new List<byte>();
			byte[] imgByts;
			lines.AddRange(BitConverter.GetBytes((short)TaskType.media));
			lines.AddRange(BitConverter.GetBytes(System.DateTime.Now.ToBinary()));
			lines.AddRange(BitConverter.GetBytes(PicList.Count));

			ImageConverter im = new ImageConverter();
			foreach (MediaEelement slide in PicList)
			{
				//converting image to bytes.
				imgByts = (byte[])im.ConvertTo(slide.Image, typeof(byte[]));
				//compress image to erude bin file
				imgByts = ByteManager.Compress(imgByts);
				//convert length of byted image to byte and add to file. 
				lines.AddRange(BitConverter.GetBytes(imgByts.Length));
				lines.AddRange(imgByts);

				lines.AddRange(BitConverter.GetBytes(slide.BGColor.R));
				lines.AddRange(BitConverter.GetBytes(slide.BGColor.G));
				lines.AddRange(BitConverter.GetBytes(slide.BGColor.B));
				lines.AddRange(BitConverter.GetBytes(slide.Time));

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
			try
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
				}
				StringBuilder savFile = new StringBuilder(10000);
				savFile.AppendLine("TaskLabMedia");
				savFile.AppendLine(PicList.Count.ToString());
				for (int i = 0; i < PicList.Count; i++)
				{
					if (!PicList[i].HaveMedia)
					{
						savFile.AppendLine("Background:," + PicList[i].BGColor.R.ToString() + "," + PicList[i].BGColor.G.ToString() + "," + PicList[i].BGColor.B.ToString() + "," + PicList[i].Time.ToString());
					}
					else
					{
						if (PicList[i].MediaTaskType == MediaType.Image)
						{
							savFile.AppendLine("Image:," + PicList[i].Address + "," + PicList[i].Time.ToString() + "," + PicList[i].BGColor.R.ToString() + "," + PicList[i].BGColor.G.ToString() + "," + PicList[i].BGColor.B.ToString() + "," + PicList[i].UseTransparency.ToString() + "," + PicList[i].TransColor.R.ToString() + "," + PicList[i].TransColor.G.ToString() + "," + PicList[i].TransColor.B.ToString());
						}
						if(PicList[i].MediaTaskType == MediaType.Video)
						{
							savFile.AppendLine("Video:," + PicList[i].Address + "," + PicList[i].Time);
						}
						if (PicList[i].MediaTaskType == MediaType.Web)
						{
							savFile.AppendLine("Web:," + PicList[i].URL + "," + +PicList[i].Time);
						}
					}
				}
				File.WriteAllText(Address, savFile.ToString());
			}
			catch (Exception)
			{
				
				return false;
			}
			return true;
		}

		bool TextImageWrite()
		{
			return false;
		}

	}
}
