using System.Drawing;
using System.IO;
using Accord.Video.FFMPEG;

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
	public class MediaEelement
    {
		bool havMedia;
		public Bitmap image = null;
        public string address;
        public int time;
        public string name;
        public Color bgColor;
		public MediaType medType = MediaType.Image;
		
		
		public MediaEelement(Bitmap im, string add, int t)
        {
            this.image = im;
            this.address = add;
            this.time = t;
			this.medType = MediaType.Image;
        }

		public MediaEelement(string add, int t)
		{
			medType = MediaType.Video;

			this.address = add;
			this.time = t;
		}

		public MediaEelement(Bitmap x, Color color, int time, string add)
		{
			medType = MediaType.Image;
			image = x;
			bgColor = color;
			address = add;
			this.time = time;
		}

		public void Reform()
		{
			if (address == null)
			{
				havMedia = false;
				return;
			}
			if(Path.GetExtension(address) == "png" || Path.GetExtension(address) == "jpg" || Path.GetExtension(address) == "jpeg" || Path.GetExtension(address) == "bmp")
			{
				havMedia = true;
				medType = MediaType.Image;
				image = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
			}
			if (Path.GetExtension(address) == "mp4" || Path.GetExtension(address) == "avi" || Path.GetExtension(address) == "mov" || Path.GetExtension(address) == "asf")
			{
				havMedia = true;
				medType = MediaType.Video;
			}
		}

		public Bitmap GetVideoFrame()
		{
			if (!havMedia || medType == MediaType.Image)
				return null;

			VideoFileReader r = new VideoFileReader();
			r.Open(address);
			image = r.ReadVideoFrame((int)r.FrameCount / 2);
			
			return image;
		}

	}
	public enum MediaType { Image , Video  }
}
