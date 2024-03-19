using Example3;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HeroService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// API with correct metadata and global validation error handler
app.MapPost("/heroes", (Hero hero, HeroService service) =>
    {
        service.Add(hero);
        return Results.Created();
    })
    .WithName("CreateHero")
    .WithOpenApi()
    .Produces(StatusCodes.Status201Created)
    .ProducesValidationProblem();

app.UseExceptionHandler();

app.Run();
