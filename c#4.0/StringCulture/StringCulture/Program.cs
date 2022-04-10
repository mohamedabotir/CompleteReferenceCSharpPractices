using System;
  delegate int assign(int number);
namespace StringCulture
{
    class Program
    {
    static int number = 10;
      static   int add(int n) {
            number += n;
            return number;
        }
        static void Main(string[] args)
        {
            checked
            {
                assign as = new assign(add);
                
                string s = "Mohamed";
                Console.WriteLine(s.IndexOf("am", StringComparison.CurrentCulture));

            }
        }
    }
}
