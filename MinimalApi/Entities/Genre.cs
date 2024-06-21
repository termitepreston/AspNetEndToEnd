namespace MinimalApi.Entities;

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Game> Games { get; } = [];
    public ICollection<GameGenre> GameGenres { get; } = [];
}