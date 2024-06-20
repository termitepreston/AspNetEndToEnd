namespace MinimalApi.Dtos;

public record class CreateGameDto(string Title, string Genre, decimal Price, DateOnly ReleaseDate);