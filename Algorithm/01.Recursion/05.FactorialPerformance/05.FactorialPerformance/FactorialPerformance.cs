using System;
using System.Diagnostics;
using System.Numerics;

namespace _05.FactorialPerformance
{
    public class FactorialPerformance
    {
        public static void Main(string[] args)
        {
            #region Recursive Factorial
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (var i = 0; i < 1000000; i++)
            {
                var f = RecursiveFactorial(15);
            }

            stopWatch.Stop();

            var ts = stopWatch.Elapsed;
            var elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            Console.WriteLine($"Recursive factorial time: {elapsedTime}");
            #endregion

            #region Iteractive Factorial
            var stopWatchI = new Stopwatch();
            stopWatchI.Start();

            for (int i = 0; i < 1_000_000; i++)
            {
                var f = IteractiveFactorial(15);
            }

            stopWatchI.Stop();
            var elapsedTimeI = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            Console.WriteLine($"Iteractive factorial time: {elapsedTimeI}");
            #endregion
        }

        private static BigInteger RecursiveFactorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                return num * RecursiveFactorial(num - 1);
            }
        }

        private static BigInteger IteractiveFactorial(int num)
        {
            var result = new BigInteger(1);

            for (var i = 1; i <= num; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
