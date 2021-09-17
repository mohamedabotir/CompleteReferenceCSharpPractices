using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter18Generics.BaseClass
{ 

   public class Person
    {
       public int age;
       public string name;
       public List<string> Matrerial;
        public virtual void print()
        {
            Console.WriteLine("Person Print");
        }
    }
   public class student : Person
    {
        bool paid = true;
        public student() {
            Matrerial = new List<string>();
        }

        public student(List<student> data) {
            foreach (student item in data)
            {
                foreach (string self in item.Matrerial)
                {

                    Console.WriteLine(self);
                }
            }
            
        }
        public override void print()
        {
            Console.WriteLine($"My name is:{name},my age:{age},i'am study:${Matrerial.ToString()}, Paid:{paid}");
        }
    }

   public class baseClass<T> where T :Person
    {
        public int id;
        public int serial;
        public void print() {
            Console.WriteLine($"id:{id},serial:{serial}");
        }
    }
}
