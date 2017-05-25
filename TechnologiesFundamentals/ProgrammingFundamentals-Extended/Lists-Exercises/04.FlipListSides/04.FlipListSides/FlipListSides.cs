using System;
using System.Linq;

namespace _04.FlipListSides
{
    public class FlipListSides
    {
        public static void Main(string[] args)
        {
            var inputList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 1; i < Math.Abs(inputList.Count / 2); i++)
            {
                var firstNumber = inputList[i];
                var lastNumber = inputList[inputList.Count - i - 1];

                inputList[i] = lastNumber;
                inputList[inputList.Count - i - 1] = firstNumber;
            }

            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
