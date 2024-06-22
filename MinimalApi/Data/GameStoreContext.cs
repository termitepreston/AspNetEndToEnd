using Microsoft.EntityFrameworkCore;
using MinimalApi.Entities;

namespace MinimalApi.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<GameGenre> GameGenres => Set<GameGenre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Game>()
            .HasMany(e => e.Genres)
            .WithMany(e => e.Games)
            .UsingEntity<GameGenre>();

        modelBuilder.Entity<Genre>().
            HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Adventure" },
                new { Id = 3, Name = "Role-Playing" },
                new { Id = 4, Name = "Strategy" },
                new { Id = 5, Name = "Simulation" },
                new { Id = 6, Name = "Sports" },
                new { Id = 7, Name = "Puzzle" },
                new { Id = 8, Name = "Racing" },
                new { Id = 9, Name = "Fighting" },
                new { Id = 10, Name = "Horror" },
                new { Id = 11, Name = "Music" },
                new { Id = 12, Name = "Platformer" },
                new { Id = 13, Name = "Shooter" },
                new { Id = 14, Name = "Stealth" },
                new { Id = 15, Name = "Educational" },
                new { Id = 16, Name = "MMO" },
                new { Id = 17, Name = "Sandbox" },
                new { Id = 18, Name = "Visual Novel" },
                new { Id = 19, Name = "Tactical" },
                new { Id = 20, Name = "Survival" }
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
                new { GameId = 1, GenreId = 14 },
                new { GameId = 1, GenreId = 17 }
            );

    }
}