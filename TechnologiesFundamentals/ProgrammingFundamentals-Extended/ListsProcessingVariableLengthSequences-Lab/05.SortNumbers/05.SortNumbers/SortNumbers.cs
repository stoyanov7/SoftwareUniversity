using System;
using System.Linq;

namespace _05.SortNumbers
{
    public class SortNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();

            numbers.Sort();

            Console.WriteLine(string.Join("<= ", numbers));
        }
    }
}
