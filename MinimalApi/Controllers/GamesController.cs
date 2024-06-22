using System.Net.Mime;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Dtos;
using MinimalApi.Entities;

namespace MinimalApi.Controllers;


/*
    1. Constructor injection of in memory db.
    2. token interpolation.
*/


public class GameDtoNew
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }

    [SourceMember("GameGenres")]
    public IEnumerable<int> Genres { get; set; } = [];
}

public static class MappingExtensions
{
    public static List<GameDtoNew>? ToDto(this List<Game>? gameEntities)
    {
        List<GameDtoNew>? games = [];

        if (gameEntities == null) return [];

        foreach (var ge in gameEntities)
        {
            games.Add(
                new()
                {
                    Id = ge.Id,
                    Title = ge.Title,
                    Price = ge.Price,
                    ReleaseDate = ge.ReleaseDate,
                    Genres = ge.GameGenres.Select(g => g.GenreId),
                }
            );
        }

        return games;
    }
}


[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("[controller]")]
public class GamesController(GameStoreContext db, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [Route("{id?}")]
    public IActionResult Retrieve(int? id)
    {
        var items = db.Games.Include(game => game.GameGenres).ToList().ToDto();


        return id is null ? base.Ok(items) : base.Ok(db.Games.Find(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(CreateGameDto newGame)
    {
        var f = db.Genres.Where(genre => newGame.Genres.Any(g => genre.Id == g));


        Game game = new()
        {
            Title = newGame.Title,
            Price = newGame.Price,
            ReleaseDate = newGame.ReleaseDate
        };




        return CreatedAtAction(nameof(Retrieve), new { id = game.Id }, game);


    }

    // [HttpPut]
    // [Route("{id}")]
    // public IActionResult Update(UpdateGameDto updateGame, int id)
    // {
    //     var index = dbContext.Games.FindIndex(game => game.Id == id);

    //     if (index == -1)
    //         return NotFound();

    //     dbContext.Games[index] = new(
    //         id,
    //         updateGame.Title,
    //         updateGame.Genre,
    //         updateGame.Price,
    //         updateGame.ReleaseDate
    //     );

    //     return NoContent();
    // }
}