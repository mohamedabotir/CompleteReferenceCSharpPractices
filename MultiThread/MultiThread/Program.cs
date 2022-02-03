using System;
using System.Threading;

namespace MultiThread
{
    public class mytask
    {
        public int count = 0;
        Thread thrd;
        public mytask(string name)
        {

            thrd = new Thread(run);
            thrd.Name = name;
            thrd.Start();
        }
        public void run()
        {
            Console.WriteLine($"Starting run for  {thrd.Name}");
            do
            {
                Thread.Sleep(500);
                Console.WriteLine($"In {thrd.Name} : Count {count}");
                count++;
            } while (count < 10);
            Console.WriteLine($"{thrd.Name} terminated");
        }
    }
    public class task3
    {
        public int count = 0;
        public Thread thrd;
        public task3(string name, int num)
        {
            /*
             The only difference between the two is that a process won’t end until all of its 
foreground threads have ended, but background threads are terminated automatically after 
all foreground threads have stopped. By default, a thread is created as a foreground thread. 
             */
            thrd = new Thread(run);
            thrd.Name = name;

            thrd.Start(num);
        }
        public void run(object num)
        {
            Console.WriteLine($"Starting run for  {thrd.Name}");
            lock (this)
            {
                do
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"In {thrd.Name} : Count {count}");
                    count++;
                } while (count < (int)num);
                Console.WriteLine($"{thrd.Name} terminated");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            task3 task = new task3("task 2 ", 5);
            task.thrd.IsBackground = true;
            task3 mt2 = new task3("task 2 1", 6);
            task3 mt3 = new task3("task 2 2", 10);
            task.thrd.Join();
            mt2.thrd.Join();
            mt3.thrd.Join();
            Console.WriteLine("Begin..");//will fetch after all thread done
            do
            {
                Console.Write(".");
                Thread.Sleep(100);
            } while (task.thrd.IsAlive || mt2.thrd.IsAlive || mt3.thrd.IsAlive);
            Console.WriteLine("Hello World!");
            #region synchronization
            tickTack t = new tickTack();

            Clock c1 = new Clock("Tick", t);
            Clock c2 = new Clock("Tock", t);
            c1.thrd.Join();
            c2.thrd.Join();
            #endregion
            #region Mutx
            IncrMutx m1 = new IncrMutx("mIncr", 5);
            DecMutx m2 = new DecMutx("mDec", 10);
            m1.thrd.Join();
            m2.thrd.Join();
            #endregion
            #region Semaphore
            semaphore sm1 = new semaphore("sema1");
            semaphore sm2 = new semaphore("sema2");
            #endregion
            #region event
            MEvent mEvent = new MEvent("event");
            MEvent1 mEvent1 = new MEvent1("clientEvent");
            mEvent.thd.Join();
            mEvent1.thd.Join();
            #endregion
            #region interlocked
            Inter inter = new Inter("interlocked1");
            Inter inter1 = new Inter("interlocked2");
            #endregion
            #region abort
            abort abort = new abort("abort", 5);
            abort.thrd.Abort(ThreadState.Aborted);
            #endregion

        }
    }
}
