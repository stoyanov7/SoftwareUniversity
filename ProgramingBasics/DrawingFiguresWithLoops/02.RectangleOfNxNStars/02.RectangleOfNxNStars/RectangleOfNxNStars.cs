using System;

namespace _02.RectangleOfNxNStars
{
    public class RectangleOfNxNStars
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', n));
            }
        }
    }
}
