using PasswordPal.Core.Models;
using PasswordPal.Services.Services;
using Xunit;

namespace PasswordPal.Tests;

public class CategoryTests
{
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
}