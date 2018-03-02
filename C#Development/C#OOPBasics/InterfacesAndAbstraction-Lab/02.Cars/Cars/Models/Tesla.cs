namespace Cars.Models
{
    using Contracts;

    public class Tesla : Vehicle, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; }

        public override string ToString() => $"{base.ToString()} with {this.Battery} Batteries {this.PrintEngine()}";
    }
}