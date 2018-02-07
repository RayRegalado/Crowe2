using System;
using System.IO;
using System.Text;
using log4net;
using log4net.Config;
using NUnit.Framework;

namespace CroweTests
{
	[TestFixture()]
	public class LoggerTests
	{
		// code for this test borrowed from: https://www.roelvanlisdonk.nl/2012/05/11/how-to-redirect-the-standard-console-output-to-assert-logmessages-written-by-log4net/
		[Test()]
		public void ConsoleTest()
		{
			// Save original console output writer.
			TextWriter originalConsole = Console.Out;

			// Configure log4net based on the App.config
			XmlConfigurator.Configure();

			var builder = new StringBuilder();

			using (var writer = new StringWriter(builder))
			{
				// Redirect all Console messages to the StringWriter.
				Console.SetOut(writer);

				// Log a debug message.
				ILog logger = LogManager.GetLogger("Unittest logger");
				logger.Info("Hello World");
			}

			// Get all messages written to the console.
			string consoleOutput = string.Empty;

			using (var reader = new StringReader(builder.ToString()))
			{
				consoleOutput = reader.ReadToEnd();
			}

			// Assert.
			string expected = "Hello World" + Environment.NewLine;

			Assert.AreEqual(expected, consoleOutput);

			// Redirect back to original console output.
			Console.SetOut(originalConsole);
		}
	}
}
