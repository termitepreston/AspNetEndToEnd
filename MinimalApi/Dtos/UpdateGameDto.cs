using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Dtos;

public record class UpdateGameDto(
    [MaxLength(200)] string? Title,
    List<int>? Genres,
    [Range(0, 200)] decimal? Price,
    [Range(typeof(DateOnly), "1980-01-01", "2024-06-24")] DateOnly? ReleaseDate);