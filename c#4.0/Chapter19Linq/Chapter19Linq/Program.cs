using System;
using System.Collections;

namespace Chapter19Linq
{
    static class extensionMethods
    {
        public static double cell(this double val)
        {

            return (double)Math.Ceiling(val);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //int[] data = { -1, 5, 2, 6, 8, -200, 10, 11, 12, 13, 14, 15 };
            //IEnumerable<int> filter = from e in data

            //                          where e >= 5 || e == -200
            //                          where e <= 13
            //                          select e;
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            //string[] domains = { ".com", ".net", "a.net", "b.net", "c.com", "d.com", "e.com" };
            //var domainFilter = from e in domains
            //                   where e.Length > 4 && e.EndsWith(".net", StringComparison.OrdinalIgnoreCase)
            //                   orderby e descending
            //                   select e;
            //foreach (var item in domainFilter)
            //{
            //    Console.WriteLine(item);
            //}
            //double[] nums = { 12.0, 12.5, 11, 85, 75.9 };
            //var filter = from item in nums

            //             orderby item
            //             select Math.Sqrt(item);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine("{0:#.##}", item);
            //}
            //Account[] accounts = { new Account("mohamed", "mohamed@ci.com"),
            //    new Account("amr","amr@gmail.com"),
            //    new Account("ahmed","ahmed@menu.org")
            //};
            //var filter = from item in accounts
            //             orderby item.name descending
            //             select item.emailAddress;
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(" {0} ", item);
            //}
            //char[] ch1 = { 'a', 'b', 'c' };
            //char[] ch2 = { 'v', 'r', 'p' };
            //var filter = from i in ch1
            //             from ii in ch2
            //             select new pair(i, ii);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item.xchar + "  " + item.ychar);
            //}
            //           string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
            //"hsNameD.com", "hsNameE.org", "hsNameF.org",
            //"hsNameG.tv", "hsNameH.net", "hsNameI.tv","domain@123" };
            //           var filter = from item in websites
            //                        where item.LastIndexOf('.') != -1
            //                        group item by item.Substring(item.LastIndexOf('.'))
            //                        into ws //continuation
            //                        where ws.Count() > 2
            //                        select ws
            //                        ;
            //           foreach (IGrouping<string, string> data in filter)
            //           {
            //               Console.WriteLine("Web Sites Grouped by " + data.Key);
            //               foreach (string item in data)
            //               {
            //                   Console.WriteLine("  " + item);
            //               }
            //           }
            //string[] data = { "alpha", "beta", "global" };
            //var handle = from item in data
            //             let charData = item.ToCharArray()
            //             from ch in charData
            //             orderby ch
            //             select ch;
            //foreach (var item in handle)
            //{
            //    Console.Write("  " + item);
            //}
            //item[] items = { new item("rx570 xfx", 1510), new item("gtx1050ti",2690),
            //    new item("gigabyte h410",1085),new item("seria cable",8542)
            //};
            //InSocke[] stock = { new InSocke(1510,true),new InSocke(2690,false)
            //        ,new InSocke(1085,true),new InSocke(8542,false)
            //};
            //var selection = from i in items
            //                join entry in stock
            //                on i.ItemSerialNum equals entry.ItemSerialNum
            //                select new { name = i.ItemName, status = entry.isAvailable };
            //foreach (var item in selection)
            //{
            //    Console.WriteLine("{0}\t{1}", item.name, item.status);
            //}

            ///// group with join
            //    string[] travelType = { "Air", "Land", "Sea" };
            //    Transport[] trans = {
            //                  new Transport("Bicycle", "Land"),
            //    new Transport("Balloon", "Air"),
            //    new Transport("Boat", "Sea"),
            //    new Transport("Jet", "Air"),
            //    new Transport("Canoe", "Sea"),
            //    new Transport("Biplane", "Air"),
            //    new Transport("Car", "Land"),
            //    new Transport("Cargo Ship", "Sea"),
            //    new Transport("Train", "Land")
            //               };
            //    var how = from h in travelType
            //              join t in trans
            //              on h equals t.How
            //              into ls
            //              select new { name = h, trans_list = ls };
            //    var how1 = travelType.Join(trans,
            //        t1 => t1,
            //        t2 => t2.How,
            //        (t1, t2) => new { t1, t2 }
            //);
            //    foreach (var item in how1)
            //    {
            //        Console.WriteLine("Category  :" + item.t1);
            //        foreach (var h in item.t2)
            //        {
            //            Console.WriteLine("By :" + h);
            //        }
            //    }

            //    double dd = 15.6;
            //    Console.WriteLine(dd.cell());
            //    Console.ReadKey();
            int result = default;

            Math.DivRem(10, 3, out result);
            Console.WriteLine(result);
            Console.WriteLine(Math.IEEERemainder(10, 3));
            Console.WriteLine(Math.Round(1.5));
            Console.WriteLine(Math.Truncate(5.8));//exclude integer value from decimal number
            Console.WriteLine(Math.Truncate(5.2d));
            Console.WriteLine(Int64.MaxValue);
            Console.WriteLine(Double.PositiveInfinity);

        }

        class Transport : IEnumerable
        {
            public string Name { get; set; }
            public string How { get; set; }
            public Transport(string name, string how)
            {
                Name = name;
                How = how;
            }

            public IEnumerator GetEnumerator()
            {
                yield return Name + " " + How;
            }
        }
        public class temp
        {
            public string ItemName { get; set; }
            public bool isAvailable { set; get; }
            public temp(string item, bool status)
            {
                ItemName = item;
                isAvailable = status;
            }
        }
        public class InSocke
        {
            public int ItemSerialNum { get; set; }
            public bool isAvailable { set; get; }
            public InSocke(int serial, bool status)
            {
                ItemSerialNum = serial;
                isAvailable = status;
            }
        }
        public class item
        {
            public string ItemName { set; get; }

            public int ItemSerialNum { get; set; }
            public item(string name, int serial)
            {
                ItemName = name;
                ItemSerialNum = serial;
            }
        }
        class pair
        {
            public char xchar { get; set; }
            public char ychar { get; set; }
            public pair(char xchar, char ychar)
            {
                this.xchar = xchar;
                this.ychar = ychar;
            }
        }
        class Account
        {
            public string name { get; set; }
            public string emailAddress { get; set; }
            public Account(string name, string emailAddress)
            {
                this.name = name;
                this.emailAddress = emailAddress;
            }
        }
    }

}
