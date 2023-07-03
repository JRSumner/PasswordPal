using Microsoft.EntityFrameworkCore;
using PasswordPal.Core.Models;
using PasswordPal.Services.Database;
using Xunit;

namespace PasswordPal.Tests;

public class DatabaseAccess
{
    [Fact]
    public void CanGetFirstUser()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "PasswordPal_TestDatabase")
            .Options;

        using (var context = new Context(options))
        {
            context.User.Add(new User
            {
                Username = "testUser1",
                Password = "testPassword1",
                Email = "testUser1@email.com"
            });

            context.SaveChanges();
        }

        User firstUser;
        using (var context = new Context(options))
        {
            firstUser = context.User.FirstOrDefault();
        }

        Assert.NotNull(firstUser);
    }

    [Fact]
    public void CanGetFirstPassword()
    {
        using var context = new Context();
        var firstPassword = context.Password.ToList();
        var users = context.User.ToList();
        Assert.NotNull(firstPassword);
    }
}