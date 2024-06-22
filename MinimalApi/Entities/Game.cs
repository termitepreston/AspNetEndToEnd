namespace MinimalApi.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required decimal Price { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public ICollection<Genre> Genres { get; } = [];
    public ICollection<GameGenre> GameGenres { get; } = [];
}