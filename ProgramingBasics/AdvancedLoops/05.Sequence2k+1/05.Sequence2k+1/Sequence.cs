using System;

namespace _05.Sequence
{
    public class Sequence
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int k = 1;

            while (k <= n)
            {
                Console.WriteLine(k);
                k = 2 * k + 1;
            }
        }
    }
}
