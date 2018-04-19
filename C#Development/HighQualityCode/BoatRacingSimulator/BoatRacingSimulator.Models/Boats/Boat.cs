namespace BoatRacingSimulator.Models.Boats
{
    using Contracts;
    using Utility;
    using Validator = Utility.Validator;

    public abstract class Boat : IBoat
    {
        private string model;
        private int weight;

        protected Boat(string model, int weight)
        {
            this.Model = model;
            this.Weight = weight;
        }

        /// <summary>
        /// The model of the <see cref="Boat"/>.
        /// </summary>
        public string Model
        {
            get => this.model;

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatModelLength);
                this.model = value;
            }
        }

        /// <summary>
        /// The weigth of the <see cref="Boat"/>
        /// </summary>
        public int Weight
        {
            get => this.weight;

            private set
            {
                Validator.ValidatePropertyValue(value, this.GetType().Name);
                this.weight = value;
            }
        }

        public abstract double CalculateRaceSpeed(IRace race);
    }
}