namespace Cars.Models
{
    using Contracts;

    public abstract class Vehicle : ICar
    {
        protected Vehicle(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; }

        public string Color { get; }

        public string PrintEngine() => $"\n{this.Start()}{this.Stop()}";

        public override string ToString() => $"{this.Color} {this.GetType().Name} {this.Model}";

        private string Start() => "Engine start\n";

        private string Stop() => "Breaaak!\n";
    }
}