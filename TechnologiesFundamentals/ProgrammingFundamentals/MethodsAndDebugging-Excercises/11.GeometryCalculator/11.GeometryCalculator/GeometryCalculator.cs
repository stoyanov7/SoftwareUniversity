namespace _11.GeometryCalculator
{
    using System;

    public class GeometryCalculator
    {
        public static void Main(string[] args)
        {
            var figure = Console.ReadLine()
                .ToLower();
            GetFigureArea(figure);
        }

        private static void GetFigureArea(string figure)
        {
            switch (figure)
            {
                case "triangle":
                {
                    var b = double.Parse(Console.ReadLine());
                    var h = double.Parse(Console.ReadLine());
                    var area = (b * h) / 2;
                    Console.WriteLine($"{area:F2}");
                }
                break;
                case "square":
                {
                    var a = double.Parse(Console.ReadLine());
                    var area = Math.Pow(a, 2);
                    Console.WriteLine($"{area:F2}");
                }
                break;
                case "rectangle":
                {
                    var w = double.Parse(Console.ReadLine());
                    var h1 = double.Parse(Console.ReadLine());
                    var area = w * h1;
                    Console.WriteLine($"{area:F2}");
                }
                break;
                case "circle":
                {
                    var r = double.Parse(Console.ReadLine());
                    var area = Math.PI * Math.Pow(r, 2);
                    Console.WriteLine($"{area:F2}");
                }
                break;
            }
        }
    } 
}