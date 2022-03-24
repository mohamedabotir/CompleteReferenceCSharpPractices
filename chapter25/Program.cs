// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Concurrent;
using chapter25;

Console.WriteLine("Hello, World!");

ArrayList data = new ArrayList(10);
data.Add(150);
data.Add(15);
data.Add(400);
Console.WriteLine(data.Count);
Console.WriteLine(data.IndexOf(15));
data.Sort();
foreach (var item in data)
{
    Console.WriteLine(item);
}
Console.WriteLine(data.BinarySearch(15)+" ,Value:"+data[0]);
Hashtable map = new Hashtable(3,0.5f);
    map.Add("ahmed",15);
    map.Add("ahmed1",12);
    Console.WriteLine(map.Count);
SortedList list = new SortedList(10);
list.Add("mohamed",80);
Console.WriteLine(list.ContainsKey("mohamed")+" "+list.ContainsValue(80));
Stack stack = new Stack();
stack.Push(500);
stack.Push(50);
Console.WriteLine(stack.Peek());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Count);
Queue queue = new Queue();
queue.Enqueue(500);
Console.WriteLine(queue.Count);
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Count);


BitArray bit = new BitArray(8,false);
Console.WriteLine(bit.Length);
Console.WriteLine(bit.Count);
bit[0]=true;
foreach(var item in bit){
    Console.Write(item+" ");
}
bit.Not();
Console.WriteLine();
foreach(var item in bit){
    Console.Write(item+" ");
}
Console.WriteLine();
byte[]d = {60};
BitArray b = new BitArray(d);
Console.WriteLine(b.Length);
foreach (var item in b)
{
    Console.Write(item+" ");
}
LinkedList<string> link = new LinkedList<string>();
link.AddFirst("mohamed");
link.AddFirst("ali");
Console.WriteLine();
Console.WriteLine(link.Contains("mohamed"));
Console.WriteLine();
LinkedListNode<string>? node ;
for (node=link?.Last;node!=null; node=node.Previous)
{
    Console.Write(node.Value+" ");
}


Dictionary<string, double> dict =
 new Dictionary<string, double>();
 // Add elements to the collection.
 dict.Add("Butler, John", 73000);
 dict.Add("Swartz, Sarah", 59000);
 dict.Add("Pyke, Thomas", 45000);
 dict.Add("Frank, Ed", 99000);
 // Get a collection of the keys (names).
 ICollection<string> c = dict.Keys;
 // Use the keys to obtain the values (salaries).
 foreach(string str in c)
 Console.WriteLine("{0}, Salary: {1:C}", str, dict[str]);
SortedSet<int> set = new SortedSet<int>();
SortedSet<int> set1 = new SortedSet<int>();
set.Add(500);
set.Add(400);
set.Add(600);
set1.Add(500);
set1.Add(400);
set1.Add(800);
var s = set.Intersect(set1);
foreach (var item in s)
{
    Console.WriteLine(item);
}



ArrayList ls = new ArrayList(1);
 for(int i=0; i < 10; i++)
 ls.Add(i);
 // Use enumerator to access list.
 IEnumerator etr = ls.GetEnumerator();
 while(etr.MoveNext())
 Console.Write(etr.Current + " ");
 Console.WriteLine();
 // Re–enumerate the list.
 etr.Reset();
 while(etr.MoveNext())
 Console.Write(etr.Current + " ");
 Console.WriteLine();




Iterator iterate = new Iterator();
foreach (var item in iterate.GetEnumerator())
{
    Console.WriteLine(item);
}
//concurrent 
Resouces.b1 = new BlockingCollection<int>(4);
Task cons = new Task(Consumer);
Task prod = new Task(Producer);
try{
    Task.WaitAll(cons,prod);
}catch(AggregateException ex){
    Console.WriteLine(ex.Message);
}finally{
    cons.Dispose();
    prod.Dispose();
    Resouces.b1.Dispose();
}




static void Consumer (){
for (var i = 1; i < 25; i++)
{
    Resouces.b1.Add(i);
    Console.WriteLine("Consume... "+i);
}
}
static void Producer(){
for (var i = 1; i < 25; i++)
{
    Console.WriteLine("Produce... "+Resouces.b1.Take());
}
}


