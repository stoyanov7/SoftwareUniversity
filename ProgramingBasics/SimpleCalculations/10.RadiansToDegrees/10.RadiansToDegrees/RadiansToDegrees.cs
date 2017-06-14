using System;

namespace _10.RadiansToDegrees
{
    public class RadiansToDegrees
    {
        public static void Main(string[] args)
        {
            var radians = double.Parse(Console.ReadLine());
            var celsius = radians * 180 / Math.PI;

            Console.WriteLine(Math.Round(celsius));
        }
    }
}
