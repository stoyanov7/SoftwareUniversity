using System;
using System.Linq;

namespace _06.EqualSequenceOfElementsInArray
{
    public class EqualSequenceOfElementsInArray
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray()
                .Distinct();

            Console.WriteLine(numbers.Count() != 1 ? "No" : "Yes");
        }
    }
}
