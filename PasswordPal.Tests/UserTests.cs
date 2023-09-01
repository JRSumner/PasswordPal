using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using PasswordPal.Tests.Data;
using Xunit;

namespace PasswordPal.Tests;

public class UserTests : TestFixture
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

		var result = UserService.UniqueUsernameAndEmail(user, _context).IsValid;

		Assert.True(result);
	}

	[Fact]
	public void UniqueUsernameAndEmail_ReturnsFalse_WhenUserProvidesExistingEmailOrUsername()
	{
		var uniqueUser = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};
		UserService.AddUser(uniqueUser, _context);
		_context.SaveChanges();
	
		var duplicateUser = new User
		{
			Username = uniqueUser.Username, 
			Email = uniqueUser.Email,       
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};
	

		var result = UserService.UniqueUsernameAndEmail(duplicateUser, _context);

		Assert.False(result.IsValid);
		Assert.NotNull(result.Message);
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

		var result = UserService.ValidUserRegistration(fields, password, confirmedPassword, user, _context);

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

		UserService.AddUser(user, _context);
		var retrievedUserResponse = UserService.GetUser(user.Username, _context);

		Assert.NotNull(retrievedUserResponse);
		Assert.True(retrievedUserResponse.Success);
		Assert.Equal(user.Username, retrievedUserResponse.User.Username);
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

		var result = UserService.GetUser(user.Username, _context);

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

		UserService.AddUser(user, _context);
		var userAdded = UserService.UserExists(user.Username, _context);

		UserService.RemoveUser(user, _context);
		var userRemoved = !UserService.UserExists(user.Username, _context);

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

		UserService.AddUser(user, _context);
		var result = UserService.GetUser(user.Username, _context);

		Assert.Equal(result.User?.Username, user.Username);
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

		var result = UserService.GetUser(user.Username, _context);

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

		UserService.AddUser(user, _context);
		var result = UserService.UserExists(user.Username, _context);

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

		var result = UserService.UserExists(user.Username, _context);

		Assert.False(result);
	}
}