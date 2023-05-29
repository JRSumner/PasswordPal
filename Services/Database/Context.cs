using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Database;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Password> Passwords { get; set; }
    public DbSet<PasswordCategory> PasswordCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=tcp:{localhost}.database.windows.net,1433;Initial Catalog={PasswordPalDB};Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        );
    }
}
