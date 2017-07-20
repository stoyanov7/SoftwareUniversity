namespace _05.MinEvenNumber
{
    using System;
    using System.Linq;

    public class MinEvenNumber
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Where(n => n % 2 == 0)
                .ToList();

            Console.WriteLine(numbers.Any() ? $"{numbers.Min():f2}" : "No match");
        }
    }
}
