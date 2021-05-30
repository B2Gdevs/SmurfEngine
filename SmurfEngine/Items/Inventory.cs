﻿using System.Collections.Generic;

namespace SmurfEngine.Items
{
    public class Inventory
    {
        public Dictionary<string, InventoryItem> Contents { get; set; } = new Dictionary<string, InventoryItem>();

        public void Add(Item item, int quantity)
        {
            if (this.Contents.TryGetValue(item.Name, out InventoryItem invItem))
                invItem.Quantity += quantity;
            else
                this.Contents.Add(item.Name, new InventoryItem(item, quantity));
        }

        public void Display()
        {
            foreach (KeyValuePair<string, InventoryItem> c in this.Contents)
                c.Value.Display();
        }
    }
}
