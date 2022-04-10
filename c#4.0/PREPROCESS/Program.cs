#define exper
using System;
using ctr = Counter;//alianse
 class counter { // class in global namespace
        int val;
      public counter(int val=0){
           this.val=val;
       }
       public int getVal(){
           return val;
       }
    }
namespace Counter{
class counter {
       internal  int val;
      public counter(int val=0){
           this.val=val;
       }
       public int getVal(){
           return val*10;
       }
    }
}
namespace PREPROCESS
{
   
    class Program
    {
        static void Main(string[] args)
        {
           global::counter c = new global::counter(15);
           ctr::counter ct = new ctr::counter(15);
           ct.val= 20;//internal is define variable in file 
           Console.WriteLine(c.getVal());
           Console.WriteLine("------------------------");
           Console.WriteLine(ct.getVal());
           #if exper
            Console.WriteLine("Compiled for experimental version.");
            #endif
             Console.WriteLine("This is in all versions.");

  
        }
    }
}
