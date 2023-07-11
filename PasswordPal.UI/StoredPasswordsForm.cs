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
	}

	private void AddBtn_Click(object sender, EventArgs e)
	{
		var createPasswordForm = new CreatePasswordForm();
		createPasswordForm.Show();
		Hide();
	}
}