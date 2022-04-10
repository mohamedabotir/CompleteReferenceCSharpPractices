using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter18Generics.reference
{
    class a {
    }
    class b :a{ }
    class reference<T> where T :class
    {
    }
    class value<T> where T :  struct{

    } 
}
