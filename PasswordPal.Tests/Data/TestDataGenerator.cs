using System.Security.Cryptography;

namespace PasswordPal.Tests.Data;

public static class TestDataGenerator
{
	private static readonly Random RandomGenerator = new();

	public static string GetUniqueUsername()
	{
		return "TestUser" + Guid.NewGuid();
	}

	public static string GetUniqueEmail()
	{
		return GetUniqueUsername() + "@mail.com";
	}

	public static string GetUniquePassword()
	{
		return "Password" + Guid.NewGuid();
	}

	public static string GetSalt()
	{
		var saltSize = 16;
		var saltBytes = new byte[saltSize];

		using (var rng = new RNGCryptoServiceProvider())
		{
			rng.GetBytes(saltBytes);
		}

		return BitConverter.ToString(saltBytes).Replace("-", "");
	}

	public static string GetUniqueTitle()
	{
		return "Title" + Guid.NewGuid();
	}

	public static string GetUniqueWebsite()
	{
		return "Website" + Guid.NewGuid();
	}
}