using PasswordPal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace PasswordPal.Services.Database;

public class Context : DbContext
{
	public DbSet<User> User { get; set; }
    public DbSet<StoredPassword> StoredPassword { get; set; }
    public DbSet<PasswordCategory> PasswordCategory { get; set; }

    public Context()
    {
    }
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)  // Only configure if no options have been provided
		{
			var dbFileName = "PasswordPal.db";
			var projectDirectory = Directory.GetCurrentDirectory();
			var dbFilePath = Path.Combine(projectDirectory, dbFileName);
			var connectionString = $"Data Source={dbFilePath};";

			DatabaseService.CreateDatabaseAndTables();

			optionsBuilder.UseSqlite(connectionString);
		}
	}
}