namespace PasswordPal.UI;

internal static class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.
		ApplicationConfiguration.Initialize();
		//Application.Run(new CreatePasswordForm());
		//Application.Run(new StoredPasswordsForm());
		Application.Run(new LoginForm());
		//Application.Run(new RegistrationForm());
	}
}