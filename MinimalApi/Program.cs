using MinimalApi.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<GamesInMemoryDb>();

var app = builder.Build();


app.MapControllers();


app.Run();


public class GamesInMemoryDb
{
    private readonly List<GameDto> _games;

    public GamesInMemoryDb()
    {
        _games = [
            new (1, "FIFA 23", "Sports", 60.00M, new (2023, 5, 12)),
            new (2, "Hitman: Absolution", "Action Stealth", 40.0M, new(2012, 11, 05))
        ];

    }
    public List<GameDto> Games { get => _games; }
}