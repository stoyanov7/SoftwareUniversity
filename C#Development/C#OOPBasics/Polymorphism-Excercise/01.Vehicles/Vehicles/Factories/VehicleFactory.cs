namespace Vehicles.Factories
{
    using Models;

    public static class VehicleFactory
    {
        private const double CarAirConditionConsumption = 0.9;
        private const double TruckAirConditionConsumption = 1.6;

        public static Vehicle ProduceVehicle(string[] vehicles)
        {
            Vehicle vehicle = null;

            var type = vehicles[0];
            var fuelQuantity = double.Parse(vehicles[1]);
            var litersPerKm = double.Parse(vehicles[2]);

            switch (type)
            {
                case "Car":
                    vehicle =  new Car(fuelQuantity, litersPerKm, CarAirConditionConsumption);
                    break;
                case "Truck":
                    vehicle = new Truck(fuelQuantity, litersPerKm, TruckAirConditionConsumption);
                    break;
            }

            return vehicle;
        }
    }
}