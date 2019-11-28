using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace TaskLab
{
    public class Node
    {
		public int _id;
        public bool enable;     ////  کمکی هنوز استفاده نشده
        public int type;        //// مشخص کننده نوع گره

        public char shape;       //// شکل گره را مشخص می کند
        public Color shapeColor;
        public Point pos;
        public int width;
        public int height;
        public int number;
        public Color textColor;

        public bool ROI;
        public char fixationType;
        public int fixationTime;
        public int priority;
        public int fixationRadius;
        public Color fixationColor;

        public Point next;      //// کمکی هنوز استفاده نشده



        // سازنده شکل بدون فیکسیشن
        public Node(int id,int x, int y, char s, Color sColor, int num, Color tColor, int w, int h)
        {
			_id = id;
            this.pos.X = x;
            this.pos.Y = y;
            this.shape = s;
            this.shapeColor = sColor;
            this.number = num;
            this.textColor = tColor;
            this.width = w;
            this.height = h;
            this.ROI = false;
        }

        // سازنده فیکسیشن با فیکسیشن
        public Node(int id, int x, int y, char s, Color sColor, int num, Color tColor, int w, int h, char fType, int fTime, int p, int fRadius, Color fColor)
        {
			_id = id;
            this.pos.X = x;
            this.pos.Y = y;
            this.shape = s;
            this.shapeColor = sColor;
            this.number = num;
            this.textColor = tColor;
            this.width = w;
            this.height = h;
            this.ROI = true;

            this.fixationType = fType;
            this.fixationTime = fTime;
            this.priority = p;
            this.fixationRadius = fRadius;
            this.fixationColor = fColor;
        }
        public Node()
        {
            this.enable = false;
        }
    }
}
