namespace _03.BigFactorial
{
    using System;
    using System.Numerics;

    public class BigFactorial
    {
        public static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            for (var i = 1; i <= num; i++)
            {
                factorial = factorial * i;
            }

            Console.WriteLine(factorial);
        }
    } 
}