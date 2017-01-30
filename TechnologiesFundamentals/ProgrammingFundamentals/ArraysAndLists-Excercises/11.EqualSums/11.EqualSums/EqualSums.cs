using System;
using System.Linq;

public class EqualSums
{
    private static int pos = 0;
    private static bool isExist = false;

    public static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            int leftSum = SumLeft(arr, i);
            int rightSum = SumRight(arr, i);

            if (leftSum == rightSum)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine("no");
    }

    private static int SumLeft(int[] arr, int position)
    {
        int leftSum = 0;

        for (int i = position; i > 0; i--)
        {
            int nextPosition = i - 1;

            if (i == 0)
            {
                leftSum += 0;
                break;
            }
            else
            {
                leftSum += arr[nextPosition];

            }
        }
        return leftSum;

    }

    private static int SumRight(int[] arr, int position)
    {
        int rightSum = 0;

        for (int i = position; i < arr.Length; i++)
        {
            int nextPosition = (i + 1) % arr.Length;

            if (arr.Length == 1 || nextPosition == 0)
            {
                rightSum += 0;
                break;
            }
            else
            {
                rightSum += arr[nextPosition];
            }
        }

        return rightSum;
    }
}