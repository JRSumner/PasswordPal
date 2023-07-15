using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using System.Security.Cryptography;
using Core.Models;

namespace PasswordPal.Services.Services
{
	public class PasswordService
	{
		public static void AddStoredPassword(StoredPassword storedPassword)
		{
			if (storedPassword == null) throw new ArgumentNullException();

			using var context = new Context();
			context.StoredPassword.Add(storedPassword);
			context.SaveChanges();
		}

		public static StoredPassword GetStoredPassword(StoredPassword storedPassword)
		{
			if (storedPassword == null) throw new ArgumentNullException();

			using var context = new Context();

			return context.StoredPassword.FirstOrDefault(p => p.Id == storedPassword.Id);
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
	}
}
