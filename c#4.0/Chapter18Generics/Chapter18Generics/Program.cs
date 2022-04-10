using Chapter18Generics.Contravariance;
using Chapter18Generics.Covariance;
using System;

namespace Chapter18Generics
{
    class Program
    {
        static int plusTwo(int value)
        {
            return value + 2;
        }
        class CompareClass : IEquatable<CompareClass>
        {
            int x;
            public CompareClass(int x)
            {
                this.x = x;

            }



            public bool Equals(CompareClass other)
            {
                return other.x == x;
            }
            //of class
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string ToString()
            {
                return base.ToString();
            }
        }
        static void Main(string[] args)
        {
            #region BaseClass
            /*List<student> data = new List<student>
            {
                new student{
                    age = 15,
                    name = "mohamed abotir",
                    Matrerial = new List<string>{ "computer organization","os"}
                }
            };
            student st = new student(data);
            st.print();
            baseClass<student> d = new baseClass<student>();*/
            #endregion
            #region InterfaceConstraint
            /*student[] data = {new student()
            {

                    age = 15,
                    name = "mohamed abotir",
                    Material = new List<string>{ "computer organization","os"}

            }};
            student st = new student(data);
            st.print();
            InterfaceConstraint<student> d = new InterfaceConstraint<student>();
            InterfaceConstraint<non> dd = new InterfaceConstraint<non>();
            d.print();*/
            #endregion
            #region reference and value
            /* reference<a> o = new reference<a>();
             value<int> oo = new value<int>();*/
            #endregion
            #region relationship
            /*relation<sub,super> rel = new relation<sub,super>();
            relation<sub, single> rel = new relation<sub, single>();*/
            #endregion


            #region GenericInterface With Delegate
            //GenInterface<int> exec = new GenInterface<int>(plusTwo);
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine(exec.getNext(i));
            //}
            #endregion
            #region IEquatable<>,IComparable<>
            //CompareT f = new CompareT();
            //int[] data = { 23, 5, 1, 8, 200, 10 };
            //f.com<int>(1, data);
            //f.com<CompareClass>(new CompareClass(15),new CompareClass[] { new CompareClass(15), new CompareClass(125), new CompareClass(152) });
            #endregion
            #region Covariance(out) , Contravariance(in) 
            operations<debug> perform = new performOperation<debug>();

            Console.WriteLine(perform.setValue());
            perform = new performOperation<fetch>();//super then child
            operations<fetch> perform1 = new performOperation<fetch>();
            perform = perform1;
            Console.WriteLine(perform.setValue());
            //contravariance
            ContravarianceOperations<alpha> contvar = new fetchOperation<alpha>();
            ContravarianceOperations<beta> contvar2 = new fetchOperation<beta>();
            ContravarianceOperations<beta> contvar3 = new fetchOperation<alpha>();//child then super
            contvar2 = contvar3;
            #endregion
        }
    }
}
