namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class DisbandCommand : ICommand
    {
        private readonly ITeamService teamService;

        public DisbandCommand(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public string Execute(string[] args)
        {
            Validator.CheckLength(1, args);

            var teamName = args[0];

            if (this.teamService.IsTeamExist(teamName))
            {
                throw new ArgumentException(string.Format(Constants.TeamNotFound, teamName));
            }

            var currentUser = AuthenticationManager.GetCurrentUser();

            if (this.teamService.IsUserCreatorOfTeam(teamName, currentUser))
            {
                throw new InvalidOperationException(Constants.NotAllowed);
            }

            this.teamService.Disband(teamName);

            return string.Empty;
        }
    }
}