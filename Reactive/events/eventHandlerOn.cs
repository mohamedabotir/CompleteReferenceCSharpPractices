using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace events
{
    public class Sender
    {
        public event EventHandler handler;
        private int myInt;
        public int MyIntChange
        {
            get
            {
                return myInt;
            }
            set
            {
                myInt = value;
                onInitChange();
            }
        }
        public void onInitChange()
        {
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public void GetNotificationMtSelf(object sender, EventArgs args)
        {
            Console.WriteLine($"I Send Notification To My Self:I Have Changed My Value To:{MyIntChange}");
        }
    }
}