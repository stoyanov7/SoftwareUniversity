namespace _09.RefactorSpecialNumbers
{
    using System;

    public class RefactorSpecialNumbers
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 1; i <= n; i++)
            {
                var temporaryNumber = i;
                var sum = 0;

                while (temporaryNumber > 0)
                {
                    sum += temporaryNumber % 10;
                    temporaryNumber /= 10;
                }

                var special = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{i} -> {special}");
                sum = 0;
            }
        }
    }
}
