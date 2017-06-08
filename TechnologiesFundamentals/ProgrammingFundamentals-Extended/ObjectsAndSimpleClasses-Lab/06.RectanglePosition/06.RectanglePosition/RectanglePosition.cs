namespace _06.RectancglePosition
{
    using System;
    using System.Linq;

    public class RectancglePosition
    {
        public static void Main(string[] args)
        {
            var firstRectangle = ReadRectangle();
            var secondRectangle = ReadRectangle();

            var result = firstRectangle.IsInside(secondRectangle);

            Console.WriteLine(result ? "Inside" : "Not inside");
        }

        public static Rectangle ReadRectangle()
        {
            var inputCoordinats = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var left = inputCoordinats[0];
            var top = inputCoordinats[1];
            var width = inputCoordinats[2];
            var height = inputCoordinats[3];

            var rectangle = new Rectangle(left, top, width, height);

            return rectangle;
        }
    }
}