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

namespace Basics
{
	public class PsycologyTask : TaskData
	{
		public bool useBackImage;
		public Bitmap backImage;
		public Color backColor;
		List<Node> shapeList;
		List<FNode> fixationList;

		bool _repaint = true;
		Image<Rgba, byte> tskImg;
		
		Bitmap _taskFrame;
		Image<Rgba, byte> prmpts;
		Bitmap overlayer;
		public int[] colorGroups = null;
		public List<List<int>> groupMembers = null;
		public int groupCount = -1;

		bool prmptRecursive = false;
		bool prmptRecursiveShowerDirect = false;
		int prmptNodeShower = 0, prmptNodeMaxShower = 10; 
		int prmptNodeId , prmptRadius = 0, prmptB = 10, prmptG = 235, prmptR = 255;
		int arrowShower, arrowBeginNodeId, arrowEndNodeId, arrowThickness, arrowR, arrowG, arrowB;

		
		public Bitmap GetTaskImage { get { return tskImg.Bitmap; } }

		
		public PsycologyTask() : base(TaskType.lab)
		{
			fixationList = new List<FNode>();
			shapeList = new List<Node>();
			backColor = Color.Silver;
			
			DrawMap();

		}

		public void Clear()
		{
			base._taskIsReady = false;
			shapeList = null;
			fixationList = null;
			backColor = Color.Silver;
			_repaint = true;
			DrawMap();
		}
		
		public bool Load()
		{
			LoadFile(true);
			return Load(lines);
		}
				
		public void DrawMap()
		{
			ChangeBackGround();
			foreach (Node n in shapeList)
			{
				DrawNode(n);
			}
			_taskFrame = tskImg.Bitmap;
		}
		
		private void ChangeBackGround()
		{
			if (tskImg != null)
				tskImg.Dispose();

			if (tskImg != null)
				tskImg.Dispose();

			if (useBackImage)
				tskImg = new Image<Rgba, byte>(backImage);
			else
				tskImg = new Image<Rgba, byte>(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y, new Rgba(backColor.R,backColor.G,backColor.B,1));
			
		}

		public Node CreateNode(int index, Shape shape, int num, int x, int y, int w, int h, Color sColor, Color numColor, int fixTime, int priorit, Color fixCol)
		{
			Node newNode = new Node(-1, x, y, shape, sColor, num, numColor, w, h);
			if (index == -1)
			{
				newNode._id = shapeList.Count;
				shapeList.Add(newNode);
			}
			else
				shapeList[index] = newNode;
			
			if (fixTime > 0)
				AddFixateNode(newNode);
			_repaint = true;
			return newNode; 
		}

		public Node CreateNode(Node newNode)
		{
			if (newNode._id == -1)
			{
				newNode._id = shapeList.Count;
				shapeList.Add(newNode);
			}
			else
				shapeList[newNode._id] = newNode;
			if (newNode.fixationTime > 0)
				AddFixateNode(newNode);
			_repaint = true;
			return newNode;
		}

		public void AddFixateNode(Node n)
        {
            fixationList.Add(new FNode(n._id, n.fixationRadius, n.pos, n.fixationTime, n.priority));
			_repaint = true;
        }

