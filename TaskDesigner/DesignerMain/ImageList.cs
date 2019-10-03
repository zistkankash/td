using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basics
{
	public partial class ImageList : UserControl
	{
		Panel pnl = new Panel();
		MetroFramework.Controls.MetroTile mTile = new MetroFramework.Controls.MetroTile();
		Label l = new Label();
		TextBox txt = new TextBox();
		public ImageList()
		{
			InitializeComponent();
			
		}
	}
}
