namespace _02.SignOfIntegerNumber
{
    using System;

    public class SignOfIntegerNumber
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            PrintSign(number);
        }

        private static void PrintSign(int num)
        {
            if (num > 0)
            {
                Console.WriteLine($"The number {num} is positive.");
            }
            else if (num < 0)
            {
                Console.WriteLine($"The number {num} is negative.");
            }
            else if (num == 0)
            {
                Console.WriteLine($"The number {num} is zero.");
            }
        }
    } 
}