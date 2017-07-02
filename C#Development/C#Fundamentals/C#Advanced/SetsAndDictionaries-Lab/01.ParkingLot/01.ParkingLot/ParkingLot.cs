namespace _01.ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        public static void Main(string[] args)
        {
            var carNumbers = new HashSet<string>();
            var line = Console.ReadLine();

            while (line != "END")
            {
                var lineTokens = line
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = lineTokens[0];
                var carNumber = lineTokens[1];

                if (command.Equals("IN"))
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    carNumbers.Remove(carNumber);
                }

                line = Console.ReadLine();
            }

            if (!carNumbers.Any())
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var carNumber in carNumbers.OrderBy(x => x))
            {
                Console.WriteLine(carNumber);
            }
        }
    }
}