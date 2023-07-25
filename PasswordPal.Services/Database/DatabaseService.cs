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

		using (var command = new SQLiteCommand("CREATE TABLE User (UserId INTEGER PRIMARY KEY, Username TEXT, Email TEXT, Password TEXT, Salt TEXT)", connection))
		{
			command.ExecuteNonQuery();
		}

		using (var command = new SQLiteCommand("CREATE TABLE PasswordCategory (UserId INTEGER PRIMARY KEY, Name TEXT)", connection))
		{
			command.ExecuteNonQuery();
		}

		using (var command = new SQLiteCommand("CREATE TABLE StoredPassword (UserId INTEGER PRIMARY KEY, Title TEXT, Username TEXT, EncryptedPassword TEXT, Website TEXT, CreatedAt TEXT, UpdatedAt TEXT, UserId INTEGER, CategoryId INTEGER, FOREIGN KEY(UserId) REFERENCES User(UserId), FOREIGN KEY(CategoryId) REFERENCES PasswordCategory(UserId))", connection))
		{
			command.ExecuteNonQuery();
		}

		using (var command = new SQLiteCommand("INSERT INTO PasswordCategory (UserId, Name) VALUES (1, 'Social'), (2, 'Work'), (3, 'Streaming'), (4, 'Shopping'), (5, 'Gaming'), (6, 'Financial');", connection))
		{
			command.ExecuteNonQuery();
		}
		//Seed User table
		using (var command = new SQLiteCommand(
			       "INSERT INTO User (Username, Email, Password, Salt) " +
			       "VALUES " +
			       "('johnDoe', 'johnDoe@gmail.com', 'hashedPassword1', 'salt1'), " +
			       "('janeDoe', 'janeDoe@yahoo.com', 'hashedPassword2', 'salt2'), " +
			       "('robertSmith', 'robertSmith@outlook.com', 'hashedPassword3', 'salt3'), " +
			       "('sarahJohnson', 'sarahJohnson@gmail.com', 'hashedPassword4', 'salt4'), " +
			       "('michaelBrown', 'michaelBrown@yahoo.com', 'hashedPassword5', 'salt5')", connection))
		{
			command.ExecuteNonQuery();
		}
		// Seed StoredPasswords for each user
		SeedStoredPasswords(connection, "johnDoe", 1);
		SeedStoredPasswords(connection, "janeDoe", 2);
		SeedStoredPasswords(connection, "robertSmith", 3);
		SeedStoredPasswords(connection, "sarahJohnson", 4);
		SeedStoredPasswords(connection, "michaelBrown", 5);
	}

	public static void SeedStoredPasswords(SQLiteConnection connection, string username, int userId)
	{
		using (var command = new SQLiteCommand(
			       "INSERT INTO StoredPassword (Title, Username, EncryptedPassword, Website, CreatedAt, UpdatedAt, UserId, CategoryId) " +
			       "VALUES " +
			       "('Facebook', '" + username + "Facebook', 'encryptedPassword1', 'www.facebook.com', '2023-07-04 14:00:00', '2023-07-04 14:00:00', " + userId + ", 1), " +
			       "('Twitter', '" + username + "Twitter', 'encryptedPassword2', 'www.twitter.com', '2023-07-04 14:00:00', '2023-07-04 14:00:00', " + userId + ", 2), " +
			       "('Instagram', '" + username + "Instagram', 'encryptedPassword3', 'www.instagram.com', '2023-07-04 14:00:00', '2023-07-04 14:00:00', " + userId + ", 3), " +
			       "('LinkedIn', '" + username + "LinkedIn', 'encryptedPassword4', 'www.linkedin.com', '2023-07-04 14:00:00', '2023-07-04 14:00:00', " + userId + ", 4), " +
			       "('Reddit', '" + username + "Reddit', 'encryptedPassword5', 'www.reddit.com', '2023-07-04 14:00:00', '2023-07-04 14:00:00', " + userId + ", 5)", connection))
		{
			command.ExecuteNonQuery();
		}
	}

}