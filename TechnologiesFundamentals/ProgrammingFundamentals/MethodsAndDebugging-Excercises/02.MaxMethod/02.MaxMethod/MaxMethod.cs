namespace _02.MaxMethod
{
    using System;

    public class MaxMethod
    {
        public static void Main(string[] args)
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());

            var firstAndSecond = GetMax(firstNumber, secondNumber);
            var biggest = GetMax(firstAndSecond, thirdNumber);

            Console.WriteLine(biggest);
        }

        private static int GetMax(int a, int b) => Math.Max(a, b);
    } 
}