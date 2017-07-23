namespace _07.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = line[0];
                var fuelAmount = double.Parse(line[1]);
                var fuelConsumption = double.Parse(line[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            var commands = string.Empty;

            while ((commands = Console.ReadLine()) != "End")
            {
                var commandsTokens = commands
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var carModel = commandsTokens[1];
                var amountOfKm = double.Parse(commandsTokens[2]);
                var currentCar = cars.FirstOrDefault(c => c.Model == carModel);

                if (!Car.CanDrive(currentCar, amountOfKm))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            cars
                .ToList()
                .ForEach(c => Console.WriteLine(c.ToString()));
        }
    }
}