namespace _04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main(string[] args)
        {
            var commands = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var enqueueElements = commands[0];
            var dequeueElements = commands[1];
            var checkNumber = commands[2];

            var queueElements = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var queue = new Queue<int>(queueElements);

            for (int i = 0; i < dequeueElements; i++)
            {
                if (queue.Any())
                {
                    queue.Dequeue();
                }
            }

            if (queue.Contains(checkNumber) && queue.Any())
            {
                Console.WriteLine("true");

            }
            else
            {
                Console.WriteLine(queue.Any() ? queue.Min() : 0);
            }
        }
    }
}