using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using PasswordPal.Services.Services;
using PasswordPal.UI.Common;

namespace PasswordPal.UI;

public partial class RegistrationForm : Form
{
	public RegistrationForm()
	{
		InitializeComponent();

		passwordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
		confirmPasswordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
	}

	private void RegisterBtn_Click(object sender, EventArgs e)
	{
		using var context = new Context();
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

		var validUserRegistrationResult = UserService.ValidUserRegistration(textBoxString, password, confirmPassword, user, context);

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
				var loginForm = new LoginForm();
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
}