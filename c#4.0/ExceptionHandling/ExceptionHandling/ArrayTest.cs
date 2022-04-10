using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    class ArrayTest
    {
        int high, low;
        int []data;
       public int this[int index] {
            set {
                if (index >= low || index < 0)
                    throw new customExciption("Error Lower Index is Greater or Equal To Higher while Insert");
                else
                    data[index] = value;
            }
        }
        public ArrayTest(int high,int low) {
            if (high <= low)
            {
                throw new customExciption("Error Lower Index is Greater or Equal To Higher While Initilization");
            }
            else {
               
                this.high = high;
                this.low = low; 
                data = new int[this.high];
            }

        }
    }
}
