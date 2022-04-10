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
            Console.WriteLine(" {0:d3}", 5);
            Console.WriteLine(" {0:f1}", 5.62);
            Console.WriteLine(" {0:n3}", 5.6);
            Console.WriteLine(" {0:p0}", .5);
            Console.WriteLine(" {0:x}", 21);
            string format = String.Format("Sum: {0,3:D}, Product: {1,8:D}", 25, "Tomato");
            Console.WriteLine(format);
            int val = 19;
            Console.WriteLine(val.ToString("F5"));
            //picture formate or custome numeric formate
            Console.WriteLine("{0:#,##.#}", 1333333.6);
            Console.WriteLine("{0:#,##,.#}", 1333333.6);
            double num = 64354.2345;
            Console.WriteLine("{0:#.#;(#.##);0.00}", num);
            num = -num;
            Console.WriteLine("{0:#.##;(#.##);0.00}", num);
            num = 0.0;
            Console.WriteLine("{0:#.##;(#.##);0.00}", num);
            DateTime dt = DateTime.Now;
            Console.WriteLine("d format: {0:d}", dt);
            Console.WriteLine("D format: {0:D}", dt);
            Console.WriteLine("t format: {0:t}", dt);
            Console.WriteLine("T format: {0:T}", dt);
            Console.WriteLine("f format: {0:f}", dt);
            Console.WriteLine("F format: {0:F}", dt);
            Console.WriteLine("g format: {0:g}", dt);
            Console.WriteLine("G format: {0:G}", dt);
            Console.WriteLine("m format: {0:m}", dt);
            Console.WriteLine("M format: {0:M}", dt);
            Console.WriteLine("o format: {0:o}", dt);
            Console.WriteLine("O format: {0:O}", dt);
            Console.WriteLine("r format: {0:r}", dt);
            Console.WriteLine("R format: {0:R}", dt);
            Console.WriteLine("s format: {0:s}", dt);
            Console.WriteLine("u format: {0:u}", dt);
            Console.WriteLine("U format: {0:U}", dt);
            Console.WriteLine("y format: {0:y}", dt);
            Console.WriteLine("Y format: {0:Y}", dt);
            string t = dt.ToString("T");
            t += "\r";
            Console.WriteLine(t);
            Console.WriteLine("Use m for day of month: {0:m}", dt);
            Console.WriteLine("Use m for minutes: {0:%m}", dt);

            Direction d = Direction.West;
            Console.WriteLine("{0:G}", d);//g,f name of value
            Console.WriteLine("{0:F}", d);
            Console.WriteLine("{0:D}", d);//d value
            Console.WriteLine("{0:X}", d);

            #endregion

        }

        enum Direction { North, South, East, West }
        public static void results(int result)
        {
            if (result < 0)
                Console.WriteLine("A greater than a");
            else
                Console.WriteLine("a greater than A");
        }
    }

}
