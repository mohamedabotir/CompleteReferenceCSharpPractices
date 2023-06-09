namespace ASyncPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Synchronous version

            Console.WriteLine("Synchronous  Version  ");
            Method1();
            Method2();
            Console.WriteLine("Main has Finished  ");

            #endregion
        }

        private static void Method2()
        {
            Console.WriteLine("Method 1 has Started");
            Thread.Sleep(1000);
            Console.WriteLine("Method 1 has Finished");
        }

        private static void Method1()
        {
            Console.WriteLine("Method 1 has Started");
            Thread.Sleep(1000);
            Console.WriteLine("Method 1 has Finished");

        }
    }
}