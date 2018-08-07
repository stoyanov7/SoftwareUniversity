namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class AcceptInviteCommand : ICommand
    {
        private readonly ITeamService teamService;
        private readonly IInvitationService invitationService;

        public AcceptInviteCommand(ITeamService teamService, IInvitationService invitationService)
        {
            this.teamService = teamService;
            this.invitationService = invitationService;
        }

        public string Execute(string[] args)
        {
            Validator.CheckLength(1, args);

            var currentUser = AuthenticationManager.GetCurrentUser();
            var teamName = args[0];

            if (!this.teamService.IsTeamExist(teamName))
            {
                throw new ArgumentException(string.Format(Constants.TeamNotFound, teamName));
            }

            if (!this.invitationService.IsInviteExisting(teamName, currentUser))
            {
                throw new ArgumentException(string.Format(Constants.InviteNotFound, teamName));
            }

            var invitation = this.invitationService.GetInvitationByTeamName(teamName, currentUser);

            if (invitation == null)
            {
                throw new ArgumentException(string.Format(Constants.InviteNotFound, teamName));
            }

            return string.Format(Constants.SuccessfullyAcceptedInvitation, currentUser.Username, teamName);
        }
    }
}