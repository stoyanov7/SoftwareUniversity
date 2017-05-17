using System;

namespace _02.PracticeFloatingPoint
{
    public class PracticeFloatingPoint
    {
        public static void Main(string[] args)
        {
            var firstNumber = decimal.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());
            var thirdNumber = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"{firstNumber}\n{secondNumber}\n{thirdNumber}");
        }
    }
}
