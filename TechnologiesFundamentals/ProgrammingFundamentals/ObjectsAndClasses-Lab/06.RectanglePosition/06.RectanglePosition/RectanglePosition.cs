using System;
using System.Linq;

public class Rectangle
{
    public double Top { get; set; }

    public double Left { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Bottom => Top - Height;

    public double Right => Left + Width;

    public double Area => Width * Height;
}

public class RectanglePosition
{
    public static void Main(string[] args)
    {
        var firstRectangle = ReadRectangle();
        var secondRectangle = ReadRectangle();

        Console.WriteLine(IsInside(firstRectangle, secondRectangle) ?
            "Inside" : "Not inside");
    }

    public static Rectangle ReadRectangle()
    {
        var inputCoordinats = Console.ReadLine().Split().Select(double.Parse).ToArray();

        var rectangle = new Rectangle
        {
            Left = inputCoordinats[0],
            Top = inputCoordinats[1],
            Width = inputCoordinats[2],
            Height = inputCoordinats[3]
        };

        return rectangle;
    }

    public static bool IsInside(Rectangle first, Rectangle second)
    {
        var topIsCorrect = first.Top <= second.Top;
        var leftIsCorrect = first.Left >= second.Left;
        var rightIsCorrect = first.Right <= second.Right;
        var bottomIsCorrect = first.Bottom <= second.Bottom;

        return topIsCorrect && leftIsCorrect && rightIsCorrect && bottomIsCorrect;
    }
}