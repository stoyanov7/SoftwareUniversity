namespace _10.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var engineTokens = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var model = engineTokens[0];
                var power = int.Parse(engineTokens[1]);

                var engine = new Engine(model, power);

                if (engineTokens.Length >= 3)
                {
                    if (engineTokens[2].All(char.IsDigit))
                    {
                        engine.Displacement = int.Parse(engineTokens[2]);
                    }
                    else
                    {
                        engine.Efficiency = engineTokens[2];
                    }
                }

                if (engineTokens.Length == 4)
                {
                    engine.Efficiency = engineTokens[3];
                }

                engines.Add(engine);
            }

            n = int.Parse(Console.ReadLine());
            

            for (var i = 0; i < n; i++)
            {
                var carsTokens = Console.ReadLine()
                    .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var model = carsTokens[0];
                var engineName = carsTokens[1];

                var car = new Car(model, engines.FirstOrDefault(e => e.Model.Equals(engineName[1])));

                if (carsTokens.Length >= 3)
                {
                    if (carsTokens[2].All(char.IsDigit))
                    {
                        car.Weight = int.Parse(carsTokens[2]);
                    }
                    else
                    {
                        car.Color = carsTokens[2];
                    }
                }

                if (carsTokens.Length == 4)
                {
                    car.Color = carsTokens[3];
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}