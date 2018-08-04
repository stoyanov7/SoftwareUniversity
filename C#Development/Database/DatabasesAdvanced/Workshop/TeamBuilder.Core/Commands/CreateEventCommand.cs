namespace TeamBuilder.Core.Commands
{
    using System;
    using System.Globalization;
    using Contracts;
    using Utilities;
    using Services.Contracts;

    public class CreateEventCommand : ICommand
    {
        private readonly IEventService eventService;

        public CreateEventCommand(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public string Execute(string[] args)
        {
            Validator.CheckLength(6, args);
            var currentUser = AuthenticationManager.GetCurrentUser();

            var name = args[0];
            var description = args[1];
            var startDateString = $"{args[2]} {args[3]}";
            var endDateString = $"{args[4]} {args[5]}";

            var isValidStartDate = DateTime
                .TryParseExact(startDateString, Constants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate);

            var isValidEndDate = DateTime
                .TryParseExact(endDateString, Constants.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate);

            if (!isValidStartDate || !isValidEndDate)
            {
                throw new ArgumentException(Constants.InvalidDateFormat);
            }

            if (startDate > endDate)
            {
                throw new ArgumentException(Constants.StartDate);
            }

            this.eventService.CreateEvent(name, description, startDate, endDate, currentUser.Id);

            return string.Format(Constants.SuccessfullyCreatedEvent, name);
        }
    }
}