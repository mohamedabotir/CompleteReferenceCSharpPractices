using System;

namespace Structure
{
    struct PacketHeader
    {
    public    uint PackNum;
       public ushort PackLen;
    }
    class Transaction {
        static uint transacNum = 0;
        PacketHeader ph; 
        string accountNum;
        double amount;
        public Transaction(string acc, double val)
        {
            ph.PackNum = ++transacNum;
            ph.PackLen = 512; 
            accountNum = acc;
            amount = val;
        }
        public void sendTransaction()
        {
            Console.WriteLine("Packet #: " + ph.PackNum +
            ", Length: " + ph.PackLen +
            ",\n Account #: " + accountNum +
            ", Amount: {0:C}\n", amount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Transaction t = new Transaction("31243", -100.12);
            Transaction t2 = new Transaction("AB4655", 345.25);
            Transaction t3 = new Transaction("8475-09", 9800.00);
            t.sendTransaction();
            t2.sendTransaction();
            t3.sendTransaction();
        }
    }
}
