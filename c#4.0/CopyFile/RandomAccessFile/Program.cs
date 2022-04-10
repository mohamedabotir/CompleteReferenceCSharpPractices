using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomAccessFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = null;
            char ch;
            try
            {
                file = new FileStream("data.dat", FileMode.Create);
                for (int i = 0; i < 26; i++)
                    file.WriteByte((byte)('A' + i));
                file.Seek(0, SeekOrigin.Begin);
                //file.WriteByte((byte)('f'));
                ch = (char)file.ReadByte();
                Console.WriteLine(ch);

            }
            catch (IOException)
            {
                Console.WriteLine("Error");
            }
            finally {
                if (file != null)
                    file.Close();
            }
        }
    }
}
