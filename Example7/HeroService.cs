using Ardalis.Result;

namespace Example7;

public record Hero(string Name, string Power);

public class HeroService
{
    private readonly List<Hero> _heroes =
    [
        new Hero("Superman", "Strength"),
        new Hero("Batman", "Money"),
        new Hero("Flash", "Speed")
    ];

    public Hero? GetByName(string name) => _heroes.FirstOrDefault(h => h.Name == name);

    public Result Add(Hero hero)
    {
        if (string.IsNullOrWhiteSpace(hero.Name))
            return Result.Invalid(new ValidationError("Name is required"));

        if (string.IsNullOrWhiteSpace(hero.Power))
            return Result.Invalid(new ValidationError("Power is required"));

        _heroes.Add(hero);

        return Result.Success();
    }
}
