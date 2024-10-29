using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    internal class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Item(int id, string name, int quantity, decimal price)
        {
            ID = id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public decimal TotalPrice()
        {
            return Quantity * Price;
        }
    }
}
