using PasswordPal.Services.Database;
using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using PasswordPal.Tests.Data;
using Xunit;

namespace PasswordPal.Tests
{
	public class UserTests
	{
		[Fact]
		public void AddsUserToDatabase_ReturnsTrue_IfSuccessful()
		{
			var user = new User
			{
				Username = TestDataGenerator.GetUniqueUsername(),
				Email = TestDataGenerator.GetUniqueEmail(),
				Password = TestDataGenerator.GetUniquePassword(),
				Salt = TestDataGenerator.GetSalt()
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
			var result = UserService.UniqueUsernameAndEmail(user, context).IsValid;

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

			var duplicateUser = new User
			{
				Username = uniqueUser.Username,
				Email = uniqueUser.Email,
				Password = uniqueUser.Password,
				Salt = uniqueUser.Salt
			};

			using var context = new Context();

			if (!context.User.Any(u => u.Username == uniqueUser.Username || u.Email == uniqueUser.Email)) context.User.Add(uniqueUser);

			context.SaveChanges();
			var result = UserService.UniqueUsernameAndEmail(duplicateUser, context).IsValid;

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
			var result = UserService.ValidUserRegistration(fields, password, confirmedPassword, user, context);

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

			UserService.AddUser(user);
			var result = UserService.GetUser(user.Username);

			Assert.NotNull(result);
			Assert.Equal(result.User.Username, user.Username);
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
}
