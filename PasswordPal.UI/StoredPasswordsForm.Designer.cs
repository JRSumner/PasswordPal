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
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(270, 12);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(518, 426);
			dataGridView1.TabIndex = 0;
			// 
			// AddBtn
			// 
			AddBtn.Location = new Point(3, 390);
			AddBtn.Name = "AddBtn";
			AddBtn.Size = new Size(262, 49);
			AddBtn.TabIndex = 1;
			AddBtn.Text = "Add";
			AddBtn.UseVisualStyleBackColor = true;
			AddBtn.Click += AddBtn_Click;
			// 
			// StoredPasswordsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(AddBtn);
			Controls.Add(dataGridView1);
			Name = "StoredPasswordsForm";
			Text = "StoredPasswordsForm";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView1;
		private Button AddBtn;
	}
}