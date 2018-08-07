namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class ShowEventCommand : ICommand
    {
        private readonly IEventService eventService;

        public ShowEventCommand(IEventService eventService) => this.eventService = eventService;

        public string Execute(string[] args)
        {
            Validator.CheckLength(1, args);

            var eventName = args[0];

            if (!this.eventService.IsEventExist(eventName))
            {
                throw new ArgumentException(string.Format(Constants.EventNotFound, eventName));
            }

            var result = this.eventService.PrintEvent(eventName);
            return result;
        }
    }
}