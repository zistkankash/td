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
		private List<PictureBox> thumbImages;
		private List<MetroTextBox> thumbTexts;
		private Label textDefiner;
		
		int horizontalMargin = 3, verticalMargin = 3;
		int textboxWidth = 15, spaceInTextLabel = 4;
		int itemHeight, pictureHeight, pictureWidth , textboxHeight;
		public int selectedThumb = 0;
		
		public Color bgColor = Color.White;
		public int MinSize = 30;

		private void ThumbnailList_MouseClick(object sender, MouseEventArgs e)
		{
			Select();
		}

		bool showTips = true;

		public ThumbnailList(bool ShowTextbox, bool ShowTips, string LabelText)
		{
			InitializeComponent();
			if (ShowTextbox)
			{
				textDefiner = new Label();
				textDefiner.Text = LabelText;
				textDefiner.Size = GetTextSize(textDefiner);
				thumbTexts = new List<MetroTextBox>();
				thumbTexts.Add(NewTextbox());
				MinSize = textDefiner.Size.Width + spaceInTextLabel + textboxWidth;
			}
			tltlpHelp.Active = ShowTips;
					
			thumbImages = new List<PictureBox>();
			thumbImages.Add(NewPicturebox());
		}
		
		public void DrawThumbs(string lblTxt)
		{
			#region initialize params
			textboxHeight = thumbTexts[0].Height;
			pictureWidth = this.Width + 2 * horizontalMargin;
			pictureHeight = (int)(0.618 * pictureWidth);

			if (thumbTexts != null)
				itemHeight = 3 * verticalMargin + textboxHeight + pictureHeight;
			else
				itemHeight = 2 * verticalMargin + pictureHeight;
			#endregion

			#region draw thumb images and texts
			for (int thCount = 0; thCount < thumbImages.Count; thCount++)
			{
				thumbImages[thCount].Location = new Point(horizontalMargin, itemHeight * thCount + verticalMargin);
				if (thumbTexts != null)
				{
					textDefiner.Location = new Point(horizontalMargin, itemHeight * thCount + verticalMargin + pictureHeight);
					thumbTexts[thCount].Location = new Point(horizontalMargin + textDefiner.Size.Width + 7, itemHeight * thCount + verticalMargin + pictureHeight);
				}
			}
			#endregion

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

		private PictureBox NewPicturebox()
		{
			PictureBox newPb = new PictureBox();
			newPb.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
			
			newPb.Image = BitmapData.PutText("Double Click To Add Image", bgColor, Brushes.Black, newPb.Size, 10);
			return newPb;
		}

		private MetroTextBox NewTextbox()
		{
			MetroTextBox mtTextbox = new MetroTextBox();
			mtTextbox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
			mtTextbox.Width = 15;
			return mtTextbox;
		}
	}
}
