using Core.Models;
using NLog;
using PasswordPal.Services.Database;

namespace PasswordPal.Services.Services;

public class UserInterfaceService
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static ValidationResult AllFieldsArePopulated(List<string> textBoxString, Context context = null)
	{
		context ??= new Context();
		Logger.Info("Checking if all fields are populated.");

		var result = new ValidationResult();

		if (!textBoxString.Any(tb => string.IsNullOrEmpty(tb) || string.IsNullOrWhiteSpace(tb)))
		{
			result.IsValid = true;
			Logger.Info("All fields are populated. Validation succeeded.");
			return result;
		}

		result.IsValid = false;
		result.Message = @"Please populate all fields before continuing.";
		Logger.Warn("Not all fields are populated. Validation failed.");

		return result;
	}

}