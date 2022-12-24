using System;
using System.Collections.Generic;

namespace InventorySystemPrototype;

public class Inventory
{

    private const int numberOfSlots = 32;
    private List<Slot> slots = new();

    public Inventory()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            slots.Add(new Slot());
        }
    }
    
    //// Methods

    // Adds an item into the first free slot
    // If it succeeds if returns true
    // If there aren't any free slots it returns false
    public bool AddItem(Item item)
    {
        // If the item is stackable it tries to find an already existing stack and add it there
        if (item.stackable)
        {
            foreach (var slot in slots)
            {
                if (slot.heldItem == item && slot.numberOfHeldItems < item.maxStackSize)
                {
                    slot.numberOfHeldItems++;
                    return true;
                }
            }
        }
        
        // Loops through all slots and if it finds an empty one, it places the item there
        foreach(var slot in slots)
        {
            if (slot.heldItem == null)
            {
                slot.heldItem = item;
                slot.numberOfHeldItems = 1;
                return true;
            }
        }

        return false;
    }

    // Adds an item into a specific slot
    // If that slot already has an item it returns false
    // otherwise it returns true
    public bool AddItem(Item item, int slot)
    {
        // If the item is stackable it tries to stack it into the same slot
        // If it's not the same item or the stack is full, it returns false
        if (item.stackable)
        {
            if (slots[slot].heldItem == item && slots[slot].numberOfHeldItems < item.maxStackSize)
            {
                slots[slot].numberOfHeldItems++;
                return true;
            }

            return false;
        }

        // If the slot is not empty and the item is not stackable it returns false
        if (slots[slot].heldItem == null)
        {
            slots[slot].heldItem = item;
            slots[slot].numberOfHeldItems = 1;
            return true;
        }
        
        return false;
    }

    // Similar to the regular AddItem() method
    // But it adds a specified number of items to the first empty slot  
    public bool AddMultipleItems(Item item, int numberOfItems)
    {
        int remainingItems = numberOfItems;
        
        // If the item is NOT stackable
        if (!item.stackable)
        {
            for (int i = 0; i < remainingItems; i++)
            {
                if (!AddItem(item))
                    return false;
            }

            return true;
        }

        // If the item is stackable the method will first find all slots that have the same item,
        // and try to fill them up. If all slots with this item are filled up, and there are still remaining items
        // that need to be added, it will start a second for loop.
        foreach (var slot in slots)
        {
            if (slot.heldItem == item && slot.numberOfHeldItems < item.maxStackSize)
            {
                // First it calculates how many free spaces there are, then the items it can add.
                // Then it adds the items and subtracts that from the remaining items.
                int freeSlots = item.maxStackSize - slot.numberOfHeldItems;
                int itemsToAdd = Math.Min(freeSlots, remainingItems);
                slot.numberOfHeldItems += itemsToAdd;
                remainingItems -= itemsToAdd;

                // If there are no more items to be added, it returns true.
                if (remainingItems <= 0)
                    return true;
            }
        }

        // This loop finds all empty slots and tries to fill them up. If it runs out of empty slots, it returns false.
        foreach (var slot in slots)
        {
            if (slot.heldItem == null)
            {
                // Does basically the same thing as the calculation before it.
                slot.heldItem = item;
                int itemsToAdd = Math.Min(item.maxStackSize, remainingItems);
                slot.numberOfHeldItems += itemsToAdd;
                remainingItems -= itemsToAdd;

                if (remainingItems <= 0)
                    return true;
            }
        }
        
        // If it can't add any more items, it returns false.
        return false;
    }

    // Like the regular AddMultipleItems() method
    // but it adds a specified amount of items into a specified slot
    public bool AddMultipleItems(Item item, int numberOfItems, int slot)
    {
        int remainingItems = numberOfItems;
        if (slots[slot].heldItem == null || (slots[slot].heldItem == item && slots[slot].numberOfHeldItems < item.maxStackSize))
        {
            // Calculates the amount of free space in the slot, the number it needs to add
            // then subtracts that from the remaining items.
            int freeSpace = item.maxStackSize - slots[slot].numberOfHeldItems;
            int numberToAdd = Math.Min(freeSpace, remainingItems);
            remainingItems -= numberToAdd;

            slots[slot].heldItem = item;
            slots[slot].numberOfHeldItems = numberToAdd;
        }

        // If there are no remaining items to be added, it returns true, otherwise false.
        if (remainingItems <= 0)
            return true;
        
        return false;
    }

    // Removes a single item from a specified slot
    // If there aren't any items remaining in it afterwards, it clears the slot.
    public void RemoveItem(int slot)
    {
        slots[slot].numberOfHeldItems--;

        if (slots[slot].numberOfHeldItems <= 0)
        {
            ClearSlot(slot);
        }
    }

    // Removes a specific amount of items from a slot
    // If there aren't any items remaining in it afterwards, it clears the slot.
    public void RemoveItem(int slot, int amountToRemove)
    {
        slots[slot].numberOfHeldItems -= amountToRemove;

        if (slots[slot].numberOfHeldItems <= 0)
        {
            ClearSlot(slot);
        }
    }

    // Replaces a slot with an empty one
    public void ClearSlot(int slot)
    {
        slots[slot] = new Slot();
    }

    // Removes all items from the inventory
    public void Clear()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            ClearSlot(i);
        }
    }

    // Swaps 2 items in the inventory
    public void SwapItems(int slot1, int slot2)
    {
        // I don't fucking know what this is my IDE suggested it.
        (slots[slot1].heldItem, slots[slot2].heldItem, slots[slot1].numberOfHeldItems, slots[slot2].numberOfHeldItems) =
            (slots[slot2].heldItem, slots[slot1].heldItem, slots[slot2].numberOfHeldItems, slots[slot1].numberOfHeldItems);
    }

    // Switches an item already in the inventory to a new one
    // It discards the original item
    public void SwitchItems(Item item, int slot)
    {
        ClearSlot(slot);
        AddItem(item, slot);
    }

    public void SwitchItems(Item item, int slot, int amount)
    {
        ClearSlot(slot);
        AddMultipleItems(item, amount, slot);
    }
    

    /// Debugging methods
    
    // Logs a single slot
    public void LogSlot(int slot)
    {
        Console.WriteLine($"Slot {slot}: {slots[slot]}");
    }

    // Logs out the entire inventory
    // Takes in start and end points and logs all slots between them
    public void LogRange(int start, int end)
    {
        if (start < 0 || end > numberOfSlots)
        {
            Console.WriteLine($"LogRange({start}, {end}) out of range (min=0,max={numberOfSlots})");
            return;
        }
        
        for (int i = start; i < end; i++)
        {
            LogSlot(i);
        }
    }

    public void Log()
    {
        Console.WriteLine("Inventory:");
        for(int i = 0; i < numberOfSlots; i++) 
        {
            Console.Write("\t");
            LogSlot(i);
        }
    }
}


