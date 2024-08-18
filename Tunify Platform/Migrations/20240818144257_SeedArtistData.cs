using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedArtistData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_songs",
                table: "songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistSongs",
                table: "PlaylistSongs");

            migrationBuilder.DropColumn(
                name: "PlaylistSongsId",
                table: "PlaylistSongs");

            migrationBuilder.RenameTable(
                name: "songs",
                newName: "Songs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "SongsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistSongs",
                table: "PlaylistSongs",
                columns: new[] { "Song_Id", "Playlist_Id" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistsId", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "If not me then who? If not now then when?", "Jadal" },
                    { 2, "Rock and Roll band from Manchester", "Oasis" },
                    { 3, "Singer-songwriter known for her deep, soulful voice", "Adele" },
                    { 4, "British rock band known for their melodic songs", "Coldplay" }
                });

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistsId",
                keyValue: 1,
                column: "Playlists_Name",
                value: "Love is Pain");

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistsId",
                keyValue: 2,
                column: "Playlists_Name",
                value: "PainHub");

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 1,
                columns: new[] { "Genre", "Title" },
                values: new object[] { "Romance", "Love" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 2,
                columns: new[] { "Genre", "Title" },
                values: new object[] { "Romance", "Alo" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 3,
                columns: new[] { "Genre", "Title" },
                values: new object[] { "Romance", "Pain" });

            migrationBuilder.UpdateData(
                table: "Songs",
                keyColumn: "SongsId",
                keyValue: 4,
                columns: new[] { "Genre", "Title" },
                values: new object[] { "Romance", "Aloo" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Name",
                value: "Nory");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Name",
                value: "Misk");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Name",
                value: "Noor");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Name",
                value: "Aya");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Artist_Id",
                table: "Songs",
                column: "Artist_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongs_Playlist_Id",
                table: "PlaylistSongs",
                column: "Playlist_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Playlists_Playlist_Id",
                table: "PlaylistSongs",
                column: "Playlist_Id",
                principalTable: "Playlists",
                principalColumn: "PlaylistsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSongs_Songs_Song_Id",
                table: "PlaylistSongs",
                column: "Song_Id",
                principalTable: "Songs",
                principalColumn: "SongsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_Artist_Id",
                table: "Songs",
                column: "Artist_Id",
                principalTable: "Artists",
                principalColumn: "ArtistsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Playlists_Playlist_Id",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSongs_Songs_Song_Id",
                table: "PlaylistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_Artist_Id",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_Artist_Id",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistSongs",
                table: "PlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSongs_Playlist_Id",
                table: "PlaylistSongs");

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistsId",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "songs");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistSongsId",
                table: "PlaylistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_songs",
                table: "songs",
                column: "SongsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistSongs",
                table: "PlaylistSongs",
                column: "PlaylistSongsId");

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistsId",
                keyValue: 1,
                column: "Playlists_Name",
                value: "love is pain");

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistsId",
                keyValue: 2,
                column: "Playlists_Name",
                value: "painHub");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Name",
                value: "nory");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Name",
                value: "misk");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Name",
                value: "noor");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Name",
                value: "aya");

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 1,
                columns: new[] { "Genre", "Title" },
                values: new object[] { "romance", "love" });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 2,
                columns: new[] { "Genre", "Title" },
                values: new object[] { "romance", "alo" });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 3,
                columns: new[] { "Genre", "Title" },
                values: new object[] { "romance", "pain" });

            migrationBuilder.UpdateData(
                table: "songs",
                keyColumn: "SongsId",
                keyValue: 4,
                columns: new[] { "Genre", "Title" },
                values: new object[] { "romance", "aloo" });
        }
    }
}
