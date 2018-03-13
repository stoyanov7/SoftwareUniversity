namespace Avatar.Models.Benders
{
    public class AirBender : Bender
    {
        public AirBender(string name, int power, double aerialIntegrity)
            : base(name, power)
        {
            this.AerialIntegrity = aerialIntegrity;
        }

        public double AerialIntegrity { get; private set; }

        public override double GetBenderPower() => this.Power * this.AerialIntegrity;

        public override string ToString()
        {
            return $"{base.ToString()} Aerial Integrity: {this.AerialIntegrity:F2}";
        }
    }
}