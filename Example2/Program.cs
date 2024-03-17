using Example2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HeroService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// API with incorrect metadata (returns 201, but OpenAPI states 200)
app.MapPost("/heroes", (Hero hero, HeroService service) =>
    {
        service.Add(hero);
        return Results.Created();
    })
    .WithName("CreateHero")
    .WithOpenApi();

app.Run();
