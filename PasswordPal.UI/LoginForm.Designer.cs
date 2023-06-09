﻿namespace PasswordPal.UI
{
	partial class LoginForm
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
			passwordTextBox = new TextBox();
			usernameLabel = new Label();
			passwordLabel = new Label();
			LoginBtn = new Button();
			passwordPalLabel = new Label();
			SignUpBtn = new Button();
			SuspendLayout();
			// 
			// usernameTextBox
			// 
			usernameTextBox.Location = new Point(257, 167);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.Size = new Size(327, 23);
			usernameTextBox.TabIndex = 0;
			// 
			// passwordTextBox
			// 
			passwordTextBox.Location = new Point(257, 206);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(327, 23);
			passwordTextBox.TabIndex = 1;
			// 
			// usernameLabel
			// 
			usernameLabel.AutoSize = true;
			usernameLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			usernameLabel.Location = new Point(140, 167);
			usernameLabel.Name = "usernameLabel";
			usernameLabel.Size = new Size(98, 25);
			usernameLabel.TabIndex = 2;
			usernameLabel.Text = "Username";
			// 
			// passwordLabel
			// 
			passwordLabel.AutoSize = true;
			passwordLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			passwordLabel.Location = new Point(140, 206);
			passwordLabel.Name = "passwordLabel";
			passwordLabel.Size = new Size(91, 25);
			passwordLabel.TabIndex = 3;
			passwordLabel.Text = "Password";
			// 
			// LoginBtn
			// 
			LoginBtn.Location = new Point(257, 244);
			LoginBtn.Name = "LoginBtn";
			LoginBtn.Size = new Size(164, 46);
			LoginBtn.TabIndex = 4;
			LoginBtn.Text = "Login";
			LoginBtn.UseVisualStyleBackColor = true;
			LoginBtn.Click += LoginBtn_Click;
			// 
			// passwordPalLabel
			// 
			passwordPalLabel.AutoSize = true;
			passwordPalLabel.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
			passwordPalLabel.Location = new Point(313, 37);
			passwordPalLabel.Name = "passwordPalLabel";
			passwordPalLabel.Size = new Size(180, 40);
			passwordPalLabel.TabIndex = 5;
			passwordPalLabel.Text = "PasswordPal";
			// 
			// SignUpBtn
			// 
			SignUpBtn.Location = new Point(427, 244);
			SignUpBtn.Name = "SignUpBtn";
			SignUpBtn.Size = new Size(157, 47);
			SignUpBtn.TabIndex = 6;
			SignUpBtn.Text = "Sign Up";
			SignUpBtn.UseVisualStyleBackColor = true;
			SignUpBtn.Click += SignUpBtn_Click;
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(SignUpBtn);
			Controls.Add(passwordPalLabel);
			Controls.Add(LoginBtn);
			Controls.Add(passwordLabel);
			Controls.Add(usernameLabel);
			Controls.Add(passwordTextBox);
			Controls.Add(usernameTextBox);
			Name = "LoginForm";
			Text = "LoginForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox usernameTextBox;
		private TextBox passwordTextBox;
		private Label usernameLabel;
		private Label passwordLabel;
		private Button LoginBtn;
		private Label passwordPalLabel;
		private Button SignUpBtn;
	}
}