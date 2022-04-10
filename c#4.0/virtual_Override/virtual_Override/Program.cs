using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtual_Override
{
    class Program
    {
        static void Main(string[] args)
        {
            superclass obj1 = new superclass();
            Console.WriteLine(obj1.Print());
            Console.WriteLine(superclass.count);
            Drived obj = new Drived();
            Console.WriteLine(obj.Print());
            Console.WriteLine(Drived.count);
        }
    }
}
