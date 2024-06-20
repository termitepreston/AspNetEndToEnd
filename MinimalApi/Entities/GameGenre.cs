namespace MinimalApi.Entities;

public class GameGenre
{
    public required int GameId { get; set; }
    public required Game Game { get; set; }
    public required int GenreId { get; set; }
    public required Genre Genre { get; set; }
}