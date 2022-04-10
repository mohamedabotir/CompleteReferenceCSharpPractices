using System;

namespace enumeration
{
    enum days{
        Saturday,sunday,monday,tuseday,wednesday,thursday,friday
    }
    
    class Program
    {  public int score ;
   public int health;
   
       public void data(ref int score, out int  health){
       score +=5;
       this.score = score;
       health = 75;
       this.health = health;
        }
        static void Main(string[] args)
        {   
            #region enumeration 
            /*days a;
             String []Day={"One","Two","Three","Four","Five","Sex","Seven"};
            Console.WriteLine("Hello World!");
            for( a = days.Saturday;a<=days.friday;a++)
            Console.WriteLine("Day Number: "+Day[(int)a]+" DayName: "+a);*/
#endregion
        #region ref and out
        Program program = new Program() ;
        int score=120;
        int d;
        program.data(ref score,out d);
Console.WriteLine(score+"\nOut"+d);

        #endregion
        }
    }
}
