using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagementSystem
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal total);
    }
    internal class PercentageDiscount:IDiscountStrategy
    {
        private readonly decimal percentage;

        public PercentageDiscount(decimal percentage)
        {
            this.percentage = percentage;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return total - (total * percentage / 100);
        }
    }
}
