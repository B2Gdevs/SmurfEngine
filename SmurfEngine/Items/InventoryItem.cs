using System;
using System.Collections.Generic;
using System.Text;
using SmurfEngine.UI;

namespace SmurfEngine.Items
{
    internal class InventoryItem
    {
        internal Item item;
        internal int quantity;

        public InventoryItem(Item item, int quantity = 1)
        {
            this.item = item;
            this.quantity = quantity;
        }

        public void Display()
        {
            UIText.SetColor(UIText.itemNameColor);
            Console.Write($"{item.name}\t");
            UIText.SetColor(UIText.itemQuantityColor);
            Console.Write($"x{quantity}\n");
            UIText.SetColor(UIText.defaultColor);
        }
    }
}
