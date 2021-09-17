using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memorystream
{
    class Program
    {
        static void Main(string[] args)
        {
            byte []data=new byte[255];
            MemoryStream storage = new MemoryStream(data);
            StreamReader ster = new StreamReader(storage);
            StreamWriter stw = new StreamWriter(storage);
            try
            {
                for (int i = 0; i < 10; i++)
                    stw.WriteLine("byte [" + i + "]: " + i);
                stw.WriteLine(".");
                stw.Flush();
                Console.WriteLine("Reading data From storage");
                foreach (char item in data)
                {
                    if (item == '.') break;
                    Console.WriteLine(item);

                }
                Console.WriteLine("....Read Using StreamReader....");
                // Read from memstrm using the stream reader.
                storage.Seek(0, SeekOrigin.Begin); // reset file pointer
                string str = ster.ReadLine();
                while (str != null)
                {
                    str = ster.ReadLine();
                    if (str[0] == '.') break;
                    Console.WriteLine(str);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Interrupted Type" + e);
            }
            finally {
                stw.Close();
                ster.Close();
            }
        }
    }
}
