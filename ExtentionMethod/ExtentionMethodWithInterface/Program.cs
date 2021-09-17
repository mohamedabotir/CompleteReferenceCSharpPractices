using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtentionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Product> products = new ShoppingCart { 
                Products = new List<Product> 
                {     new Product { ID=1,name="Tomato",Price=3,cat="Vegetables"}, 
                      new Product { ID = 2, name = "Strawbawry", Price = 10 ,cat="Fruits"} } };
            decimal Total = products.TotalPrice();
            StringBuilder d = new StringBuilder();

            Console.WriteLine("--------------Product in Banch--------------");
            foreach (Product item in products)
            {
                Console.WriteLine("ProductID("+item.ID+")-"+item.name);
                d.Append(item.name + ",");
            }
            Console.WriteLine("TotalPrice:{0:c}", Total);

            Total = 0;
            foreach (Product item in products.filterCategory("Vegetables"))
            {
                Total += item.Price;
            }
            Console.WriteLine($"Vegetables TotalPrice: ${Total}");
            Console.WriteLine("All Product:"+d.ToString());
            Console.WriteLine("------------------Linq-----------------");
            /*var founditem = from Match in products orderby Match.Price 
                            descending select new { Match.name, Match.Price };*/
            var founditem = products.OrderByDescending(e => e.Price).Take(3).Select(e => new { e.Price, e.name });//like previous
            StringBuilder result = new StringBuilder();
            //int count = 0;
            foreach (var p in founditem)
            {
                result.AppendFormat("\nPrice: {0:c} ", p.Price +"  Product:"+p.name );
                //if (++count == 2)
                //{
                //    break;
                //}
            }
            Console.WriteLine("Result:"+result);
            #region async-await
            /*
             public async static Task<long?> GetPageLength() {
HttpClient client = new HttpClient();
var httpMessage = await client.GetAsync("http://apress.com");
// we could do other things here while we are waiting
// for the HTTP request to complete
return httpMessage.Content.Headers.ContentLength;
}
             */
            #endregion

        }
    }
}
