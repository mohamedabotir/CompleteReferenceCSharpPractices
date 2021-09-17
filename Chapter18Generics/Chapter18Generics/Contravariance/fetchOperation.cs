using System;

namespace Chapter18Generics.Contravariance
{
    class fetchOperation<T> : ContravarianceOperations<T>
    {
        public void show(T obj)
        {
            Console.WriteLine(obj);
        }
    }
}
