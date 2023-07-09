using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using PasswordPal.UI.Utilities;

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

		private void RegisterBtn_Click(object sender, EventArgs e)
		{
			var textBoxes = new List<TextBox> { usernameTextBox, emailTextBox, passwordTextBox, confirmPasswordTextBox};
			var password = passwordTextBox?.Text;
			var confirmPassword = confirmPasswordTextBox?.Text;

			using var context = new Context();

			var user = new User
			{
				Username = usernameTextBox.Text,
				Email = emailTextBox.Text,
				Password = HelperMethods.CreateHashedPassword(passwordTextBox?.Text)
			};

			if (!HelperMethods.ValidUserRegistration(textBoxes, password, confirmPassword, user, context))
			{
				return;
			}

			try
			{
				context.Add(user);
				context.SaveChanges();
				if (context.User.Any(u => u.Username == user.Username))
				{
					MessageBox.Show($@"User: {user.Username}, registered successfully.");
				}

				foreach (var textBox in textBoxes)
				{
					textBox.Clear();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show($@"The following error occurred:{exception}");
				throw;
			}
		}
	}
}
