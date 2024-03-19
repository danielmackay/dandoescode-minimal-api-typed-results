using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Example5;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HeroService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// API with correct metadata, type safety
app.MapPost("/heroes", Results<BadRequest<string>, Created>(Hero hero, HeroService service) =>
    {
        if (string.IsNullOrWhiteSpace(hero.Name))
            return TypedResults.BadRequest("Name is required");

        service.Add(hero);

        return TypedResults.Created();
    })
    .WithName("CreateHero")
    .WithOpenApi();

app.Run();
