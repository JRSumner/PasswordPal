using System.Globalization;
using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using PasswordPal.UI.Common;

namespace PasswordPal.UI;

public partial class CreatePasswordForm : Form
{
	private Point previousFormLocation;

	public CreatePasswordForm(Point location)
	{
		InitializeComponent();
		previousFormLocation = location;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Location = previousFormLocation;
	}

	private void CreatePasswordBtn_Click(object sender, EventArgs e)
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

	private void CreatePasswordForm_Load(object sender, EventArgs e)
	{
	}

	private async void Help_Click(object sender, EventArgs e)
	{
		await Methods.HelpClickCommon(HelpIcon);
	}

	private async void InfoIcon_Click(object sender, EventArgs e)
	{
		await Methods.InfoClickCommon(InfoIcon);
	}

	private async void GithubIcon_Click(object sender, EventArgs e)
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

	private void InitializeIcons()
	{
		var toolTip = new ToolTip();

		HelpIcon.Cursor = Cursors.Hand;
		toolTip.SetToolTip(HelpIcon, "Help");

		InfoIcon.Cursor = Cursors.Hand;
		toolTip.SetToolTip(InfoIcon, "Info");

		GithubIcon.Cursor = Cursors.Hand;
		toolTip.SetToolTip(GithubIcon, "Github");
	}
}