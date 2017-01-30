using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] arrFoldA = new int[array.Length / 2];
        int[] arrFoldB = new int[array.Length / 2];
        int n = 0;

        for (int i = array.Length / 4 - 1; i >= 0; i--)
        {
            arrFoldA[n] = array[i];
            n++;
        }
        n = array.Length / 2 - 1;

        for (int i = array.Length - array.Length / 4; i < array.Length; i++)
        {
            arrFoldA[n] = array[i];
            n--;
        }
        n = 0;

        int start = array.Length / 4;
        int end = array.Length - array.Length / 4;

        for (int i = start; i < end; i++)
        {
            arrFoldB[n] = array[i];
            n++;
        }

        int[] sum = new int[arrFoldA.Length];

        for (int i = 0; i < arrFoldA.Length; i++)
        {
            sum[i] = arrFoldA[i] + arrFoldB[i];
        }

        Console.WriteLine(string.Join(" ", sum));
    }
}