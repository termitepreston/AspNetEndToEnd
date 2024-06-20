using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Dtos;

namespace MinimalApi.Controllers;


/*
    1. Constructor injection of in memory db.
    2. token interpolation.
*/

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("[controller]")]
public class GamesController(GamesInMemoryDb db) : ControllerBase
{
    [HttpGet]
    [Route("{id?}")]
    public IActionResult Retrieve(int? id) => id is null ? Ok(db.Games) : Ok(db.Games.Find(g => g.Id == id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(CreateGameDto newGame)
    {
        GameDto game = new(
                    db.Games.Count + 1,
                    newGame.Title,
                    newGame.Genre,
                    newGame.Price,
                    newGame.ReleaseDate
                );



        db.Games.Add(game);

        return CreatedAtAction(nameof(Retrieve), new { id = game.Id }, game);


    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(UpdateGameDto updateGame, int id)
    {
        var index = db.Games.FindIndex(game => game.Id == id);

        if (index == -1)
            return NotFound();

        db.Games[index] = new(
            id,
            updateGame.Title,
            updateGame.Genre,
            updateGame.Price,
            updateGame.ReleaseDate
        );

        return NoContent();
    }
}