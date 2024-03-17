namespace Example1;

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

    public void Add(Hero hero) => _heroes.Add(hero);
}
