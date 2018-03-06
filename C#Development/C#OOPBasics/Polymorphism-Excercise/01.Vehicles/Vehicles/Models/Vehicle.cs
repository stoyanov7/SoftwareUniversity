namespace Vehicles.Models
{
    public class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditioningConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.AirConditioningConsumption = airConditioningConsumption;
        }

        private double FuelQuantity { get; set; }

        private double FuelConsumption { get; set; }

        private double AirConditioningConsumption { get; set; }

        public string Drive(double distance)
        {
            var neededFuel = (this.FuelConsumption + this.AirConditioningConsumption) * distance;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters) => this.FuelQuantity += liters;

        public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}