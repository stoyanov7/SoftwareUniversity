namespace _05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SequenceWithQueue
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<long>();
            var n = long.Parse(Console.ReadLine());
            queue.Enqueue(n);
            var sb = new StringBuilder();

            for (var i = 0; i < 50; i++)
            {
                var currentNumber = queue.Peek();
                queue.Enqueue(currentNumber + 1);
                queue.Enqueue(2 * currentNumber + 1);
                queue.Enqueue(currentNumber + 2);

                sb.Append(queue.Dequeue() + " ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}