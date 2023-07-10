using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using System.Globalization;
using PasswordPal.UI.Utilities;

namespace PasswordPal.UI
{
	public partial class CreatePasswordForm : Form
	{
		public CreatePasswordForm()
		{
			InitializeComponent();
		}

		private void CreatePasswordBtn_Click(object sender, EventArgs e)
		{
			var textBoxes = new List<string> { TitleTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text, WebsiteTextBox.Text };

			if (!HelperMethods.AllFieldsArePopulated(textBoxes))
			{
				return;
			}
			
			var context = new Context();
			var selectedCategory = context.PasswordCategory
				.FirstOrDefault(c => c.Name == (string)CategoryComboBox.SelectedItem);

			var password = new StoredPassword
			{
				Title = TitleTextBox.Text,
				Username = UsernameTextBox.Text,
				EncryptedPassword = PasswordTextBox.Text,
				Website = WebsiteTextBox.Text,
				CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
				UpdatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
				UserId = 1,
				CategoryId = selectedCategory.Id,
			};

			context.Password.Add(password);
			context.SaveChanges();
		}
	}
}