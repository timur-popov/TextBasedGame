using System;
using ConsoleBasedTextAdventure;

class Program
{
    private static string introductionText = "Welcome to \"The Forgotten Manor.\" You wake up in an unfamiliar, dark room within a grand but decaying manor. Your head aches, and you have no memory of how you got here. The air is thick with dust, and the silence is unsettling. You must explore the manor, solve puzzles, and collect items to find the key that will allow you to escape.";
    private static Player player;
    private static EntranceHall entranceHall; 
    private static Library library;
    private static Bedroom bedroom;
    private static Kitchen kitchen;
    private static Basement basement;
    
    static void Main()
    {
        init();
        
        Console.WriteLine(introductionText);
        Console.WriteLine("--------------------------------");
        Console.WriteLine("In each room, you can use the following commands:\n" + Room.GetActions());
        Console.WriteLine("\nAlso you have a list of other commands, namely:\n" 
                          + "exit - to exit the game\n" 
                          + "view inventory - view elements in inventory\n"
                          + "view commands - view list of commands\n"
                          + "description {Item in your inventory} - view description of item in inventory\n"
                          + "view directions - view available directions to go");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("You are in: " + player.GetCurrentRoom().roomName);
        Console.WriteLine("--------------------------------");
        Console.WriteLine(player.GetCurrentRoom().description);
        Console.WriteLine("--------------------------------");
        
        while (true)
        {
            HandleInput();
        }
        
    }

    static void init()
    {
        entranceHall = new EntranceHall();
        library = new Library();
        bedroom = new Bedroom();
        kitchen = new Kitchen();
        basement = new Basement();
        
        
        entranceHall.AddDestination(library);
        entranceHall.AddDestination(bedroom);
        entranceHall.AddDestination(kitchen);
        
        library.AddDestination(entranceHall);
        library.AddDestination(basement);
        
        kitchen.AddDestination(entranceHall);
        bedroom.AddDestination(entranceHall);
        
        player = new Player(entranceHall);
    }
    
    static void HandleInput()
    {
        Console.Write("Enter a command: ");
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        {
            var command = reader.ReadLine().Trim().ToLower();
            Console.Write("\n");

            switch (command)
            {
                case "look":
                    Console.WriteLine(player.GetCurrentRoom().look());
                    break;
                case { } when command.Contains("go"):
                    string roomName = command.Replace("go", "").Trim();
                    player.currentRoom = player.GetCurrentRoom().go(roomName);
                    Console.WriteLine("You are in: " + player.GetCurrentRoom().roomName);
                    Console.WriteLine("\n" + player.GetCurrentRoom().description);
                    break;
                case { } when command.Contains("examine"):
                    Console.WriteLine(player.GetCurrentRoom().examine(command.Replace("examine", "").Trim()));
                    break;
                case { } when command.Contains("take"):
                    Console.WriteLine(player.GetCurrentRoom().take(command.Replace("take", "").Trim(), player.getInventory()));
                    break;
                case { } when command.Contains("use"):
                    Console.WriteLine(player.GetCurrentRoom().use(command.Replace("use", "").Trim()));
                    break;
                case { } when command.Contains("open"):
                    Console.WriteLine(player.GetCurrentRoom().open(command.Replace("open", "").Trim()));
                    break;  
                case "exit":
                    Console.WriteLine("Goodbye!");
                    System.Environment.Exit(0);
                    break;
                case "view inventory":
                    Console.WriteLine(player.GetInventory());
                    break;
                case "view commands":
                    Console.WriteLine(Room.GetActions());
                    break;
                case { } when command.Contains("description"):
                    Console.WriteLine(player.getDescriptionOfItem(command.Replace("description", "").Trim()));
                    break;
                case "view directions":
                    Console.WriteLine("Possible directions:\n" + player.GetCurrentRoom().GetPossibleDestinations());
                    break;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
            Console.WriteLine("--------------------------------");
        }
    }
}