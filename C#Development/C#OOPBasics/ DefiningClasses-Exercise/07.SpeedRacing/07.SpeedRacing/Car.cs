namespace _07.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double distanceTravel;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.DistanceTravel = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double DistanceTravel { get; set; }

        public static bool CanDrive(Car car, double distance)
        {
            var km = car.FuelAmount / car.FuelConsumption;

            if (km >= distance)
            {
                var liters = distance * car.FuelConsumption;
                car.FuelAmount -= liters;
                car.DistanceTravel += distance;
                return true;
            }

            return false;
        }

        public override string ToString() => $"{this.Model} {this.FuelAmount:f2} {(int) DistanceTravel}";
    }
}