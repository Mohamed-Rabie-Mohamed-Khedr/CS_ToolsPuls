namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        { 
            string str = "hi hi, digit is 1 2, 3 and .5";
            
            string digitAsString;
            uint digitAsUint;
            double digitAsDouble;
            
            str.GetDigit(out digitAsString);
            str.GetDigit(out digitAsUint);
            str.GetDigit(out digitAsDouble);

            Console.WriteLine(digitAsString);// => 1235
            Console.WriteLine(digitAsUint);// => 11
            Console.WriteLine(digitAsDouble);// => 6.5
            Console.WriteLine(str.ValueCount('i'));// => 5
            Console.WriteLine(str.ValueCount("hi"));// => 2
            Console.WriteLine(str.ToTitleCase());// => Hi Hi, Digit Is 1 2, 3 And .5
        }
    }
}