using System;
using System.Linq;

namespace _01.ArrayContainsElement
{
    public class ArrayContainsElement
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var find = int.Parse(Console.ReadLine());
            bool isFind = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == find)
                {
                    isFind = true;
                    break;
                }
            }

            Console.WriteLine(isFind ? "yes" : "no");
        }
    }
}