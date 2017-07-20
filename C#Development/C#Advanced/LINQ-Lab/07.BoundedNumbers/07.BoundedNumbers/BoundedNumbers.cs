namespace _07.BoundedNumbers
{
    using System;
    using System.Linq;

    public class BoundedNumbers
    {
        public static void Main(string[] args)
        {
            var bound = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(n => n >= bound.Min() && n <= bound.Max())
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
