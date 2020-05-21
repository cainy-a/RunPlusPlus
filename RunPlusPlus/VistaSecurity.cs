using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace RunPlusPlus
{
	public class VistaSecurity
	{
		[DllImport("user32")]
		public static extern UInt32 SendMessage
			(IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);

		internal const int BCM_FIRST = 0x1600; //Normal button
		internal const int BCM_SETSHIELD = (BCM_FIRST + 0x000C); //Elevated button
		
		// API Stuff up here ^^^
		
		static internal bool IsAdmin()
		{
			var id = WindowsIdentity.GetCurrent();
			var p = new WindowsPrincipal(id);
			return p.IsInRole(WindowsBuiltInRole.Administrator);
		} // Checks for Admin

		static internal void AddShieldToButton(Button b)
		{
			b.FlatStyle = FlatStyle.System;
			SendMessage(b.Handle, BCM_SETSHIELD, 0, 0xFFFFFFFF);
		} // Adds a shield to a button when called
		
		internal static void RestartElevated()
		{
			var startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = true;
			startInfo.WorkingDirectory = Environment.CurrentDirectory;
			startInfo.FileName = Application.ExecutablePath;
			startInfo.Verb = "runas";
			try
			{
				var p = Process.Start(startInfo);
			}
			catch(System.ComponentModel.Win32Exception)
			{
				return;
			}

			Application.Exit();
		} // Restarts myself but elevated
	}
}