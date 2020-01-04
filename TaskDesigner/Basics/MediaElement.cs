using System.Drawing;
using System.IO;
using Accord.Video.FFMPEG;
using WMPLib;
using System;

namespace Basics
{

    /// <summary>
	/// Data class for save slides in media tasks.
	/// image saves bitmap of slide.
	/// address saves system file address of slide media.
	/// time saves slide show time of slide.
	/// name saves an id name for slide to find in slides.
	/// bgColor saves background color of image in bitmap. Use Color.FromArgb to set this color using alpha channel.
	/// </summary>
	public class MediaEelement
    {
        bool havMedia;

        public bool HaveMedia
        {
            get { return havMedia; }
            
        }

        public Bitmap Image = null;
        public string Address;
        public string URL;
        public int Time;
        public string Name;
        public Color BGColor;
		public bool UseTransparency;
		public Color TransColor;
		public MediaType medType = MediaType.Image;
				
		public MediaEelement(Bitmap im, string add, int t)
        {
            this.Image = im;
            this.Address = add;
            this.Time = t;
			this.medType = MediaType.Image;
            if (im == null)
                havMedia = false;
        }

		/// <summary>
        /// This constructor used for creating video elements.
        /// </summary>
        /// <param name="add"> address of video element.</param>
        public MediaEelement(string add)
		{
			medType = MediaType.Video;
			Address = add;
			havMedia = true;
			Image = GetVideoFrame();
		}

		public MediaEelement(Color color, int time, string add)
		{
			medType = MediaType.Image;
            Image = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
            using (Graphics g = Graphics.FromImage(Image))
                g.Clear(color);
            BGColor = color;
			Address = add;
			Time = time;
            havMedia = false;
		}

		public MediaType ReformInAddress()
		{
			if (Address == null)
			{
				havMedia = false;
				medType = MediaType.Image;
				
			}
			if(Path.GetExtension(Address) == ".png" || Path.GetExtension(Address) == ".jpg" || Path.GetExtension(Address) == ".jpeg" || Path.GetExtension(Address) == ".bmp")
			{
				havMedia = true;
				medType = MediaType.Image;
				Image = new Bitmap(Address);
			}
			if (Path.GetExtension(Address) == ".mp4" || Path.GetExtension(Address) == ".avi" || Path.GetExtension(Address) == ".mov" || Path.GetExtension(Address) == ".asf" || Path.GetExtension(Address) == ".wmv")
			{
				havMedia = true;
				medType = MediaType.Video;
				GetVideoFrame();
			}
			return medType;
		}

		public Bitmap GetVideoFrame()
		{
			if (!havMedia || medType == MediaType.Image)
				return null;
			
			VideoFileReader r = new VideoFileReader();
			r.Open(Address);

			Image = r.ReadVideoFrame(5);
			r.Close();
			r.Dispose();
            var player = new WindowsMediaPlayer();
            var clip = player.newMedia(Address);
            Time = (int)TimeSpan.FromSeconds(clip.duration).TotalMilliseconds;

            return Image;
		}

        public MediaEelement(string URL, int Time)
        {
            this.URL = URL;
            this.Time = Time;
            havMedia = true;
        }
	}
	public enum MediaType { Image , Video , Web  }
}
