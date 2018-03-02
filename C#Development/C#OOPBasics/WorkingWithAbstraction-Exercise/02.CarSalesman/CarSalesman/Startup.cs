namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var engines = ReadEnginData();
            var cars = ReadCarsData(engines);

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static List<Engine> ReadEnginData()
        {
            var engines = new List<Engine>();
            var engineCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < engineCount; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = parameters[0];
                var power = int.Parse(parameters[1]);

                if (parameters.Length == 3 && int.TryParse(parameters[2], out var displacement))
                {
                    engines.Add(new Engine(model, power, displacement));
                }
                else if (parameters.Length == 3)
                {
                    var efficiency = parameters[2];
                    engines.Add(new Engine(model, power, efficiency));
                }
                else if (parameters.Length == 4)
                {
                    var efficiency = parameters[3];
                    engines.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }

            return engines;
        }

        private static IEnumerable<Car> ReadCarsData(IReadOnlyCollection<Engine> engines)
        {
            var cars = new List<Car>();
            var carCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < carCount; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = parameters[0];
                var engineModel = parameters[1];
                var engine = engines
                    .FirstOrDefault(x => x.Model == engineModel);

                if (parameters.Length == 3 && int.TryParse(parameters[2], out var weight))
                {
                    cars.Add(new Car(model, engine, weight));
                }
                else if (parameters.Length == 3)
                {
                    var color = parameters[2];
                    cars.Add(new Car(model, engine, color));
                }
                else if (parameters.Length == 4)
                {
                    var color = parameters[3];
                    cars.Add(new Car(model, engine, int.Parse(parameters[2]), color));
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }

            return cars;
        }
    }
}
