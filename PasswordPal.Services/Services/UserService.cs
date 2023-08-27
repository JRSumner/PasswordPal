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
        Logger.Info("Attempting to add a new user.");

        try
        {
            using var context = new Context();
            context.Add(user);
            context.SaveChanges();
            Logger.Info("Successfully added a new user with ID: {0}", user.Id);
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "An error occurred while adding a new user.");
        }
	}

	public static void RemoveUser(User user)
	{
		Logger.Info("Attempting to remove a user.");

		try
		{
			using var context = new Context();
			context.Remove(user);
			context.SaveChanges();
			Logger.Info("Successfully removed a user with ID: {0}.", user.Id);
		}
		catch (Exception ex)
		{
			Logger.Error(ex, "An error occured while removing a user with ID: {0}.", user.Id);
		}
	}

	public static UserResponse GetUser(string username)
	{
		Logger.Info("Attempting to get a user.");
		User? user = null;
		var userResponse = new UserResponse();

		try
		{
			using var context = new Context();
			user = context.User.FirstOrDefault(u => u.Username == username);

			if (user != null)
			{
				userResponse.User = user;
				userResponse.Success = true;
				Logger.Info("Successfully retrieved a user with ID: {0}", user.Id);

				return userResponse;
			}

			userResponse.Success = false;
			userResponse.Response = $"Unable to find user with username :{username}";

			return userResponse;
		}
		catch (Exception ex)
		{
			Logger.Error(ex, "An error occured while retrieving a user with ID: {0}.", user.Id);
			return userResponse;
		}
	}

	public static bool UserExists(string username)
	{
		Logger.Info("Checking if a user with the username: {0} exists.", username);

		try
		{
			using var context = new Context();
			if (context.User.Any(u => u.Username == username))
			{
				Logger.Info("User with username: {0} exists.", username);
				return true;
			}
	
			Logger.Info("User with username: {0} does not exist.", username);
			return false;
		}
		catch (Exception ex)
		{
			Logger.Error(ex, "An error occurred while checking if a user with username: {0} exists.", username);
			return false;
		}
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
		Logger.Info("Validating the uniqueness of username and email for a new user.");

		var result = new ValidationResult
		{
			IsValid = true
		};

		try
		{
			using var context = new Context();

			if (context.User.Any(u => u.Username == user.Username))
			{
				result.IsValid = false;
				result.Message = @"Username already exists, please try a different username";
				Logger.Warn("Username: {0} already exists. Validation failed.", user.Username);
				return result;
			}

			if (context.User.Any(u => u.Email == user.Email))
			{
				result.IsValid = false;
				result.Message = @"Please register with a different email, a user has already registered using this email.";
				Logger.Warn("Email: {0} already exists. Validation failed.", user.Email);
			}
			else
			{
				Logger.Info("Username and Email are unique. Validation successful.");
			}
		}
		catch (Exception ex)
		{
			Logger.Error(ex, "An error occurred while validating the uniqueness of username and email.");
			result.IsValid = false;
			result.Message = "An error occurred during validation.";
		}

		return result;
	}

	public static UserResponse Login(string username)
	{
		Logger.Info("Attempting to login user with username: {0}", username);

		var userResponse = GetUser(username);

		if (!userResponse.Success)
		{
			Logger.Warn("Login failed for username: {0}. User not found or an error occurred.", username);
			return userResponse;
		}

		var user = userResponse.User;

		if (user != null)
		{
			AppSession.UserId = user.Id;
			Logger.Info("Successfully logged in user with ID: {0}", user.Id);
		}
		else
		{
			Logger.Warn("Login failed for username: {0}. User object is null.", username);
		}

		return userResponse;
	}

}