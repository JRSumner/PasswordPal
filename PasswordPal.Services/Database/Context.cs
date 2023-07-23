using PasswordPal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
			.AddJsonFile("appsettings.json", optional: true)
			.Build();
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		DatabaseService.CreateDatabaseAndTables();

		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlite(connectionString);
		}
	}
}