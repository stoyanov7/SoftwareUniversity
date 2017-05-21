using System;
using System.Linq;

namespace _07.CountNumbers
{
    public class CountNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            numbers.Sort();

            var count = new int[1001];

            foreach (var number in numbers)
            {
                count[number]++;
            }

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                {
                    Console.WriteLine($"{i} -> {count[i]}");
                }
            }
        }
    }
}
