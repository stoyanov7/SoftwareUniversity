using System;

namespace _10.CheckPrime
{
    public class CheckPrime
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var isPrime = true;

            if (n < 2)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isPrime ? "Prime" : "Not prime");
        }
    }
}