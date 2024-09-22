  var LongLifeRunningInMin = TimeSpan.FromMinutes(60);
  var ShortLifeRunningInMin=TimeSpan.FromMinutes(1);
  var cancellationTokenSource = new CancellationTokenSource();
  ISync booking = new BookingBusiness();
  var bookingJob =  new Task(()=>SyncJobs(booking.Sync,ShortLifeRunningInMin,cancellationTokenSource.Token),TaskCreationOptions.LongRunning);
   Console.WriteLine("Press any key to stop...");
   bookingJob.Start();
   Console.ReadKey();
  cancellationTokenSource.Cancel();
  bookingJob.Wait();
  
  
 void SyncJobs(Action doJob,TimeSpan sleepInMin,CancellationToken cancellationToken)
 {
     while (!cancellationToken.IsCancellationRequested)
     {
         try
         {
             doJob();
             Task.Delay(sleepInMin, cancellationToken);
         }
         catch (TaskCanceledException)
         {
             Console.WriteLine("Job cancelled!");
             break;
         }
         catch (Exception e)
         {
             Console.WriteLine(e);
         }
     }
 }

 interface ISync
 {
    void Sync();
 }
 public class BookingBusiness : ISync
 {
     public void Sync()
     {
         Console.WriteLine("Sync:{0} on:{1}","Booking",DateTime.Today); 
     }
 }