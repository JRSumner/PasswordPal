using System.Data.SQLite;

namespace PasswordPal.Services.Database;

public class DatabaseService
{
	private const string DbFileName = "PasswordPal.db";

	public static void CreateDatabaseAndTables()
	{
		if (File.Exists(DbFileName)) return;

		SQLiteConnection.CreateFile(DbFileName);

		using var connection = new SQLiteConnection($"Data Source={DbFileName};Version=3;");
		connection.Open();

		using (var command = new SQLiteCommand("CREATE TABLE User (Id INTEGER PRIMARY KEY, Username TEXT, Email TEXT, Password TEXT, Salt TEXT)", connection))
		{
			command.ExecuteNonQuery();
		}

		using (var command = new SQLiteCommand("CREATE TABLE PasswordCategory (Id INTEGER PRIMARY KEY, Name TEXT)", connection))
		{
			command.ExecuteNonQuery();
		}

		using (var command = new SQLiteCommand("CREATE TABLE StoredPassword (Id INTEGER PRIMARY KEY, Title TEXT, Username TEXT, EncryptedPassword TEXT, Website TEXT, CreatedAt TEXT, UpdatedAt TEXT, UserId INTEGER, CategoryId INTEGER, FOREIGN KEY(UserId) REFERENCES User(Id), FOREIGN KEY(CategoryId) REFERENCES PasswordCategory(Id))", connection))
		{
			command.ExecuteNonQuery();
		}
		using (var command = new SQLiteCommand("INSERT INTO PasswordCategory (Id, Name) VALUES (1, 'Social'), (2, 'Work'), (3, 'Streaming'), (4, 'Shopping'), (5, 'Gaming'), (6, 'Financial');", connection))
		{
			command.ExecuteNonQuery();
		}
	}
}