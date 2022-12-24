#nullable enable
namespace InventorySystemPrototype;

public class Slot
{
    public Item? heldItem;
    public int numberOfHeldItems;
    

    // Creates an empty slot
    public Slot()
    {
        heldItem = null;
        numberOfHeldItems = 0;
    }

    // Creates a slot with a single item
    public Slot(Item item)
    {
        heldItem = item;
        numberOfHeldItems = 1;
    }

    // Creates a slot with a set number of items
    public Slot(Item item, int numberOfItems)
    {
        heldItem = item;
        numberOfHeldItems = numberOfItems;
    }

    public override string ToString()
    {
        return $"Item: {heldItem}, Count: {numberOfHeldItems}";
    }
}
