namespace PasswordPal.UI
{
	partial class CreatePasswordForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePasswordForm));
			SaveBtn = new Button();
			TitleTextBox = new TextBox();
			UsernameTextBox = new TextBox();
			PasswordTextBox = new TextBox();
			WebsiteTextBox = new TextBox();
			TitleLabel = new Label();
			UsernameLabel = new Label();
			PasswordLabel = new Label();
			WebsiteLabel = new Label();
			CategoryComboBox = new ComboBox();
			CategoryLabel = new Label();
			PasswordPalLabel = new Label();
			LockIcon = new PictureBox();
			GithubIcon = new PictureBox();
			InfoIcon = new PictureBox();
			HelpIcon = new PictureBox();
			((System.ComponentModel.ISupportInitialize)LockIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)GithubIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)InfoIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)HelpIcon).BeginInit();
			SuspendLayout();
			// 
			// SaveBtn
			// 
			SaveBtn.Location = new Point(285, 381);
			SaveBtn.Name = "SaveBtn";
			SaveBtn.Size = new Size(251, 38);
			SaveBtn.TabIndex = 1;
			SaveBtn.Text = "Save";
			SaveBtn.UseVisualStyleBackColor = true;
			SaveBtn.Click += CreatePasswordBtn_Click;
			// 
			// TitleTextBox
			// 
			TitleTextBox.Location = new Point(285, 167);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.Size = new Size(251, 23);
			TitleTextBox.TabIndex = 2;
			// 
			// UsernameTextBox
			// 
			UsernameTextBox.Location = new Point(285, 210);
			UsernameTextBox.Name = "UsernameTextBox";
			UsernameTextBox.Size = new Size(251, 23);
			UsernameTextBox.TabIndex = 3;
			// 
			// PasswordTextBox
			// 
			PasswordTextBox.Location = new Point(285, 252);
			PasswordTextBox.Name = "PasswordTextBox";
			PasswordTextBox.Size = new Size(251, 23);
			PasswordTextBox.TabIndex = 4;
			// 
			// WebsiteTextBox
			// 
			WebsiteTextBox.Location = new Point(285, 298);
			WebsiteTextBox.Name = "WebsiteTextBox";
			WebsiteTextBox.Size = new Size(251, 23);
			WebsiteTextBox.TabIndex = 5;
			// 
			// TitleLabel
			// 
			TitleLabel.AutoSize = true;
			TitleLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			TitleLabel.ForeColor = Color.FromArgb(64, 64, 64);
			TitleLabel.Location = new Point(230, 167);
			TitleLabel.Name = "TitleLabel";
			TitleLabel.Size = new Size(49, 25);
			TitleLabel.TabIndex = 6;
			TitleLabel.Text = "Title";
			// 
			// UsernameLabel
			// 
			UsernameLabel.AutoSize = true;
			UsernameLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			UsernameLabel.ForeColor = Color.FromArgb(64, 64, 64);
			UsernameLabel.Location = new Point(181, 210);
			UsernameLabel.Name = "UsernameLabel";
			UsernameLabel.Size = new Size(98, 25);
			UsernameLabel.TabIndex = 7;
			UsernameLabel.Text = "Username";
			// 
			// PasswordLabel
			// 
			PasswordLabel.AutoSize = true;
			PasswordLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			PasswordLabel.ForeColor = Color.FromArgb(64, 64, 64);
			PasswordLabel.Location = new Point(188, 252);
			PasswordLabel.Name = "PasswordLabel";
			PasswordLabel.Size = new Size(91, 25);
			PasswordLabel.TabIndex = 8;
			PasswordLabel.Text = "Password";
			// 
			// WebsiteLabel
			// 
			WebsiteLabel.AutoSize = true;
			WebsiteLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			WebsiteLabel.ForeColor = Color.FromArgb(64, 64, 64);
			WebsiteLabel.Location = new Point(198, 296);
			WebsiteLabel.Name = "WebsiteLabel";
			WebsiteLabel.Size = new Size(81, 25);
			WebsiteLabel.TabIndex = 9;
			WebsiteLabel.Text = "Website";
			// 
			// CategoryComboBox
			// 
			CategoryComboBox.FormattingEnabled = true;
			CategoryComboBox.Items.AddRange(new object[] { "Social", "Work", "Streaming", "Shopping", "Gaming", "Financial" });
			CategoryComboBox.Location = new Point(285, 341);
			CategoryComboBox.Name = "CategoryComboBox";
			CategoryComboBox.Size = new Size(251, 23);
			CategoryComboBox.TabIndex = 10;
			// 
			// CategoryLabel
			// 
			CategoryLabel.AutoSize = true;
			CategoryLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			CategoryLabel.ForeColor = Color.FromArgb(64, 64, 64);
			CategoryLabel.Location = new Point(188, 341);
			CategoryLabel.Name = "CategoryLabel";
			CategoryLabel.Size = new Size(91, 25);
			CategoryLabel.TabIndex = 11;
			CategoryLabel.Text = "Category";
			// 
			// PasswordPalLabel
			// 
			PasswordPalLabel.AutoSize = true;
			PasswordPalLabel.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
			PasswordPalLabel.ForeColor = Color.FromArgb(64, 64, 64);
			PasswordPalLabel.Location = new Point(364, 110);
			PasswordPalLabel.Name = "PasswordPalLabel";
			PasswordPalLabel.Size = new Size(180, 40);
			PasswordPalLabel.TabIndex = 12;
			PasswordPalLabel.Text = "PasswordPal";
			// 
			// LockIcon
			// 
			LockIcon.Image = (Image)resources.GetObject("LockIcon.Image");
			LockIcon.Location = new Point(285, 82);
			LockIcon.Name = "LockIcon";
			LockIcon.Size = new Size(73, 68);
			LockIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			LockIcon.TabIndex = 13;
			LockIcon.TabStop = false;
			// 
			// GithubIcon
			// 
			GithubIcon.Image = (Image)resources.GetObject("GithubIcon.Image");
			GithubIcon.Location = new Point(737, 12);
			GithubIcon.Name = "GithubIcon";
			GithubIcon.Size = new Size(51, 49);
			GithubIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			GithubIcon.TabIndex = 16;
			GithubIcon.TabStop = false;
			GithubIcon.Click += GithubIcon_Click;
			// 
			// InfoIcon
			// 
			InfoIcon.Image = (Image)resources.GetObject("InfoIcon.Image");
			InfoIcon.Location = new Point(691, 12);
			InfoIcon.Name = "InfoIcon";
			InfoIcon.Size = new Size(49, 49);
			InfoIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			InfoIcon.TabIndex = 15;
			InfoIcon.TabStop = false;
			InfoIcon.Click += InfoIcon_Click;
			// 
			// HelpIcon
			// 
			HelpIcon.Image = (Image)resources.GetObject("HelpIcon.Image");
			HelpIcon.Location = new Point(648, 16);
			HelpIcon.Name = "HelpIcon";
			HelpIcon.Size = new Size(37, 41);
			HelpIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			HelpIcon.TabIndex = 14;
			HelpIcon.TabStop = false;
			HelpIcon.Click += Help_Click;
			// 
			// CreatePasswordForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 450);
			Controls.Add(GithubIcon);
			Controls.Add(InfoIcon);
			Controls.Add(HelpIcon);
			Controls.Add(LockIcon);
			Controls.Add(PasswordPalLabel);
			Controls.Add(CategoryLabel);
			Controls.Add(CategoryComboBox);
			Controls.Add(WebsiteLabel);
			Controls.Add(PasswordLabel);
			Controls.Add(UsernameLabel);
			Controls.Add(TitleLabel);
			Controls.Add(WebsiteTextBox);
			Controls.Add(PasswordTextBox);
			Controls.Add(UsernameTextBox);
			Controls.Add(TitleTextBox);
			Controls.Add(SaveBtn);
			Name = "CreatePasswordForm";
			Text = "Form1";
			Load += CreatePasswordForm_Load;
			((System.ComponentModel.ISupportInitialize)LockIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)GithubIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)InfoIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)HelpIcon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button SaveBtn;
		private TextBox TitleTextBox;
		private TextBox UsernameTextBox;
		private TextBox PasswordTextBox;
		private TextBox WebsiteTextBox;
		private Label TitleLabel;
		private Label UsernameLabel;
		private Label PasswordLabel;
		private Label WebsiteLabel;
		private ComboBox CategoryComboBox;
		private Label CategoryLabel;
		private Label PasswordPalLabel;
		private PictureBox LockIcon;
		private PictureBox GithubIcon;
		private PictureBox InfoIcon;
		private PictureBox HelpIcon;
	}
}