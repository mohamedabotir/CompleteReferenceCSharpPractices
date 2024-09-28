
// auto reset

using ThreadingAndDataSynchronization;

//new AutoReset();// execution sync

//new JoinSync(); // join thread to main to acheive execution sync

//Data Sync do with lock for critical section

   
/*
 *
  Task.Run vs Task.Factory.startnew 
  Task.Factory.StartNew(A, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);   = Task.Run(A)
  the main different is Task.Run always run task as DenychildAttach
 * 
 Parallel.For(0,500, e =>
 {
  Console.WriteLine("Value :{0} Parallel Thread :{1}",e,Thread.CurrentThread.ManagedThreadId);
  Thread.Sleep(1000);
 });
 */
 
 //Console.WriteLine("Main Thread Finished:{0}",Thread.CurrentThread.ManagedThreadId);
 
 // delay make thread busy for idle status , but sleep is free thread temporary to be reuse , after period finished will continue executing again 
 
 /*
  *Multithreading
  Time ───────────────────────────►
    
    Thread 1: |----Task A---->|--Task B-->|---Task A (continue)---|
                 ↑                   ↑
                 |                   |
    Thread 2:    |  |----Task C---->|-------Task D-------|
                         ↑
                         |
    Thread 3:       |----Task E---->|-----Task F-----|
    
  *Parallel
    Core 1: |----Task1 (Subtask A)----|
    Core 2: |----Task1 (Subtask B)----|
    Core 3: |----Task2 (Subtask A)----|
    Core 4: |----Task2 (Subtask B)----|
    
  *Asynchronous
  Time:   |----Task1 (Waiting)----|----Task1 (Complete)----|
    |----Task2----|                       |----Task3----|

  */
  
  
  // continution will runs on background else if you need sync with main thread use wait();
  Task t1 = new Task(e=>
  {
      Console.WriteLine("Task 1 :{0}", Thread.CurrentThread.ManagedThreadId);
  }, TaskCreationOptions.LongRunning);
  
  var continution = t1.ContinueWith(e=>Console.WriteLine("StatusOf1:{0},Task 2 :{1}",e.Status, Thread.CurrentThread.ManagedThreadId));
  t1.Start();// this also may finished after main thread as this executed on separated one
  //continution.Wait();
  Console.WriteLine("Main Thread Finished:{0}",Thread.CurrentThread.ManagedThreadId);   