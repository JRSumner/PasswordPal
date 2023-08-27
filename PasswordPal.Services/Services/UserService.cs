using Core.Models;
using Core.Models.Responses;
using NLog;
using PasswordPal.Core.Models;
using PasswordPal.Services.Database;

namespace PasswordPal.Services.Services;

public class UserService
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static void AddUser(User user)
	{
		using var context = new Context();
		context.Add(user);
		context.SaveChanges();
	}

	public static void RemoveUser(User user)
	{
		using var context = new Context();
		context.Remove(user);
		context.SaveChanges();
	}

	public static UserResponse GetUser(string username)
	{
		using var context = new Context();
		var user = context.User.FirstOrDefault(u => u.Username == username);
		var userResponse = new UserResponse();

		Logger.Warn("Test in Services project final");

		if (user != null)
		{
			userResponse.User = user;
			userResponse.Success = true;

			return userResponse;
		}

		userResponse.Success = false;
		userResponse.Response = $"Unable to find user with username :{username}";

		return userResponse;
	}

	public static bool UserExists(string username)
	{
		using var context = new Context();

		return context.User.Any(u => u.Username == username);
	}

	public static ValidationResult UniqueUsernameAndEmail(User user)
	{
		var result = new ValidationResult
		{
			IsValid = true
		};

		using var context = new Context();

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

	public static ValidationResult ValidUserRegistration(List<string> textBoxString, string? password, string? confirmedPassword, User user)
	{
		var result = new ValidationResult
		{
			IsValid = true
		};

		var allFieldsArePopulatedResult = UserInterfaceService.AllFieldsArePopulated(textBoxString);
		var passwordMatchesConfirmationResult = PasswordService.PasswordMatchesConfirmation(password, confirmedPassword);
		var uniqueUsernameAndEmailResult = UniqueUsernameAndEmail(user);

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

	public static UserResponse Login(string username)
	{
		var userResponse = GetUser(username);

		if (!userResponse.Success) return userResponse;

		var user = GetUser(username).User;
		if (user != null) AppSession.UserId = user.Id;

		return userResponse;
	}
}