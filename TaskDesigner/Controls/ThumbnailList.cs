using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using Basics;

namespace Controls
{
	public partial class ThumbnailList : UserControl
	{
		List<Thumbnail> thumbs;
		Label labelDefiner;
		Operat _operat;
		int _itemHorzMarg = 1, _itemVertMarg = 1;
		int _picHorizontalMargin = 3, _picVerticalMargin = 3;
		int textboxWidth = 15, textboxMinWidth = 3,spaceInTextLabel = 4;
		int itemHeight, itemWeigth, pictureHeight, pictureWidth , textboxHeight;
		int _selectedThumb = 0;
		int _minWidth = 30;
		bool showTips = true;
		bool hasText = true;

		public int ThumbMinWidth { get { return _minWidth; } set { _minWidth = Math.Max(labelDefiner.Size.Width + spaceInTextLabel + textboxMinWidth, value); } }

		public int SelectedThumb { get { return _selectedThumb; } set { _selectedThumb = value; } }

		public Image SlideBitmapSelected
		{
			get
			{
			
				return thumbs[_selectedThumb]._img.Image;
			}
		}
		
		public ThumbnailList(bool ShowTextbox, bool ShowTips, string LabelText,Operat op)
		{
			InitializeComponent();
			
			_operat = op;

			if (ShowTextbox)
			{
				hasText = true;
				labelDefiner = new Label();
				labelDefiner.Text = LabelText;
				labelDefiner.Size = GetTextSize(labelDefiner);
				_minWidth = labelDefiner.Size.Width + spaceInTextLabel + textboxWidth;
			}
			else
				hasText = false;
			
				tltlpHelp.Active = ShowTips;
					
		}
		
		public bool DrawThumbs(string lblTxt)
		{
			#region initialize params
			
			itemWeigth = Width - 2 * _itemHorzMarg;
			textboxHeight = thumbs[0]._text.Height;
			pictureWidth = this.Width - 2 * _picHorizontalMargin;
			pictureHeight = (int)(0.618 * pictureWidth);
			if (pictureWidth < 3)
				return false;
			if (hasText)
			{
				textboxWidth = pictureWidth - labelDefiner.Size.Width - spaceInTextLabel;
				if (textboxWidth < textboxMinWidth)
					return false;
				itemHeight = 3 * _picVerticalMargin + textboxHeight + pictureHeight;
			}
			else
				itemHeight = 2 * _picVerticalMargin + pictureHeight;
			
			#endregion

			#region erase old controls

			tblPnlThumb.Controls.Clear();

			#endregion

			#region draw thumb images and texts

			for (int thCount = 0; thCount < thumbs.Count; thCount++)
			{
				Panel pnlThumbs = new Panel();
				pnlThumbs.Location = new Point(1, thCount * itemHeight + 1);
				pnlThumbs.Size = new Size(itemWeigth, itemHeight);
				if (thCount == _selectedThumb)
					ControlPaint.DrawBorder(pnlThumbs.CreateGraphics(), pnlThumbs.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
				else
					ControlPaint.DrawBorder(pnlThumbs.CreateGraphics(), pnlThumbs.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
				thumbs[thCount].Location = new Point(_picHorizontalMargin, itemHeight * thCount + _picVerticalMargin);
				thumbs[thCount].Size = new Size(pictureWidth,pictureHeight);
				pnlThumbs.Controls.Add(thumbs[thCount]);
				if (hasText)
				{
					labelDefiner.Location = new Point(_picHorizontalMargin, itemHeight * thCount + _picVerticalMargin + pictureHeight);
					pnlThumbs.Controls.Add(labelDefiner);
					thumbs[thCount].Location = new Point(_picHorizontalMargin + labelDefiner.Size.Width + spaceInTextLabel, itemHeight * thCount + _picVerticalMargin + pictureHeight);
					thumbs[thCount].Size = new Size(textboxWidth,textboxHeight);
					pnlThumbs.Controls.Add(thumbs[thCount]);
				}
				tblPnlThumb.Controls.Add(pnlThumbs);
				//tblPnlThumb.row
			}
			#endregion
			return true;
		}

		private Size GetTextSize(Label l)
		{
			using (Graphics g = CreateGraphics())
			{
				SizeF size = g.MeasureString(l.Text, l.Font, 495);
				Size res = new Size();
				res.Height = (int)Math.Ceiling(size.Height);
				res.Width = (int)Math.Ceiling(size.Width);
				return res;
			}
		}

		private void ThumbnailList_MouseClick(object sender, MouseEventArgs e)
		{
			Select();
		}

	}
	 
	public class Thumbnail : UserControl
	{
		bool hasTxt = true;
		public PictureBox _img;
		public MetroTextBox _text;
		public Panel thumbItem;
		public Color bgColor;
		int id;
		Operat _opera;
		ThumbnailList parent;

		public Thumbnail(ThumbnailList pr, int ind, bool hasText, Color bg, Operat op)
		{
			id = ind;
			hasTxt = hasText;
			_img = NewPicturebox(null);
			bgColor = bg;
			parent = pr;
			if (hasText)
				_text = NewTextbox(null);
		}

		public Thumbnail(ThumbnailList pr, int ind, bool hasText, Color bg, Operat op,Bitmap im)
		{
			id = ind;
			hasTxt = hasText;
			_img = NewPicturebox(im);
			bgColor = bg;
			parent = pr;
			if (hasText)
				_text = NewTextbox(null);
		}

		public Thumbnail(ThumbnailList pr, int ind, bool hasText, Color bg, Operat op, Bitmap im, string txt)
		{
			id = ind;
			hasTxt = hasText;
			_img = NewPicturebox(im);
			bgColor = bg;
			parent = pr;
			if (hasText)
				_text = NewTextbox(null);
		}

		private PictureBox NewPicturebox(Bitmap im)
		{
			PictureBox newPb = new PictureBox();
			newPb.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
			if (im == null)
				newPb.Image = BitmapManager.TextBitmap("", bgColor, Brushes.Black, newPb.Size, 10);
			else
				newPb.Image = im;
			newPb.Click += new EventHandler(pb_Click);
			newPb.DoubleClick += new EventHandler(pb_DoubleClick);
			newPb.Name = id.ToString();
			return newPb;
		}

		private MetroTextBox NewTextbox(string txt)
		{
			MetroTextBox mtTextbox = new MetroTextBox();
			mtTextbox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
			mtTextbox.Width = 15;
			if (txt == null)
				mtTextbox.Text = "10000";
			else
				mtTextbox.Text = txt;
			return mtTextbox;
		}

		private void pb_DoubleClick(object sender, EventArgs e)
		{
			PictureBox pbTemp = (PictureBox)sender;
			pb_Click(sender, e);
			if (_opera == Operat.Media)
			{
				OpenFileDialog file = new OpenFileDialog();
				file.Filter = "Media Files |*.png;*.jpg;";
				if (file.ShowDialog() == DialogResult.OK)
				{
					pbTemp.Image = BitmapManager.DrawOn(new Bitmap(file.FileName), pbTemp.Size, bgColor);

				}
			}
		}
		
		private void pb_Click(object sender, EventArgs e)
		{
			PictureBox pbTemp = (PictureBox)sender;
			parent.SelectedThumb = int.Parse(pbTemp.Name);
		}
	}
}
