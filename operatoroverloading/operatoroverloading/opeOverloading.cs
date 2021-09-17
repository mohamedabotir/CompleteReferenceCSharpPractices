using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace operatoroverloading
{
    class opeOverloading
    {
        
       public int number1 { set; get; }
        public int number2 { set; get; }

      public   opeOverloading(int number1 = 0, int number2 = 0)
        {
            this.number1 = number1;
            this.number2 = number2;
        }
        public static opeOverloading operator +(opeOverloading first, opeOverloading second)
        {
            opeOverloading sum = new opeOverloading();
            sum.number1 = first.number1 + second.number1;
            sum.number2 = first.number2 + second.number2;
            return sum;

        }
        public static int[] sumofValueType(params int[] data)
        {
            int cur;
            int j;
            for (int i = 0; i < data.Length; i++)
            {
                cur = data[i];
                j = i - 1;
                while (j >= 0 && data[j] < cur)
                {
                    data[j+1] = data[j--];
                }
                data[j + 1] = cur;
            }
            return data;
        }
        public override string ToString()
        {
            return $"Number1:{number1},Number2:{number2}";
        }
    }
}
