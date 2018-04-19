namespace BoatRacingSimulator.Models.Boats
{
    using Contracts;

    public abstract class MotorBoat : Boat, IMotorBoat
    {
        protected MotorBoat(string model, int weight, IBoatEngine engine)
            : base(model, weight)
        {
            this.Engine = engine;
        }

        /// <summary>
        /// The engine of the <see cref="MotorBoat"/>.
        /// </summary>
        public IBoatEngine Engine { get; private set; }
    }
}