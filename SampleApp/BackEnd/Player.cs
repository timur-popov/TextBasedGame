using System.Text;

namespace ConsoleBasedTextAdventure;

public class Player
{
    public Room currentRoom;

    public static List<Item> inventory = new List<Item>();
    
    public List<Item> getInventory()
    {
        return inventory;
    }

    public String GetInventory()
    {
        StringBuilder text = new StringBuilder("Your inventory:");
        foreach (Item item in inventory)
        {
            text.Append("\n" + item.name);
        }

        return text.ToString();
    }

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }

    public Player(Room currentRoom)
    {
        this.currentRoom = currentRoom;
    }
    
    public String getDescriptionOfItem(String name)
    {
        foreach (Item item in inventory)
        {
            if (item.name.Trim().ToLower() == name)
            {
                return string.Format($"Description of {item.name}: {item.description}");
            }
        }

        return "There is no such item in your inventory";
    }
}