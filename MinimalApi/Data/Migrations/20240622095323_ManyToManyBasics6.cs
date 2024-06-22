using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyBasics6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GameId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenreId",
                table: "GameGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameGenre",
                table: "GameGenre");

            migrationBuilder.RenameTable(
                name: "GameGenre",
                newName: "GameGenres");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenre_GenreId",
                table: "GameGenres",
                newName: "IX_GameGenres_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameGenres",
                table: "GameGenres",
                columns: new[] { "GameId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Games_GameId",
                table: "GameGenres",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenres_Genres_GenreId",
                table: "GameGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Games_GameId",
                table: "GameGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenres_Genres_GenreId",
                table: "GameGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameGenres",
                table: "GameGenres");

            migrationBuilder.RenameTable(
                name: "GameGenres",
                newName: "GameGenre");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenres_GenreId",
                table: "GameGenre",
                newName: "IX_GameGenre_GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameGenre",
                table: "GameGenre",
                columns: new[] { "GameId", "GenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Games_GameId",
                table: "GameGenre",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genres_GenreId",
                table: "GameGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
