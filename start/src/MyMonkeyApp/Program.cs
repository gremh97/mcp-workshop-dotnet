using MyMonkeyApp.Helpers;

namespace MyMonkeyApp;

/// <summary>
/// Main entry point for the Monkey Console Application.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Starting Monkey Console Application...");
        Console.WriteLine();
        
        DisplayWelcomeBanner();
        
        try
        {
            RunInteractiveMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            Console.ResetColor();
        }
        
        Console.WriteLine();
        Console.WriteLine("Thank you for using the Monkey Console Application!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// Displays the ASCII art welcome banner.
    /// </summary>
    private static void DisplayWelcomeBanner()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    ╔══════════════════════════════════════════════════════════════════╗
    ║                                                                  ║
    ║    🐵  MONKEY CONSOLE APPLICATION  🐵                            ║
    ║                                                                  ║
    ║       🌿 Explore the World of Monkeys 🌿                        ║
    ║                                                                  ║
    ║      🎯 Learn about different monkey species                     ║
    ║      🔍 Search for specific monkeys                              ║
    ║      🎲 Discover random monkey facts                             ║
    ║                                                                  ║
    ╚══════════════════════════════════════════════════════════════════╝
        ");
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// Runs the main interactive menu loop.
    /// </summary>
    private static void RunInteractiveMenu()
    {
        bool keepRunning = true;
        
        while (keepRunning)
        {
            DisplayMenu();
            Console.Write("Enter your choice (1-4): ");
            
            var input = Console.ReadLine()?.Trim();
            Console.WriteLine();
            
            switch (input)
            {
                case "1":
                    ListAllMonkeys();
                    break;
                case "2":
                    SearchMonkeyByName();
                    break;
                case "3":
                    ShowRandomMonkey();
                    break;
                case "4":
                    keepRunning = false;
                    break;
                default:
                    ShowErrorMessage("Invalid choice. Please enter 1, 2, 3, or 4.");
                    break;
            }
            
            if (keepRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                DisplayWelcomeBanner();
            }
        }
    }

    /// <summary>
    /// Displays the main menu options.
    /// </summary>
    private static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("═══════════════════════════════════════");
        Console.WriteLine("              MAIN MENU");
        Console.WriteLine("═══════════════════════════════════════");
        Console.ResetColor();
        
        Console.WriteLine("1. 📋 List all monkeys");
        Console.WriteLine("2. 🔍 Search for monkey by name");
        Console.WriteLine("3. 🎲 Get random monkey");
        Console.WriteLine("4. 🚪 Exit application");
        Console.WriteLine();
    }

    /// <summary>
    /// Lists all available monkey species.
    /// </summary>
    private static void ListAllMonkeys()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🐵 ALL MONKEY SPECIES 🐵");
        Console.WriteLine("═════════════════════════");
        Console.ResetColor();
        
        var monkeys = MonkeyHelper.GetMonkeys();
        var count = 0;
        
        foreach (var monkey in monkeys)
        {
            count++;
            Console.WriteLine($"{count}. {monkey}");
            Console.WriteLine($"   Details: {monkey.Details}");
            Console.WriteLine();
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Total species: {count}");
        Console.ResetColor();
    }

    /// <summary>
    /// Searches for a monkey by name with user input.
    /// </summary>
    private static void SearchMonkeyByName()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("🔍 SEARCH MONKEY BY NAME 🔍");
        Console.WriteLine("════════════════════════════");
        Console.ResetColor();
        
        Console.Write("Enter monkey name to search: ");
        var searchName = Console.ReadLine()?.Trim();
        
        if (string.IsNullOrWhiteSpace(searchName))
        {
            ShowErrorMessage("Please enter a valid monkey name.");
            return;
        }
        
        Console.WriteLine();
        var monkey = MonkeyHelper.GetMonkeyByName(searchName);
        
        if (monkey != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Monkey found!");
            Console.ResetColor();
            Console.WriteLine();
            DisplayMonkeyDetails(monkey);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"❌ No monkey found with name '{searchName}'.");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("💡 Tip: Try searching for one of these monkeys:");
            
            var allMonkeys = MonkeyHelper.GetMonkeys();
            foreach (var m in allMonkeys.Take(3))
            {
                Console.WriteLine($"   • {m.Name}");
            }
        }
    }

    /// <summary>
    /// Shows a random monkey species.
    /// </summary>
    private static void ShowRandomMonkey()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🎲 RANDOM MONKEY DISCOVERY 🎲");
        Console.WriteLine("══════════════════════════════");
        Console.ResetColor();
        
        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        Console.WriteLine("🎯 Here's a randomly selected monkey:");
        Console.WriteLine();
        DisplayMonkeyDetails(randomMonkey);
    }

    /// <summary>
    /// Displays detailed information about a specific monkey.
    /// </summary>
    /// <param name="monkey">The monkey to display details for.</param>
    private static void DisplayMonkeyDetails(Models.Monkey monkey)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"🐵 {monkey.Name}");
        Console.WriteLine("".PadRight(monkey.Name.Length + 2, '═'));
        Console.ResetColor();
        
        Console.WriteLine($"📍 Location: {monkey.Location}");
        Console.WriteLine($"👥 Population: {monkey.Population:N0}");
        Console.WriteLine($"🛡️  Conservation Status: {monkey.ConservationStatus}");
        Console.WriteLine($"📝 Details: {monkey.Details}");
    }

    /// <summary>
    /// Shows an error message in red color.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    private static void ShowErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ {message}");
        Console.ResetColor();
    }
}
