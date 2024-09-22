namespace ThreadingAndDataSynchronization;

public class AutoReset
{
    AutoResetEvent autoResetEvent = new AutoResetEvent(false);

    public AutoReset()
    {
        new Task(() => DoSomething1()).Start();
        new Task(() => DoSomething2()).Start();
    }
    
    void DoSomething1()
    {
        Console.WriteLine("DoSomething1");
        Console.WriteLine("Waiting for invoke Signal");
        Task.Delay(1000);
        Console.WriteLine("set signal");
        autoResetEvent.Set();

    }

    void DoSomething2()
    {
        Console.WriteLine("DoSomething2");
        Console.WriteLine("Waiting for Signal");
        Task.Delay(500);
        autoResetEvent.WaitOne();
        Console.WriteLine("DoSomething2 Signaled");
    }
}