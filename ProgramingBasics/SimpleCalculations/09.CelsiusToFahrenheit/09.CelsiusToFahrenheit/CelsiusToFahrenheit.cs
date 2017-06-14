using System;

namespace _09.CelsiusToFahrenheit
{
    public class CelsiusToFahrenheit
    {
        public static void Main(string[] args)
        {
            var gradus = double.Parse(Console.ReadLine());
            var celsius = gradus * 1.80000 + 32;

            Console.WriteLine(celsius);
        }
    }
}
