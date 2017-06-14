using System;

namespace _04.TriangleOfDollars
{
    public class TriangleOfDollars
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 1; i <= n; i++)
            {
                Console.WriteLine(new string('$', i));
            }
        }
    }
}
