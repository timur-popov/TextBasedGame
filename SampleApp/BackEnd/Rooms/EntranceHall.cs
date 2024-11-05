namespace ConsoleBasedTextAdventure;

public class EntranceHall : Room
{
    
    public EntranceHall()
    {
        roomName = "Entrance Hall";
        description = "You find yourself in a grand entrance hall. The room is dimly lit, with a dusty chandelier hanging above. To the left, there is a door leading to the library, to the right, a door to the kitchen, and a staircase that goes upstairs. The front door is locked. Near the door, you spot a crumpled newspaper.";
        items = new List<Item>()
        {
            new Item("Newspaper", "You pick up the crumpled newspaper, its paper brittle and yellowed with age. The headline catches your eye, mentioning a mysterious disappearance connected to the manor. Also you reveal that the front is locked and needs a key"),
        };
    }

    public override string look()
    {
        return
            "The grand entrance hall is covered in a layer of dust. The chandelier sways slightly, as if moved by an unseen force. Faded paintings line the walls, and the dim light gives the room a ghostly aura";
    }

    public override string examine(string item)
    {
        if (item == "front door")
        {
            return "You try the handle, but it's locked tight. The keyhole looks old and worn, suggesting it hasn’t been used in a long time. You’ll need to find a key if you hope to escape.";
        }
        else if (item == "newspaper")
        {
            return
                "\"Local Girl Goes Missing, Last Seen Near Abandoned Manor.\"\nThe article mentions a hidden room in the basement that can only be accessed by a secret mechanism.";
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
        if (item == "front door")
        {
            foreach (Item i in Player.inventory)
            {
                if (i.name.ToLower().Trim() == "hidden key")
                {
                    return "The door creaks open, and fresh air fills your lungs. As you step outside, you glance back at the manor, now shrouded in shadows. Something deep within seems to be watching you, but you don’t plan on sticking around to find out. You walk away, relieved but haunted, leaving the manor and its secrets behind.";
                } else if (i.name == "Rusty key")
                {
                    return "You cannot use rusty key here";
                }
            }
            return "You try to open the front door, but it's locked tight. You can examine the door to find out more";
        }
        else
        {
            return "You cannot open this item";
        }
    }
}