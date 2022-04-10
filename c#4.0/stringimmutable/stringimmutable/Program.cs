using System;

namespace stringimmutable
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "mydata is safe here ! i'am didn't feel that";
            Console.WriteLine(data.Substring(0,9));
        }
    }
}
