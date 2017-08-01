namespace _05.RoundingNumbers
{
    using System;
    using System.Linq;

    public class RoundingNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse).
                ToArray();

            for (var i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} => ");
                numbers[i] = Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine(numbers[i]);
            }
        }
    } 
}