using PasswordPal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

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

		if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
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
				Password = "testPassword1",
				Salt = "exampleSalt"
			},
			new User
			{
				Id = 2,
				Username = "testUser2",
				Email = "testUser2@email.com",
				Password = "testPassword2",
				Salt = "exampleSalt"
			},
			new User
			{
				Id = 3,
				Username = "testUser3",
				Email = "testUser3@email.com",
				Password = "testPassword3",
				Salt = "exampleSalt"
			},
			new User
			{
				Id = 4,
				Username = "testUser4",
				Email = "testUser4@email.com",
				Password = "testPassword4",
				Salt = "exampleSalt"
			},
			new User
			{
				Id = 5,
				Username = "testUser5",
				Email = "testUser5@email.com",
				Password = "testPassword5",
				Salt = "exampleSalt"
			}
		);

		modelBuilder.Entity<StoredPassword>().HasData(
			new StoredPassword
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
			new StoredPassword
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
			new StoredPassword
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
			new StoredPassword
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
			new StoredPassword
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
				Name = "Social",
			},
			new PasswordCategory
			{
				Id = 2,
				Name = "Work",
			},
			new PasswordCategory
			{
				Id = 3,
				Name = "Streaming",
			},
			new PasswordCategory
			{
				Id = 4,
				Name = "Shopping",
			},
			new PasswordCategory
			{
				Id = 5,
				Name = "Gaming",
			},
			new PasswordCategory
			{
				Id = 6,
				Name = "Financial"
			}
		);
	}
}