using System;

namespace _13.AreaOfFigures
{
    public class AreaOfFigures
    {
        public static void Main(string[] args)
        {
            var figure = Console.ReadLine().ToLower();
            var areaOfFigure = 0.0;

            switch (figure)
            {
                case "square":
                    var side = double.Parse(Console.ReadLine());
                    areaOfFigure = side * side;
                    break;
                case "rectangle":
                    var a = double.Parse(Console.ReadLine());
                    var b = double.Parse(Console.ReadLine());
                    areaOfFigure = a * b;
                    break;
                case "circle":
                    var radius = double.Parse(Console.ReadLine());
                    areaOfFigure = Math.PI * radius * radius;
                    break;
                case "triangle":
                    var sideT = double.Parse(Console.ReadLine());
                    var h = double.Parse(Console.ReadLine());
                    areaOfFigure = (sideT * h) / 2;
                    break;
            }

            Console.WriteLine(Math.Round(areaOfFigure, 3));
        }
    }
}