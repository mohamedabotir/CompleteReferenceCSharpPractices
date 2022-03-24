// See https://aka.ms/new-console-template for more information

//task asynchronous and thread synchronous
Console.WriteLine("Hello, World!");
Task tsk = new Task(tpl);
Task tsk2 = new Task(tpl);
tsk.Start();
tsk2.Start();
// Keep Main() alive until MyTask() finishes.
//for (int i = 0; i < 100; i++)
//{
//    Console.Write(".");
//    Thread.Sleep(100);
//}
//tsk.Wait();
//tsk2.Wait();
Task.WaitAll(tsk,tsk2);
Console.WriteLine("Main thread ending.");

//TPL
static void tpl() {
    Console.WriteLine($"Tpl is Starting:{Task.CurrentId}");
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Thread[{Task.CurrentId}]:{i}");
        Thread.Sleep(500);
    }
    Console.WriteLine("Terminate!");
}