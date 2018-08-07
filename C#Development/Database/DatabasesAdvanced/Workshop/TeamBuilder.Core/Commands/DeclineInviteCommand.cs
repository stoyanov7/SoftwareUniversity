namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class DeclineInviteCommand : ICommand
    {
        private readonly IInvitationService invitationService;
        private readonly ITeamService teamService;

        public DeclineInviteCommand(IInvitationService invitationService, ITeamService teamService)
        {
            this.invitationService = invitationService;
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

            var user = AuthenticationManager.GetCurrentUser();

            if (!this.invitationService.IsInviteExisting(teamName, user))
            {
                throw new ArgumentException(string.Format(Constants.InviteNotFound, teamName));
            }

            this.invitationService.DeactivateInvitation(user, teamName);

            return string.Format(Constants.SuccessfullyJoinedTeam, user.Username, teamName);
        }
    }
}