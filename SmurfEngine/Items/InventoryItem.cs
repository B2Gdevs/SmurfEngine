using SmurfEngine.UI;
using System;

namespace SmurfEngine.Items
{
    public class InventoryItem
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }

        public InventoryItem(Item item, int quantity = 1)
        {
            this.Item = item;
            this.Quantity = quantity;
        }

        public void Display()
        {
            ConsoleExt.WriteColor($"{this.Item.Name}\t", ConsoleExt.ItemNameColor);
            ConsoleExt.WriteColor($"x{this.Quantity}\n", ConsoleExt.ItemQuantityColor);
        }
    }
}
