using System;
using System.Threading;

namespace MultiThread
{
    public class tickTack
    {
        object lockOn = new object();
        //we can use [MethodImplAttribute(MethodImplOptions.Synchronized)]
        public void Tick(bool isRunning)
        {
            lock (lockOn)
            {

                if (!isRunning)
                {
                    Monitor.Pulse(lockOn);
                    return;
                }
                Console.WriteLine("Tick");
                Monitor.Pulse(lockOn);
                Monitor.Wait(lockOn);
            }
        }

        public void Tock(bool isRunning)
        {
            lock (lockOn)
            {

                if (!isRunning)
                {
                    Monitor.Pulse(lockOn);
                    return;
                }
                Console.WriteLine("Tock");
                Monitor.Pulse(lockOn);
                Monitor.Wait(lockOn);
            }
        }
    }
    class Clock
    {
        public Thread thrd;
        tickTack tt;
        public Clock(string name, tickTack t)
        {
            tt = t;
            thrd = new Thread(this.Run);
            thrd.Name = name;
            thrd.Start();
        }

        private void Run()
        {
            if (thrd.Name == "Tick")
            {
                for (int i = 0; i < 5; i++)
                    tt.Tick(true);
                tt.Tick(false);

            }



            if (thrd.Name == "Tock")
            {
                for (int i = 0; i < 5; i++)
                    tt.Tock(true);
                tt.Tock(false);

            }

        }
    }
}
