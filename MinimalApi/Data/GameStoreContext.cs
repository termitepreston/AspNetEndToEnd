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

        modelBuilder.Entity<GameGenre>()
            .HasOne(gg => gg.Game)
            .WithMany(game => game.GameGenres)
            .HasForeignKey(gg => gg.GameId);

        modelBuilder.Entity<GameGenre>()
            .HasOne(gg => gg.Genre)
            .WithMany(game => game.GameGenres)
            .HasForeignKey(gg => gg.GenreId);

        modelBuilder.Entity<Genre>().
            HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Adventure" },
                new { Id = 3, Name = "Role-playing" },
                new { Id = 4, Name = "Strategy" },
                new { Id = 5, Name = "Sports" },
                new { Id = 6, Name = "Puzzle" },
                new { Id = 7, Name = "Stealth" },
                new { Id = 8, Name = "Japanese-RPG" },
                new { Id = 9, Name = "MMO" },
                new { Id = 10, Name = "Farming Simulator" },
                new { Id = 11, Name = "Immersive Sim" }
            );
    }
}