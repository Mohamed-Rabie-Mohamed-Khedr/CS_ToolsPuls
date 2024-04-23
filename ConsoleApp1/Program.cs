namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am a developer.".IsTitle());// => false
            Console.WriteLine("I Am A Developer.".IsTitle());// => true
        }
    }
}