using Example5;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HeroService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Simplified API with correct metadata
app.MapPost("/heroes", (Hero hero, HeroService service) =>
    {
        service.Add(hero);
        return TypedResults.Created();
    })
    .WithName("CreateHero")
    .WithOpenApi();

app.Run();
