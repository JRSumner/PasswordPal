using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Database;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Password> Passwords { get; set; }
    public DbSet<PasswordCategory> PasswordCategories { get; set; }

    private const string CONNECTION_STRING = "";

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}