using System;
using System.Threading;

namespace MultiThread
{

    public class SharedRes
    {
        public static int count;
        public static Mutex mtx = new Mutex();
        public static Semaphore smp = new Semaphore(2, 2);
        public static ManualResetEvent Mevent = new ManualResetEvent(false);
        public static int inter;
    }
    public class IncrMutx
    {
        int num;
        public Thread thrd;
        public IncrMutx(string name, int n)
        {
            thrd = new Thread(this.Run);
            thrd.Name = name;
            num = n;
            thrd.Start();
        }

        private void Run(object obj)
        {
            Console.WriteLine($"The Thread {thrd.Name} is waiting Mutx");
            SharedRes.mtx.WaitOne();
            Console.WriteLine($"The Thread {thrd.Name} is aquire Mutx");
            do
            {
                Thread.Sleep(500);
                SharedRes.count++;
                Console.WriteLine($"we are in {thrd.Name} and count = {SharedRes.count}");
                num--;

            } while (num > 0);
            Console.WriteLine($"{thrd.Name} Released Resources");
            SharedRes.mtx.ReleaseMutex();

        }
    }
    public class DecMutx
    {
        int num;
        public Thread thrd;
        public DecMutx(string name, int n)
        {
            thrd = new Thread(this.Run);
            thrd.Name = name;
            num = n;
            thrd.Start();
        }

        private void Run(object obj)
        {
            Console.WriteLine($"The Thread {thrd.Name} is waiting Mutx");
            SharedRes.mtx.WaitOne();
            Console.WriteLine($"The Thread {thrd.Name} is aquire Mutx");
            do
            {
                Thread.Sleep(500);
                SharedRes.count--;
                Console.WriteLine($"we are in {thrd.Name} and count = {SharedRes.count}");
                num--;

            } while (num > 0);

            Console.WriteLine($"{thrd.Name} Released Resources");
            SharedRes.mtx.ReleaseMutex();

        }
    }
    public class semaphore
    {
        Thread thrd;
        public semaphore(string name)
        {
            thrd = new Thread(this.Run);
            thrd.Name = name;
            thrd.Start();
        }

        private void Run(object obj)
        {
            Console.WriteLine($"Thead {thrd.Name} is wait Semaphore");
            SharedRes.smp.WaitOne();
            Console.Write($"Thread {thrd.Name} is aquire Semaphore");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"In side {thrd.Name} count {i}");
            }
            Console.WriteLine($"Thread {thrd.Name} release Semaphore");
            SharedRes.smp.Release();
        }
    }
    public class MEvent
    {
        public Thread thd;
        public MEvent(string name)
        {
            thd = new Thread(this.run);
            thd.Name = name;
            thd.Start();
        }

        private void run()
        {
            Console.WriteLine($"{thd.Name} Start.");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{thd.Name}: {i}");
                Thread.Sleep(500);
            }
            SharedRes.Mevent.Set();
        }
    }

    public class MEvent1
    {
        public Thread thd;
        public MEvent1(string name)
        {
            thd = new Thread(this.run);
            thd.Name = name;
            thd.Start();
        }

        private void run()
        {
            Console.WriteLine($"{thd.Name}  aquire.");
            SharedRes.Mevent.WaitOne();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{thd.Name}: {i}");
                Thread.Sleep(500);
            }
            SharedRes.Mevent.Reset();

        }
    }

    public class Inter
    {
        Thread thd;
        public Inter(string name)
        {
            thd = new Thread(this.run);
            thd.Name = name;
            thd.Start();
        }

        private void run()
        {
            Console.WriteLine($"{thd.Name} is start.");
            for (int i = 1; i < 6; i++)
            {
                Interlocked.Increment(ref SharedRes.inter);
                Console.WriteLine($"{thd.Name}: {SharedRes.inter}");
                Thread.Sleep(500);
            }
        }
    }






}
