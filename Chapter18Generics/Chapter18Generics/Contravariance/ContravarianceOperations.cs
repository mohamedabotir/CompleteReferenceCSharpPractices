namespace Chapter18Generics.Contravariance
{
    interface ContravarianceOperations<in T>
    {
        void show(T obj);
    }
}
