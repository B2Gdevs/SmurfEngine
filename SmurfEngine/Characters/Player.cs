using SmurfEngine.Items;
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

		public void AddItemToInventory(Item item)
        {
			inventory.Add(item);
        }

		public void DisplayInventory()
        {
			inventory.Display();
        }
	}

}