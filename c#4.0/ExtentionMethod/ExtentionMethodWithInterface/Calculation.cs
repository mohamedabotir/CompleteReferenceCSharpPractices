using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod
{
   static class Calculation
    {
        public static decimal TotalPrice(this IEnumerable<Product> par)
        {
            decimal total = 0;
            foreach (Product item in par)
            {
                total += item.Price;


            }
            return total;
        }
        public static IEnumerable<Product> filterCategory(this IEnumerable<Product> prod, string cat) {
            foreach (Product item in prod)
            {
                if (item.cat == cat)
                    yield return item;
            }
        }
    }
}
