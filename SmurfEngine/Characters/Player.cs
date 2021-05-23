using SmurfEngine.Items;
using System;
using System.Collections.Generic;

namespace SmurfEngine.Characters
{
	internal class Player
	{
		string name;
		int health;
		Inventory inventory;

		public Player(string name, int health, Inventory inventory)
		{
			this.name = name;
			this.health = health;
			this.inventory = inventory;
		}

		public void AddItemToInventory(Item item, int quantity = 1)
        {
			inventory.Add(item, quantity);
        }

		public void DisplayInventory()
        {
			Console.WriteLine($"Inventory for {name}:");
			Console.WriteLine(("").PadRight(24, '*'));
			inventory.Display();
			Console.WriteLine(("").PadRight(24, '*'));
		}
	}

}