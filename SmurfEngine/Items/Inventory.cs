using System;
using System.Collections.Generic;

namespace SmurfEngine.Items
{
    public class Inventory
    {
        public Dictionary<string, InventoryItem> Contents { get; set; } = new Dictionary<string, InventoryItem>();

        public void Add(Item item, int quantity)
        {
            if (quantity == 0) return;

            if (this.Contents.TryGetValue(item.Name, out var invItem))
                invItem.Quantity += quantity;
            else
                this.Contents.Add(item.Name, new InventoryItem(item, quantity));
        }

        public bool Remove(Item item, int quantity)
        {
            if (quantity <= 0) return false;

            if (this.Contents.TryGetValue(item.Name, out var invItem))
            {
                if (quantity >= invItem.Quantity)
                    this.Contents.Remove(item.Name);
                else
                    invItem.Quantity -= quantity;

                return true;
            }
            
            return false;
        }

        public bool Check(Item item, int quantity = 1)
        {
            if (this.Contents.TryGetValue(item.Name, out var invItem))
                return invItem.Quantity >= quantity;
            else 
                return false;
        }

        public void Display()
        {
            foreach (var c in this.Contents) 
                c.Value.Display();
        }
    }
}
