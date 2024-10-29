using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    internal class Billing
    {
        public decimal CalculateTotal(Cart cart, List<IDiscountStrategy> discounts = null)
        {
            decimal total = 0;
            foreach (var item in cart.GetItems())
            {
                total += item.TotalPrice();
            }

            if (discounts != null)
            {
                foreach (var discount in discounts)
                {
                    total = discount.ApplyDiscount(total);
                }
            }

            return total;
        }
    }
}