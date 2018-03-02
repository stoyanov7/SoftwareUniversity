namespace JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var dimestions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var x = dimestions[0];
            var y = dimestions[1];

            var matrix = new int[x, y];

            var value = 0;
            for (var rowIdex = 0; rowIdex < x; rowIdex++)
            {
                for (var colIndex = 0; colIndex < y; colIndex++)
                {
                    matrix[rowIdex, colIndex] = value++;
                }
            }

            string command;
            long sum = 0;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                var ivo = command
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evil = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var xEvil = evil[0];
                var yEvil = evil[1];

                while (xEvil >= 0 && yEvil >= 0)
                {
                    if (xEvil >= 0 && xEvil < matrix.GetLength(0) && yEvil >= 0 && yEvil < matrix.GetLength(1))
                    {
                        matrix[xEvil, yEvil] = 0;
                    }

                    xEvil--;
                    yEvil--;
                }

                var xIvo = ivo[0];
                var yIvo = ivo[1];

                while (xIvo >= 0 && yIvo < matrix.GetLength(1))
                {
                    if (xIvo >= 0 && xIvo < matrix.GetLength(0) && yIvo >= 0 && yIvo < matrix.GetLength(1))
                    {
                        sum += matrix[xIvo, yIvo];
                    }

                    yIvo++;
                    xIvo--;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
