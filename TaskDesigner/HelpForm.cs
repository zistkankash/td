using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace TaskDesigner
{
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			InitializeComponent();
		}
		byte[] Key = new byte[16] {204, 101, 17, 48, 46, 89, 98, 19, 0, 11, 79, 233, 181, 191, 211, 95 };
		byte[] IV = new byte[16] { 46, 70, 40, 250, 153, 94, 203, 111, 0, 53, 0, 79, 173, 0, 169, 41 };
		string decrypted;
		byte[] line;
		private void HelpForm_Load(object sender, EventArgs e)
		{
			//using (AesCryptoServiceProvider myAes = new AesCryptoServiceProvider())
			{
				//Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();

				// Open a doc file.
				//Document document = application.Documents.Open(@"C:\Users\ZKT\Desktop\نمودارها و داده ها.docx");
				line = File.ReadAllBytes(@"C:\Users\ZKT\Desktop\نمودارها و داده ها.docx");
				//document.WritePassword = "ali";
				//document.Protect(WdProtectionType.wdAllowOnlyReading);
				File.WriteAllBytes("wt.docx", line);
				//byte[] encrypted = Basics.StringEncryptor.EncryptStringToBytes_Aes(line, Key, IV);

				//File.WriteAllBytes("w1", encrypted);


				byte[] nl = File.ReadAllBytes("w1");
				// Decrypt the bytes to a string.
				decrypted = Basics.StringEncryptor.DecryptStringFromBytes_Aes(nl, Key, IV);

				File.WriteAllText("wt.docx", decrypted);

			}
			//CabInfo cab = new CabInfo(@"C:\Cabinet2.cab");
			//cab.Pack(@"C:\folder", true, Microsoft.Deployment.Compression.CompressionLevel.Max, null);

			////Unpack a cab file into C:\Unpacked folder :
			//cab.Unpack(@"C:\Unpacked");

			richEditControl1.LoadDocument(@"C: \Users\ZKT\Desktop\نمودارها و داده ها.docx");
		}

		private void richEditControl1_Click(object sender, EventArgs e)
		{

		}
		
		
	}
}
