namespace VehiclesExtension.Factories
{
    using Models;

    public static class VehicleFactory
    {
        public static Vehicle ProduceVehicle(string[] vehicles)
        {
            Vehicle vehicle = null;

            var type = vehicles[0];
            var fuelQuantity = double.Parse(vehicles[1]);
            var fuelConsumptionPerKm = double.Parse(vehicles[2]);
            var tankCapacity = double.Parse(vehicles[3]);

            switch (type)
            {
                case "Car":
                    vehicle = new Car(fuelQuantity, fuelConsumptionPerKm, tankCapacity);
                    break;
                case "Truck":
                    vehicle = new Truck(fuelQuantity, fuelConsumptionPerKm, tankCapacity);
                    break;
                case "Bus":
                    vehicle = new Bus(fuelQuantity, fuelQuantity, tankCapacity);
                    break;
            }

            return vehicle;
        }
    }
}