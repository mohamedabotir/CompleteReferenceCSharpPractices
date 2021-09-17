using System;
using System.Runtime.CompilerServices;

namespace operatoroverloading
{
    class Program
    {
        Program(int uid=12,int usalary=2500) {
            this.uid = uid;
            this.usalary = usalary;
        }
        public int uid { set; get; }
        public int usalary { set; get; }
        public static Program operator +(Program o1, Program o2) {
            o1.uid += o2.uid;
            o1.usalary += o2.usalary;
            return o1;
        }
        public override string ToString()
        {
            return $"UserIDs:{uid},User Salarys:{usalary}";
        }
        public static Program operator +(Program o1, int add)
        {
            Program s = new Program();
            s.uid = o1.uid + add;
            s.usalary = o1.usalary + add;
            return s;
        }
        public static Program operator +(int add, Program o1)
        {
            Program s = new Program();
            s.uid = o1.uid + add;
            s.usalary = o1.usalary + add;
            return s;
        }
        public static bool operator >(Program o1, Program o2)
        {
            if (((o1.usalary + o1.usalary) > (o2.usalary + o2.usalary)))
                return true;
            else
                return false;
        }
        public static bool operator <(Program o1, Program o2)
        {
            if (((o1.usalary + o1.usalary) < (o2.usalary + o2.usalary)))
                return true;
            else
                return false;
        }

        public static bool operator !=(Program o1, Program o2)
        {
            if (((o1.usalary + o1.usalary) != (o2.usalary + o2.usalary)))
                return true;
            else
                return false;
        }

        public static bool operator ==(Program o1, Program o2)
        {
            if (((o1.usalary + o1.usalary) == (o2.usalary + o2.usalary)))
                return true;
            else
                return false;
        }
        public void add(int number1=15 ,int number2=16) {
            this.uid = number1;
            this.usalary = number2;
        }
        public static bool operator true(Program obj) {
            if (obj.uid > 0 || obj.usalary > 0)
                return true;
            else
                return false;
        }
        public static bool operator false(Program obj)
        {
            if ((obj.uid > 0 )&& (obj.usalary > 0))
                return false;
            else
                return true;
        }
        public static Program operator --(Program obj)
        {

            obj.uid--;
            obj.usalary--;
            return obj;
        }
        #region simple logical operators
        //public static bool operator &(Program obj,Program obj1)
        //{

        //    if (obj.usalary == 0 & obj1.usalary == 0)
        //        return true;
        //    else
        //        return false;
        //}
        //public static bool operator |(Program obj, Program obj1)
        //{

        //    if (obj.usalary == 0 | obj1.usalary == 0)
        //        return true;
        //    else
        //        return false;
        //}
        #endregion
        public static Program operator |(Program obj, Program obj1)
        {

            if (obj.usalary == 0 || obj1.usalary == 0)
                return new Program(0, 0);
            else
                return new Program(1, 1);
        }
        public static Program operator &(Program obj, Program obj1)
        {

            if ((obj.usalary != 0) & (obj1.usalary != 0))
        
                return new Program(0, 0);
           
            else
            
                return new Program(1, 1);
          
        }



        static void Main(string[] args)
        {


            #region binary operator over loading
            opeOverloading data = new opeOverloading();
            data.number1 = 50;
            data.number2 = 120;
            opeOverloading data2 = new opeOverloading() { number1 = 150, number2 = 120 };//object initializer
            Console.WriteLine(data);
            data2 = data + data2;
            Console.WriteLine("After Using Binary operator overloadind(+/-)");
            Console.WriteLine(data2);
            #endregion
            #region unary operator overloading
            Program meta = new Program() { uid = 1, usalary = 2000 };
            Program meta1 = new Program() { uid = 1, usalary = 230 };
            meta += meta1;
            Console.WriteLine(meta);
            #endregion
            #region param and insertion sort
            foreach (int item in opeOverloading.sumofValueType(12, 1, 15, 3, 2, 8))
                Console.Write(item + ",");
            #endregion

            #region unary overloaing
            Program f = new Program() { uid = 1, usalary = 50 };
            Console.WriteLine();
            Console.WriteLine("After add f+10");
            f = f + 10;
            Console.WriteLine(f);
            Program f1 = new Program() { uid = 1, usalary = 50 };
            Console.WriteLine();
            Console.WriteLine("After add f+10");
            f1 = 500 + f1;
            Console.WriteLine(f1);
            #endregion
            #region relational overloading
            if (f1 > f)
                Console.WriteLine($"F1:{f1},Greater Than F2:{f}");
            else
                Console.WriteLine($"F1:{f},Smaller Than F2:{f1}");
            f.add(number2: 550, number1: 501);//make f object the same of object f1
            if (f1 == f)
                Console.WriteLine("F1 Equal  F2");

            else if (f1 != f)
                Console.WriteLine("F1 not Equal F2");

            #endregion
            #region true overloading// uid 501  usalary 550
            f.add(number1: 5, number2: 0);
            while (f)
            {
                Console.WriteLine($"True overloading:{f.uid}");
                f--;
            }
            f.add(-1, -1);
            if (f) Console.WriteLine("true");
            else
                Console.WriteLine("False");

            #endregion
            #region logical operator simpe
            //if (f & f1)
            //    Console.WriteLine("F &f1 Equals Zero");
            //else
            //    Console.WriteLine("F & f1 Not Equal Zero");
            //f.add(number2: 0);
            //if (f | f1)
            //    Console.WriteLine("F | f1 equal zero");
            //else
            //    Console.WriteLine("F | f2 both not equal zero");

            #endregion
           
           
            
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
