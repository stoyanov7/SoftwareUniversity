using System;
using System.Linq;

namespace _03.SumAdjacentEqualNumbers
{
    public class SumAdjacentEqualNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
            .Split(' ')
            .Select(double.Parse)
            .ToList();

            for (var i = 0; i < numbers.Count - 1; i++)
            {
                var firstNumber = numbers[i];
                var secondNumber = numbers[i + 1];

                if (firstNumber == secondNumber)
                {
                    numbers[i] *= 2;
                    numbers.RemoveAt(i + 1);
                    i -= 2;

                    if (i < -1)
                    {
                        i = -1;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
