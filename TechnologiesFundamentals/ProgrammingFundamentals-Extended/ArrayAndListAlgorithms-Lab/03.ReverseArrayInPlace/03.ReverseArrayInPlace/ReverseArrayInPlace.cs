using System;
using System.Linq;

namespace _03.ReverseArrayInPlace
{
    public class ReverseArrayInPlace
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                var temp = numbers[i];
                numbers[i] = numbers[numbers.Length - i - 1];
                numbers[numbers.Length - i - 1] = temp;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
