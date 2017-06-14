using System;

namespace _07.ChristmasTree
{
    public class ChristmasTree
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine(new string(' ', n - i) + new string('*', i) +
                    " | " + new string('*', i));
            }
        }
    }
}
