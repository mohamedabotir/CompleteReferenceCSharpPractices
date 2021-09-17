using System;

delegate int Incr (int v);
delegate bool i(int a,int b,int c);
delegate bool IsEven(int v);

    class Program
    {
        static void Main(string[] args)
        {
           Incr increment = number=>++number;
           Console.WriteLine(increment(15));
           IsEven isEven = number=>number%2==0;
           Console.WriteLine(isEven(4));
           i inRange = (lower,upper,v)=>v>=lower && v<=upper;
           Console.WriteLine(inRange(1,5,2));
           #region Statement Lambdas
           Incr b = n=>{
               int mul =1;
            for (int i = 1; i <= n; i++)
            {
                mul = i*mul;
            }
            return mul;
           };
           Console.WriteLine(b(4));
           #endregion
        }
    }

