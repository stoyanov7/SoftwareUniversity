using System;
using System.Linq;

public class RotateAndSum
{
    public static void Main(string[] args)
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int numberRotates = int.Parse(Console.ReadLine());
        int[] sum = new int[array.Length];

        for (int i = 0; i < numberRotates; i++)
        {
            int lastElement = array[array.Length - 1];

            for (int j = array.Length - 1; j > 0; j--)
            {
                array[j] = array[j - 1];
            }
            array[0] = lastElement;

            for (int k = 0; k < array.Length; k++)
            {
                sum[k] += array[k];
            }
        }

        sum.ToList().ForEach(e => Console.Write(e + " "));
    }
}