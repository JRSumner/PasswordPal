using SQLitePCL;
using System.Reflection;

namespace PasswordPal.UI;

internal static class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() {
		var uiProjectPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		var servicesProjectPath = Path.GetFullPath(Path.Combine(uiProjectPath, "..", "..", "..", "..", "PasswordPal.Services", "Database"));
		Directory.SetCurrentDirectory(servicesProjectPath);

		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.

		Batteries.Init();
		ApplicationConfiguration.Initialize();
		Application.Run(new LoginForm());
	}
}