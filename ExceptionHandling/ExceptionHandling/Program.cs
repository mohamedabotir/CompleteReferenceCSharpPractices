using System;
using System.Security.Cryptography;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            #region basic Exciption
            int[] data = { 1,150,210,3250,111};
            int[] div = { 1,5,6,0};
            try
            {
                try
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        for (int j = 0; j < div.Length; j++)
                        {
                            data[i] = data[i] / div[j];
                        }

                    }
                }
                catch (DivideByZeroException) { Console.WriteLine("Divide By Zero Error"); }
            }
            catch
            {
                Console.WriteLine("Some thing Gone Wrong Go to Manuel Doc");
            }
            finally {
                Console.WriteLine("System Closing");
            }
            #endregion
            #region custom Exception
            try
            {
                ArrayTest object1 = new ArrayTest(5, 3);
                object1[-1] = 200;

            }
            catch (customExciption exc)
            {
                Console.WriteLine(exc);
            }
            finally {
                Console.WriteLine("Custom Exciption End");
            }
            try
            {
           
                ArrayTest object2 = new ArrayTest(3, 5);

            }
            catch (customExciption exc)
            {
                Console.WriteLine(exc);
                Console.WriteLine("StackTrace:"+exc.StackTrace);
                Console.WriteLine("TargetSite:"+exc.TargetSite);

            }
            finally
            {
                Console.WriteLine("Custom Exciption End");
            }
            #endregion
           
        }
    }
}
