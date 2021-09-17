using System;

namespace ObjectInitioanlizer
{class initianlizer {
       public int id;
       public string name;
    }
    class Program
    {
      static  int factorial(int i)
        {
            if (i == 1)
                return 1;
            return i * factorial(i - 1);
        }
        static void Main(string[] args)
        {
            initianlizer o = new initianlizer { id = 15, name = "mohamed" };
            Console.WriteLine($"ID:{o.id},Name:{o.name}");
            Console.WriteLine("Factorial(Applies in Named Argument)");
            int fac = factorial(i: 5);
            Console.WriteLine(fac);
        }
    }
}
