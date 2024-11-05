using System.Runtime.InteropServices.JavaScript;

namespace ConsoleBasedTextAdventure;

public abstract class Room : IActions
{
    public static Dictionary<string, string> actionsDescription = new Dictionary<string, string>
    {
        {"look", "Look around the room for details"},
        {"examine {item}", "Get more information about an item"},
        {"take {item}", "Pick up an item"},
        {"use {item}", "Use an item in your inventory"},
        {"open {object}", "Open objects like doors, cabinets, and chests"},
        {"go {room}", "Move to a different room"}
    };

    protected List<Item> items
    {
        get;
        set;
    }

    public String roomName
    {
        get;
        set;
    }

    public String description
    {
        get;
        set;
    }
    
    public List<Room> destinations = new List<Room>();

    public abstract string look();

    public abstract string examine(string item);
    public string take(String item, List<Item> inventory)
    {
        foreach (var i in items)
        {
            if (i.name.ToLower().Trim() == item)
            {
                if (!inventory.Contains(i))
                {
                    inventory.Add(i);
                    return i.description;
                }
                else
                {
                    return "You already have this item in your inventory";
                }
            }
        }
        return "There is no such item in this room";
    }

    public abstract string use(String item);

    public abstract string open(String item);

    public Room go(string roomName)
    {
        foreach (var destination in destinations)
        {
            if (destination.roomName.ToLower().Trim() == roomName)
            {
                return destination;
            }
        }
        Console.WriteLine("You cannot go to this room from here");
        return this;
    }
    

    public static string GetActions()
    {
        string actions = "";
        foreach (var action in actionsDescription)
        {
            actions += action.Key + " - " + action.Value + "\n";
        }
        return actions.Trim();
    }
    
    public string GetPossibleDestinations()
    {
        string destinations = "";
        foreach (var destination in this.destinations)
        {
            destinations += destination.roomName + "\n";
        }
        return destinations.Trim();
    }
    
    public void AddDestination(Room destination)
    {
        if (destinations == null)
        {
            destinations = new List<Room>();
            destinations.Add(destination);
        }
        else
        {
            destinations.Add(destination);
        }
    }
}