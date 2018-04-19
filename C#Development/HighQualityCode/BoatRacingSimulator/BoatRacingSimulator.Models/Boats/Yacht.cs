namespace BoatRacingSimulator.Models.Boats
{
    using Contracts;
    using Utility;

    public class Yacht : MotorBoat, IYacht
    {
        private int cargoWeight;

        /// <summary>
        /// Initialize a new instance of <see cref="Yacht"/>
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="engine">The engine.</param>
        /// <param name="cargoWeight">The cargo weight.</param>
        public Yacht(string model, int weight, IBoatEngine engine, int cargoWeight)
            : base(model, weight, engine)
        {
            this.CargoWeight = cargoWeight;
        }

        /// <summary>
        /// The cargo weight of <see cref="Yacht"/>
        /// </summary>
        public int CargoWeight
        {
            get => this.cargoWeight;

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.Engine.Output - this.Weight - this.CargoWeight + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}