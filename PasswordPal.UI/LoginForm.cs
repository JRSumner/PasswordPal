using PasswordPal.Services.Services;
using PasswordPal.UI.Common;

namespace PasswordPal.UI;

public partial class LoginForm : Form
{
	private readonly Point _previousFormLocation;

	public LoginForm(Point location = default(Point))
	{
		InitializeComponent();
		Methods.InitializeIcons(HelpIcon, InfoIcon, GithubIcon);

		passwordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
		_previousFormLocation = location;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Location = _previousFormLocation;
	}

	private void LoginBtnClick(object sender, EventArgs e)
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

	private void SignUpBtnClick(object sender, EventArgs e)
	{
		var registrationForm = new RegistrationForm(Location);
		registrationForm.Show();
		Hide();
	}

	private async void HelpIconClick(object sender, EventArgs e)
	{
		Hide();
		await Methods.HelpClickCommon(HelpIcon, "loginForm", Location);
	}

	private async void InfoIconClick(object sender, EventArgs e)
	{
		Hide();
		await Methods.InfoClickCommon(InfoIcon, "loginForm", Location);
	}

	private async void GithubIconClick(object sender, EventArgs e)
	{
		await Methods.GithubClickCommon(GithubIcon);
	}
}