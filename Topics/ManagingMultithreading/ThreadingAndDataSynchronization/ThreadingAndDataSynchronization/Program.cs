
// auto reset

using ThreadingAndDataSynchronization;

//new AutoReset();// execution sync

new JoinSync(); // join thread to main to acheive execution sync

//Data Sync do with lock for critical section

   
/*
 *
  Task.Run vs Task.Factory.startnew 
  Task.Factory.StartNew(A, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);   = Task.Run(A)
  the main different is Task.Run always run task as DenychildAttach
 * 
 */