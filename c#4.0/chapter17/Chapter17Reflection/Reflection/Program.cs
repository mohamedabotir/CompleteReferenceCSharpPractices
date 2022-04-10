using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
/*
 four key 
reflection techniques: obtaining information about methods, invoking methods, constructing 
objects, and loading types from assemblies.
     */
namespace Reflection
{
    class myClass
    {
        int a, b;
        public myClass(int a) {
            this.a = a = b;
        }
        public myClass(int a, int b)
        {
            this.a = a;
            this.a = b;
        }
        public int Sum()
        {
            return a + b;
        }
        public bool IsBetween(int i)
        {
            if (a < i && i < b) return true;
            else return false;
        }
        public void Set(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public void Set(double a, double b)
        {
            this.a = (int)a;
            this.b = (int)b;
        }
        public void Show()
        {
            Console.WriteLine(" a: {0}, b: {1}", a, b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region Obtaining Information About Methods
            /*
               Type t = typeof(myClass); // get a Type object representing MyClass
               Console.WriteLine("Name of Class {0}",t.Name);
               Console.WriteLine();
               Console.WriteLine("Methods supported: ");
               MethodInfo[] mi = t.GetMethods(BindingFlags.NonPublic| BindingFlags.Public| BindingFlags.Instance);
               ParameterInfo[] pi;
               foreach (var element in mi)
               {
                   // Display return type and name.
                   Console.Write(" " + element.ReturnType.Name +
                   " " + element.Name + "(");
                   pi = element.GetParameters();
                   for(int i = 0; i < pi.Length; i++)
                   {
                       Console.WriteLine(pi[i].ParameterType.Name + " "+pi[i].Name);

                       if (i + 1 < pi.Length)
                       {

                           Console.Write(", ");
                       }
                   }
                   Console.WriteLine(")");
                   Console.WriteLine();
               }
           }*/
            #endregion

            #region invoke method & constructor
            
            Type t = typeof(myClass);
            myClass reflectOb = new myClass(10, 20);
            Console.WriteLine("Invoking methods in:{0}" , t.Name);
            Console.WriteLine();
            MethodInfo[] mi = t.GetMethods();
            ParameterInfo[] pi;
            ConstructorInfo[] ci = t.GetConstructors();
            int val;
            foreach (MethodInfo m in mi)
            {
                
                pi = m.GetParameters();//get parameters of method
                //Console.WriteLine(pi[0].ParameterType);
                if (m.Name.Equals("Set", StringComparison.Ordinal) && pi[0].ParameterType == typeof(int))
                {
                    Console.WriteLine(m.ReturnType.Name + " " + m.Name + pi[0].ParameterType + ")");
                    object[] argus = new object[2];
                    argus[0] = 12;
                    argus[1] = 5;
                    m.Invoke(reflectOb, argus);
                   
                }
                else if (m.Name.Equals("Set",StringComparison.Ordinal) && pi[0].ParameterType == typeof(double)) {
                    Console.WriteLine(m.ReturnType.Name + " " + m.Name + pi[0].ParameterType + ")");
                    object[] argus = new object[2];
                    argus[0] = 12.8;
                    argus[1] = 100.6;
                    m.Invoke(reflectOb, argus);
                    
                }
                else if (m.Name.Equals("Sum", StringComparison.Ordinal))
                {
                    val = (int)m.Invoke(reflectOb, null);
                    Console.WriteLine("sum is " + val);
                }
                else if (m.Name.Equals("IsBetween", StringComparison.Ordinal))
                {
                    object[] argus = new object[1];
                    argus[0] = 14;
                    if ((bool)m.Invoke(reflectOb, argus))
                        Console.WriteLine("14 is between x and y");
                }
                else if (m.Name.Equals("Show", StringComparison.Ordinal))
                {
                    m.Invoke(reflectOb, null);
                }

            }
            #endregion

           

        }
    }
}
