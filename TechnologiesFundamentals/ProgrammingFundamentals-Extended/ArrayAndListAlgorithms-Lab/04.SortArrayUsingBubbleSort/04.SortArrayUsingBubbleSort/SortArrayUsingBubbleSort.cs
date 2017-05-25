using System;
using System.Linq;

namespace _04.SortArrayUsingBubbleSort
{
    public class SortArrayUsingBubbleSort
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            BubbleSort(inputNumbers);

            Console.WriteLine(string.Join(" ", inputNumbers));
        }

        private static void BubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                Swap(arr);
            }
        }

        private static void Swap(int[] arr)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    var temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}