using System;
using System.IO;


namespace Basics
{
	public static class FileName
	{

		/// <summary>
		/// If addZero set to false: select last string number in path and plus in one. 
		/// If addZero set to true: adds one zero in trail of path.
		/// File name extension set to csv.
		/// </summary>
		/// <param name="addZero"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string AddNumToCSVFileName(bool addZero, string path)
		{
			if (addZero)
			{
				string t = path.Substring(0, path.Length - 4);
				return String.Concat(t, "-0.csv");
			}
			string dir = Path.GetDirectoryName(path);
			string name = Path.GetFileNameWithoutExtension(path);
			string[] temp = name.Split('-');
			int tr = int.Parse(temp[1]);
			return dir + "\\" + temp[0] + "-" + (tr + 1).ToString() + ".csv";
		}

		public static string UpdateFileName(string path,string trail)
		{
			string dir = Path.GetDirectoryName(path);
			string ext = Path.GetExtension(path);
			string name = Path.GetFileNameWithoutExtension(path);
			name = name + "-" + trail + "." + ext;
			return name;
		}
	}
}
