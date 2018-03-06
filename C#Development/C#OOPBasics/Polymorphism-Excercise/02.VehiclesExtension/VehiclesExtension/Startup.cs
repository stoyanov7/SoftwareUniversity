namespace VehiclesExtension
{
    using System;
    using Factories;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var car = VehicleFactory.ProduceVehicle(carInfo);

            var truckInfo = Console.ReadLine().Split();
            var truck = VehicleFactory.ProduceVehicle(truckInfo);

            var busInfo = Console.ReadLine().Split();
            var bus = VehicleFactory.ProduceVehicle(busInfo);

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine().Split();
                var command = commandArgs[0];
                var typeOfVehicle = commandArgs[1];
                var givenParam = double.Parse(commandArgs[2]);

                Vehicle vehicleToOperate;
                switch (typeOfVehicle)
                {
                    case "Car":
                        vehicleToOperate = car;
                        break;
                    case "Truck":
                        vehicleToOperate = truck;
                        break;
                    default:
                        vehicleToOperate = bus;
                        break;
                }

                try
                {
                    switch (command)
                    {
                        case "Drive":
                            vehicleToOperate.Drive(givenParam);
                            Console.WriteLine($"{vehicleToOperate.GetType().Name} travelled {givenParam} km");
                            break;
                        case "DriveEmpty":
                            ((Bus) vehicleToOperate).DriveEmpty(givenParam);
                            Console.WriteLine($"{vehicleToOperate.GetType().Name} travelled {givenParam} km");
                            break;
                        case "Refuel":
                            vehicleToOperate.Refuel(givenParam);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}