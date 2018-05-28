namespace AirConditionerTesterSystem.Core
{
    using System;
    using Contracts;
    using Utilities;

    public class Dispatcher : IDispatcher
    {
        private readonly IController controller;

        public Dispatcher(IController controller)
        {
            this.controller = controller;
        }

        public string DispatchAction(IAction command)
        {
            switch (command.Name)
            {
                case "RegisterStationaryAirConditioner":
                    this.ValidateParametersCount(command, 4);
                    return this.controller.RegisterStationaryAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1],
                        char.Parse(command.Parameters[2]),
                        int.Parse(command.Parameters[3]));
                case "RegisterCarAirConditioner":
                    this.ValidateParametersCount(command, 3);
                    return this.controller.RegisterCarAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1],
                        int.Parse(command.Parameters[2]));
                case "RegisterPlaneAirConditioner":
                    this.ValidateParametersCount(command, 4);
                    return this.controller.RegisterPlaneAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1],
                        int.Parse(command.Parameters[2]),
                        int.Parse(command.Parameters[3]));
                case "TestAirConditioner":
                    this.ValidateParametersCount(command, 2);
                    return this.controller.TestAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1]);
                case "FindAirConditioner":
                    this.ValidateParametersCount(command, 2);
                    return this.controller.FindAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1]);
                case "FindReport":
                    this.ValidateParametersCount(command, 2);
                    return this.controller.FindReport(
                        command.Parameters[0],
                        command.Parameters[1]);
                case "Status":
                    this.ValidateParametersCount(command, 0);
                    return this.controller.Status();
                case "FindAllReportsByManufacturer":
                    this.ValidateParametersCount(command, 1);
                    return this.controller.FindAllReportsByManufacturer(command.Parameters[0]);
                default:
                    throw new InvalidOperationException(Constants.InvalidCommand);
            }
        }

        private void ValidateParametersCount(IAction command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }
        }
    }
}