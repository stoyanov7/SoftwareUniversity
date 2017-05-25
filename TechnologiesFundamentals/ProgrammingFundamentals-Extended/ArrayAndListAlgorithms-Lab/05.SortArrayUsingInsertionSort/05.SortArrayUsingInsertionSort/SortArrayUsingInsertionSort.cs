using System;
using System.Linq;

namespace _05.SortArrayUsingInsertionSort
{
    public class SortArrayUsingInsertionSort
    {
        public static void Main(string[] args)
        {
            var inputArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            InsertionSort(inputArray);

            Console.WriteLine(string.Join(" ", inputArray));
        }

        private static void InsertionSort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
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