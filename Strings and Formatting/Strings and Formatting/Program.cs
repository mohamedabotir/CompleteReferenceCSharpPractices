using System;

namespace Strings_and_Formatting
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] data = { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' };
            String converter = new String('5', 5);//repeat char n times
            Console.WriteLine(converter);
            String converter1 = new String(data, 0, 5);
            Console.WriteLine(converter1);
            string name = "ali";
            string id = "1&1";
            Console.WriteLine(name == id);
            Console.WriteLine(name.CompareTo(id));
            string a = "a", b = "A";
            Console.WriteLine(String.Compare(a, b, true));
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(String.Equals(a, b, StringComparison.OrdinalIgnoreCase));
            int result = String.Compare(a, b, StringComparison.CurrentCulture);
            results(result);
            result = String.Compare(a, b, StringComparison.Ordinal);
            results(result);
            #region split and join
            string str = "One if by land, two if by sea.";
            char[] seps = { ' ', '.', ',' };
            // Split the string into parts.
            string[] parts = str.Split(seps);
            Console.WriteLine("Pieces from split: ");
            for (int i = 0; i < parts.Length; i++)
                Console.WriteLine(parts[i]);
            // Now, join the parts.
            string whole = String.Join(" | ", parts);
            Console.WriteLine("Result of join: ");
            Console.WriteLine(whole);
            parts = str.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Pieces from split: ");
            for (int i = 0; i < parts.Length; i++)
                Console.WriteLine(parts[i]);
            #endregion
            Console.WriteLine(a.PadLeft(5));// add  5 spaces from left 
            Console.WriteLine(a.PadLeft(5, '/'));
            #region formate
            Console.WriteLine(" {0:d3}",5);
            Console.WriteLine(" {0:f1}", 5.62);
            Console.WriteLine(" {0:n3}", 5.6);
            Console.WriteLine(" {0:p0}", .5);
            Console.WriteLine(" {0:x}", 21);
            #endregion
        }


        public static void results(int result)
        {
            if (result < 0)
                Console.WriteLine("A greater than a");
            else
                Console.WriteLine("a greater than A");
        }
    }

}
