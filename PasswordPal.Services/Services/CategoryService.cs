using NLog;
using PasswordPal.Core.Models;
using PasswordPal.Services.Database;

namespace PasswordPal.Services.Services;

public class CategoryService
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	public static PasswordCategory GetCategory(string category, Context context = null)
	{
		context ??= new Context();
		PasswordCategory foundCategory = null;
		Logger.Info($"Attempting to retrieve the category named: {category}");

		try
		{
			foundCategory = context.PasswordCategory.FirstOrDefault(c => c.Name == category);

			if (foundCategory != null)
			{
				Logger.Info($"Successfully retrieved the category with ID: {foundCategory.Id}");
			}
			else
			{
				Logger.Warn($"No category found with the name: {category}");
			}
		}
		catch (Exception ex)
		{
			Logger.Error(ex, $"An error occurred while attempting to retrieve the category named: {category}");
		}

		return foundCategory;
	}
}