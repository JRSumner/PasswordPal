using PasswordPal.Services.Database;
using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using PasswordPal.Tests.Data;
using Xunit;

namespace PasswordPal.Tests;

public class UserTests
{
	[Fact]
	public void UniqueUsernameAndEmail_ReturnsTrue_WhenUserProvidesUniqueEmailAndUsername()
	{
		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		using var context = new Context();
		var result = UserService.UniqueUsernameAndEmail(user).IsValid;

		Assert.True(result);
	}

	[Fact]
	public void UniqueUsernameAndEmail_ReturnsFalse_WhenUserProvidesExistingEmailOrUsername()
	{
		using var context = new Context();

		var uniqueUser = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		var duplicateUser = new User
		{
			Username = uniqueUser.Username,
			Email = uniqueUser.Email,
			Password = uniqueUser.Password,
			Salt = uniqueUser.Salt
		};

		if (!context.User.Any(u => u.Username == uniqueUser.Username || u.Email == uniqueUser.Email))
		{
			context.User.Add(uniqueUser);
		};

		context.SaveChanges();
		var result = UserService.UniqueUsernameAndEmail(duplicateUser).IsValid;

		Assert.False(result);
	}

	[Fact]
	public void ValidUserRegistration_ReturnsTrue_UserRegistrationIsValid()
	{
		var fields = new List<string>
		{
			"Some text",
			"Some other text"
		};

		var password = TestDataGenerator.GetUniquePassword();
		var confirmedPassword = password;

		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		using var context = new Context();
		var result = UserService.ValidUserRegistration(fields, password, confirmedPassword, user);

		Assert.True(result.IsValid);
	}

	[Fact]
	public void AddUser_ReturnsTrue_WhenUserIsAdded()
	{
		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		using var context = new Context();

		var existingUser = context.User.Any(u => u == user);

		if (existingUser)
		{
			UserService.AddUser(user);
		}

		UserService.AddUser(user);
		var result = UserService.GetUser(user.Username);

		Assert.NotNull(result);
		Assert.Equal(result.User.Username, user.Username);
		Assert.Contains(context.User, u => u.Username == user.Username);
	}

	[Fact]
	public void AddUser_ReturnsFalse_WhenUserIsNotAdded()
	{
		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		var result = UserService.GetUser(user.Username);

		Assert.False(result.Success);
	}

	[Fact]
	public void RemoveUser_ReturnsTrue_WhenUserIsRemoved()
	{
		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		UserService.AddUser(user);
		var userAdded = UserService.UserExists(user.Username);

		UserService.RemoveUser(user);
		var userRemoved = !UserService.UserExists(user.Username);

		Assert.True(userAdded);
		Assert.True(userRemoved);
	}

	[Fact]
	public void GetUser_ReturnsTrue_WhenUserIsReturned()
	{
		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		UserService.AddUser(user);
		var result = UserService.GetUser(user.Username);

		Assert.Equal(result.User.Username, user.Username);
	}

	[Fact]
	public void GetUser_ReturnsFalse_WhenUserIsNotReturned()
	{
		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		var result = UserService.GetUser(user.Username);

		Assert.False(result.Success);
	}

	[Fact]
	public void UserExists_ReturnsTrue_WhenUserExists()
	{
		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		UserService.AddUser(user);
		var result = UserService.UserExists(user.Username);

		Assert.True(result);
	}

	[Fact]
	public void UserExists_ReturnsFalse_WhenUserDoesNotExist()
	{
		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		var result = UserService.UserExists(user.Username);

		Assert.False(result);
	}
}