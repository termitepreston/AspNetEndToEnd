namespace MinimalApi.Entities;

public class Genre
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required ICollection<GameGenre> GameGenres { get; set; }
}