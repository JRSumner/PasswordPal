﻿using PasswordPal.Services.Services;

namespace PasswordPal.UI;

public partial class StoredPasswordsForm : Form
{
	private readonly Point _previousFormLocation;

	public StoredPasswordsForm(Point location)
	{
		InitializeComponent();
		DisplayStoredPasswords();

		Text = @"PasswordPal - Stored Items";
		_previousFormLocation = location;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Location = _previousFormLocation;
	}

	private void DisplayStoredPasswords()
	{
		dataGridView1.DataSource = PasswordService.GetStoredPasswords();
		dataGridView1.Columns["Id"].Visible = false;
		dataGridView1.Columns["UserId"].Visible = false;
		dataGridView1.Columns["CategoryId"].Visible = false;
		dataGridView1.Columns["CreatedAt"].Visible = false;
		dataGridView1.Columns["UpdatedAt"].Visible = false;
	}

	private void AddBtnClick(object sender, EventArgs e)
	{
		var createPasswordForm = new CreatePasswordForm(Location);
		createPasswordForm.Show();
		Hide();
	}

	private void LogoutBtnClick(object sender, EventArgs e)
	{
		var loginForm = new LoginForm(Location);
		loginForm.Show();
		Close();
	}

	private void StoredPasswordsFormLoad(object sender, EventArgs e)
	{
	}
}