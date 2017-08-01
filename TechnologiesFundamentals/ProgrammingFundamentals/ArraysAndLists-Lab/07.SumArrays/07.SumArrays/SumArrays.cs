namespace _07.SumArrays
{
    using System;
    using System.Linq;

    public class SumArrays
    {
        public static void Main(string[] args)
        {
            var arrayOne = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var arrayTwo = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var sumArray = new int[Math.Max(arrayOne.Length, arrayTwo.Length)];

            for (var i = 0; i < sumArray.Length; i++)
            {
                sumArray[i] = arrayOne[i % arrayOne.Length] + arrayTwo[i % arrayTwo.Length];
            }

            sumArray
                .ToList()
                .ForEach(Console.WriteLine);
        }
    } 
}