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
        public static int returnSum(object n)
        {
            int sum = 0;
            for (int i = 1; i < (int)n; i++)
            {
                sum += 1;
            }
            return sum;
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
            Task con = t3.ContinueWith((f) =>
            {
                Console.WriteLine("Continue End.");
            });
            con.Wait();
            Task<int> da = Task<int>.Factory.StartNew(returnSum, 5);
            Console.WriteLine(da.Result);
            t3.Dispose();
            con.Dispose();
            da.Dispose();
            CancellationTokenSource cancel = new CancellationTokenSource();
            Task tsk = Task.Factory.StartNew(Cancelation, cancel.Token, cancel.Token);
            // Let tsk run until cancelled.


            try
            {
                // Cancel the task.
                cancel.Cancel();
                // Suspend Main() until tsk terminates.
                tsk.Wait();
            }
            catch (AggregateException exc)
            {
                if (tsk.IsCanceled)
                    Console.WriteLine("\ntsk Cancelled\n");
                // To see the exception, un-comment this line:
                // Console.WriteLine(exc);
            }
            finally
            {
                tsk.Dispose();
                cancel.Dispose();
            }
            Console.WriteLine("Main thread ending.");

        }
        public static void Cancelation(object ct)
        {
            CancellationToken token = (CancellationToken)ct;
            token.ThrowIfCancellationRequested();
            Console.WriteLine("MyTask() starting");
            for (int count = 0; count < 10; count++)
            {
                // This example uses polling to watch for cancellation.
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation request received.");

                    token.ThrowIfCancellationRequested();
                }
                Thread.Sleep(500);
                Console.WriteLine("In MyTask(), count is " + count);
            }
            Console.WriteLine("MyTask terminating");
        }
    }
}

