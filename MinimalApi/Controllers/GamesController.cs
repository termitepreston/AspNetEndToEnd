using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Data;
using MinimalApi.Dtos;
using MinimalApi.Entities;

namespace MinimalApi.Controllers;


/*
    1. Constructor injection of in memory db.
    2. token interpolation.
*/

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("[controller]")]
public class GamesController(GameStoreContext dbContext) : ControllerBase
{
    [HttpGet]
    [Route("{id?}")]
    public IActionResult Retrieve(int? id) => id is null ? Ok(dbContext.Games) : Ok(dbContext.Games.Find(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(CreateGameDto newGame)
    {
        var f = dbContext.Genres.Where(genre => newGame.Genres.Any(g => genre.Id == g));


        Game game = new()
        {
            Title = newGame.Title,
            Price = newGame.Price,
            Genres = [.. f],
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