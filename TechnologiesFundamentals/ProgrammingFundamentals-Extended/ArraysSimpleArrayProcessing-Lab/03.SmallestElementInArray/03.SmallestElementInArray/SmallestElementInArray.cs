using System;
using System.Linq;

namespace _03.SmallestElementInArray
{
    public class SmallestElementInArray
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var smallest = double.MaxValue;

            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                }
            }

            Console.WriteLine(smallest);
        }
    }
}
