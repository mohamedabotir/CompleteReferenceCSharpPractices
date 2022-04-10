using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter18Generics.newConstructor
{
    public interface IPerson
    {
        int age { get; set; }
        string name { get; set; }
        List<string> Material { get; set; }

    }

    public class Person : IPerson
    {
        public int age { get; set; }
        public string name { get; set; }
        public List<string> Material { get; set; }

        public virtual void print()
        {
            Console.WriteLine("Person Print");
        }
    }
    public class student : Person
    {
        List<string> mat = new List<string>();
        List<student> std = new List<student>();
        bool paid = true;
        public student() {
        }

        public student( student[] data) {
            foreach (var item in data)
            {
                std.Add(item);
            }

            foreach (student item in std)
            {
                foreach (string i in item.Material)
                {

                mat.Add(i);
                }
            }
        }
        public override void print()
        {
            Console.WriteLine($"My name is:{name},my age:{age},i'am study:${mat.SelectMany(e=>e)}, Paid:{paid}");
        }

    }
    public class non{
      public void print() {
            Console.WriteLine("Their is non class");
    }
}
   public class InterfaceConstraint<T> where T :new()
    {
        public int id;
        public int serial;
        public void print() {
            Console.WriteLine($"id:{id},serial:{serial}");
        }
    }
    class dd<t> where t : struct, IPerson {

    } 
}
