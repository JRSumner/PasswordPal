using System.Configuration;
using PasswordPal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.IdentityModel.Protocols;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace PasswordPal.Services.Database;

public class Context : DbContext
{
	private readonly SeedDatabase _seedDatabase;
	public DbSet<User> User { get; set; }
    public DbSet<Password> Password { get; set; }
    public DbSet<PasswordCategory> PasswordCategory { get; set; }

    //private const string CONNECTION_STRING =  "Server=DESKTOP-RS3IDSB\\SQLEXPRESS;Database=PasswordPal;Trusted_Connection=True;Encrypt=False;";

    public Context(DbContextOptions<Context> options) : base(options)
    {
	    _seedDatabase = new SeedDatabase();
    }

    public Context()
    {
	    _seedDatabase = new SeedDatabase();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
	    var configuration = new ConfigurationBuilder()
			.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "PasswordPal.Services"))
			.AddJsonFile("appsettings.json", optional: true)
			.Build();
	    var connectionString = configuration.GetConnectionString("DefaultConnection");

	    if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
	    _seedDatabase.OnModelCreating(modelBuilder);
        //TODO Include table relationships
    }
}