using PasswordPal.Services.Database;
using SQLitePCL;

namespace PasswordPal.UI;

internal static class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() {
		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.
		DatabaseService.CreateDatabaseAndTables();
		Batteries.Init();
		ApplicationConfiguration.Initialize();
		Application.Run(new LoginForm());
	}
}