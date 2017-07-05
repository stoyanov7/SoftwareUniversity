using System;
using System.Collections.Generic;

namespace _07.CarSalesman
{
    public class CarSalesman
    {
        public static void Main(string[] args)
        {
            Car car = null;
            Engine engine = null;
            var cars = new List<Car>();
            var engines = new List<Engine>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var engineTokens = Console.ReadLine()
                    .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                var model = engineTokens[0];
                var power = int.Parse(engineTokens[1]);

                if (engineTokens.Length == 4)
                {
                    var displacement = int.Parse(engineTokens[2]);
                    var efficiency = engineTokens[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (engineTokens.Length == 3)
                {
                    if (IsNumber(engineTokens[2])) 
                    {
                        engine = new Engine(model, power, engineTokens[2]);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineTokens[2]);
                    }
                }
                else
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            var m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var carTokens = Console.ReadLine()
                    .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                var model = carTokens[0];
                var engineName = carTokens[1];

                foreach (var engine1 in engines)
                {
                    if (engine1.Model.Equals(engineName)) {
                        engine = engine1;
                        break;
                    }
                }

                if (carTokens.Length == 4)
                {
                    var weight = int.Parse(carTokens[2]);
                    var color = carTokens[3];
                    car = new Car(model, engine, weight, color);
                }
                else if (carTokens.Length == 3)
                {
                    if (IsNumber(carTokens[2]))
                    {
                        var weight = int.Parse(carTokens[2]);
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        var color = carTokens[2];
                        car = new Car(model, engine, color);
                    }
                }
                else
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }

            cars.ForEach(c => Console.WriteLine(c.ToString()));
        }

        private static bool IsNumber(string s)
        {
            try
            {
                int.Parse(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
