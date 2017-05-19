using System;
using System.Linq;

namespace _02.CountOfDddNumbersInArray
{
    public class CountOfDddNumbersInArray
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) % 2 != 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
