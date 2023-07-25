using PasswordPal.Services.Services;
using PasswordPal.UI.Common;

namespace PasswordPal.UI;

public partial class StoredPasswordsForm : Form
{
	private readonly Point _previousFormLocation;

	public StoredPasswordsForm(Point location)
	{
		InitializeComponent();
		Methods.InitializeIcons(HelpIcon, InfoIcon, GithubIcon);
		DisplayStoredPasswords();

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
		dataGridView1.Columns["UserId"].Visible = false;
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

	private async void HelpIconClick(object sender, EventArgs e)
	{
		Hide();
		await Methods.HelpClickCommon(HelpIcon, "storedPasswordsForm", Location);
	}

	private async void InfoIconClick(object sender, EventArgs e)
	{
		Hide();
		await Methods.InfoClickCommon(InfoIcon, "storedPasswordsForm", Location);
	}

	private async void GithubIconClick(object sender, EventArgs e)
	{
		await Methods.GithubClickCommon(GithubIcon);
	}
}