using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter25
{
    public  class Iterator
    {
        private char[] data = {'a', 'b', 'c', 'd'};

        public IEnumerable GetEnumerator()
        {
            foreach (var c in data)
            {
                if(c == 'c')
                    yield break;
                yield return c;
            }
        }
    }
}
