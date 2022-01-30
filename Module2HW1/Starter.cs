using System;
using System.Runtime;
using System.IO;
using System.Text;

namespace Module2HW1
{
	public static class Starter
	{
		private const int Counter = 100;
		public static void Run()
		{
			Logger logger = Logger.getInstance();
			Random random = new Random();
			int number;
			Result result;
			for (int i = 0; i < Counter; i++)
			{
                Console.WriteLine($"Current iteretion is {i}");
				number = random.Next(1, 4);
				result = default;
				switch (number)
				{
					case 1:
						{
							result = Actions.StartMethod();
							break;
						}
					case 2:
						{
							result = Actions.SkipMethod();
							break;
						}
					case 3:
						{
							result = Actions.BrokeMethod();
							break;
						}
				}
				if (!result.Status)
				{
					logger.AddLog(new Log(DateTime.Now, LogType.Error, $"Action failed by a reason: {result.Message}"));
					break;
				}
			}
			logger.printToConsole();
			logger.printToFile();
			Console.ReadKey();
		}
	}
}
