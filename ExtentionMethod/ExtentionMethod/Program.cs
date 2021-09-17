using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart products = new ShoppingCart { 
                Products = new List<Product> 
                {     new Product { ID=1,name="Tomato",Price=3}, 
                      new Product { ID = 2, name = "Strawbawry", Price = 10 } } };
            decimal Total = products.TotalPrice();
            Console.WriteLine("--------------Product in Banch--------------");
            foreach (Product item in products.Products)
            {
                Console.WriteLine("ProductID("+item.ID+")-"+item.name);
            }
            Console.WriteLine("TotalPrice:{0:c}",Total);
            
        }
    }
}
