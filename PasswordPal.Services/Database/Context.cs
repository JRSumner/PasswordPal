using PasswordPal.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace PasswordPal.Services.Database;

public class Context : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Password> Password { get; set; }
    public DbSet<PasswordCategory> PasswordCategories { get; set; }

    private const string CONNECTION_STRING =  "Server=DESKTOP-RS3IDSB\\SQLEXPRESS;Database=PasswordPal;Trusted_Connection=True;Encrypt=False;";

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public Context()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "testUser1",
                Email = "testUser1@email.com",
                Password = "testPassword1"
            },
            new User
            {
                Id = 2,
                Username = "testUser2",
                Email = "testUser2@email.com",
                Password = "testPassword2"
            },
            new User
            {
                Id = 3,
                Username = "testUser3",
                Email = "testUser3@email.com",
                Password = "testPassword3"
            },
            new User
            {
                Id = 4,
                Username = "testUser4",
                Email = "testUser4@email.com",
                Password = "testPassword4"
            },
            new User
            {
                Id = 5,
                Username = "testUser5",
                Email = "testUser5@email.com",
                Password = "testPassword5"
            }
        );

        modelBuilder.Entity<Password>().HasData(
            new Password
            {
                Id = 1,
                Title = "Title1",
                Username = "Username1",
                EncryptedPassword = "encryptedPassword1",
                Website = "www.website1.com",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00",
                UserId = 1
            },
            new Password
            {
                Id = 2,
                Title = "Title2",
                Username = "Username2",
                EncryptedPassword = "encryptedPassword2",
                Website = "www.website2.com",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00",
                UserId = 2
            },
            new Password
            {
                Id = 3,
                Title = "Title3",
                Username = "Username3",
                EncryptedPassword = "encryptedPassword3",
                Website = "www.website3.com",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00",
                UserId = 3
            },
            new Password
            {
                Id = 4,
                Title = "Title4",
                Username = "Username4",
                EncryptedPassword = "encryptedPassword4",
                Website = "www.website4.com",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00",
                UserId = 4
            },
            new Password
            {
                Id = 5,
                Title = "Title5",
                Username = "Username5",
                EncryptedPassword = "encryptedPassword5",
                Website = "www.website5.com",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00",
                UserId = 5
            }
        );

        modelBuilder.Entity<PasswordCategory>().HasData(
            new PasswordCategory
            {
                Id = 1,
                Name = "Personal",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00"
            },
            new PasswordCategory
            {
                Id = 2,
                Name = "Work",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00"
            },
            new PasswordCategory
            {
                Id = 3,
                Name = "Social",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00"
            },
            new PasswordCategory
            {
                Id = 4,
                Name = "Shopping",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00"
            },
            new PasswordCategory
            {
                Id = 5,
                Name = "Other",
                CreatedAt = "2023-07-04 14:00:00",
                UpdatedAt = "2023-07-04 14:00:00"
            }
        );

    }
}