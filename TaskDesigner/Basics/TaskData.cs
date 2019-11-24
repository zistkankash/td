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
		TaskType _type;
		protected bool _taskIsReady = false;
		protected string _tskAddress = null;
		
		public RunConfig runConf;
		public SaveMod tskSavMod;
		public DateTime tskLastDateEdited;

		PsycoPhysicTask psycoPhysicsTask;
		MediaTask mediaTask;
		PsycologyTask psycoTask;

		public bool IsReady { get { return _taskIsReady; } }

		public string Address { get { return _tskAddress; } }

		public TaskType Type { get { return _type; } }

		public PsycoPhysicTask PsycoPhysicsTask { get { return psycoPhysicsTask; } }

		public MediaTask MediaTask { get { return mediaTask; } }

		public PsycologyTask PsycoTask { get { return psycoTask; } }

		public void UnSave()
		{
			_tskAddress = null;
		}
		
		public void ClearTask()
		{
			
			if(_type == TaskType.cognitive)
			{

			}
			if (_type == TaskType.lab)
			{
				psycoTask.Clear();
			}
			if (_type == TaskType.media)
			{
				mediaTask.Clear();
			}
			
		}
		
		public TaskData(TaskType tk) 
		{
			_tskAddress = null;
		    _taskIsReady = false;

			if (tk == TaskType.lab)
			{
				_type = TaskType.lab;
				psycoTask = new PsycologyTask();
				return;
			}
			if(tk == TaskType.media)
			{
				_type = TaskType.media;
				mediaTask = new MediaTask();
				return;
			}
			if(tk == TaskType.cognitive)
			{
				_type = TaskType.cognitive;
				psycoPhysicsTask = new PsycoPhysicTask();

				return;
			}
		}
		
		public TaskData()
		{
			_taskIsReady = false;
			_tskAddress = null;
		}

		public bool LoadTask(bool newTask)
		{
			if (newTask || _tskAddress == null)
			{
				OpenFileDialog ofd = new OpenFileDialog();
				string TaskFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				ofd.InitialDirectory = TaskFolder;
				ofd.Title = "Pick a valid task file...";
				ofd.CustomPlaces.Add(@"C:\");
				ofd.CustomPlaces.Add(@"C:\Program Files\");
				ofd.CustomPlaces.Add(@"K:\Documents\");
				//ofd.Filter = "Binary File (*.bin)|*.bin| Text File (*.txt) |*.txt";
				if (ofd.ShowDialog() == DialogResult.OK)
					_tskAddress = ofd.FileName;
				else
					return false;
			}

			try
			{
				string suffix = Path.GetExtension(_tskAddress);
				#region txt formart loader
				if (suffix == ".txt")
				{
					string[] lines = File.ReadAllLines(_tskAddress, Encoding.UTF8);
					if (lines[0] != "TaskLabPics" && lines[0] != "TaskLab" && lines[0] != "Number Of Levels")
					{
						
						return false;
					}
					else
					{
						_taskIsReady = false;

						if (lines[0] == "TaskLabPics")      // تسک های تصویری
						{
							if (mediaTask.Load(lines))
								_taskIsReady = true;
							_type = TaskType.media;
						}
						
						else if (lines[0] == "TaskLab")     // تسک های روانشناختی
						{
							if (psycoTask.Load(lines))
								_taskIsReady = true;
							_type = TaskType.lab;
							
						}       // انتهای تسک های روانشناختی
						
						#region cognitive tasks

						else if (lines[0] == "Number Of Levels")
						{
							if (psycoPhysicsTask.LoadTaskFromFile(false, _tskAddress))
							{
								_type = TaskType.cognitive;
								_taskIsReady = true;
							}
							return true;
						}
						#endregion
					}
				}
				#endregion
				#region bin format loader
				if (suffix == ".bin")
				{
					byte[] tskFile = ByteManager.ReadBinFile(_tskAddress);
					if (tskFile == null)
						return false;
					int readIndex = 0;
					short tsktyp = (short)BitConverter.ToInt16(tskFile, readIndex);
					readIndex += sizeof(short);
					
					if (tsktyp == (short) TaskType.media)
					{
						if(mediaTask.Load(tskFile,readIndex))
							_taskIsReady = true;
					}
										
					return true;
				}
				#endregion
			}
			catch (Exception ex)
			{
				MessageBox.Show("Load file error" + ex.Message);
				_tskAddress = null;
				return false;
			}
			return false;
		}
				
		public bool  SaveTask()
		{
			if (_type == TaskType.lab)
			{
				return psycoTask.Save();
			}
			else if (_type == TaskType.media)
			{
				return mediaTask.Save();
			}
			return false;
		}
				
		public Bitmap GetFrameImage(int selSlide, Size pbSize)
		{
			Bitmap b = new Bitmap(100,100);			
			if (Type == TaskType.media)
			{
				
			}
			//if(type == TaskType.cognitive)
			//{
			//return psycophysicsData.
			//}
			return b;
		}
	}
}
