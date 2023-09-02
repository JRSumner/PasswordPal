using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using Xunit;

namespace PasswordPal.Tests;

public class CategoryTests : TestFixture
{
	[Fact]
	public void GetCategory_ReturnsCategory_WhenCategoryExists()
	{
		var category = new PasswordCategory { Name = "Social" };
		var result = CategoryService.GetCategory(category.Name, _context);
	
		Assert.Equal(result.Name, category.Name);
	}

	[Fact]
	public void GetCategory_ReturnsNull_WhenCategoryDoesNotExist()
	{
		const string categoryName = "NonExistingCategory";
		var result = CategoryService.GetCategory(categoryName, _context);

		Assert.Null(result);
	}
}