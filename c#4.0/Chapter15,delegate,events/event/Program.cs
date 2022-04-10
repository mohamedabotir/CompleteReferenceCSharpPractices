using System;
// Declare a delegate type for an event.
delegate void MyEventHandler();
class MyEvent
{
    public event MyEventHandler SomeEvent;
    public void OnSomeEvent()
    {
        if (SomeEvent != null)
            SomeEvent();
    }
}
class customEvent {
    MyEventHandler[] evt = new MyEventHandler[3];
    public event  MyEventHandler reciveEvent{
        add {
            int i=0;
            for (; i < 3; i++)
            {
                if(evt[i]==null){
                    evt[i]=value;
                    break;
                }
                if(i==3)
                Console.WriteLine("Event List is Full");
            }
        }
        remove{
int i;
 for(i=0; i < 3; i++){
 if(evt[i] == value) {
     evt[i]=null;
     break;
 }
 if(i==3)
 Console.WriteLine("Event is Empty");
 }


        }
    } 
    public void fetchEvent(){
        for (int i = 0; i < 3; i++)
        {
            if (evt[i]!=null)
            {
                evt[i]();
            }
        }
    }
}
public class date {
    public string dateTime { get; set; }
  public  date(string initial){
     dateTime = initial;
    }
    public void fetchDate(){
        Console.WriteLine(dateTime);
    }
    
    
}
class Degree {
    public int noDegree { get; set; }
  public  Degree(int initial){
     noDegree = initial;
    }
    public void fetchDegree(){
        Console.WriteLine(noDegree);
    }
    
    
}

class Program
{
    // An event handler.
    static void Handler()
    {
        Console.WriteLine("Event occurred");
    }
    static void Main(string[] args)
    {
        MyEvent evt = new MyEvent();
        date d = new date("2-15-2021 1:58");
        Degree dg = new Degree(15);
        // Add Handler() to the event list.
        evt.SomeEvent += Handler ;
        evt.SomeEvent += d.fetchDate;
        evt.SomeEvent +=dg.fetchDegree;

        // Raise the event.
        evt.OnSomeEvent();
        Console.WriteLine("customHandler-----");
        customEvent customHandler = new customEvent();
        customHandler.reciveEvent+=Handler;
        customHandler.reciveEvent+=dg.fetchDegree;
        customHandler.fetchEvent();

    }
}
