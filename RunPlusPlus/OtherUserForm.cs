using System;
using System.Security;
using System.Windows.Forms;

namespace RunPlusPlus
{
	public partial class OtherUserForm : Form
	{
		public OtherUserForm()
		{
			InitializeComponent();
		}

		private void buttonDone_Click(object sender, EventArgs e)
		{
			Form1.Username = textBoxUser.Text;
			var temp = new SecureString();
			foreach (var character in textBoxPassword.Text)
			{
				temp.AppendChar(character);
			}
			Form1.Password = temp;
			textBoxPassword.Text = "";
			GC.Collect();
			GC.WaitForPendingFinalizers(); // Does this purge the entered string???
			Close();
		}

		private void keyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonDone_Click(new object(), new EventArgs());
			}
		}
	}
}