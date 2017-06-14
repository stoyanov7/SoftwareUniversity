using System;

namespace _01.Numbers1NWithStep3
{
    public class Numbers1NWithStep3
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 1; i <= n; i += 3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
