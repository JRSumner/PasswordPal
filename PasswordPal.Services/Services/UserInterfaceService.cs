using Core.Models;

namespace PasswordPal.Services.Services;

public class UserInterfaceService
{
	public static ValidationResult AllFieldsArePopulated(List<string> textBoxString)
	{
		var result = new ValidationResult();

		if (!textBoxString.Any(tb => string.IsNullOrEmpty(tb) || string.IsNullOrWhiteSpace(tb)))
		{
			result.IsValid = true;
			return result;
		}

		result.IsValid = false;
		result.Message = @"Please populate all fields before continuing.";

		return result;
	}
}