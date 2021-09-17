using System;
using System.Runtime.CompilerServices;

namespace indexer
{
    class fail
    {
        int[] data;
        public int Length; // Length is public
        public bool ErrFlag; // indicates outcome of last operation
        public fail(int i)
        {
            data = new int[i];
            Length = i;
        }
        public int this[int index]
        {
            set
            {
                if (ok(index))
                {
                    data[index] = value;
                    ErrFlag = false;
                }
                else
                    ErrFlag = true;
            }
            get
            {
                if (ok(index))
                {
                    ErrFlag = false;
                    return data[index];
                }
                else
                {
                    ErrFlag = true;
                    return -1;

                }
            }
        }
        bool ok(int i)
        {
            if (i >= 0 && i < Length)
                return true;
            else
                return false;
        }



    }
    class withoutUnderlying
    { 
        int base1 = 2;
    public int this[int index] { get {  return pow(index,base1); } }
        int pow(int e,int base1) {
            base1 = 2;
            if (e == 0)
                return 1;
            return base1*pow(e-1,base1);
        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region indexer 
            //fail obj = new fail(5);
            //int x;
            //for (int i = 0; i < obj.Length * 2; i++)
            //{
            //    obj[i] = i * 10;
            //}
            //for (int i = 0; i < (obj.Length * 2); i++)
            //{
            //    x = obj[i];
            //    if (x != -1) Console.Write(x + " ");

            //}
            //Console.WriteLine("\nFail with error reports.");
            //for (int i = 0; i < (obj.Length * 2); i++)
            //{
            //    obj[i] = i * 10;
            //    if (obj.ErrFlag)
            //        Console.WriteLine("fs[" + i + "] out-of-bounds");
            //}
            //for (int i = 0; i < (obj.Length * 2); i++)
            //{
            //    x = obj[i];
            //    if (!obj.ErrFlag) Console.Write(x + " ");
            //    else
            //        Console.WriteLine("fs[" + i + "] out-of-bounds");


            //}

            #endregion
            #region without underlying
            withoutUnderlying obj3 = new withoutUnderlying();
            Console.WriteLine(obj3[16]);
            #endregion
            //Two Dimenthonal the same  public int[int index1,int index2]{set;get;}
        }
    }
    }
