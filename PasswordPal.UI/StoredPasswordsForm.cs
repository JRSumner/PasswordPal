using PasswordPal.Services.Services;

namespace PasswordPal.UI;

public partial class StoredPasswordsForm : Form
{
	private Point previousLocation;

	public StoredPasswordsForm(Point location)
	{
		InitializeComponent();
		DisplayStoredPasswords();
		previousLocation = location;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Location = previousLocation;
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

	private void AddBtn_Click(object sender, EventArgs e)
	{
		var createPasswordForm = new CreatePasswordForm(Location);
		createPasswordForm.Show();
		Hide();
	}

	private void LogoutBtn_Click(object sender, EventArgs e)
	{
		var loginForm = new LoginForm(Location);
		loginForm.Show();
		Close();
	}

	private void StoredPasswordsForm_Load(object sender, EventArgs e)
	{
	}
}