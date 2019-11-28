using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Basics
{
    public  class FNode
    {
        public int radius;
        public Point pos;
        public int time;
        public char type;
        public int priority;
        public bool seen;
		public int color;
        public bool sound;  //کمکی
        public int _id;   //کمکی

        public FNode(int id,int r, Point p, int t, int priority)
        {
			this._id = id;
            this.radius = r;
            this.pos = p;
            this.time = t;
            this.priority = priority;
            seen = false;
        }
        public FNode() { }
    }
}
