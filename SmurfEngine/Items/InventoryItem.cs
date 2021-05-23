using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
