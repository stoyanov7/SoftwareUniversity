using System;
using System.Linq;

public class LastKNumbersSums
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        long[] numberArray = new long[n];
        numberArray[0] = 1;

        for (int i = 1; i < n; i++)
        {
            long sum = 0;

            for (int previous = i - 1; previous >= 0 && previous >= i - k; previous--)
            {
                    sum += numberArray[previous];
            }
            numberArray[i] = sum;
        }

        numberArray.ToList().ForEach(e => Console.WriteLine(e));
    }
}
