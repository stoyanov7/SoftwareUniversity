using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.MathPotato
{
    public class MathPotato
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToArray();
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(input);
            var count = 1;

            while (queue.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    var name = queue.Dequeue();
                    queue.Enqueue(name);
                }

                Console.WriteLine(IsPrime(count) ? $"Prime {queue.Peek()}" : $"Removed {queue.Dequeue()}");

                count++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        private static bool IsPrime(int count)
        { 
            if (count == 1) return false;
            if (count == 2) return true;

            for (var div = 2; div <= Math.Sqrt(count); div++)
            {
                if (count % div == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
