namespace Example4;

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

    public void Add(Hero hero)
    {
        if (string.IsNullOrWhiteSpace(hero.Name))
            throw new ValidationException("Name is required");

        if (string.IsNullOrWhiteSpace(hero.Power))
            throw new ValidationException("Power is required");

        _heroes.Add(hero);
    }
}
