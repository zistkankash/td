using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskLab;
using Emgu.CV.Structure;
using Emgu.CV;
using TaskRunning;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Basics
{
	public enum TaskType { picture, lab, cognitive }
	
	public enum GroupingMod { byColor, byType, byRegion}

	public enum SaveMod { bin , txt}
	
	public class TaskData
	{
		public TaskType type;
		public bool taskIsReady = false;

		public RunConfig runConf;

		public Color backColor;
		public bool setTransparency = false;
		public Color transColor;

		public List<Picture> picList;
		public int showedIndex;
	

		private Image<Rgb, byte> tskImg;
		
		//In design mode temp image used to compose some feature (for example chessboard grid) with task image.
		//In running mode temp image used to save original task map to improve running speed. 
		public Image<Rgb, byte> tskTempImg;
		public bool drawChess = false;

		public Image<Rgb, byte> GetTaskImage { get { return tskImg; } }

		public string tskAddress = null;
		public SaveMod tskSavMod;
		public DateTime tskLastDateEdited;

		public List<Node> shapeList;
		
		public List<Node> fixationList;
		
		public List<FNode> positiveFixates;
		public List<FNode> negativeFixates;

		public int[] colorGroups = null;
		public List<List<int>> groupMembers = null;
		public int groupCount = -1;

		public int prmptCircleLocker , prmptCircleMaxLocker = 10;
		public int prmptCircleNodeId;
		
		public int prmptCircleRadius;
		public int prmptCircleB = 10, prmptCircleG = 235, prmptCircleR = 255;

		public int arrowLocker;
		public int arrowBeginNodeId;
		public int arrowEndNodeId;
		
		public void ClearTask()
		{
			taskIsReady = false;
			if (shapeList != null)
				shapeList.Clear();
			if (positiveFixates != null)
				positiveFixates.Clear();
			if (negativeFixates != null)
				negativeFixates.Clear();
			if (picList != null)
				picList.Clear();
			backColor = Color.Gray;
			if (tskImg != null)
				tskImg.Dispose();
			
		}
		
		public TaskData(TaskType tk) 
		{
			taskIsReady = false;
			tskAddress = null;
			if (tk == TaskType.lab)
			{
				type = TaskType.lab;
				fixationList = new List<Node>();
				positiveFixates = new List<FNode>();
				negativeFixates = new List<FNode>();
				shapeList = new List<Node>();
				backColor = Color.White;
				arrowLocker = 0;
				prmptCircleLocker = 0;
				tskTempImg = new Image<Rgb, Byte>(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
				return;
			}
			if(tk == TaskType.picture)
			{
				type = TaskType.picture;
				picList = new List<Picture>();
				showedIndex = -1;
				
				return;
			}
		}
		
		public TaskData()
		{
			taskIsReady = false;
			tskAddress = null;
		}

		public bool LoadTask(bool newTask)
		{
			if (newTask || tskAddress == null)
			{
				OpenFileDialog ofd = new OpenFileDialog();
				string TaskFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				ofd.InitialDirectory = TaskFolder;
				ofd.Title = "Pick a valid task file...";
				ofd.CustomPlaces.Add(@"C:\");
				ofd.CustomPlaces.Add(@"C:\Program Files\");
				ofd.CustomPlaces.Add(@"K:\Documents\");
				ofd.Filter = "Binary File (*.bin)|*.bin| Text File (*.txt) |*.txt";
				if (ofd.ShowDialog() == DialogResult.OK)
					tskAddress = ofd.FileName;
				else
					return false;
			}
			ClearTask();
			try
			{
				string suffix = Path.GetExtension(tskAddress);
				#region txt formart loader
				if (suffix == ".txt")
				{
					string[] lines = File.ReadAllLines(tskAddress, Encoding.UTF8);
					if (lines[0] != "TaskLabPics" && lines[0] != "TaskLab" && lines[0] != "Number Of Levels")
					{
						taskIsReady = false;
						return false;
					}
					else
					{
						#region pictur task
						if (lines[0] == "TaskLabPics")      // تسک های تصویری
						{
							picList = new List<Picture>();
							type = TaskType.picture;
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
							taskIsReady = true;
							tskImg.Bitmap = picList[0].image;
							foreach (Picture pic in picList)
							{
								//var TimeTxt_Box = new TextBox();
								//TimeTxt_Box.Name = "TimeTxt" + CntPic;
								//TimeTxt_Box.Size = new Size(60, 20);
								//TimeTxt_Box.Text = pic.time.ToString();
								////TimeTxt_Box.TextChanged += new System.EventHandler(this.TimeTxt_Box_Click);
								//TimeTxt_Box.Enabled = false;


								//ShowList.Add(true);
							}
						}
						#endregion
						#region lab tasks
						else if (lines[0] == "TaskLab")     // تسک های روانشناختی
						{
							type = TaskType.lab;
							shapeList = new List<Node>();
							//// تنظیم رنگ پس زمینه

							string[] bg = lines[2].Split(',');
							int r, g, b;
							Int32.TryParse(bg[1], out r);
							Int32.TryParse(bg[2], out g);
							Int32.TryParse(bg[3], out b);
							backColor = Color.FromArgb(r, g, b);

							////خواندن اشکال و کشیدن آن روی تصویر

							string[] Number = lines[3].Split(',');
							int shapeNumber;
							Int32.TryParse(Number[1], out shapeNumber);
							#region خواندن اشکال
							for (int i = 4; i < 4 + shapeNumber; i++)
							{
								string[] s = lines[i].Split(',');
								char shape;
								shape = s[0].First();
								int R, G, B;
								Int32.TryParse(s[1], out R);
								Int32.TryParse(s[2], out G);
								Int32.TryParse(s[3], out B);
								int x, y;
								Int32.TryParse(s[4], out x);
								Int32.TryParse(s[5], out y);
								int width;
								Int32.TryParse(s[6], out width);
								int height;
								Int32.TryParse(s[7], out height);
								int number;
								Int32.TryParse(s[8], out number);
								int textR, textG, textB;
								Color shapeColor = Color.FromArgb(R, G, B);
								Int32.TryParse(s[9], out textR);
								Int32.TryParse(s[10], out textG);
								Int32.TryParse(s[11], out textB);
								Color textColor = Color.FromArgb(textR, textG, textB);

								if (s.Length > 12 && s[12] == "True")
								{
									char fType = s[13].First();
									int fTime;
									Int32.TryParse(s[14], out fTime);
									int priority;
									Int32.TryParse(s[15], out priority);
									int radius;
									Int32.TryParse(s[16], out radius);
									int fColorR, fColorG, fColorB;
									Int32.TryParse(s[17], out fColorR);
									Int32.TryParse(s[18], out fColorG);
									Int32.TryParse(s[19], out fColorB);
									Color fixationColor = Color.FromArgb(fColorR, fColorG, fColorB);
									shapeList.Add(new Node(i - 4, x, y, shape, shapeColor, number, textColor, width, height, fType, fTime, priority, radius, fixationColor));
								}
								else
								{
									shapeList.Add(new Node(i - 4, x, y, shape, shapeColor, number, textColor, width, height));
								}
							}
							#endregion
							// اضافه کردن فیکسیشن ها
							positiveFixates = new List<FNode>();
							negativeFixates = new List<FNode>();
							foreach (Node node in shapeList)
							{
								if (node.ROI == true)
								{
									AddFnode(node);
								}
							}
							DrawMap();
							tskTempImg = tskImg;
							taskIsReady = true;
						}       // انتهای تسک های روانشناختی
						#endregion
						#region COGLAB
						else if (lines[0] == "Number Of Levels")
						{
							//	mode = "CogLab";
							//	LoadInitialAction(3);
							//	using (var fs = File.OpenRead(ofd.FileName))
							//	using (var reader = new StreamReader(fs))
							//	{
							//		var line = reader.ReadLine();
							//		line = reader.ReadLine();
							//		int NumberLevel = int.Parse(line);
							//		for (int i = 0; i < NumberLevel; i++)       //این حلقه به تعداد لول های تسک اجرا می شود
							//		{
							//			BaseIndex.Add(0);
							//			List<FrameProperties> ListAddedFrame = new List<FrameProperties>();

							//			line = reader.ReadLine();
							//			line = reader.ReadLine();
							//			AllLevelName.Add(line.Substring(3));

							//			line = reader.ReadLine();
							//			line = reader.ReadLine();
							//			int repeatnumber = int.Parse(line.Substring(3));
							//			NumerRepeat.Add(repeatnumber);
							//			EnabledTask.Add(2);

							//			line = reader.ReadLine();
							//			line = reader.ReadLine();
							//			int NumberFrame = int.Parse(line.Substring(3));

							//			for (int j = 0; j < NumberFrame; j++)
							//			{
							//				FrameProperties varFrame = new FrameProperties();

							//				line = reader.ReadLine();
							//				line = reader.ReadLine();
							//				var values = line.Substring(6).Split(' ');
							//				int FrameTime = int.Parse(values[0]);
							//				//Debug.Write("Load Debug " + line.Substring(6) + " " + values[0] + "\n");
							//				Color BGColor = Color.FromArgb(255, int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));

							//				line = reader.ReadLine();
							//				line = reader.ReadLine();
							//				values = line.Substring(9).Split(' ');
							//				FixationPts varFixation = new FixationPts();
							//				//varFixation.SetFixationPts(int.Parse(), int.Parse(), int.Parse(), int.Parse(),Color.FromArgb(255, int.Parse(), int.Parse(), int.Parse()));
							//				Color fixationColor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
							//				varFixation.SetFixationPts(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), fixationColor);
							//				int fixationtime = int.Parse(values[4]);
							//				line = reader.ReadLine();
							//				line = reader.ReadLine();
							//				//Debug.Write("Load Debug " + line.Substring(9)+ "\n");
							//				int NumberStimulus = int.Parse(line.Substring(9));
							//				FixationPts[] varStimulus = new FixationPts[NumberStimulus];

							//				for (int k = 0; k < NumberStimulus; k++)
							//				{
							//					line = reader.ReadLine();
							//					line = reader.ReadLine();
							//					values = line.Substring(9).Split(' ');
							//					Debug.Write("Load Debug " + line.Substring(9) + "\n");

							//					varStimulus[k] = new FixationPts();
							//					if (int.Parse(values[0]) == 4 || int.Parse(values[0]) == 8 || int.Parse(values[0]) == 12)
							//					{
							//						line = reader.ReadLine();
							//						varStimulus[k].SetPicture(int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[0]), line.Substring(9));
							//					}
							//					else
							//					{
							//						Color stimulusColor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
							//						varStimulus[k].SetFixationPts(int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[0]), stimulusColor);
							//						varStimulus[k].SetContrastPts(int.Parse(values[8]));
							//					}
							//				}
							//				line = reader.ReadLine();
							//				line = reader.ReadLine();
							//				int NumberShowFrame = int.Parse(line.Substring(9));
							//				ShowFr[] varShowFrame = new ShowFr[NumberShowFrame];
							//				for (int k = 0; k < NumberShowFrame; k++)
							//				{
							//					varShowFrame[k] = new ShowFr();
							//					line = reader.ReadLine();
							//					line = reader.ReadLine();
							//					values = line.Substring(9).Split(' ');
							//					Color showframecolor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));
							//					varShowFrame[k].SetShowFrameProp(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), showframecolor);
							//				}
							//				//MainForm.MeanX_PupilCenter[i] = Double.Parse(values[0]);

							//				HintForm varCue = new HintForm();
							//				line = reader.ReadLine();
							//				line = reader.ReadLine();
							//				values = line.Substring(9).Split(' ');

							//				varCue.type = int.Parse(values[0]);
							//				if (int.Parse(values[0]) == 1)
							//				{
							//					//SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.ArrowLocX0 + " " + AllLevelProp[i][j].Cue.ArrowLocX1 + " " + AllLevelProp[i][j].Cue.ArrowLocY + " " + AllLevelProp[i][j].Cue.ArrowColor.R + " " + AllLevelProp[i][j].Cue.ArrowColor.G + " " + AllLevelProp[i][j].Cue.ArrowColor.B + " " + AllLevelProp[i][j].Cue.ArrowWidth;
							//					Color showframecolor = Color.FromArgb(255, int.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]));

							//					varCue.ArrowWidth = int.Parse(values[8]);
							//					varCue.SetArrowProp(int.Parse(values[3]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[4]), showframecolor);
							//				}
							//				else if (int.Parse(values[0]) == 2)
							//				{
							//					//SaveText += "_________" + AllLevelProp[i][j].Cue.type + " " + AllLevelProp[i][j].Cue.BoxRatio + "\n";
							//					varCue.SetBoxProp(20, int.Parse(values[1]), Color.Black);
							//				}
							//				else
							//				{

							//				}


							//				line = reader.ReadLine();
							//				line = reader.ReadLine();
							//				int reward = int.Parse(line.Substring(9));
							//				////Debug.Write("Load Debug " + line.Substring(9) + "\n");

							//				varFrame.SetProperties(BGColor, FrameTime, varFixation, fixationtime, NumberStimulus, varStimulus, reward, varCue, NumberShowFrame, varShowFrame);
							//				Debug.Write("FixTime1 : " + varFrame.FixationTime + "\n");

							//				line = reader.ReadLine();
							//				line = reader.ReadLine();
							//				values = line.Substring(9).Split(' ');
							//				RepeatLinkFrame repeatInfo = new RepeatLinkFrame();
							//				repeatInfo.SetProperties(bool.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));

							//				varFrame.RepeatInfo = repeatInfo;

							//				ListAddedFrame.Add(varFrame);
							//			}
							//			AllLevelProp.Add(ListAddedFrame);
							//		}
							//		// انتهای حاقه تعداد لول ها 
							//		line = reader.ReadLine();
							//		var value = line.Split(' ');
							//		userDistance = double.Parse(value[1]);

							//		line = reader.ReadLine();
							//		value = line.Split(' ');
							//		WidthM = double.Parse(value[1]);

							//		line = reader.ReadLine();
							//		value = line.Split(' ');
							//		HeightM = double.Parse(value[1]);

							//		line = reader.ReadLine();
							//		value = line.Split(' ');
							//		WidthP = double.Parse(value[1]);

							//		line = reader.ReadLine();
							//		value = line.Split(' ');
							//		HeightP = double.Parse(value[1]);

							//		for (int i = 0; i < AllLevelProp.Count; i++)
							//		{

							//			//add a new RowStyle as a copy of the previous one
							//			this.Task_Table.RowStyles.Add(new RowStyle(SaveRowStyle.SizeType, SaveRowStyle.Height));
							//			this.Task_Table.RowCount++;

							//			var namebox = new TextBox();
							//			namebox.Name = "NameTask_TB" + (Task_Table.RowCount - 1);
							//			//namebox.TextChanged += new System.EventHandler(this.NameTask_TB_TextChanged);

							//			namebox.Text = AllLevelName[i];
							//			namebox.Size = NameTask_TB1.Size;
							//			namebox.Enabled = false;
							//			Task_Table.Controls.Add(namebox, 0, this.Task_Table.RowCount - 1);


							//			//var Combox = new ComboBox();
							//			//Combox.Items.Add(" ");
							//			//Combox.Items.Add("Normal");
							//			//Combox.Items.Add("MGS");
							//			//Combox.Items.Add("VGS");
							//			//Combox.Items.Add("Posner");
							//			//Combox.Items.Add("Delete");
							//			//Combox.Name = "SelectTask_CB" + (Task_Table.RowCount - 1);
							//			//Debug.Write(" Combo" + Combox.Name + "\n");
							//			//Combox.SelectedIndexChanged += new System.EventHandler(this.SelectTask_CB_SelectedIndexChanged);
							//			//this.Task_Table.Controls.Add(Combox, 1, this.Task_Table.RowCount - 1);
							//			var txbox = new TextBox();
							//			txbox.Text = Convert.ToString(NumerRepeat[i]);
							//			txbox.Name = "NumTrial_TB" + (Task_Table.RowCount - 1);
							//			txbox.TextChanged += new System.EventHandler(this.NumTrial_TB_TextChanged);
							//			txbox.Size = NumTrial_TB1.Size;
							//			txbox.Enabled = false;

							//			Task_Table.Controls.Add(txbox, 2, this.Task_Table.RowCount - 1);
							//			Task_Table.Controls.Add(new Label() { Text = "0", Name = "TotalTime_LB" + (Task_Table.RowCount - 1) }, 3, this.Task_Table.RowCount - 1);
							//			Task_Table.Controls.Add(new Label() { Text = "0", Name = "FramePerTask_LB" + (Task_Table.RowCount - 1) }, 1, this.Task_Table.RowCount - 1);
							//			UpdateData(i + 1);
							//			//UpdateComboBox(i + 1);
							//			Task_Table.BringToFront();
							//			Task_Table.Visible = true;
							//		}
							//	}
							//}
						}
						#endregion
					}
				}
				#endregion
				#region bin format loader
				if (suffix == ".bin")
				{
					byte[] tskFile = ReadBinFile();
					if (tskFile == null)
						return false;
					int readIndex = 0;
					short tsktyp = (short)BitConverter.ToInt16(tskFile, readIndex);
					readIndex += sizeof(short);
					#region picture task type
					if (tsktyp == (short) TaskType.picture)
					{
						long longVar = BitConverter.ToInt64(tskFile, readIndex);
						readIndex += sizeof(Int64);
						//DateTime dateTimeVar = new DateTime(1980, 1, 1).AddMilliseconds(longVar);
						DateTime dateTimeVar = DateTime.FromBinary(longVar);
						

						int count = BitConverter.ToInt32(tskFile, readIndex);
						readIndex += sizeof(Int32);
						ImageConverter imConverter = new ImageConverter();

						picList = new List<Picture>();
						
						for(int i=0;i<count;i++)
						{
							int length = BitConverter.ToInt32(tskFile, readIndex);
							readIndex += sizeof(Int32);
							byte[] compImg = new byte[length];
							Buffer.BlockCopy(tskFile, readIndex, compImg, 0, length);
							
							Bitmap x = (Bitmap)imConverter.ConvertFrom(ByteCompressor.Decompress(compImg)); 
							readIndex += length;
							byte R = tskFile[readIndex];
							byte G = tskFile[readIndex + 2];
							byte B = tskFile[readIndex + 4];
							
							readIndex += 6;

							int time = BitConverter.ToInt32(tskFile, readIndex);
							readIndex += sizeof(Int32);
							picList.Add(new Picture(x, Color.FromArgb(R,G,B), time,"valid image"));
						}
					}
					#endregion
				}
				#endregion
			}
			catch (Exception ex)
			{
				MessageBox.Show("Load file error" + ex.Message);
				tskAddress = null;
				return false;
			}
			taskIsReady = true;
			return true;
		}
		
		public void AddFnode(Node node)
		{
			if (node.fixationType == 'P')
			{
				positiveFixates.Add(new FNode(node.fixationRadius, node.pos, node.fixationTime, 'P', node.priority));
			}
			else
			{
				negativeFixates.Add(new FNode(node.fixationRadius, node.pos, node.fixationTime, 'N', node.priority));
			}
		}
		
		private byte[] ReadBinFile()
		{
			try
			{
				using (FileStream fsSource = new FileStream(tskAddress,
								FileMode.Open, FileAccess.Read))
				{

					// Read the source file into a byte array.
					byte[] bytes = new byte[fsSource.Length];
					int numBytesToRead = (int)fsSource.Length;
					int numBytesRead = 0;
					while (numBytesToRead > 0)
					{
						// Read may return anything from 0 to numBytesToRead.
						int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

						// Break when the end of the file is reached.
						if (n == 0)
							break;

						numBytesRead += n;
						numBytesToRead -= n;
					}
					numBytesToRead = bytes.Length;
					return bytes;
				}
			}
			catch (Exception)
			{
				return null;
			}
		}
		
		public void DrawMap()
		{
			ChangeBackGround();
			foreach (Node n in shapeList)
			{
				DrawNode(n);
			}
		}
		
		private void ChangeBackGround()
		{
			if (tskImg != null)
				tskImg.Dispose();
			tskImg = tskTempImg;

			CvInvoke.Rectangle(tskImg, new Rectangle(0, 0, BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y), new MCvScalar(backColor.R, backColor.G, backColor.B), -1);
		}
		
		private void DrawNode(Node node)
		{
			if (node.shape == 'C')
			{
				CvInvoke.Circle(tskImg, new Point(node.pos.X, node.pos.Y), node.width / 2, new MCvScalar(node.shapeColor.R, node.shapeColor.G, node.shapeColor.B), -1);
			}
			else if (node.shape == 'R')
			{
				CvInvoke.Rectangle(tskImg, new Rectangle(new Point(node.pos.X - node.width / 2, node.pos.Y - node.height / 2), new Size(node.width, node.height)), new MCvScalar(node.shapeColor.R, node.shapeColor.G, node.shapeColor.B), -1);
			}
			if (node.number != -1)
			{
				//// کشیدن عدد
				double numSize = node.width * 0.02;
				int posOffsetX = 7;
				int posOffsetY = 5;
				int thickness = 5;
				if (node.shape == 'C')        // تنظیم شماره برای دایره
				{
					if (node.width <= 45)
						thickness = 2;
					if (node.number < 10)
					{
						posOffsetX = (int)(node.width * 0.2);
						posOffsetY = (int)(node.width * 0.2);
					}
					else
					{
						posOffsetX = (int)(node.width * 0.4);
						posOffsetY = (int)(node.width * 0.2);
					}
				}
				else if (node.shape == 'R')        // تنظیم شماره برای مستطیل
				{
					numSize = Math.Min(node.height, node.width) * 0.02;
					if (Math.Min(node.height, node.width) <= 45)
						thickness = 2;
					if (node.number < 10)
					{
						posOffsetX = (int)(node.width * 0.2);
						posOffsetY = (int)(node.height * 0.15);
					}
					else
					{
						posOffsetX = (int)(node.width * 0.4);
						posOffsetY = (int)(node.height * 0.15);
					}
				}

				// رسم شماره
				CvInvoke.PutText(tskImg, node.number.ToString(), new Point(node.pos.X - posOffsetX, node.pos.Y + posOffsetY), new Emgu.CV.CvEnum.FontFace(), numSize, new MCvScalar(node.textColor.R, node.textColor.G, node.textColor.B), thickness);
			}
			// کشیدن فیکسیشن
			CvInvoke.Circle(tskImg, node.pos, node.fixationRadius, new MCvScalar(node.fixationColor.R, node.fixationColor.G, node.fixationColor.B));
			//map = img.ToBitmap();
		}

		/// <summary>
		/// Groups shapes by shape color
		/// after running this method, colorGroups array is filled.
		/// corresponding index of colorGroups determinds group of index in shapList.
		/// </summary>
		public void ColorGrouping()
		{
			colorGroups = new int[shapeList.Count];
			groupMembers = new List<List<int>>();
			groupMembers.Add(new List<int>(new int[] {0}));
			colorGroups[0] = 0; // group numbers starts from 0.
			groupCount = 1;
			int i, j;
			for (i = 1; i < shapeList.Count; i++)
			{
				for (j = 0; j < i; j++)
				{
					if (shapeList[i].shapeColor.Equals(shapeList[j].shapeColor))
					{
						colorGroups[j] = colorGroups[i];
						groupMembers[colorGroups[j]].Add(i);
					}
					
				}
				if (j == i)
				{
					groupCount++;
					colorGroups[i] = groupCount;
					groupMembers.Add(new List<int>(new int[] { i }));
				}
			}
		}
		
		/// <summary>
		/// This methode draws a circle on a node in lab tasks.
		/// </summary>
		public void DrawCircle()
		{
			
			if (prmptCircleLocker == 0)
				return;
			tskImg = tskTempImg;
			int alpha = Math.Min(prmptCircleLocker / prmptCircleMaxLocker * 255 , 255);
			CvInvoke.Circle(tskImg, shapeList[prmptCircleNodeId].pos, shapeList[prmptCircleNodeId].width, new MCvScalar(prmptCircleB, prmptCircleG, prmptCircleR, alpha));
		}
		
		public void DrawArrow()
		{
			if (arrowLocker == 0)
				return;
			tskImg = tskTempImg;
			
			CvInvoke.ArrowedLine(tskImg, shapeList[arrowBeginNodeId].pos, shapeList[arrowEndNodeId].pos, new MCvScalar(0, 0, 0, 125), 5);
		}

		public int[] FindStartShapes()
		{
			if (type != TaskType.lab)
				return null;

			if (runConf.shapeGroupingMode == GroupingMod.byColor)
				ColorGrouping();
			int[] res = new int[groupCount];
						
			for (int i = 0; i< groupCount; i++)
			{
				int minNum = groupMembers[i][0];
				res[i] = 0;
				for (int j = 0; j <groupMembers[i].Count; j++)
				{
					if (shapeList[groupMembers[i][j]].number < minNum)
					{
						minNum = groupMembers[i][j];
						res[i] = j;
					}
				}
			}
			return res;
		}

		/// <summary>
		/// Saving Image task in bin file 
		/// </summary>
		/// <returns></returns>
		private bool SavePicTask()
		{
			if (tskAddress == null)
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
				
				//path.Filter = "Binary File (*.bin) | Text File (*.txt)";
				if (path.ShowDialog() == DialogResult.OK)
				{
					tskAddress = path.FileName;
				}
				else
					return false;
			}
			try
			{

				if(tskSavMod == SaveMod.bin)
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
		
		private bool BinImageWrite()
		{
			List<byte> lines = new List<byte>();
			byte[] imgByts;
			lines.AddRange(BitConverter.GetBytes((short)TaskType.picture));
			lines.AddRange(BitConverter.GetBytes(System.DateTime.Now.ToBinary()));
			lines.AddRange(BitConverter.GetBytes(picList.Count));

			ImageConverter im = new ImageConverter();
			foreach (Picture slide in picList)
			{
				//converting image to bytes.
				imgByts = (byte[])im.ConvertTo(slide.image, typeof(byte[]));
				//compress image to erude bin file
				imgByts = ByteCompressor.Compress(imgByts);
				//convert length of byted image to byte and add to file. 
				lines.AddRange(BitConverter.GetBytes(imgByts.Length));
				lines.AddRange(imgByts);
				
				lines.AddRange(BitConverter.GetBytes(slide.bgColor.R));
				lines.AddRange(BitConverter.GetBytes(slide.bgColor.G));
				lines.AddRange(BitConverter.GetBytes(slide.bgColor.B));
				lines.AddRange(BitConverter.GetBytes(slide.time));

			}
			File.WriteAllBytes(tskAddress, lines.ToArray());
			return true;
		}
		
		/// <summary>
		/// Saving Psycology task in text file.
		/// In future text was replaced with bin format.
		/// </summary>
		/// <returns></returns>
		private bool SaveLabTask()
		{
			int i;
			if (tskAddress == null)
			{
				SaveFileDialog path = new SaveFileDialog();
				if (tskSavMod == SaveMod.txt)
				{
					path.FileName = "LapTask.txt";
					path.Filter = "Text File |*.txt";
				}
				if (tskSavMod == SaveMod.txt)
				{
					path.FileName = "LapTask.bin";
					path.Filter = "Text File |*.bin";
				}
				if (path.ShowDialog() == DialogResult.OK)
				{
					tskAddress = path.FileName;
				}
				else
					return false;
			}
			try
			{

				List<string> lines = new List<string>();
				lines.Add("TaskLab");
				lines.Add("DateCreated:" + System.DateTime.Now.ToString());
				lines.Add("BackGround:" + "," + backColor.R + "," + backColor.G + "," + backColor.B);
				lines.Add("Shapes:" + "," + shapeList.Count.ToString());
				for (i = 0; i < shapeList.Count; i++)
				{
					char shape = shapeList[i].shape;
					int shapecolorR = shapeList[i].shapeColor.R;
					int shapecolorG = shapeList[i].shapeColor.G;
					int shapecolorB = shapeList[i].shapeColor.B;
					int x = shapeList[i].pos.X;
					int y = shapeList[i].pos.Y;
					int width = shapeList[i].width;
					int height = shapeList[i].height;
					int number = shapeList[i].number;
					int textcolorR = shapeList[i].textColor.R;
					int textcolorG = shapeList[i].textColor.G;
					int textcolorB = shapeList[i].textColor.B;

					if (shapeList[i].ROI == true)
					{
						bool roi = true;
						char fType = shapeList[i].fixationType;
						int fTime = shapeList[i].fixationTime;
						int priority = shapeList[i].priority;
						int radius = shapeList[i].fixationRadius;
						int fColorR = shapeList[i].fixationColor.R;
						int fColorG = shapeList[i].fixationColor.G;
						int fColorB = shapeList[i].fixationColor.B;

						lines.Add(shape.ToString() + "," + shapecolorR.ToString() + "," + shapecolorG.ToString() + "," + shapecolorB.ToString()
							+ "," + x.ToString() + "," + y.ToString() + "," + width.ToString() + "," + height.ToString() + "," + number.ToString()
							+ "," + textcolorR.ToString() + "," + textcolorG.ToString() + "," + textcolorB.ToString()
							+ "," + roi + "," + fType + "," + fTime + "," + priority + "," + radius + "," + fColorR
							+ "," + fColorG + "," + fColorB);
					}
					else
					{
						bool roi = false;
						lines.Add(shape.ToString() + "," + shapecolorR.ToString() + "," + shapecolorG.ToString() + "," + shapecolorB.ToString()
						+ "," + x.ToString() + "," + y.ToString() + "," + width.ToString() + "," + height.ToString() + "," + number.ToString()
						+ "," + textcolorR.ToString() + "," + textcolorG.ToString() + "," + textcolorB.ToString() + "," + roi);
					}

					File.WriteAllLines(tskAddress, lines);
					
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool  SaveTask()
		{
			if (type == TaskType.lab)
			{
				return SaveLabTask();
			}
			else if (type == TaskType.picture)
			{
				return SavePicTask();
			}
			return false;
		}

		public Bitmap GetSlideImage(int selSlide, Size pbSize)
		{
			if (selSlide == -1 || picList == null || picList.Count == 0 || selSlide == picList.Count)
				return new Bitmap(100,100);
			
			Bitmap b;
			
			if (picList[selSlide].address != null)
				b = BitmapData.DrawOn(picList[selSlide].image, pbSize, picList[selSlide].bgColor);
			else
				b = BitmapData.DrawOn(null, pbSize, picList[selSlide].bgColor);

			if (setTransparency)
				b.MakeTransparent(transColor);


			if (drawChess)
			{
				BitmapData.ChessboardDraw(ref b);
				
			}
			
			return b;
		}
	}
}
