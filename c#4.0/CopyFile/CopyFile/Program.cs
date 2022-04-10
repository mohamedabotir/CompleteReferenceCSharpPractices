using System;
using System.IO;

namespace CopyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            FileStream fin=null;
            FileStream fout = null;
            args = new string[2];
            args[0] = "test.txt";
            args[1] = "temp.txt";
            if (args.Length != 2)
            {
                Console.WriteLine("Copy File");
                return;
            }
            try
            {
                fin = new FileStream(args[0],FileMode.Open);
                fout = new FileStream(args[1], FileMode.Create);
                do
                {
                    i = fin.ReadByte();
                    if (i != -1) fout.WriteByte((Byte)i);

                } while (i != -1);
                fout.Flush();
            }
            catch (IOException e)
            {
                Console.WriteLine("File Error:"+e);
            }
            finally {
                if (fin != null)fin.Close(); 
                
            }
            try
            {
                writer obj = new writer();
                obj.writeFile(fout);
            }
            catch (IOException e)
            {
                Console.WriteLine("Second:" + e);
            }
            finally {
                if (fout != null) fout.Close();
            }
        }
    }
}
