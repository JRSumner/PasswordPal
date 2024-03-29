﻿using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using System.Globalization;
using PasswordPal.Tests.Data;
using Xunit;

namespace PasswordPal.Tests;

public class PasswordTests : TestFixture, IAsyncLifetime
{
	public Task InitializeAsync()
	{
		return Task.CompletedTask;
	}

	public Task DisposeAsync()
	{
		AppSession.UserId = null;
		return Task.CompletedTask;
	}

	[Fact]
	public void PasswordMatchesConfirmation_ReturnsTrue_WhenPasswordsMatch()
	{
		var password = TestDataGenerator.GetUniquePassword();
		var confirmedPassword = password;
		var result = PasswordService.PasswordMatchesConfirmation(password, confirmedPassword).IsValid;

		Assert.True(result);
	}

	[Fact]
	public void PasswordMatchesConfirmation_ReturnsFalse_WhenPasswordsDontMatch()
	{
		var password = TestDataGenerator.GetUniquePassword();
		var confirmedPassword = "NoneMatchingPassword";
		var result = PasswordService.PasswordMatchesConfirmation(password, confirmedPassword).IsValid;

		Assert.False(result);
	}

	[Fact]
	public void GenerateHashedPasswordAndSalt_ReturnsDifferentResultsForSamePassword()
	{
		var password = TestDataGenerator.GetUniquePassword();
		var result1 = PasswordService.GenerateHashedPasswordAndSalt(password);
		var result2 = PasswordService.GenerateHashedPasswordAndSalt(password);

		Assert.NotEqual(result1.Password, result2.Password);
		Assert.NotEqual(result1.Salt, result2.Salt);
	}

	[Fact]
	public void GenerateHashedPasswordAndSalt_ReturnsNotNull()
	{
		var password = TestDataGenerator.GetUniquePassword();
		var result = PasswordService.GenerateHashedPasswordAndSalt(password);

		Assert.NotNull(result);
		Assert.NotNull(result.Password);
		Assert.NotNull(result.Salt);
	}

	[Fact]
	public void AddStoredPassword_AddsPassword_WhenValidPasswordIsProvided()
	{
		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		UserService.AddUser(user, _context);
		AppSession.UserId = UserService.GetUser(user.Username, _context)?.User?.Id;

		var storedPassword = new StoredPassword
		{
			Title = TestDataGenerator.GetUniqueTitle(),
			Username = TestDataGenerator.GetUniqueUsername(),
			EncryptedPassword = TestDataGenerator.GetUniquePassword(),
			Website = TestDataGenerator.GetUniqueWebsite(),
			CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
			UpdatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
			UserId = user.Id,
			CategoryId = 3
		};

		PasswordService.AddStoredPassword(storedPassword, _context);

		var result = PasswordService.GetStoredPassword(storedPassword, _context);

		Assert.Equal(result?.Id, storedPassword?.Id);
	}

	[Fact]
	public void AddStoredPassword_DoesNotAddPassword_WhenNullIsProvided()
	{
		StoredPassword password = null;

		Assert.Throws<ArgumentNullException>(() => PasswordService.AddStoredPassword(password, _context));
	}

	[Fact]
	public void GetStoredPasswords_ReturnsListOfStoredPasswords()
	{

		var user = new User
		{
			Username = TestDataGenerator.GetUniqueUsername(),
			Email = TestDataGenerator.GetUniqueEmail(),
			Password = TestDataGenerator.GetUniquePassword(),
			Salt = TestDataGenerator.GetSalt()
		};

		UserService.AddUser(user, _context);
		AppSession.UserId = UserService.GetUser(user.Username, _context).User?.Id;

		var password = new StoredPassword
		{
			Title = TestDataGenerator.GetUniqueTitle(),
			Username = TestDataGenerator.GetUniqueUsername(),
			EncryptedPassword = TestDataGenerator.GetUniquePassword(),
			Website = TestDataGenerator.GetUniqueWebsite(),
			CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
			UpdatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
			UserId = user.Id,
			CategoryId = 3,
		};

		PasswordService.AddStoredPassword(password, _context);

		var result = PasswordService.GetStoredPasswords(_context);

		Assert.NotNull(result); 
		Assert.IsType<List<StoredPassword>>(result); 
		Assert.True(result.Count > 0);
	}
}