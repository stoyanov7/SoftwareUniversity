namespace Vehicles
{
    using System;
    using Factories;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var carData = Console.ReadLine().Split();
            var car = VehicleFactory.ProduceVehicle(carData);

            var truckData = Console.ReadLine().Split();
            var truck = VehicleFactory.ProduceVehicle(truckData);

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (var i = 0; i <  numberOfCommands ; i++)
            {
                var line = Console.ReadLine().Split();

                var command = line[0];
                var vehicleType = line[1];
                var value = double.Parse(line[2]);

                if (command == "Drive")
                {
                    Console.WriteLine(vehicleType == "Car"
                        ? car.Drive(value)
                        : truck.Drive(value));
                }
                else if (command == "Refuel")
                {
                    switch (vehicleType)
                    {
                        case "Car":
                            car.Refuel(value);
                            break;
                        case "Truck":
                            truck.Refuel(value);
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
