using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    class customExciption : Exception {
       public static int id;
public customExciption() {
        
        }
        public customExciption(string Message):base(Message) { id++; }
        public override string ToString()
        {
            return Message + "ID:" + Convert.ToString(id);
        }


    }
}
