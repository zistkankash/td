using System.Drawing;
using System.IO;
using WMPLib;
using System;
using System.Windows.Media.Imaging;

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
		Bitmap _image = null;
        string _address;
        string _url;
        int _time;
		Color _bgColor;
		public bool UseTransparency;
		public Color TransColor;
		MediaType medType = MediaType.Empty;

		public Color BGColor { get { return _bgColor; } set { _bgColor = value;  RenderImage(); } }

		public Bitmap Image { get { return _image; } set { _image = value; RenderImage(); } }

		public MediaType MediaTaskType { get { return medType; } }

		public string  Address { get { return _address; } }

		public string URL { get { return _url; } }

		public int Time { get { return _time; } set { _time = value; } }

		public MediaEelement(Color BackGroundColor, string Address, int Time)
		{
			if (VerifyElementbyAddress(Address, false) != MediaType.Empty)
			{
				_time = Time;
				BGColor = BackGroundColor;
			}

		}

		/// <summary>
		/// This constructor used for creating video elements.
		/// </summary>
		/// <param name="add"> address of video element.</param>
		public MediaEelement(string Address)
		{
			VerifyElementbyAddress(Address, false);
		}

		public MediaEelement(Color color, int FrameTime)
		{
			medType = MediaType.Empty;
            Image = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
            using (Graphics g = Graphics.FromImage(Image))
                g.Clear(color);
			Time = FrameTime;
            BGColor = color;
			havMedia = false;
		}

		public MediaType VerifyElementbyAddress(string Address, bool IsURL)
		{
			if (Address == null)
			{
				havMedia = false;
				medType = MediaType.Empty;
				
			}
			if(IsURL)
			{
				Uri uriResult;
				bool result = Uri.TryCreate(Address, UriKind.Absolute, out uriResult)
					&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
				if (result)
				{
					_url = Address;
					_address = Address;
					medType = MediaType.Web;
					return medType;
				}
				else
					return MediaType.Empty;
			}
			if(Path.GetExtension(Address) == ".png" || Path.GetExtension(Address) == ".jpg" || Path.GetExtension(Address) == ".jpeg" || Path.GetExtension(Address) == ".bmp")
			{
			if(CheckImage(Address))
				medType = MediaType.Image;
				this._address = Address;
			}
			if (Path.GetExtension(Address) == ".mp4" || Path.GetExtension(Address) == ".avi" || Path.GetExtension(Address) == ".mov" || Path.GetExtension(Address) == ".asf" || Path.GetExtension(Address) == ".wmv")
			{
				CheckVideo(Address);
				this._address = Address;
				medType = MediaType.Video;
			}
			return medType;
		}

		bool CheckVideo(string add)
		{
			MemoryStream thumby = new MemoryStream();
			try
			{
				var player = new WindowsMediaPlayer();
				var clip = player.newMedia(Address);
				Time = (int)TimeSpan.FromSeconds(clip.duration).TotalMilliseconds;

				var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
				ffMpeg.GetVideoThumbnail(add, thumby, Time / 2000);
				Bitmap b = new Bitmap(thumby);
				_image = BitmapManager.DrawOn(b, _image.Size, _bgColor);
				
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		bool CheckImage(string add)
		{
			try
			{
				Image = new Bitmap(add);
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
            if(VerifyElementbyAddress(URL, true) != MediaType.Empty)
			{
				_time = Time;
			}
        }

        /// <summary>
        /// Rendering Image and Empty Media Tasks and update Image variable.
        /// </summary>
        
		public void RenderImage()
        {
            if (medType == MediaType.Image)
                RunnerUtils.MediaPictureRenderer(BGColor, Image, UseTransparency, TransColor, false, ref _image);
            
			if (medType == MediaType.Empty)
                Graphics.FromImage(Image).Clear(BGColor);
        }

	}
	public enum MediaType { Empty, Image, Video , Web }
}
