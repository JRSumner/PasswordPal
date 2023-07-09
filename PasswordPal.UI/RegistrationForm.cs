namespace PasswordPal.UI
{
	public partial class RegistrationForm : Form
	{
		public RegistrationForm()
		{
			InitializeComponent();

			passwordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
			confirmPasswordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
		}
	}
}
