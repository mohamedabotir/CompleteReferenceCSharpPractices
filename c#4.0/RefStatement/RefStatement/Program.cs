using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefStatement
{
    class Program
    {
         void sqrt(ref int i) {
            i *= i;
        }
         void swap(ref int i,ref int ii,out int s)
         {
             int temp = i;
             i = ii;
             ii = temp;
             s = i;
         }
        static void Main(string[] args)
        {
            Program obj1 = new Program();
            Console.WriteLine("NumberOfProgram:");
            int number = int.Parse(Console.ReadLine());
            obj1.sqrt(ref number);
            Console.WriteLine("Multiple:" + number);
            int number1 = 5;
            int number2 = 120;
            int s;
            Console.WriteLine("Before Swap\nNumber1:"+number1+","+"Number2:"+number2);
            obj1.swap(ref number1, ref number2, out s);
            Console.WriteLine("After Swap\nNumber1:" + number1 + "," + "Number2:" + number2);
        }
    }
}
