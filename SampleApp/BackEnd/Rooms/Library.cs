namespace ConsoleBasedTextAdventure;

public class Library : Room
{
    public Library()
    {
        roomName = "Library";
        description =
            "The library is filled with dusty bookshelves and a crackling fireplace. There is a locked cabinet in the corner, and a magnifying glass lies on the desk. A large, ancient book catches your attention on the highest shelf.";
        items = new List<Item>()
        {
            new Item("Magnifying Glass",
                "You pick up the magnifying glass. The lens is slightly cracked, but it might still help you read small or faded text hidden around the manor."),
            new Item("Ancient Book",
                "You pick up the ancient book. It is thick, with a worn leather cover. Its pages are filled with strange symbols and diagrams, hinting at secret mechanisms within the manor."),
        };
    }

    public override string look()
    {
        return
            "\"The library is dark and musty, filled with rows of towering bookshelves. Most of the books are coated in dust, untouched for years. A fireplace flickers dimly, casting eerie shadows across the room.\"";
    }

    public override string examine(string item)
    {
        if (item == "magnifying glass")
        {
            return "You cannot examine the magnifying glass. You can only take it.";
        }
        else if (item == "ancient book")
        {
            return
                "Reading the book reveals that there’s a hidden mechanism to access the basement. It mentions a rusty key";
        }
        else
        {
            return "There is no such item in this room";
        }
    }

    public override string use(String item)
    {
        if (item == "rusty key")
        {
            return open("cabinet");
        }
        else
        {
            return "You cannot use this item here";
        }
    }

    public override string open(String item)
    {
        if (item == "cabinet")
        {
            foreach (var i in Player.inventory)
            {
                if (i.name.Trim().ToLower() == "rusty key")
                {
                    return
                        "You use Rusty key to open cabinet. Inside, you find a note with symbols that match those in the ancient book. The symbols hint at a hidden door in the library.";
                }
            }
        }
        
        return "You cannot open anything here";
    }
}