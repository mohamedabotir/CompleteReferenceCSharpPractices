using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter18Generics.commpareInstance
{
    class CompareT
    {
        int a;
        public void com<T>(T element, T[] Data)where T:IEquatable<T> {
            foreach (T item in Data)
            {
                if (item.Equals(element)) {
                    Console.WriteLine("Item is : {0}",item);
                    return;
                }
            }
        }
    }
}
