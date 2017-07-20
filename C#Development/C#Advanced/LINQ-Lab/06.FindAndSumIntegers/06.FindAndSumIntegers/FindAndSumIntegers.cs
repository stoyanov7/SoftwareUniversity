namespace _06.FindAndSumIntegers
{
    using System;
    using System.Linq;

    public class FindAndSumIntegers
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => !x.Any(y => char.IsLetter(y)))
                .Select(long.Parse)
                .ToList();

            Console.WriteLine(input.Count().Equals(0) ? "No match" : input.Sum().ToString());

        }
    }
}
