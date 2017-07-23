namespace _10.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine) : this(model, engine, -1, "n/a") { }

        public Car(string model, Engine engine, int weight) : this(model, engine, weight, "n/a") { }

        public Car(string model, Engine engine, string color) : this(model, engine, -1, color) { }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }
    }
}