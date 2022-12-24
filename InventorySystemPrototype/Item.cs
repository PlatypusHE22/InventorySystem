namespace InventorySystemPrototype;

public enum ItemType
{
    None = 0,
    Weapon,
    Food,
    Potion,
    
    
    Misc = 99
}

public class Item
{
    // Basic attributes
    public string name;
    public int price;
    public ItemType type;
    
    // Stacking
    public bool stackable;
    public int maxStackSize;

    public Item()
    {
        name = "";
        price = 0;
        type = ItemType.None;
    }
    public Item(string name, int price, ItemType type)
    {
        this.name = name;
        this.price = price;
        this.type = type;
        stackable = false;
    }

    public Item(string name, int price, ItemType type, bool stackable, int maxStackSize)
    {
        this.name = name;
        this.price = price;
        this.type = type;
        this.stackable = stackable;
        this.maxStackSize = maxStackSize;
    }

    public override string ToString()
    {
        return $"{name}, {price}, {type}";
    }
}

    