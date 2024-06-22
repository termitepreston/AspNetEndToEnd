using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyBasics5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GameId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GameGenre_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 60.0m, new DateOnly(2012, 8, 25), "Hitman: Absolution" },
                    { 2, 50.0m, new DateOnly(2015, 5, 19), "The Witcher 3: Wild Hunt" },
                    { 3, 70.0m, new DateOnly(2018, 10, 26), "Red Dead Redemption 2" },
                    { 4, 30.0m, new DateOnly(2013, 9, 17), "Grand Theft Auto V" },
                    { 5, 50.0m, new DateOnly(2018, 10, 5), "Assassin's Creed Odyssey" },
                    { 6, 60.0m, new DateOnly(2020, 12, 10), "Cyberpunk 2077" },
                    { 7, 40.0m, new DateOnly(2016, 4, 12), "Dark Souls III" },
                    { 8, 60.0m, new DateOnly(2021, 5, 7), "Resident Evil Village" },
                    { 9, 60.0m, new DateOnly(2022, 2, 25), "Elden Ring" },
                    { 10, 40.0m, new DateOnly(2017, 2, 28), "Horizon Zero Dawn" },
                    { 11, 40.0m, new DateOnly(2018, 4, 20), "God of War" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Role-Playing" },
                    { 4, "Strategy" },
                    { 5, "Simulation" },
                    { 6, "Sports" },
                    { 7, "Puzzle" },
                    { 8, "Racing" },
                    { 9, "Fighting" },
                    { 10, "Horror" },
                    { 11, "Music" },
                    { 12, "Platformer" },
                    { 13, "Shooter" },
                    { 14, "Stealth" },
                    { 15, "Educational" },
                    { 16, "MMO" },
                    { 17, "Sandbox" },
                    { 18, "Visual Novel" },
                    { 19, "Tactical" },
                    { 20, "Survival" }
                });

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[,]
                {
                    { 1, 14 },
                    { 1, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenreId",
                table: "GameGenre",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
