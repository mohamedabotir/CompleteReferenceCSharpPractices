using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
   public class TickTock
    {
        private object obj = new object();
       // [MethodImplAttribute(MethodImplOptions.Synchronized)] if you use that you must  remove lock
       // this work if all contents of method is locked not recommened use it with public class or instance
        public void Tick(bool isRunning) {
            lock (obj)
            {

            if (!isRunning)
            {

                Monitor.Pulse(obj);
                return;
            }
            Console.WriteLine("Tick");
            Monitor.Pulse(obj);
            Monitor.Wait(obj);
            }
        }

        public void Tock(bool isRunning)
        {
            lock (obj)
            {


            if (!isRunning)
            {

                Monitor.Pulse(obj);
                return;
            }
            Console.WriteLine("Tock");
            Monitor.Pulse(obj);
            Monitor.Wait(obj);
            }
        }
    }
    public class useCommunication {
        TickTock tk;
       public Thread thrd;
        public useCommunication(string name,TickTock t)
        {
            thrd = new Thread(run);
            thrd.Name = name;
            tk = t;
            thrd.Start();
        }

        private void run()
        {
            if (thrd.Name == "Tick")
            {
                for (int i = 0; i < 5; i++) tk.Tick(true);
                tk.Tick(false);
            }
            else
            {
                for (int i = 0; i < 5; i++) tk.Tock(true);
                tk.Tock(false);
            }
        }
    }
}
