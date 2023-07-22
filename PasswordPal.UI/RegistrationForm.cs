using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using PasswordPal.UI.Common;

namespace PasswordPal.UI;

public partial class RegistrationForm : Form
{
	private readonly Point _previousFormLocation;

	public RegistrationForm(Point location)
	{
		InitializeComponent();
		Methods.InitializeIcons(HelpIcon, InfoIcon, GithubIcon, BackIcon);

		passwordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
		confirmPasswordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
		_previousFormLocation = location;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Location = _previousFormLocation;
	}

	private void RegisterBtnClick(object sender, EventArgs e)
	{
		var textBoxes = new List<TextBox> { usernameTextBox, emailTextBox, passwordTextBox, confirmPasswordTextBox };
		var textBoxString = new List<string> { usernameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, confirmPasswordTextBox.Text };
		var password = passwordTextBox?.Text;
		var confirmPassword = confirmPasswordTextBox?.Text;
		var hashedPasswordWithSalt = PasswordService.GenerateHashedPasswordAndSalt(password);

		var user = new User
		{
			Username = usernameTextBox.Text,
			Email = emailTextBox.Text,
			Password = hashedPasswordWithSalt.Password,
			Salt = hashedPasswordWithSalt.Salt
		};

		var validUserRegistrationResult = UserService.ValidUserRegistration(textBoxString, password, confirmPassword, user);

		if (!validUserRegistrationResult.IsValid)
		{
			MessageBox.Show(validUserRegistrationResult.Message, Constants.MESSAGE_BOX_TITLE_ERROR);
			return;
		}

		try
		{
			UserService.AddUser(user);

			if (UserService.UserExists(user.Username))
			{
				MessageBox.Show(@"Registration successful!", Constants.MESSAGE_BOX_TITLE_SUCCESS);
				var loginForm = new LoginForm(Location);
				loginForm.Show();
				Hide();
			}

			foreach (var textBox in textBoxes) textBox.Clear();
		}
		catch (Exception exception)
		{
			MessageBox.Show($@"The following error occurred:{exception}", Constants.MESSAGE_BOX_TITLE_ERROR);
			throw;
		}
	}

	private async void HelpIconClick(object sender, EventArgs e)
	{
		Hide();
		await Methods.HelpClickCommon(HelpIcon, "registrationForm", Location);
	}

	private async void InfoIconClick(object sender, EventArgs e)
	{
		await Methods.InfoClickCommon(InfoIcon);
	}

	private async void GithubIconClick(object sender, EventArgs e)
	{
		await Methods.GithubClickCommon(GithubIcon);
	}

	private async void BackIconClick(object sender, EventArgs e)
	{
		await Methods.BackClickCommon(BackIcon);
		var loginForm = new LoginForm(Location);
		loginForm.Show();
		Close();
	}
}