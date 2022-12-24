using System;

namespace InventorySystemPrototype;


internal class Program
{
    public static void Main(string[] args)
    {
        Item sword = new("Steel Sword", 1200, ItemType.Weapon);
        Item bow = new("Hunting Bow", 850, ItemType.Weapon);
        Item bread = new("Bread", 65, ItemType.Food);
        Item healPotion = new("Health Potion", 450, ItemType.Potion, true, 5);
        Item manaPotion = new("Mana Potion", 550, ItemType.Potion, true, 5);
        Item goldCoin = new("Gold Coin", 1, ItemType.Misc, true, 100);

        Inventory inventory = new();


        inventory.AddItem(sword, 10);
        inventory.AddItem(bow, 12);
        inventory.AddItem(manaPotion, 13);
        inventory.AddItem(healPotion, 15);
        
        inventory.Log();        
    }
}
