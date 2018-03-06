namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double airConditioningConsumption)
            : base(fuelQuantity, fuelConsumption, airConditioningConsumption)
        {
        }
    }
}