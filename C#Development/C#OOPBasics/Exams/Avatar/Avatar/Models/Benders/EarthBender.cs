namespace Avatar.Models.Benders
{
    public class EarthBender : Bender
    {
        public EarthBender(string name, int power, double groundSaturation)
            : base(name, power)
        {
            this.GroundSaturation = groundSaturation;
        }

        public double GroundSaturation { get; private set; }

        public override double GetBenderPower() => this.Power * this.GroundSaturation;

        public override string ToString()
        {
            return $"{base.ToString()} Ground Saturation: {this.GroundSaturation:F2}";
        }
    }
}