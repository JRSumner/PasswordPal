using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using System.Globalization;

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
			CheckFieldsArePopulated();

			var context = new Context();
			var selectedCategory = context.PasswordCategory
				.FirstOrDefault(c => c.Name == (string)CategoryComboBox.SelectedItem);

			var password = new Password
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

		private void CheckFieldsArePopulated()
		{
			var textBoxes = new List<TextBox>() { TitleTextBox, UsernameTextBox, PasswordTextBox, WebsiteTextBox };

			if (textBoxes.Any(tb => string.IsNullOrEmpty(tb.Text) || string.IsNullOrWhiteSpace(tb.Text)))
			{
				MessageBox.Show(@"Please populate all fields before pressing ""Save"".");
			}
		}
	}
}