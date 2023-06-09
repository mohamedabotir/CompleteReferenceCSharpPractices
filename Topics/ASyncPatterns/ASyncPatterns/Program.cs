using System.ComponentModel;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASyncPatterns
{
    internal class Program
    {
        delegate void InvokeMethod(int sleep);
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

            //Console.WriteLine("ASynchronous  Version  ");

            //var thread1 = new Thread(e =>
            //{
            //    Console.WriteLine("Method 1 has Started");
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Method 1 has Finished");
            //});
            //thread1.Start();    

            //Thread.Sleep(10);
            //Method2();
            //thread1.Join();
            //Console.WriteLine("End Main().");



            #endregion

            #region ThreadPool
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Method2));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Method3),10);

            //Method1();
            //Console.WriteLine("End Main().");
            #endregion

            #region IAsyncResult Pattern 
            //InvokeMethod invoke = DoAsyncResult;
            //IAsyncResult asyncResult =   invoke.BeginInvoke(1000,null,null);// not supported it support in platform .NET Framework 4.7.2
            //
            #endregion

            #region Event-Based Pattern
            WebClient client = new();
            Uri myLocation = new Uri(@"E:\]\library\Advanced ASP.NET Core 3 Security.pdf");

            client.DownloadFileAsync(myLocation, @"C:\Advanced ASP.NET Core 3 Security.pd");
            client.DownloadFileCompleted += DownloadCompleted;
            #endregion
        }
        public  static void Method2(object state)
        {
            Console.WriteLine("Method 2 has Started");
            Thread.Sleep(100);
            Console.WriteLine("Method 2 has Finished");
        } 
        public  static void Method3(object counter)
        {
            Console.WriteLine("---Method3() has started.");
            int upperLimit = (int)counter;
            for (int i = 0; i < upperLimit; i++)
            {
                Console.WriteLine("---Method3() prints 3.0{0}", i);
            }
            Thread.Sleep(10);
            Console.WriteLine("---Method3() has finished.");
        }  
        static void Method1()
        {
            Console.WriteLine("Method 1 has Started");
            Thread.Sleep(1000);
            Console.WriteLine("Method 1 has Finished");
        }
        static void DoAsyncResult(int sleep)
        {
            Console.WriteLine("Start DoAsyncResult");

            Thread.Sleep(sleep);
            Console.WriteLine("End DoAsyncResult");
        }
        private static void DownloadCompleted(object sender,
AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Successfully Download the file now.");
        }

    }
}