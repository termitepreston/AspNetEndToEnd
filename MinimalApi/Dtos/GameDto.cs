namespace MinimalApi.Dtos;

public class GameDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public IEnumerable<int> Genres { get; set; } = [];
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}