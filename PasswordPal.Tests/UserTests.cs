using PasswordPal.Services.Database;
using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using Xunit;

namespace PasswordPal.Tests
{
	public class UserTests
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

			if (!context.User.Any(u => u.Username == uniqueUser.Username || u.Email == uniqueUser.Email)) context.User.Add(uniqueUser);

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
			Assert.Equal(result.User.Username, user.Username);
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

			Assert.False(result.Success);
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

			Assert.Equal(result.User.Username, user.Username);
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

			Assert.False(result.Success);
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
	}
}
