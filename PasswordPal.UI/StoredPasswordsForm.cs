using PasswordPal.Services.Database;

namespace PasswordPal.UI
{
	public partial class StoredPasswordsForm : Form
	{
		public StoredPasswordsForm()
		{
			InitializeComponent();
			DisplayStoredPasswords();
		}

		private void DisplayStoredPasswords()
		{
			using var context = new Context();
			dataGridView1.DataSource = context.Password.ToList();
		}
	}
}
