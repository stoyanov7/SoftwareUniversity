using System;
using System.Linq;

public class RotateAndSum
{
    public static void Main(string[] args)
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int numberRotates = int.Parse(Console.ReadLine());
        int[] sum = new int[array.Length];

        for (int rotations = 0; rotations < numberRotates; rotations++)
        {
            int lastElement = array[array.Length - 1];

            for (int element = array.Length - 1; element > 0; element--)
            {
                array[element] = array[element - 1];
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
