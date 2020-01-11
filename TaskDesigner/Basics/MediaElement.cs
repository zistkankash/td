using System.Drawing;
using System.IO;
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
		Bitmap _image = null;
        string _address;
        string _url;
        int _time;
		Color _bgColor;
		bool _useTransparency;
		Color _transColor;
		MediaType _medType = MediaType.Empty;
		MediaTask _parentTask;

		public bool HaveMedia
		{
			get { return havMedia; }

		}

		public Color TransColor { get { return _transColor; } set { _transColor = value; RenderImage(); } }

		public bool UseTransparency { get { return _useTransparency; } set { _useTransparency = value; RenderImage(); } }

		public Color BGColor { get { return _bgColor; } set { _bgColor = value;  RenderImage(); } }

		public Bitmap Image { get { return _image; } set { _image = value; RenderImage(); havMedia = true; } }

		public MediaType MediaTaskType { get { return _medType; } }

		public string  Address { get { return _address; } }

		public string URL { get { return _url; } }

		public int Time { get { return _time; } set { _time = value; } }

		public MediaEelement(Color BackGroundColor, string Address, int Time, bool UseTransparency, Color TransColor, MediaTask Parent)
		{
			_parentTask = Parent;
			_bgColor = BackGroundColor;
			if (VerifyElementbyAddress(Address, false) != MediaType.Empty)
			{
				_time = Time;
				_useTransparency = UseTransparency ;
				_transColor = TransColor;
				RenderImage();
			}

		}

		/// <summary>
		/// This constructor used for creating video elements.
		/// </summary>
		/// <param name="add"> address of video element.</param>
		public MediaEelement(string Address, MediaTask Parent)
		{
			_parentTask = Parent;
			VerifyElementbyAddress(Address, false);

		}

		public MediaEelement(Color color, int FrameTime, MediaTask Parent)
		{
			_medType = MediaType.Empty;
            Image = new Bitmap(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
            using (Graphics g = Graphics.FromImage(Image))
                g.Clear(color);
			Time = FrameTime;
            BGColor = color;
			havMedia = false;
			_parentTask = Parent;
		}
		
		public MediaEelement(string URL, int Time, MediaTask Parent)
		{
			_parentTask = Parent;
			if (VerifyElementbyAddress(URL, true) != MediaType.Empty)
			{
				_time = Time;
			}
		}
		
		public MediaType VerifyElementbyAddress(string Address, bool IsURL)
		{
			if (Address == null)
			{
				havMedia = false;
				_medType = MediaType.Empty;
				
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
					_medType = MediaType.Web;
					havMedia = true;
					_image = BitmapManager.TextBitmap("Web Page Slide", Color.White, Brushes.Green, _parentTask._thumbSize, 40);
					
					return _medType;
				}
				else
					return MediaType.Empty;
			}
			if(Path.GetExtension(Address) == ".png" || Path.GetExtension(Address) == ".jpg" || Path.GetExtension(Address) == ".jpeg" || Path.GetExtension(Address) == ".bmp")
			{
			if(CheckImage(Address))
				_medType = MediaType.Image;
				this._address = Address;
			}
			if (Path.GetExtension(Address) == ".mp4" || Path.GetExtension(Address) == ".avi" || Path.GetExtension(Address) == ".mov" || Path.GetExtension(Address) == ".asf" || Path.GetExtension(Address) == ".wmv")
			{
				CheckVideo(Address);
				this._address = Address;
				_medType = MediaType.Video;
				havMedia = true;
			}
			return _medType;
		}

		bool CheckVideo(string add)
		{
			MemoryStream thumby = new MemoryStream();
			try
			{
				var player = new WindowsMediaPlayer();
				var clip = player.newMedia(add);
				_time = (int)TimeSpan.FromSeconds(clip.duration).TotalMilliseconds;
				var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
								
				ffMpeg.GetVideoThumbnail(add, thumby, _time / 2000);
				Bitmap b = new Bitmap(thumby);
				_image = BitmapManager.DrawOn(b, _parentTask.OperationalImageSize, _bgColor);
				
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
				Bitmap temp = new Bitmap(add); ;
				_image = BitmapManager.DrawOn(temp, _parentTask.OperationalImageSize, _bgColor);
				havMedia = true;
				_medType = MediaType.Image;
				return true;
			}
			catch(Exception)
			{
				throw new System.ArgumentException("Operational size cannot be zero", "Media Task Reader");
			}
		}
		       

        /// <summary>
        /// Rendering Image and Empty Media Tasks and update Image variable.
        /// </summary>
        
		public void RenderImage()
        {
            if (_medType == MediaType.Image)
                RunnerUtils.MediaPictureRenderer(BGColor, Image, UseTransparency, TransColor, false, ref _image);
            
			if (_medType == MediaType.Empty)
                Graphics.FromImage(Image).Clear(BGColor);
        }

	}
	public enum MediaType { Empty, Image, Video , Web }
}
