using System;
using log4net;

namespace Crowe
{
	class MainClass
	{
		private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static void Main(string[] args)
		{
			Logger.Info("Hello World");
			Console.ReadLine();
		}
	}
}
