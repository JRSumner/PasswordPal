using PasswordPal.Services.Services;
using PasswordPal.UI.Common;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace PasswordPal.UI;

public partial class StoredPasswordsForm : Form
{
	private readonly Point _previousFormLocation;
	private bool passwordCellClicked;

	public StoredPasswordsForm(Point location)
	{
		InitializeComponent();
		Methods.InitializeIcons(HelpIcon, InfoIcon, GithubIcon);
		DisplayStoredPasswords();

		_previousFormLocation = location;
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Location = _previousFormLocation;
		StyleDataGridView(StoredItemsGrid);
	}

	private void DisplayStoredPasswords()
	{
		StoredItemsGrid.DataSource = PasswordService.GetStoredPasswords();
		StoredItemsGrid.Columns["Id"].Visible = false;
		StoredItemsGrid.Columns["UserId"].Visible = false;
		StoredItemsGrid.Columns["UserId"].Visible = false;
		StoredItemsGrid.Columns["CategoryId"].Visible = false;
		StoredItemsGrid.Columns["CreatedAt"].Visible = false;
		StoredItemsGrid.Columns["UpdatedAt"].Visible = false;

		StoredItemsGrid.CellFormatting += StoredItemsGrid_CellFormatting;
		StoredItemsGrid.CellClick += StoredItemsGrid_CellClick;
	}

	private void AddBtnClick(object sender, EventArgs e)
	{
		var createPasswordForm = new CreatePasswordForm(Location);
		createPasswordForm.Show();
		Hide();
	}

	private void LogoutBtnClick(object sender, EventArgs e)
	{
		var loginForm = new LoginForm(Location);
		loginForm.Show();
		Close();
	}

	private void StoredPasswordsFormLoad(object sender, EventArgs e)
	{
	}

	private async void HelpIconClick(object sender, EventArgs e)
	{
		Hide();
		await Methods.HelpClickCommon(HelpIcon, "storedPasswordsForm", Location);
	}

	private async void InfoIconClick(object sender, EventArgs e)
	{
		Hide();
		await Methods.InfoClickCommon(InfoIcon, "storedPasswordsForm", Location);
	}

	private async void GithubIconClick(object sender, EventArgs e)
	{
		await Methods.GithubClickCommon(GithubIcon);
	}

	private void StyleDataGridView(DataGridView dgv)
	{
		dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
		dgv.DefaultCellStyle.BackColor = Color.WhiteSmoke;
		dgv.DefaultCellStyle.ForeColor = Color.Black;
		dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
		dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
		dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
		dgv.BorderStyle = BorderStyle.None;
		dgv.RowTemplate.Height = 30;
		dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
		dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgv.MultiSelect = false;
		dgv.DefaultCellStyle.SelectionBackColor = Color.MediumSlateBlue;
		dgv.DefaultCellStyle.SelectionForeColor = Color.White;
		dgv.RowHeadersVisible = false;
		dgv.EnableHeadersVisualStyles = false;

		foreach (DataGridViewColumn column in dgv.Columns)
		{
			column.ReadOnly = true;
			column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}
	}

	private void StoredItemsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (StoredItemsGrid.Columns[e.ColumnIndex].Name == "EncryptedPassword" && !passwordCellClicked)
		{
			e.Value = "*****";
			e.FormattingApplied = true;
		}
	}


	private void StoredItemsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (StoredItemsGrid.Columns[e.ColumnIndex].Name == "EncryptedPassword")
		{
			passwordCellClicked = true;

			var originalPassword = StoredItemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
			StoredItemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = originalPassword;

			var timer = new Timer();
			timer.Interval = 5000;
			timer.Tick += (s, args) =>
			{
				StoredItemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "*****";
				passwordCellClicked = false;
				timer.Stop();
			};
			timer.Start();
		}
	}


}