namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class AddTeamToCommand : ICommand
    {
        private readonly IEventService eventService;
        private readonly ITeamService teamService;

        public AddTeamToCommand(IEventService eventService, ITeamService teamService)
        {
            this.eventService = eventService;
            this.teamService = teamService;
        }

        public string Execute(string[] args)
        {
            Validator.CheckLength(2, args);

            var eventName = args[0];
            var teamName = args[1];

            if (!this.eventService.IsEventExist(eventName))
            {
                throw new ArgumentException(string.Format(Constants.EventNotFound, eventName));
            }

            if (!this.teamService.IsTeamExist(teamName))
            {
                throw new ArgumentException(string.Format(Constants.TeamNotFound, teamName));
            }

            var currentUser = AuthenticationManager.GetCurrentUser();

            if (!this.eventService.IsUserCreatorOfEvent(eventName, currentUser))
            {
                throw new InvalidOperationException(Constants.NotAllowed);
            }

            if (this.eventService.IsTeamInEvent(eventName, teamName))
            {
                throw new InvalidOperationException(Constants.CannotAddSameTeamTwice);
            }

            this.eventService.AddTeamToEvent(teamName, eventName);

            return string.Format(Constants.SuccessfullyAddedTeamToEvent, teamName, eventName);
        }
    }
}