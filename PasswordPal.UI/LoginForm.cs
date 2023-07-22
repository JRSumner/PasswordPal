using PasswordPal.Services.Services;
using PasswordPal.UI.Common;

namespace PasswordPal.UI;

public partial class LoginForm : Form
{
	private Point previousFormLocation;

	public LoginForm(Point location = default(Point))
	{
		InitializeComponent();
		InitializeIcons();
		passwordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
		previousFormLocation = location;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Location = previousFormLocation;
	}

	private void LoginBtn_Click(object sender, EventArgs e)
	{
		var textBoxString = new List<string> { usernameTextBox.Text, passwordTextBox.Text };
		var enteredUsername = usernameTextBox.Text;
		var enteredPassword = passwordTextBox.Text;
		var userResponse = UserService.GetUser(enteredUsername);

		if (!userResponse.Success)
		{
			MessageBox.Show(userResponse.Response, Constants.MESSAGE_BOX_TITLE_ERROR);
			return;
		}

		var allFieldsArePopulatedResult = UserInterfaceService.AllFieldsArePopulated(textBoxString);

		if (!allFieldsArePopulatedResult.IsValid)
		{
			MessageBox.Show(allFieldsArePopulatedResult.Message, Constants.MESSAGE_BOX_TITLE_ERROR);
			return;
		}

		if (PasswordService.VerifyPassword(enteredPassword, userResponse.User?.Password, userResponse.User.Salt))
		{
			var storedPasswordsForm = new StoredPasswordsForm(Location);
			storedPasswordsForm.Show();
			Hide();
			return;
		}

		MessageBox.Show(@"Error logging in", Constants.MESSAGE_BOX_TITLE_ERROR);
	}

	private void SignUpBtn_Click(object sender, EventArgs e)
	{
		var registrationForm = new RegistrationForm(Location);
		registrationForm.Show();
		registrationForm.FormClosed += RegistrationFormClosed;
		Hide();
	}

	private void RegistrationFormClosed(object sender, EventArgs e)
	{
		Show();
	}

	private async void Help_Click(object sender, EventArgs e)
	{
		await Methods.HelpClickCommon(HelpIcon);
	}

	private async void InfoIcon_Click(object sender, EventArgs e)
	{
		await Methods.InfoClickCommon(InfoIcon);
	}

	private async void GithubIcon_Click(object sender, EventArgs e)
	{
		await Methods.GithubClickCommon(GithubIcon);
	}

	private void InitializeIcons()
	{
		var toolTip = new ToolTip();
	
		HelpIcon.Cursor = Cursors.Hand;
		toolTip.SetToolTip(HelpIcon, "Help");
	
		InfoIcon.Cursor = Cursors.Hand;
		toolTip.SetToolTip(InfoIcon, "Info");
	
		GithubIcon.Cursor = Cursors.Hand;
		toolTip.SetToolTip(GithubIcon, "Github");
	}
}