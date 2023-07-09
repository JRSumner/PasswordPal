using System.Security.Cryptography;

namespace PasswordPal.UI.Utilities
{
	public class HelperMethods
	{
		public static bool AllFieldsArePopulated(List<TextBox> textBoxes)
		{
			if (!textBoxes.Any(tb => string.IsNullOrEmpty(tb.Text) || string.IsNullOrWhiteSpace(tb.Text))) return true;

			MessageBox.Show(@"Please populate all fields before continuing.");
			return false;

		}

		public static bool PasswordMatchesConfirmation(string password, string confirmedPassword)
		{
			if (password == confirmedPassword) return true;

			MessageBox.Show(@"Passwords do not match");
			return false;

		}

		public static string CreateHashedPassword(string password)
		{
			byte[] salt;
			new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
			var hash = pbkdf2.GetBytes(20);

			var hashBytes = new byte[36];
			Array.Copy(salt, 0, hashBytes, 0, 16);
			Array.Copy(hash, 0, hashBytes, 16, 20);
			var savedPasswordHash = Convert.ToBase64String(hashBytes);

			return savedPasswordHash;
		}
	}
}
