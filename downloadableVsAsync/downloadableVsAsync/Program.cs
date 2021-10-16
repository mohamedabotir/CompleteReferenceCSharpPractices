using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace downloadableVsAsync
{
    class Program
    {
    public static void DownlaodData(string url, string path) {
            using (WebClient client = new WebClient()) {
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64)");
                byte[] data = client.DownloadData(url);
                using (var file = File.OpenWrite(path)) {
                    file.Write(data, 0, data.Length);
                }
            }        
    }
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string url = "https://www.apress.com/in/apress-open/apressopen-titles";
            string path = "C:\\App\\download.txt";
            var directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
            DownlaodData(url, path);
            Console.ReadKey();
        }
    }
}
