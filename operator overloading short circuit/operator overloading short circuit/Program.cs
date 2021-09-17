using System;

namespace operator_overloading_short_circuit
{
    class Program {
       public Program(int x,int y,int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public int z {set; get; }
    public int x { set; get; }
    public int y { set; get; }
        public static Program operator &(Program p1,Program p2) {
            if ((p1.z != 0 && p1.y != 0 && p1.x != 0) & (p2.z != 0 && p2.y != 0 && p2.x != 0))
                return new Program(1, 1, 1);
            else
                return new Program(0,0,0);

        }
        public static bool operator true(Program op)
        {
            if ((op.x != 0) || (op.y != 0) || (op.z != 0))
                return true; // at least one coordinate is non-zero
            else
                return false;
        }
        // Overload false.
        public static bool operator false(Program op)
        {
            if ((op.x == 0) && (op.y == 0) && (op.z == 0))
                return true; // all coordinates are zero
            else
                return false;
        }
        /*public static implicit operator int(Program o) {
            return o.x + o.y + o.z;
        }*/
        public static Program operator +(Program o1,Program o2) {
            Program sum=new Program(0,0,0);
            sum.x += o1.x + o2.x;
            sum.y += o1.y + o2.y;
            sum.z += o1.z + o2.z;

                return sum;
        }
            


        public static explicit operator int(Program o)
        {
            return o.x + o.y + o.z;
        }

        static void Main(string[] args)
        {
            Program f = new Program(1,2,3);
            Program f1 = new Program(2, 5, 6);
            // int sum = f;//implicit
            int sum = (int)f;

            if (f && f1)
                Console.WriteLine($" true  x:{f.x},y:{f.y},z:{f.z}");
            else
                Console.WriteLine("false");
            Console.WriteLine($"Implicit:{sum}");
            f1 += f;
            Console.WriteLine(f1.x+":"+f1.y+":"+f1.z);
        }
    }
}
