using System;

namespace _01.RectangleOf10x10Stars
{
    public class RectangleOf10x10Stars
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(new string('*', 10));
            }
        }
    }
}
