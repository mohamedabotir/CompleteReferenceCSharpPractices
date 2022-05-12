#region async await

//Task task = Task.Run(() =>
//{
//    Console.WriteLine("Inside Task");
//});
//Task.WaitAll(task);


using System.Diagnostics;
using System.Runtime.CompilerServices;

var watch = new Stopwatch();
var cancellationToken = new CancellationTokenSource();
var listOfFiles = new List<Tuple<string, string, long, DateTime>>();
var t = Task.Run(() => {
        string dir = "C:\\Windows\\System32\\";
        object obj = new Object();
        if (Directory.Exists(dir))
        {
            watch.Start();
            Parallel.ForEach(Directory.GetFiles(dir),
                f => {
                    if (cancellationToken.Token.IsCancellationRequested)
                        cancellationToken.Token.ThrowIfCancellationRequested();
                    var fi = new FileInfo(f);
                    lock (obj)
                    {
                        listOfFiles.Add(Tuple.Create(fi.Name, fi.DirectoryName, fi.Length, fi.LastWriteTimeUtc));
                        Monitor.Pulse(obj);
                    }
                    
                });
            watch.Stop();
            Console.WriteLine("\n"+watch.ElapsedMilliseconds);

        }
    }
    , cancellationToken.Token);
await Task.Yield();//for enforce method to work asynchronous 
try
{
    await t;
    Console.WriteLine("Retrieved information for {0} files.", listOfFiles.Count);
}
catch (AggregateException e)
{
    Console.WriteLine("Exception messages:");
    foreach (var ie in e.InnerExceptions)
        Console.WriteLine("   {0}: {1}", ie.GetType().Name, ie.Message);

    Console.WriteLine("\nTask status: {0}", t.Status);
}
finally
{
    cancellationToken.Dispose();
    
}
#endregion

#region Caller

TraceMessage("Caller");

static void TraceMessage(string message,
    [CallerMemberName] string memberName = "",
    [CallerFilePath] string filePath = "",
    [CallerLineNumber] int lineNumber = 0)
{
    Trace.WriteLine("Message:" + message);
    Trace.WriteLine("Member:" + memberName);
    Trace.WriteLine("FilePath:" + filePath);
    Trace.WriteLine("Line:" + lineNumber);
}

#endregion

#region CallerArgumentExpression

string name = null;

ValidateArgument(nameof(name),name is not null);//caller argument expression read condition as string to make exception more readable


static void ValidateArgument(string parameterName, bool condition, [CallerArgumentExpression("condition")] string? message = null)
{
    if (!condition)
    {
        throw new ArgumentException($"Argument failed validation: <{message}>", parameterName);
    }
}

#endregion




