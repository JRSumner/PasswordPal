using PasswordPal.Services.Services;
using PasswordPal.UI.Common;

namespace PasswordPal.UI;

public partial class LoginForm : Form
{
	public LoginForm()
	{
		var iconsList = new List<PictureBox> {HelpIcon, InfoIcon, GithubIcon};
		InitializeComponent();
		InitializeIcons();
		passwordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
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
			var storedPasswordsForm = new StoredPasswordsForm();
			storedPasswordsForm.Show();
			Hide();
			return;
		}

		MessageBox.Show(@"Error logging in", Constants.MESSAGE_BOX_TITLE_ERROR);
	}

	private void SignUpBtn_Click(object sender, EventArgs e)
	{
		var registrationForm = new RegistrationForm();
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