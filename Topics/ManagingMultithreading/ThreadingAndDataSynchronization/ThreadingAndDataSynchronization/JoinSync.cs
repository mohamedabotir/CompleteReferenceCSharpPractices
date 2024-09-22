namespace ThreadingAndDataSynchronization;

public class JoinSync
{
     static double value = 5000;
     private Thread thread1;
     private Thread thread2;

    public JoinSync()
    {
          thread1=new Thread(DoSomething1);
            thread1.Start();
            thread1.Join();
            thread2=new Thread(DoSomething2);
            thread2.Start();
            thread2.Join();

    }
    void DoSomething1()
    {
        for (int i = 0; i < 100; i++)
        {
            value -= i;
            Console.WriteLine("Subtract:{0} with {1}, ThreadId:{2}", value,i,Thread.CurrentThread.ManagedThreadId);
            Task.Delay(1000);
        }

    }

    void DoSomething2()
    {
        for (int i = 0; i < 100; i++)
        {
            value += i*2;
            Console.WriteLine("Add:{0} with {1}, ThreadId:{2}", value,i,Thread.CurrentThread.ManagedThreadId);
            Task.Delay(1000);
        }
    }
}