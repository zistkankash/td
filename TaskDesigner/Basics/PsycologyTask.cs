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
		Size _opSize;
        public Size OperationalSize { get { return _opSize; } set { _opSize = value; InitiatNodePositions(); } }

		public List<Node> shapeList;
		List<FNode> fixationList;

		Image<Rgba, byte> tskImg;
				
		Image<Rgba, byte> prmpts;
		Bitmap overlayer;
		Bitmap _taskFrame;

		public int[] NodeGroupIdetifier = null;
		public List<List<int>> groupMembers = null;
		public int groupCount = -1;

		bool prmptRecursive = false;
		bool prmptRecursiveShowerDirect = false;
		int prmptNodeShower = 0, prmptNodeMaxShower = 10; 
		int prmptB = 10, prmptG = 235, prmptR = 255;

        int[] _blinkArrowBeginNodeId, _blinkArrowEndNodeId;
        int[] _fixArrowBegingNodeId, _fixArrowEndNodeId;
        int arrowThickness, arrowR, arrowG, arrowB;
		bool arrowShower;
		int[] prmptNodeId;

		public Bitmap GetTaskImage { get { return tskImg.Bitmap; } }
				
		public PsycologyTask() : base(TaskType.lab)
		{
			fixationList = new List<FNode>();
			shapeList = new List<Node>();
			backColor = Color.Silver;
			OperationalSize = new Size(1000,1000);
			DrawMap();
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

        public bool InitiatNodePositions()
        {
            if (_opSize.Width == 0)
                return false;
            for(int i=0;i<shapeList.Count;i++)
            {
                shapeList[i].absolutePosition.X = (int)(shapeList[i].relationalPosition.X * _opSize.Width);
                shapeList[i].absolutePosition.Y = (int)(shapeList[i].relationalPosition.Y * _opSize.Height);
            }
            return true;
        }

		void ChangeBackGround()
		{
			if (tskImg != null)
				tskImg.Dispose();

			if (tskImg != null)
				tskImg.Dispose();

			if (useBackImage)
			{
				tskImg = new Image<Rgba, byte>(backImage);
				CvInvoke.Resize(tskImg, tskImg, _opSize);
			}
			else
				tskImg = new Image<Rgba, byte>(_opSize.Width, _opSize.Height, new Rgba(backColor.R, backColor.G, backColor.B, 1));
			
		}

		/// <summary>
		/// This function renders a bitmap from current state of nodes in task and renders prompts set before.
		/// </summary>
		/// <param name="OperSize"> Size of output bitmap of function</param>
		/// <returns></returns>
		public Bitmap RenderTask()
		{
			DrawMap();
			RenderPrompt();
			return _taskFrame;
		}

		public Node CreateNode(int index, Shape shape, int num, float x, float y, int w, int h, Color sColor, Color numColor, int fixTime, int priorit, Color fixCol)
		{
			PointF point = new PointF(x, y);
			Node newNode = new Node(-1, point, shape, sColor, num, numColor, w, h, OperationalSize);
			if (index == -1)
			{
				newNode._id = shapeList.Count;
				shapeList.Add(newNode);
			}
			else
				shapeList[index] = newNode;
			
			if (fixTime > 0)
				AddFixateNode(newNode);
			
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
			
			return newNode;
		}

		public void AddFixateNode(Node n)
        {
            fixationList.Add(new FNode(n._id, n.fixationRadius, n.absolutePosition, n.fixationTime, n.priority));
			
        }

        void DrawNode(Node node)
		{
		
			if (node.shape == Shape.Circle)
			{
				CvInvoke.Circle(tskImg, new Point(node.absolutePosition.X, node.absolutePosition.Y) , node.width / 2, new MCvScalar(node.shapeColor.R, node.shapeColor.G, node.shapeColor.B), -1);
			}
			else if (node.shape == Shape.Rectangle)
			{
				CvInvoke.Rectangle(tskImg, new Rectangle(new Point(node.absolutePosition.X - node.width / 2, node.absolutePosition.Y - node.height / 2), new Size(node.width, node.height)), new MCvScalar(node.shapeColor.R, node.shapeColor.G, node.shapeColor.B), -1);
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
				CvInvoke.PutText(tskImg, node.number.ToString(), new Point(node.absolutePosition.X - posOffsetX, node.absolutePosition.Y + posOffsetY), new Emgu.CV.CvEnum.FontFace(), numSize, new MCvScalar(node.textColor.R, node.textColor.G, node.textColor.B), thickness);
			}
			// کشیدن فیکسیشن
			//if (node.fixationTime > 0)
				//CvInvoke.Circle(tskImg, node.absolutePosition, node.fixationRadius, new MCvScalar(node.fixationColor.R, node.fixationColor.G, node.fixationColor.B));
			
		}

		/// <summary>
		/// Groups shapes by shape color
		/// after running this method, colorGroups array is filled.
		/// corresponding index of colorGroups determinds group of index in shapList.
		/// </summary>
		void ColorGrouping()
		{
            bool nodeAdded;
			NodeGroupIdetifier = Enumerable.Repeat(-1, shapeList.Count).ToArray();
			groupMembers = new List<List<int>>();
			groupMembers.Add(new List<int>(new int[] { 0 }));
			NodeGroupIdetifier[0] = 0; 
			groupCount = 0;
			int i, j;
			for (i = 1; i < shapeList.Count; i++)
			{
                if (NodeGroupIdetifier[i] != -1)
                    continue;
                nodeAdded = false;
				for (j = 0; j < groupMembers.Count; j++)
				{
					if (shapeList[i].shapeColor.Equals(shapeList[groupMembers[j][0]].shapeColor))
					{
						NodeGroupIdetifier[i] = NodeGroupIdetifier[groupMembers[j][0]];
						groupMembers[NodeGroupIdetifier[i]].Add(i);
                        nodeAdded = true;
                        break;
					}

				}
				if (!nodeAdded)
				{
					groupCount++;
					NodeGroupIdetifier[i] = groupCount;
					groupMembers.Add(new List<int>(new int[] { i }));
				}
			}
		}

		/// <summary>
		/// This methode draws and renders prompts in lab tasks.
		/// </summary>
		
		void RenderPrompt()
		{
			if (prmptNodeMaxShower == 0)
				return;
			if (prmptNodeShower == 0 && !prmptRecursive )
				return;
			prmpts = new Image<Rgba, byte>(OperationalSize.Width, OperationalSize.Height, new Rgba(0, 0, 0, 0));
			float alpha = ((float)prmptNodeShower / prmptNodeMaxShower);
			
			if (!prmptRecursiveShowerDirect)
				prmptNodeShower--;
			else
				prmptNodeShower++;

			if (prmptNodeShower < 1 && prmptRecursive)
			{
				prmptRecursiveShowerDirect = true;
			}
			if (prmptNodeShower > prmptNodeMaxShower && prmptRecursive)
			{
				prmptRecursiveShowerDirect = false;
			}
			for (int i = 0; i < prmptNodeId.Length; i++)
			{
				if (shapeList[prmptNodeId[i]].shape == Shape.Circle)
				{
					CvInvoke.Circle(prmpts, new Point((int)(shapeList[prmptNodeId[i]].absolutePosition.X), (int)(shapeList[prmptNodeId[i]].absolutePosition.Y)), shapeList[prmptNodeId[i]].width / 2 + 3, new MCvScalar(prmptR, prmptG, prmptB, 255), 3);
				}
				else if (shapeList[prmptNodeId[i]].shape == Shape.Rectangle)
				{
					CvInvoke.Rectangle(prmpts, new Rectangle(new Point((int)(shapeList[prmptNodeId[i]].absolutePosition.X) - shapeList[prmptNodeId[i]].width / 2 - 3, (int)(shapeList[prmptNodeId[i]].absolutePosition.Y) - shapeList[prmptNodeId[i]].height / 2 - 3), new Size(shapeList[prmptNodeId[i]].width + 6, shapeList[prmptNodeId[i]].height + 6)), new MCvScalar(prmptR, prmptG, prmptB), 3);
				}
			}
            //Draw blinking arrow
			if (arrowShower)
                for (int arg = 0; arg < _blinkArrowBeginNodeId.Length; arg++)
				    CvInvoke.ArrowedLine(prmpts, shapeList[_blinkArrowBeginNodeId[arg]].absolutePosition, shapeList[_blinkArrowEndNodeId[arg]].absolutePosition, new MCvScalar(arrowR, arrowG, arrowB), arrowThickness);

			overlayer = prmpts.Bitmap;
			overlayer.MakeTransparent(Color.Black);
			_taskFrame = tskImg.Bitmap;
            
			BitmapManager.DrawOn(overlayer, _taskFrame, alpha);
            overlayer.Dispose();
            prmpts.Dispose();
        }

		public void DrawNodePrompt(int Max, int[] id, Color prCol, bool recursive)
		{
			prmptNodeShower = Max;
			prmptNodeId = id;
			prmptNodeMaxShower = Max;
			prmptR = prCol.R; prmptG = prCol.G; prmptB = prCol.B;
			prmptRecursive = recursive;
		}

		public void DrawBlinkArrow(int Max, int[] id1, int[] id2, Color prCol, bool recursive, int ArrowThickess)
		{
			prmpts = new Image<Rgba, byte>(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y, new Rgba(0, 0, 0, 0));
			arrowShower = true;
			arrowThickness = ArrowThickess;
			_blinkArrowBeginNodeId = id1;
			_blinkArrowEndNodeId = id2;
			prmptNodeMaxShower = Max;
			arrowR = prCol.R; arrowG = prCol.G; arrowB = prCol.B;
			prmptRecursive = recursive;
		}

		public void UndrawPrmpt()
		{
			prmptRecursive = false;
			prmptNodeShower = 0;
			arrowShower = false;
			if (prmpts != null)
				prmpts.Dispose();
			DrawMap();
			_taskFrame = tskImg.Bitmap;
		}

		public int[] FindGroupedShapes()
		{
			if (runConf.shapeGroupingMode == GroupingMod.byColor)
				ColorGrouping();
            
            int[] res = new int[groupMembers.Count];

            for (int i = 0; i < groupMembers.Count; i++)
			{
				int[] keys = groupMembers[i].ToArray();
                int[] values = new int[keys.Length];
                for (int j=0; j < keys.Length; j++)
                {
                    values[j] = shapeList[keys[j]].number;
                }
                Array.Sort(keys, values);
                groupMembers[i].Clear();
                groupMembers[i].AddRange(keys);
                res[i] = groupMembers[i][0];
			}
           
			return res;
		}
		
		public Node findNode(int x, int y)
		{
			foreach (Node node in shapeList)
				if (node.shape == Shape.Circle)
				{
					if (Math.Sqrt(Math.Pow(Math.Abs(node.relationalPosition.X * OperationalSize.Width - x), 2) + Math.Pow(Math.Abs(node.relationalPosition.Y * OperationalSize.Height - y), 2)) <= node.width)
					{
						return node;
					}
				}
				else
				{
					if (Math.Abs(x - node.relationalPosition.X * OperationalSize.Width) < node.width / 2 && Math.Abs(y - node.relationalPosition.Y * OperationalSize.Height) < node.height / 2)
					{
						return node;
					}
				}
			return null;
		}

		public List<int> findNode(int x, int y, float radius)
		{
			List<int> bestNodes = new List<int>();
			for (int i = 0; i < shapeList.Count; i++)
			{
				if (shapeList[i].shape == Shape.Circle)
				{
					if (Math.Sqrt(Math.Pow(Math.Abs(shapeList[i].relationalPosition.X * OperationalSize.Width - x), 2) + Math.Pow(Math.Abs(shapeList[i].relationalPosition.Y * OperationalSize.Height - y), 2)) <= (shapeList[i].width / 2) * radius)
					{
						bestNodes.Add(i);
					}
				}
				else
				{
					if (Math.Abs(x - shapeList[i].relationalPosition.X * OperationalSize.Width) < (shapeList[i].width / 2) * radius && Math.Abs(y - shapeList[i].relationalPosition.Y * OperationalSize.Height) < (shapeList[i].height / 2) * radius)
					{
						bestNodes.Add(i);
					}
				}
			}
			return bestNodes;
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
				
				return true;
			}
			return false;
		}

		bool RemoveFixNode(int id)
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
				lines.Add("PsycoTaskLab");
				lines.Add("DateCreated:" + System.DateTime.Now.ToString());
				lines.Add("BackGround:" + "," + backColor.R + "," + backColor.G + "," + backColor.B);
				lines.Add("Shapes:" + "," + shapeList.Count.ToString());
				for (i = 0; i < shapeList.Count; i++)
				{
					char shape = 'c';
					if (shapeList[i].shape == Shape.Rectangle)
						shape = 'r';
					int shapecolorR = shapeList[i].shapeColor.R;
					int shapecolorG = shapeList[i].shapeColor.G;
					int shapecolorB = shapeList[i].shapeColor.B;
					float x = shapeList[i].relationalPosition.X;
					float y = shapeList[i].relationalPosition.Y;
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

		bool LoadFromText()
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
			float x, y;
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
				float.TryParse(s[4], out x);
				float.TryParse(s[5], out y);
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
					shapeList.Add(new Node(i - 4, new PointF(x, y), shp, shapeColor, number, textColor, width, height, fType, fTime, priority, radius, fixationColor, OperationalSize));
				}
				else
				{
					shapeList.Add(new Node(i - 4, new PointF(x, y), shp, shapeColor, number, textColor, width, height, OperationalSize));
				}
			}
			#endregion
			// اضافه کردن فیکسیشن ها

			//foreach (Node node in shapeList)
			//{
			//	if (node.fixationTime > 0)
			//	{
			//		AddFixateNode(node);
			//	}
			//}
			DrawMap();
			return true;
		}

		public void Clear()
		{
			base._taskIsReady = false;
			shapeList = null;
			fixationList = null;
			backColor = Color.Silver;
			
			DrawMap();
		}

		public bool Load(bool NewTask)
		{
			if (Load(NewTask, TaskType.lab).Result == ResultState.OK)
				return LoadFromText();
			else
				return false;
		}
	}
}
