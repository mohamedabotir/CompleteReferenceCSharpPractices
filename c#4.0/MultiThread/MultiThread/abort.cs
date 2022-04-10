using System;
using System.Threading;

namespace MultiThread
{
    public class abort
    {
        public Thread thrd;
        public abort(string name, int n)
        {
            thrd = new Thread(this.run);
            thrd.Name = name;
            thrd.Start(n);
        }

        private void run(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
                try
                {
                    Console.WriteLine($"{thrd.Name} : {i + 1}");
                    Thread.Sleep(500);
                }
                catch (ThreadAbortException exc)
                {
                    if ((int)exc.ExceptionState == 0)
                    {
                        Console.WriteLine("Abort Cancelled! Code is " + exc.ExceptionState);
                        Thread.ResetAbort();
                    }
                    else
                        Console.WriteLine("Abort Cancelled! Code is " + exc.ExceptionState);
                }

            }
            Console.WriteLine("exit Normally");
        }
    }
}
