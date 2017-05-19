using System;

namespace _01.LargestElementInArray
{
    public class LargestElementInArray
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            var largest = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                if (largest < arr[i])
                {
                    largest = arr[i];
                }
            }

            Console.WriteLine(largest);
        }
    }
}