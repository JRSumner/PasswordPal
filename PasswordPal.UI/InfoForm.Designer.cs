namespace PasswordPal.UI
{
	partial class InfoForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoForm));
			AboutLabel = new Label();
			LockIcon = new PictureBox();
			PasswordPalLabel = new Label();
			BackIcon = new PictureBox();
			((System.ComponentModel.ISupportInitialize)LockIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)BackIcon).BeginInit();
			SuspendLayout();
			// 
			// AboutLabel
			// 
			AboutLabel.AutoSize = true;
			AboutLabel.Location = new Point(12, 233);
			AboutLabel.Name = "AboutLabel";
			AboutLabel.Size = new Size(85, 15);
			AboutLabel.TabIndex = 0;
			AboutLabel.Text = "About this app";
			// 
			// LockIcon
			// 
			LockIcon.Image = (Image)resources.GetObject("LockIcon.Image");
			LockIcon.Location = new Point(285, 82);
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
			PasswordPalLabel.Location = new Point(364, 110);
			PasswordPalLabel.Name = "PasswordPalLabel";
			PasswordPalLabel.Size = new Size(180, 40);
			PasswordPalLabel.TabIndex = 12;
			PasswordPalLabel.Text = "PasswordPal";
			// 
			// BackIcon
			// 
			BackIcon.Image = Properties.Resources.back_icon;
			BackIcon.Location = new Point(12, 12);
			BackIcon.Name = "BackIcon";
			BackIcon.Size = new Size(38, 38);
			BackIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			BackIcon.TabIndex = 19;
			BackIcon.TabStop = false;
			BackIcon.Click += BackIconClick;
			// 
			// InfoForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveCaption;
			ClientSize = new Size(800, 450);
			Controls.Add(BackIcon);
			Controls.Add(PasswordPalLabel);
			Controls.Add(LockIcon);
			Controls.Add(AboutLabel);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "InfoForm";
			Text = "PasswordPal - Info";
			((System.ComponentModel.ISupportInitialize)LockIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)BackIcon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label AboutLabel;
		private PictureBox LockIcon;
		private Label PasswordPalLabel;
		private PictureBox BackIcon;
	}
}