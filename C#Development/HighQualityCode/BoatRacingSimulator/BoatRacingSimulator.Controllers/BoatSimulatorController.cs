namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Database;
    using Database.Contracts;
    using Enumerations;
    using Exceptions;
    using Factories;
    using Factories.Contracts;
    using Models;
    using Models.Boats;
    using Models.Contracts;
    using Utility;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        private readonly IEngineFactory engineFactory;

        public BoatSimulatorController(IBoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
            this.engineFactory = new EngineFactory();
        }

        public BoatSimulatorController()
            : this(new BoatSimulatorDatabase(), null)
        {
            this.engineFactory = new EngineFactory();
        }

        public IRace CurrentRace { get; private set; }

        public IBoatSimulatorDatabase Database { get; private set; }

        /// <summary>
        /// A method that creates different types of boat engines and saves them in the database.
        /// </summary>
        /// <param name="model">The model of the desired engine.</param>
        /// <param name="horsepower">The horsepower of the engine.</param>
        /// <param name="displacement">The water displacement of the engine.</param>
        /// <param name="engineType">The type of the engine.</param>
        /// <returns>Returns a string message signifying the result of the action.</returns>
        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            var engine = this.engineFactory.CreateEngine(model, horsepower, displacement, engineType);
            this.Database.Engines.Add(engine);

            return string.Format(Constants.SuccessfullCreateBoatEngine, model, horsepower, displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat boat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(boat);

            return string.Format(Constants.SuccessfullCreateBoat, "Row boat", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);

            return string.Format(Constants.SuccessfullCreateBoat, "Sail boat", model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            var firstEngine = this.Database.Engines.GetItem(firstEngineModel);
            var secondEngine = this.Database.Engines.GetItem(secondEngineModel);
            IBoat boat = new PowerBoat(model, weight, firstEngine, secondEngine);
            this.Database.Boats.Add(boat);

            return string.Format(Constants.SuccessfullCreateBoat, "Power boat", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            var engine = this.Database.Engines.GetItem(engineModel);
            IBoat boat = new Yacht(model, weight, engine, cargoWeight);
            this.Database.Boats.Add(boat);

            return string.Format(Constants.SuccessfullCreateBoat, "Yacht", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.ValidateRaceIsEmpty();
            this.CurrentRace = race;

            return string.Format(Constants.OpenRaceMessage, distance, windSpeed, oceanCurrentSpeed);
        }

        public string SignUpBoat(string model)
        {
            var boat = this.Database.Boats.GetItem(model);
            this.ValidateRaceIsSet();

            if (!this.CurrentRace.AllowMotorboats && boat is MotorBoat)
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            this.CurrentRace.AddParticipant(boat);
            return string.Format(Constants.SignUpBoatMessage, model);
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();
            var participants = this.CurrentRace.GetParticipants();

            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var raceResults = new List<KeyValuePair<double, IBoat>>();

            foreach (var participant in participants)
            {
                var speed = participant.CalculateRaceSpeed(this.CurrentRace);

                if (speed <= 0)
                {
                    raceResults.Add(new KeyValuePair<double, IBoat>(double.PositiveInfinity, participant));
                }
                else
                {
                    var time = this.CurrentRace.Distance / speed;
                    raceResults.Add(new KeyValuePair<double, IBoat>(time, participant));
                }
            }

            raceResults = raceResults.OrderBy(x => x.Key).ToList();

            var first = raceResults[0];
            var second = raceResults[1];
            var third = raceResults[2];

            var result = new StringBuilder();
            result.AppendLine(
                $"First place: {first.Value.GetType().Name} Model: {first.Value.Model} Time: {(double.IsInfinity(first.Key) ? "Did not finish!" : first.Key.ToString("0.00") + " sec")}");

            result.AppendLine(
                $"Second place: {second.Value.GetType().Name} Model: {second.Value.Model} Time: {(double.IsInfinity(second.Key) ? "Did not finish!" : second.Key.ToString("0.00") + " sec")}");

            result.Append(
                $"Third place: {third.Value.GetType().Name} Model: {third.Value.Model} Time: {(double.IsInfinity(third.Key) ? "Did not finish!" : third.Key.ToString("0.00") + " sec")}");

            this.CurrentRace = null;

            return result.ToString();
        }

        public string GetStatistic()
        {
            var percentagesByType = new SortedDictionary<string, double>();
            var participants = this.CurrentRace.GetParticipants();

            foreach (var participant in participants)
            {
                var name = participant.GetType().Name;

                if (!percentagesByType.ContainsKey(name))
                {
                    percentagesByType.Add(name, 0);
                }

                percentagesByType[name]++;
            }

            var result = new StringBuilder();

            foreach (var type in percentagesByType)
            {
                result.AppendLine($"{type.Key} -> {(type.Value / participants.Count) * 100:F2}%");
            }

            result.Remove(result.Length - 2, 2);

            return result.ToString();
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NotSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}