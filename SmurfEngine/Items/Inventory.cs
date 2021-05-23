using System;
using System.Collections.Generic;
using System.Text;

namespace SmurfEngine.Items
{
    internal class Inventory
    {
        Dictionary<string, InventoryItem> contents;

        public void Add(Item item)
        {
            if (contents.TryGetValue(item.name, out var invItem))
                ++invItem.quantity;
            else
                contents.Add(item.name, new InventoryItem(item));
        }

        public void Display()
        {
            foreach(var c in contents)
            {
                var item = c.Value.item;
                var quantity = c.Value.quantity;

                Console.WriteLine($"{item.name}\tx{item}");
            }
        }
    }
}
