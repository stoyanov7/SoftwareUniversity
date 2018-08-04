namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class CreateTeamCommand : ICommand
    {
        private readonly ITeamService teamService;
        private readonly IUserTeamService userTeamService;

        public CreateTeamCommand(ITeamService teamService, IUserTeamService userTeamService)
        {
            this.teamService = teamService;
            this.userTeamService = userTeamService;
        }

        public string Execute(string[] args)
        {
            if (args.Length != 3 && args.Length != 2)
            {
                throw new InvalidOperationException(Constants.InvalidArgumentsCount);
            }

            var currentUser = AuthenticationManager.GetCurrentUser();

            var name = args[0];
            var acronym = args[1];
            string description = null;

            if (args.Length == 3)
            {
                description = args[2];
            }

            if (this.teamService.IsTeamExist(name))
            {
                throw new ArgumentException(string.Format(Constants.TeamExists, name));
            }
            
            if (!this.teamService.IsAcronymValid(acronym))
            {
                throw new ArgumentException(string.Format(Constants.InvalidAcronym, acronym));
            }
            
            this.teamService.CreateTeam(name, acronym, description, currentUser.Id);
            var team = this.teamService.GetTeam(name);

            this.userTeamService.CreateUserTeam(team.Id, currentUser.Id);

            return string.Format(Constants.SuccessfullyCreatedTeam, name);
        }
    }
}