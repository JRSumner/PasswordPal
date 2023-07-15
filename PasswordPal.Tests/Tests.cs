using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using PasswordPal.Services.Services;
using System.Globalization;
using Xunit;

namespace PasswordPal.Tests;

public class Tests
{
	[Fact]
	public void AddsUserToDatabase_ReturnsTrue_IfSuccessful()
	{
		var randomNumber = new Random(999999).Next();

		var user = new User
		{
			Username = $"testUser{randomNumber}",
			Email = $"testUser{randomNumber}@mail.com",
			Password = "testUser1",
			Salt = "testUser1"
		};

		using var context = new Context();

		var existingUser = context.User.FirstOrDefault(u => u.Username == user.Username);
		if (existingUser != null)
		{
			context.User.Remove(existingUser);
			context.SaveChanges();
		}

		context.User.Add(user);
		context.SaveChanges();

		Assert.Contains(context.User, u => u.Username == user.Username);
	}

	[Fact]
	public void AllFieldsArePopulated_ReturnsTrue_WhenAllFieldsArePopulated()
	{
		var fields = new List<string>
		{
			"Some text",
			"Some other text"
		};

		var result = UserInterfaceService.AllFieldsArePopulated(fields);

		Assert.True(result.IsValid);
	}

	[Fact]
	public void AllFieldsArePopulated_ReturnsFalse_WhenAnyFieldIsEmpty()
	{
		var fields = new List<string>
		{
			"Some text",
			string.Empty // empty field
		};

		var result = UserInterfaceService.AllFieldsArePopulated(fields);

		Assert.False(result.IsValid);
	}

	[Fact]
	public void PasswordMatchesConfirmation_ReturnsTrue_WhenPasswordsMatch()
	{
		const string password = "ExamplePassword123!";
		const string confirmedPassword = "ExamplePassword123!";
		var result = PasswordService.PasswordMatchesConfirmation(password, confirmedPassword);

		Assert.True(result.IsValid);
	}

	[Fact]
	public void PasswordMatchesConfirmation_ReturnsFalse_WhenPasswordsDontMatch()
	{
		const string password = "ExamplePassword123!";
		const string confirmedPassword = "NoneMatchingPassword";
		var result = PasswordService.PasswordMatchesConfirmation(password, confirmedPassword);

		Assert.False(result.IsValid);
	}

	[Fact]
	public void UniqueUsernameAndEmail_ReturnsTrue_WhenUserProvidesUniqueEmailAndUsername()
	{
		var user = new User
		{
			Username = "TestUser1",
			Email = "TestUser1@mail.com",
			Password = "AnExamplePassword",
			Salt = "AnExampleSalt"
		};

		using var context = new Context();
		var result = UserService.UniqueUsernameAndEmail(user, context);

		Assert.True(result.IsValid);
	}

	[Fact]
	public void UniqueUsernameAndEmail_ReturnsFalse_WhenUserProvidesExistingEmailOrUsername()
	{
		var uniqueUser = new User
		{
			Username = "TestUser2",
			Email = "TestUser2@mail.com",
			Password = "uniqueUser",
			Salt = "AnExampleSalt"
		};

		var duplicateUser = new User
		{
			Username = "TestUser2",
			Email = "TestUser2@mail.com",
			Password = "AnExamplePassword",
			Salt = "AnExampleSalt"
		};

		using var context = new Context();

		if(!context.User.Any(u => u.Username == uniqueUser.Username || u.Email == uniqueUser.Email)) context.User.Add(uniqueUser);

		context.SaveChanges();
		var result = UserService.UniqueUsernameAndEmail(duplicateUser, context);

		Assert.False(result.IsValid);
	}

	[Fact]
	public void ValidUserRegistration_ReturnsTrue_UserRegistrationIsValid()
	{
		var fields = new List<string>
		{
			"Some text",
			"Some other text"
		};

		const string password = "ExamplePassword123!";
		const string confirmedPassword = "ExamplePassword123!";

		var user = new User
		{
			Username = "TestUser4",
			Email = "TestUser4@mail.com",
			Password = "AnExamplePassword",
			Salt = "AnExampleSalt"
		};

		using var context = new Context();
		var result = UserService.ValidUserRegistration(fields, password, confirmedPassword, user, context);

		Assert.True(result.IsValid);
	}

