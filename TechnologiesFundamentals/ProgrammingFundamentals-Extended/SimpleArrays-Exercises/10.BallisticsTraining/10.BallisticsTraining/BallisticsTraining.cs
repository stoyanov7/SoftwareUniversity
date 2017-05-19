using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BallisticsTraining
{
    public class BallisticsTraining
    {
        public static void Main(string[] args)
        {
            var coordinates = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var x = 0d;
            var y = 0d;

            var line = Console.ReadLine()
                .Split(' ')
                .ToArray();

            for (int i = 0; i < line.Length - 1; i+= 2)
            {
                var direction = line[i];
                var value = double.Parse(line[i + 1]);

                if (direction == "up")
                {
                    y += value;
                }
                else if (direction == "down")
                {
                    y -= value;
                }
                else if (direction == "left")
                {
                    x -= value;
                }
                else
                {
                    x += value;
                }
            }

            Console.WriteLine($"firing at [{x}, {y}]");

            if (x == coordinates.First() && y == coordinates.Last())
            {
                Console.WriteLine("got 'em!");
            }
            else
            {
                Console.WriteLine("better luck next time...");
            }
        }
    }
}