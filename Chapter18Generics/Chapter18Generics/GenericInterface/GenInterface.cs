using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter18Generics.GenericInterface
{
    interface operation<T> {
        T getNext(T val);
        void Reset();
        void setStart();
    }
    class GenInterface<T> : operation<T>
    {
        T start;
        T val;
       public delegate T incrTwo(T value);
        incrTwo inc;
        public GenInterface(incrTwo incrTwo) {
            start = default(T);
            val = default(T);
            inc = incrTwo;
        }
        public T getNext(T v)
        {
            val = inc(v);
            return val;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void setStart()
        {
            throw new NotImplementedException();
        }
    }
}
