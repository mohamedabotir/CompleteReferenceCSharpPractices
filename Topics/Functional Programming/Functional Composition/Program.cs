
namespace Functional_Composition
{
    public static class Program
    {
        public static List<int> datasource = new (){5,10,14,6,30 };
        static void Main(string[] args)
        {
            #region example 1 
            //datasource.Select(addOne).Select(Square).Select(SubtractTen)
            //     .ToList().ForEach(Console.WriteLine);
            #endregion

            #region example 2 compaction
            //datasource.Select(e=> SubtractTen(Square(addOne(e))))
            //     .ToList().ForEach(Console.WriteLine);
            #endregion
            #region exmaple 3 composition
            //datasource.Select(CompositeCustom(addOne, Square, SubtractTen))
            //     .ToList().ForEach(Console.WriteLine);
            #endregion
            #region exmaple 3 composition generic
            datasource.Select(AddOneSquareSubtractTen())
                 .ToList().ForEach(Console.WriteLine);
            #endregion
        }
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> F1, Func<T2, T3> F2)
            => (x) => F2(F1(x));
           
        
        public static int addOne(int number) => number + 1;
        public static int Square(int number) => number *number;
        public static int SubtractTen(int number) => number -10;
        public static Func<int,int> CompositeCustom(Func<int, int> F1, Func<int, int> F2, Func<int, int> F3)
        {
            return (x) =>
            {
                return F3(F2(F1(x)));
            };
        }
        public static Func<int, int> AddOneSquareSubtractTen() {
            Func<int, int> q1 = addOne;
            Func<int, int> q2 = Square;
            Func<int, int> q3 = SubtractTen;
        return q1.Compose(q2).Compose(q3);
        }
       


    }
}