using System;

namespace _04.FloatOrInteger
{
    public class FloatOrInteger
    {
        public static void Main(string[] args)
        {
            var firstNumber = double.Parse(Console.ReadLine());
            var result = (int)Math.Round(firstNumber);

            Console.WriteLine(result);
        }
    }
}
