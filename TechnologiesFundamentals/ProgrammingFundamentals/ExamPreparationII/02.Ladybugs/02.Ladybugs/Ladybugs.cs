using System;
using System.Linq;

public class Ladybugs
{
    public static void Main(string[] args)
    {
        var fieldSize = int.Parse(Console.ReadLine());

        var ladybugIndexes = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .Where(l => l >= 0 && l < fieldSize)
            .ToArray();

        var ladybugsArray = new int[fieldSize];

        for (int i = 0; i < ladybugIndexes.Length; i++)
        {
            var currentLadybugIndex = ladybugIndexes[i];
            ladybugsArray[currentLadybugIndex] = 1;
        }

        var inputLine = Console.ReadLine();
        while (!inputLine.Equals("end"))
        {
            var tokens = inputLine.Split(' ');
            var ladybugIndex = int.Parse(tokens[0]);
            var direction = tokens[1];
            var flyLength = int.Parse(tokens[2]);

            var isInvalidIndex = ladybugIndex < 0 || ladybugIndex >= ladybugsArray.Length;

            if (isInvalidIndex)
            {
                inputLine = Console.ReadLine();
                continue;
            }

            var isIndexZero = ladybugsArray[ladybugIndex] == 0;

            if (isIndexZero)
            {
                inputLine = Console.ReadLine();
                continue;
            }

            MoveLadyBug(ladybugsArray, ladybugIndex, flyLength, direction);

            inputLine = Console.ReadLine();
        }

        Console.WriteLine(string.Join(" ", ladybugsArray));
    }

    private static void MoveLadyBug(int[] ladybugsArray, int ladybugIndex, int flyLength, string direction)
    {
        ladybugsArray[ladybugIndex] = 0;

        var isLeftArrayOrFoundPlace = false;

        while (!isLeftArrayOrFoundPlace)
        {
            switch (direction)
            {
                case "left":
                    ladybugIndex -= flyLength;
                    break;

                case "right":
                    ladybugIndex += flyLength;
                    break;
            }

            if (ladybugIndex < 0 || ladybugIndex >= ladybugsArray.Length)
            {
                // left arry
                isLeftArrayOrFoundPlace = true;
                continue;
            }

            if (ladybugsArray[ladybugIndex] == 1)
            {
                // stepped over another ladybug
                continue;
            }

            if (ladybugsArray[ladybugIndex] == 0)
            {
                // found place in the array
                ladybugsArray[ladybugIndex] = 1;
                isLeftArrayOrFoundPlace = true;
                continue;
            }
        }
    }
}