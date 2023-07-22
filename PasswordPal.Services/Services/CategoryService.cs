using PasswordPal.Core.Models;
using PasswordPal.Services.Database;

namespace PasswordPal.Services.Services;

public class CategoryService
{
	public static PasswordCategory GetCategory(string category)
	{
		using var context = new Context();

		return context.PasswordCategory.FirstOrDefault(c => c.Name == category);
	}
}