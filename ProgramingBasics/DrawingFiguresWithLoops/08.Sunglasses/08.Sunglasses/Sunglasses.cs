using System;

namespace _08.Sunglasses
{
    public class Sunglasses
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                if (i == 0 || i == n - 1)
                {
                    Console.WriteLine("{0}{1}{0}", new string('*', n * 2), new string(' ', n));
                }
                else if (i == (n - 1) / 2)
                {
                    Console.WriteLine("*{0}*{1}*{0}*", new string('/', (n * 2) - 2), new string ('|', n));
                }
                else
                {
                    Console.WriteLine("*{0}*{1}*{0}*", new string('/', (n * 2) - 2), new string(' ', n));
                }
            }
        }
    }
}