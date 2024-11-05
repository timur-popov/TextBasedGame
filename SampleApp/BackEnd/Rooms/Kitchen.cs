namespace ConsoleBasedTextAdventure;

public class Kitchen : Room 
{
    public Kitchen()
    {
        roomName = "Kitchen";
        description = "The kitchen is a mess. There are broken dishes on the floor, and the air smells stale. The refrigerator hums softly, and there is cabinet above the sink.";
        items = new List<Item>() 
        {
            new Item("Bottle of Water", "You pick up the half-empty bottle of water. It’s dusty, but the water inside seems clear. It could come in handy for cleaning something off or maybe revealing a hidden message"),
            new Item("Knife", "You take the knife from the counter. It’s sharp and well-balanced, despite the rust starting to creep up the blade. It might prove useful if you need to cut something open."),
        };
    }

    public override string look()
    {
        return "The kitchen is chaotic. Pots and pans are scattered across the counters, and broken dishes litter the floor. It feels like someone left in a hurry. The hum of an old refrigerator echoes in the quiet room.";
    }

    public override string examine(string item)
    {
       return "You can't examine this item";
    }

    public override string use(String item)
    {
        return "You can't use this item here";
    }

    public override string open(string item)
    {
        if (item == "cabinet")
        {
            items.Add(new Item("Rusty key", "A small, rust-covered key. It looks like it could open a simple lock somewhere in the manor"));
            return "You open the creaking cabinet, but it’s mostly empty, apart from a rusty key. You can take the key.";
        }
        else
        {
            return "You can't examine this item";
        }
    }
}