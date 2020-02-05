using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basics
{
	public class TaskClient
	{
		TaskType _type;
		PsycophysicTasks psycoPhysicsTask;
		MediaTask mediaTask;
		PsycologyTask psycoTask;
		bool _taskIsReady = false;
		string _tskAddress = null;
		
		public RunConfig SetRunConfig
		{
			set
			{
				if(_type == TaskType.lab)
				{
					psycoTask.runConf = value;
				}
				if(_type == TaskType.media)
				{
					mediaTask.runConf = value;
				}
			}
		}	

		public PsycophysicTasks PsycoPhysicsTask { get { return psycoPhysicsTask; } }

		public MediaTask MediaTask { get { return mediaTask; } }

		public PsycologyTask PsycoTask { get { return psycoTask; } }

		public bool IsReady { get { return _taskIsReady; } }

		public string Address { get { return _tskAddress; } }

		public TaskType Type { get { return _type; } }

		public void UnSave()
		{
			_tskAddress = null;
		}

		public TaskClient()
		{
			_tskAddress = null;

		}

		public TaskClient(TaskType tk)
		{
			_tskAddress = null;
			_taskIsReady = false;

			if (tk == TaskType.lab)
			{
				_type = TaskType.lab;

				psycoTask = new PsycologyTask();
				 

				return;
			}
			if (tk == TaskType.media)
			{
				_type = TaskType.media;
				mediaTask = new MediaTask();
				
				return;
			}
			if (tk == TaskType.cognitive)
			{
				_type = TaskType.cognitive;
				psycoPhysicsTask = new PsycophysicTasks(0);
				
				return;
			}
		}

		public void ClearTask()
		{

			if (_type == TaskType.cognitive)
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

		public bool LoadTask(bool oldTask)
		{
			if (oldTask || _tskAddress == null)
			{
				OpenFileDialog ofd = new OpenFileDialog();
				string TaskFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				ofd.InitialDirectory = TaskFolder;
				ofd.Title = "Pick a valid task file";
				ofd.CustomPlaces.Add(@"C:\");
				ofd.CustomPlaces.Add(@"C:\Program Files\");
				ofd.CustomPlaces.Add(@"C:\Documents\");
				ofd.Filter = "Task File (*.bin , *.txt)|*.bin;*.txt;";
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
					if (lines[0] != "TaskLabMedia" && lines[0] != "PsycoTaskLab" && lines[0] != "Number Of Levels")
					{

						return false;
					}
					else
					{
						_taskIsReady = false;
                      						
						if (lines[0] == "TaskLabMedia")      // تسک های تصویری
						{
							mediaTask = new MediaTask();
							mediaTask.OperationalImageSize = new Size(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
							if (mediaTask.LoadFromText(lines))
								_taskIsReady = true;
							_type = TaskType.media;
							return true;
						}

						else if (lines[0] == "PsycoTaskLab")     // تسک های روانشناختی
						{
                            psycoTask = new PsycologyTask();
                            psycoTask.OperationalSize = new Size(BasConfigs._monitor_resolution_x, BasConfigs._monitor_resolution_y);
                            psycoTask.Address = _tskAddress;
                            if (psycoTask.Load(false))
                                _taskIsReady = true;
                            else
                                return false;
							_type = TaskType.lab;
                            return true;
						}       // انتهای تسک های روانشناختی

						#region cognitive tasks

						else if (lines[0] == "Number Of Levels")
						{
							psycoPhysicsTask = new PsycophysicTasks(0);
							
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

					if (tsktyp == (short)TaskType.media)
					{
						_type = TaskType.media;
						mediaTask = new MediaTask();
						if (mediaTask.LoadFromBin(tskFile))
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

		public bool GetFrameImage(int SelSlide, ref Bitmap BIn)
		{
			if (Type == TaskType.media)
			{
				return mediaTask.GetOperationFrame(SelSlide, ref BIn);
			}
            if(Type == TaskType.lab)
            {
                BIn = psycoTask.RenderTask();
                return true;
            }
			return false;
		}

		public bool SaveTask()
		{
			switch (_type)
			{
				case TaskType.lab:
					{
						return psycoTask.Save();

					}
				case TaskType.media:
					{
						return mediaTask.Save();
					}
				case TaskType.cognitive:
					{
						return false;
					}

			}
			return false;

		}

	}
}
