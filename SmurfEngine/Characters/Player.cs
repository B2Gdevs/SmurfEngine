using SmurfEngine.Items;
using SmurfEngine.UI;
using System;

namespace SmurfEngine.Characters
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Inventory Inventory { get; set; }

        public Player(string name, int health, Inventory inventory)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;
        }

        public void AddItemToInventory(Item item, int quantity = 1)
        {
            this.Inventory.Add(item, quantity);
        }

        public void DisplayInventory()
        {
            Console.Write("Inventory for ");
            UIText.SetColor(UIText.playerNameColor);
            Console.Write(this.Name);
            UIText.SetColor(UIText.defaultColor);
            Console.Write(":\n");
            Console.WriteLine(("").PadRight(24, '*'));
            this.Inventory.Display();
            Console.WriteLine(("").PadRight(24, '*'));
        }
    }
}