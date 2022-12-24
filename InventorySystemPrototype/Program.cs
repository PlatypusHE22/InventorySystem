using System;

namespace InventorySystemPrototype;


internal class Program
{
    public static void Main(string[] args)
    {
        Item sword = new("Steel Sword", 1200, ItemType.Weapon);
        Item bow = new("Hunting Bow", 850, ItemType.Weapon);
        Item bread = new("Bread", 65, ItemType.Food);
        Item healPotion = new("Health Potion", 450, ItemType.Potion);
        Item manaPotion = new("Mana Potion", 550, ItemType.Potion);

        Inventory inventory = new();

        inventory.AddItem(sword);
        inventory.AddItem(healPotion);
        inventory.AddItem(bread);
        inventory.AddItem(sword);

        inventory.AddItem(manaPotion, 10);
        inventory.AddItem(manaPotion, 11);
        inventory.AddItem(healPotion, 12);

        inventory.AddItem(bow);
        inventory.AddItem(bow);
        inventory.AddItem(healPotion);
        
        inventory.Log();

        Console.WriteLine("\n\n\n");

        inventory.SwapItems(1, 2);
        inventory.SwitchItems(bow, 0);
        
        inventory.Log();
    }
}