	[Fact]
	public void GenerateHashedPasswordAndSalt_ReturnsDifferentResultsForSamePassword()
	{
		const string password = "testPassword";
		var result1 = PasswordService.GenerateHashedPasswordAndSalt(password);
		var result2 = PasswordService.GenerateHashedPasswordAndSalt(password);

		Assert.NotEqual(result1.Password, result2.Password);
		Assert.NotEqual(result1.Salt, result2.Salt);
	}

	[Fact]
	public void GenerateHashedPasswordAndSalt_ReturnsNotNull()
	{
		const string password = "testPassword";
		var result = PasswordService.GenerateHashedPasswordAndSalt(password);

		Assert.NotNull(result);
		Assert.NotNull(result.Password);
		Assert.NotNull(result.Salt);
	}

	[Fact]
	public void AddUser_ReturnsTrue_WhenUserIsAdded()
	{
		var user = new User
		{
			Username = "TestUser5",
			Email = "TestUser5@mail.com",
			Password = "AnExamplePassword",
			Salt = "AnExampleSalt"
		};

		UserService.AddUser(user);
		var result = UserService.GetUser(user.Username);

		Assert.NotNull(result);
		Assert.Equal(result.Username, user.Username);
	}

	[Fact]
	public void AddUser_ReturnsFalse_WhenUserIsNotAdded()
	{
		var user = new User
		{
			Username = "TestUser6",
			Email = "TestUser6@mail.com",
			Password = "AnExamplePassword",
			Salt = "AnExampleSalt"
		};

		var result = UserService.GetUser(user.Username);

		Assert.Null(result);
	}

	[Fact]
	public void GetUser_ReturnsTrue_WhenUserIsReturned()
	{
		var user = new User
		{
			Username = "TestUser7",
			Email = "TestUser7@mail.com",
			Password = "AnExamplePassword",
			Salt = "AnExampleSalt"
		};

		UserService.AddUser(user);
		var result = UserService.GetUser(user.Username);

		Assert.Equal(result.Username, user.Username);
	}

	[Fact]
	public void GetUser_ReturnsFalse_WhenUserIsNotReturned()
	{
		var user = new User
		{
			Username = "TestUser8",
			Email = "TestUser8@mail.com",
			Password = "AnExamplePassword",
			Salt = "AnExampleSalt"
		};

		var result = UserService.GetUser(user.Username);

		Assert.Null(result);
	}

	[Fact]
	public void UserExists_ReturnsTrue_WhenUserExists()
	{
		var user = new User
		{
			Username = "TestUser9",
			Email = "TestUser9@mail.com",
			Password = "AnExamplePassword",
			Salt = "AnExampleSalt"
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
			Username = "TestUser10",
			Email = "TestUser10@mail.com",
			Password = "AnExamplePassword",
			Salt = "AnExampleSalt"
		};

		var result = UserService.UserExists(user.Username);

		Assert.False(result);
	}

	[Fact]
	public void GetCategory_ReturnsCategory_WhenCategoryExists()
	{
		var category = new PasswordCategory { Name = "Work" };
		var result = CategoryService.GetCategory(category.Name);

		Assert.Equal(result.Name, category.Name);
	}

	[Fact]
	public void GetCategory_ReturnsNull_WhenCategoryDoesNotExist()
	{
		const string categoryName = "NonExistingCategory";
		var result = CategoryService.GetCategory(categoryName);

		Assert.Null(result);
	}

	[Fact]
	public void AddStoredPassword_AddsPassword_WhenValidPasswordIsProvided()
	{
		var storedPassword = new StoredPassword
		{
			Title = "AnExampleStoredPassword",
			Username = "AnExampleUsername",
			EncryptedPassword = "AnExamplePassword",
			Website = "AnExampleWebsite",
			CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
			UpdatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
			UserId = 1,
			CategoryId = 1
		};

		PasswordService.AddStoredPassword(storedPassword);

		var result = PasswordService.GetStoredPassword(storedPassword); // Assuming you have a method to retrieve a password by Id

		Assert.Equal(result.Id, storedPassword.Id);
	}

	[Fact]
	public void AddStoredPassword_DoesNotAddPassword_WhenNullIsProvided()
	{
		StoredPassword password = null;

		Assert.Throws<ArgumentNullException>(() => PasswordService.AddStoredPassword(password));
	}

}