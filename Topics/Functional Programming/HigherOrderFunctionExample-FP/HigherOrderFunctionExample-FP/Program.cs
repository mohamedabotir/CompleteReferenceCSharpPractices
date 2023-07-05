namespace HigherOrderFunctionExample_FP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //orders type 
            Console.WriteLine(GetOrderDiscount(new Order { Name="Tomato1",Price=15000}, GetRules()));
        }
        public static double GetOrderDiscount(Order order, List<(Func<Order, bool> ProductsRules, Func<Order, double> GetDiscount)> Rules)
        {
            var result = Rules.Where(r=>r.ProductsRules(order))
                .Select(e=>e.GetDiscount(order)).Sum();
            order.Price -= result;
            return order.Price;
        }
        public static List<(Func<Order,bool> ProductsRules, Func<Order, double> GetDiscount)> GetRules()
        {
            List<(Func<Order, bool> ProductsRules, Func<Order, double> GetDiscount)> discounts = new List<(Func<Order, bool> ProductsRules, Func<Order, double> GetDiscount)>
            {
                 (IsProductOfTypeAQualified,ProcessOrderA),
                 (IsProductOfTypeBQualified,ProcessOrderB),
                 (IsProductOfTypeCQualified,ProcessOrderC)
            };
            return discounts;
        }//order >= 5000 LE Qualified A 5%
         //order >= 10000 LE Qualified B 4%
         //order >= 20000 LE Qualified C 3%
        public static bool IsProductOfTypeAQualified(Order order)
        {
            return order.Price>=5000;
        }
        public static bool IsProductOfTypeBQualified(Order order)
        {
            return order.Price>=10000;
        }
        public static bool IsProductOfTypeCQualified(Order order)
        {
            return order.Price>=2000;
        }
    
        public static double ProcessOrderA(Order order)
        {
             return order.Price * 0.05;
        }
        public static double ProcessOrderB(Order order)
        {
             return order.Price * 0.04;
        }
        public static double ProcessOrderC(Order order)
        {
             return order.Price * 0.04;
        }
    }
}