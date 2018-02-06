namespace ReverseAndExclude
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var divisor = int.Parse(Console.ReadLine());
            
            var remainingNumbers = numbers
                .Reverse()
                .Where(n => n % divisor != 0);

            Console.WriteLine(string.Join(" ", remainingNumbers));
        }
    }
}
