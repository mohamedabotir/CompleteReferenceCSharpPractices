using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {//string writer create string builder and hold data in it
            StringWriter stw = null;
            StringReader str = null;
            try { 
                stw=new StringWriter();
                for (int i = 0; i < 10; i++)
			{
                    stw.WriteLine("Line["+i+"]:"+i*2);
			 
			}
                str=new StringReader(stw.ToString());
                string reader=str.ReadLine();
                while(reader!=null){
                Console.WriteLine(reader);
                    reader=str.ReadLine();
                }

        }
    }
}
