namespace BoatRacingSimulator.Models.Boats
{
    using Contracts;
    using Utility;

    public class RowBoat : Boat, IRowBoat
    {
        private int oars;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="RowBoat" /> class.
        /// </summary>
        /// <param name="model">Row boat model.</param>
        /// <param name="weight">Row boat weight.</param>
        /// <param name="oars">Row boat oars.</param>
        public RowBoat(string model, int weight, int oars)
            : base(model, weight)
        {
            this.Oars = oars;
        }

        /// <summary>
        /// The oars of the RowBoat.
        /// </summary>
        public int Oars
        {
            get => this.oars;

            private set
            {
                Validator.ValidatePropertyValue(value, this.GetType().Name);
                this.oars = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = (this.Oars * 100) - this.Weight + race.OceanCurrentSpeed;
            return speed;
        }
    }
}