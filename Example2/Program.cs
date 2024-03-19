using Example2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HeroService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// API with correct metadata (including global error handler)
app.MapPost("/heroes", (Hero hero, HeroService service) =>
    {
        service.Add(hero);
        return Results.Created();
    })
    .WithName("CreateHero")
    .WithOpenApi()
    .Produces(StatusCodes.Status201Created);

app.Run();
