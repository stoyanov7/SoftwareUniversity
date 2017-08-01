namespace _02.CircleAreaPrecision12
{
    using System;

    public class CircleAreaPrecision
    {
        public static void Main(string[] args)
        {
            var radius = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F12}", (Math.PI * Math.Pow(radius, 2)));
        }
    }
}