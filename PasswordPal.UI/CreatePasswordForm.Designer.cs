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
			vScrollBar1 = new VScrollBar();
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
			pictureBox1 = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// vScrollBar1
			// 
			vScrollBar1.Location = new Point(779, -1);
			vScrollBar1.Name = "vScrollBar1";
			vScrollBar1.Size = new Size(21, 456);
			vScrollBar1.TabIndex = 0;
			// 
			// SaveBtn
			// 
			SaveBtn.Location = new Point(279, 277);
			SaveBtn.Name = "SaveBtn";
			SaveBtn.Size = new Size(251, 38);
			SaveBtn.TabIndex = 1;
			SaveBtn.Text = "Save";
			SaveBtn.UseVisualStyleBackColor = true;
			SaveBtn.Click += CreatePasswordBtn_Click;
			// 
			// TitleTextBox
			// 
			TitleTextBox.Location = new Point(279, 69);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.Size = new Size(251, 23);
			TitleTextBox.TabIndex = 2;
			// 
			// UsernameTextBox
			// 
			UsernameTextBox.Location = new Point(279, 107);
			UsernameTextBox.Name = "UsernameTextBox";
			UsernameTextBox.Size = new Size(251, 23);
			UsernameTextBox.TabIndex = 3;
			// 
			// PasswordTextBox
			// 
			PasswordTextBox.Location = new Point(279, 148);
			PasswordTextBox.Name = "PasswordTextBox";
			PasswordTextBox.Size = new Size(251, 23);
			PasswordTextBox.TabIndex = 4;
			// 
			// WebsiteTextBox
			// 
			WebsiteTextBox.Location = new Point(279, 191);
			WebsiteTextBox.Name = "WebsiteTextBox";
			WebsiteTextBox.Size = new Size(251, 23);
			WebsiteTextBox.TabIndex = 5;
			// 
			// TitleLabel
			// 
			TitleLabel.AutoSize = true;
			TitleLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			TitleLabel.Location = new Point(163, 69);
			TitleLabel.Name = "TitleLabel";
			TitleLabel.Size = new Size(49, 25);
			TitleLabel.TabIndex = 6;
			TitleLabel.Text = "Title";
			// 
			// UsernameLabel
			// 
			UsernameLabel.AutoSize = true;
			UsernameLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			UsernameLabel.Location = new Point(163, 107);
			UsernameLabel.Name = "UsernameLabel";
			UsernameLabel.Size = new Size(98, 25);
			UsernameLabel.TabIndex = 7;
			UsernameLabel.Text = "Username";
			// 
			// PasswordLabel
			// 
			PasswordLabel.AutoSize = true;
			PasswordLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			PasswordLabel.Location = new Point(163, 148);
			PasswordLabel.Name = "PasswordLabel";
			PasswordLabel.Size = new Size(91, 25);
			PasswordLabel.TabIndex = 8;
			PasswordLabel.Text = "Password";
			// 
			// WebsiteLabel
			// 
			WebsiteLabel.AutoSize = true;
			WebsiteLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			WebsiteLabel.Location = new Point(163, 189);
			WebsiteLabel.Name = "WebsiteLabel";
			WebsiteLabel.Size = new Size(81, 25);
			WebsiteLabel.TabIndex = 9;
			WebsiteLabel.Text = "Website";
			// 
			// CategoryComboBox
			// 
			CategoryComboBox.FormattingEnabled = true;
			CategoryComboBox.Items.AddRange(new object[] { "Social", "Work", "Streaming", "Shopping", "Gaming", "Financial" });
			CategoryComboBox.Location = new Point(279, 235);
			CategoryComboBox.Name = "CategoryComboBox";
			CategoryComboBox.Size = new Size(251, 23);
			CategoryComboBox.TabIndex = 10;
			// 
			// CategoryLabel
			// 
			CategoryLabel.AutoSize = true;
			CategoryLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			CategoryLabel.Location = new Point(163, 233);
			CategoryLabel.Name = "CategoryLabel";
			CategoryLabel.Size = new Size(91, 25);
			CategoryLabel.TabIndex = 11;
			CategoryLabel.Text = "Category";
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(59, 47);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 12;
			pictureBox1.TabStop = false;
			// 
			// CreatePasswordForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(pictureBox1);
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
			Controls.Add(vScrollBar1);
			Name = "CreatePasswordForm";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private VScrollBar vScrollBar1;
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
		private PictureBox pictureBox1;
	}
}