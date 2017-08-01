namespace _02.RotateAndSum
{
    using System;
    using System.Linq;

    public class RotateAndSum
    {
        public static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var numberRotates = int.Parse(Console.ReadLine());
            var sum = new int[array.Length];

            for (var rotations = 0; rotations < numberRotates; rotations++)
            {
                var lastElement = array[array.Length - 1];

                for (var element = array.Length - 1; element > 0; element--)
                {
                    array[element] = array[element - 1];
                }

                array[0] = lastElement;

                for (var k = 0; k < array.Length; k++)
                {
                    sum[k] += array[k];
                }
            }

            sum
                .ToList()
                .ForEach(e => Console.Write(e + " "));
        }
    }
}