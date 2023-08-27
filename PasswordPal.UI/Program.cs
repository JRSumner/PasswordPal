using NLog;
using SQLitePCL;
using System.Reflection;
using NLog.Common;

namespace PasswordPal.UI;

internal static class Program
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() {
		Logger.Info("Initializing PasswordPal...");
		var uiProjectPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		var servicesProjectPath = Path.GetFullPath(Path.Combine(uiProjectPath, "..", "..", "..", "..", "PasswordPal.Services", "Database"));
		Directory.SetCurrentDirectory(servicesProjectPath);

		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.

		Batteries.Init();
		ApplicationConfiguration.Initialize();
		Application.Run(new LoginForm());
		LogManager.Shutdown();
	}
}