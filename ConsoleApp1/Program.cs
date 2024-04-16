namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "v 1 2h3 k .5v hihi";
            
            string digitAsString;// = 1235
            uint digitAsUint;// = 11
            double digitAsDouble;// = 6.5

            str.GetDigits(out digitAsString);
            str.GetDigits(out digitAsUint);
            str.GetDigits(out digitAsDouble);
            
            
            
            
            
            
            
            
            
            /*while (true)
            {
                Console.WriteLine(StringProcessing.ToTitleCase(Console.ReadLine()));
                Console.WriteLine(StringProcessing.Count(Console.ReadLine(), 'g'));
                Console.WriteLine(StringProcessing.Count(Console.ReadLine(), "NUM"));
            }*/
        }
    }
}