using System.Windows.Forms;

namespace RunPlusPlus
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxCommand = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.buttonAdminRun = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.buttonRun = new System.Windows.Forms.Button();
			this.buttonOtherUserRun = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(59, 54);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(77, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(351, 54);
			this.label1.TabIndex = 1;
			this.label1.Text = "Type the name of a program, folder, document, or Internet Resource, and Run++ wil" + "l open it for you";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Open:";
			// 
			// textBoxCommand
			// 
			this.textBoxCommand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxCommand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.textBoxCommand.Location = new System.Drawing.Point(64, 86);
			this.textBoxCommand.Name = "textBoxCommand";
			this.textBoxCommand.Size = new System.Drawing.Size(364, 20);
			this.textBoxCommand.TabIndex = 3;
			this.textBoxCommand.TextChanged += new System.EventHandler(this.textBoxCommand_TextChanged);
			this.textBoxCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCommand_KeyDown);
			this.textBoxCommand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxCommand_KeyUp);
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Location = new System.Drawing.Point(350, 141);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(78, 23);
			this.buttonBrowse.TabIndex = 4;
			this.buttonBrowse.Text = "Browse...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// buttonAdminRun
			// 
			this.buttonAdminRun.Location = new System.Drawing.Point(153, 141);
			this.buttonAdminRun.Name = "buttonAdminRun";
			this.buttonAdminRun.Size = new System.Drawing.Size(107, 23);
			this.buttonAdminRun.TabIndex = 4;
			this.buttonAdminRun.Text = "Run as admin";
			this.buttonAdminRun.UseVisualStyleBackColor = true;
			this.buttonAdminRun.Click += new System.EventHandler(this.buttonAdminRun_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.InitialDirectory = "Desktop";
			// 
			// buttonRun
			// 
			this.buttonRun.Location = new System.Drawing.Point(266, 141);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size(78, 23);
			this.buttonRun.TabIndex = 4;
			this.buttonRun.Text = "Run";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
			// 
			// buttonOtherUserRun
			// 
			this.buttonOtherUserRun.Location = new System.Drawing.Point(12, 141);
			this.buttonOtherUserRun.Name = "buttonOtherUserRun";
			this.buttonOtherUserRun.Size = new System.Drawing.Size(135, 23);
			this.buttonOtherUserRun.TabIndex = 4;
			this.buttonOtherUserRun.Text = "Run as another user";
			this.buttonOtherUserRun.UseVisualStyleBackColor = true;
			this.buttonOtherUserRun.Click += new System.EventHandler(this.buttonOtherUserRun_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 176);
			this.Controls.Add(this.buttonOtherUserRun);
			this.Controls.Add(this.buttonAdminRun);
			this.Controls.Add(this.buttonRun);
			this.Controls.Add(this.buttonBrowse);
			this.Controls.Add(this.textBoxCommand);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Run++";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Button buttonAdminRun;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonOtherUserRun;
		private System.Windows.Forms.Button buttonRun;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBoxCommand;

		#endregion
	}
}