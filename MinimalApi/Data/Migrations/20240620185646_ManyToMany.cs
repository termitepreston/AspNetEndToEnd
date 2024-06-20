using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GamesId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenresId",
                table: "GameGenre");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "GameGenre",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GameGenre",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenre_GenresId",
                table: "GameGenre",
                newName: "IX_GameGenre_GenreId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GameId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenreId",
                table: "GameGenre");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GameGenre",
                newName: "GenresId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GameGenre",
                newName: "GamesId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenre_GenreId",
                table: "GameGenre",
                newName: "IX_GameGenre_GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Games_GamesId",
                table: "GameGenre",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genres_GenresId",
                table: "GameGenre",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
