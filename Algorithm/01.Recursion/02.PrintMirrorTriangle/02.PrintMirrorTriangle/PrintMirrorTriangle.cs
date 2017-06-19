using System;

namespace _02.PrintMirrorTriangle
{
    public class PrintMirrorTriangle
    {
        public static void Main(string[] args)
        {
            var wrongInput = true;

            while (wrongInput)
            {
                Console.Write("Enter symbol: ");
                var inputSymbol = char.Parse(Console.ReadLine());

                Console.Write("Enter size: ");
                var size = int.Parse(Console.ReadLine());

                try
                {
                    PrintFigure(inputSymbol, size);
                    wrongInput = false;
                }
                catch (NegativeNumberException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
        }

        public static void PrintStar(char c, int n)
        {
            if (n < 0)
            {
                throw new NegativeNumberException("Cannot use negative number!");
            }

            for (var i = 0; i < n; i++)
            {
                Console.Write(c + " ");
            }

            Console.WriteLine();
        }

        public static void PrintFigure(char c, int n)
        {
            if (n == 0)
            {
                return;
            }

            if (n == 1)
            {
                Console.WriteLine(c);
                return;
            }

            PrintStar(c, n);
            PrintFigure(c, n - 1);
            PrintStar(c, n);
        }
    }
}
