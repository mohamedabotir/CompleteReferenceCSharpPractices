using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter18Generics.InterfaceConstraint
{ 
  public  interface IPerson
    {
        int age { get; set; }
        string name { get; set; }
        List<string> Material { get; set; }

    }

    public class Person :IPerson
    {
        public int age { get; set; }
        public string name { get; set ; }
        public List<string> Material { get ; set; }

        public virtual void print()
        {
            Console.WriteLine("Person Print");
        }
    }
    public class student : Person
    {
        bool paid = true;
        public student() {
            Material = new List<string>();
        }

        public student(List<student> data) {
            foreach (student item in data)
            {
                foreach (string self in item.Material)
                {

                    Console.WriteLine(self);
                }
            }

        }
        public override void print()
        {
            Console.WriteLine($"My name is:{name},my age:{age},i'am study:${Material.ToString()}, Paid:{paid}");
        }
}
        public class non{
    }

   public class InterfaceConstraint<T> where T :IPerson
    {
        public int id;
        public int serial;
        public void print() {
            Console.WriteLine($"id:{id},serial:{serial}");
        }
    }
    class fff<T>{
         
    }
}
