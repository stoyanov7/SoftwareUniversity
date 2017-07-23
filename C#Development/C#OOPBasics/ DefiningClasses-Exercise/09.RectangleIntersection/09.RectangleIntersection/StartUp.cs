using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var numberOfRectangles = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var n = int.Parse(numberOfRectangles[0]);
        var m = int.Parse(numberOfRectangles[1]);
        var rectangles = new Rectangle[n];

        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var id = tokens[0];
            var width = double.Parse(tokens[1]);
            var height = double.Parse(tokens[2]);
            var x = double.Parse(tokens[3]);
            var y = double.Parse(tokens[4]);

            rectangles[i] = new Rectangle(id, width, height, x, y);
        }

        for (var i = 0; i < m; i++)
        {
            var tokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var firstRectangle = rectangles
                .First(r => r.Id == tokens[0]);

            var secondRectangle = rectangles
                .First(r => r.Id == tokens[1]);

            Console.WriteLine(firstRectangle.IsThereIntersection(secondRectangle));
        }
    }
}