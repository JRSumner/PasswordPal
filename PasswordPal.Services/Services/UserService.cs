using Core.Models;
using PasswordPal.Core.Models;
using PasswordPal.Services.Database;

namespace PasswordPal.Services.Services
{
	public class UserService
	{
		public static void AddUser(User user)
		{
			using var context = new Context();
			context.Add(user);
			context.SaveChanges();
		}

		public static User GetUser(string username)
		{
			using var context = new Context();

			return context.User.FirstOrDefault(u => u.Username == username);
		}

		public static bool UserExists(string username)
		{
			using var context = new Context();

			return context.User.Any(u => u.Username == username);
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

			var allFieldsArePopulatedResult = UserInterfaceService.AllFieldsArePopulated(textBoxString);
			var passwordMatchesConfirmationResult = PasswordService.PasswordMatchesConfirmation(password, confirmedPassword);
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
	}
}
