using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SmallestElementInArray
{
    public class SmallestElementInArray
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

            var smallest = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < smallest)
                {
                    smallest = numbers[i];
                }
            }

            Console.WriteLine(smallest);
        }
    }
}