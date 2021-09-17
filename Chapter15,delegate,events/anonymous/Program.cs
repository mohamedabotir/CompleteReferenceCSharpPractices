using System;

//delegate void CountIt(int i); anonymous with delegate statement
delegate int CountIt(int end);


class Program
{
    #region  Use Outer Variables with Anonymous Methods
    static CountIt Counter()
    {
        int sum = 0;
        // Here, a summation of the count is stored
        // in the captured variable sum.
        CountIt ctObj = delegate (int end)
        {
            for (int i = 0; i <= end; i++)
            {
                Console.WriteLine(i);
                sum += i;
            }
            return sum;
        };
        return ctObj;
    }
    #endregion

    static void Main(string[] args)
    {
        #region anonymous with delegate statement
        //can be with argument or not 
        /*
         CountIt func = delegate (int z)
         {
             // This is the block of code passed to the delegate.
             for (int i = 0; i <= z; i++)
                 Console.WriteLine(i * 3);
         };
         func(15);
         */
        #endregion
        #region  Use Outer Variables with Anonymous Methods
        CountIt count = Counter();
        int result;
        result = count(3);
        Console.WriteLine("Summation of 3 is " + result);
        Console.WriteLine();
        result = count(5);
        Console.WriteLine("Summation of 5 is " + result);
        #endregion
    }
}

