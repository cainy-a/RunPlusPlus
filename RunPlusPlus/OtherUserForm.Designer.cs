using System.ComponentModel;

namespace RunPlusPlus
{
	partial class OtherUserForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherUserForm));
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonDone = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			// 
			// textBoxUser
			// 
			this.textBoxUser.Location = new System.Drawing.Point(85, 6);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.Size = new System.Drawing.Size(195, 20);
			this.textBoxUser.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Password:";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(85, 32);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(195, 20);
			this.textBoxPassword.TabIndex = 1;
			// 
			// buttonDone
			// 
			this.buttonDone.Location = new System.Drawing.Point(202, 58);
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new System.Drawing.Size(78, 31);
			this.buttonDone.TabIndex = 2;
			this.buttonDone.Text = "OK";
			this.buttonDone.UseVisualStyleBackColor = true;
			this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
			// 
			// OtherUserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 101);
			this.Controls.Add(this.buttonDone);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxUser);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.Name = "OtherUserForm";
			this.Text = "Run as other user";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Button buttonDone;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxUser;

		#endregion
	}
}