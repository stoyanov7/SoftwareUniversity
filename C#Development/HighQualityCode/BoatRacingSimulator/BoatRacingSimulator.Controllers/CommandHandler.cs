namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Enumerations;
    using Utility;

    public class CommandHandler : ICommandHandler
    {
        public CommandHandler()
            : this(new BoatSimulatorController())
        {
        }

        public CommandHandler(IBoatSimulatorController controller)
        {
            this.Controller = controller;
        }

        public IBoatSimulatorController Controller { get; private set; }

        public string ExecuteCommand(string name, string[] parameters)
        {
            switch (name)
            {
                case "CreateBoatEngine":
                    return this.CreateBoatEngine(parameters);
                case "CreateSailBoat":
                    return this.CreateSailBoat(parameters);
                case "CreatePowerBoat":
                    return this.CreatePowerBoat(parameters);
                case "CreateRowBoat":
                    return this.CreateRowBoat(parameters);
                case "CreateYacht":
                    return this.CreateYaht(parameters);
                case "OpenRace":
                    return this.OpenRace(parameters);
                case "SignUpBoat":
                    return this.Controller.SignUpBoat(parameters[0]);
                case "StartRace":
                    return this.Controller.StartRace();
                case "GetStatistic":
                    return this.Controller.GetStatistic();
                default:
                    throw new InvalidOperationException();
            }
        }

        private string CreateBoatEngine(IReadOnlyList<string> parameters)
        {
            if (Enum.TryParse(parameters[3], out EngineType engineType))
            {
                return this.Controller.CreateBoatEngine(
                    parameters[0],
                    int.Parse(parameters[1]),
                    int.Parse(parameters[2]),
                    engineType);
            }

            throw new ArgumentException(Constants.IncorrectEngineTypeMessage);
        }

        private string CreateSailBoat(IReadOnlyList<string> parameters)
        {
            return this.Controller.CreateSailBoat(
                parameters[0],
                int.Parse(parameters[1]),
                int.Parse(parameters[2]));
        }

        private string CreatePowerBoat(IReadOnlyList<string> parameters)
        {
            return this.Controller.CreatePowerBoat(
                parameters[0],
                int.Parse(parameters[1]),
                parameters[2],
                parameters[3]);
        }

        private string CreateRowBoat(IReadOnlyList<string> parameters)
        {
            return this.Controller.CreateRowBoat(
                parameters[0],
                int.Parse(parameters[1]),
                int.Parse(parameters[2]));
        }

        private string CreateYaht(IReadOnlyList<string> parameters)
        {
            return this.Controller.CreateYacht(
                parameters[0],
                int.Parse(parameters[1]),
                parameters[2],
                int.Parse(parameters[3]));
        }

        private string OpenRace(IReadOnlyList<string> parameters)
        {
            return this.Controller.OpenRace(
                int.Parse(parameters[0]),
                int.Parse(parameters[1]),
                int.Parse(parameters[2]),
                bool.Parse(parameters[3]));
        }
    }
}