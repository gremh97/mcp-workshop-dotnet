using MyMonkeyApp;

namespace MyMonkeyApp;

/// <summary>
/// Main program class for the Monkey Console Application
/// </summary>
public class Program
{
    private static readonly Random _random = new();
    private static readonly string[] _asciiArt = 
    {
        """
        🐵     🙈     🙉     🙊     🐒
           MONKEY BUSINESS!
        """,
        """
            .="=.
          _/.-.-.\\_     _
         ( ( o o ) )    ))
          |/  "  \\|    //
           \\'---'/    //
        """,
        """
             __   __
            /  \\ /  \\   
           | (oo) (oo) |
            \\  <   >  /
             \\  ___  /
              |     |
              | ._. |
             /|     |\\
            ( | .-. | )
              \\___/
        """,
        """
          .-"-.
         /     \\
        | o   o |
         \\  >  /
          '---'
         /     \\
        |  ___  |
        | |   | |
        | |___| |
         \\     /
          '---'
        """,
        """
        🍌 Monkey see... 🍌
        🍌 Monkey do... 🍌
        🍌 Monkey code! 🍌
        """,
        """
           🐒
          /|\\
           |
          / \\
        Monkey!
        """,
        """
        ╔══════════════╗
        ║   🐵 OOOK!   ║
        ╚══════════════╝
        """
    };

    /// <summary>
    /// Main entry point of the application
    /// </summary>
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        DisplayWelcomeMessage();
        
        bool keepRunning = true;
        while (keepRunning)
        {
            DisplayMenu();
            var choice = GetUserChoice();
            
            Console.Clear();
            DisplayRandomAsciiArt();
            
            keepRunning = ProcessMenuChoice(choice);
            
            if (keepRunning)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        DisplayGoodbyeMessage();
    }

    /// <summary>
    /// Displays the welcome message with ASCII art
    /// </summary>
    private static void DisplayWelcomeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        
        Console.WriteLine("""
            ╔══════════════════════════════════════════════════╗
            ║                                                  ║
            ║            🐵 MONKEY CONSOLE APP 🐵              ║
            ║                                                  ║
            ║        Welcome to the Monkey Database!          ║
            ║                                                  ║
            ╚══════════════════════════════════════════════════╝
            """);
        
        Console.ResetColor();
        DisplayRandomAsciiArt();
        
