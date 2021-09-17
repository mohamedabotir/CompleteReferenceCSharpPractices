using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;

namespace CopyFile
{
    class writer
    {
        string str;
        public void writeFile(FileStream file) {
            StreamWriter write = new StreamWriter(file);
            try
            {
                Console.WriteLine("IF You Want To Stop Writing Write[Stop]");
              
                Console.Write(":");
                do
                {
                    str = Console.ReadLine();
                    str.Trim();
                    str.ToLower();
                    if (str != "stop")
                    {
                        str = str + "\r\n";
                        write.Write(str);
                    }
                } while (str != "stop");

            }
            catch (IOException e)
            {
                Console.WriteLine("File Error:" + e);
            }
            finally {
                write.Close();
            }
        
        }
    }
}
