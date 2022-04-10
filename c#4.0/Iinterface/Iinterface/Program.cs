using System;

namespace Iinterface
{
    class Program
    {
        interface Idata {
            int getValue();
            void SetValues( params int []data);
            void Display();
            void Calculat();

        }
        interface ICalculation {
            void Calculat();

        }

        class employee : Idata, ICalculation
        {
            int id;
            int password;
            int deptId;
            public void Display()
            {
                Console.WriteLine($"EmployeeData(Note:This Info Is Serious Must Be Secure!):ID:{id},Password:{password},DepartmentID:{deptId}");
            }

            public int getValue()
            {
                throw new NotImplementedException();
            }

            public void SetValues(params int[] data)
            {
                this.id = data[0];
                this.password = data[1];
                this.deptId = data[2];
            }
            //Explicit Methods
            void ICalculation.Calculat()
            {
                Console.WriteLine($"Salary{1500}$");            }

            void Idata.Calculat()
            {
                Console.WriteLine($"AvgSalary:{deptId*10+1500}$");
            }
            //Using interface referance
          public  void ICcalculate() {
                ICalculation ob;
                ob = this;
                ob.Calculat();
            }
         public   void IDcalculate()
            {
                Idata ob;
                ob = this;
                ob.Calculat();
            }

        }
        static void Main(string[] args)
        {
            employee Edata = new employee();
            Idata referance;
            referance = Edata;
            referance.SetValues(1,201545154,12);
            Edata.Display();
            Property IWithProp = new Property();
            IWithProp.value = "Hello Our Employee Their is Good News All Employee in DepartmentID:12 Will Raise In Salary by 2.5%";
            Console.WriteLine(IWithProp.display);
            Edata.ICcalculate();
            Edata.IDcalculate();
        }
    }
}
