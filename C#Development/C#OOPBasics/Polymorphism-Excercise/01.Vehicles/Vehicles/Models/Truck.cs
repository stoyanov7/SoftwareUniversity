namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TakenFuelInCharging = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double airConditioningConsumption)
            : base(fuelQuantity, fuelConsumption, airConditioningConsumption)
        {
        }

        public override void Refuel(double fuel)
        {
            fuel *= TakenFuelInCharging;
            base.Refuel(fuel);
        }
    }
}