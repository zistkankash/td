using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Basics
{
    public class Node
    {
		public int _id;
        public bool enable;     
        public int type;
        public double _distToPoint; // used for node search
		public int NearHeatCountforNode, HeatCountforNode;
        public Shape shape;       
        public Color shapeColor;
        public Point absolutePosition;
		public PointF relationalPosition;
        public int width;
        public int height;
        public int number;
        public Color textColor;

        public char fixationType;
        public int fixationTime;
        public int priority;
        public int fixationRadius;
        public Color fixationColor;
		      

        // سازنده شکل بدون فیکسیشن
        public Node(int id, PointF point, Shape s, Color sColor, int num, Color tColor, int w, int h, Size OperSize)
        {
			_id = id;
			relationalPosition = point;
            this.absolutePosition.X = (int)(point.X * OperSize.Width);
			this.absolutePosition.Y = (int)(point.Y * OperSize.Height);
			this.shape = s;
            this.shapeColor = sColor;
            this.number = num;
            this.textColor = tColor;
            this.width = w;
            this.height = h;
           
        }

        public Node(int id, Point point ,Shape s, Color ShapeColor, int ShapeNumber,double dist)
        {
            _id = id;
            absolutePosition = point;
            shape = s;
            number = ShapeNumber;
            shapeColor = ShapeColor;
            _distToPoint = dist;
        }

        // سازنده فیکسیشن با فیکسیشن
        public Node(int id, PointF point, Shape s, Color sColor, int num, Color tColor, int w, int h, char fType, int fTime, int p, int fRadius, Color fColor, Size OperSize)
        {
			_id = id;
			relationalPosition = point;
			this.absolutePosition.X = (int)(point.X * OperSize.Width);
			this.absolutePosition.Y = (int)(point.Y * OperSize.Height);
			this.shape = s;
            this.shapeColor = sColor;
            this.number = num;
            this.textColor = tColor;
            this.width = w;
            this.height = h;
           

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

        public Node ClonePlusDist(double DistanceToPoint)
        {
            return new Node(_id, absolutePosition, shape, shapeColor, number,DistanceToPoint);
        }
    }
}
