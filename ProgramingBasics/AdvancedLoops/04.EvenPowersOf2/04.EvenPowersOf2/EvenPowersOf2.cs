using System;

namespace _04.EvenPowersOf2
{
    public class EvenPowersOf2
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var num = 1;

            for (var i = 0; i <= n; i += 2)
            {
                Console.WriteLine(num);
                num *= 4;
            }
        }
    }
}
