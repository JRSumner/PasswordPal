using PasswordPal.Services.Database;
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

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			using var context = new Context();

			var enteredUsername = usernameTextBox.Text;
			var enteredPassword = passwordTextBox.Text;


		}
	}
}
