using System;

namespace _09.House
{
    public class House
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stars = 1;

            if (n % 2 == 0)
            {
                stars = 2;
            }

            var dashes = (n - stars) / 2;

            for (var i = 0; i < (n + 1) / 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('-', dashes), new string('*', stars));
                stars += 2;
                dashes--;
            }

            for (var i = 0; i < n / 2; i++)
            {
                Console.WriteLine("|{0}|", new string('*', n - 2));

            }
        }
    }
}
