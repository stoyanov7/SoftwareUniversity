using System;

namespace _15.ThreeEqualNumbers
{
    public class ThreeEqualNumbers
    {
        public static void Main(string[] args)
        {
            var firstNum = double.Parse(Console.ReadLine());
            var secondNum = double.Parse(Console.ReadLine());
            var thirdNum = double.Parse(Console.ReadLine());

            Console.WriteLine(firstNum == secondNum && secondNum == thirdNum ? "yes" : "no");
        }
    }
}
