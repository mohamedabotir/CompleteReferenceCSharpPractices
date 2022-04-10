using System;

namespace ch
{
    class Program
    {
        static void Main(string[] args)
        {
            byte f,m;
            byte z;
            #region expression
            try
            {
                checked { 
                f =127;
               m = 127;
               z = (byte)(f *m);
                Console.WriteLine(z);}

            }
            catch (OverflowException ex) {
                Console.WriteLine(ex);
            }
            ///////////////////////////////////////////////
            try
            {
                unchecked
                {
                    f = 127;
                    m = 127;
                    z = (byte)(f * m);
                    Console.WriteLine(z);
                }
               

            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex);
            }

            #endregion
        }
    }
}
