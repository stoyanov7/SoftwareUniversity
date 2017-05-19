using System;
using System.Linq;

namespace _02.MultiplyAnArrayOfDoubles
{
    public class MultiplyAnArrayOfDoubles
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var p = double.Parse(Console.ReadLine());

            var result = 0.0;

            for (var i = 0; i < arr.Length; i++)
            {
                result = arr[i] * p;
                Console.Write(result + " ");
            }
        }
    }
}
