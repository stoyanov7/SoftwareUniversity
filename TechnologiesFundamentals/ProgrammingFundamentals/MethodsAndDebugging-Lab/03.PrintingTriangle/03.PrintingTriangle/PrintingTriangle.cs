namespace _03.PrintingTriangle
{
    using System;

    public class PrintingTriangle
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                PrintLine(1, i);
            }

            PrintLine(1, n);

            for (var j = n - 1; j >= 0; j--)
            {
                PrintLine(1, j);
            }
        }

        private static void PrintLine(int start, int end)
        {
            for (var i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    } 
}