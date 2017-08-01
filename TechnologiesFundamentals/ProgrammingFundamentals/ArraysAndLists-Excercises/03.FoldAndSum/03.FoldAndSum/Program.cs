namespace _03.FoldAndSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var arrFoldA = new int[array.Length / 2];
            var arrFoldB = new int[array.Length / 2];
            var n = 0;

            for (var i = array.Length / 4 - 1; i >= 0; i--)
            {
                arrFoldA[n] = array[i];
                n++;
            }

            n = array.Length / 2 - 1;

            for (var i = array.Length - array.Length / 4; i < array.Length; i++)
            {
                arrFoldA[n] = array[i];
                n--;
            }

            n = 0;

            var start = array.Length / 4;
            var end = array.Length - array.Length / 4;

            for (var i = start; i < end; i++)
            {
                arrFoldB[n] = array[i];
                n++;
            }

            var sum = new int[arrFoldA.Length];

            for (var i = 0; i < arrFoldA.Length; i++)
            {
                sum[i] = arrFoldA[i] + arrFoldB[i];
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    } 
}