using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskLab;
using Emgu.CV.Structure;
using Emgu.CV;
using Psychophysics;


namespace Basics
{
	public class TaskData
	{
		protected TaskType _type;
		protected bool _taskIsReady = false;
		protected string _tskAddress = null;
		protected RunConfig runConf;
		protected SaveMod tskSavMod;
		protected DateTime tskLastDateEdited;
		protected byte[] binTaskFile;
		protected string[] lines;
		protected int binReadIndex = 0;

		public bool IsReady { get { return _taskIsReady; } }

		public string Address { get { return _tskAddress; } }

		public TaskType Type { get { return _type; } }

		public SaveMod SavingMode { get { return tskSavMod; } set { tskSavMod = value; } }

		public void UnSave()
		{
			_tskAddress = null;
		}
				
		public TaskData(TaskType tk) 
		{
			_tskAddress = null;
		    _taskIsReady = false;

			if (tk == TaskType.lab)
			{
				_type = TaskType.lab;
				tskSavMod = SaveMod.txt;
				return;
			}
			if(tk == TaskType.media)
			{
				_type = TaskType.media;
				tskSavMod = SaveMod.bin;
				return;
			}
			if(tk == TaskType.cognitive)
			{
				_type = TaskType.cognitive;
				tskSavMod = SaveMod.txt;
				return;
			}
		}
		
		public TaskData()
		{
			_taskIsReady = false;
			_tskAddress = null;
			
		}

		protected bool Load(bool newTask)
		{
			try
			{
				if (newTask || _tskAddress == null)
				{
					OpenFileDialog ofd = new OpenFileDialog();
					string TaskFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					ofd.InitialDirectory = TaskFolder;
					ofd.Title = "Pick a valid task file...";
					ofd.CustomPlaces.Add(@"C:\");
					ofd.CustomPlaces.Add(@"C:\Program Files\");
					ofd.CustomPlaces.Add(@"C:\Documents\");
					ofd.Filter = "Task File (*.bin , *.txt)|*.bin;*.txt";
					if (ofd.ShowDialog() == DialogResult.OK)
						_tskAddress = ofd.FileName;
					else
						return false;
				}

				string suffix = Path.GetExtension(_tskAddress);
				#region txt formart loader
				if (suffix == ".txt")
				{
					lines = File.ReadAllLines(_tskAddress, Encoding.UTF8);
					if (lines[0] != "TaskLabMedia" && lines[0] != "TaskLab" && lines[0] != "Number Of Levels")
					{

						return false;
					}
					SavingMode = SaveMod.txt;
					return true;
					
				}
				#endregion
				#region bin format loader
				if (suffix == ".bin")
				{
					binTaskFile = ByteManager.ReadBinFile(_tskAddress);
					if (binTaskFile == null)
						return false;
					binReadIndex += sizeof(short);
					SavingMode = SaveMod.bin;
					return true;
				}
				#endregion
			}
			catch (Exception)
			{
				_tskAddress = null;
				return false;
			}
			return false;
		}
						
		
	}
}
