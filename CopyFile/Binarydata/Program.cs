using System;
using System.IO;
using System.Linq;

namespace Binarydata
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryWriter bw=null;
            BinaryReader br=null;
            int i = 545;
            bool b = true;
            double d = 4545.6;
            string s = "MohamedAbotir";
            try
            {
                bw = new BinaryWriter(new FileStream("Data", FileMode.Create));
                bw.Write(i);
                bw.Write(b);
                bw.Write(d);
                bw.Write(s);
            }
            catch (IOException e)
            { Console.WriteLine("FileError:" + e); }
            finally {
                bw.Close();
            }
            try
            {
                br = new BinaryReader(new FileStream("Data", FileMode.Open));
                i = br.ReadInt32();
                Console.WriteLine("I:"+i);
                b = br.ReadBoolean();
                Console.WriteLine("B:"+b);
                d = br.ReadDouble();
                Console.WriteLine("D:"+d);
                s=br.ReadString();
                Console.WriteLine("S:"+s);
            }
            catch (IOException e)
            { Console.WriteLine("FileError:" + e); }
            finally
            {
                br.Close();
            }
        }
    }
}
