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
		public Color BGColor;
		public bool UseTransparency;
		public Color TransColor;
		MediaType medType = MediaType.Image;
		
		public MediaType MediaTaskType { get { return medType; }  set { medType = value; } }

		public MediaEelement(Bitmap im, Color BackGroundColor, string add, int t)
        {
            this.Image = im;
            this.Address = add;
            this.Time = t;
			BGColor = BackGroundColor;
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

			if (CheckVideo())
			{
				medType = MediaType.Video;
				Address = add;
				havMedia = true;
			}
			else
			{
				medType = MediaType.Empty;
				havMedia = false;
			}
		}

		public MediaEelement(Color color, int FrameTime)
		{
			medType = MediaType.Image;
            Image = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
            using (Graphics g = Graphics.FromImage(Image))
                g.Clear(color);
			Time = FrameTime;
            BGColor = color;
			havMedia = false;
		}

		public MediaType VerifyElement()
		{
			if (Address == null)
			{
				havMedia = false;
				medType = MediaType.Empty;
				
			}
			if(Path.GetExtension(Address) == ".png" || Path.GetExtension(Address) == ".jpg" || Path.GetExtension(Address) == ".jpeg" || Path.GetExtension(Address) == ".bmp")
			{
			if(CheckImage())
				medType = MediaType.Image;
			}
			if (Path.GetExtension(Address) == ".mp4" || Path.GetExtension(Address) == ".avi" || Path.GetExtension(Address) == ".mov" || Path.GetExtension(Address) == ".asf" || Path.GetExtension(Address) == ".wmv")
			{
				CheckVideo();
			}
			return medType;
		}

		bool CheckVideo()
		{
			try
			{
				VideoFileReader r = new VideoFileReader();
				r.Open(Address);
				Image = r.ReadVideoFrame(5);
				r.Close();
				r.Dispose();
				var player = new WindowsMediaPlayer();
				var clip = player.newMedia(Address);
				Time = (int)TimeSpan.FromSeconds(clip.duration).TotalMilliseconds;
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		bool CheckImage()
		{
			try
			{
				Image = new Bitmap(Address);
				havMedia = true;
				medType = MediaType.Image;
				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}

        public MediaEelement(string URL, int Time)
        {
            this.URL = URL;
            this.Time = Time;
            havMedia = true;
			medType = MediaType.Web;
        }

        /// <summary>
        /// Rendering Image and Empty Media Tasks and update Image variable.
        /// </summary>
        public void RenderImage()
        {
            if (medType == MediaType.Image)
                RunnerUtils.MediaPictureRenderer(BGColor, Image, UseTransparency, TransColor, false, ref Image);
            if (medType == MediaType.Empty)
                Graphics.FromImage(Image).Clear(BGColor);
            
        }

	}
	public enum MediaType { Empty, Image, Video , Web }
}
