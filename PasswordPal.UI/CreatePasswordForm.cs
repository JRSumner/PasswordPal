using System.Globalization;
using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using PasswordPal.Services.Utilities;

namespace PasswordPal.UI;

public partial class CreatePasswordForm : Form
{
	public CreatePasswordForm()
	{
		InitializeComponent();
	}

	private void CreatePasswordBtn_Click(object sender, EventArgs e)
	{
		var textBoxString = new List<string> { TitleTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text, WebsiteTextBox.Text };
		var allFieldsArePopulatedResult = HelperMethods.AllFieldsArePopulated(textBoxString);

		if (!allFieldsArePopulatedResult.IsValid)
		{
			MessageBox.Show(allFieldsArePopulatedResult.Message);
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

		context.StoredPassword.Add(password);
		context.SaveChanges();

		var storedPasswordForm = new StoredPasswordsForm();
		storedPasswordForm.Show();
		Close();
	}
}