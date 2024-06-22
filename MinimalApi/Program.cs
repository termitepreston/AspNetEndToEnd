using AutoMapper;
using MinimalApi.Controllers;
using MinimalApi.Data;
using MinimalApi.Entities;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");

builder.Services.AddSqlite<GameStoreContext>(connString);
builder.Services.AddScoped<GameStoreContext>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();


app.MapControllers();


app.Run();