namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>();
            var lines = int.Parse(Console.ReadLine());

            for (var i = 0; i < lines; i++)
            {
                cars.Add(new Car(Console.ReadLine));
            }

            void Print(IEnumerable<string> n) => Console.WriteLine(string.Join(Environment.NewLine, n));

            var command = Console.ReadLine();
            if (command == "fragile")
            {
                var fragile = cars
                    .Where(x => x.CargoType == "fragile" && x.Tires.Any(y => y.Key < 1))
                    .Select(x => x.Model)
                    .ToList();

                Print(fragile);
            }
            else
            {
                var flamable = cars
                    .Where(x => x.CargoType == "flamable" && x.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Print(flamable);
            }
        }
    }
}
