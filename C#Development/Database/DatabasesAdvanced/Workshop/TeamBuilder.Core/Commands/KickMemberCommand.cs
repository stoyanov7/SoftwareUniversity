namespace TeamBuilder.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Utilities;

    public class KickMemberCommand : ICommand
    {
        private readonly ITeamService teamService;
        private readonly IUserService userService;

        public KickMemberCommand(ITeamService teamService, IUserService userService)
        {
            this.teamService = teamService;
            this.userService = userService;
        }

        public string Execute(string[] args)
        {
            Validator.CheckLength(2, args);

            var teamName = args[0];
            var username = args[1];

            if (!this.teamService.IsTeamExist(teamName))
            {
                throw new ArgumentException(string.Format(Constants.TeamNotFound, teamName));
            }

            if (!this.userService.IsUserExisting(username))
            {
                throw new ArgumentException(string.Format(Constants.UserNotFound, username));
            }

            if (!this.teamService.IsMemberOfTeam(teamName, username))
            {
                throw new ArgumentException(string.Format(Constants.NotPartOfTeam, username, teamName));
            }

            var currentUser = AuthenticationManager.GetCurrentUser();

            if (!this.teamService.IsUserCreatorOfTeam(teamName, currentUser))
            {
                throw new InvalidOperationException(Constants.NotAllowed);
            }

            if (username == currentUser.Username)
            {
                throw new InvalidOperationException(
                    string.Format(Constants.CommandNotAllowed, "DisbandTeam"));
            }

            this.teamService.KickMember(teamName, username);

            return string.Format(Constants.KickedFromTeam, username, teamName);
        }
    }
}