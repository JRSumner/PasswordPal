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

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var dbFileName = "PasswordPal.db";
		var projectDirectory = Directory.GetCurrentDirectory();
		var dbFilePath = Path.Combine(projectDirectory, dbFileName);
		var connectionString = $"Data Source={dbFilePath};";

		DatabaseService.CreateDatabaseAndTables();

		optionsBuilder.UseSqlite(connectionString);
	}
}