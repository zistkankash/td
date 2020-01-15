using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace TaskDesigner
{
	public partial class HelpForm : Form
	{
		public string address;
		ChromiumWebBrowser _controlWebBrowser;
		
		void InitBrowser()
		{
			try
			{

				CefSettings seting = new CefSettings();
				if (!Cef.IsInitialized)
					Cef.Initialize(seting);

				_controlWebBrowser = new ChromiumWebBrowser(address);
				Controls.Add(_controlWebBrowser);

				_controlWebBrowser.LoadError += _controlWebBrowser_LoadError;
				_controlWebBrowser.ActivateBrowserOnCreation = true;
				_controlWebBrowser.Dock = DockStyle.Fill;
			}
			catch(Exception)
			{
				Close();
			}	
		}

		private void _controlWebBrowser_LoadError(object sender, LoadErrorEventArgs e)
		{
			
		}
		
		public HelpForm()
		{
			InitializeComponent();
			
		}
				
		public void Show(string helpPath)
		{
			address = helpPath;
			InitBrowser();
			Show();
		}
	}
}
