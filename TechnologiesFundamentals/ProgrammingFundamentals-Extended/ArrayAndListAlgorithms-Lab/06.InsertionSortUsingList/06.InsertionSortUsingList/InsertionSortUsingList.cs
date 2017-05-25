using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.InsertionSortUsingList
{
    public class InsertionSortUsingList
    {
        public static void Main(string[] args)
        {
            var inputArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            InsertionSort(inputArray);

            Console.WriteLine(string.Join(" ", inputArray));
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