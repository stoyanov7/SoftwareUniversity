using System;

namespace _04.TriangleOf55Stars
{
    public class TriangleOfStars
    {
        public static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 0; j < i; j++)
                    Console.WriteLine("*");

                Console.WriteLine("");
            }
        }
    }
}
