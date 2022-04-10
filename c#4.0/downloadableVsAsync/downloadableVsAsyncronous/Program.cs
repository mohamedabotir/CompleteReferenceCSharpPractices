using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace downloadableVsAsyncronous
{
    class Program
    {
        public static async Task DownlaodData(string url, string path)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64)");
                byte[] data = await client.DownloadDataTaskAsync(url);
                Console.WriteLine("1 -5");
                using (var file = File.OpenWrite(path))
                {
                    Console.WriteLine("2 -2");
                    await file.WriteAsync(data, 0, data.Length);
                }
            }
        }
        static async Task Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string url = "https://www.apress.com/in/apress-open/apressopen-titles";
            string path = "C:\\App\\download.txt";
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            Console.WriteLine("Start");
              await DownlaodData(url, path);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
