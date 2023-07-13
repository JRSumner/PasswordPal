using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using PasswordPal.Services.Utilities;
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
		var hashedPasswordWithSalt = HelperMethods.GenerateHashedPasswordAndSalt(password);

		var user = new User
		{
			Username = usernameTextBox.Text,
			Email = emailTextBox.Text,
			Password = hashedPasswordWithSalt.Password,
			Salt = hashedPasswordWithSalt.Salt
		};

		var validUserRegistrationResult = HelperMethods.ValidUserRegistration(textBoxString, password, confirmPassword, user, context);

		if (!validUserRegistrationResult.IsValid)
		{
			MessageBox.Show(validUserRegistrationResult.Message);
			return;
		}

		try
		{
			context.Add(user);
			context.SaveChanges();

			if (context.User.Any(u => u.Username == user.Username))
			{
				MessageBox.Show(@"Registration successful!");
				var loginForm = new LoginForm();
				loginForm.Show();
				Hide();
			}
			
			foreach (var textBox in textBoxes) textBox.Clear();
		}
		catch (Exception exception)
		{
			MessageBox.Show($@"The following error occurred:{exception}");
			throw;
		}
	}
}