using System.Security.Cryptography;
using MessageBox = System.Windows.Forms.MessageBox;
using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using User = PasswordPal.Core.Models.User;

namespace PasswordPal.UI.Utilities;

public class HelperMethods
{
	public static bool AllFieldsArePopulated(List<string> textBoxString)
	{
		if (!textBoxString.Any(tb => string.IsNullOrEmpty(tb) || string.IsNullOrWhiteSpace(tb))) return true;

		MessageBox.Show(@"Please populate all fields before continuing.");
		return false;
	}

	public static bool PasswordMatchesConfirmation(string? password, string? confirmedPassword)
	{
		if (!string.IsNullOrWhiteSpace(password) && password == confirmedPassword) return true;

		MessageBox.Show(@"Passwords do not match");
		return false;
	}

	public static bool UniqueUsernameAndEmail(User user, Context context)
	{
		if(context.User.Any(u => u.Username == user.Username))
		{
			MessageBox.Show(@"Username already exists, please try a different username");
			return false;
		}

		if (context.User.Any(u => u.Email == user.Email))
		{
			MessageBox.Show(
				@"Please register with a different email, a user has already registered using this email.");
		}

		return true;
	}

	public static bool ValidUserRegistration(List<string> textBoxString, string? password, string? confirmedPassword, User user, Context context)
	{
		if (!AllFieldsArePopulated(textBoxString)) return false;

		if (!PasswordMatchesConfirmation(password, confirmedPassword)) return false;
		
		if (!UniqueUsernameAndEmail(user, context)) return false;

		return true;
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