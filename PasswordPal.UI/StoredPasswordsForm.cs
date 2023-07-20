using PasswordPal.Services.Database;

namespace PasswordPal.UI;

public partial class StoredPasswordsForm : Form
{
	public StoredPasswordsForm()
	{
		InitializeComponent();
		DisplayStoredPasswords();
	}

	private void DisplayStoredPasswords()
	{
		using var context = new Context();
		dataGridView1.DataSource = context.StoredPassword.ToList();
		dataGridView1.Columns["Id"].Visible = false;
		dataGridView1.Columns["UserId"].Visible = false;
		dataGridView1.Columns["CategoryId"].Visible = false;
		dataGridView1.Columns["CreatedAt"].Visible = false;
		dataGridView1.Columns["UpdatedAt"].Visible = false;
	}

	private void AddBtn_Click(object sender, EventArgs e)
	{
		var createPasswordForm = new CreatePasswordForm();
		createPasswordForm.Show();
		createPasswordForm.Closed += CloseCreatePasswordForm;
		Hide();
	}

	private void LogoutBtn_Click(object sender, EventArgs e)
	{
		var loginForm = new LoginForm();
		loginForm.Show();
		Close();
	}

	private void CloseCreatePasswordForm(object sender, EventArgs e)
	{
		Show();
	}
}