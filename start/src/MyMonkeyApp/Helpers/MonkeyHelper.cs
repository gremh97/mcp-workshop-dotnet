using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Static helper class for managing monkey species data and operations.
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> _monkeys = InitializeMonkeys();

    /// <summary>
    /// Returns all available monkey species.
    /// </summary>
    /// <returns>A collection of all monkey species.</returns>
    public static IEnumerable<Monkey> GetMonkeys()
    {
        return _monkeys.AsReadOnly();
    }

    /// <summary>
    /// Finds a specific monkey by name (case-insensitive).
    /// </summary>
    /// <param name="name">The name of the monkey to search for.</param>
    /// <returns>The monkey if found, otherwise null.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return _monkeys.FirstOrDefault(m => 
            m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Returns a randomly selected monkey species.
    /// </summary>
    /// <returns>A randomly selected monkey.</returns>
    public static Monkey GetRandomMonkey()
    {
        var random = new Random();
        var index = random.Next(_monkeys.Count);
        return _monkeys[index];
    }

    /// <summary>
    /// Initializes the collection with interesting monkey species data.
    /// </summary>
    private static List<Monkey> InitializeMonkeys()
    {
        return new List<Monkey>
        {
            new Monkey
            {
                Name = "Golden Lion Tamarin",
                Location = "Brazil (Atlantic coastal forests)",
                Population = 3000,
                ConservationStatus = "Endangered",
                Details = "Known for their magnificent golden mane, these small primates are excellent acrobats and live in family groups."
            },
            new Monkey
            {
                Name = "Proboscis Monkey",
                Location = "Borneo (mangrove forests)",
                Population = 7000,
                ConservationStatus = "Endangered",
                Details = "Famous for their large, distinctive noses and reddish fur. Males have much larger noses than females."
            },
            new Monkey
            {
                Name = "Japanese Macaque",
                Location = "Japan (mountains and forests)",
                Population = 114000,
                ConservationStatus = "Least Concern",
                Details = "Also known as snow monkeys, they're famous for bathing in hot springs during winter."
            },
            new Monkey
            {
                Name = "Howler Monkey",
                Location = "Central and South America (rainforests)",
                Population = 100000,
                ConservationStatus = "Least Concern",
                Details = "Known for their loud calls that can be heard up to 3 miles away. They have the loudest call of any land animal."
            },
            new Monkey
            {
                Name = "Spider Monkey",
                Location = "Central and South America (tropical rainforests)",
                Population = 250000,
                ConservationStatus = "Vulnerable",
                Details = "Named for their long, slender limbs and lack of thumbs. They're excellent brachiators, swinging through trees with ease."
            },
            new Monkey
            {
                Name = "Mandrill",
                Location = "Africa (tropical rainforests of Equatorial Guinea, Equatorial Africa)",
                Population = 20000,
                ConservationStatus = "Vulnerable",
                Details = "The largest living primate species. Males have colorful faces with bright red and blue markings."
            },
            new Monkey
            {
                Name = "Capuchin Monkey",
                Location = "Central and South America (forests)",
                Population = 50000,
                ConservationStatus = "Least Concern",
                Details = "Highly intelligent primates known for using tools. Often featured in movies and as helper animals."
            },
            new Monkey
            {
                Name = "Vervet Monkey",
                Location = "Africa (savannas, woodlands, and forests)",
                Population = 500000,
                ConservationStatus = "Least Concern",
                Details = "Known for their distinct alarm calls for different predators and their complex social structures."
            }
        };
    }
}