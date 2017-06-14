using System;

namespace _06.MinNumber
{
    public class MinNumber
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var min = int.MaxValue;
            var num = 0;

            for (var i = 0; i < n; i++)
            {
                num = int.Parse(Console.ReadLine());

                if (num < min)
                {
                    min = num;
                }
            }

            Console.WriteLine(min);
        }
    }
}
