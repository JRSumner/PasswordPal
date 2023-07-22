namespace PasswordPal.UI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			usernameTextBox = new TextBox();
			passwordTextBox = new TextBox();
			usernameLabel = new Label();
			passwordLabel = new Label();
			LoginBtn = new Button();
			PasswordPalLabel = new Label();
			SignUpBtn = new Button();
			HelpIcon = new PictureBox();
			InfoIcon = new PictureBox();
			GithubIcon = new PictureBox();
			LockIcon = new PictureBox();
			((System.ComponentModel.ISupportInitialize)HelpIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)InfoIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)GithubIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)LockIcon).BeginInit();
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
			usernameLabel.ForeColor = Color.FromArgb(64, 64, 64);
			usernameLabel.Location = new Point(153, 167);
			usernameLabel.Name = "usernameLabel";
			usernameLabel.Size = new Size(98, 25);
			usernameLabel.TabIndex = 2;
			usernameLabel.Text = "Username";
			// 
			// passwordLabel
			// 
			passwordLabel.AutoSize = true;
			passwordLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			passwordLabel.ForeColor = Color.FromArgb(64, 64, 64);
			passwordLabel.Location = new Point(160, 204);
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
			LoginBtn.Click += LoginBtnClick;
			// 
			// PasswordPalLabel
			// 
			PasswordPalLabel.AutoSize = true;
			PasswordPalLabel.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
			PasswordPalLabel.ForeColor = Color.FromArgb(64, 64, 64);
			PasswordPalLabel.Location = new Point(364, 110);
			PasswordPalLabel.Name = "PasswordPalLabel";
			PasswordPalLabel.Size = new Size(180, 40);
			PasswordPalLabel.TabIndex = 5;
			PasswordPalLabel.Text = "PasswordPal";
			// 
			// SignUpBtn
			// 
			SignUpBtn.Location = new Point(427, 244);
			SignUpBtn.Name = "SignUpBtn";
			SignUpBtn.Size = new Size(157, 47);
			SignUpBtn.TabIndex = 6;
			SignUpBtn.Text = "Sign Up";
			SignUpBtn.UseVisualStyleBackColor = true;
			SignUpBtn.Click += SignUpBtnClick;
			// 
			// HelpIcon
			// 
			HelpIcon.Image = (Image)resources.GetObject("HelpIcon.Image");
			HelpIcon.Location = new Point(648, 16);
			HelpIcon.Name = "HelpIcon";
			HelpIcon.Size = new Size(37, 41);
			HelpIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			HelpIcon.TabIndex = 7;
			HelpIcon.TabStop = false;
			HelpIcon.Click += HelpIconClick;
			// 
			// InfoIcon
			// 
			InfoIcon.Image = (Image)resources.GetObject("InfoIcon.Image");
			InfoIcon.Location = new Point(691, 12);
			InfoIcon.Name = "InfoIcon";
			InfoIcon.Size = new Size(49, 49);
			InfoIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			InfoIcon.TabIndex = 8;
			InfoIcon.TabStop = false;
			InfoIcon.Click += InfoIconClick;
			// 
			// GithubIcon
			// 
			GithubIcon.Image = (Image)resources.GetObject("GithubIcon.Image");
			GithubIcon.Location = new Point(737, 12);
			GithubIcon.Name = "GithubIcon";
			GithubIcon.Size = new Size(51, 49);
			GithubIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			GithubIcon.TabIndex = 9;
			GithubIcon.TabStop = false;
			GithubIcon.Click += GithubIconClick;
			// 
			// LockIcon
			// 
			LockIcon.Image = (Image)resources.GetObject("LockIcon.Image");
			LockIcon.Location = new Point(285, 82);
			LockIcon.Name = "LockIcon";
			LockIcon.Size = new Size(73, 68);
			LockIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			LockIcon.TabIndex = 10;
			LockIcon.TabStop = false;
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 450);
			Controls.Add(LockIcon);
			Controls.Add(GithubIcon);
			Controls.Add(InfoIcon);
			Controls.Add(HelpIcon);
			Controls.Add(SignUpBtn);
			Controls.Add(PasswordPalLabel);
			Controls.Add(LoginBtn);
			Controls.Add(passwordLabel);
			Controls.Add(usernameLabel);
			Controls.Add(passwordTextBox);
			Controls.Add(usernameTextBox);
			Name = "LoginForm";
			Text = "LoginForm";
			((System.ComponentModel.ISupportInitialize)HelpIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)InfoIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)GithubIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)LockIcon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox usernameTextBox;
		private TextBox passwordTextBox;
		private Label usernameLabel;
		private Label passwordLabel;
		private Button LoginBtn;
		private Label PasswordPalLabel;
		private Button SignUpBtn;
		private PictureBox HelpIcon;
		private PictureBox InfoIcon;
		private PictureBox GithubIcon;
		private PictureBox LockIcon;
	}
}