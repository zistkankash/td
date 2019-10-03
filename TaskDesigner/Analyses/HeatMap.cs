using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing.Imaging;

using System.IO;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Diagnostics;
using TaskDesigner;
using Basics;

namespace Analyses
{
    public partial class HeatMap : Form
    {
        private List<HeatPoint> HeatPoints = new List<HeatPoint>();
		private List<HeatPoint> manHeats = new List<HeatPoint>();
		private List<HeatPoint> femHeats = new List<HeatPoint>();
		private static ColorMap[] Colors2 = new ColorMap[256];
        //private StreamReader globalSR;
        private Bitmap map = new Bitmap(1440, 900);
        bool isTaskLab = false;
        int taskShapes;
		//string folderHist;
		string outputImageFileName="Target";
        
		public HeatMap()
        {
            InitializeComponent();
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CogLab Data");
			
            //txtSave.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CogLab Data"; ;
        }

        private void btnHeatPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "CSV Files (*.csv)|*.csv";

            if (open.ShowDialog() == DialogResult.OK)
            {
                isTaskLab = false;
                txtHeatPath.Text = open.FileName;
                int taskType = CheckTaskType();
                if(taskType == 1)
                {
                    CreateTaskLabTask();
                    pbHeat.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbHeat.Image = map;
                    isTaskLab = true;
                }
            }
        }

        private void CreateTaskLabTask()
        {
            int R, G, B;
            //int shapeR, shapeG, shapeB;
            int x, y;
            int width, height;
            int number;
            int numR, numG, numB;
            //char fixType;
            //int fixTime;
            //int fixPriority;
            int fixRadius;
            int fixR, fixG, fixB;
            StreamReader s = new StreamReader(txtHeatPath.Text);
            string line;
            string[] words;
            Image<Rgb, byte> img = new Image<Rgb, byte>(1440, 900);
            s.ReadLine();
            s.ReadLine();
            line = s.ReadLine();
            words = line.Split(',');
            Int32.TryParse(words[1], out R);
            Int32.TryParse(words[2], out G);
            Int32.TryParse(words[3], out B);
            //background = Color.FromArgb(R, G, B);
            CvInvoke.Rectangle(img, new Rectangle(0, 0, 1440, 900), new MCvScalar(R, G, B), -1);
            line = s.ReadLine();
            words = line.Split(',');
            int shapes;
            Int32.TryParse(words[1], out shapes);
            taskShapes = shapes;
            for (int i = 0; i < shapes; i++)
            {
                line = s.ReadLine();
                words = line.Split(',');
                Int32.TryParse(words[1], out R);
                Int32.TryParse(words[2], out G);
                Int32.TryParse(words[3], out B);
                Int32.TryParse(words[4], out x);
                Int32.TryParse(words[5], out y);
                Int32.TryParse(words[6], out width);
                Int32.TryParse(words[7], out height);

                if (words[0] == "C")
                {
                    CvInvoke.Circle(img, new Point(x, y), width / 2, new MCvScalar(R, G, B), -1);
                }
                else if (words[0] == "R")
                {
                    CvInvoke.Rectangle(img, new Rectangle(new Point(x - width / 2, y - height / 2), new Size(width, height)), new MCvScalar(R, G, B), -1);
                }
                Int32.TryParse(words[8], out number);
                Int32.TryParse(words[9], out numR);
                Int32.TryParse(words[10], out numG);
                Int32.TryParse(words[11], out numB);
                if (number != -1)
                {
                    //// کشیدن عدد
                    double numSize = width * 0.02;
                    int posOffsetX = 7;
                    int posOffsetY = 5;
                    int thickness = 5;
                    if (words[0] == "C")        // تنظیم شماره برای دایره
                    {
                        if (width <= 45)
                            thickness = 2;
                        if (number < 10)
                        {
                            posOffsetX = (int)(width * 0.2);
                            posOffsetY = (int)(width * 0.2);
                        }
                        else
                        {
                            posOffsetX = (int)(width * 0.4);
                            posOffsetY = (int)(width * 0.2);
                        }
                    }
                    else if (words[0] == "R")        // تنظیم شماره برای مستطیل
                    {
                        numSize = Math.Min(height, width) * 0.02;
                        if (Math.Min(height, width) <= 45)
                            thickness = 2;
                        if (number < 10)
                        {
                            posOffsetX = (int)(width * 0.2);
                            posOffsetY = (int)(width * 0.15);
                        }
                        else
                        {
                            posOffsetX = (int)(width * 0.4);
                            posOffsetY = (int)(height * 0.15);
                        }
                    }
                    // رسم شماره
                    CvInvoke.PutText(img, number.ToString(), new Point(x - posOffsetX, y + posOffsetY), new Emgu.CV.CvEnum.FontFace(), numSize, new MCvScalar(numR, numG, numB), thickness);
                }
                if (words[12] == "TRUE" || words[12] == "True")
                {
                    Int32.TryParse(words[16], out fixRadius);
                    Int32.TryParse(words[17], out fixR);
                    Int32.TryParse(words[18], out fixG);
                    Int32.TryParse(words[19], out fixB);
                    // کشیدن فیکسیشن
                    CvInvoke.Circle(img, new Point(x, y), fixRadius, new MCvScalar(fixR, fixG, fixB));
                }
            }
            map = img.ToBitmap();
        }
        private int CheckTaskType()
        {
            StreamReader s = new StreamReader(txtHeatPath.Text);
            string line = s.ReadLine();
            string[] words = line.Split(',');
            if (words[0] == "TaskLab")
            {
                return 1;
            }
            else
                return 0;
        }

