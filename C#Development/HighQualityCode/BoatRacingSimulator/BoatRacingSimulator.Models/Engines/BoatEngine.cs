namespace BoatRacingSimulator.Models.Engines
{
    using Contracts;
    using Utility;

    public abstract class BoatEngine : IBoatEngine
    {
        private string model;
        private int horsepower;
        private int displacement;

        /// <summary>
        /// Initialize a new instance of <see cref="BoatEngine"/>
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="horsepower">The horsepower.</param>
        /// <param name="displacement">The displacement.</param>
        protected BoatEngine(string model, int horsepower, int displacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.Displacement = displacement;
        }

        /// <summary>
        /// The model of the <see cref="BoatEngine"/>
        /// </summary>
        public string Model
        {
            get => this.model;

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                this.model = value;
            }
        }

        /// <summary>
        /// The output.
        /// </summary>
        public abstract int Output { get; }

        /// <summary>
        /// The cached output.
        /// </summary>
        protected int CachedOutput { get; set; }

        /// <summary>
        /// The horsepower of the <see cref="BoatEngine"/>
        /// </summary>
        protected int Horsepower
        {
            get => this.horsepower;

            private set
            {
                Validator.ValidatePropertyValue(value, this.GetType().Name);
                this.horsepower = value;
            }
        }

        /// <summary>
        /// The dispacement of the <see cref="BoatEngine"/>
        /// </summary>
        protected int Displacement
        {
            get => this.displacement;

            private set
            {
                Validator.ValidatePropertyValue(value, this.GetType().Name);
                this.displacement = value;
            }
        }
    }
}