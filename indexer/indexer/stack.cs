using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace indexer
{
    class stack
    {
        int []data;
        bool errdetect;
        int top;
        int length;
       public stack(int size) {
            data = new int[size];
            top = 0;
            length = size;

        }
        public int this[int index]
        {
            set
            {
                if (errorDetector(index))
                {
                    
                    data[index] = value;
                    errdetect = false;
                }
                else errdetect = true;
            }
            get
            {
                if (errorDetector(index))
                {
                    errdetect = false;
                    return data[index];
                }
                else
                {errdetect = true;  return -1;  }

            }
        }
    public  void push(int element) {
            if(errdetect)
                Console.WriteLine($"Error {top} out of bound");
            else
            this[top] = element;
            top++;
        }
        public void pop() {
            if (errdetect)
                Console.WriteLine($"Error {top} out of bound");
            else
                top--;
        }
        bool errorDetector(int i) {
            if (i >= 0 && i < length)
                return false;
            else
                return true;
        }
    }
}
