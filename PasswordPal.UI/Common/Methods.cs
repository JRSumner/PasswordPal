using System.Diagnostics;

namespace PasswordPal.UI.Common;

public class Methods
{
	public static async Task HelpClickCommon(PictureBox helpIcon, string? calledForm, Point location = default(Point))
	{
		helpIcon.Image = Properties.Resources.notepad_icon_clicked;
		await Task.Delay(100);
		helpIcon.Image = Properties.Resources.notepad_icon;

		var helpForm = new HelpForm(location, calledForm);
		helpForm.ShowDialog();
	}

	public static async Task InfoClickCommon(PictureBox infoIcon, string? calledForm, Point location = default(Point))
	{
		infoIcon.Image = Properties.Resources.info_icon_clicked;
		await Task.Delay(100);
		infoIcon.Image = Properties.Resources.info_icon;

		var infoForm = new InfoForm(location, calledForm);
		infoForm.ShowDialog();
	}
		
	public static async Task GithubClickCommon(PictureBox githubIcon)
	{
		githubIcon.Image = Properties.Resources.github_icon_clicked;
		await Task.Delay(100);
		githubIcon.Image = Properties.Resources.github_icon;
		
		var githubLink = "https://github.com/jrsumner";
		var psi = new ProcessStartInfo
		{
			FileName = githubLink,
			UseShellExecute = true
		};
		
		Process.Start(psi);
	}

	public static async Task BackClickCommon(PictureBox backIcon)
	{
		backIcon.Image = Properties.Resources.back_icon_clicked;
		await Task.Delay(100);
		backIcon.Image = Properties.Resources.back_icon;
	}

	public static void InitializeIcons(Control helpIcon, Control infoIcon, Control githubIcon, Control? backIcon = null)
	{
		var toolTip = new ToolTip();

		helpIcon.Cursor = Cursors.Hand;
		toolTip.SetToolTip(helpIcon, "Help");

		infoIcon.Cursor = Cursors.Hand;
		toolTip.SetToolTip(infoIcon, "Info");

		githubIcon.Cursor = Cursors.Hand;
		toolTip.SetToolTip(githubIcon, "Github");

		if (backIcon != null)
		{
			backIcon.Cursor = Cursors.Hand;
			toolTip.SetToolTip(backIcon, "Back");
		}
	}
}