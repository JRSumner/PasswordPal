using System.Globalization;
using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using PasswordPal.UI.Common;

namespace PasswordPal.UI;

public partial class CreatePasswordForm : Form
{
	private readonly Point _previousFormLocation;

	public CreatePasswordForm(Point location)
	{
		InitializeComponent();
		Methods.InitializeIcons(HelpIcon, InfoIcon, GithubIcon, BackIcon);

		_previousFormLocation = location;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Location = _previousFormLocation;
	}

	private void CreatePasswordBtnClick(object sender, EventArgs e)
	{
		var textBoxString = new List<string> { TitleTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text, WebsiteTextBox.Text };
		var allFieldsArePopulatedResult = UserInterfaceService.AllFieldsArePopulated(textBoxString);

		if (!allFieldsArePopulatedResult.IsValid)
		{
			MessageBox.Show(allFieldsArePopulatedResult.Message);
			return;
		}

		var selectedCategory = CategoryService.GetCategory((string)CategoryComboBox.SelectedItem);

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

		PasswordService.AddStoredPassword(password);

		var storedPasswordForm = new StoredPasswordsForm(Location);
		storedPasswordForm.Show();
		Close();
	}

	private void CreatePasswordFormLoad(object sender, EventArgs e)
	{
	}

	private async void HelpIconClick(object sender, EventArgs e)
	{
		await Methods.HelpClickCommon(HelpIcon);
	}

	private async void InfoIconClick(object sender, EventArgs e)
	{
		await Methods.InfoClickCommon(InfoIcon);
	}

	private async void GithubIconClick(object sender, EventArgs e)
	{
		await Methods.GithubClickCommon(GithubIcon);
	}

	private async void BackIconClick(object sender, EventArgs e)
	{
		await Methods.BackClickCommon(BackIcon);
		var storedPasswordFrom = new StoredPasswordsForm(Location);
		storedPasswordFrom.Show();
		Close();
	}
}