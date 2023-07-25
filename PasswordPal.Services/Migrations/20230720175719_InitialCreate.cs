using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PasswordPal.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PasswordCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoredPassword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncryptedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredPassword", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PasswordCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Social" },
                    { 2, "Work" },
                    { 3, "Streaming" },
                    { 4, "Shopping" },
                    { 5, "Gaming" },
                    { 6, "Financial" }
                });

            migrationBuilder.InsertData(
                table: "StoredPassword",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "EncryptedPassword", "Title", "UpdatedAt", "UserId", "Username", "Website" },
                values: new object[,]
                {
                    { 1, 0, "2023-07-04 14:00:00", "encryptedPassword1", "Title1", "2023-07-04 14:00:00", 1, "Username1", "www.website1.com" },
                    { 2, 0, "2023-07-04 14:00:00", "encryptedPassword2", "Title2", "2023-07-04 14:00:00", 2, "Username2", "www.website2.com" },
                    { 3, 0, "2023-07-04 14:00:00", "encryptedPassword3", "Title3", "2023-07-04 14:00:00", 3, "Username3", "www.website3.com" },
                    { 4, 0, "2023-07-04 14:00:00", "encryptedPassword4", "Title4", "2023-07-04 14:00:00", 4, "Username4", "www.website4.com" },
                    { 5, 0, "2023-07-04 14:00:00", "encryptedPassword5", "Title5", "2023-07-04 14:00:00", 5, "Username5", "www.website5.com" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password", "Salt", "Username" },
                values: new object[,]
                {
                    { 1, "testUser1@email.com", "testPassword1", "exampleSalt", "testUser1" },
                    { 2, "testUser2@email.com", "testPassword2", "exampleSalt", "testUser2" },
                    { 3, "testUser3@email.com", "testPassword3", "exampleSalt", "testUser3" },
                    { 4, "testUser4@email.com", "testPassword4", "exampleSalt", "testUser4" },
                    { 5, "testUser5@email.com", "testPassword5", "exampleSalt", "testUser5" },
                    { 6, "a@email.com", "a", "exampleSalt", "a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasswordCategory");

            migrationBuilder.DropTable(
                name: "StoredPassword");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
