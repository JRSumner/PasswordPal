using PasswordPal.Services.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
