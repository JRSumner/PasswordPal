using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using System.Globalization;
using Xunit;

namespace PasswordPal.Tests
{
	public class PasswordTests
	{
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
}
