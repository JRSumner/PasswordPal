using PasswordPal.UI.Common;

namespace PasswordPal.UI
{
	public partial class HelpForm : Form
	{
		private readonly Point _previousFormLocation;
		private readonly string _calledForm;

		public HelpForm(Point location, string? calledForm)
		{
			InitializeComponent();

			_previousFormLocation = location;
			_calledForm = calledForm;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Location = _previousFormLocation;
		}

		private async void BackIconClick(object sender, EventArgs e)
		{
			await Methods.BackClickCommon(BackIcon);

			switch (_calledForm)
			{
				case "loginForm":
					var loginForm = new LoginForm(Location);
					loginForm.Show();
					break;
				case "storedPasswordsForm":
					var storedPasswordsForm = new StoredPasswordsForm(Location);
					storedPasswordsForm.Show();
					break;
				case "createPasswordForm":
					var createPasswordForm = new CreatePasswordForm(Location);
					createPasswordForm.Show();
					break;
			}

			Close();
		}
	}
}
