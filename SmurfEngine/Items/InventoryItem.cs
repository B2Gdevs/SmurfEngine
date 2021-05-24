using System;
using System.Collections.Generic;
using System.Text;
using SmurfEngine.UI;

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
            UIText.SetColor(UIText.itemNameColor);
            Console.Write($"{this.Item.Name}\t");
            UIText.SetColor(UIText.itemQuantityColor);
            Console.Write($"x{this.Quantity}\n");
            UIText.SetColor(UIText.defaultColor);
        }
    }
}
