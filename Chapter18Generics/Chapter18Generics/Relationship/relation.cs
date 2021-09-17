using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter18Generics.Relationship
{
    class super { }
    class sub : super { }
    class single { }
    class relation<T,V>where T:V
    {
    }
}
