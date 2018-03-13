namespace Avatar.Models.Benders
{
    public class FireBender : Bender
    {
        public FireBender(string name, int power, double heatAggression)
            : base(name, power)
        {
            this.HeatAggression = heatAggression;
        }

        public double HeatAggression { get; private set; }

        public override double GetBenderPower() => this.Power * this.HeatAggression;

        public override string ToString()
        {
            return $"{base.ToString()} Heat Aggression: {this.HeatAggression:F2}";
        }
    }
}