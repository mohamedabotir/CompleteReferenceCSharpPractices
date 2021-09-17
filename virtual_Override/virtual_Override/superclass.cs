using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virtual_Override
{
    class superclass 
    { public static int count=0;
   public superclass() {
        count++;
    }
        public virtual string Print()
        { 
            return "SuperClass Class";
        }
    }
}
