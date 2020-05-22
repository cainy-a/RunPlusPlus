using System;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RunPlusPlus.ProcessWorker;

namespace RunPlusPlus
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			if (VistaSecurity.IsAdmin()) return;
			VistaSecurity.AddShieldToButton(buttonAdminRun);
		}

		private string _currentFile = "C:\\"; // Stores which file is going to be run.
		private bool _busy; // Makes sure that you can't spam the run button to open up too many copies of the same thing.
		
		private static readonly string CommonAppdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // Get the Appdata folder
		//var pathSettingFile = $"{commonAppdata}\\CainAtkinson\\RunPlusPlus\\LastPath.txt"; // FALLBACK INCASE BELOW DOES NOT WORK
		private static readonly string PathSettingFile = Path.Combine(CommonAppdata, "CainAtkinson\\RunPlusPlus\\LastPath.txt"); // Get the location of LastPath.
		private static readonly string RunOnStartFile = Path.Combine(CommonAppdata, "CainAtkinson\\RunPlusPlus\\RunStart.txt");

		private static bool _controlHeld;
		private static bool _shiftHeld;
		
		private static Form _otherUserForm = new OtherUserForm();
		public static string Username;
		public static SecureString Password;

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			if (Directory.Exists(_currentFile))
			{
				openFileDialog1.InitialDirectory = _currentFile;
			} // if a directory, open it
			else if (File.Exists(_currentFile))
			{
				openFileDialog1.InitialDirectory = Directory.GetParent(_currentFile).FullName;
			} // if a file, open it's parent
			
			openFileDialog1.ShowDialog();
			_currentFile = openFileDialog1.FileName;
			textBoxCommand.Text = _currentFile; // This is just dialog stuff
		}

		private void buttonAdminRun_Click(object sender, EventArgs e)
		{
			if (_busy) return;
			if (!ValidateResource(_currentFile))
			{
				MessageBox.Show(
					"It appears that the selected item doesn't actually exist... Try pick something else?",
					"Non-Existent item",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			_busy = true;
			SaveLastPath();
			SaveStartRun(true);
			VistaSecurity.RestartElevated();
			Environment.Exit(0);
		}

		private async void buttonOtherUserRun_Click(object sender, EventArgs e)
		{
			_otherUserForm.ShowDialog();
			if (_busy) return;
			if (!ValidateResource(_currentFile))
			{
				MessageBox.Show(
					"It appears that the selected item doesn't actually exist... Try pick something else?",
					"Non-Existent item",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			_busy = true;

		//	try
		//	{
				await Task.Factory.StartNew(() =>
					{
						var info = new ProcessStartInfo { UserName = Username, Password = Password, UseShellExecute = false };
						if (!ValidateResource(_currentFile))
							return;
						info.FileName = _currentFile;
						RunProcess(info);
					});
		/*	} // Move this function call to another thread and call RunProcess
			catch
			{
				// ignored
			} */

			SaveLastPath();
			Environment.Exit(0);
		}

		private async void buttonRun_Click(object sender, EventArgs e)
		{
			if (_busy) return;
			if (!ValidateResource(_currentFile))
			{
				MessageBox.Show(
					"It appears that the selected item doesn't actually exist... Try pick something else?",
					"Non-Existent item",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			_busy = true;

			try
			{
				await Task.Factory.StartNew(
					() => RunProcess(_currentFile)); // Move this function call to another thread and call RunProcess
			}
			catch
			{
				// ignored
			}

			SaveLastPath();
			Environment.Exit(0);
		}

		private void textBoxCommand_TextChanged(object sender, EventArgs e)
			=> _currentFile = textBoxCommand.Text;

		private void textBoxCommand_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.ControlKey:
					_controlHeld = true;
					e.Handled = true;
					break; // set _controlHeld to true when ctrl is pressed
				case Keys.ShiftKey:
					_shiftHeld = true;
					e.Handled = true;
					break;// set _shiftHeld to true when shift is pressed
				case Keys.Enter:
					if (_controlHeld && _shiftHeld) 
						buttonAdminRun_Click(new object(), new EventArgs()); // Make Ctrl+Shift+Enter Run as Admin, like in standard Run dialog
					else buttonRun_Click(new object(), new EventArgs());
					e.Handled = true;
					break; // Catch enters in the textbox and press the Run button.
			}
		}

		private void textBoxCommand_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.ControlKey:
					_controlHeld = false;
					e.Handled = true;
					break; // set _controlHeld to false when ctrl is released
				case Keys.ShiftKey:
					_shiftHeld = false;
					e.Handled = true;
					break; // set _shiftHeld to false when shift is released
			}
		}
		private async void Form1_Load(object sender, EventArgs e)
		{
			ReadLastPath();
			if (ReadStartRun())
			{
				await Task.Factory.StartNew(() => RunProcess(_currentFile));
				SaveStartRun(false);
				Environment.Exit(0);
			}
			textBoxCommand.Text = _currentFile; // Makes the textbox initialise with the current file.
		}

		/// <summary>
		/// if last path file exists then read it into CurrentFile
		/// </summary>
		private void ReadLastPath()
		{
			if (File.Exists(PathSettingFile))
			{
				using StreamReader sr = new StreamReader(PathSettingFile);
				{
					_currentFile = sr.ReadToEnd();
					sr.Dispose();
				}
			}
		}
		
		/// <summary>
		/// Checks to see if we should run LastPath on startup
		/// </summary>
		/// <returns>whether or not to run LastPath</returns>
		private bool ReadStartRun()
		{
			if (File.Exists(RunOnStartFile))
			{
				string toReturn;
				using StreamReader sr = new StreamReader(RunOnStartFile);
				{
					toReturn = sr.ReadToEnd();
					sr.Dispose();
				}
				if (toReturn == "1") return true;
			}
			return false;
		}
		
		/// <summary>
		/// Saves whether or not to run last path on startup
		/// </summary>
		/// <param name="value">What value to save</param>
		private void SaveStartRun(bool value)
		{
			var toWrite = value ? "1" : "0";

			if (File.Exists(RunOnStartFile))
			{
				File.Delete(RunOnStartFile); // Remove old file
			}

			Directory.CreateDirectory(Directory.GetParent(RunOnStartFile).FullName);
			var sw = File.CreateText(RunOnStartFile); // Create a new file, and opens a StreamWriter in it
			sw.Write(toWrite); // Write into the file.
			sw.Flush(); // Makes sure that it actually wrote it
			sw.Dispose();
		}

		/// <summary>
		/// Write the contents of CurrentFile into last path file
		/// </summary>
		private void SaveLastPath()
		{
			if (File.Exists(PathSettingFile))
			{
				File.Delete(PathSettingFile); // Remove old file
			}

			Directory.CreateDirectory(Directory.GetParent(PathSettingFile).FullName);
			var sw = File.CreateText(PathSettingFile); // Create a new file, and opens a StreamWriter in it
			sw.Write(_currentFile); // Write into the file.
			sw.Flush(); // Makes sure that it actually wrote it
			sw.Dispose();
		}
	}
}