using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tpl
{
    class Program
    {
        static void mytask()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"inside Task:{Task.CurrentId} , {i}");
                Thread.Sleep(500);
            }
            Console.WriteLine($"Task{Task.CurrentId} End.");
        }
        static void mytaskContinue(Task t3)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Continue Task:{Task.CurrentId} , {i}");
                Thread.Sleep(500);
            }
            Console.WriteLine($"Continue:{Task.CurrentId} End.");
        }
        static void Main(string[] args)
        {
            //Task t = new Task(mytask);
            //t.Start();
            Task t = Task.Factory.StartNew(mytask);
            //for (int i = 0; i < 60; i++)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(100);
            //}
            Task t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Task {Task.CurrentId} started");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"inside Task:{Task.CurrentId} , {i}");
                }
                Console.WriteLine($"Task{Task.CurrentId} End.");

            });
            Task.WaitAll(t, t2);
            t.Dispose();
            t2.Dispose();
            Task t3 = Task.Factory.StartNew(mytask);
            Task con = t3.ContinueWith(mytaskContinue);
            con.Wait();
            t3.Dispose();
            con.Dispose();
        }
    }
}
