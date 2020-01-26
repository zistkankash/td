using System.Runtime.InteropServices;

namespace Basics
{
	public class PortAccess
	{
		[DllImport("inpout32.dll", EntryPoint = "Out32")]
		public static extern void Output(int adress, int value);
	}
}
