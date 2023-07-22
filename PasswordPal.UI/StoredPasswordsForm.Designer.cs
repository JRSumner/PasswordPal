namespace PasswordPal.UI
{
	partial class StoredPasswordsForm
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
			dataGridView1 = new DataGridView();
			AddBtn = new Button();
			LogoutBtn = new Button();
			LockIcon = new PictureBox();
			PasswordPalLabel = new Label();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)LockIcon).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(338, 12);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(450, 426);
			dataGridView1.TabIndex = 0;
			// 
			// AddBtn
			// 
			AddBtn.Location = new Point(12, 334);
			AddBtn.Name = "AddBtn";
			AddBtn.Size = new Size(262, 49);
			AddBtn.TabIndex = 1;
			AddBtn.Text = "Add";
			AddBtn.UseVisualStyleBackColor = true;
			AddBtn.Click += AddBtn_Click;
			// 
			// LogoutBtn
			// 
			LogoutBtn.Location = new Point(12, 389);
			LogoutBtn.Name = "LogoutBtn";
			LogoutBtn.Size = new Size(262, 49);
			LogoutBtn.TabIndex = 2;
			LogoutBtn.Text = "Logout";
			LogoutBtn.UseVisualStyleBackColor = true;
			LogoutBtn.Click += LogoutBtn_Click;
			// 
			// LockIcon
			// 
			LockIcon.Image = Properties.Resources.lock_icon;
			LockIcon.Location = new Point(12, 12);
			LockIcon.Name = "LockIcon";
			LockIcon.Size = new Size(73, 68);
			LockIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			LockIcon.TabIndex = 11;
			LockIcon.TabStop = false;
			// 
			// PasswordPalLabel
			// 
			PasswordPalLabel.AutoSize = true;
			PasswordPalLabel.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
			PasswordPalLabel.ForeColor = Color.FromArgb(64, 64, 64);
			PasswordPalLabel.Location = new Point(91, 40);
			PasswordPalLabel.Name = "PasswordPalLabel";
			PasswordPalLabel.Size = new Size(180, 40);
			PasswordPalLabel.TabIndex = 12;
			PasswordPalLabel.Text = "PasswordPal";
			// 
			// StoredPasswordsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 450);
			Controls.Add(PasswordPalLabel);
			Controls.Add(LockIcon);
			Controls.Add(LogoutBtn);
			Controls.Add(AddBtn);
			Controls.Add(dataGridView1);
			Name = "StoredPasswordsForm";
			Text = "StoredPasswordsForm";
			Load += StoredPasswordsForm_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)LockIcon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private Button AddBtn;
		private Button LogoutBtn;
		private PictureBox LockIcon;
		private Label PasswordPalLabel;
	}
}