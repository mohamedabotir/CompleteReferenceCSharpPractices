namespace FactoryExample_FP
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f, Func<T2, T3> g) => x => g(f(x));
        public static Func<Type,Sheet> ManifacturePathFunc(Configure c ,ManifacturePath path)
        {

            var result = path.TypeFunctions.Where(x => x.type == c.productType).Select(e => e.parts).FirstOrDefault()
                .Compose(path.PartsFunctions.Where(x=>x.type == c.productPart).Select(e=>e.Products).FirstOrDefault())
                .Compose(path.sheetFunctions.Where(x => x.type == c.product).Select(e => e.Sheet).FirstOrDefault());
            return result;
        }
        public static Func<Order,Agg> ِAgreementPathFunc(Configure c ,ManifacturePath path)
        {

            var result = path.TypeFunctions.Where(x => x.type == c.productType).Select(e => e.parts).FirstOrDefault()
                .Compose(path.PartsFunctions.Where(x=>x.type == c.productPart).Select(e=>e.Products).FirstOrDefault())
                .Compose(path.sheetFunctions.Where(x => x.type == c.product).Select(e => e.Sheet).FirstOrDefault());
            return result;
        }
        public class ManifacturePath
        {
           public List<(Types type, Func<Type, Part> parts)> TypeFunctions = new();
           public List<(Parts type, Func<Part, Product> Products)> PartsFunctions = new();
           public List<(Products type, Func<Product, Sheet> Sheet)> sheetFunctions = new();
            public ManifacturePath()
            {
                TypeFunctions =new (){
                    (Types.engine,PartsEngine),
                    (Types.composer,PartsComposer),
                    (Types.wire,PartsWire)
                };

                PartsFunctions = new()
                {
                    (Parts.part1,Part1Processor),
                    (Parts.part2,Part2Processor),
                    (Parts.part3,Part3Processor),
                };
            }

          
        }
        public static Product Part3Processor(Part part)
        {
            Product product = new();
            product.GUID = "RRRR-TTTT-YYYY";
            product.Name = "Wire";
            product.Price = 400;
            return product;
        }
        public static Product Part2Processor(Part part)
        {
            Product product = new();
            product.GUID = "EEEE-WWWW-QQQQ";
            product.Name = "Composer";
            product.Price = 4000;
            return product;
        }
        public static Product Part1Processor(Part part)
        {
            Product product = new();
            product.GUID = "HHHH-SSSS-ZZZZ";
            product.Name = "Engine";
            product.Price = 3000;
            return product;
        }
        public static Part PartsWire(Type type)
        {
            Part part = new();
            part.GUID = "GGGG-BBBB-NNNN";
            part.Name = "Plastic";
            part.Price = 200;
            return part;
        }
        public static Part PartsComposer(Type type)
        {
            Part part = new();
            part.GUID = "FFFFF-DDDDD-LLLL";
            part.Name = "Dynamo";
            part.Price = 120;
            return part;
        }
        public static Part PartsEngine(Type type)
            {
                Part part = new();
                part.GUID = "AAAAAAA-BBBBB-CCCC";
                part.Name = "MetalLeg";
                part.Price = 100;
            return part;
                
            }

        public class Type
        {
            public string Name { get; set; }
            public string GUID { get; set; }
        }

        public class Part
        {
            public string Name { get; set; }
            public string GUID { get; set; }
            public decimal Price { get; set; }
        } 
        public class Product
        {
            public string Name { get; set; }
            public string GUID { get; set; }
            public decimal Price { get; set; }
        }
        public class Sheet
        {
            public string Name { get; set; }
            public string GUID { get; set; }
            public Product product { get; set; }
        }
        public class Configure
        {
           public Types productType { get; set; }
            public Parts productPart { get; set; }
            public Products product { get; set; }
            public Order orderType { get; set; }
            public CalculcationAgreement agreementType { get; set; }

        }

       

        public enum Types
        {
            engine,wire,composer
        }
        public enum Parts
        {
            part1,part2, part3
        }
        public enum Products
        {
            x3Engine,XProduct,Wire
        }
        public enum Order
        {
            one,two
        }
        public enum CalculcationAgreement
        {
            calc1, calc2 
        }


          public enum SheetType
        {
            sheet1,sheet2
        }
    }
}