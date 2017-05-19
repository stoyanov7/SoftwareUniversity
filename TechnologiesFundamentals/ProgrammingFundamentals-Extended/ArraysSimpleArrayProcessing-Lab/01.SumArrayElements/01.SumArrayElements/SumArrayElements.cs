using System;

namespace _01.SumArrayElements
{
    public class SumArrayElements
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            for (var i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            var sum = 0;

            for (var j = 0; j < n; j++)
            {
                sum += arr[j];
            }

            Console.WriteLine(sum);
        }
    }
}