namespace ConsoleBasedTextAdventure;

public class Item
{
    public String name
    {
        get;
    }

    public String description
    {
        get;
    }
    
    public Item(String name, String description)
    {
        this.name = name;
        this.description = description;
    }
}