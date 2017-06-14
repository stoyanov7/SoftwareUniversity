using System;

namespace _06.SquareOfStars
{
    public class SquareOfStars
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                Console.WriteLine("*");
            }

            for (int leftHeight = 0; leftHeight < n - 2; leftHeight++)
            {
                Console.WriteLine("\n*");

                for (int rightHeigth = 0; rightHeigth < n - 2; rightHeigth++)
                {
                    Console.WriteLine(" ");
                }

                Console.WriteLine("*");
            }

            Console.WriteLine("\n");


            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("*");
            }
        }
    }
}
