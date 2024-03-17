using Example1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HeroService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Basic API
app.MapPost("/heroes", (Hero hero, HeroService service) => { service.Add(hero); })
    .WithName("CreateHero")
    .WithOpenApi();

app.Run();
