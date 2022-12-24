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
        foreach(var e in slots)
        {
            if (e.heldItem == null)
            {
                e.heldItem = item;
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
        if (slots[slot].heldItem == null)
        {
            slots[slot].heldItem = item;
            return true;
        }
        
        return false;
    }

    // Removes an item from a specified slot
    public void RemoveItem(int slot)
    {
        slots[slot].heldItem = null;
    }

    // Removes all items from the inventory
    public void Clear()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            RemoveItem(i);
        }
    }

    // Swaps 2 items in the inventory
    public void SwapItems(int slot1, int slot2)
    {
        (slots[slot1].heldItem, slots[slot2].heldItem) = (slots[slot2].heldItem, slots[slot1].heldItem);
    }

    // Switches an item already in the inventory to a new one
    public void SwitchItems(Item item, int slot)
    {
        RemoveItem(slot);
        AddItem(item, slot);
    }
    

    // Debugging methods
    public void LogSlot(int slot)
    {
        Console.WriteLine($"Slot {slot}: {slots[slot]}");
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


