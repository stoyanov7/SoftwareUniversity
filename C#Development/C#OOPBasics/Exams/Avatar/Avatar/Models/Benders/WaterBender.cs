namespace Avatar.Models.Benders
{
    public class WaterBender : Bender
    {
        public WaterBender(string name, int power, double waterClarity)
            : base(name, power)
        {
            this.WaterClarity = waterClarity;
        }

        public double WaterClarity { get; private set; }

        public override double GetBenderPower() => this.Power * this.WaterClarity;

        public override string ToString()
        {
            return $"{base.ToString()} Water Clarity: {this.WaterClarity:F2}";
        }
    }
}