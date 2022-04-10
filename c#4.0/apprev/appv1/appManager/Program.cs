using fileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler fileManager = new Handler("fileReader.txt");
            fileManager.countLetters();
            Console.WriteLine(fileManager.getLetterValue());
            
        }
    }
}
