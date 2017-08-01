namespace _08.CondenseArrayToNumber
{
    using System;
    using System.Linq;

    public class CondenseArrayToNumber
    {
        public static void Main(string[] args)
        {
            var numberArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            while (numberArray.Length > 1)
            {
                var condensed = new int[numberArray.Length - 1];

                for (var j = 0; j < numberArray.Length - 1; j++)
                {
                    condensed[j] = numberArray[j] + numberArray[j + 1];
                }

                numberArray = condensed;
            }

            numberArray
                .ToList()
                .ForEach(Console.WriteLine);
        }
    } 
}