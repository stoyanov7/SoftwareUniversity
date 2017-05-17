using System;

namespace _04.DrawAFilledSquare
{
    public class DrawAFilledSquare
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            PrintHeaderRow(n);

            for (int i = 0; i < n - 2; i++)
            {
                PrintMiddleRow(n);
                Console.WriteLine();
            }

            PrintHeaderRow(n);
        }

        private static void PrintHeaderRow(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }

        private static void PrintMiddleRow(int n)
        {
            Console.Write("-");

            for (int i = 1; i < n; i++)
            {
                Console.Write("\\/");
            }

            Console.Write("-");
        }
    }
}
