using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.LargestNElements
{
    public class LargestNElements
    {
        public static void Main(string[] args)
        {

            var inputArray = Console.ReadLine()
                   .Split(' ')
                   .Select(int.Parse)
                   .ToList();

            var count = int.Parse(Console.ReadLine());

            InsertionSort(inputArray);
            inputArray.Reverse();

            Console.WriteLine(string.Join(" ", inputArray.Take(count)));
        }

        private static void InsertionSort(List<int> arr)
        {
            for (var i = 1; i < arr.Count; i++)
            {
                var currentElement = arr[i];
                var previousElement = i - 1;

                while (previousElement >= 0 && arr[previousElement] > currentElement)
                {
                    arr[previousElement + 1] = arr[previousElement];
                    previousElement -= 1;
                }
                arr[previousElement + 1] = currentElement;
            }
        }
    }
}
