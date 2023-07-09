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

			if (!HelperMethods.AllFieldsArePopulated(textBoxes))
			{
				return;
			}
			//TODO: Requires testing.
			if (!HelperMethods.PasswordMatchesConfirmation(passwordTextBox.Text, confirmPasswordTextBox.Text))
			{
				return;
			}

			using var context = new Context();

			try
			{
				context.Add(new User
				{
					//Id = 0,
					Username = usernameTextBox.Text,
					Email = emailTextBox.Text,
					Password = HelperMethods.CreateHashedPassword(passwordTextBox.Text)
				});
				context.SaveChanges();
			}
			catch (Exception exception)
			{
				MessageBox.Show($@"The following error occurred:{exception}");
				throw;
			}
		}
	}
}
