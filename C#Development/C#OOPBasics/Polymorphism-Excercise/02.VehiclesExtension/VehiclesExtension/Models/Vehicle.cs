namespace VehiclesExtension.Models
{
    using System;

    public abstract class Vehicle
    {
        public const string InsufficientFuelErrorMessage = "{0} needs refueling";
        public const string FuelAmountError = "Fuel must be a positive number";
        public const string ExessFuelErrorMessage = "Cannot fit {0} fuel in the tank";
        public const double CarACExtraConsumption = 0.9;
        public const double TruckACExtraConsumption = 1.6;
        public const double BusACExtraConsumption = 1.4;
        public const double FuelLossRatio = 0.95;

        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(FuelAmountError);
                }

                this.fuelQuantity = value > this.TankCapacity ? 0 : value;
            }
        }

        public virtual double FuelConsumptionPerKm { get; set; }

        public double TankCapacity { get; set; }

        public virtual void Drive(double distance)
        {
            var fuelNeeded = distance * (this.FuelConsumptionPerKm);

            if (fuelNeeded > this.FuelQuantity)
            {
                throw new ArgumentException(string.Format(InsufficientFuelErrorMessage, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(FuelAmountError);
            }

            if (this.fuelQuantity + amount > this.TankCapacity)
            {
                throw new ArgumentException(string.Format(ExessFuelErrorMessage, amount));
            }

            this.FuelQuantity += amount;
        }

        public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}