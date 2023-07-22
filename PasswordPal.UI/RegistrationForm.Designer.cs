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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
			usernameTextBox = new TextBox();
			emailTextBox = new TextBox();
			passwordTextBox = new TextBox();
			confirmPasswordTextBox = new TextBox();
			usernameLabel = new Label();
			emailLabel = new Label();
			passwordLabel = new Label();
			confirmPasswordLabel = new Label();
			RegisterBtn = new Button();
			PasswordPalLabel = new Label();
			LockIcon = new PictureBox();
			GithubIcon = new PictureBox();
			InfoIcon = new PictureBox();
			HelpIcon = new PictureBox();
			BackIcon = new PictureBox();
			((System.ComponentModel.ISupportInitialize)LockIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)GithubIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)InfoIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)HelpIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)BackIcon).BeginInit();
			SuspendLayout();
			// 
			// usernameTextBox
			// 
			usernameTextBox.Location = new Point(285, 161);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.Size = new Size(251, 23);
			usernameTextBox.TabIndex = 0;
			// 
			// emailTextBox
			// 
			emailTextBox.Location = new Point(285, 199);
			emailTextBox.Name = "emailTextBox";
			emailTextBox.Size = new Size(251, 23);
			emailTextBox.TabIndex = 1;
			// 
			// passwordTextBox
			// 
			passwordTextBox.Location = new Point(285, 240);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.Size = new Size(251, 23);
			passwordTextBox.TabIndex = 2;
			// 
			// confirmPasswordTextBox
			// 
			confirmPasswordTextBox.Location = new Point(285, 281);
			confirmPasswordTextBox.Name = "confirmPasswordTextBox";
			confirmPasswordTextBox.Size = new Size(251, 23);
			confirmPasswordTextBox.TabIndex = 3;
			// 
			// usernameLabel
			// 
			usernameLabel.AutoSize = true;
			usernameLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			usernameLabel.ForeColor = Color.FromArgb(64, 64, 64);
			usernameLabel.Location = new Point(181, 161);
			usernameLabel.Name = "usernameLabel";
			usernameLabel.Size = new Size(98, 25);
			usernameLabel.TabIndex = 4;
			usernameLabel.Text = "Username";
			// 
			// emailLabel
			// 
			emailLabel.AutoSize = true;
			emailLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			emailLabel.ForeColor = Color.FromArgb(64, 64, 64);
			emailLabel.Location = new Point(220, 197);
			emailLabel.Name = "emailLabel";
			emailLabel.Size = new Size(59, 25);
			emailLabel.TabIndex = 5;
			emailLabel.Text = "Email";
			// 
			// passwordLabel
			// 
			passwordLabel.AutoSize = true;
			passwordLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			passwordLabel.ForeColor = Color.FromArgb(64, 64, 64);
			passwordLabel.Location = new Point(188, 240);
			passwordLabel.Name = "passwordLabel";
			passwordLabel.Size = new Size(91, 25);
			passwordLabel.TabIndex = 6;
			passwordLabel.Text = "Password";
			// 
			// confirmPasswordLabel
			// 
			confirmPasswordLabel.AutoSize = true;
			confirmPasswordLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			confirmPasswordLabel.ForeColor = Color.FromArgb(64, 64, 64);
			confirmPasswordLabel.Location = new Point(113, 281);
			confirmPasswordLabel.Name = "confirmPasswordLabel";
			confirmPasswordLabel.Size = new Size(166, 25);
			confirmPasswordLabel.TabIndex = 7;
			confirmPasswordLabel.Text = "Confirm Password";
			// 
			// RegisterBtn
			// 
			RegisterBtn.Location = new Point(285, 325);
			RegisterBtn.Name = "RegisterBtn";
			RegisterBtn.Size = new Size(251, 38);
			RegisterBtn.TabIndex = 8;
			RegisterBtn.Text = "Register";
			RegisterBtn.UseVisualStyleBackColor = true;
			RegisterBtn.Click += RegisterBtnClick;
			// 
			// PasswordPalLabel
			// 
			PasswordPalLabel.AutoSize = true;
			PasswordPalLabel.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
			PasswordPalLabel.ForeColor = Color.FromArgb(64, 64, 64);
			PasswordPalLabel.Location = new Point(364, 110);
			PasswordPalLabel.Name = "PasswordPalLabel";
			PasswordPalLabel.Size = new Size(180, 40);
			PasswordPalLabel.TabIndex = 11;
			PasswordPalLabel.Text = "PasswordPal";
			// 
			// LockIcon
			// 
			LockIcon.Image = Properties.Resources.lock_icon;
			LockIcon.Location = new Point(285, 82);
			LockIcon.Name = "LockIcon";
			LockIcon.Size = new Size(73, 68);
			LockIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			LockIcon.TabIndex = 10;
			LockIcon.TabStop = false;
			// 
			// GithubIcon
			// 
			GithubIcon.Image = (Image)resources.GetObject("GithubIcon.Image");
			GithubIcon.Location = new Point(737, 12);
			GithubIcon.Name = "GithubIcon";
			GithubIcon.Size = new Size(51, 49);
			GithubIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			GithubIcon.TabIndex = 14;
			GithubIcon.TabStop = false;
			GithubIcon.Click += GithubIconClick;
			// 
			// InfoIcon
			// 
			InfoIcon.Image = (Image)resources.GetObject("InfoIcon.Image");
			InfoIcon.Location = new Point(691, 12);
			InfoIcon.Name = "InfoIcon";
			InfoIcon.Size = new Size(49, 49);
			InfoIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			InfoIcon.TabIndex = 13;
			InfoIcon.TabStop = false;
			InfoIcon.Click += InfoIconClick;
			// 
			// HelpIcon
			// 
			HelpIcon.Image = (Image)resources.GetObject("HelpIcon.Image");
			HelpIcon.Location = new Point(648, 16);
			HelpIcon.Name = "HelpIcon";
			HelpIcon.Size = new Size(37, 41);
			HelpIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			HelpIcon.TabIndex = 12;
			HelpIcon.TabStop = false;
			HelpIcon.Click += HelpIconClick;
			// 
			// BackIcon
			// 
			BackIcon.Image = Properties.Resources.back_icon;
			BackIcon.Location = new Point(12, 12);
			BackIcon.Name = "BackIcon";
			BackIcon.Size = new Size(38, 38);
			BackIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			BackIcon.TabIndex = 15;
			BackIcon.TabStop = false;
			BackIcon.Click += BackIconClick;
			// 
			// RegistrationForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 450);
			Controls.Add(BackIcon);
			Controls.Add(GithubIcon);
			Controls.Add(InfoIcon);
			Controls.Add(HelpIcon);
			Controls.Add(PasswordPalLabel);
			Controls.Add(LockIcon);
			Controls.Add(RegisterBtn);
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
			((System.ComponentModel.ISupportInitialize)LockIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)GithubIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)InfoIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)HelpIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)BackIcon).EndInit();
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
		private Button RegisterBtn;
		private Label PasswordPalLabel;
		private PictureBox LockIcon;
		private PictureBox GithubIcon;
		private PictureBox InfoIcon;
		private PictureBox HelpIcon;
		private PictureBox BackIcon;
	}
}