using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using System.Globalization;

namespace PasswordPal.UI
{
	public partial class PasswordPal : Form
	{
		public PasswordPal()
		{
			InitializeComponent();
		}

		private void CreatePasswordBtn_Click(object sender, EventArgs e)
		{
			var category = new PasswordCategory()
			{
				Name = CategoryComboBox.Text,
				CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
				UpdatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture)
			};

			var password = new Password()
			{
				Title = TitleTextBox.Text,
				Username = UsernameTextBox.Text,
				EncryptedPassword = PasswordTextBox.Text,
				Website = WebsiteTextBox.Text,
				CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
				UpdatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
			};

			var context = new Context();
			context.Password.Add(password);
		}
	}
}