using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basics
{
	public static class BasConfigs
	{
		public static int _monitor_resolution_x = 1440;
		public static int _monitor_resolution_y = 900;
		public static TaskServer server;

		public static bool GetConfigs()
		{
			Screen[] screen = Screen.AllScreens;
			if (screen.Length == 2)
			{
				_monitor_resolution_x = screen[1].Bounds.Width;
				_monitor_resolution_y = screen[1].Bounds.Height;
				
			}
			if (screen.Length == 1)
			{
				
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

	public enum TaskRunMod { recursive, reward }

	public struct RunConfig { public GroupingMod shapeGroupingMode; public TaskRunMod taskRunMode; public bool showArrow; public bool showGoalPrompt; public bool useCursor; public bool useSound; public bool nmsShowArrow; public bool nmsShowGoalPrompt; public bool useCursorNextFrm; public bool nmsUseSound; }

	enum Comnd { Close = 5, CalibStat = 2, SendGaz = 8, EndGaz = 9 , WatRest = 11 }
	
	public struct GazeTriple
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

		public GazeTriple(double[] a1, long t, double a2)
		{
			x = a1[0];
			y = a1[1];
			time = t;
			pupilSize = a2;
		}
	}

	public enum RunMod { running, stop }
}
