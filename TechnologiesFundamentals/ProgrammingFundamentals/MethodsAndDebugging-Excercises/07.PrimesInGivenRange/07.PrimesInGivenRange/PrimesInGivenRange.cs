using System;
using System.Collections.Generic;

public class PrimesInGivenRange
{
    public static void Main(string[] args)
    {
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());
        List<int> primeList = FindPrimesInRange(startNum, endNum);

        for (int i = 0; i < primeList.Count; i++)
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
        List<int> result = new List<int>();

        for (int i = startNum; i <= endNum; i++)
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
            for (int i = 2; i <= Math.Sqrt(number); i++)
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