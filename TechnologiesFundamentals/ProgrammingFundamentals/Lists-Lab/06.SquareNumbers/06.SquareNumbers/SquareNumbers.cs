namespace _06.SquareNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SquareNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var squareNumbers = new List<int>();

            foreach (var number in numbers)
            {
                var currentNum = Math.Sqrt(number);

                if (currentNum == (int)currentNum)
                {
                    squareNumbers.Add(number);
                }
            }

            squareNumbers.Sort();
            squareNumbers.Reverse();

            Console.WriteLine(string.Join(" ", squareNumbers));
        }
    }
}
