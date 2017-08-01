namespace _07.PrimesInGivenRange
{
    using System;
    using System.Collections.Generic;

    public class PrimesInGivenRange
    {
        public static void Main(string[] args)
        {
            var startNum = int.Parse(Console.ReadLine());
            var endNum = int.Parse(Console.ReadLine());
            var primeList = FindPrimesInRange(startNum, endNum);

            for (var i = 0; i < primeList.Count; i++)
            {
                Console.Write(primeList[i]);

                if (i != primeList.Count - 1)
                {
                    Console.Write(", ");
                }
            }
        }

        private static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            var result = new List<int>();

            for (var i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static bool IsPrime(long number)
        {
            if (number < 2)
            {
                return false;
            }
            else
            {
                for (var i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    } 
}