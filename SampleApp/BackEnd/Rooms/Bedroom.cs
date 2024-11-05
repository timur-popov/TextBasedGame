namespace ConsoleBasedTextAdventure;

public class Bedroom : Room 
{
    public Bedroom()
    {
        roomName = "Bedroom";
        description = "You enter a small, dark bedroom. There’s a bed, a slightly open wardrobe, and a nightstand with a flashlight on it. A silver locket glints on the floor.";
        items = new List<Item>()
        {
            new Item("Flashlight",
                "You pick up the flashlight, but it flickers weakly when you turn it on. It looks like the batteries are running low. Hopefully, it’ll last long enough to light your way in dark places."),
            new Item("Silver Locket", "You find a silver locket on the floor, glinting in the dim light. It opens easily, revealing a faded photograph. The face is too worn to recognize, but you feel a strange connection to it."),
        };
    }
    
    public override string look()
    {
        return "The bedroom is small, with a single bed pushed up against the wall. The sheets are wrinkled, and there’s a faint, cold draft coming from the slightly open window. A wardrobe sits in the corner, and a flashlight rests on the nightstand.";
    }

    public override string examine(string item)
    {
        if (item == "silver locket")
        {
            return
                "You take a closer look at the locket. The photograph inside seems familiar, but you can’t quite place it. Maybe it holds a clue to the mysteries of this manor.";
        } else if (item == "flashlight")
        {
            return "You examine the flashlight. The batteries are indeed low, but it should still work for a while. It might be useful in dark places.";
        }
        else
        {
            return "There is no such item in this room";
        }
    }

    public override string use(String item)
    {
        return "You can't use this item here";
    }

    public override string open(String item)
    {
        if (item == "wardrobe")
        {
            items.Add(new Item("Manor Map", "          [ Bedroom ]\n              |\n[ Library ] - [ Entrance Hall ] - [ Kitchen ]\n      |\n[ Basement ]\n"));
            return "You open the wardrobe and find a manor map. You can take it. There’s nothing else inside.";
        }
        else
        {
            return "There is no such item in this room";
        }
    }
}