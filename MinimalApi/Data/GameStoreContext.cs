using Microsoft.EntityFrameworkCore;
using MinimalApi.Entities;

namespace MinimalApi.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite key.
        modelBuilder.Entity<GameGenre>()
            .HasKey(gg => new { gg.GameId, gg.GenreId });

        modelBuilder.Entity<Game>()
            .HasMany(e => e.Genres)
            .WithMany(e => e.Games)
            .UsingEntity<GameGenre>();


        modelBuilder.Entity<Genre>().
            HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Adventure" },
                new { Id = 3, Name = "Role-playing (RPG)" },
                new { Id = 4, Name = "Simulation" },
                new { Id = 5, Name = "Strategy" },
                new { Id = 6, Name = "Sports" },
                new { Id = 7, Name = "Puzzle" },
                new { Id = 8, Name = "Racing" },
                new { Id = 9, Name = "Fighting" },
                new { Id = 10, Name = "First-person shooter (FPS)" },
                new { Id = 11, Name = "Third-person shooter (TPS)" },
                new { Id = 12, Name = "Platformer" },
                new { Id = 13, Name = "Open world" },
                new { Id = 14, Name = "Sandbox" },
                new { Id = 15, Name = "Massively multiplayer online (MMO)" },
                new { Id = 16, Name = "MMO RPG (MMORPG)" },
                new { Id = 17, Name = "Real-time strategy (RTS)" },
                new { Id = 18, Name = "Turn-based strategy (TBS)" },
                new { Id = 19, Name = "4X games (explore, expand, exploit, and exterminate)" },
                new { Id = 20, Name = "City-building" },
                new { Id = 21, Name = "Life simulation" },
                new { Id = 22, Name = "Vehicle simulation" },
                new { Id = 23, Name = "Point-and-click adventure" },
                new { Id = 24, Name = "Text-based adventure" },
                new { Id = 25, Name = "Graphic adventure" },
                new { Id = 26, Name = "Match-three" },
                new { Id = 27, Name = "Physics-based" },
                new { Id = 28, Name = "Word games" },
                new { Id = 29, Name = "Battle Royale" },
                new { Id = 30, Name = "Auto battler" },
                new { Id = 31, Name = "Art game" },
                new { Id = 32, Name = "Artillery game" },
                new { Id = 33, Name = "Board game or card game" },
                new { Id = 34, Name = "Casual" },
                new { Id = 35, Name = "Educational" },
                new { Id = 36, Name = "Fitness" },
                new { Id = 37, Name = "Music" },
                new { Id = 38, Name = "Social network game" },
                new { Id = 39, Name = "Social simulation game" },
                new { Id = 40, Name = "Souls-like" },
                new { Id = 41, Name = "Space flight simulation" },
                new { Id = 42, Name = "Stealth" },
                new { Id = 43, Name = "Serious game" },
                new { Id = 44, Name = "Shoot 'em up" }
            );

        modelBuilder.Entity<Game>()
            .HasData(
                 new { Id = 1, Title = "Hitman: Absolution", Price = 60.0M, ReleaseDate = new DateOnly(2012, 8, 25) },
                new { Id = 2, Title = "The Witcher 3: Wild Hunt", Price = 50.0M, ReleaseDate = new DateOnly(2015, 5, 19) },
                new { Id = 3, Title = "Red Dead Redemption 2", Price = 70.0M, ReleaseDate = new DateOnly(2018, 10, 26) },
                new { Id = 4, Title = "Grand Theft Auto V", Price = 30.0M, ReleaseDate = new DateOnly(2013, 9, 17) },
                new { Id = 5, Title = "Assassin's Creed Odyssey", Price = 50.0M, ReleaseDate = new DateOnly(2018, 10, 5) },
                new { Id = 6, Title = "Cyberpunk 2077", Price = 60.0M, ReleaseDate = new DateOnly(2020, 12, 10) },
                new { Id = 7, Title = "Dark Souls III", Price = 40.0M, ReleaseDate = new DateOnly(2016, 4, 12) },
                new { Id = 8, Title = "Resident Evil Village", Price = 60.0M, ReleaseDate = new DateOnly(2021, 5, 7) },
                new { Id = 9, Title = "Elden Ring", Price = 60.0M, ReleaseDate = new DateOnly(2022, 2, 25) },
                new { Id = 10, Title = "Horizon Zero Dawn", Price = 40.0M, ReleaseDate = new DateOnly(2017, 2, 28) },
                new { Id = 11, Title = "God of War", Price = 40.0M, ReleaseDate = new DateOnly(2018, 4, 20) }
            );

        modelBuilder.Entity<GameGenre>()
            .HasData(
                new { GameId = 1, GenreId = 1 },
                new { GameId = 1, GenreId = 42 },
                new { GameId = 2, GenreId = 2 },
                new { GameId = 2, GenreId = 3 },
                new { GameId = 3, GenreId = 1 },
                new { GameId = 3, GenreId = 11 },
                new { GameId = 3, GenreId = 34 },
                new { GameId = 4, GenreId = 1 },
                new { GameId = 4, GenreId = 34 },
                new { GameId = 5, GenreId = 2 },
                new { GameId = 6, GenreId = 1 },
                new { GameId = 7, GenreId = 42 },
                new { GameId = 8, GenreId = 11 },
                new { GameId = 9, GenreId = 40 },
                new { GameId = 10, GenreId = 14 },
                new { GameId = 11, GenreId = 1 }

            );
    }
}