        private void btnHeatPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog picAddress = new OpenFileDialog();
            picAddress.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
            if (picAddress.ShowDialog() == DialogResult.OK)
            {
                txtHeatPic.Text = picAddress.FileName;
                Bitmap bit = new Bitmap(txtHeatPic.Text);
                pbHeat.SizeMode = PictureBoxSizeMode.StretchImage;
                pbHeat.Image = bit;
            }
        }

        private void btnCreateHeatMap_Click(object sender, EventArgs e)
        {
            //if (cmbFileType.SelectedText == "TaskLab")
            //    CreateBackground();
            if (cmbType.Text == "Heat Map")
                Heating();
            else if (cmbType.Text == "Heat Point")
                HeatPoint();
            else if (cmbType.Text == "Heat Movie")
                HeatMovie();
            else if (cmbType.Text == "Heat Chart")
                HeatChart2();
            else if (cmbType.Text == "Chart Movie")
                ChartMovie();
        }

        private bool CreateBackground()
        {
            StreamReader s = new StreamReader(txtHeatPath.Text);
            string line;
            string[] bg;
            line = s.ReadLine();
            if (line != "TaskLab")
                return false;
            s.ReadLine();       //date created
            line = s.ReadLine();
            bg = line.Split(',');   //background
            int r, g, b;
            Int32.TryParse(bg[1], out r);
            Int32.TryParse(bg[2], out g);
            Int32.TryParse(bg[3], out b);
            line = s.ReadLine();
            string[] Number = line.Split(',');
            int shapeNumber;
            Int32.TryParse(Number[1], out shapeNumber);
            for(int i = 0; i < shapeNumber; i++)
            {
                
            }
            return true;
        }

        private void ChartMovie()
        {
            Bitmap pic;
            if (isTaskLab)
                pic = map;
            else
            {
                Bitmap temp = new Bitmap(txtHeatPic.Text);
                pic = temp;
            }
            Image<Bgr, byte> img = new Image<Bgr, byte>(pic);
            StreamReader s = new StreamReader(txtHeatPath.Text);
            string path;
            if (chkSave.Checked)
            {
                path = txtSave.Text;
            }
            else
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CogLab Data";
            VideoWriter video = new VideoWriter(path + "\\ChartMovie.avi", 5, new Size(1440, 900), true);
            int counter = 0;
            int number = 1;
            int sumX = 0, sumY = 0;
            int currentX = -1, currentY = -1;
            string line;
            int[,] cells = new int[20, 20];
            int[,] c = new int[20, 20];
            string[] i;
            double m = 0, n = 0;
            int x = 0, y = 0;
            while ((line = s.ReadLine()) != null)
            {
                i = line.Split(',');
                double.TryParse(i[0], out m);
                double.TryParse(i[1], out n);
                x = (int)m;
                y = (int)n;
                i[0] = "";
                i[1] = "";
                if (x > 0 && x < 1440 && y > 0 && y < 900)
                {
                    counter++;
                    sumX += x;
                    sumY += y;
                }
                if (counter == 8)
                {

                    counter = 0;
                    if (currentX == -1 && currentY == -1)
                    {
                        CvInvoke.Circle(img, new Point((sumX / 8), (sumY / 8)), 10, new MCvScalar(255, 255, 0, 125), -1);
                        CvInvoke.PutText(img, number.ToString(), new Point((sumX / 8), (sumY / 8)), new FontFace(), 0.5, new MCvScalar(0, 0, 255, 125));
                        Mat frame = img.Mat;
                        video.Write(frame);
                        number++;
                        currentX = sumX;
                        currentY = sumY;
                        frame.Dispose();
                    }
                    else
                    {
                        double distance = Math.Sqrt((sumX - currentX) * (sumX - currentX) + (sumY - currentY) * (sumY - currentY));
                        if (distance > 500)
                        {
                            CvInvoke.Circle(img, new Point((sumX / 8), (sumY / 8)), 10, new MCvScalar(255, 255, 0, 125), -1);
                            CvInvoke.PutText(img, number.ToString(), new Point((sumX / 8), (sumY / 8)), new FontFace(), 0.5, new MCvScalar(0, 0, 255, 125));
                            CvInvoke.ArrowedLine(img, new Point(currentX / 8, currentY / 8), new Point((sumX / 8), (sumY / 8)), new MCvScalar(255, 0, 255, 125), 1);
                            Mat frame = img.Mat;
                            video.Write(frame);
                            number++;
                            currentX = sumX;
                            currentY = sumY;
                            frame.Dispose();
                        }
                    }
                    sumY = 0;
                    sumX = 0;
                }
            }
            pbHeat.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHeat.Image = img.ToBitmap();
            video.Dispose();
            MessageBox.Show("Chart ic Complete!!!");
        }
        
		private void HeatChart2()
        {
            Bitmap pic;
            if (isTaskLab)
                pic = map;
            else
            {
                Bitmap temp = new Bitmap(txtHeatPic.Text);
                pic = temp;
            }
            Image<Bgr, byte> img = new Image<Bgr, byte>(pic);
            StreamReader s = new StreamReader(txtHeatPath.Text);
			FontFace chartFont = new FontFace();
			
            int counter = 0;
            int number = 1;
            int sumX = 0, sumY = 0;
            int currentX = -1, currentY = -1;
            string line;
            int[,] cells = new int[20, 20];
            int[,] c = new int[20, 20];
            string[] i;
            double m = 0, n = 0;
            int x = 0, y = 0;
            while ((line = s.ReadLine()) != null)
            {
                i = line.Split(',');
                double.TryParse(i[0], out m);
                double.TryParse(i[1], out n);
                x = (int)m;
                y = (int)n;
                i[0] = "";
                i[1] = "";
                if (x > 0 && x < 1440 && y > 0 && y < 900)
                {
                    counter++;
                    sumX += x;
                    sumY += y;
                }
                if (counter == 8)
                {

                    counter = 0;
                    if (currentX == -1 && currentY == -1)
                    {
                        CvInvoke.Circle(img, new Point((sumX / 8), (sumY / 8)), 10, new MCvScalar(255, 255, 0, 125), -1);
						CvInvoke.PutText(img, number.ToString(), new Point((sumX / 8) - 2, (sumY / 8) - 2),chartFont , 0.6, new MCvScalar(0, 0, 0, 0));
                        number++;
                        currentX = sumX;
                        currentY = sumY;
                    }
                    else
                    {
                        double distance = Math.Sqrt((sumX - currentX) * (sumX - currentX) + (sumY - currentY) * (sumY - currentY));
                        if (distance > 500)
                        {
                            CvInvoke.Circle(img, new Point((sumX / 8), (sumY / 8)), 10, new MCvScalar(255, 255, 0, 125), -1);
                            CvInvoke.PutText(img, number.ToString(), new Point((sumX / 8) - 2, (sumY / 8) - 2),chartFont , 0.6, new MCvScalar(0, 0, 0, 0));
                            CvInvoke.ArrowedLine(img, new Point(currentX / 8, currentY / 8), new Point((sumX / 8), (sumY / 8)), new MCvScalar(255, 0, 255, 125), 1);
                            number++;
                            currentX = sumX;
                            currentY = sumY;
                        }
                    }
                    sumY = 0;
                    sumX = 0;
                }
            }
            string path;
            if (chkSave.Checked)
            {
                path = txtSave.Text;
            }
            else
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CogLab Data";
            img.Save(path + "\\HeatCharts\\" + outputImageFileName + ".jpg");
            pbHeat.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHeat.Image = img.ToBitmap();
			
            //MessageBox.Show("Chart ic Complete!!!");
        }
        
		private void HeatChart()
        {
            Bitmap pic = new Bitmap(txtHeatPic.Text);
            Image<Bgr, byte> img = new Image<Bgr, byte>(pic);
            StreamReader s = new StreamReader(txtHeatPath.Text);
            //int diiffrence;
            int currentX = -1, currentY = -1;
            string line;
            int[,] cells = new int[20, 20];
            int[,] c = new int[20, 20];
            string[] i;
            double m = 0, n = 0;
            int x = 0, y = 0;
            while ((line = s.ReadLine()) != null)
            {
                i = line.Split(',');
                double.TryParse(i[0], out m);
                double.TryParse(i[1], out n);
                x = (int)m;
                y = (int)n;
                i[0] = "";
                i[1] = "";
                if (x > 0 && x < 1440 && y > 0 && y < 900)
                {
                    cells[y / 46, x / 73]++;
                    if (currentX == -1 && currentY == -1)
                    {
                        currentX = x / 73;
                        currentY = y / 46;
                    }
                    if (currentX == x / 73 && currentY == y / 46)
                    {
                        //diiffrence = 0;
                    }
                    else
                    {
                        CvInvoke.Circle(img, new Point(currentX * 73, currentY * 46), 10, new MCvScalar(255, 255, 0, 125), -1);
                        CvInvoke.ArrowedLine(img, new Point(currentX * 73, currentY * 46), new Point((x / 73) * 73, (y / 46) * 46), new MCvScalar(255, 0, 255, 125), 2);
                        currentX = x / 73;
                        currentY = y / 46;
                    }
                    //    diiffrence++;
                    //if(diiffrence == 3)
                    //{
                    //    CvInvoke.Circle(img, new Point(currentX * 73, currentY * 46), 5, new MCvScalar(0, 255, 255), -1);
                    //    currentX = x / 73;
                    //    currentY = y / 46;
                    //}
                }
            }
            img.Save("HeatChart.jpg");
            pbHeat.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHeat.Image = img.ToBitmap();
            MessageBox.Show("Chart ic Complete!!!");
        }
        
		private void HeatMovie()
        {
            Bitmap jPic;
            if (isTaskLab)
                jPic = map;
            else
            {
                Bitmap temp = new Bitmap(txtHeatPic.Text);
                jPic = temp;
            }
            Colors2 = CreatePalleteIndex(125);
            string path;
            if (chkSave.Checked)
            {
                path = txtSave.Text;
            }
            else
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            VideoWriter video = new VideoWriter(path + "\\video.avi", 5, new Size(1440, 900), true);
            int min = 0;
            int max = 0;
            StreamReader s = new StreamReader(txtHeatPath.Text);
            string line;
            int[,] cells = new int[30, 48];
            int[,] c = new int[30, 48];
            while ((line = s.ReadLine()) != null)
            {
                string[] i = line.Split(',');
                double m = 0, n = 0;
                int x = 0, y = 0;
                double.TryParse(i[0], out m);
                double.TryParse(i[1], out n);
                x = (int)m;
                y = (int)n;
                if (x > 0 && x < 1440 && y > 0 && y < 900)
                {
                    cells[y / 31, x / 49]++;
                    min = Math.Min(min, cells[y / 31, x / 49]);
                    max = Math.Max(max, cells[y / 31, x / 49]);
                }
            }
            s.Close();
            int fCounter = 0;
            StreamReader ss = new StreamReader(txtHeatPath.Text);
            int counter = 0;
            while ((line = ss.ReadLine()) != null)
            {
                string[] i = line.Split(',');
                double m = 0, n = 0;
                int x = 0, y = 0;
                double.TryParse(i[0], out m);
                double.TryParse(i[1], out n);
                x = (int)m;
                y = (int)n;
                if (x > 0 && x < 1440 && y > 0 && y < 900)
                {
                    counter++;
                    c[y / 31, x / 49]++;
                }
                if (counter == 8)
                {
                    fCounter++;
                    Bitmap pic = new Bitmap(1440, 900);
                    int iX;
                    int iY;
                    byte iIntense;
                    for (int k = 0; k < 30; k++)
                        for (int l = 0; l < 48; l++)
                        {
                            decimal val = Convert.ToDecimal((c[k, l] - min)) / (max - min) * 255;
                            iX = (l * 48) + 24;
                            iY = (k * 30) + 15;
                            iIntense = (byte)val;
                            HeatPoints.Add(new HeatPoint(iX, iY, iIntense));
                        }
                    pic = CreateIntensityMask(pic, HeatPoints);
                    Bitmap maskPic = pic;
                    Bitmap output = Colorize2(pic, 125);

                    var target = new Bitmap(1440, 900, PixelFormat.Format32bppArgb);
                    var graphics = Graphics.FromImage(target);
                    graphics.CompositingMode = CompositingMode.SourceOver;
                    graphics.DrawImage(jPic, 0, 0);
                    graphics.DrawImage(output, 0, 0);
                    Image<Bgr, byte> im = new Image<Bgr, byte>(target);
                    Mat frame = im.Mat;
                    video.Write(frame);
                    counter = 0;

                    pic.Dispose();
                    target.Dispose();
                    graphics.Dispose();
                    im.Dispose();
                    frame.Dispose();
                    maskPic.Dispose();
                    output.Dispose();
                }
                HeatPoints.Clear();
            }
            video.Dispose();
            MessageBox.Show("Video Generated Successfully", "Success");
            fCounter++;
        }
        
		private void HeatPoint()
        {
            int codec = VideoWriter.Fourcc('M', 'P', '4', 'V');
            string path;
            if (chkSave.Checked)
            {
                path = txtSave.Text;
            }
            else
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CogLab Data";
            VideoWriter pointVideo = new VideoWriter(path + "\\pointVideo.avi", 10, new Size(1440, 900), true);
            Bitmap source;
            if (isTaskLab)
                source = map;
            else
            {
                Bitmap temp = new Bitmap(txtHeatPic.Text);
                source = temp;
            }
            Point[] points = new Point[8];
            int counter = 0;
            StreamReader s = new StreamReader(txtHeatPath.Text);
            string line;
            if (isTaskLab)
            {
                for (int i = 0; i < taskShapes + 4; i++)
                    s.ReadLine();
            }
            while ((line = s.ReadLine()) != null)
            {
                string[] i = line.Split(',');
                double m = 0, n = 0;
                int x = 0, y = 0;
                double.TryParse(i[0], out m);
                double.TryParse(i[1], out n);
                x = (int)m;
                y = (int)n;
                if (x > 0 && x < 1440 && y > 0 && y < 900)
                {
                    points[counter] = new Point(x, y);
                    counter++;
                }
                if (counter == 8)
                {
                    int aveX = 0, aveY = 0;
                    counter = 0;
                    for (int index = 0; index < 8; index++)
                    {
                        aveX += points[index].X;
                        aveY += points[index].Y;
                    }
                    aveX /= 8;
                    aveY /= 8;
                    Image<Bgr, byte> temp = new Image<Bgr, byte>(source);
                    CvInvoke.Circle(temp, new Point(aveX, aveY), 10, new MCvScalar(255, 255, 0), -1);
                    Mat mat = temp.Mat;
                    pointVideo.Write(mat);
                    mat.Dispose();
                    temp.Dispose();

                }
            }
            pointVideo.Dispose();
            MessageBox.Show("Heat Point Created!!!!");
        }
		
		private void Heating()
		{
			int counter = 0;
			int min = 0;
			int max = 0;
			StreamReader s = new StreamReader(txtHeatPath.Text);
			string line;
			int[,] cells = new int[30, 48];
			HeatPoints.Clear();
			if (isTaskLab)
			{
				for (int i = 0; i < taskShapes + 4; i++)
					s.ReadLine();
			}
			while ((line = s.ReadLine()) != null)
			{
				string[] i = line.Split(',');
				double m = 0, n = 0;
				int x = 0, y = 0;
				//Int32.TryParse(i[0], out x);
				//Int32.TryParse(i[1], out y);
				double.TryParse(i[0], out m);
				double.TryParse(i[1], out n);
				x = (int)m;
				y = (int)n;
				if (x > 0 && x < 1440 && y > 0 && y < 900)
				{
					counter++;
					cells[y / 31, x / 49]++;
					min = Math.Min(min, cells[y / 31, x / 49]);
					max = Math.Max(max, cells[y / 31, x / 49]);
				}
			}
			Bitmap jPic;
			if (isTaskLab)
				jPic = map;
			else
			{
				Bitmap temp = new Bitmap(txtHeatPic.Text);
				jPic = temp;
			}

			Bitmap pic;

			pic = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
						
			int iX;
			int iY;
			byte iIntense;
			for (int i = 0; i < 30; i++)
				for (int j = 0; j < 48; j++)
				{
					decimal val = Convert.ToDecimal((cells[i, j] - min)) / (max - min + 1) * 255;
					cells[i, j] = (byte)val;
					iX = (j * 48) + 24;
					iY = (i * 30) + 15;
					iIntense = (byte)val;
					HeatPoints.Add(new HeatPoint(iX, iY, iIntense));
					
				}
			pic = CreateIntensityMask(pic, HeatPoints);
			Bitmap maskPic = pic;
			Bitmap output = Colorize(pic, 125);
			
			var target = new Bitmap(pbHeat.Size.Width, pbHeat.Size.Height, PixelFormat.Format32bppArgb);
			var graphics = Graphics.FromImage(target);
			
			graphics.CompositingMode = CompositingMode.SourceOver;
			graphics.DrawImage(jPic, 0, 0);
			graphics.DrawImage(output, 0, 0);

			string path;
            if (chkSave.Checked)
            {
                path = txtSave.Text;
            }
            else
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CogLab Data";
			Directory.CreateDirectory(path + "\\HeatPoints\\");
            target.Save(path + "\\HeatPoints\\" + outputImageFileName + ".jpg", ImageFormat.Jpeg);
		
			//jPic.Save("jpic", ImageFormat.Jpeg);
            Image<Rgb, byte> im = new Image<Rgb, byte>(Colorize(pic, 255));
            im.ToBitmap().Save("j.png");
            pbHeat.SizeMode = PictureBoxSizeMode.StretchImage;
            pbHeat.Image = target;
			GC.Collect();
            MessageBox.Show("Heat Map Created!!!!");
        }
        
		public static Bitmap Colorize2(Bitmap Mask, byte Alpha)
        {
            Bitmap Output = new Bitmap(Mask.Width, Mask.Height, PixelFormat.Format32bppArgb);

            Graphics Surface = Graphics.FromImage(Output);
            Surface.Clear(Color.Transparent);
            //ColorMap[] Colors = CreatePalleteIndex(Alpha);
            ImageAttributes Remapper = new ImageAttributes();
            Remapper.SetRemapTable(Colors2);
            Surface.DrawImage(Mask, new Rectangle(0, 0, Mask.Width, Mask.Height), 0, 0, Mask.Width, Mask.Height, GraphicsUnit.Pixel, Remapper);
            Surface.Dispose();
            return Output;
        }
        
		public static Bitmap Colorize(Bitmap Mask, byte Alpha)
        {
            Bitmap Output = new Bitmap(Mask.Width, Mask.Height, PixelFormat.Format32bppArgb);

            Graphics Surface = Graphics.FromImage(Output);
            Surface.Clear(Color.Transparent);
            ColorMap[] Colors = CreatePalleteIndex(Alpha);
            ImageAttributes Remapper = new ImageAttributes();
            Remapper.SetRemapTable(Colors);
            Surface.DrawImage(Mask, new Rectangle(0, 0, Mask.Width, Mask.Height), 0, 0, Mask.Width, Mask.Height, GraphicsUnit.Pixel, Remapper);
            return Output;
        }
        
		private static ColorMap[] CreatePalleteIndex(byte Alpha)
        {
            ColorMap[] OutputMap = new ColorMap[256];
			Bitmap Pallete = (Bitmap)Resource.palette;
            for (int X = 0; X <= 254; X++)
            {
                OutputMap[X] = new ColorMap();
                OutputMap[X].OldColor = Color.FromArgb(X, X, X);
                OutputMap[X].NewColor = Color.FromArgb(Alpha, Pallete.GetPixel(X, 0));
            }
            OutputMap[255] = new ColorMap();
            OutputMap[255].OldColor = Color.FromArgb(255, 255, 255);
            OutputMap[255].NewColor = Color.FromArgb(0, 255, 255, 255);
            return OutputMap;
        }
        
		private Bitmap CreateIntensityMask(Bitmap bSurface, List<HeatPoint> aHeatPoint)
        {
            Graphics DrawSurface = Graphics.FromImage(bSurface);
            DrawSurface.Clear(Color.White);
            foreach (HeatPoint DataPoint in aHeatPoint)
            {
                DrawHeatPoint(DrawSurface, DataPoint, 35);
            }
            DrawSurface.Dispose();
            return bSurface;
        }
        
		private void DrawHeatPoint(Graphics Canvas, HeatPoint Heatpoint, int Radius)
        {
            List<Point> CircumferencePointsList = new List<Point>();
            Point CircumferencePoint;
            Point[] CircumferencePointsArray;
            float fRatio = 1F / byte.MaxValue;
            byte bHalf = byte.MaxValue / 2;
            int iIntensity = (byte)(Heatpoint.Intensity - ((Heatpoint.Intensity - bHalf) * 2));
            float fIntensity = iIntensity * fRatio;
            for (double i = 0; i <= 360; i += 10)
            {
                CircumferencePoint = new Point();
                CircumferencePoint.X = Convert.ToInt32(Heatpoint.X + Radius * Math.Cos(ConvertDegreesToRadius(i)));
                CircumferencePoint.Y = Convert.ToInt32(Heatpoint.Y + Radius * Math.Sin(ConvertDegreesToRadius(i)));
                CircumferencePointsList.Add(CircumferencePoint);
            }

            CircumferencePointsArray = CircumferencePointsList.ToArray();

            PathGradientBrush GradientShaper = new PathGradientBrush(CircumferencePointsArray);
            ColorBlend GradientSpecifications = new ColorBlend(3);
            GradientSpecifications.Positions = new float[3] { 0, fIntensity, 1 };
            GradientSpecifications.Colors = new Color[3]
            {
                Color.FromArgb(0, Color.White),
                Color.FromArgb(Heatpoint.Intensity, Color.Black),
                Color.FromArgb(Heatpoint.Intensity, Color.Black)
            };
            GradientShaper.InterpolationColors = GradientSpecifications;
            Canvas.FillPolygon(GradientShaper, CircumferencePointsArray);
        }
        
		private double ConvertDegreesToRadius(double degrees)
        {
            double radius = (Math.PI / 180) * degrees;
            return (radius);
        }
        
		private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSave.Checked == true)
            {
                FolderBrowserDialog savePath = new FolderBrowserDialog();
				savePath.Tag = "Where to save results...";
                if (savePath.ShowDialog() == DialogResult.OK)
                {
                    txtSave.Text = savePath.SelectedPath;
                }
            }
            else
                txtSave.Text = "";
        }
        
		private void HeatMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            this.Close();
        }
		
		private void btnBatchAnalyz_Click(object sender, EventArgs e)
		{
			//process name files in selected folder and get number of triable file results related to selected task/pic
			//all of triable results must be in one folder
			string[] lst,nums;
			string fn;
			int i, tbNum, tsNum;
			try
			{
				OpenFileDialog picAddress = new OpenFileDialog();
				picAddress.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
				if (picAddress.ShowDialog() == DialogResult.OK)
				{
					txtHeatPic.Text = picAddress.FileName;
					Bitmap bit = new Bitmap(txtHeatPic.Text);
					pbHeat.SizeMode = PictureBoxSizeMode.StretchImage;
					pbHeat.Image = bit;
				}
				else
					return;

				string imageName = Path.GetFileNameWithoutExtension(txtHeatPic.Text);

				//get image file name

				chkSave.Checked = true;
				chkSave.Enabled = false;
				if (txtSave.Text == "")
				{
					chkSave.Checked = false;
					return;
				}
				//Directory.CreateDirectory(txtSave.Text+"\\manHeatPoints");
				//Directory.CreateDirectory(txtSave.Text + "\\femHeatPoints");
				lst = Directory.GetFiles(txtSave.Text);
				for (i = 0; i < lst.Length; i++)
				{

					Debug.WriteLine(i);
					
					fn = Path.GetFileNameWithoutExtension(lst[i]);
					nums = Regex.Split(fn, @"\D+");
					if (nums.Length < 2)
						continue;
					tbNum = int.Parse(nums[1]);
					tsNum = int.Parse(nums[2]);
					if (fn.Contains(imageName))
					{
						outputImageFileName = "p" + tbNum.ToString() + "h" + tsNum.ToString();
						txtHeatPath.Text = lst[i];
						Heating();

						//if (tbNum == 1 | tbNum == 4 | tbNum == 5 | tbNum == 8 | tbNum == 10 | tbNum == 13 | tbNum == 14 | tbNum == 15 | tbNum == 16 | tbNum == 18 | tbNum == 23 | tbNum == 24 | tbNum == 25 | tbNum == 28 | tbNum == 30 | tbNum == 34 | tbNum == 35 | tbNum == 36 | tbNum == 40 | tbNum == 44 | tbNum == 46 | tbNum == 48 | tbNum == 49 | tbNum == 50 | tbNum == 51 | tbNum == 52 | tbNum == 53)


						//outputImageFileName = "p" + tbNum.ToString() + "ch" + tsNum.ToString();
						//HeatChart2();

					}
				}
				chkSave.Checked = false;
				chkSave.Enabled = true;
			}
			catch(Exception exp)
			{
				chkSave.Checked = false;
				chkSave.Enabled = true;
				MessageBox.Show("There is problem" + exp.Message);
				return;
			}
			MessageBox.Show("Successful");
		}
	}
}
