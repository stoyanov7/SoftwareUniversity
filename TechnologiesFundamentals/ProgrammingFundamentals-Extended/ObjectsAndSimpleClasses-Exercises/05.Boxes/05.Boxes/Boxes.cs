using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Boxes
{
    public class Boxes
    {
        public static void Main(string[] args)
        {
            var boxes = new List<Box>();
            var line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                ReadBox(boxes, line);

                line = Console.ReadLine();
            }

            foreach (var box in boxes)
            {
                Console.WriteLine($"Box: {box.Width}, {box.Height}");
                Console.WriteLine($"Perimeter: {Box.CalculatePerimeter(box.Width, box.Height)}");
                Console.WriteLine($"Area: {Box.CalculateArea(box.Width, box.Height)}");
            }
        }

        private static void ReadBox(List<Box> boxes, string line)
        {
            var lineTokens = line
                .Split(": |".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var upperLeft = new Point(lineTokens[0], lineTokens[1]);
            var upperRight = new Point(lineTokens[2], lineTokens[3]);
            var bottomLeft = new Point(lineTokens[4], lineTokens[5]);
            var bottomRight = new Point(lineTokens[6], lineTokens[7]);

            var box = new Box(upperLeft, upperRight, bottomLeft, bottomRight);
            boxes.Add(box);
        }
    }
}
