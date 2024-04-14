namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(StringProcessing.ToTitleCase(Console.ReadLine()));
                Console.WriteLine(StringProcessing.GetDigits(Console.ReadLine()));
                Console.WriteLine(StringProcessing.GetDigitsAsUint(Console.ReadLine()));
                Console.WriteLine(StringProcessing.GetDigitsAsDouble(Console.ReadLine()));
                Console.WriteLine(StringProcessing.Count(Console.ReadLine(), 'g'));
                Console.WriteLine(StringProcessing.Count(Console.ReadLine(), "NUM"));
            }
        }
    }
}