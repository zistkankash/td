using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Basics
{
	public class TaskServer
	{
		public static Socket ListenerSocket; //This is the socket that will listen to any incoming connections.
		public static short Port = 5050; // on this port we will listen and user can change it.
		public Socket GazeTracker; // This is the socket that reads and writes to ET address.
		byte[] comBuffer = new byte[sizeof(Int16)];
		short _comnd;
		byte[] parBuffer = null; 
		byte[] b1, b2, b3, b4;
		private Queue<GazeTriple> gazPnt = new Queue<GazeTriple>();
		private int paramBufferSize = 3 * sizeof(double) + sizeof(long);
		private int _calibStat;
		private NetSettingForm par;
		public bool _endGaze = true;
		public bool serverDisposed = true, serverListening = false;
		public event EventHandler<GazeTriple> OnGaze;

		public GazeTriple getGaze
		{
			get
			{
				if (_endGaze || gazPnt.Count == 0)
					return new GazeTriple((double)-1, (double)-1, -1, (double)-1);

				return gazPnt.Dequeue();
			}
		}

		/// <summary>
		/// Call IsCalibrated to detect calibration status.
		/// if returned 1 ET is calibrated,if returned 2 Et not connected, if returned 0 Et not calibrated.
		/// </summary>
		public ETStatus IsCalibrated
		{
			get
			{
				if (serverDisposed || GazeTracker == null && !GazeTracker.Connected)
				{
					return ETStatus.disconnected;
				}
				_calibStat = 2;
				
				//ReceivComnd();
				if (Send((short)Comnd.CalibStat))
				{

					while (_calibStat == 2)
					{
						continue;
					}
				}
				else
					return ETStatus.disconnected;
				if (_calibStat == 1)
					return ETStatus.ready;
				else
					return ETStatus.not_calibrated;
			}
		}
				
		public TaskServer(short port, NetSettingForm pr)
		{
			par = pr;
			Port = port;
			parBuffer = new byte[paramBufferSize];
			if (ListenerSocket == null)
				ListenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}
		
		public bool StartListening()
		{
			try
			{
				serverListening = true;
				ListenerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
				ListenerSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
				ListenerSocket.Listen(1);
				ListenerSocket.BeginAccept(AcceptCallback, ListenerSocket);
				serverDisposed = false;
				return true;
			}
			catch (Exception ex)
			{
				return false;
				
			}
		}
		
		public void AcceptCallback(IAsyncResult ar)
		{
			try
			{
				GazeTracker = ListenerSocket.EndAccept(ar);
				serverListening = false;		
				ReceivComnd();
				
			}
			catch (Exception)
			{
				//MessageBox.Show("Send Error");
				//Dispose();
			}
		}

		public bool ReceivComnd()
		{
			Array.Clear(comBuffer, 0, comBuffer.Length);
			try
			{
				GazeTracker.BeginReceive(comBuffer, 0, sizeof(Int16), SocketFlags.None, ReceiveCallback, null);
				
				return true;
			}
			catch
			{
				//MessageBox.Show("receive error");
				//Dispose();
				return false;
			}
		}
		
		private void ReceiveCallback(IAsyncResult AR)
		{
			try
			{
				// if bytes are less than 1 takes place when a client disconnect from the server.
				// So we run the Disconnect function on the current client
				if (!serverDisposed && GazeTracker.EndReceive(AR) > 1)
				{
					_comnd = Convert.ToInt16(comBuffer[0]);
					//Translate command code to declare and receive params.
					if (_comnd == (short)Comnd.Close)
					{
						Dispose();
						return;
					}
					

					if (_comnd == (short)Comnd.CalibStat)
					{
						GazeTracker.Receive(parBuffer, paramBufferSize, SocketFlags.None);
						SetCalibStat();
						ReceivComnd();
						
					}

					if (_comnd == (short)Comnd.SendGaz)
					{
						
						GazeTriple gazTemp = new GazeTriple();
						gazPnt.Clear();
											
						_endGaze = false;

						while (!_endGaze)
						{
							GazeTracker.Receive(parBuffer, paramBufferSize, SocketFlags.None);
							gazTemp.x = BitConverter.ToDouble(parBuffer, 0);
							gazTemp.y = BitConverter.ToDouble(parBuffer, sizeof(double));
							gazTemp.time = BitConverter.ToInt64(parBuffer, 2 * sizeof(double));
							gazTemp.pupilSize = BitConverter.ToDouble(parBuffer, 2 * sizeof(double) + sizeof(long));
							gazPnt.Enqueue(gazTemp);
							OnGaze?.Invoke(this, gazTemp);

							_comnd = GetComnd();
							if ( _comnd == (short)Comnd.EndGaz || _comnd == (short)Comnd.Close)
							{
								_endGaze = true;
								break;
							}
							if (_comnd == (short)Comnd.CalibStat)
							{
								GazeTracker.Receive(parBuffer, paramBufferSize, SocketFlags.None);
								SetCalibStat();
								_comnd = GetComnd();
							}
						}
						//clear buffer
						if (GazeTracker.Available > 0)
						{
							GazeTracker.Receive(parBuffer);
						}
						ReceivComnd();
						//GazeTracker.EndReceive(AR);
					}
					//if close command received run dispose methode.
					if (_comnd == (short)Comnd.Close)
						Dispose();
					//get new command after performing current command.
					
				}
				else
				{
					//MetroMessageBox.Show((IWin32Window)this, "ET Was Disconnected", "ET Connection", MessageBoxButtons.OK, MessageBoxIcon.Stop, 100);
					Dispose();
				}
				
			}
			catch(Exception)
			{
				//MessageBox.Show("Connection was interrupted in ET", "ET Connection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				//Dispose();
				//ReceivComnd();
			}
			
		}
		
		public static string GetLocalIP()
		{
			IPHostEntry myHost;
			myHost = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in myHost.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
					return ip.ToString();
			}
			return "127.0.0.1";
		}
		
		private Int16 GetComnd()
		{
			Array.Clear(comBuffer, 0, comBuffer.Length);
			GazeTracker.Receive(comBuffer, sizeof(Int16), SocketFlags.None);
			return Convert.ToInt16(comBuffer[0]);
		}
		
		private void SetCalibStat()
		{
			if (BitConverter.ToDouble(parBuffer, 0) == 1)
			{
				_calibStat = 1;
			}
			else
				_calibStat = 0;
		}
		
		/// <summary>
		/// Clear gaze buffer and send start gaze command to ET.
		/// </summary>
		/// <returns></returns>
		public bool StartGaze()
		{
			_endGaze = false;
			
			return (Send((short)Comnd.SendGaz));
		}

		public bool EndGaze()
		{
			_endGaze = true;
			return (Send((short)Comnd.EndGaz));
		}

		public void Dispose()
		{
			
			if (GazeTracker != null)
			{
				serverDisposed = true;
				GazeTracker.Close();
				
				ListenerSocket.Close();
				ListenerSocket = null;
				
			}
		}

		public bool Send(Int16 cmnd, double p1, double p2, long p3)
		{
			if (GazeTracker == null)
				return false;
			try
			{
				/* what hapends here:
					 1. Create a array of bytes
					 2. Add the command of the packet at the begining.
						So if this message arrives at the server we can easily read the command of the coming message.
					 3. Add the params bytes
				*/
				b1 = BitConverter.GetBytes(cmnd);
				b2 = BitConverter.GetBytes(p1);
				b3 = BitConverter.GetBytes(p2);
				b4 = BitConverter.GetBytes(p3);

				byte[] rv = new byte[b1.Length + b2.Length + b3.Length + b4.Length];
				System.Buffer.BlockCopy(b1, 0, rv, 0, b1.Length);
				System.Buffer.BlockCopy(b2, 0, rv, b1.Length, b2.Length);
				System.Buffer.BlockCopy(b3, 0, rv, b1.Length + b2.Length, b3.Length);
				System.Buffer.BlockCopy(b4, 0, rv, b1.Length + b2.Length + b3.Length, b4.Length);

				/* Send the message to the server we are currently connected to.
				Our package stucture is {command (int16), 3 double params }*/
				GazeTracker.Send(rv);


				return true;
			}
			catch (SocketException)
			{
				MessageBox.Show("TD Sending problem, command is " + cmnd.ToString() + ". Connection Terminated.");
				Dispose();
				return false;
			}
		}

		public bool Send(Int16 cmnd)
		{
			if (GazeTracker == null)
				return false;
			try
			{
				b1 = BitConverter.GetBytes(cmnd);
				//Send the message to the server we are currently connected to.
				GazeTracker.Send(b1);
				
				return true;
			}
			catch (SocketException)
			{
				MessageBox.Show("TD Sending problem, command is " + cmnd.ToString() + ". Connection Terminated.");
				Dispose();
				return false;
			}
		}	
	}
}
