using System;
using System.Linq;

namespace _03.CountOfGivenElementInArray
{
    public class CountOfGivenElementInArray
    {
        public static void Main(string[] args)
        {

            var arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var element = int.Parse(Console.ReadLine());
            var count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
