// See https://aka.ms/new-console-template for more information
 #region  math
Console.WriteLine(Math.BigMul(10,20));//avoid overflow
Console.WriteLine(Math.Ceiling(12.2));
Console.WriteLine(Math.Floor(12.2));
Console.WriteLine(Math.DivRem(10,3));//calculate divid result and reminder
Console.WriteLine(Math.IEEERemainder(10,3));
Console.WriteLine(Math.Exp(3));// e ^ n
Console.WriteLine(Math.Round(12.6));
Console.WriteLine(Math.Round(12.6886,3));
Console.WriteLine(Math.Round(11.5,MidpointRounding.ToEven));//will return 12 approximate to nearest event number 
Console.WriteLine(Math.Round(11.5,MidpointRounding.AwayFromZero));
Console.WriteLine(Math.Round(11.5,MidpointRounding.ToZero));
Console.WriteLine(Math.Sign(0));

#endregion
#region structure
Single f;
f = new float();
f = 23.6f;
Console.WriteLine(f);
Console.WriteLine(float.Epsilon);
decimal val = new decimal(115,2,2,false,0);
Console.WriteLine(val);
char ca = 'a';
Console.WriteLine(char.GetNumericValue('5'));
Console.WriteLine(char.IsLetter(ca));
int[]data = {1,15,2,4,10,22};
int[] data1 = (int[])data.Clone();
data1[0] = 4;
data[0]=0;
//decimal[]dedata = Array.ConvertAll<int,decimal>(data, dedata);
Console.WriteLine(data[0]+"  "+data1[0]);

#endregion