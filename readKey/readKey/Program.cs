using System;
using System.IO;

namespace readKey
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyinfo;
            Console.WriteLine("Enter Any Key ex:'Alt'+'Enter'");
            keyinfo = Console.ReadKey();
            Console.WriteLine("Normal Letter"+keyinfo.KeyChar);
            if((ConsoleModifiers.Alt & keyinfo.Modifiers)!=0)
                Console.WriteLine("Alt Is Pressed...");
            if ((ConsoleModifiers.Control & keyinfo.Modifiers) != 0)
                Console.WriteLine("Control Is Pressed...");
            if ((ConsoleModifiers.Shift & keyinfo.Modifiers) != 0)
                Console.WriteLine("Shift Is Pressed...");
            try
            {
                FileStream file = new FileStream(@"C:\Users\Threading\Desktop\file.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
            catch (IOException)
            {
                Console.WriteLine("Can't OpenFile");
            }
            catch (UnauthorizedAccessException) {
                Console.WriteLine("Ihave No Access");
            }
        }
    }
}
