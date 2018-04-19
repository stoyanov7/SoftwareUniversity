namespace BoatRacingSimulator.Models.Boats
{
    using Contracts;

    public class PowerBoat : MotorBoat, IPowerBoat
    {
        /// <inheritdoc />
        /// <summary>
        /// Initialize a new instance of <see cref="PowerBoat"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="engine">The first engine.</param>
        /// <param name="secondEngine">The second engine.</param>
        public PowerBoat(string model, int weight, IBoatEngine engine, IBoatEngine secondEngine)
            : base(model, weight, engine)
        {
            this.SecondEngine = secondEngine;
        }

        /// <summary>
        /// The second engine of <see cref="PowerBoat"/>
        /// </summary>
        public IBoatEngine SecondEngine { get; private set; }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = 
                this.Engine.Output 
                + this.SecondEngine.Output
                - this.Weight + (race.OceanCurrentSpeed / 5d);

            return speed;
        }
    }
}