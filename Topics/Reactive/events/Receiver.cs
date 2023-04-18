using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace events
{
    public class Receiver
    {
        public void GetNotificationFromSender(object sender, EventArgs args)
        {
            Console.WriteLine($"Receiver receive a Notification from Sender: and Change Latest Value");
        }
    }
}