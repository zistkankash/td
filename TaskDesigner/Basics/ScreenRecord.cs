//using System;
//using System.Diagnostics;
//using System.Text;
////using WMEncoderLib;
//using System.Windows.Forms;

//namespace Basics
//{
//	class ScreenRecord
//	{
//		WMEncoderApp DesktopEncoderAppln;
//		IWMEncoder _desktopEncoder;
//		Timer recTimer = new Timer();

//		public ScreenRecord(string OutPath, int TimetoRecord)
//		{
//			DesktopEncoderAppln = new WMEncoderApp();
//			_desktopEncoder = DesktopEncoderAppln.Encoder;
//			IWMEncSourceGroupCollection SrcGroupCollection = _desktopEncoder.SourceGroupCollection;
//			IWMEncSourceGroup SrcGroup = SrcGroupCollection.Add("SG_1");
//			IWMEncVideoSource2 VideoSrc = (IWMEncVideoSource2)SrcGroup.AddSource(WMENC_SOURCE_TYPE.WMENC_VIDEO);
//			VideoSrc.SetInput("ScreenCapture1", "ScreenCap", "");
//			IWMEncProfileCollection ProfileCollection = _desktopEncoder.ProfileCollection;
//			ProfileCollection = _desktopEncoder.ProfileCollection;
//			int lLength = ProfileCollection.Count;
//			IWMEncFile inputFile = _desktopEncoder.File;
//			inputFile.LocalFileName = OutPath;
//			_desktopEncoder.PrepareToEncode(false);
//			recTimer.Tick += RecTimer_Tick;
			
//			_desktopEncoder.Start();

//			recTimer.Interval = TimetoRecord;
//			recTimer.Enabled = true;
			
//		}

//		private void RecTimer_Tick(object sender, EventArgs e)
//		{
//			_desktopEncoder.Stop();
//		}

//	}
//}