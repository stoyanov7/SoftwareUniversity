namespace _06.MathPower
{
    using System;

    public class MathPower
    {
        public static void Main(string[] args)
        {
            var number = double.Parse(Console.ReadLine());
            var power = double.Parse(Console.ReadLine());
            Console.WriteLine($"{RaiseToPower(number, power)}");
        }

        private static double RaiseToPower(double number, double power)
        {
            var result = 1D;

            for (var i = 0; i < power; i++)
            {
                result *= number;
            }

            return result;
        }
    } 
}