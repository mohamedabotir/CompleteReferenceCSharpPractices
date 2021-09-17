using System;
//delegate string strMode(String str); first ,second 
//delegate void strMode(ref string str); multicast

class X
{
    public int Val;
}
class Y : X
{

}
delegate X ChangeIt(Y obj);

class Program
{
    #region  first , two case 
    /* // Replaces spaces with hyphens.
static string ReplaceSpaces(string s) {

Console.WriteLine("Replacing spaces with hyphens.");
return s.Replace(' ', '-');
}
// Remove spaces.
static string RemoveSpaces(string s) {
string temp = "";
int i;
Console.WriteLine("Removing spaces.");
for(i=0; i < s.Length; i++)
if(s[i] != ' ') temp += s[i];
return temp;
}
// Reverse a string.
static string Reverse(string s) {
string temp = "";
int i, j;
Console.WriteLine("Reversing string.");
for(j=0, i=s.Length-1; i >= 0; i--, j++)
temp += s[i];
return temp;
}*/
    #endregion
    #region multicast
    // Replaces spaces with hyphens.
    /*
       static void ReplaceSpaces(ref string s)
       {
           Console.WriteLine("Replacing spaces with hyphens.");
           s = s.Replace(' ', '-');
       }
       // Remove spaces.
       static void RemoveSpaces(ref string s)
       {
           string temp = "";
           int i;
           Console.WriteLine("Removing spaces.");
           for (i = 0; i < s.Length; i++)
               if (s[i] != ' ') temp += s[i];
           s = temp;
       }
       // Reverse a string.
       static void Reverse(ref string s)
       {
           string temp = "";
           int i, j;
           Console.WriteLine("Reversing string.");
           for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
               temp += s[i];
           s = temp;
       } 
       */
    #endregion
    #region convariance,contravariance
    // This method returns X and has an X parameter.
    static X IncrA(X obj)
    {
        X temp = new X();
        temp.Val = obj.Val + 1;
        return temp;
    }
    // This method returns Y and has a Y parameter.
    static Y IncrB(Y obj)
    {
        Y temp = new Y();
        temp.Val = obj.Val + 1;
        return temp;
    }
    #endregion
    static void Main(string[] args)
    {
        #region first delegate
        /*
        strMode str = new strMode(ReplaceSpaces);
        string st = str("mohamedSalah  is best player in the World ");
        Console.WriteLine(st);
        str = new strMode(RemoveSpaces);
        string remove = str("mohamedSalah  is best player in the World");
        Console.WriteLine(remove);
        str = new strMode(Reverse);
        string revarse = str("mohamedSalah  is best player in the World");
        Console.WriteLine(revarse);
        */
        #endregion
        #region  Method Group Conversion
        /*
        strMode str = ReplaceSpaces;
        string st = str("mohamedSalah  is best player in the World ");
        Console.WriteLine(st);
        str = RemoveSpaces;
        string remove = str("mohamedSalah  is best player in the World");
        Console.WriteLine(remove);
        str = Reverse;
        string revarse = str("mohamedSalah  is best player in the World");
        Console.WriteLine(revarse);
        */
        #endregion
        #region multicast

        // Construct delegates.
        /*
         strMode strOp;
         strMode replaceSp = ReplaceSpaces;
         strMode removeSp = RemoveSpaces;
         strMode reverseStr = Reverse;
         string str = "This is a test";
         // Set up multicast.
         strOp = replaceSp;
         strOp += reverseStr;
         // Call multicast.
         strOp(ref str);
         Console.WriteLine("Resulting string: " + str);
         Console.WriteLine();
         // Remove replace and add remove.
         strOp -= replaceSp;
         strOp += removeSp;
         str = "This is a test."; // reset string
                                  // Call multicast.
         strOp(ref str);
         Console.WriteLine("Resulting string: " + str);
         Console.WriteLine();
         */
        #endregion
        #region  convariance,contravariance
        Y Yob = new Y();
        // In this case, the parameter to IncrA
        // is X and the parameter to ChangeIt is Y.
        // Because of contravariance, the following
        // line is OK.
        ChangeIt change = IncrA;
        X Xob = change(Yob);
        Console.WriteLine("Xob: " + Xob.Val);
        // In the next case, the return type of
        // IncrB is Y and the return type of
        // ChangeIt is X. Because of covariance,
        // the following line is OK.
        change = IncrB;
        Yob = (Y)change(Yob);
        Console.WriteLine("Yob: " + Yob.Val);
        #endregion
    }
}
