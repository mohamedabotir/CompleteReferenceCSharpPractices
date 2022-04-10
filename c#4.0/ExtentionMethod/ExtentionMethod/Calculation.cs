using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod
{
   static class Calculation
    {
        public static decimal TotalPrice(this ShoppingCart par)
        {
            decimal total = 0;
            foreach (Product item in par.Products)
            {
                total += item.Price;
            }
            return total;
        }
    }
}
