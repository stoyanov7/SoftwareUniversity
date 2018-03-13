namespace Avatar.Models.Monuments
{
    public class AirMonument : Monument
    {
        public AirMonument(string name, int airAffinity)
            : base(name)
        {
            this.AirAffinity = airAffinity;
        }

        public int AirAffinity { get; private set; }

        public override double GetMonumentBonus()
        {
            return this.AirAffinity;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Air Affinity: {this.AirAffinity}";
        }
    }
}