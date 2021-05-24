using SmurfEngine.Items;
using SmurfEngine.UI;
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
			Console.Write("Inventory for ");
			UIText.SetColor(UIText.playerNameColor);
			Console.Write(name);
			UIText.SetColor(UIText.defaultColor);
			Console.Write(":\n");
			Console.WriteLine(("").PadRight(24, '*'));
			inventory.Display();
			Console.WriteLine(("").PadRight(24, '*'));
		}
	}
}