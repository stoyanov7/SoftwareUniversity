namespace _09.ExtractMiddleElements
{
    using System;
    using System.Linq;

    public class ExtractMiddleElements
    {
        public static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            if (array.Length == 1)
            {
                ExtractOne(array);
            }
            else if (array.Length % 2 == 0)
            {
                ExtractEven(array);
            }
            else
            {
                ExtractOdd(array);
            }
        }

        private static void ExtractOne(int[] arr)
        {
            Console.WriteLine(arr[0]);
        }

        private static void ExtractEven(int[] arr)
        {
            Console.WriteLine(($"{arr[arr.Length / 2 - 1]}, {arr[arr.Length / 2]}"));
        }

        private static void ExtractOdd(int[] arr)
        {
            Console.WriteLine($"{arr[arr.Length / 2 - 1]}, {arr[arr.Length / 2]}, {arr[arr.Length / 2 + 1]}");
        }
    } 
}