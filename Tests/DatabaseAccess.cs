using Xunit;
using Microsoft.EntityFrameworkCore;
using Services.Database;  
using Core.Models;

namespace Tests.DatabaseAccess;

public class DatabaseAccess
{
    [Fact]
    public void CanGetFirstUser()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new Context(options))
        {
            context.Users.Add(new User
            {
                Username = "Test User",
                Password = "pa$£word1",
                Email = "TestUser890@mail.com"
            });
            
            context.SaveChanges();
        }

        User firstUser;
        using (var context = new Context(options))
        {
            firstUser = context.Users.FirstOrDefault();
        }

        Assert.NotNull(firstUser);
    }
}