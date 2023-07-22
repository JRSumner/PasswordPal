using System.Diagnostics;

namespace PasswordPal.UI.Common;

public class Methods
{
	public static async Task HelpClickCommon(PictureBox helpIcon)
	{
		helpIcon.Image = Properties.Resources.notepad_icon_clicked;
		await Task.Delay(100);
		helpIcon.Image = Properties.Resources.notepad_icon;
	}

	public static async Task InfoClickCommon(PictureBox infoIcon)
	{
		infoIcon.Image = Properties.Resources.info_icon_clicked;
		await Task.Delay(100);
		infoIcon.Image = Properties.Resources.info_icon;
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
}