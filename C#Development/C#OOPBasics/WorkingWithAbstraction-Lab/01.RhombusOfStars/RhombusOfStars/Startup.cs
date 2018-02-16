namespace RhombusOfStars
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            for (var i = 1; i <= size; i++)
            {
                PrintRow(size, i);
            }

            for (var i = size - 1; i >= 1; i--)
            {
                PrintRow(size, i);
            }
        }

        private static void PrintRow(int figureSize, int startCount)
        {
            for (var i = 0; i < figureSize - startCount; i++)
            {
                Console.Write(" ");
            }

            for (var j = 1; j < startCount; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
