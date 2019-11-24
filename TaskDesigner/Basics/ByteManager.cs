using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Basics
{
	public static class ByteManager
	{
		public static byte[] ReadBinFile(string fileAddress)
		{
			try
			{
				using (FileStream fsSource = new FileStream(fileAddress,
								FileMode.Open, FileAccess.Read))
				{

					// Read the source file into a byte array.
					byte[] bytes = new byte[fsSource.Length];
					int numBytesToRead = (int)fsSource.Length;
					int numBytesRead = 0;
					while (numBytesToRead > 0)
					{
						// Read may return anything from 0 to numBytesToRead.
						int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

						// Break when the end of the file is reached.
						if (n == 0)
							break;

						numBytesRead += n;
						numBytesToRead -= n;
					}
					numBytesToRead = bytes.Length;
					return bytes;
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static byte[] Compress(byte[] data)
		{
			MemoryStream output = new MemoryStream();
			using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
			{
				dstream.Write(data, 0, data.Length);
			}
			return output.ToArray();
		}

		public static byte[] Decompress(byte[] data)
		{
			MemoryStream input = new MemoryStream(data);
			MemoryStream output = new MemoryStream();
			using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
			{
				dstream.CopyTo(output);
			}
			return output.ToArray();
		}
	}
}
