namespace BoatRacingSimulator.Models.Engines
{
    public class JetEngine : BoatEngine
    {
        private const int Multiplier = 5;

        public JetEngine(string model, int horsepower, int displacement)
            : base(model, horsepower, displacement)
        {
        }

        public override int Output
        {
            get
            {
                if (this.CachedOutput != 0)
                {
                    return this.CachedOutput;
                }

                this.CachedOutput = (this.Horsepower * Multiplier) + this.Displacement;
                return this.CachedOutput;
            }
        }
    }
}