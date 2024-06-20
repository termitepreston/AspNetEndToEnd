namespace MinimalApi.Entities;

public class Game
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required ICollection<GameGenre> GameGenres { get; set; }

    public required decimal Price { get; set; }

    public required DateOnly ReleaseDate { get; set; }
}