        Console.WriteLine("Loading monkey data...");
        Thread.Sleep(1000); // Simulate loading
        Console.WriteLine($"✅ Loaded {MonkeyHelper.TotalMonkeyCount} monkeys successfully!\n");
        
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();
        Console.Clear();
    }

    /// <summary>
    /// Displays the main menu options
    /// </summary>
    private static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║                   MAIN MENU                     ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine();
        Console.WriteLine("🐵 What would you like to do?");
        Console.WriteLine();
        Console.WriteLine("1️⃣  List all monkeys");
        Console.WriteLine("2️⃣  Get details for a specific monkey by name");
        Console.WriteLine("3️⃣  Get a random monkey");
        Console.WriteLine("4️⃣  View statistics");
        Console.WriteLine("5️⃣  Exit app");
        Console.WriteLine();
        Console.Write("👉 Enter your choice (1-5): ");
    }

    /// <summary>
    /// Gets and validates user input for menu choice
    /// </summary>
    /// <returns>The user's menu choice</returns>
    private static int GetUserChoice()
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
            {
                return choice;
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("❌ Invalid choice! Please enter a number between 1-5: ");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Processes the user's menu choice
    /// </summary>
    /// <param name="choice">The menu choice selected by the user</param>
    /// <returns>True to continue running, false to exit</returns>
    private static bool ProcessMenuChoice(int choice)
    {
        return choice switch
        {
            1 => HandleListAllMonkeys(),
            2 => HandleGetMonkeyByName(),
            3 => HandleGetRandomMonkey(),
            4 => HandleViewStatistics(),
            5 => false, // Exit
            _ => true
        };
    }

    /// <summary>
    /// Handles listing all monkeys
    /// </summary>
    private static bool HandleListAllMonkeys()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🐵 ALL MONKEYS IN THE DATABASE");
        Console.WriteLine("═══════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();

        var monkeys = MonkeyHelper.GetMonkeys();
        
        Console.WriteLine($"📊 Found {monkeys.Count} monkeys:");
        Console.WriteLine();

        foreach (var monkey in monkeys)
        {
            var statusColor = monkey.IsWildSpecies ? ConsoleColor.Green : ConsoleColor.Magenta;
            Console.ForegroundColor = statusColor;
            Console.WriteLine($"🐵 {monkey}");
            Console.ResetColor();
            Console.WriteLine($"   📍 {monkey.Location}");
            Console.WriteLine($"   🚨 Status: {monkey.ConservationStatus}");
            Console.WriteLine();
        }

        return true;
    }

    /// <summary>
    /// Handles getting a specific monkey by name
    /// </summary>
    private static bool HandleGetMonkeyByName()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("🔍 FIND MONKEY BY NAME");
        Console.WriteLine("══════════════════════");
        Console.ResetColor();
        Console.WriteLine();

        Console.Write("Enter the monkey name to search for: ");
        var searchName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(searchName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Please enter a valid monkey name!");
            Console.ResetColor();
            return true;
        }

        var monkey = MonkeyHelper.GetMonkeyByName(searchName);
        
        if (monkey != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Monkey found!");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(monkey.GetDetailedInfo());
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"❓ No monkey found with name '{searchName}'");
            Console.ResetColor();
            Console.WriteLine();
            
            // Try partial search
            var partialMatches = MonkeyHelper.SearchMonkeysByName(searchName).ToList();
            if (partialMatches.Any())
            {
                Console.WriteLine("🔍 Did you mean one of these?");
                foreach (var match in partialMatches)
                {
                    Console.WriteLine($"   • {match.Name}");
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Handles getting a random monkey
    /// </summary>
    private static bool HandleGetRandomMonkey()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🎲 RANDOM MONKEY GENERATOR");
        Console.WriteLine("══════════════════════════");
        Console.ResetColor();
        Console.WriteLine();

        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        
        if (randomMonkey != null)
        {
            Console.WriteLine("🎉 Here's your random monkey:");
            Console.WriteLine();
            Console.WriteLine(randomMonkey.GetDetailedInfo());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"🎲 Random selections so far: {MonkeyHelper.RandomAccessCount}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ No monkeys available!");
            Console.ResetColor();
        }

        return true;
    }

    /// <summary>
    /// Handles viewing collection statistics
    /// </summary>
    private static bool HandleViewStatistics()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("📈 MONKEY COLLECTION STATISTICS");
        Console.WriteLine("═══════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine(MonkeyHelper.GetStatistics());
        
        Console.WriteLine();
        Console.WriteLine("🌿 Wild Species:");
        foreach (var wild in MonkeyHelper.GetWildSpecies())
        {
            Console.WriteLine($"   • {wild.Name} ({wild.Population:N0})");
        }
        
        Console.WriteLine();
        Console.WriteLine("👥 Special Friends:");
        foreach (var friend in MonkeyHelper.GetSpecialFriends())
        {
            Console.WriteLine($"   • {friend.Name} in {friend.Location}");
        }

        return true;
    }

    /// <summary>
    /// Displays random ASCII art
    /// </summary>
    private static void DisplayRandomAsciiArt()
    {
        var randomArt = _asciiArt[_random.Next(_asciiArt.Length)];
        
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(randomArt);
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// Displays goodbye message when exiting
    /// </summary>
    private static void DisplayGoodbyeMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        
        Console.WriteLine("""
            ╔══════════════════════════════════════════════════╗
            ║                                                  ║
            ║            🐵 THANKS FOR VISITING! 🐵            ║
            ║                                                  ║
            ║         Hope you enjoyed the monkeys!           ║
            ║                                                  ║
            ║              🍌 See you later! 🍌               ║
            ║                                                  ║
            ╚══════════════════════════════════════════════════╝
            """);
        
        Console.ResetColor();
        DisplayRandomAsciiArt();
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"📊 Total random monkey selections: {MonkeyHelper.RandomAccessCount}");
        Console.ResetColor();
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
