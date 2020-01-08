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
using MetroFramework;

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
				tskSavMod = SaveMod.txt;
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

		protected ResultForm Load(bool newTask, TaskType newTaskType)
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
						return new ResultForm(ResultState.Cancel, SaveMod.bin);
				}

				string suffix = Path.GetExtension(_tskAddress);
				#region txt formart loader
				if (suffix == ".txt")
				{
					lines = File.ReadAllLines(_tskAddress, Encoding.UTF8);
					if (lines[0] != "TaskLabMedia" && lines[0] != "TaskLab" && lines[0] != "Number Of Levels")
					{
						MessageBox.Show("Wrong task file selected","Task File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return new ResultForm(ResultState.Error, SaveMod.txt);
					}
					
					short type = 0;
					if (lines[0] == "TaskLabMedia")
					{
						type = (short)TaskType.media;
					}
					if (lines[0] == "TaskLab")
					{
						type = (short)TaskType.lab;
					}
					if (lines[0] == "Number Of Levels")
					{
						type = (short)TaskType.cognitive;
					}
					return TaskFormatCheck(newTaskType, type, SaveMod.txt);
				}
				#endregion
				#region bin format loader
				if (suffix == ".bin")
				{
					binTaskFile = ByteManager.ReadBinFile(_tskAddress);
					if (binTaskFile == null)
						return new ResultForm(ResultState.Error, SaveMod.bin);
					
					short type = BitConverter.ToInt16(binTaskFile, 0);
					return TaskFormatCheck(newTaskType, type, SaveMod.bin);

				}
				#endregion
			}
			catch (Exception)
			{
				_tskAddress = null;
				return new ResultForm(ResultState.Error, SaveMod.txt);
			}
			return new ResultForm(ResultState.Cancel, SaveMod.txt);
		}
		
		ResultForm TaskFormatCheck(TaskType newTaskType, short type, SaveMod mode)
		{
			if (newTaskType == TaskType.media && type == (short)TaskType.cognitive)
			{
				if (MetroMessageBox.Show((IWin32Window)this, "A psycophysic task selected! do you want to work on it?", "Open Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return new ResultForm(ResultState.Cancel, TaskType.cognitive);
				else
					return new ResultForm(ResultState.Mismath, TaskType.cognitive);
			}
			if (newTaskType == TaskType.media && type == (short)TaskType.lab)
			{
				if (MetroMessageBox.Show((IWin32Window)this, "A psycology task selected! do you want to work on it?", "Open Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return new ResultForm(ResultState.Cancel, TaskType.lab);
				else
					return new ResultForm(ResultState.Mismath, TaskType.lab);

			}
			if (newTaskType == TaskType.lab && type == (short)TaskType.cognitive)
			{
				if (MetroMessageBox.Show((IWin32Window)this, "A psycophysic task selected! do you want to work on it?", "Open Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return new ResultForm(ResultState.Cancel, TaskType.cognitive);
				else
					return new ResultForm(ResultState.Mismath, TaskType.cognitive);
			}
			if (newTaskType == TaskType.lab && type == (short)TaskType.media)
			{
				if (MetroMessageBox.Show((IWin32Window)this, "A media task selected! do you want to work on it?", "Open Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return new ResultForm(ResultState.Cancel, TaskType.media);
				else
					return new ResultForm(ResultState.Mismath, TaskType.media);
			}
			if (newTaskType == TaskType.cognitive && type == (short)TaskType.lab)
			{
				if (MetroMessageBox.Show((IWin32Window)this, "A psycophysic task selected! do you want to work on it?", "Open Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return new ResultForm(ResultState.Cancel, TaskType.lab);
				else
					return new ResultForm(ResultState.Mismath, TaskType.lab);
			}
			if (newTaskType == TaskType.cognitive && type == (short)TaskType.media)
			{
				if (MetroMessageBox.Show((IWin32Window)this, "A media task selected! do you want to work on it?", "Open Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return new ResultForm(ResultState.Cancel, TaskType.media);
				else
					return new ResultForm(ResultState.Mismath, TaskType.media);
			}
			return new ResultForm(ResultState.OK, mode);
		}			
		
	}
}
