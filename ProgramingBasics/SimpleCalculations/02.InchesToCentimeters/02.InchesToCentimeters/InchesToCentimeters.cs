using System;

namespace _02.InchesToCentimeters
{
    public class InchesToCentimeters
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("inches = ");
            var inches = double.Parse(Console.ReadLine());
            Console.WriteLine($"centimeters = {inches * 2.54}");
        }
    }
}
