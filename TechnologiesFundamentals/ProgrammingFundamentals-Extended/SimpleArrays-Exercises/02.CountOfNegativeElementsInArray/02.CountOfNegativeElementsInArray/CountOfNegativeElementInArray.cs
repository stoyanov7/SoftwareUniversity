using System;

namespace _02.CountOfNegativeElementInArray
{
    public class CountOfNegativeElementInArray
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            var count = 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] < 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
