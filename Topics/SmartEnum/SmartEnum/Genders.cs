using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnum
{
    internal class Genders : SmartEnum<Genders, string>
    {
        public static readonly Genders Male = new Genders("M", "Male");
        public static readonly Genders Female = new Genders("F", "Female");
        public static readonly Genders Unknown = new Genders("U", "Unknown");

        public Genders(string value, string name) : base(value, name)
        {
        }
    }
}
