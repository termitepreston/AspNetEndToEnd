﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalApi.Data;

#nullable disable

namespace MinimalApi.Data.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    [Migration("20240621124335_PopulateGamesWithSeedData")]
    partial class PopulateGamesWithSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("MinimalApi.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 60.0m,
                            ReleaseDate = new DateOnly(2012, 8, 25),
                            Title = "Hitman: Absolution"
                        },
                        new
                        {
                            Id = 2,
                            Price = 50.0m,
                            ReleaseDate = new DateOnly(2015, 5, 19),
                            Title = "The Witcher 3: Wild Hunt"
                        },
                        new
                        {
                            Id = 3,
                            Price = 70.0m,
                            ReleaseDate = new DateOnly(2018, 10, 26),
                            Title = "Red Dead Redemption 2"
                        },
                        new
                        {
                            Id = 4,
                            Price = 30.0m,
                            ReleaseDate = new DateOnly(2013, 9, 17),
                            Title = "Grand Theft Auto V"
                        },
                        new
                        {
                            Id = 5,
                            Price = 50.0m,
                            ReleaseDate = new DateOnly(2018, 10, 5),
                            Title = "Assassin's Creed Odyssey"
                        },
                        new
                        {
                            Id = 6,
                            Price = 60.0m,
                            ReleaseDate = new DateOnly(2020, 12, 10),
                            Title = "Cyberpunk 2077"
                        },
                        new
                        {
                            Id = 7,
                            Price = 40.0m,
                            ReleaseDate = new DateOnly(2016, 4, 12),
                            Title = "Dark Souls III"
                        },
                        new
                        {
                            Id = 8,
                            Price = 60.0m,
                            ReleaseDate = new DateOnly(2021, 5, 7),
                            Title = "Resident Evil Village"
                        },
                        new
                        {
                            Id = 9,
                            Price = 60.0m,
                            ReleaseDate = new DateOnly(2022, 2, 25),
                            Title = "Elden Ring"
                        },
                        new
                        {
                            Id = 10,
                            Price = 40.0m,
                            ReleaseDate = new DateOnly(2017, 2, 28),
                            Title = "Horizon Zero Dawn"
                        },
                        new
                        {
                            Id = 11,
                            Price = 40.0m,
                            ReleaseDate = new DateOnly(2018, 4, 20),
                            Title = "God of War"
                        });
                });

            modelBuilder.Entity("MinimalApi.Entities.GameGenre", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GameGenre");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 1,
                            GenreId = 42
                        },
                        new
                        {
                            GameId = 2,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 2,
                            GenreId = 3
                        },
                        new
                        {
                            GameId = 3,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 3,
                            GenreId = 11
                        },
                        new
                        {
                            GameId = 3,
                            GenreId = 34
                        },
                        new
                        {
                            GameId = 4,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 4,
                            GenreId = 34
                        },
                        new
                        {
                            GameId = 5,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 6,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 7,
                            GenreId = 42
                        },
                        new
                        {
                            GameId = 8,
                            GenreId = 11
                        },
                        new
                        {
                            GameId = 9,
                            GenreId = 40
                        },
                        new
                        {
                            GameId = 10,
                            GenreId = 14
                        },
                        new
                        {
                            GameId = 11,
                            GenreId = 1
                        });
                });

            modelBuilder.Entity("MinimalApi.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Role-playing (RPG)"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Simulation"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Puzzle"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Fighting"
                        },
                        new
                        {
                            Id = 10,
                            Name = "First-person shooter (FPS)"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Third-person shooter (TPS)"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Platformer"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Open world"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Sandbox"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Massively multiplayer online (MMO)"
                        },
                        new
                        {
                            Id = 16,
                            Name = "MMO RPG (MMORPG)"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Real-time strategy (RTS)"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Turn-based strategy (TBS)"
                        },
                        new
                        {
                            Id = 19,
                            Name = "4X games (explore, expand, exploit, and exterminate)"
                        },
                        new
                        {
                            Id = 20,
                            Name = "City-building"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Life simulation"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Vehicle simulation"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Point-and-click adventure"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Text-based adventure"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Graphic adventure"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Match-three"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Physics-based"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Word games"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Battle Royale"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Auto battler"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Art game"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Artillery game"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Board game or card game"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Casual"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Educational"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Fitness"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Music"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Social network game"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Social simulation game"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Souls-like"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Space flight simulation"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Stealth"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Serious game"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Shoot 'em up"
                        });
                });

            modelBuilder.Entity("MinimalApi.Entities.GameGenre", b =>
                {
                    b.HasOne("MinimalApi.Entities.Game", "Game")
                        .WithMany("GameGenres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinimalApi.Entities.Genre", "Genre")
                        .WithMany("GameGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MinimalApi.Entities.Game", b =>
                {
                    b.Navigation("GameGenres");
                });

            modelBuilder.Entity("MinimalApi.Entities.Genre", b =>
                {
                    b.Navigation("GameGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
