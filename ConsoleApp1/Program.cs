namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ReadLine().GetDigit(out double i);
                Console.WriteLine(i);
            }
        }
    }
}