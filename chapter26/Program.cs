using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-6.0");

HttpWebResponse res = (HttpWebResponse)  req.GetResponse();
Stream data = res.GetResponseStream();
int ch;
for (var i = 1;; i++)
{
    ch=data.ReadByte();
    if(ch==-1)break;
    Console.Write((char)ch);
}
string []keys = res.Headers.AllKeys;
foreach(var i in keys)
foreach(var v in res.Headers.GetValues(i))
Console.WriteLine(v);
Console.ReadKey();
res.Close();

//new 
HttpClient client = new HttpClient();

HttpResponseMessage response = await client.GetAsync(@"https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-6.0");

response.EnsureSuccessStatusCode();
Console.WriteLine(await response.Content.ReadAsStringAsync());
foreach(var i in response.Headers.AcceptRanges){
    Console.WriteLine(i);
}
ThreadPool.QueueUserWorkItem(callBack: Exec!);
Console.WriteLine("main method do some operations");
Thread.Sleep(1000);
TraceMessage("hi from main");



//webclient
WebClient web = new WebClient();
Uri uri = new Uri(@"https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-6.0");
string fileName = "data.txt";
try{
web.DownloadFile(uri,fileName);
}catch{

}finally{
web.Dispose();
}

 static void Exec(Object state){
  Console.WriteLine("Inside Exec Function");
}
 void TraceMessage(string name,[CallerMemberName] string memberName="",[CallerFilePath]string path="",[CallerLineNumber] int num=0){
Trace.WriteLine("message: " + name);
    Trace.WriteLine("member name: " + memberName);
    Trace.WriteLine("source file path: " + path);
    Trace.WriteLine("source line number: " + num);
}