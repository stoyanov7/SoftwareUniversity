using System;

namespace _05.MaxNumber
{
    public class MaxNumber
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var max = int.MinValue;

            for (var i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());

                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine(max);
        }
    }
}
