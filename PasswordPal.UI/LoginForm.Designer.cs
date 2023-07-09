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
			usernameTextBox = new TextBox();
			passwordTextBox = new TextBox();
			label1 = new Label();
			label2 = new Label();
			LoginBtn = new Button();
			label3 = new Label();
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
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(138, 167);
			label1.Name = "label1";
			label1.Size = new Size(98, 25);
			label1.TabIndex = 2;
			label1.Text = "Username";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			label2.Location = new Point(138, 206);
			label2.Name = "label2";
			label2.Size = new Size(91, 25);
			label2.TabIndex = 3;
			label2.Text = "Password";
			// 
			// LoginBtn
			// 
			LoginBtn.Location = new Point(303, 250);
			LoginBtn.Name = "LoginBtn";
			LoginBtn.Size = new Size(237, 46);
			LoginBtn.TabIndex = 4;
			LoginBtn.Text = "Login";
			LoginBtn.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
			label3.Location = new Point(313, 37);
			label3.Name = "label3";
			label3.Size = new Size(180, 40);
			label3.TabIndex = 5;
			label3.Text = "PasswordPal";
			// 
			// LoginForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(label3);
			Controls.Add(LoginBtn);
			Controls.Add(label2);
			Controls.Add(label1);
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
		private Label label1;
		private Label label2;
		private Button LoginBtn;
		private Label label3;
	}
}