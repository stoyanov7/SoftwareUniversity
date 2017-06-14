using System;

namespace _10.Diamond
{
    public class Diamond
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dashes = (n - 1) / 2;
            var middleDashes = 1;
            var stars = 1;
            var oddOrEven = 1;

            if (n % 2 == 0)
            {
                stars = 2;
                middleDashes = 2;
                oddOrEven = 0;
            }

            if (n == 1)
            {
                Console.WriteLine("*");
            }
            else if (n == 2)
            {
                Console.WriteLine("**");
            }
            else
            {
                for (var i = 0; i < n / 2 + oddOrEven; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("{0}{1}{0}", new string('-', (n - 1) / 2), new string('*', stars));
                    }
                    else
                    {
                        dashes--;
                        Console.WriteLine("{0}*{1}*{0}", new string('-', dashes), new string('-', middleDashes));
                        middleDashes += 2;
                    }
                }

                dashes = 0;
                middleDashes -= 2;

                for (var i = 0; i < (n + 1) / 2 - 2; i++)
                {
                    dashes++;
                    middleDashes -= 2;
                    Console.WriteLine("{0}*{1}*{0}", new string('-', dashes), new string('-', middleDashes));
                }

                Console.WriteLine("{0}{1}{0}", new string('-', (n - 1) / 2), new string('*', stars));
            }
        }
    }
}