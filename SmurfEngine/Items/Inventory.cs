using System.Collections.Generic;

namespace SmurfEngine.Items
{
    public class Inventory
    {
        public Dictionary<string, InventoryItem> Contents { get; set; } = new Dictionary<string, InventoryItem>();

        /// <summary>
        /// Adds quantity new items from this inventory
        /// </summary>
        /// <param name="item">the item</param>
        /// <param name="quantity">how many to add</param>
        public void Add(Item item, int quantity)
        {
            if (quantity == 0) return;

            if (this.Contents.TryGetValue(item.Name, out InventoryItem invItem))
                invItem.Quantity += quantity;
            else
                this.Contents.Add(item.Name, new InventoryItem(item, quantity));
        }

        /// <summary>
        /// Attempts to Remove quantity new items from this inventory
        /// </summary>
        /// <param name="item">Item to remove</param>
        /// <param name="quantity">how many to remove</param>
        /// <returns>true if the items could be removed. 
        /// If quantity > the number of items left removes all items 
        /// and return true</returns>
        public bool Remove(Item item, int quantity)
        {
            if (quantity <= 0) return false;

            if (this.Contents.TryGetValue(item.Name, out InventoryItem invItem))
            {
                if (quantity >= invItem.Quantity)
                    this.Contents.Remove(item.Name);
                else
                    invItem.Quantity -= quantity;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks to see if the inventory contains at least 
        /// quantity items of type item
        /// </summary>
        /// <param name="item">The item to look for</param>
        /// <param name="quantity"></param>
        /// <returns>True if there are at lest quantity items</returns>
        public bool Check(Item item, int quantity = 1)
        {
            if (this.Contents.TryGetValue(item.Name, out InventoryItem invItem))
                return invItem.Quantity >= quantity;
            else
                return false;
        }

        /// <summary>
        /// Writes the items in the inventory and their quantities to the console
        /// </summary>
        public void Display()
        {
            foreach (KeyValuePair<string, InventoryItem> c in this.Contents)
                c.Value.Display();
        }
    }
}
