namespace SmartEnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gender = Genders.FromValue("M");
            if (gender == Genders.Male)
                Console.WriteLine(gender);
            else Console.WriteLine("NotFound");
        }
    }
}