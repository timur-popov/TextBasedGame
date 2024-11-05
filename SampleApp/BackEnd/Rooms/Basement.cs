namespace ConsoleBasedTextAdventure;

public class Basement : Room
{
    public Basement()
    {
        roomName = "Basement";
        description = "The basement is cold and damp, it is dark there. You can use flashlight to see better.";
        items = new List<Item>();
    }

    public override string look()
    {
        return "It's too dark to see anything. You need to use a flashlight.";
    }

    public override string examine(string item)
    {
        return "You cannot examine anything here";
    }

    public override string use(String item)
    {
        if (item == "flashlight")
        {
            items.Add(new Item("Crowbar", "You pick up the crowbar. It’s heavy, but it feels solid in your hands. It might be just what you need to pry open something stubborn"));
            items.Add(new Item("Rope", "A sturdy, thick rope. It’s long enough to be useful if you need to climb or pull something."));
            return "You turn on the flashlight. The basement is cold and damp, and your flashlight flickers as you look around. Old furniture is piled up in the corners, and a musty smell fills the air. A locked chest sits ominously in one corner, and there’s a crowbar and a coil of rope lying nearby.";
            
        }
        else if (item == "crowbar")
        {
            items.Add(new Item("Hidden key", "A small brass key, polished and well-maintained. Unlike the other keys you’ve found, this one looks like it’s still in use. It might be the key to the front door."));
            return "With a groan of metal, you wedge the crowbar under the lid of the chest and pry it open. Inside, you find a small brass key—your ticket out of this place. You can take it.";
        }
        else
        {
            return "You cannot use this item here";
        }
    }

    public override string open(string item)
    {
        if (item == "chest")
        {
            use("crowbar");
        }
        return "You cannot open this item";
    }
}