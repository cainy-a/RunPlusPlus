using System.Diagnostics;
using System.IO;

namespace RunPlusPlus
{
	public static class ProcessWorker
	{
		public static void RunProcess(string processPath)
		{
			RunProcess(new ProcessStartInfo(processPath));
		}

		public static void RunProcess(ProcessStartInfo processStartInfo)
		{
			Process.Start(processStartInfo);
		}

		public static bool ValidateResource(string resourcePath)
			=> File.Exists(resourcePath) || Directory.Exists(resourcePath);
	}
}