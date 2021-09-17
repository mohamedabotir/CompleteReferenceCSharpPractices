using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{   
    [AttributeUsage(AttributeTargets.All)]
    class RemarkAttribute : Attribute {
        public string supplement;
        string pri_remark; // underlies Remark property
        public RemarkAttribute(string comment)
        {
            pri_remark = comment;
            supplement = "None";
        }
        public string Remark1
        {
            get
            {
                return pri_remark;
            }
        }
    }
    [AttributeUsage(AttributeTargets.All)]
    class NoteAttribute : Attribute
    {
        string pri_remark; // underlies Remark property
        public NoteAttribute(string comment)
        {
            pri_remark = comment;
        }
        public string Note
        {
            get
            {
                return pri_remark;
            }
        }
    }
    [Note("invoke Note Attribute")]
    [Remark("invoke Remark Attribute", supplement ="second")]
    class useAttrib
    {
     //implementation
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(useAttrib);
            Type ta = typeof(RemarkAttribute);
            Console.WriteLine("Attributes in (" + t.Name + ": ");
            object[] attribs = t.GetCustomAttributes(ta,true);
            foreach (object o in attribs)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine("Attribute:");
            Type tRemAtt = typeof(RemarkAttribute);
            Type tNoteAtt = typeof(NoteAttribute);
            RemarkAttribute ra = (RemarkAttribute)
            Attribute.GetCustomAttribute(t, tRemAtt);
            NoteAttribute na = (NoteAttribute)Attribute.GetCustomAttribute(t,tNoteAtt);
            Console.WriteLine("Remark:"+ra.supplement);
            Console.WriteLine("Note:" + na.Note);

        }
    }
}
