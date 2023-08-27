using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using System.Security.Cryptography;
using Core.Models;
using NLog;

namespace PasswordPal.Services.Services;

public class PasswordService
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static void AddStoredPassword(StoredPassword storedPassword)
	{
		Logger.Info("Attempting to add a new stored password.");

		if (storedPassword == null)
		{
			Logger.Error("Stored password is null.");
			throw new ArgumentNullException();
		}

		using var context = new Context();
		context.StoredPassword.Add(storedPassword);
		context.SaveChanges();
		Logger.Info($"Successfully added a new stored password with ID: {storedPassword.Id}");
	}

	public static StoredPassword GetStoredPassword(StoredPassword storedPassword)
	{
		Logger.Info("Attempting to retrieve a stored password.");

		if (storedPassword == null)
		{
			Logger.Error("Stored password is null.");
			throw new ArgumentNullException();
		}

		using var context = new Context();
		var result = context.StoredPassword
			.FirstOrDefault(p => p.Id == storedPassword.Id && p.UserId == AppSession.UserId);

		if (result != null)
		{
			Logger.Info($"Successfully retrieved the stored password with ID: {storedPassword.Id}");
		}
		else
		{
			Logger.Warn($"Could not find the stored password with ID: {storedPassword.Id}");
		}

		return result;
	}

	public static HashedPasswordAndSalt GenerateHashedPasswordAndSalt(string? stringPassword)
	{
		Logger.Info("Generating hashed password and salt.");

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

		Logger.Info("Successfully generated hashed password and salt.");
		return password;
	}


	public static bool VerifyPassword(string enteredPassword, string storedPassword, string storedSalt)
	{
		Logger.Info("Verifying the entered password.");

		var salt = Convert.FromBase64String(storedSalt);
		var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 100000);
		var hash = pbkdf2.GetBytes(20);
		var hashBytes = new byte[36];

		Array.Copy(salt, 0, hashBytes, 0, 16);
		Array.Copy(hash, 0, hashBytes, 16, 20);

		var enteredPasswordHash = Convert.ToBase64String(hashBytes);

		if (enteredPasswordHash != storedPassword) return false;

		Logger.Info("Password successfully verified.");
		return true;

	}

	public static ValidationResult PasswordMatchesConfirmation(string? password, string? confirmedPassword)
	{
		Logger.Info("Checking if password matches the confirmed password.");

		var result = new ValidationResult();

		if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmedPassword))
		{
			Logger.Warn("Either password or confirmed password is empty or null.");
		}

		if (password == confirmedPassword)
		{
			if (!string.IsNullOrWhiteSpace(password))
			{
				Logger.Info("Password matches confirmed password.");
			}

			result.IsValid = true;
			return result;
		}

		Logger.Warn("Passwords do not match.");
		result.IsValid = false;
		result.Message = @"Passwords do not match";

		return result;
	}


	public static List<StoredPassword>? GetStoredPasswords()
	{
		Logger.Info("Attempting to retrieve all stored passwords for the current user.");

		try
		{
			using var context = new Context();
			if (!context.StoredPassword.Any())
			{
				Logger.Warn("No stored passwords found in the database.");
				return new List<StoredPassword>();
			}

			Logger.Debug("Stored passwords found in the database. Filtering by current user ID.");

			var storedPasswords = context.StoredPassword
				.Where(sp => sp.UserId == AppSession.UserId)
				?.ToList();

			if (storedPasswords == null || !storedPasswords.Any())
			{
				Logger.Info("No stored passwords found for the current user.");
				return new List<StoredPassword>();
			}

			Logger.Info("Successfully retrieved stored passwords for the current user.");
			return storedPasswords;
		}
		catch (Exception ex)
		{
			Logger.Error(ex, "An error occurred while trying to retrieve stored passwords.");
			return null;
		}
	}

}