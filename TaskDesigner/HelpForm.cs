using System;
using System.Reflection;
using System.Windows.Forms;


namespace TaskDesigner
{
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			InitializeComponent();
		}

		private void HelpForm_Load(object sender, EventArgs e)
		{

			//richTextBox1.LoadFile("C:\\Users\\ZKT\\Desktop\\31-6-98.rtf");
			richEditControl1.LoadDocument("C:\\Users\\ZKT\\Desktop\\31-6-98.rtf");
		}

		private void richEditControl1_Click(object sender, EventArgs e)
		{

		}
		
		
	}
}
