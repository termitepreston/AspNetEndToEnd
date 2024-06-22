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




[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("[controller]")]
public class GamesController(GameStoreContext db, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [Route("{id?}")]
    public async Task<IActionResult> Retrieve(int? id)
    {
        if (id != null)
        {
            var game = await db.Games.Include(game => game.GameGenres).Where(game => game.Id == id).FirstOrDefaultAsync();

            if (game == null)
            {
                return NotFound();
            }

            var gameDto = mapper.Map<GameDto>(game);

            return Ok(gameDto);
        }

        var games = await db.Games.Include(game => game.GameGenres).ToListAsync();

        var gameDtos = mapper.Map<IEnumerable<Game>, IEnumerable<GameDto>>(games);


        return Ok(gameDtos);
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