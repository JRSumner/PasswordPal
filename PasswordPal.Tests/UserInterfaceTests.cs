using PasswordPal.Services.Services;
using Xunit;

namespace PasswordPal.Tests;

public class UserInterfaceTests : TestFixture
{
	[Fact]
	public void AllFieldsArePopulated_ReturnsTrue_WhenAllFieldsArePopulated()
	{
		var fields = new List<string>
		{
			"Some text",
			"Some other text"
		};

		var result = UserInterfaceService.AllFieldsArePopulated(fields, _context);

		Assert.True(result.IsValid);
	}

	[Fact]
	public void AllFieldsArePopulated_ReturnsFalse_WhenAnyFieldIsEmpty()
	{
		var fields = new List<string>
		{
			"Some text",
			string.Empty
		};

		var result = UserInterfaceService.AllFieldsArePopulated(fields, _context);

		Assert.False(result.IsValid);
	}
}