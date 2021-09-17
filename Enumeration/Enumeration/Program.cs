using System;

namespace Enumeration
{
    class Program
    {
        //Underlying Type of an Enumeration
        public enum  Months:byte{January,February,March,April,May,June,July,August,October,November,December };
        static void Main(string[] args)
        {
            int []days = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for(Months i=Months.January;i<=Months.December;i++)
                Console.WriteLine($"Month:{(int)i+1}-{i},Has {days[(int)i]} Days");
        }
    }
}
