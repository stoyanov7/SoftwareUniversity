using System;
using System.Linq;

namespace _01.DistinctList
{
    public class DistinctList
    {
        public static void Main(string[] args)
        {
            var inputList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Distinct()
                .ToList();

            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
