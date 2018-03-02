namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Car
    {
        public Car(Func<string> readData)
        {
            var dataTokens = readData()
                .Split(" ")
                .ToArray();

            this.Model = dataTokens[0];
            this.EngineSpeed = int.Parse(dataTokens[1]);
            this.EnginePower = int.Parse(dataTokens[2]);
            this.CargoWeight = int.Parse(dataTokens[3]);
            this.CargoType = dataTokens[4];

            this.Tires = new[]
            {
                KeyValuePair.Create(double.Parse(dataTokens[5]), int.Parse(dataTokens[6])),
                KeyValuePair.Create(double.Parse(dataTokens[7]), int.Parse(dataTokens[8])),
                KeyValuePair.Create(double.Parse(dataTokens[9]), int.Parse(dataTokens[10])),
                KeyValuePair.Create(double.Parse(dataTokens[11]), int.Parse(dataTokens[12]))
            };
        }

        public string Model { get; private set; }

        public string CargoType { get; }

        public KeyValuePair<double, int>[] Tires { get; private set; }

        public int EnginePower { get; private set; }

        public int EngineSpeed { get; private set; }

        public int CargoWeight { get; private set; }
    }
}