using System;
using System.Linq;
using System.Text;

namespace _05.CharRotation
{
    public class CharRotation
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .ToCharArray();

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = new StringBuilder();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                var charAsInt = currentNumber % 2 == 0 ? text[i] - currentNumber : text[i] + currentNumber;
                result.Append((char)charAsInt);
            }

            Console.WriteLine(result);
        }
    }
}