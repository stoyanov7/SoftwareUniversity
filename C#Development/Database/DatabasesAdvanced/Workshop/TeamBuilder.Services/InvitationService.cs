namespace TeamBuilder.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class InvitationService : IInvitationService
    {
        private readonly TeamBuilderContext context;

        public InvitationService(TeamBuilderContext context) => this.context = context;

        public bool IsInviteExisting(string teamName, User user)
        {
            return this.context
                .Invitations
                .Any(i => i.Team.Name == teamName &&
                          i.InvitedUserId == user.Id && i.IsActive);
        }

        public void CreateInvitation(User user, Team team)
        {
            var invitation = new Invitation
            {
                InvitedUserId = user.Id,
                TeamId = team.Id,
                IsActive = false
            };

            this.context.Invitations.Add(invitation);
            this.context.SaveChanges();
        }

        public Invitation GetInvitationByTeamName(string teamName, User user)
        {
            return this.context
                .Invitations
                .Include(i => i.Team)
                .FirstOrDefault(i => i.Team.Name.ToLower() == teamName.ToLower() &&
                                     i.InvitedUserId == user.Id);
        }
    }
}