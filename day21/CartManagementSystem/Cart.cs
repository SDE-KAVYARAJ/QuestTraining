using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    internal class Cart
    {
        private readonly Dictionary<int, Item> items; // Keyed by item ID

        public Cart()
        {
            items = new Dictionary<int, Item>();
        }

        public void AddItem(Item item)
        {
            if (items.ContainsKey(item.ID))
            {
                items[item.ID].Quantity += item.Quantity; // Update quantity if item already exists
            }
            else
            {
                items[item.ID] = item; // Add new item
            }
        }

        public void UpdateItem(int id, int quantity)
        {
            if (items.ContainsKey(id))
            {
                items[id].Quantity = quantity;
                if (items[id].Quantity <= 0)
                {
                    items.Remove(id); // Remove item if quantity is 0 or less
                }
            }
        }

        public void RemoveItem(int id)
        {
            if (items.ContainsKey(id))
            {
                items.Remove(id); // Remove item by ID
            }
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in items.Values)
            {
                total += item.TotalPrice(); // Calculate total price of items
            }
            return total;
        }
        public IEnumerable<Item> GetItems()
        {
            return items.Values; // Return all items
        }
    }
}
