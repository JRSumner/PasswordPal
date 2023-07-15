using PasswordPal.Services.Database;
using PasswordPal.Services.Services;
using PasswordPal.UI.Common;

namespace PasswordPal.UI;

public partial class LoginForm : Form
{
	public LoginForm()
	{
		InitializeComponent();

		passwordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
	}

	private void LoginBtn_Click(object sender, EventArgs e)
	{
		using var context = new Context();
		var textBoxString = new List<string> { usernameTextBox.Text, passwordTextBox.Text };
		var enteredUsername = usernameTextBox.Text;
		var enteredPassword = passwordTextBox.Text;
		var userResponse = UserService.GetUser(enteredUsername);

		if (!userResponse.Success)
		{
			MessageBox.Show(userResponse.Response);
		}

		var allFieldsArePopulatedResult = UserInterfaceService.AllFieldsArePopulated(textBoxString);

		if (!allFieldsArePopulatedResult.IsValid)
		{
			MessageBox.Show(allFieldsArePopulatedResult.Message);
			return;
		}

		if (PasswordService.VerifyPassword(enteredPassword, userResponse.User?.Password, userResponse.User.Salt))
		{
			var storedPasswordsForm = new StoredPasswordsForm();
			storedPasswordsForm.Show();
			Hide();
			return;
		}

		MessageBox.Show(@"Error logging in");
	}

	private void SignUpBtn_Click(object sender, EventArgs e)
	{
		var registrationForm = new RegistrationForm();
		registrationForm.Show();
		Hide();
	}
}