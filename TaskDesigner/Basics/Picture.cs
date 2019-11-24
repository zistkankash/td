using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Basics;

namespace Basics
{

    /// <summary>
	/// Data class for save slides in picture tasks.
	/// image saves bitmap of slide.
	/// address saves system file address of slide picture.
	/// time saves slide show time of slide.
	/// name saves an id name for slide to find in slides.
	/// bgColor saves background color of image in bitmap. Use Color.FromArgb to set this color using alpha channel.
	/// </summary>
	public class Picture
    {
        public Bitmap image = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
        public string address;
        public int time;
        public string name;
        public Color bgColor;
		
		public Picture(Bitmap im, string add, int t)
        {
            this.image = im;
            this.address = add;
            this.time = t;
        }
		
		public Picture(Bitmap x, Color color, int time, string add)
		{
			image = x;
			bgColor = color;
			address = add;
			this.time = time;
		}
	}
}
