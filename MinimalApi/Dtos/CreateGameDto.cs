using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Dtos;

public record class CreateGameDto(
    [Required] string Title,
    [Required][MinLength(1)] List<int> Genres,
    [Required][Range(1, 200)] decimal Price,
    [Required] DateOnly ReleaseDate
);