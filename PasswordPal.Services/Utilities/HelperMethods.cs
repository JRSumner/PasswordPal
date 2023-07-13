using System.Security.Cryptography;
using Core.Models;
using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using User = PasswordPal.Core.Models.User;

namespace PasswordPal.Services.Utilities;

public class HelperMethods
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

	public static ValidationResult PasswordMatchesConfirmation(string? password, string? confirmedPassword)
	{
		var result = new ValidationResult();

		if (!string.IsNullOrWhiteSpace(password) && password == confirmedPassword)
		{
			result.IsValid = true;
			return result;
		}

		result.IsValid = false;
		result.Message = @"Passwords do not match";
		
		return result;
	}

	public static ValidationResult UniqueUsernameAndEmail(User user, Context context)
	{
		var result = new ValidationResult
		{
			IsValid = true
		};

		if (context.User.Any(u => u.Username == user.Username))
		{
			result.IsValid = false;
			result.Message = @"Username already exists, please try a different username";

			return result;
		}

		if (context.User.Any(u => u.Email == user.Email))
		{
			result.IsValid = false;
			result.Message = @"Please register with a different email, a user has already registered using this email.";
		}

		return result;
	}

	public static ValidationResult ValidUserRegistration(List<string> textBoxString, string? password, string? confirmedPassword, User user, Context context)
	{
		var result = new ValidationResult
		{
			IsValid = true
		};

		var allFieldsArePopulatedResult = AllFieldsArePopulated(textBoxString);
		var passwordMatchesConfirmationResult = PasswordMatchesConfirmation(password, confirmedPassword);
		var uniqueUsernameAndEmailResult = UniqueUsernameAndEmail(user, context);

		if (!allFieldsArePopulatedResult.IsValid)
		{
			result.IsValid = false;
			result.Message = allFieldsArePopulatedResult.Message;

			return result;
		}

		if (!passwordMatchesConfirmationResult.IsValid)
		{
			result.IsValid = false;
			result.Message = passwordMatchesConfirmationResult.Message;
		}

		if (!uniqueUsernameAndEmailResult.IsValid)
		{
			result.IsValid = false;
			result.Message = uniqueUsernameAndEmailResult.Message;
		}

		return result;
	}

	public static HashedPasswordAndSalt GenerateHashedPasswordAndSalt(string? stringPassword)
	{
		byte[] salt;
		new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

		var pbkdf2 = new Rfc2898DeriveBytes(stringPassword, salt, 100000);
		var hash = pbkdf2.GetBytes(20);
		var hashBytes = new byte[36];

		Array.Copy(salt, 0, hashBytes, 0, 16);
		Array.Copy(hash, 0, hashBytes, 16, 20);

		var savedPasswordHash = Convert.ToBase64String(hashBytes);

		var password = new HashedPasswordAndSalt
		{
			Password = savedPasswordHash,
			Salt = Convert.ToBase64String(salt)
		};

		return password;
	}

	public static bool VerifyPassword(string enteredPassword, string storedPassword, string storedSalt)
	{
		var salt = Convert.FromBase64String(storedSalt);
		var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100000);
		var hash = pbkdf2.GetBytes(20);
		var hashBytes = new byte[36];

		Array.Copy(salt, 0, hashBytes, 0, 16);
		Array.Copy(hash, 0, hashBytes, 16, 20);

		var enteredPasswordHash = Convert.ToBase64String(hashBytes);

		return enteredPasswordHash == storedPassword;
	}
}