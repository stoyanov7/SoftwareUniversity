namespace BoatRacingSimulator.Models
{
    using System.Collections.Generic;
    using Contracts;
    using Exceptions;
    using Utility;

    public class Race : IRace
    {
        private int distance;

        public Race(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            this.Distance = distance;
            this.WindSpeed = windSpeed;
            this.OceanCurrentSpeed = oceanCurrentSpeed;
            this.AllowMotorboats = allowsMotorboats;
            this.RegisteredBoats = new Dictionary<string, IBoat>();
        }

        /// <summary>
        /// The distance of the current Race.
        /// </summary>
        public int Distance
        {
            get => this.distance;

            private set
            {
                Validator.ValidatePropertyValue(value, "Distance");
                this.distance = value;
            }
        }

        /// <summary>
        /// The wind speed of the current race.
        /// </summary>
        public int WindSpeed { get; private set; }

        /// <summary>
        /// The speed of the ocean current in the current Race.
        /// </summary>
        public int OceanCurrentSpeed { get; private set; }

        /// <summary>
        /// A boolean property indicating whether Motorboats(boats with engines) are allowed.
        /// </summary>
        public bool AllowMotorboats { get; private set; }

        protected Dictionary<string, IBoat> RegisteredBoats { get; set; }

        /// <summary>
        /// A method for adding boats to the inner collection of participants for the current Race.
        /// </summary>
        /// <param name="boat">The boat to be added to the Race participants</param>
        public void AddParticipant(IBoat boat)
        {
            if (this.RegisteredBoats.ContainsKey(boat.Model))
            {
                throw new DuplicateModelException(Constants.DuplicateModelMessage);
            }

            this.RegisteredBoats.Add(boat.Model, boat);
        }

        /// <summary>
        /// A method which returns a copy of the collection of participants.
        /// </summary>
        /// <returns>Returns a copy of the collection of participants.</returns>
        public IList<IBoat> GetParticipants() => new List<IBoat>(this.RegisteredBoats.Values);
    }
}