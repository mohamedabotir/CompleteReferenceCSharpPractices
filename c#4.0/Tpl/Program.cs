using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tpl
{
    class Program
    {
        static int[] Data;
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
            Parallel.Invoke(pTask1, pTask2);
            Data = new int[10000000];
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Parallel.For(0, Data.Length, transform);
            watch.Stop();
            Console.WriteLine($"Parallel Estimate Time is:{watch.Elapsed.TotalSeconds}");
            watch.Reset();
            watch.Start();
            for (int i = 0; i < Data.Length; i++)
            {
                transform(i);
            }
            watch.Stop();
            Console.WriteLine($"Sequential Estimate Time is:{watch.Elapsed.TotalSeconds}");
            Data[100] = -10;
            Data[2000] = 2000;
            ParallelLoopResult pa = Parallel.For(0, Data.Length, trytransform);

            if (!pa.IsCompleted)
                Console.WriteLine("\nLoop Terminated early because a " +
                "negative value was encountered\n" +
                "in iteration number " +
                pa.LowestBreakIteration + ".\n");

            Console.WriteLine(Data[100] + "  ," + Data[2000]);
            int[] Data2 = new int[100];
            Data2[99] = -2000;
            Data2[10] = -10;

            ParallelLoopResult pa1 = Parallel.ForEach(Data2, p2);
            if (!pa1.IsCompleted)
                Console.WriteLine("\nLoop Terminated early because a " +
                "negative value was encountered\n" +
                "in iteration number " +
                pa1.LowestBreakIteration + ".\n");

            Console.WriteLine(Data[100] + "  ," + Data[2000]);

            var filter = from val in Data2.AsQueryable()
                         where val < 0
                         select val;
            foreach (var item in filter)
            {
                Console.WriteLine(item);
            }
            CancellationTokenSource can = new CancellationTokenSource();
            var fil = from val in Data2.AsParallel().WithCancellation(can.Token)
                      where val < 0
                      select val;
            Task tr = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                can.Cancel();
            });
            try
            {
                foreach (var item in fil)
                {
                    Console.WriteLine(item);

                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex);

            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                tr.Wait();
                can.Dispose();
                tr.Dispose();
            }
        }
        public static void data(out int d)
        {
            d = 50;
        }
        public static void p2(int v, ParallelLoopState p)
        {
            if (v < 0) p.Break();
            Console.WriteLine("Value: " + v);
        }
        public static void trytransform(int i, ParallelLoopState st)
        {
            if (Data[i] < 0)
            {
                Data[i] *= 2;
                Console.WriteLine($"Exit in iteration {i}");
                st.Break();
            }
            Data[i] = Data[i] + 10;
            if (Data[i] < 1000) Data[i] = 0;
            if (Data[i] > 1000 & Data[i] < 2000) Data[i] = 100;
            if (Data[i] > 2000 & Data[i] < 3000) Data[i] = 200;
            if (Data[i] > 3000) Data[i] = 300;
        }
        public static void transform(int i)
        {

            Data[i] = Data[i] / 10;
            if (Data[i] < 1000) Data[i] = 0;
            if (Data[i] > 1000 & Data[i] < 2000) Data[i] = 100;
            if (Data[i] > 2000 & Data[i] < 3000) Data[i] = 200;
            if (Data[i] > 3000) Data[i] = 300;
        }
        public static void pTask1()
        {
            Console.WriteLine("Task1");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task1: {i}");
                Thread.Sleep(500);
            }
            Console.WriteLine("Task1 End.");
        }

        public static void pTask2()
        {
            Console.WriteLine("Task2");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task2: {i}");
                Thread.Sleep(500);
            }
            Console.WriteLine("Task2 End.");
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

