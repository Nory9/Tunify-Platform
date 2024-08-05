using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "PlaylistsId", "Created_Date", "Playlists_Name", "User_Id" },
                values: new object[,]
                {
                    { 1, "20-2-2024", "love is pain", 1 },
                    { 2, "04-7-2024", "painHub", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Join_Date", "Name", "Subscription_ID" },
                values: new object[,]
                {
                    { 1, "noormisk94@gmail.com", "2-2-2022", "nory", 1 },
                    { 2, "noormisk94@gmail.com", "2-2-2022", "misk", 2 },
                    { 3, "misk94@gmail.com", "2-2-2022", "noor", 3 },
                    { 4, "aya94@gmail.com", "2-2-2022", "aya", 4 }
                });

            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "SongsId", "Album_Id", "Artist_Id", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "2:00m", "romance", "love" },
                    { 2, 1, 2, "2:54m", "romance", "alo" },
                    { 3, 1, 1, "3:30m", "romance", "pain" },
                    { 4, 1, 1, "3:50m", "romance", "aloo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 4);
        }
    }
}
