namespace PasswordPal.UI
{
	partial class PasswordPal
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
			vScrollBar1 = new VScrollBar();
			CreatePasswordBtn = new Button();
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
			SuspendLayout();
			// 
			// vScrollBar1
			// 
			vScrollBar1.Location = new Point(779, -1);
			vScrollBar1.Name = "vScrollBar1";
			vScrollBar1.Size = new Size(21, 456);
			vScrollBar1.TabIndex = 0;
			// 
			// CreatePasswordBtn
			// 
			CreatePasswordBtn.Location = new Point(261, 282);
			CreatePasswordBtn.Name = "CreatePasswordBtn";
			CreatePasswordBtn.Size = new Size(251, 38);
			CreatePasswordBtn.TabIndex = 1;
			CreatePasswordBtn.Text = "Create Password";
			CreatePasswordBtn.UseVisualStyleBackColor = true;
			CreatePasswordBtn.Click += CreatePasswordBtn_Click;
			// 
			// TitleTextBox
			// 
			TitleTextBox.Location = new Point(261, 69);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.Size = new Size(251, 23);
			TitleTextBox.TabIndex = 2;
			// 
			// UsernameTextBox
			// 
			UsernameTextBox.Location = new Point(261, 107);
			UsernameTextBox.Name = "UsernameTextBox";
			UsernameTextBox.Size = new Size(251, 23);
			UsernameTextBox.TabIndex = 3;
			// 
			// PasswordTextBox
			// 
			PasswordTextBox.Location = new Point(261, 148);
			PasswordTextBox.Name = "PasswordTextBox";
			PasswordTextBox.Size = new Size(251, 23);
			PasswordTextBox.TabIndex = 4;
			// 
			// WebsiteTextBox
			// 
			WebsiteTextBox.Location = new Point(261, 191);
			WebsiteTextBox.Name = "WebsiteTextBox";
			WebsiteTextBox.Size = new Size(251, 23);
			WebsiteTextBox.TabIndex = 5;
			// 
			// TitleLabel
			// 
			TitleLabel.AutoSize = true;
			TitleLabel.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			TitleLabel.Location = new Point(156, 69);
			TitleLabel.Name = "TitleLabel";
			TitleLabel.Size = new Size(37, 23);
			TitleLabel.TabIndex = 6;
			TitleLabel.Text = "Title";
			// 
			// UsernameLabel
			// 
			UsernameLabel.AutoSize = true;
			UsernameLabel.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			UsernameLabel.Location = new Point(156, 107);
			UsernameLabel.Name = "UsernameLabel";
			UsernameLabel.Size = new Size(83, 23);
			UsernameLabel.TabIndex = 7;
			UsernameLabel.Text = "Username";
			// 
			// PasswordLabel
			// 
			PasswordLabel.AutoSize = true;
			PasswordLabel.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			PasswordLabel.Location = new Point(156, 148);
			PasswordLabel.Name = "PasswordLabel";
			PasswordLabel.Size = new Size(79, 23);
			PasswordLabel.TabIndex = 8;
			PasswordLabel.Text = "Password";
			// 
			// WebsiteLabel
			// 
			WebsiteLabel.AutoSize = true;
			WebsiteLabel.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			WebsiteLabel.Location = new Point(156, 191);
			WebsiteLabel.Name = "WebsiteLabel";
			WebsiteLabel.Size = new Size(66, 23);
			WebsiteLabel.TabIndex = 9;
			WebsiteLabel.Text = "Website";
			// 
			// CategoryComboBox
			// 
			CategoryComboBox.FormattingEnabled = true;
			CategoryComboBox.Items.AddRange(new object[] { "Social", "Work", "Streaming", "Shopping", "Gaming", "Financial" });
			CategoryComboBox.Location = new Point(261, 235);
			CategoryComboBox.Name = "CategoryComboBox";
			CategoryComboBox.Size = new Size(251, 23);
			CategoryComboBox.TabIndex = 10;
			// 
			// CategoryLabel
			// 
			CategoryLabel.AutoSize = true;
			CategoryLabel.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			CategoryLabel.Location = new Point(156, 235);
			CategoryLabel.Name = "CategoryLabel";
			CategoryLabel.Size = new Size(72, 23);
			CategoryLabel.TabIndex = 11;
			CategoryLabel.Text = "Category";
			// 
			// PasswordPal
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
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
			Controls.Add(CreatePasswordBtn);
			Controls.Add(vScrollBar1);
			Name = "PasswordPal";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private VScrollBar vScrollBar1;
		private Button CreatePasswordBtn;
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
	}
}