using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Example6;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HeroService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// API with correct metadata, type safety, and no global exception handling
app.MapPost("/heroes", Results<BadRequest<string>, Created>(Hero hero, HeroService service) =>
    {
        var result = service.Add(hero);
        if (result.Status == ResultStatus.Invalid)
            return TypedResults.BadRequest(result.ValidationErrors[0].ErrorMessage);

        return TypedResults.Created();
    })
    .WithName("CreateHero")
    .WithOpenApi();

app.Run();
