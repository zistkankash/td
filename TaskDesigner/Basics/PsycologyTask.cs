﻿using System;
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
		public List<Node> shapeList;
		public List<Node> fixationList;
		public List<FNode> positiveFixates;
		public List<FNode> negativeFixates;
		
		private Image<Rgb, byte> tskImg;

		//In design mode temp image used to compose some feature (for example chessboard grid) with task image.
		//In running mode temp image used to save original task map to improve running speed. 
		public Image<Rgb, byte> tskTempImg;
			

		public int[] colorGroups = null;
		public List<List<int>> groupMembers = null;
		public int groupCount = -1;

		public int prmptCircleShower, prmptCircleMaxShower = 10;
		public int prmptCircleNodeId;
		public int prmptCircleRadius;
		public int prmptCircleB = 10, prmptCircleG = 235, prmptCircleR = 255;
		public int arrowShower;
		public int arrowBeginNodeId;
		public int arrowEndNodeId;


		public Image<Rgb, byte> GetTaskImage { get { return tskImg; } }

		
		public PsycologyTask()
		{
			base._taskIsReady = false;
			fixationList = new List<Node>();
			positiveFixates = new List<FNode>();
			negativeFixates = new List<FNode>();
			shapeList = new List<Node>();
			backColor = Color.White;
			arrowShower = 0;
			prmptCircleShower = 0;
			
		}

		public void Clear()
		{
			base._taskIsReady = false;
			if (shapeList != null)
				shapeList.Clear();
			if (positiveFixates != null)
				positiveFixates.Clear();
			if (negativeFixates != null)
				negativeFixates.Clear();
			backColor = Color.White;
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

			if (tskTempImg != null)
				tskTempImg.Dispose();

			if (useBackImage)
				tskTempImg = new Image<Rgb, byte>(backImage);
			else
				tskTempImg = new Image<Rgb, byte>(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y, new Rgb(backColor));
			
			tskImg = tskTempImg;
		}

		public void CreateNode(int index, char shape, int num, int x, int y, int w, int h, Color sColor, Color numColor)
		{
			if (index == -1)
				shapeList.Add(new Node(0, x, y, shape, sColor, num, numColor, w, h));
			else
				shapeList[index] = new Node(0, x, y, shape, sColor, num, numColor, w, h);
		}

		public void CreateFixateNode(int index, char shape, int num, int x, int y, int w, int h, Color sColor, Color numColor, int fTime , int fColor , int fRadius)
		{
			CreateNode(index, shape, num, x, y, w, h, sColor, numColor);
			//add Fnode

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
		public void DrawCircle()
		{

			if (prmptCircleShower == 0)
				return;
			tskImg = tskTempImg;
			int alpha = Math.Min((int)(prmptCircleShower / prmptCircleMaxShower * 255), 255);
			CvInvoke.Circle(tskImg, shapeList[prmptCircleNodeId].pos, shapeList[prmptCircleNodeId].width, new MCvScalar(prmptCircleB, prmptCircleG, prmptCircleR, alpha));
		}

		public void DrawArrow()
		{
			if (arrowShower == 0)
				return;
			tskImg = tskTempImg;

			CvInvoke.ArrowedLine(tskImg, shapeList[arrowBeginNodeId].pos, shapeList[arrowEndNodeId].pos, new MCvScalar(0, 0, 0, 125), 5);
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

		/// <summary>
		/// Saving Psycology task in text file.
		/// In future text was replaced with bin format.
		/// </summary>
		/// <returns></returns>
		public bool Save()
		{
			int i;
			if (base._tskAddress == null)
			{
				SaveFileDialog path = new SaveFileDialog();
				if (tskSavMod == SaveMod.txt)
				{
					path.FileName = "LapTask.txt";
					path.Filter = "Text File |*.txt";
				}
				if (tskSavMod == SaveMod.bin)
				{
					path.FileName = "LapTask.bin";
					path.Filter = "Text File |*.bin";
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

					File.WriteAllLines(base._tskAddress, lines);

				}
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
