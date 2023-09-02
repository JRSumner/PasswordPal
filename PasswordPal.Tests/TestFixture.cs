using Microsoft.EntityFrameworkCore;
using PasswordPal.Core.Models;
using PasswordPal.Services.Database;

namespace PasswordPal.Tests
{
	public class TestFixture : IDisposable
	{
		protected Context _context { get; }

		protected TestFixture()
		{
			var options = new DbContextOptionsBuilder<Context>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;
			_context = new Context(options);
			SeedPasswordCategories();
			_context.Database.EnsureCreated();
		}

		public void Dispose()
		{
			_context.User.RemoveRange(_context.User);
			_context.SaveChanges();

			_context.Database.EnsureDeleted();
			_context.Dispose();
		}

		private void SeedPasswordCategories()
		{
			_context.PasswordCategory.Add(new PasswordCategory { Id = 1, Name = "Social" });
			_context.PasswordCategory.Add(new PasswordCategory { Id = 2, Name = "Work" });
			_context.PasswordCategory.Add(new PasswordCategory { Id = 3, Name = "Streaming" });
			_context.PasswordCategory.Add(new PasswordCategory { Id = 4, Name = "Shopping" });
			_context.PasswordCategory.Add(new PasswordCategory { Id = 5, Name = "Gaming" });
			_context.PasswordCategory.Add(new PasswordCategory { Id = 6, Name = "Financial" });
			_context.SaveChanges();
		}
	}
}
