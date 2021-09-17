namespace Chapter18Generics.Covariance
{
    interface operations<out T> : test<T>
    {
        T setValue();

    }
}
