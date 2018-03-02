namespace Ferrari.Models
{
    using Contracts;

    public class Ferrari : IFerrari
    {
        private const string Model = "488-Spider";

        public Ferrari(string driver) => this.Driver = driver;

        public string Driver { get; set; }

        public string UseBrake() => "Brakes!";

        public string PushGasPedal() => "Zadu6avam sA!";

        public override string ToString() => $"{Model}/{this.UseBrake()}/{this.PushGasPedal()}/{this.Driver}";
    }
}