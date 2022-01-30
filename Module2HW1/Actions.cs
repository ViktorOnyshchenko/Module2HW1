using System;
using System.Runtime;
using System.IO;
using System.Text;

namespace Module2HW1
{
	public static class Actions
	{
		private static Logger logger = Logger.getInstance();

		public static Result StartMethod()
		{
			logger.AddLog(new Log(DateTime.Now, LogType.Info, $"Start method: {nameof(StartMethod)}"));
			return new Result(true, "Start method completed.");
		}

		public static Result SkipMethod()
		{
			logger.AddLog(new Log(DateTime.Now, LogType.Warning, $"Skipped logic in method: {nameof(SkipMethod)}"));
			return new Result(true, "Skipped logic in method");
		}

		public static Result BrokeMethod()
		{
			logger.AddLog(new Log(DateTime.Now, LogType.Error, $"Broke method: {nameof(BrokeMethod)}"));
			return new Result(false, "I broke a logic");
		}
	}
}
