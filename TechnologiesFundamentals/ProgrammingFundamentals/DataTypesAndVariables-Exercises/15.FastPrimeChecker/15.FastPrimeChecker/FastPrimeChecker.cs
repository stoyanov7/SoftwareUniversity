namespace _15.FastPrimeChecker
{
    using System;

    public class FastPrimeChecker
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 2; i <= n; i++)
            {
                var isPrime = true;

                for (var divisor = 2; divisor <= Math.Sqrt(i); divisor++)
                {
                    if (i % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine(isPrime ? ($"{i} -> True") : ($"{i} -> False"));
            }
        }
    } 
}