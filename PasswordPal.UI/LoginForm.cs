using PasswordPal.UI.Utilities;

namespace PasswordPal.UI
{
    public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();

			passwordTextBox.PasswordChar = Constants.PASSWORD_CHAR;
		}
	}
}
