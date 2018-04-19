namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using Contracts;
    using Utility;

    public class SailBoat : Boat, ISailBoat
    {
        private int sailEfficiency;

        /// <summary>
        /// Initialize a new instance of <see cref="SailBoat"/>
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="sailEfficiency">The sail efficiency.</param>
        public SailBoat(string model, int weight, int sailEfficiency) 
            : base(model, weight)
        {
            this.SailEfficiency = sailEfficiency;
        }

        /// <summary>
        /// The sail efficiency of the SailBoat.
        /// </summary>
        public int SailEfficiency
        {
            get => this.sailEfficiency;

            private set
            {
                if (value < Constants.MinSailEfficiency || value > Constants.MaxSailEfficiency)
                {
                    throw new ArgumentException(
                        string.Format(Constants.IncorrectSailEfficiencyMessage, Constants.MinSailEfficiency, Constants.MaxSailEfficiency));
                }

                this.sailEfficiency = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = (race.WindSpeed * (this.SailEfficiency / 100d)) - this.Weight + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}