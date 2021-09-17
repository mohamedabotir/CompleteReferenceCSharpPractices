using System;

namespace Chapter17Reflection
{
    class a { }
    class b : a
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            int data;
            data = 15;
            double d;
            d = 18.0;
            a A = new a();
            b B = new b();
            if (B is b)
                Console.WriteLine("is the same a type");
            if (data is int)
                Console.WriteLine("is the same  int");
            #region as
            A = B as a; //cast a to b in one statement rather is
            if (B == null)
                Console.WriteLine("Can't Cast!");
            else
                Console.WriteLine("Cast Done");
            #endregion

        }
    }
}
