using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();
            cart.AddItem(new Item(1, "Laptop", 1, 1500m));
            cart.AddItem(new Item(2, "Mouse", 2, 50m));

            var discounts = new List<IDiscountStrategy> { new PercentageDiscount(10) };

            var billing = new Billing();
            decimal total = billing.CalculateTotal(cart, discounts);

            Console.WriteLine($"Total after discount: {total}");

        }
    }
}
