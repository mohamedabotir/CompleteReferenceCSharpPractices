using System;
using System.Threading;

namespace MultiThreading
{
    public class myTask {
        public int count = 0;
        string name = "";
        public myTask(string name)
        {
            this.name = name;
        }
        public void start() {
            Console.WriteLine($"thread {name}");
            do
            {
                Thread.Sleep(500);
                Console.WriteLine("In " + name +
                ", Count is " + count);
                count++;
            } while (count < 10);
        }
    }
    public class synchronization {
       public int sum;
        object lockOn = new object();
        public virtual int SumIt(int[] nums)
        {
            lock (lockOn)
            { // lock the entire method
                sum = 0; // reset sum
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    Console.WriteLine("Running total for " +
                    Thread.CurrentThread.Name +
                    " is " + sum);
                    Thread.Sleep(500); // allow task-switch
                }
                return sum;
            }
        }
    }
    public class alterSynchronization : synchronization {
        public override int SumIt(int[] nums)
        {
           // lock the entire method
                sum = 0; // reset sum
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    Console.WriteLine("Running total for " +
                    Thread.CurrentThread.Name +
                    " is " + sum);
                    Thread.Sleep(500); // allow task-switch
                }
                return sum;
            }
        }
    public class alterImplSync {
        public Thread Thrd;
        int[] a;
        int answer;
        static synchronization sa = new synchronization();
        public alterImplSync(string name, int[] nums)
        {
            a = nums;
            Thrd = new Thread(run);
            Thrd.Name = name;
            Thrd.Start();
        }

        private void run()
        {
            Console.WriteLine(Thrd.Name + " starting.");
            Monitor.Enter(sa);
            answer = sa.SumIt(a);
            Monitor.Exit(sa);
            Console.WriteLine("Sum for " + Thrd.Name +
            " is " + answer);
            Console.WriteLine(Thrd.Name + " terminating.");
        }
    }
    class Program
    {
        public Thread Thrd;
        int[] a;
        int answer;
        static synchronization sa = new synchronization();
        public Program(string name,int[]nums)
        {
            a = nums;
            Thrd = new Thread(run);
            Thrd.Name = name;
            Thrd.Start();
        }

        private void run()
        {
            Console.WriteLine(Thrd.Name + " starting.");
            answer = sa.SumIt(a);
            Console.WriteLine("Sum for " + Thrd.Name +
            " is " + answer);
            Console.WriteLine(Thrd.Name + " terminating.");
        }

        static void Main(string[] args)
        {
            #region thread
            myTask task = new myTask("f112");
            Thread thread = new Thread(task.start);
            
            thread.Start();
            do
            {
                Console.Write(".");
                Thread.Sleep(50);
            } while (task.count != 10);
            Console.WriteLine("Main thread ending.");
            #endregion
            #region synchronization
            //int[] a = { 1, 2, 3, 4, 5 };
            //Program mt1 = new Program("Child #1", a);
            //Program mt2 = new Program("Child #2", a);
            #endregion

            #region Alternative way synchronization
            //int[] data = { 1, 2, 3, 4, 5 };
            //alterImplSync c4 = new alterImplSync("Child #4", data);
            //alterImplSync c5 = new alterImplSync("Child #5", data);
            #endregion
            #region thread communication
            TickTock tt = new TickTock();
            useCommunication com1 = new useCommunication("Tick", tt);
            useCommunication com2 = new useCommunication("Tock", tt);
            com1.thrd.Join();
            com2.thrd.Join();
            Console.WriteLine("Clock End");
            #endregion

        }
    }
}
