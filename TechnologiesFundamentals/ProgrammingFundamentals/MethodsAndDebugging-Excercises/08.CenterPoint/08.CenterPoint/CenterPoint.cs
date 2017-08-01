namespace _08.CenterPoint
{
    using System;

    public class CenterPoint
    {
        public static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var distanceToCenterA = GetDistanceBetweenTwoPoints(x1, y1);
            var distanceToCenterB = GetDistanceBetweenTwoPoints(x2, y2);

            Console.WriteLine(distanceToCenterA < distanceToCenterB ? $"({x1}, {y1})" : $"({x2}, {y2})");
        }

        private static double GetDistanceBetweenTwoPoints(double x, double y) => Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    }

}