        private void DrawNode(Node node)
		{
		
			if (node.shape == Shape.Circle)
			{
				CvInvoke.Circle(tskImg, new Point(node.pos.X, node.pos.Y), node.width / 2, new MCvScalar(node.shapeColor.R, node.shapeColor.G, node.shapeColor.B), -1);
			}
			else if (node.shape == Shape.Rectangle)
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
				if (node.shape == Shape.Circle)        // تنظیم شماره برای دایره
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
				else if (node.shape == Shape.Rectangle)        // تنظیم شماره برای مستطیل
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
			if (node.fixationTime > 0)
				CvInvoke.Circle(tskImg, node.pos, node.fixationRadius, new MCvScalar(node.fixationColor.R, node.fixationColor.G, node.fixationColor.B));
			
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
			groupMembers.Add(new List<int>(new int[] { 0 }));
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
		
		private void RenderPrompt()
		{
			if (prmptNodeMaxShower == 0)
				return;
			if (prmptNodeShower == 0 && !prmptRecursive )
				return;
					
			float alpha = ((float)prmptNodeShower / prmptNodeMaxShower);
			
			if (!prmptRecursiveShowerDirect)
				prmptNodeShower--;
			else
				prmptNodeShower++;

			if (prmptNodeShower == 0 && prmptRecursive)
			{
				prmptRecursiveShowerDirect = true;
			}
			if (prmptNodeShower == prmptNodeMaxShower && prmptRecursive)
			{
				prmptRecursiveShowerDirect = false;
			}

			if (shapeList[prmptNodeId].shape == Shape.Circle)
			{
				CvInvoke.Circle(prmpts, new Point(shapeList[prmptNodeId].pos.X, shapeList[prmptNodeId].pos.Y), shapeList[prmptNodeId].width / 2 + 3, new MCvScalar(prmptR, prmptG, prmptB,255), -1);
			}
			else if (shapeList[prmptNodeId].shape == Shape.Rectangle)
			{
				CvInvoke.Rectangle(prmpts, new Rectangle(new Point(shapeList[prmptNodeId].pos.X - shapeList[prmptNodeId].width / 2 - 3, shapeList[prmptNodeId].pos.Y - shapeList[prmptNodeId].height / 2  - 3), new Size(shapeList[prmptNodeId].width + 6, shapeList[prmptNodeId].height  + 6)), new MCvScalar(prmptR, prmptG, prmptB), -1);
			}
			if (arrowShower > 0)
				CvInvoke.ArrowedLine(prmpts, shapeList[arrowBeginNodeId].pos, shapeList[arrowEndNodeId].pos, new MCvScalar(0, 0, 0), arrowThickness);

			overlayer = prmpts.Bitmap;
			overlayer.MakeTransparent(Color.Black);
			_taskFrame = tskImg.Bitmap;
			BitmapManager.DrawOn(overlayer, _taskFrame, alpha);
		}

		public void DrawPrompt(int Max, int id, Color prCol, bool recursive)
		{
			prmpts = new Image<Rgba, byte>(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y, new Rgba(0, 0, 0, 0));
			prmptNodeShower = Max;
			prmptNodeId = id;
			prmptNodeMaxShower = Max;
			prmptR = prCol.R; prmptG = prCol.G; prmptB = prCol.B;
			prmptRecursive = recursive;
		}

		public void UndrawPrmpt()
		{
			prmptRecursive = false;
			prmptNodeShower = 0;
			arrowShower = 0;
			if (prmpts != null)
				prmpts.Dispose();
			DrawMap();
			_taskFrame = tskImg.Bitmap;
		}

		public int[] FindStartShapes()
		{
			if (runConf.shapeGroupingMode == GroupingMod.byColor)
				ColorGrouping();

			int[] res = new int[groupCount];

			for (int i = 0; i < groupCount; i++)
			{
				int minNum = groupMembers[i][0];
				res[i] = 0;
				for (int j = 0; j < groupMembers[i].Count; j++)
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
		
		public Bitmap RenderTask()
		{
			if (_repaint)
			{
				DrawMap();
				_repaint = false;
			}
			RenderPrompt();
			return _taskFrame;
		}

		public Node findNode(int x, int y)
		{
			foreach (Node node in shapeList)
				if (node.shape == Shape.Circle)
				{
					if (Math.Sqrt(Math.Pow(Math.Abs(node.pos.X - x), 2) + Math.Pow(Math.Abs(node.pos.Y - y), 2)) <= node.width)
					{
						return node;
					}
				}
				else
				{
					if (Math.Abs(x - node.pos.X) < node.width / 2 && Math.Abs(y - node.pos.Y) < node.height / 2)
					{
						return node;
					}
				}
			return null;
		}

		public Node findNodeByID(int id)
		{
			if (id > -1 && id < shapeList.Count)
				return shapeList[id];
			return null;
		}

		public bool RemoveNode(int id)
		{
			if (id < shapeList.Count)
			{
				if (shapeList[id].fixationTime > 0)
					RemoveFixNode(id);
				shapeList.RemoveAt(id);
				_repaint = true;
				return true;
			}
			return false;
		}

		private bool RemoveFixNode(int id)
		{
			foreach (FNode n in fixationList)
				if (n._id == id)
				{
					fixationList.Remove(n);
					return true;
				}
			return true;
		}
		
		/// <summary>
		/// Saving Psycology task in text file.
		/// In future text was replaced with bin format.
		/// </summary>
		/// <returns></returns>
		
		public bool Save()
		{
			int i;
			if (_tskAddress == null)
			{
				SaveFileDialog path = new SaveFileDialog();
				if (tskSavMod == SaveMod.txt)
				{
					path.FileName = "LabTask.txt";
					path.Filter = "Text File |*.txt";
				}
				if (tskSavMod == SaveMod.bin)
				{
					path.FileName = "LabTask.bin";
					path.Filter = "Binary File |*.bin";
				}
				if (path.ShowDialog() == DialogResult.OK)
				{
					_tskAddress = path.FileName;
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
					char shape = 'c';
					if (shapeList[i].shape == Shape.Circle)
						shape = 'c';
					if (shapeList[i].shape == Shape.Rectangle)
						shape = 'r';
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

					if (shapeList[i].fixationTime > 0)
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

					File.WriteAllLines(base._tskAddress, lines);

				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Load(string[] lines)
		{
			shapeList = new List<Node>();
			//// تنظیم رنگ پس زمینه

			string[] bg = lines[2].Split(',');
			int r, g, b;
			Int32.TryParse(bg[1], out r);
			Int32.TryParse(bg[2], out g);
			Int32.TryParse(bg[3], out b);
			backColor = Color.FromArgb(r, g, b);
			int R, G, B;
			int x, y;
			int width;
			int height;
			int number;
			int textR, textG, textB;
			char fType;
			int fTime;
			int priority;
			int radius;
			Color fixationColor;
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
				Shape shp = Shape.Circle;
				if (shape == 'c')
					shp = Shape.Circle;
				if (shape == 'r')
					shp = Shape.Rectangle;
				Int32.TryParse(s[1], out R);
				Int32.TryParse(s[2], out G);
				Int32.TryParse(s[3], out B);
				Int32.TryParse(s[4], out x);
				Int32.TryParse(s[5], out y);
				Int32.TryParse(s[6], out width);
				Int32.TryParse(s[7], out height);
				Int32.TryParse(s[8], out number);
				Color shapeColor = Color.FromArgb(R, G, B);
				Int32.TryParse(s[9], out textR);
				Int32.TryParse(s[10], out textG);
				Int32.TryParse(s[11], out textB);
				Color textColor = Color.FromArgb(textR, textG, textB);

				if (s.Length > 12 && s[12] == "True")
				{
					fType = s[13].First();

					Int32.TryParse(s[14], out fTime);

					Int32.TryParse(s[15], out priority);

					Int32.TryParse(s[16], out radius);
					int fColorR, fColorG, fColorB;
					Int32.TryParse(s[17], out fColorR);
					Int32.TryParse(s[18], out fColorG);
					Int32.TryParse(s[19], out fColorB);
					fixationColor = Color.FromArgb(fColorR, fColorG, fColorB);
					shapeList.Add(new Node(i - 4, x, y, shp, shapeColor, number, textColor, width, height, fType, fTime, priority, radius, fixationColor));
				}
				else
				{
					shapeList.Add(new Node(i - 4, x, y, shp, shapeColor, number, textColor, width, height));
				}
			}
			#endregion
			// اضافه کردن فیکسیشن ها

			foreach (Node node in shapeList)
			{
				if (node.fixationTime > 0)
				{
					AddFixateNode(node);
				}
			}
			DrawMap();
			return true;
		}

		public void Invalidate()
		{
			_repaint = true;
		}
	}
}
