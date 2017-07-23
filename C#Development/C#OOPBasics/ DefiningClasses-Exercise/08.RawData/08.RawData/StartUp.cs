namespace _08.RawData
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
                var carTokens = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = carTokens[0];
                var engineSpeed = int.Parse(carTokens[1]);
                var enginePower = int.Parse(carTokens[2]);
                var cargoWeight = int.Parse(carTokens[3]);
                var cargoType = carTokens[4];

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var tires = new[]
                {
                    new Tire(double.Parse(carTokens[5]), int.Parse(carTokens[6])),
                    new Tire(double.Parse(carTokens[7]), int.Parse(carTokens[8])),
                    new Tire(double.Parse(carTokens[9]), int.Parse(carTokens[10])),
                    new Tire(double.Parse(carTokens[11]), int.Parse(carTokens[12])),
                };

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            var command = Console.ReadLine();

            switch (command)
            {
                case "fragile":
                    cars
                        .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;
                case "flamable":
                    cars
                        .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                        .ToList()
                        .ForEach(c => Console.WriteLine(c.Model));
                    break;
            }
        }
    }
}