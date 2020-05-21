using System.Diagnostics;
using System.IO;

namespace RunPlusPlus
{
	public static class ProcessWorker
	{
		public static void RunProcess(string processPath)
		{
			Process.Start(processPath);
		}

		public static bool ValidateResource(string resourcePath)
			=> File.Exists(resourcePath) || Directory.Exists(resourcePath);
	}
}