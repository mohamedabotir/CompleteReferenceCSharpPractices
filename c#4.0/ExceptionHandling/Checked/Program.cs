using System;

namespace Checked
{
    class Program
    {
        static void Main(string[] args)
        {
            #region expression
            checked
            {
                int f = 40;
                int m = 50;
                byte z = (byte)(f * m);
            }
            #endregion
        }
    }
}
