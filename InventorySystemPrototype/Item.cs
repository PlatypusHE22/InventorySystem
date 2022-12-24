namespace InventorySystemPrototype;

public enum ItemType
{
    None = 0,
    Weapon,
    Food,
    Potion
}

public class Item
{
    public string name;
    public int price;
    public ItemType type;

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
    }

    public override string ToString()
    {
        return $"{name}, {price}, {type}";
    }
}

    