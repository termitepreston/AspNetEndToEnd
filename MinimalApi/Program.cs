using MinimalApi.Data;
using StackExchange.Profiling;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");

builder.Services.AddSqlite<GameStoreContext>(connString);
builder.Services.AddScoped<GameStoreContext>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMiniProfiler(options =>
{
    // Route: /profiler/results-index
    options.RouteBasePath = "/profiler";
    options.ColorScheme = ColorScheme.Dark;
    options.EnableServerTimingHeader = true;
    options.TrackConnectionOpenClose = true;
    options.EnableDebugMode = builder.Environment.IsDevelopment();

});



var app = builder.Build();

app.UseMiniProfiler();
app.MapControllers();


app.Run();