namespace _02.Largest3Numbers
{
    using System;
    using System.Linq;

    public class Largest3Numbers
    {

        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var result = numbers
                .OrderByDescending(n => n)
                .Take(3);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}