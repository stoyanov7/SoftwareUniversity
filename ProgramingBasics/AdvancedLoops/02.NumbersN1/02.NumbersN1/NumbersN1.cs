using System;

namespace _02.NumbersN1
{
    public class NumbersN1
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = n; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
