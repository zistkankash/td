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

        public Bitmap image = null;
        public string address;
        public int time;
        public string name;
        public Color bgColor;
		public bool UseTransparency;
		public Color TransColor;
		public MediaType medType = MediaType.Image;
				
		public MediaEelement(Bitmap im, string add, int t)
        {
            this.image = im;
            this.address = add;
            this.time = t;
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
			address = add;
			havMedia = true;
			image = GetVideoFrame();
		}

		public MediaEelement(Bitmap x, Color color, int time, string add)
		{
			medType = MediaType.Image;
			image = x;
			bgColor = color;
			address = add;
			this.time = time;
		}

		public MediaType ReformInAddress()
		{
			if (address == null)
			{
				havMedia = false;
				medType = MediaType.Image;
				
			}
			if(Path.GetExtension(address) == ".png" || Path.GetExtension(address) == ".jpg" || Path.GetExtension(address) == ".jpeg" || Path.GetExtension(address) == ".bmp")
			{
				havMedia = true;
				medType = MediaType.Image;
				image = new Bitmap(address);
			}
			if (Path.GetExtension(address) == ".mp4" || Path.GetExtension(address) == ".avi" || Path.GetExtension(address) == ".mov" || Path.GetExtension(address) == ".asf" || Path.GetExtension(address) == ".wmv")
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
			r.Open(address);

			image = r.ReadVideoFrame(5);
			r.Close();
			r.Dispose();
            var player = new WindowsMediaPlayer();
            var clip = player.newMedia(address);
            time = (int)TimeSpan.FromSeconds(clip.duration).TotalMilliseconds;

            return image;
		}

	}
	public enum MediaType { Image , Video  }
}
