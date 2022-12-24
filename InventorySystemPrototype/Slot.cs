#nullable enable
namespace InventorySystemPrototype;

public class Slot
{
    public Item? heldItem;
    

    public Slot()
    {
        heldItem = null;
    }

    public Slot(Item item)
    {
        heldItem = item;
    }

    public override string ToString()
    {
        return $"Item: {heldItem}";
    }
}
