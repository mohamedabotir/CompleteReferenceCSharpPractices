using System;

namespace Chapter18Generics.Covariance
{
    partial class performOperation<T> : operations<T>
    {
        T obj;
        public T setValue()
        {
            Console.WriteLine("Inside perform" + obj);
            return obj;
        }

    }
}
