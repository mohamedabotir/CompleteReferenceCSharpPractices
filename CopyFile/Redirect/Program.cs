﻿using System;
using System.IO;

namespace Redirect
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter log_out = null;
            try
            {
                log_out = new StreamWriter("test.txt");
                // Redirect standard out to logfile.txt.
                Console.SetOut(log_out);
                Console.WriteLine("This is the start of the log file.");
                for (int i = 0; i < 10; i++) Console.WriteLine(i);
                Console.WriteLine("This is the end of the log file.");
            }
            catch (IOException exc)
            {
                Console.WriteLine("I/O Error\n" + exc.Message);
            }
            finally
            {
                if (log_out != null) log_out.Close();
            }
        }
    }
}
