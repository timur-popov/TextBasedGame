namespace ConsoleBasedTextAdventure;

public interface IActions
{
    
    protected String look();
    
    protected String examine(string item);
    
    protected String take(String item, List<Item> inventory);
    protected String use(String item);
    protected String open(String item);
    protected Room go(String roomName);
}