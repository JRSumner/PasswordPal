using Microsoft.EntityFrameworkCore;
using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using PasswordPal.UI.Utilities;
using Xunit;

namespace PasswordPal.Tests;

public class Tests
{
	#region Database Tests
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
	#endregion

	#region UI HelperMethod Tests
	[Fact]
	public void AllFieldsArePopulated_ReturnsTrue_WhenAllFieldsArePopulated()
	{
		var fields = new List<string>
		{
			"Some text",
			"Some other text"
		};

		var result = HelperMethods.AllFieldsArePopulated(fields);

		Assert.True(result);
	}

	[Fact]
	public void AllFieldsArePopulated_ReturnsFalse_WhenAnyFieldIsEmpty()
	{
		var fields = new List<string>
		{
			"Some text",
			string.Empty // empty field
		};

		var result = HelperMethods.AllFieldsArePopulated(fields);

		Assert.False(result);
	}

	[Fact]
	public void PasswordMatchesConfirmation_ReturnsTrue_WhenPasswordsMatch()
	{
		const string password = "ExamplePassword123!";
		const string confirmedPassword = "ExamplePassword123!";
		var result = HelperMethods.PasswordMatchesConfirmation(password, confirmedPassword);

		Assert.True(result);
	}

	[Fact]
	public void PasswordMatchesConfirmation_ReturnsFalse_WhenPasswordsDontMatch()
	{
		const string password = "ExamplePassword123!";
		const string confirmedPassword = "NoneMatchingPassword";
		var result = HelperMethods.PasswordMatchesConfirmation(password, confirmedPassword);

		Assert.False(result);
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
		var result = HelperMethods.UniqueUsernameAndEmail(user, context);

		Assert.True(result);
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
		var result = HelperMethods.UniqueUsernameAndEmail(duplicateUser, context);

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
		var result = HelperMethods.ValidUserRegistration(fields, password, confirmedPassword, user, context);

		Assert.True(result);
	}

	[Fact]
	public void GenerateHashedPasswordAndSalt_ReturnsDifferentResultsForSamePassword()
	{
		const string password = "testPassword";
		var result1 = HelperMethods.GenerateHashedPasswordAndSalt(password);
		var result2 = HelperMethods.GenerateHashedPasswordAndSalt(password);

		Assert.NotEqual(result1.Password, result2.Password);
		Assert.NotEqual(result1.Salt, result2.Salt);
	}

	[Fact]
	public void GenerateHashedPasswordAndSalt_ReturnsNotNull()
	{
		const string password = "testPassword";
		var result = HelperMethods.GenerateHashedPasswordAndSalt(password);

		Assert.NotNull(result);
		Assert.NotNull(result.Password);
		Assert.NotNull(result.Salt);
	}
	#endregion
}