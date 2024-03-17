using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Example7;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HeroService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// API with correct metadata, type safety, and no global exception handling (optimized example)
app.MapPost("/heroes", Results<ValidationProblem, Created>(Hero hero, HeroService service) =>
    {
        var result = service.Add(hero);
        if (result.IsInvalid())
            return TypedResultsExt.ValidationProblem(result);

        return TypedResults.Created();
    })
    .WithName("CreateHero")
    .WithOpenApi();

app.Run();
