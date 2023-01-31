
#region standard Event
using events;

var sender = new Sender();
var receiver = new Receiver();
var receiver2 = new Receiver();
sender.handler += receiver.GetNotificationFromSender;
sender.MyIntChange = 1;
sender.handler += receiver2.GetNotificationFromSender;
sender.MyIntChange++;
sender.handler -= receiver2.GetNotificationFromSender;
sender.handler -= receiver.GetNotificationFromSender;
sender.handler += sender.GetNotificationMtSelf;
sender.MyIntChange--;

#endregion