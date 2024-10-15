using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops
{
    internal class CreditCard
    {
        public string CardHolderName;
        public long CardNumber;
        public byte ExpiryMonth;
        public int ExpiryYear;

        public override string ToString()
        {
            return $"name: {CardHolderName},CardNumber: {CardNumber},expiry:{ExpiryMonth}/{ExpiryYear}";
        }
    }
}
