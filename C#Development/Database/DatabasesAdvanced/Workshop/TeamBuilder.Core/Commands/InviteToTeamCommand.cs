namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class InviteToTeamCommand : ICommand
    {
        private readonly ITeamService teamService;
        private readonly IUserService userService;
        private readonly IInvitationService invitationService;
        private readonly IUserTeamService userTeamService;

        public InviteToTeamCommand(ITeamService teamService, IUserService userService, IInvitationService invitationService, IUserTeamService userTeamService)
        {
            this.teamService = teamService;
            this.userService = userService;
            this.invitationService = invitationService;
            this.userTeamService = userTeamService;
        }

        public string Execute(string[] args)
        {
            Validator.CheckLength(2, args);
            var currentUser = AuthenticationManager.GetCurrentUser();

            var teamName = args[0];
            var username = args[1];

            var isCurrentUserMemberOfTeam = this.teamService.IsMemberOfTeam(teamName, currentUser.Username);
            var isMemberOfTeam = this.teamService.IsMemberOfTeam(teamName, username);

            if (!isCurrentUserMemberOfTeam || isMemberOfTeam)
            {
                throw new InvalidOperationException(Constants.NotAllowed);
            }

            var isTeamExist = this.teamService.IsTeamExist(teamName);
            var isUserExist = this.userService.IsUserExisting(username);

            if (!isTeamExist || !isUserExist)
            {
                throw new ArgumentException(Constants.TeamOrUserNotExist);
            }

            var invitedUser = this.userService.GetUserByUsername(username);
            if (this.invitationService.IsInviteExisting(teamName, invitedUser))
            {
                throw new InvalidOperationException(Constants.InviteIsAlreadySent);
            }

            var isUserCreatorOfTheTeam = this.userService
                .IsUserCreatorOfTeam(teamName, currentUser);

            string result = null;

            if (isUserCreatorOfTheTeam)
            {
                var team = this.teamService.GetTeam(teamName);
                this.invitationService.CreateInvitation(invitedUser, team);
                this.userTeamService.CreateUserTeam(team.Id, invitedUser.Id);
                result = string.Format(Constants.SuccessfullyAddedToTeam, invitedUser.Username, teamName);
            }
            else
            {
                var team = this.teamService.GetTeam(teamName);
                this.invitationService.CreateInvitation(invitedUser, team);
                result = string.Format(Constants.SuccessfullySentInvitation, teamName, invitedUser.Username);
            }

            return result;
        }
    }
}