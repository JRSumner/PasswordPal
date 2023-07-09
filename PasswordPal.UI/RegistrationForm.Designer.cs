namespace PasswordPal.UI
{
	partial class RegistrationForm
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
			usernameTextBox = new TextBox();
			emailTextBox = new TextBox();
			passwordTextBox = new TextBox();
			confirmPasswordTextBox = new TextBox();
			usernameLabel = new Label();
			emailLabel = new Label();
			passwordLabel = new Label();
			confirmPasswordLabel = new Label();
			SuspendLayout();
			// 
			// usernameTextBox
			// 
			usernameTextBox.Location = new Point(226, 76);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.Size = new Size(349, 23);
			usernameTextBox.TabIndex = 0;
			// 
			// emailTextBox
			// 
			emailTextBox.Location = new Point(226, 128);
			emailTextBox.Name = "emailTextBox";
			emailTextBox.Size = new Size(349, 23);
			emailTextBox.TabIndex = 1;
			// 
			// passwordTextBox
			// 
			passwordTextBox.Location = new Point(226, 187);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(349, 23);
			passwordTextBox.TabIndex = 2;
			// 
			// confirmPasswordTextBox
			// 
			confirmPasswordTextBox.Location = new Point(226, 251);
			confirmPasswordTextBox.Name = "confirmPasswordTextBox";
			confirmPasswordTextBox.Size = new Size(349, 23);
			confirmPasswordTextBox.TabIndex = 3;
			// 
			// usernameLabel
			// 
			usernameLabel.AutoSize = true;
			usernameLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			usernameLabel.Location = new Point(115, 76);
			usernameLabel.Name = "usernameLabel";
			usernameLabel.Size = new Size(98, 25);
			usernameLabel.TabIndex = 4;
			usernameLabel.Text = "Username";
			// 
			// emailLabel
			// 
			emailLabel.AutoSize = true;
			emailLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			emailLabel.Location = new Point(154, 128);
			emailLabel.Name = "emailLabel";
			emailLabel.Size = new Size(59, 25);
			emailLabel.TabIndex = 5;
			emailLabel.Text = "Email";
			// 
			// passwordLabel
			// 
			passwordLabel.AutoSize = true;
			passwordLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			passwordLabel.Location = new Point(122, 187);
			passwordLabel.Name = "passwordLabel";
			passwordLabel.Size = new Size(91, 25);
			passwordLabel.TabIndex = 6;
			passwordLabel.Text = "Password";
			// 
			// confirmPasswordLabel
			// 
			confirmPasswordLabel.AutoSize = true;
			confirmPasswordLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			confirmPasswordLabel.Location = new Point(54, 251);
			confirmPasswordLabel.Name = "confirmPasswordLabel";
			confirmPasswordLabel.Size = new Size(166, 25);
			confirmPasswordLabel.TabIndex = 7;
			confirmPasswordLabel.Text = "Confirm Password";
			// 
			// RegistrationForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(confirmPasswordLabel);
			Controls.Add(passwordLabel);
			Controls.Add(emailLabel);
			Controls.Add(usernameLabel);
			Controls.Add(confirmPasswordTextBox);
			Controls.Add(passwordTextBox);
			Controls.Add(emailTextBox);
			Controls.Add(usernameTextBox);
			Name = "RegistrationForm";
			Text = "RegistrationForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox usernameTextBox;
		private TextBox emailTextBox;
		private TextBox passwordTextBox;
		private TextBox confirmPasswordTextBox;
		private Label usernameLabel;
		private Label emailLabel;
		private Label passwordLabel;
		private Label confirmPasswordLabel;
	}
}