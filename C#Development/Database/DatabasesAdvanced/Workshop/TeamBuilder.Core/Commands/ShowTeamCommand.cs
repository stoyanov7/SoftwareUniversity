namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class ShowTeamCommand : ICommand
    {
        private readonly ITeamService teamService;

        public ShowTeamCommand(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public string Execute(string[] args)
        {
            Validator.CheckLength(1, args);

            var teamName = args[0];

            if (!this.teamService.IsTeamExist(teamName))
            {
                throw new ArgumentException(string.Format(Constants.TeamNotFound, teamName));
            }

            var result = this.teamService.PrintTeam(teamName);
            return result;
        }
    }
}