using System.Net.Mime;
using AutoMapper;
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
        // First track the genres we are interested in.
        // If the request includes genres that don't exist, ignore them.

        var requiredGenres = db.Genres
                                .Where(rg => newGame.Genres.Any(pg => pg == rg.Id));

        var trackedGame = db.Games.Add(new Game()
        {
            Title = newGame.Title,
            Genres = [.. requiredGenres],
            Price = newGame.Price,
            ReleaseDate = newGame.ReleaseDate
        });

        db.SaveChanges();

        var game = mapper.Map<GameDto>(trackedGame.Entity);


        return CreatedAtAction(nameof(Retrieve), new { id = game.Id }, game);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(UpdateGameDto updateGame, int id)
    {
        var game = await db.Games
                    .Where(game => game.Id == id)
                    .Include(game => game.Genres)
                    .SingleAsync();

        if (game == null)
        {
            return NotFound();
        }

        game.Title = updateGame?.Title ?? game.Title;
        game.Price = updateGame?.Price ?? game.Price;
        game.ReleaseDate = updateGame?.ReleaseDate ?? game.ReleaseDate;

        if (updateGame is not null)
        {
            var requestedGenres = await db.Genres
                                   .Where(gd => updateGame.Genres.Any(gr => gr == gd.Id))
                                   .ToListAsync();


            game.Genres = requestedGenres;
        }


        await db.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var game = await db.Games.Where(game => game.Id == id).SingleAsync();

        db.Games.Remove(game);

        await db.SaveChangesAsync();

        return NoContent();
    }
}