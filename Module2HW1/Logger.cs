using System;
using System.Runtime;
using System.IO;
using System.Text;

namespace Module2HW1
{
	public class Logger
	{
		private const int Capacity = 20;
		private static Logger? logger;
		private readonly Log[] logs;
		private int length;

		public static Logger getInstance()
		{
			if (logger == null)
			{
				logger = new Logger();
			}
			return logger;
		}

		private Logger()
		{
			logs = new Log[Capacity];
			length = 0;
		}

		public void AddLog(Log log)
		{
			if (length >= Capacity)
			{
				throw new ArgumentOutOfRangeException("Run out of space for logs!");
			}
            Console.WriteLine(log.ToString());
			logs[length++] = log;
		}

		public void printToConsole()
		{
			foreach (var log in logs)
			{
				if (log == null)
				{
					break;
				}
				Console.WriteLine(log.ToString());
			}
		}

		public void printToFile()
		{
			using (FileStream fstream = new FileStream("log.txt", FileMode.Create))
			{
				StringBuilder textLogs = new StringBuilder();
				foreach (var log in logs)
				{
					if(log == null)
                    {
						break;
                    }
					textLogs.Append($"{log.ToString()}\n");
				}
				byte[] array = Encoding.Default.GetBytes(textLogs.ToString());
				fstream.Write(array, 0, array.Length);
				Console.WriteLine("Logs wrote in the file!");
			}
		}
	}
}
