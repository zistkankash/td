using System;
using System.Windows.Forms;

namespace Basics
{
	public static class BasConfigs
	{
		public static int _monitor_resolution_x = 1440;
		public static int _monitor_resolution_y = 900;
		public static double userDistance = 0.5;
		public static double WidthM = 0.42, HeightM = 0.26;
		
		public static TaskServer server;
		public static int _triableMonitor;
		public static object graphicsLock = new object();
		public static bool SetScreenConfigs(int TriableMonitor)
		{
			_triableMonitor = TriableMonitor;
			Screen[] screen = Screen.AllScreens;
			if (screen.Length == 2)
			{
				_monitor_resolution_x = screen[TriableMonitor].Bounds.Width;
				_monitor_resolution_y = screen[TriableMonitor].Bounds.Height;
				
			}
			if (screen.Length == 1)
			{
				_triableMonitor = 0;
				_monitor_resolution_x = screen[0].Bounds.Width;
				_monitor_resolution_y = screen[0].Bounds.Height;
				MessageBox.Show("Second screen not detected. This cause some features not working well!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			return true;
		}

		public static ETStatus GetNetStatus()
		{
			if (server == null || server.serverDisposed)
			{
				return ETStatus.disconnected;
			}
			if (server.serverListening)
			{
				return ETStatus.listening;
			}

			return ETStatus.Connected;
		}
	}
    
	public enum ETStatus { Connected, listening, disconnected, ready, not_calibrated }

	public enum TaskRunMod { recursive, forward }

	public enum TaskType { media, lab, cognitive }

	public enum GroupingMod { byColor, byType, byRegion }

	public enum SaveMod { bin, txt }

	public struct RunConfig { public GroupingMod shapeGroupingMode; public TaskRunMod taskRunMode; public bool showArrow; public bool showGoalPrompt; public bool useCursor; public bool useSound; public bool nmsShowArrow; public bool nmsShowGoalPrompt; public bool useCursorNextFrm; public bool nmsUseSound; public short gazNumSmoth; public bool useParOut; public int ParAddress; public bool _useCOMPort; public string _COMAddress; }

	enum Comnd { Close = 5, CalibStat = 2, SendGaz = 8, EndGaz = 9 , WatRest = 11 }
	
	public class GazeTriple : EventArgs
	{
		public double x;
		public double y;
		public long time;
		public double pupilSize;

		public GazeTriple(double a1, double a2, long a3, double a4)
		{
			x = a1;
			y = a2;
			time = a3;
			pupilSize = a4;
		}

		public GazeTriple()
		{

		}

		public GazeTriple(double[] a1, long t, double a2)
		{
			x = a1[0];
			y = a1[1];
			time = t;
			pupilSize = a2;
		}
	}

	public enum RunMod { Running, Stop }

	public enum Operat { Media, GraphicsMap }

	public enum Shape { Circle, Rectangle}

	public enum ResultState { OK, Cancel, Error, Mismath}

	public class ResultForm
	{
		public ResultState Result;
		public TaskType Type;
		public SaveMod FileMode;
		public ResultForm(ResultState st, SaveMod fileMode)
		{
			Result = st;
			FileMode = fileMode;
		}
		public ResultForm(ResultState st, TaskType tp)
		{
			Result = st;
			Type = tp;
		}
	}

}
