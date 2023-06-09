﻿namespace ASyncPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Synchronous version

            //Console.WriteLine("Synchronous  Version  ");
            //Method1();
            //Method2();
            //Console.WriteLine("Main has Finished  ");
            //  static void Method2()
            //{
            //    Console.WriteLine("Method 1 has Started");
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Method 1 has Finished");
            //}

            //  static void Method1()
            //{
            //    Console.WriteLine("Method 1 has Started");
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Method 1 has Finished");

            //}
            #endregion 
            #region ASynchronous version

            Console.WriteLine("ASynchronous  Version  ");
             
            var thread1 = new Thread(e =>
            {
                Console.WriteLine("Method 1 has Started");
                Thread.Sleep(1000);
                Console.WriteLine("Method 1 has Finished");
            });
            thread1.Start();    

            Thread.Sleep(10);
            Method2();
            thread1.Join();
            Console.WriteLine("End Main().");


           
            #endregion
        }
        static void Method2()
        {
            Console.WriteLine("Method 2 has Started");
            Thread.Sleep(10);
            Console.WriteLine("Method 2 has Finished");
        }


    }
}