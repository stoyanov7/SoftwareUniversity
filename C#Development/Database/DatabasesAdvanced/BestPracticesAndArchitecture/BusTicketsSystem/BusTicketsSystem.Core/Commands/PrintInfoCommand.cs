namespace BusTicketsSystem.Core.Commands
{
    using System.Text;
    using Contracts;
    using Models;
    using Services.Contracts;

    public class PrintInfoCommand : ICommand
    {
        private readonly IBusStationService busStationService;

        public PrintInfoCommand(IBusStationService busStationService)
        {
            this.busStationService = busStationService;
        }

        public string Execute(string[] args)
        {
            var busStationId = int.Parse(args[0]);
            var busStation = this.busStationService.ById<BusStation>(busStationId);
            var sb = new StringBuilder();

            sb.AppendLine($"{busStation.Name}, {busStation.Town.Name}");
            sb.AppendLine("Arrivals:");
            foreach (var originStation in busStation.OriginTrips)
            {
                sb.AppendLine($"From {originStation.OriginBusStation.Name} | Arrive at {originStation.ArrivalTime} | {originStation.Status}");
            }

            sb.AppendLine("Departures:");
            foreach (var destinationStation in busStation.DestinationTrips)
            {
                sb.AppendLine($"To {destinationStation.DestinationBusStation.Name} | Depart at {destinationStation.DepartureTime} | {destinationStation.Status}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}